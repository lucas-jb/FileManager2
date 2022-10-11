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
        public List<Hilo> MisHilos = new List<Hilo>();
        public static int Cont = 0;
        public static ServicioModificacion Modificacion = new ServicioModificacion();
        public static ServicioLineas Lineas = new ServicioLineas();
        public enum TipoServicio
        {
            ServicioModificacion,
            ServicioLineas
        }

        public Hilo GenerarHilo(IServicioFichero Tipo)
        {
            Cont++;
            return new Hilo() { Id = Cont, Servicio = Tipo };
        }
        public void CreateModificacion()
        {
            var hilo = GenerarHilo(Modificacion);
            hilo.Comprobar();
            hilo.Espera();
            
        }
        public void CreateLineas()
        {
            var hilo = GenerarHilo(Lineas);
            hilo.Comprobar();
            hilo.Espera();
        }

        public void CambiarRuta(TipoServicio tipoServicio, string ruta)
        {
            if(tipoServicio == TipoServicio.ServicioModificacion) { Modificacion.CambiarRuta(ruta); }
            if(tipoServicio == TipoServicio.ServicioLineas) { Lineas.CambiarRuta(ruta); }
        }
        public void CambiarDelay(TipoServicio tipoServicio, int delay)
        {
            if(tipoServicio == TipoServicio.ServicioModificacion) { Modificacion.CambiarDelay(delay); }
            if(tipoServicio == TipoServicio.ServicioLineas) { Lineas.CambiarDelay(delay); }
        }
        public void Alternar(TipoServicio tipoServicio)
        {
            if (tipoServicio == TipoServicio.ServicioModificacion) { Modificacion.Alternar(); }
            if (tipoServicio == TipoServicio.ServicioLineas) { Lineas.Alternar(); }
        }
    }
}
