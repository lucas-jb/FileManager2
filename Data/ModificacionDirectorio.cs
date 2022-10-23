using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class ModificacionDirectorio
    {
        public static bool ComprobarModificacion(DateTime UltimaModificacionGuardada, string path)
        {
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            var a = Directory.GetLastWriteTime(path);
            if (a == UltimaModificacionGuardada)
            {
                return true;
            }
            return false;
        }

        public static DateTime SincronizarModificacion(string path)
        {
            if (Directory.Exists(path))
            {
                return Directory.GetLastWriteTime(path);
            }
            return DateTime.Now;
        }
    }
}