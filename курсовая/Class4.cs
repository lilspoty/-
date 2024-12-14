using System;
using System.IO;

namespace Test
{
    public static class Logger
    {
        private static string logFile = "game_log.txt";

        public static void Log(string message)
        {
            try
            {
                File.AppendAllText(logFile, $"{DateTime.Now}: {message}{Environment.NewLine}");
            }
            catch
            {
                // Если ошибка записи в лог, просто игнорируем
            }
        }
    }
}




