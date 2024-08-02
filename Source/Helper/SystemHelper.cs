using System.Collections.Generic;
using System.IO;
using System.Management;
using System.Net;
using System.Text;

namespace LeagueAI.Libraries.Helper
{
    public sealed class SystemHelper
    {
        private static readonly WebClient client;

        static SystemHelper()
        {
            client = new WebClient();
            client.Headers.Add("Accept", "application/json");
        }

        public static void Shutdown()
        {
            // https://stackoverflow.com/a/102583/12354701

            ManagementBaseObject mboShutdown = null;
            ManagementClass mcWin32 = new ManagementClass("Win32_OperatingSystem");
            mcWin32.Get();

            // You can't shutdown without security privileges
            mcWin32.Scope.Options.EnablePrivileges = true;
            ManagementBaseObject mboShutdownParams =
                     mcWin32.GetMethodParameters("Win32Shutdown");

            // Flag 1 means we want to shut down the system. Use "2" to reboot.
            mboShutdownParams["Flags"] = "1";
            mboShutdownParams["Reserved"] = "0";
            foreach (ManagementObject manObj in mcWin32.GetInstances())
            {
                mboShutdown = manObj.InvokeMethod("Win32Shutdown",
                                               mboShutdownParams, null);
            }
        }

        public static List<string> SearchFiles(string startingDirectory, string fileName)
        {
            var files = new List<string>();
            if (!Directory.Exists(startingDirectory)) return files;

            var subDirectories = Directory.GetDirectories(startingDirectory);
            foreach (var subDirectory in subDirectories)
            {
                var searchResult = SearchFiles(subDirectory, fileName);
                if (searchResult == null || searchResult.Count <= 0) continue;

                files.AddRange(searchResult);
            }

            string[] matchingFiles = Directory.GetFiles(startingDirectory, fileName);

            if (matchingFiles?.Length > 0)
                files.AddRange(matchingFiles);

            return files;
        }

        public static string SafeReadFile(string path)
        {
            using (var fileStream = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
            {
                using (var streamReader = new StreamReader(fileStream, Encoding.Default))
                {
                    var result = streamReader.ReadToEnd();

                    streamReader.Close();
                    streamReader.Dispose();

                    fileStream.Close();
                    fileStream.Dispose();
                    return result;
                }
            }
        }
    }
}
