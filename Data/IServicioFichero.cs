using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public interface IServicioFichero
    {
        public void ComprobarModificacion();
        public void Start();
        public void Alternar();
        public void CambiarRuta(string path);
        public void CambiarDelay(int delay);
    }
}
