using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Data;

namespace Business
{
    public static class HiloController
    {
        public static Dictionary<int, Hilo> MisHilos = new Dictionary<int, Hilo>();
        public static int Cont = 0;

        public static Hilo GenerarHilo(IServicioFichero Tipo, string path)
        {
            Cont++;
            return new Hilo() { Id = Cont, Servicio = Tipo, Path = path };
        }
        public static void CreateModificacion(string path)
        {
            var hilo = GenerarHilo(new ServicioModificacion() { Path=path}, path);
            MisHilos.Add(hilo.Id, hilo);
            hilo.Comprobar();
        }
        public static void CreateLineas(string path)
        {
            var hilo = GenerarHilo(new ServicioLineas() { Path = path }, path);
            MisHilos.Add(hilo.Id, hilo);
            hilo.Comprobar();
        }

        public static void CargarConfig()
        {
            List<string> config = Data.Info.Configuration.CargarConfiguracion();
            if((config.Count > 0) && (MisHilos.Count == 0))
            {
                foreach (string hilo in config)
                {
                    Hilo hiloaux = JsonSerializer.Deserialize<Hilo>(hilo);
                }
            }
        }

        public static void GuardarConfig()
        {
            if(MisHilos.Count > 0)
            {
                List<string> hilosString = new List<string>();
                foreach (Hilo hilo in MisHilos.Values)
                {
                    string aux = JsonSerializer.Serialize<Hilo>(hilo);
                    aux = aux.Split("\"Servicio\":{")[0] + "\"Servicio\":{"+ JsonSerializer.Serialize<IServicioFichero>(hilo.Servicio)+"}}";
                    hilosString.Add(aux);
                }
                Data.Info.Configuration.GuardarConfiguracion(hilosString);
            }
        }
    }
}
