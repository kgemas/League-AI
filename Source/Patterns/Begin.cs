using LeagueAI.Libraries.Entities;
using LeagueAI.Libraries.Enums;
using LeagueAI.Libraries.Helper;
using LeagueAI.Libraries.Patterns;
using System;

namespace LeagueAI.Libraries
{
    public class Begin : BasePatternScript
    {
        private EQueueRoom gameMode { get; set; } = EQueueRoom.CoopVsAIIntroBot;
        private Summoner currentPlayer { get; set; }

        public override void Execute()
        {
            try
            {
                bot.Log(DEFINE.BeginGameLog);
                Program.GameHandle = IntPtr.Zero;
                client.WaitClientOpen();
                client.Initialize();
                currentPlayer = client.LoadSummoner();
                if (string.IsNullOrWhiteSpace(currentPlayer?.displayName))
                {
                    bot.Warn(DEFINE.BeginCantLoadUserInfoLog);
                }

                LimitLevel();

                if (Enum.TryParse(DEFINE.DefaultRoom, out EQueueRoom selectedRoom))
                    gameMode = selectedRoom;
                else gameMode = EQueueRoom.CoopVsAIIntroBot;

                EGameflowPhase statusGame = client.GetGameflowPhase();
                switch (statusGame)
                {
                    case EGameflowPhase.FailedToLaunch:
                    case EGameflowPhase.TerminatedInError:
                        bot.Log(DEFINE.BeginLogError1);
                        return;
                    case EGameflowPhase.InProgress:
                        Dispose();
                        return;
                    case EGameflowPhase.Reconnect:
                        client.Reconnect();
                        bot.Wait(10000);
                        Dispose();
                        break;
                    case EGameflowPhase.PreEndOfGame:
                        bot.Log("Pre-end of game state.");
                        client.Initialize();
                        try
                        {
                            client.CreateLobby(gameMode);
                        }
                        catch { }
                        Execute();
                        return;
                    case EGameflowPhase.EndOfGame:
                        bot.Log("End of game state.");
                        client.Initialize();
                        try
                        {
                            client.CreateLobby(gameMode);
                        }
                        catch { }
                        Execute();
                        return;
                    default:
                        client.CreateLobby(gameMode);
                        ProcessMatch();
                        break;
                }
            }
            catch (Exception ex) { Logger.WriteLine(ex); }
        }

        private void LimitLevel()
        {
            try
            {
                var maxLevel = (int)Configuration.Instance.SettingGame?.maxLevell;
                if (maxLevel <= currentPlayer?.summonerLevel)
                {
                    bot.Warn(DEFINE.BeginMaximumLevelLog);
                    bot.Wait(5000);
                    Program.Exit(0);
                }
            }
            catch (Exception) { }
        }

        private void ProcessMatch()
        {
            bot.Log(DEFINE.BeginLog1);
            bot.Wait(3000);

            ESearchMatchResult result = client.SearchMatch();
            while (result != ESearchMatchResult.Ok)
            {
                switch (result)
                {
                    case ESearchMatchResult.GatekeeperRestricted:
                        bot.Warn(DEFINE.BeginLog2);
                        bot.Wait(30000);
                        break;
                    case ESearchMatchResult.QueueNotEnabled:
                        client.CreateLobby(gameMode);
                        bot.Warn(DEFINE.BeginLogError2);
                        bot.Wait(10000);
                        break;
                    case ESearchMatchResult.InvalidLobby:
                        bot.Warn(DEFINE.BeginLogError3);
                        bot.Wait(10000);
                        break;
                    default:
                        bot.Warn(DEFINE.BeginLogError4);
                        bot.Wait(10000);
                        break;
                }

                result = client.SearchMatch();
            }

            while (!client.IsMatchFound())
            {
                bot.Wait(2000);
            }

            bot.Log(DEFINE.BeginLog3);
            while (client.GetGameflowPhase() != EGameflowPhase.ChampSelect)
            {
                client.AcceptMatch();
                bot.Wait(1000);
            }

            PickChampion();
            client.PickSkin(currentPlayer);

            bot.Log(DEFINE.BeginLog5);

            client.BringToFont();
            client.CenterScreen();

            // game.chat.TalkInClient(DEFINE.InGameTalkFirst);
            EGameflowPhase currentPhase = client.GetGameflowPhase();

            while (currentPhase != EGameflowPhase.InProgress)
            {
                if (currentPhase != EGameflowPhase.ChampSelect)
                {
                    bot.Log(DEFINE.BeginLog6);
                    ProcessMatch();
                    return;
                }
                bot.Wait(1000);
                currentPhase = client.GetGameflowPhase();
            }
            Dispose();
        }

        private void PickChampion()
        {
            if (Enum.TryParse(DEFINE.DefaultChampion, out EChampion champion))
            {
                var result1 = client.PickChampion(champion);
                switch (result1)
                {
                    case EChampionPickResult.Ok:
                        bot.Log(string.Format(DEFINE.BeginLog4, champion));
                        return;
                    case EChampionPickResult.ChampionNotOwned:
                        bot.Warn(DEFINE.BeginLogError6);
                        break;
                    case EChampionPickResult.ChampionPicked:
                        bot.Warn(DEFINE.BeginLogError7);
                        break;
                    default:
                        break;
                }
            }

            bool picked = false;
            int championIndex = 0;
            while (!picked)
            {
                if (championIndex > DEFINE.Champions.Length - 1)
                {
                    bot.Warn(DEFINE.BeginLogError5);
                    return;
                }
                EChampionPickResult pickResult = client.PickChampion(DEFINE.Champions[championIndex]);

                switch (pickResult)
                {
                    case EChampionPickResult.Ok:
                        bot.Log(string.Format(DEFINE.BeginLog4, DEFINE.Champions[championIndex]));
                        picked = true;
                        break;
                    case EChampionPickResult.ChampionNotOwned:
                        bot.Warn(DEFINE.BeginLogError6);
                        break;
                    case EChampionPickResult.ChampionPicked:
                        bot.Warn(DEFINE.BeginLogError7);
                        break;
                    default:
                        break;
                }

                championIndex++;
                bot.Wait(1000);
            }
        }

        public override void Dispose()
        {
            bot.ExecutePattern("InGame");
            base.Dispose();
        }
    }
}
