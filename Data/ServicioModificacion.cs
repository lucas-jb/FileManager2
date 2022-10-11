using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class ServicioModificacion : IServicioFichero
    {
        public DateTime UltimaModificacionGuardada = DateTime.Now;
        private bool Arrancado = false;
        public int Delay = 0;
        public string Path = "";

        public void ComprobarModificacion()
        {
            var a = File.GetLastWriteTime(Path);
            if (a == UltimaModificacionGuardada) { Arrancado=true; }
            Arrancado = false;
        }
        public void Start()
        {
            while (Arrancado)
            {
                ComprobarModificacion();
            }
        }
        public void Alternar()
        {
            if(Arrancado) 
            { 
                Arrancado = false; 
            } else
            {
                Arrancado = true;
            }
        }
        public void SincronizarModificacion()
        {
            UltimaModificacionGuardada = File.GetLastWriteTime(Path);
        }

        public void CambiarRuta(string path)
        {
            Path = path;
            SincronizarModificacion();
        }

        public void CambiarDelay(int delay)
        {
            Delay = delay;
        }
    }
}
