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

        //public static Hilo GenerarHilo(string service, string hilo)
        //{
            
        //}

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
                    string service = hilo.Split("\"Servicio\": ")[1];
                    service = service.Substring(0, service.Length - 1);

                    string quitar = ",\"Servicio\": " + service;
                    string auxhilo = hilo.Replace(quitar, "");

                    Hilo hiloaux = JsonSerializer.Deserialize<Hilo>(auxhilo);

                    if (service.Contains("Lineas"))
                    {
                        hiloaux.Servicio = JsonSerializer.Deserialize<ServicioLineas>(service);
                    }
                    if (service.Contains("Modificacion"))
                    {
                        hiloaux.Servicio = JsonSerializer.Deserialize<ServicioModificacion>(service);
                    }
                    MisHilos.Add(hiloaux.Id, hiloaux);
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
                    string hiloJson = JsonSerializer.Serialize<Hilo>(hilo);
                    string serviceJson = hilo.Servicio.DameJson();
                    hiloJson = hiloJson.Split("\"Servicio\":{")[0] + "\"Servicio\": "+ serviceJson + "}";
                    hilosString.Add(hiloJson);
                }
                Data.Info.Configuration.GuardarConfiguracion(hilosString);
            }
        }
    }
}
