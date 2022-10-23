using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public static class ModificacionFichero
    {
        public static bool ComprobarModificacion(DateTime UltimaModificacionGuardada, string path)
        {
            if (!File.Exists(path))
            {
                File.Create(path);
            }
            var a = File.GetLastWriteTime(path);
            if (a == UltimaModificacionGuardada)
            {
                return true;
            }
            return false;
        }

        public static DateTime SincronizarModificacion(string path)
        {
            if (File.Exists(path))
            {
                return File.GetLastWriteTime(path);
            }
            return DateTime.Now;
        }
    }
}
