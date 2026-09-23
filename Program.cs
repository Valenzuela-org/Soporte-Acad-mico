using System;
namespace SoporteAcademico
{
    class Program
    {
static void Main(string[] args)
        {
            bool continuar = true;
            while (continuar)
            {
                MostrarMenu();
                string opcion = Console.ReadLine();

                switch (opcion)
                {
                    case "1":
                        Console.WriteLine("1. Registro de solicitudes");
                        break;
                    case "2":
                        Console.WriteLine("2. Ver solicitudes registradas");
                        break;
                    case "3":
                        continuar = false;
                        Console.WriteLine("3. Saliendo del programa");
                        break;
                    default:
                        Console.WriteLine("Opción no válida. Intente nuevamente.");
                        break;
                }
            }
        }
        //Funcion 4 sin retorno: mostrar menú de opciones y permitir al usuario seleccionar una opción
        static void MostrarMenu()
        {
            Console.WriteLine("Seleccione una opción:");
            Console.WriteLine("1. Registro de solicitudes");
            Console.WriteLine("2. Ver solicitudes registradas");
            Console.WriteLine("3. Salir del programa");
        }
    }
}