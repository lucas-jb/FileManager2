using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class Hilo
    {
        public int Id { get; set; }
        private Thread MiHilo;
        public IServicioFichero Servicio;
        public string Path = string.Empty;


        public void Comprobar()
        {
            Servicio.SetHiloId(Id);
            Servicio.CambiarRuta(Path);
            MiHilo = new Thread(Servicio.Start);
            //Servicio.Alternar();
            MiHilo.Start();
        }

        public void Espera(int delay)
        {
            Thread.Sleep(delay);
        }

        
        public override string ToString()
        {
            return Servicio.DameTipo() + "  " + Id;
        }
    }
}
