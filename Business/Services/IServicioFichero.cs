using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public interface IServicioFichero
    {
        public void SetHiloId(int id);
        public string DameTipo();
        public void ComprobarModificacion();
        public void Start();
        public void Alternar();
        public void CambiarRuta(string path);
        public void CambiarDelay(int delay);
        public void CambiarLimiteLineas(int limit);
        public string DameInfo();
    }
}
