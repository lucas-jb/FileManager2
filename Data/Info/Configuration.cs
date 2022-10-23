using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Info
{
    public static class Configuration
    {
        private static string ConfigFilePath = "conf.txt";

        public static List<string> CargarConfiguracion()
        {
            bool check = true;
            List<string> lineas = new List<string>();
            if (File.Exists(ConfigFilePath))
            {
                while (check == true)
                {
                    try
                    {
                        check = false;
                        lineas = File.ReadLines(ConfigFilePath).ToList();
                    }
                    catch
                    {
                        check = true;
                    }
                }
            }
            return lineas;
        }

        public static void GuardarConfiguracion(List<string> info)
        {
            bool check = true;
            if (!File.Exists(ConfigFilePath))
            {
                File.Create(ConfigFilePath);
            }
            while (check == true)
            {
                try
                {
                    check = false;
                    File.WriteAllText(ConfigFilePath, String.Empty);
                    File.WriteAllLines(ConfigFilePath, info);
                }
                catch
                {
                    check = true;
                }
            }
        }

    }
}
