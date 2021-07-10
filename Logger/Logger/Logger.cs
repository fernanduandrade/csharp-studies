using System;
using System.IO;

namespace Logger
{
    public static class Logger
    {
        public static void WriteLog(string message)
        {
            string logPath = "C:/Temp/log.txt";
            using (StreamWriter write = new StreamWriter(logPath, true))
            {
                write.WriteLine($"{DateTime.Now} : {message}");
            }
        }
    }
}
