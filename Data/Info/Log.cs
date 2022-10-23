using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Info
{
    public static class Log
    {
        private static string LogFilePath = "logs.txt";

        public static void ImprimirLog(string log)
        {
            bool check = true;
            if (!File.Exists(LogFilePath))
            {
                File.Create(LogFilePath);
            }
            while (check == true)
            {
                try
                {
                    check = false;
                    File.AppendAllText(LogFilePath, log);
                }
                catch
                {
                    check = true;
                }
            }
        }


    }
}
