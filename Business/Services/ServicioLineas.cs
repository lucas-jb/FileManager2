using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Data;

namespace Business
{
    public class ServicioLineas : IServicioFichero
    {
        public bool Arrancado { get; set; } = true;
        public int Delay { get; set; } = 0;
        public string Path { get; set; }
        public int LimiteLineas { get; set; } = 5;
        public int NumeroLineas { get; set; } = 0;
        public int HiloId { get; set; }
        public string Tipo { get; set; } = "Lineas";

        public void Alternar()
        {
            if (Arrancado)
            {
                Arrancado = false;
            }
            else
            {
                HiloController.MisHilos[HiloId].Comprobar();
            }
        }
        public void CambiarRuta(string path)
        {
            Path = path;
            NumeroLineas = LineasFichero.LineasActuales(path);
        }

        public void ComprobarModificacion()
        {
            if (Arrancado == true)
            {
                Arrancado = LineasFichero.ComprobarModificacion(LimiteLineas, Path);
            }
        }

        public void Start()
        {
            Arrancado = true;
            CambiarRuta(Path);
            while (Arrancado)
            {
                Thread.Sleep(Delay);
                ComprobarModificacion();
                CambiarRuta(Path);
            }
            string log = DateTime.Now.ToString() + " - Hilo ID: " + HiloId.ToString() + " Ruta: " + Path + " Limite lineas: " + LimiteLineas.ToString() + " Numero lineas: " + NumeroLineas.ToString() + Environment.NewLine;
            Data.Info.Log.ImprimirLog(log);
            CambiarRuta(Path);
            EliminarLineasSobrantes();
            HiloController.delegado(log);
        }

        private void EliminarLineasSobrantes()
        {
            int lineasSobrantes = NumeroLineas - LimiteLineas;
            Data.LineasFichero.EliminarLineasSobrantes(lineasSobrantes, Path);
        }

        public void CambiarDelay(int delay)
        {
            Delay = delay;
        }

        public void CambiarLimiteLineas(int limit)
        {
            LimiteLineas = limit;
        }
        public string DameTipo()
        {
            return "Lineas      ";
        }

        public string DameInfo()
        {
            return "Ruta: "+Path+Environment.NewLine+"Delay: "+Delay.ToString() +"ms"+Environment.NewLine+"Limite de líneas: "+LimiteLineas.ToString()+Environment.NewLine+ "Líneas fichero: " + NumeroLineas.ToString() + Environment.NewLine + "Arrancado: " +Arrancado.ToString();
        }
        public void SetHiloId(int id)
        {
            HiloId = id;
        }

        public string DameJson()
        {
            return JsonSerializer.Serialize<ServicioLineas>(
                new ServicioLineas()
                                    {
                                    Arrancado=Arrancado,
                                    LimiteLineas=LimiteLineas,
                                    Delay=Delay,
                                    NumeroLineas=NumeroLineas,
                                    Path=Path,
                                    HiloId=HiloId,
                                    Tipo = Tipo
                                    });
        }
    }
}