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
        public string Path { get; set; }
        private Thread MiHilo;
        public IServicioFichero Servicio { get; set; }


        public void Comprobar()
        {
            Servicio.SetHiloId(Id);
            MiHilo = new Thread(Servicio.Start);
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
