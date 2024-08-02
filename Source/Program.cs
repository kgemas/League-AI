using LeagueAI.Libraries.Enums;
using LeagueAI.Libraries.Game;
using LeagueAI.Libraries.Helper;
using System;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Threading;

namespace LeagueAI.Libraries
{
    public sealed class Program
    {
        public static int GameCount { get; set; } = 0;
        public static IntPtr ClientHandle { get; private set; } = IntPtr.Zero;
        public static IntPtr GameHandle { get; set; } = IntPtr.Zero;

        static Program()
        {
            Console.OutputEncoding = Encoding.UTF8;
            Logger.Initialize();
            ServicePointManager.Expect100Continue = true;
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12 | SecurityProtocolType.Ssl3;
            ServicePointManager.ServerCertificateValidationCallback += (sender, cert, chain, sslPolicyErrors) => true;
        }

        public static int Main(string[] args)
        {
            Logger.OnStartup();

            // Tải tệp tin cấu hình
            Configuration.Initialize();

            Logger.PrintInfo();
            int watch = Environment.TickCount;
            Logger.WriteLine(DEFINE.InitSettingLog, EMessageState.PROCESS);

            // Tự cài đặt đường dẫn cấu hình bằng cách đọc tiến trình
            AutoSetting();
            Logger.WriteLine($"** {DEFINE.FinishSettingLog} (" + (Environment.TickCount - watch) + "ms) **", EMessageState.SUCCES);

            try
            {
                // Nạp nội dung config, pattern
                StartupManager.Initialize(Assembly.GetExecutingAssembly());
                UserInterfaces();
                Program.Exit(0);
            }
            catch (Exception e)
            {
                Logger.WriteLine(e);
            }
            Program.Exit(1);
            return 1;
        }

        public static void AutoSetting()
        {
            try
            {
                if (bool.TryParse(Configuration.Instance.SettingGame?.autoConfig?.ToString(), out bool autoConfig)
                    && !autoConfig) return;

                // Đọc tiến trình, nếu không có tiến trình client thì thoát
                var openProcess = HandleExtention.GetOpenWindows();
                ClientHandle = openProcess.FirstOrDefault(m => m.Value.Contains(DEFINE.ClientExecutableName)).Key;
                if (ClientHandle == null || ClientHandle == IntPtr.Zero)
                {
                    Logger.WriteLine(DEFINE.NotOpenGameClientYetLog, EMessageState.WARNING);
                    Program.Exit(1);
                }

                // nếu không phải là tiến trình 64bit thì bỏ qua.
                if (IntPtr.Size != 8) return;

                Logger.WriteLine($"DefaultLeaguePath: [{Configuration.Instance.DefaultLeaguePath}]");
                Logger.WriteLine($"ClientExecutablePath: [{Configuration.Instance.ClientExecutablePath}]");
                Logger.WriteLine($"LockfilePath: [{Configuration.Instance.LockfilePath}]");
                Logger.WriteLine($"LeagueGameconfigPath: [{Configuration.Instance.LeagueGameconfigPath}]");
                Logger.WriteLine($"LeaguePersistedSettingsPath: [{Configuration.Instance.LeaguePersistedSettingsPath}]");
            }
            catch (Exception e)
            {
                Logger.WriteLine(e);
            }
        }

        private static void UserInterfaces(int timeout = 90)
        {
            if (bool.TryParse(Configuration.Instance.SettingGame?.autoDetectStateGame?.ToString() ?? "true", out bool autoDetectStateGame)
                && autoDetectStateGame)
            {
                ClientLCU.Initialize();

                if (GameLCU.IsApiReady()) // nếu api trong game khả dụng -> chạy pattern trong game
                {
                    string pattern = PatternsUlti.ScriptsPattern?.FirstOrDefault(m => m.ToLower().Contains("ingame"));
                    PatternsUlti.Execute(pattern);
                    UserInterfaces();
                    return;
                }

                if (ClientLCU.IsApiReady()) // nếu api trong game không khả dụng và api client khả dụng -> tạo trận chơi ngay
                {
                    string pattern = PatternsUlti.ScriptsPattern?.FirstOrDefault(m => m.ToLower().Contains("begin"));
                    PatternsUlti.Execute(pattern);
                    UserInterfaces();
                    return;
                }

                Logger.WriteLine(string.Format(DEFINE.WaitGameLog, timeout));
                Thread.Sleep(TimeSpan.FromSeconds(30));
                timeout -= 30;
                if (timeout <= 0)
                {
                    Logger.WriteLine(DEFINE.NotOpenGameClientYetLog);
                    Program.Exit(1);
                }

                UserInterfaces(timeout);
                return;
            }
            Program.Exit(1);
        }

        public static void Exit(int code, bool forceExit = false)
        {
            if (code != 0 && !forceExit)
            {
                Console.ReadKey();
            }
            Environment.Exit(code);
        }
    }
}
