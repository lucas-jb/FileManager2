using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data;

namespace Business
{
    public class ServicioLineas : IServicioFichero
    {
        private bool Arrancado = true;
        public int Delay = 0;
        public string Path = "FicheroDefault";
        public int LimiteLineas = 5;
        public int NumeroLineas = 0;
        private int HiloId;
        public void Alternar()
        {
            if (Arrancado)
            {
                Arrancado = false;
            }
            else
            {
                Start();
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
            Data.Info.Log.ImprimirLog(DateTime.Now.ToString()+"Hilo ID: "+HiloId.ToString()+" Ruta: "+Path+" Limite lineas: "+LimiteLineas.ToString()+" Numero lineas: "+NumeroLineas.ToString());
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
            CambiarRuta(Path);
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
    }
}
