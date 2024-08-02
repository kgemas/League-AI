using LeagueAI.Libraries.Entities;
using LeagueAI.Libraries.Enums;
using LeagueAI.Libraries.Game;
using LeagueAI.Libraries.Helper;
using LeagueAI.Libraries.Interfaces;
using System.Threading;

namespace LeagueAI.Libraries.Api
{
    public sealed class ClientApi : IApi
    {
        public void WaitClientOpen(
            int timeout = 60
            )
        {
            while (!IsClientOpen())
            {
                if (timeout <= 0)
                {
                    Logger.WriteLine(DEFINE.NotOpenGameClientYetLog, EMessageState.ERROR);
                    Program.Exit(1);
                }
                timeout -= 5;
                Thread.Sleep(5000);
            }
        }

        public bool IsClientOpen() => ClientLCU.IsClientOpen();

        public void Initialize() => ClientLCU.Initialize();
        public void BringToFont() => ClientLCU.BringToFont();
        public void CenterScreen() => ClientLCU.CenterScreen();
        public void CloseClient() => ClientLCU.CloseClient();
        public void KillProcessRenderUxClient() => ClientLCU.KillProcessRenderUxClient();

        public void OpenClient() => ClientLCU.OpenClient();

        public Summoner LoadSummoner() => ClientLCU.GetCurrentSummoner();

        public void CreateLobby(EQueueRoom queueId) => ClientLCU.CreateLobby(queueId);

        public ESearchMatchResult SearchMatch() => ClientLCU.SearchMatch();

        public void Reconnect() => ClientLCU.Reconnect();

        public void AcceptMatch() => ClientLCU.AcceptMatch();

        public bool IsMatchFound() => ClientLCU.IsMatchFound();

        public EGameflowPhase GetGameflowPhase() => ClientLCU.GetGameflowPhase();

        public EChampionPickResult PickChampion(EChampion champion) => ClientLCU.PickChampion(champion);
        public bool PickSkin(Summoner player) => ClientLCU.PickSkin(player);
        public string HonorPlayer() => ClientLCU.PostHonorAfterGameDone();
    }
}
