﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data;

namespace Business
{
    public class Hilo
    {
        public int Id { get; set; }
        private Thread MiHilo;
        public IServicioFichero Servicio;


        public void Comprobar()
        {
            MiHilo = new Thread(Servicio.Start);
            Servicio.Alternar();
            MiHilo.Start();
        }

        public void Espera()
        {
            MiHilo.Join();
            Console.WriteLine("Hilo número " + Id + " terminado");
        }
    }
}
