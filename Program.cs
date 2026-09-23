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

                        //requerimiento 2 solicitar y validar datos del usuario para registrar una solicitud
                        string codigo=leerCodigoEstudiante("Ingrese el código del estudiante: (Ejemplo: N20230001)");

                        //requerimiento 3 tipo de solicitud
                        Console.WriteLine("Ingrese el tipo de solicitud:");
                        Console.WriteLine("1. Consulta");
                        Console.WriteLine("2. Reclamo");
                        Console.WriteLine("3. Trámite");
                        int tipoSolicitud=leerOpcionNumerica("Seleccione una opción (1-3):", 1, 3);

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

        //Validar codigo de estudiante
        static string leerCodigoEstudiante(string mensaje)
        {
            string codigo = "";
            bool esValido=false;
            do
            {
                Console.WriteLine(mensaje);
                codigo = Console.ReadLine() ?? "";
                if (!System.Text.RegularExpressions.Regex.IsMatch(codigo, @"^N\d{8}$"))
                {
                    Console.WriteLine("¡Error! El código debe tener el formato N seguido de 8 dígitos. Intente nuevamente.");
                }
            } while (!System.Text.RegularExpressions.Regex.IsMatch(codigo, @"^N\d{8}$"));
            return codigo;
        }

        //Requerimiento 3 con retorno, validar que el usuario ingrese un número dentro de un rango específico
        static int leerOpcionNumerica(string mensaje, int min, int max)
        {
            int opcion;
            bool esValido;
            do
            {
                Console.WriteLine(mensaje);
                string input = Console.ReadLine() ?? "";
                esValido = int.TryParse(input, out opcion) && opcion >= min && opcion <= max;
                if (!esValido)
                {
                    Console.WriteLine($"¡Error! Debe ingresar un número entre {min} y {max}. Intente nuevamente.");
                }
            } while (!esValido);
            return opcion;
        }
    }
}