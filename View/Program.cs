using Business;

namespace View
{
    internal class Program
    {
        static void Main(string[] args)
        {
            InitialSetup.CreateDependencies();
            HiloController.DelegateState delegateState = new HiloController.DelegateState(DelegateFunction);
            HiloController.delegado = delegateState;
            while (Menu()==true)
            {

            }
            Console.WriteLine("Hasta la proxima!");
        }
        static void DelegateFunction(string log)
        {
            Console.WriteLine(log);
        }
        static bool Menu()
        {
            Console.Clear();
            Console.WriteLine("SERVICIOS ASÍNCRONOS" + Environment.NewLine +
                "1. Crear un hilo." + Environment.NewLine +
                "2. Modificar un hilo." + Environment.NewLine +
                "3. Cargar configuración." + Environment.NewLine +
                "4. Guardar configuración." + Environment.NewLine +
                "0. Salir" + Environment.NewLine);
            int select;
            try
            {
                select = Convert.ToInt32(Console.ReadLine());
            }
            catch
            {
                return true;
            }
            Console.Clear();

            if(select == 1) {return CrearHilo(); }
            if(select == 2) {return ModificarHilo(); }
            if(select == 3) {HiloController.CargarConfig(); }
            if(select == 4) {HiloController.GuardarConfig(); }
            if(select < 1 || select > 4) { return false; }
            return true;
        }
        static bool CrearHilo()
        {
            Console.Clear();
            Console.WriteLine("1 - Ultima modificación." + Environment.NewLine +
                              "2 - Número de líneas." + Environment.NewLine +
                              "Introduce el tipo del hilo a crear:");
            int id = PedirNum();
            if(id == 1) { HiloController.CreateModificacion(PedirText(true)); }
            if(id == 2) { HiloController.CreateLineas(PedirText(false)); }
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
            if (HiloController.MisHilos.ContainsKey(id)) 
            { 
                Type tipo = HiloController.MisHilos[id].Servicio.GetType();
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
                Console.WriteLine("COMPROBAR MODIFICACIÓN DE FICHERO" + Environment.NewLine +
                "1. Arrancar / Parar" + Environment.NewLine +
                "2. Fichero a comproboar" + Environment.NewLine +
                "3. Delay" + Environment.NewLine +
                "4. Actualizar información" + Environment.NewLine +
                "0. Salir al menú principal" + Environment.NewLine);

                int select;
                try
                {
                    select = Convert.ToInt32(Console.ReadLine());
                }
                catch
                {
                    return true;
                }
                Console.Clear();

                if (select == 1) { HiloController.MisHilos[id].Servicio.Alternar(); }
                if (select == 2) { HiloController.MisHilos[id].Servicio.CambiarRuta(PedirText(true)); }
                if (select == 3) { HiloController.MisHilos[id].Servicio.CambiarDelay(PedirNum()); }
                if (select == 4) { }
                if (select < 1 || select > 4) { check = false; }
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
                Console.WriteLine("COMPROBAR LINEAS DE FICHERO" + Environment.NewLine +
                "1. Arrancar / Parar" + Environment.NewLine +
                "2. Fichero a comproboar" + Environment.NewLine +
                "3. Número límite de líneas" + Environment.NewLine +
                "4. Delay" + Environment.NewLine +
                "5. Actualizar información" + Environment.NewLine +
                "0. Salir al menú principal" + Environment.NewLine);

                int select;
                try
                {
                    select = Convert.ToInt32(Console.ReadLine());
                }
                catch
                {
                    return true;
                }
                Console.Clear();

                if (select == 1) { HiloController.MisHilos[id].Servicio.Alternar(); }
                if (select == 2) { HiloController.MisHilos[id].Servicio.CambiarRuta(PedirText(false)); }
                if (select == 3) { HiloController.MisHilos[id].Servicio.CambiarLimiteLineas(PedirNum()); }
                if (select == 4) { HiloController.MisHilos[id].Servicio.CambiarDelay(PedirNum()); }
                if (select == 5) { }
                if (select < 1 || select > 5) { check = false; }
            }
            return true;
        }

        static string PedirText(bool tipo)
        {
            Console.WriteLine("(Dejar en blanco para ruta por defecto)" + Environment.NewLine + "Introduce la ruta absoluta:");
            string text = Console.ReadLine();
            if(text == string.Empty) 
            {
                if (!tipo) { text = "DefaultFile"; } 
                if (tipo) { text = "DefaultDirectory"; } 
            }
            return text;
        }
        static int PedirNum()
        {
            int num;
            try
            {
                num = Convert.ToInt32(Console.ReadLine());
            }
            catch
            {
                Console.WriteLine("Introduce un valor numérico.");
                return PedirNum();
            }
            return num;
        }

        static bool PrintListHilos()
        {
            if (HiloController.MisHilos.Count() == 0)
            {
                Console.WriteLine("No hay hilos creados.");
                return false;
            }
            else
            {
                string hilosString = string.Empty;
                string cabecera = "  Tipo        ID    " + Environment.NewLine + "--------------------" + Environment.NewLine;
                foreach (Hilo h in HiloController.MisHilos.Values)
                {
                    hilosString = hilosString + h.ToString() + Environment.NewLine;
                }
                Console.WriteLine(cabecera + hilosString);
                return true;
            }
        }

        static bool DameInfo(int id)
        {
            if (HiloController.MisHilos.ContainsKey(id))
            {
                Console.WriteLine("Info del hilo con id:" + id);
                Console.WriteLine(HiloController.MisHilos[id].Servicio.DameInfo()+Environment.NewLine);
            }
            return true;
        }
    }
}