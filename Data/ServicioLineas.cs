using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class ServicioLineas : IServicioFichero
    {
        private bool Arrancado = false;
        public int Delay = 0;
        public string Path = "";
        public void Alternar()
        {
            if (Arrancado)
            {
                Arrancado = false;
            }
            else
            {
                Arrancado = true;
            }
        }

        public void CambiarRuta(string path)
        {
            Path = path;
        }

        public void ComprobarModificacion()
        {
            throw new NotImplementedException();
        }

        public void Start()
        {
            ComprobarModificacion();
        }

        public void CambiarDelay(int delay)
        {
            Delay = delay;
        }
    }
}
