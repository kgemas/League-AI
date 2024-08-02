using LeagueAI.Libraries.Entities;
using LeagueAI.Libraries.Enums;
using LeagueAI.Libraries.Helper;
using LeagueAI.Libraries.Patterns;
using System;
using System.Collections.Generic;

namespace LeagueAI.Libraries
{
    public class InGame : BasePatternScript
    {
        private readonly List<ItemDto> Items = DEFINE.DefaultItem;
        private readonly Random rand = new Random();
        private int AllyIndex { get; set; }

        public InGame()
        {
            Items = DEFINE.DefaultItem;
            rand = new Random();
        }

        public override void Execute()
        {
            try
            {
                bot.Log(DEFINE.InGameLog);

                client.Initialize();
                game.SetupHandleGame();

                bot.Wait(200);

                game.BringGameToFront();
                game.CenterGameToScreen();
                game.WaitGameStart(120);

                if (game.GetSide() == ESideTeam.ORDER) bot.Log(DEFINE.InGameLog4);
                else bot.Log(DEFINE.InGameLog5);

                game.BringGameToFront();

                FollowStrongest();
                GameLoop();
                Dispose();
            }
            catch (Exception ex) { Logger.WriteLine(ex); }
            Dispose();
        }

        private void GameLoop()
        {
            var level = 0d;
            var followStrongestTime = Environment.TickCount;

            int timeOut;
            while (game.IsGameOpen())
            {
                if (Environment.TickCount - followStrongestTime >= 60000)
                {
                    Program.GameHandle = HandleExtention.GetGameHandle("");
                    game.BringGameToFront();
                    game.CenterGameToScreen();
                    game.CloseWarning(100);
                    game.CloseShopIfOpen(100);

                    followStrongestTime = Environment.TickCount;
                    FollowStrongest();
                }

                timeOut = 0;
                EGameflowPhase status = client.GetGameflowPhase();
                while (status != EGameflowPhase.InProgress || !game.IsAPIReady())
                {
                    timeOut += 5000;
                    bot.Wait(5000);
                    if (timeOut >= 30000)
                    {
                        bot.Warn(DEFINE.InGameLog2);
                        bot.Wait(5000);
                        return;
                    }
                    status = client.GetGameflowPhase();
                }

                game.BringGameToFront();

                var newLevel = game.player.GetLevel();
                while (newLevel >= level)
                {
                    game.player.UpgradeSpellOnLevelUp(level++);
                    bot.Wait(200);
                }

                if (game.player.IsDead())
                {
                    BuyItems();
                    continue;
                }

                double health = game.player.GetHealthPercent();
                if (0 <= health && health <= 0.35d)
                {
                    game.MoveToSafePlace();
                    OnRecall();
                    continue;
                }

                CastAndMove();

                if (CanBuy())
                {
                    game.MoveToSafePlace();
                    OnRecall();
                    continue;
                }
            }
        }
        private void BuyItems()
        {
            double golds = game.player.GetGolds();
            if (golds < 0) return;

            bot.Wait(300);
            game.shop.Toogle(500);
            List<ItemDto> buyedItem = new List<ItemDto>();
            foreach (ItemDto item in Items)
            {
                bot.Wait(200);
                if (item.Cost <= golds
                    && !item.Buyed)
                {
                    game.shop.SearchItem(item.Name, 40, 200);
                    game.shop.BuySearchedItem(80);

                    double newGold = game.player.GetGolds();
                    if (newGold < 0) return;

                    if (newGold < golds) golds = newGold;
                    item.Buyed = true;
                    buyedItem.Add(item);
                }
            }
            game.shop.Toogle(200);
            bot.Wait(200);
        }

        private bool CanBuy()
        {
            double golds = game.player.GetGolds();
            if (golds < 0) return false;

            foreach (ItemDto item in Items)
            {
                if (item.Cost <= golds && !item.Buyed) return true;
            }
            return false;
        }

        private void OnRecall(int timeWait = 8500)
        {
            game.player.Recall(timeWait);
            BuyItems();
            var health = game.player.GetHealthPercent();
            if (health >= 0d && health <= 0.70d)
            {
                OnRecall(timeWait);
                return;
            }
            FollowStrongest();
        }

        private void SmartGoToSafePlace()
        {
            game.MoveToSafePlace();
            for (int i = 0; i < 5; i++)
            {
                if (!game.FoundEnemy()) break;
                game.MoveToSafePlace();
            }
        }

        private void SmartRecall(int timeWait = 9000)
        {
            InputHelper.PressKey("B", 50);
            for (int i = 0; i < 9; i++)
            {
                if (game.FoundEnemy())
                {
                    game.MoveToSafePlace(4000);
                    SmartRecall(timeWait);
                    return;
                }
                bot.Wait(1000);
            }
            BuyItems();
            var health = game.player.GetHealthPercent();
            if (health >= 0d && health <= 0.70d) game.player.Recall(timeWait);
        }

        private void FollowStrongest()
        {
            try
            {
                var newAllyFollow = game.GetAllyIdToFollow();
                if (newAllyFollow >= 1)
                {
                    AllyIndex = newAllyFollow;
                    game.camera.LockAlly(AllyIndex);
                    game.camera.PingComing();
                }
            }
            catch (Exception ex) { Logger.WriteLine(ex, showLog: false); }
        }

        private void CastAndMove()
        {
            try
            {
                game.MoveRandomCenter(300);
                string skills = "QWERDFA";
                var attackSkill = skills[rand.Next(0, skills.Length)];
                game.player.TryCastSpellOnTarget(attackSkill, 800);
            }
            catch (Exception ex) { Logger.WriteLine(ex, showLog: false); }
        }

        private void Attack(int count = 3)
        {
            try
            {
                if (count < 0) return;
                string skills = "QWERDFA";
                var attackSkill = skills[rand.Next(0, skills.Length)];
                InputHelper.PressKey(System.Windows.Forms.Keys.Space, 150);
                game.player.TryCastSpellOnTarget(attackSkill, 800);
                Attack(--count);
            }
            catch (Exception ex) { Logger.WriteLine(ex, showLog: false); }
        }

        public override void Dispose()
        {
            bot.ExecutePattern("End");
            base.Dispose();
        }
    }
}
