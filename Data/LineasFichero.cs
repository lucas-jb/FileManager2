using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class LineasFichero
    {
        public static bool ComprobarModificacion(int lineLimit, string path)
        {
            int cont = LineasActuales(path);
            if(cont <= lineLimit) { return true; }
            return false;
        }

        public static int LineasActuales(string path)
        {
            bool check = true;
            int numLineas = 0;
            if (!File.Exists(path))
            {
                File.Create(path);
            }
            while (check == true)
            {
                try
                {
                    check = false;
                    numLineas = File.ReadLines(path).Count();
                }
                catch
                {
                    check = true;
                }
            }
            return numLineas;
        }
    }
}
