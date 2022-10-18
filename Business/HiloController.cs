using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class HiloController
    {
        public Dictionary<int, Hilo> MisHilos = new Dictionary<int, Hilo>();
        public static int Cont = 0;

        public Hilo GenerarHilo(IServicioFichero Tipo)
        {
            Cont++;
            return new Hilo() { Id = Cont, Servicio = Tipo };
        }
        public void CreateModificacion()
        {
            var hilo = GenerarHilo(new ServicioModificacion());
            MisHilos.Add(hilo.Id, hilo);
            hilo.Comprobar();
        }
        public void CreateLineas()
        {
            var hilo = GenerarHilo(new ServicioLineas());
            MisHilos.Add(hilo.Id, hilo);
            hilo.Comprobar();
        }
    }
}
