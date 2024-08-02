using LeagueAI.Libraries.Enums;
using LeagueAI.Libraries.Helper;
using LeagueAI.Libraries.Interfaces;
using System.Threading;

namespace LeagueAI.Libraries.Api
{
    public sealed class BotApi : IApi
    {
        public static int IDLE_DELAY { get; set; } = 150;

        public void Log(object message)
        {
            Logger.WriteLine(message);
        }
        public void Warn(object message)
        {
            Logger.WriteLine(message, EMessageState.WARNING);
        }
        public void Error(object message)
        {
            Logger.WriteLine(message, EMessageState.ERROR);
        }
        public void Wait(int ms)
        {
            Thread.Sleep(ms);
        }
        public void ExecutePattern(string name)
        {
            PatternsUlti.Execute(name);
        }
    }
}
