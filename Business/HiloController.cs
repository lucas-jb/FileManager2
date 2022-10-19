using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data;

namespace Business
{
    public class HiloController
    {
        public Dictionary<int, Hilo> MisHilos = new Dictionary<int, Hilo>();
        public static int Cont = 0;

        public Hilo GenerarHilo(IServicioFichero Tipo, string path)
        {
            Cont++;
            return new Hilo() { Id = Cont, Servicio = Tipo, Path = path };
        }
        public void CreateModificacion(string path)
        {
            var hilo = GenerarHilo(new ServicioModificacion(), path);
            MisHilos.Add(hilo.Id, hilo);
            hilo.Comprobar();
        }
        public void CreateLineas(string path)
        {
            var hilo = GenerarHilo(new ServicioLineas(), path);
            MisHilos.Add(hilo.Id, hilo);
            hilo.Comprobar();
        }

        public void CargarConfig(List<string> listaconfig)
        {
            Data.Configuration.
            foreach (string hilo in listaconfig)
            {
                ConstruirHilo(hilo);
            }
        }

        public void ConstruirHilo(string hilo)
        {

        }

        public List<string> GuardarConfig()
        {
            var x = new List<string>();
            return x;
        }
    }
}
