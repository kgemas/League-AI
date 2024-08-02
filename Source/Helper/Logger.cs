using LeagueAI.Libraries.Enums;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;

namespace LeagueAI.Libraries.Helper
{
    public sealed class Logger
    {
        private static readonly Dictionary<EMessageState, ConsoleColor> Colors;
        private static readonly Dictionary<string, int> errorCache = new Dictionary<string, int>();

        static Logger()
        {
            Colors = new Dictionary<EMessageState, ConsoleColor>()
            {
                { EMessageState.TIP_HELP,        ConsoleColor.Gray },
                { EMessageState.INFO,            ConsoleColor.DarkCyan },
                { EMessageState.PROCESS,         ConsoleColor.DarkGray },
                { EMessageState.WARNING,         ConsoleColor.DarkYellow },
                { EMessageState.SUCCES,          ConsoleColor.Green },
                { EMessageState.ERROR ,          ConsoleColor.DarkRed},
                { EMessageState.ERROR_FATAL ,    ConsoleColor.Magenta},
            };
        }
        public static void Initialize()
        {
            if (!File.Exists(DEFINE.LogPath))
            {
                File.Create(DEFINE.LogPath);
            }
        }

        public static void LogToFile(object message)
        {
            string value = DateTime.Now + " : " + message.ToString();
            File.AppendAllLines(DEFINE.LogPath, new string[] { value }, Encoding.UTF8);
        }

        public static void OnStartup()
        {
            WriteLine(DEFINE.Logo1, EMessageState.TIP_HELP);
            Console.Title = Guid.NewGuid().ToString("N") + " (" + Program.GameCount + " games)";
        }

        public static void PrintInfo()
        {
            WriteLine(DEFINE.Logo2, EMessageState.TIP_HELP);
        }

        public static void WriteLine(
            Exception e, EMessageState state = EMessageState.ERROR_FATAL, bool showLog = true)
        {
            if (showLog) WriteColored($"{state} - {DateTime.Now} - {e.Message}.\n", Colors[state]);
            if (state >= EMessageState.ERROR)
            {
                LogToFile(e.Message + "\n" + e.StackTrace);
                AddErrorLog(e.Message + "\n" + e.StackTrace, state);
            }
        }

        public static void WriteLine(object value, EMessageState state = EMessageState.INFO, bool showLog = true) => Write($"{value}\n", state, showLog);

        public static void Write(
            object value,
            EMessageState state = EMessageState.INFO,
            bool showLog = true
            )
        {
            if (showLog)
            {
                WriteColored($"{state} - {DateTime.Now} - {value}", Colors[state]);
            }

            if (state >= EMessageState.ERROR)
            {
                LogToFile(value);
            }

            if (state >= EMessageState.ERROR_FATAL)
            {
                System.Reflection.MethodBase frame = new StackFrame(1).GetMethod();
                AddErrorLog($"[{frame.DeclaringType.FullName}.{frame.Name}]: " + value?.ToString(), state);
            }
        }

        private static void WriteColored(object value, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.Write(value);
        }

        private static void AddErrorLog(
            string message,
            EMessageState state = EMessageState.ERROR_FATAL
            )
        {
            try
            {
                if (errorCache.ContainsKey(message)) errorCache[message] += 1;
                else errorCache.Add(message, 1);
            }
            catch (Exception) { }
        }
    }
}
