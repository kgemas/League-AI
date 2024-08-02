using LeagueAI.Libraries.Helper;
using System;

namespace LeagueAI.Libraries.Patterns
{
    public class End : BasePatternScript
    {
        public override void Execute()
        {
            try
            {
                bot.Log(DEFINE.EndGameLog2);
                Program.GameHandle = IntPtr.Zero;
                ChangeInfo();
                client.HonorPlayer();
                client.KillProcessRenderUxClient();
                bot.Wait(5000);
                client.WaitClientOpen();
                Dispose();
            }
            catch (Exception ex) { Logger.WriteLine(ex); }
        }

        public override void Dispose()
        {
            bot.ExecutePattern("Begin");
            base.Dispose();
        }

        public void ChangeInfo()
        {
            // Sự kiện sau khi kết thúc game.
            Program.GameCount++;
            Console.Title = Guid.NewGuid().ToString("N") + " (" + Program.GameCount + " games)";
            Logger.LogToFile(string.Format(DEFINE.EndGameLog, Program.GameCount));
            if ((int)Configuration.Instance.SettingGame.maxGame <= Program.GameCount)
            {
                Logger.LogToFile(DEFINE.EndMission);
                if (int.TryParse((Configuration.Instance.SettingGame?.autoShutdown?.ToString() ?? "0"),
                    out int autoShutdown)
                    && autoShutdown == 1)
                {
                    SystemHelper.Shutdown();
                    return;
                }
                Program.Exit(0);
            }
        }
    }
}
