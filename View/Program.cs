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
                Menu();
            }
            Console.WriteLine("Hasta la proxima!");
        }
        static bool Menu()
        {
            bool res = true;
            Console.WriteLine("SERVICIOS ASÍNCRONOS\n" +
                "1. Comprobar modificación de fichero\n" +
                "2. comprobar lineas de fichero\n" +
                "3. Salir\n");

            int select = Convert.ToInt32(Console.ReadLine());
            Console.Clear();

            if(select == 1) {return MenuModificar(); }
            if(select == 2) {return MenuComprobar(); }
            if(select < 1 || select > 2) { return false; }
            return res;
        }

        static bool MenuModificar()
        {
            Console.WriteLine("COMPROBAR MODIFICACIÓN DE FICHERO\n" +
            "1. Arrancar / Parar\n" +
            "2. Fichero a comproboar\n" +
            "3. Delay\n" +
            "0. Salir al menú principal\n");

            int select = Convert.ToInt32(Console.ReadLine());
            Console.Clear();

            if (select == 1) { }
            if (select == 2) { }
            if (select == 3) { }
            if (select < 1 || select > 3) { return true; }
            return true;
        }

        static bool MenuComprobar()
        {
            Console.WriteLine("COMPROBAR LINEAS DE FICHERO\n" +
            "1. Arrancar / Parar\n" +
            "2. Fichero a comproboar\n" +
            "3. Número límite de líneas\n" +
            "4. Delay\n" +
            "0. Salir al menú principal\n");

            int select = Convert.ToInt32(Console.ReadLine());
            Console.Clear();

            if (select == 1) { }
            if (select == 2) { }
            if (select == 3) { }
            if (select == 4) { }
            if (select < 1 || select > 4) { return true; }
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
            Console.WriteLine("Introduce el delay en milisegundos: ");
            int num = Convert.ToInt32(Console.ReadLine());

            return num;
        }
    }
}