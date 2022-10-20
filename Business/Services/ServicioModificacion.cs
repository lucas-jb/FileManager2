﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data;

namespace Business
{
    public class ServicioModificacion : IServicioFichero
    {
        public DateTime UltimaModificacionGuardada { get; set; } = DateTime.Now;
        private bool Arrancado { get; set; } = true;
        public int Delay { get; set; } = 0;
        public string Path { get; set; }  = "directorioDefault";
        private int HiloId { get; set; }

        public void ComprobarModificacion()
        {
            Arrancado = ModificacionDirectorio.ComprobarModificacion(UltimaModificacionGuardada, Path);
        }
        public void Start()
        {
            Arrancado = true;
            CambiarRuta(Path);
            while (Arrancado)
            {
                Thread.Sleep(Delay);
                ComprobarModificacion();
            }
            Data.Info.Log.ImprimirLog(DateTime.Now.ToString() + " - Hilo ID: " + HiloId.ToString() + " Ruta: " + Path + " Ultima modificación¨: "+UltimaModificacionGuardada.ToString());
            CambiarRuta(Path);
        }
        public void Alternar()
        {
            if(Arrancado) 
            { 
                Arrancado = false; 
            } else
            {
                Start();
            }
        }
        public void CambiarRuta(string path)
        {
            Path = path;
            UltimaModificacionGuardada = ModificacionFichero.SincronizarModificacion(path);
        }

        public void CambiarDelay(int delay)
        {
            Delay = delay;
        }

        public string DameTipo()
        {
            return "Modificación";
        }
        public string DameInfo()
        {
            return "Ultima modificación: "+UltimaModificacionGuardada.ToString()+ Environment.NewLine + "Ruta: " + Path + Environment.NewLine + "Delay: " + Delay.ToString() +"ms"+ Environment.NewLine + "Arrancado: " + Arrancado.ToString();
        }

        public void CambiarLimiteLineas(int limit)
        {
            
        }

        public void SetHiloId(int id)
        {
            HiloId = id;
        }
    }
}
