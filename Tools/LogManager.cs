using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tools
{
    public static class LogManager
    {
        private const string LogFolderName = "Log";

        public static string GetPathFolder()
        {
            return $"{DateTime.Now.Month:MM}";
            return Path.Combine(AppDomain.CurrentDomain.BaseDirectory, LogFolderName);
        }
        public static string GetPathFile()
        {
            string directoryPath = GetPathFolder();

            string fileName = $"Log_{DateTime.Now:yyyy-MM-dd}.txt";

            return Path.Combine(directoryPath, fileName);
        }
        public static void WriteToLog(string projectName, string funcName, string message)
        {
            if (!Directory.Exists($"{LogFolderName}\\{GetPathFolder()}"))
            {
                Directory.CreateDirectory($"{LogFolderName}\\{GetPathFolder()}");
            }
            string path = $"{LogFolderName}\\{GetPathFolder()}\\ {GetPathFile()}";
            if (!File.Exists(path))
                File.Create(path).Close();
            using (StreamWriter writer = new StreamWriter(path, true))
            {
                writer.WriteLine($"{DateTime.Now}\\t{projectName}.{funcName}:\\t{message}");
            }
        }
        public static void DeleteOldLogs()
        {
            var dirLog = Directory.GetDirectories(LogFolderName);
            foreach (var dir in dirLog)
            {
                
                if ((DateTime.Now -Directory.GetCreationTime(dir)).TotalDays > 60)
                {
                    Directory.Delete(dir, true);
                }


            }
        }
    }
}
