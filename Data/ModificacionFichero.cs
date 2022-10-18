﻿using System;
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
            var a = File.GetLastWriteTime(path);
            if (a == UltimaModificacionGuardada) 
            { 
                return true; 
            }
            return false;
        }

        public static DateTime SincronizarModificacion(string path)
        {
            return File.GetLastWriteTime(path);
        }
    }
}
