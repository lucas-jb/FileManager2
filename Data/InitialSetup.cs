using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public static class InitialSetup
    {
        private static string DefaultFile = "DefaultFile";
        private static string DefaultDirectory = "DefaultDirectory";
        private static string DefaultLogFile = "logs.txt";
        private static string DefaultConfFile = "conf.txt";
        public static void CreateFiles()
        {
            if (!File.Exists(DefaultFile))
            {
                File.Create(DefaultFile);
            }
            if (!File.Exists(DefaultLogFile))
            {
                File.Create(DefaultLogFile);
            }
            if (!File.Exists(DefaultConfFile))
            {
                File.Create(DefaultConfFile);
            }
            if (!Directory.Exists(DefaultDirectory))
            {
                Directory.CreateDirectory(DefaultDirectory);
            }
        }
    }
}
