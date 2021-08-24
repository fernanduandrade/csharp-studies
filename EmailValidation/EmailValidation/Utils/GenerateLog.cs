using System;
using System.IO;

namespace EmailValidation.Utils
{
    public class GenerateLog
    {
        public void WriteLog(string message)
        {
            string logPath = $"/home/fernando/LOG-{DateTime.Now.ToString("dd-MM-yyyy")}.txt";
            using (StreamWriter write = new StreamWriter(logPath, true))
            {
                write.WriteLine($"{DateTime.Now} : {message}");
            }
        }
    }
}