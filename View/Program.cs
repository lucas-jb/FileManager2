using Business;

namespace View
{
    internal class Program
    {
        static HiloController controller = new Business.HiloController();

        static void Main(string[] args)
        {
            while (Menu()==true)
            {

            }
            Console.WriteLine("Hasta la proxima!");
        }
        static bool Menu()
        {
            Console.Clear();
            bool res = true;
            Console.WriteLine("SERVICIOS ASÍNCRONOS\n" +
                "1. Crear un hilo.\n" +
                "2. Modificar un hilo.\n" +
                "0. Salir\n");

            int select = Convert.ToInt32(Console.ReadLine());
            Console.Clear();

            if(select == 1) {return CrearHilo(); }
            if(select == 2) {return ModificarHilo(); }
            if(select < 1 || select > 2) { return false; }
            return res;
        }
        static bool CrearHilo()
        {
            Console.Clear();
            Console.WriteLine("1 - Ultima modificación.\n" +
                              "2 - Número de líneas.\n" +
                              "Introduce el tipo del hilo a crear:");
            int id = PedirNum();
            if(id == 1) { controller.CreateModificacion(); }
            if(id == 2) { controller.CreateLineas(); }
            if(id < 1 || id > 2) { return true; }
            return true;
        }
        static bool ModificarHilo()
        {
            if (!PrintListHilos())
            {
                return true;
            }
            else
            {
                Console.WriteLine("0 - Salir\nIntroduce el id del hilo a modificar:");
                int id = PedirNum();
                if(id == 0) { return true; }
                return RedirigirMenu(id);
            }
        }
        static bool RedirigirMenu(int id)
        {
            if (controller.MisHilos.ContainsKey(id)) 
            { 
                Type tipo = controller.MisHilos[id].Servicio.GetType();
                Type modificar = typeof(ServicioModificacion);
                Type lineas = typeof(ServicioLineas);
                if(tipo == modificar) { return MenuModificar(id); }
                if(tipo == lineas) { return MenuLineas(id); }
                return true;
            }
            Console.WriteLine("El id introducido no es válido.");
            return true;
        }
        static bool MenuModificar(int id)
        {
            bool check = true;
            while (check == true)
            {
                Console.Clear();
                DameInfo(id);
                Console.WriteLine("COMPROBAR MODIFICACIÓN DE FICHERO\n" +
                "1. Arrancar / Parar\n" +
                "2. Fichero a comproboar\n" +
                "3. Delay\n" +
                "0. Salir al menú principal\n");

                int select = Convert.ToInt32(Console.ReadLine());
                Console.Clear();

                if (select == 1) { controller.MisHilos[id].Servicio.Alternar(); }
                if (select == 2) { controller.MisHilos[id].Servicio.CambiarRuta(PedirText()); }
                if (select == 3) { controller.MisHilos[id].Servicio.CambiarDelay(PedirNum()); }
                if (select < 1 || select > 3) { check = false; }
            }
            return true;
        }
        static bool MenuLineas(int id)
        {
            bool check = true;
            while (check == true)
            {
                Console.Clear();
                DameInfo(id);
                Console.WriteLine("COMPROBAR LINEAS DE FICHERO\n" +
                "1. Arrancar / Parar\n" +
                "2. Fichero a comproboar\n" +
                "3. Número límite de líneas\n" +
                "4. Delay\n" +
                "0. Salir al menú principal\n");

                int select = Convert.ToInt32(Console.ReadLine());
                Console.Clear();

                if (select == 1) { controller.MisHilos[id].Servicio.Alternar(); }
                if (select == 2) { controller.MisHilos[id].Servicio.CambiarRuta(PedirText()); }
                if (select == 3) { controller.MisHilos[id].Servicio.CambiarLimiteLineas(PedirNum()); }
                if (select == 4) { controller.MisHilos[id].Servicio.CambiarDelay(PedirNum()); }
                if (select < 1 || select > 4) { check = false; }
            }
            return true;
        }

        static string PedirText()
        {
            Console.WriteLine("Introduce la ruta absoluta: ");
            string text = Console.ReadLine();

            return text;
        }
        static int PedirNum()
        {
            int num = Convert.ToInt32(Console.ReadLine());
            return num;
        }

        static bool PrintListHilos()
        {
            if (controller.MisHilos.Count() == 0)
            {
                Console.WriteLine("No hay hilos creados.");
                return false;
            }
            else
            {
                string hilosString = string.Empty;
                string cabecera = "  Tipo        ID    " + Environment.NewLine + "--------------------" + Environment.NewLine;
                foreach (Hilo h in controller.MisHilos.Values)
                {
                    hilosString = hilosString + h.ToString() + Environment.NewLine;
                }
                Console.WriteLine(cabecera + hilosString);
                return true;
            }
        }

        static bool DameInfo(int id)
        {
            if (controller.MisHilos.ContainsKey(id))
            {
                Console.WriteLine("Info del hilo con id:" + id);
                Console.WriteLine(controller.MisHilos[id].Servicio.DameInfo()+Environment.NewLine);
            }
            return true;
        }
    }
}