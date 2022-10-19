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

        public static async Task ImprimirLog(string log)
        {
            await File.WriteAllTextAsync(LogFilePath, log);
        }
    }
}
