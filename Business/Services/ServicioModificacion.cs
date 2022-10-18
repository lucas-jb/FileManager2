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
        public DateTime UltimaModificacionGuardada = DateTime.Now;
        private bool Arrancado = true;
        public int Delay = 0;
        public string Path = "C:\\Users\\Lucas\\Desktop\\pruebillas\\directorioBBDD";
        private int HiloId;

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
                //HiloController.MisHilos[id].Espera(Delay);
                ComprobarModificacion();
            }
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
            return "Ultima modificación: "+UltimaModificacionGuardada.ToString()+ Environment.NewLine + "Ruta: " + Path + Environment.NewLine + "Delay: " + Delay.ToString() + Environment.NewLine + "Arrancado: " + Arrancado.ToString();
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