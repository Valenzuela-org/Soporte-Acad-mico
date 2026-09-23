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
                        //requerimiento 2 y 6 solicitar y validar datos del usuario para registrar una solicitud
                        string codigo=leerTextoObligatorio("Ingrese el código del estudiante: (Minimo 4 caracteres)", 4);
                        Console.WriteLine($"Código ingresado: {codigo}");
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
        //funcion 6 con retorno, validar que el texto ingresado por el usuario cumpla con un mínimo de caracteres
        static string leerTextoObligatorio(string mensaje, int longitudMinima)
        {
            string texto = "";
            do
            {
                Console.WriteLine(mensaje);
                texto = Console.ReadLine() ?? "";
                if (string.IsNullOrWhiteSpace(texto) || texto.Length < longitudMinima)
                {
                    Console.WriteLine($"¡Error! El texto debe tener al menos {longitudMinima} caracteres. Intente nuevamente.");
                }
            } while (string.IsNullOrWhiteSpace(texto) || texto.Length < longitudMinima);
            return texto;
        }
    }
}