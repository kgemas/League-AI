using System.Reflection;

namespace LeagueAI.Libraries.Helper
{
    public sealed class StartupManager
    {
        public static void Initialize(Assembly startupAssembly)
        {
            InterceptKeys.Init();
            PatternsUlti.Initialize();
            LeagueSettingsUlti.ApplySettings();
        }
    }
}
