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
                Console.Clear();
                MostrarMenu();
                string opcion = Console.ReadLine();

                switch (opcion)
                {
                    //requerimiento 1 mostrar menú de opciones y permitir al usuario seleccionar una opción
                    case "1":
                        Console.Clear();
                        Console.WriteLine("1. Registro de solicitudes");

                        //requerimiento 2 solicitar y validar datos del usuario para registrar una solicitud
                        string codigo=leerCodigoEstudiante("Ingrese el código del estudiante: (Ejemplo: N20230001)");

                        //requerimiento 3 tipo de solicitud
                        Console.WriteLine("Ingrese el tipo de solicitud:");
                        Console.WriteLine("1. Consulta");
                        Console.WriteLine("2. Reclamo");
                        Console.WriteLine("3. Trámite");
                        int tipoSolicitud=leerOpcionNumerica("Seleccione una opción (1-3):", 1, 3);

                        string nombreTipo=obtenerNombreTipoSolicitud(tipoSolicitud);

                        string prioridad=calcularPrioridadSolicitud(tipoSolicitud);
                        //requerimiento 6 descripción de la solicitud
                        string descripcion=leerTextoObligatorio("Ingrese la descripción de la solicitud (mínimo 10 caracteres):", 10);

                        mostrarResumenSolicitud(codigo, nombreTipo, prioridad, descripcion);
                        break;
                    case "2":
                        Console.Clear();
                        Console.WriteLine("2. Ver solicitudes registradas");
                        break;
                    case "3":
                        continuar = false;
                        Console.WriteLine("3. Saliendo del programa...");
                        Console.ReadKey();
                        break;
                    default:
                        Console.WriteLine("Opción no válida. Intente nuevamente.");
                        Console.ReadKey();
                        break;
                }
            }
        }

        //Requerimiento 4 sin retorno: mostrar menú de opciones y permitir al usuario seleccionar una opción
        static void MostrarMenu()
        {
            Console.WriteLine("Seleccione una opción:");
            Console.WriteLine("1. Registro de solicitudes");
            Console.WriteLine("2. Ver solicitudes registradas");
            Console.WriteLine("3. Salir del programa");
        }

        //Requerimiento 2 con retorno, validar que el usuario ingrese un código de estudiante con formato específico
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
        //requerimiento 6 con retorno validar texto ingresado por el usuario, que no sea vacío y que no contenga caracteres especiales
        static string leerTextoObligatorio(string mensaje, int longitudMinima)
        {
            string texto = "";
            bool esValido;
            do
            {
                Console.WriteLine(mensaje);
                texto = Console.ReadLine() ?? "";
                esValido = !string.IsNullOrWhiteSpace(texto) && texto.Length >= longitudMinima && System.Text.RegularExpressions.Regex.IsMatch(texto, @"^[a-zA-Z0-9\s]+$");
                if (!esValido)
                {
                    Console.WriteLine($"¡Error! El texto no puede estar vacío, debe tener al menos {longitudMinima} caracteres y no puede contener caracteres especiales. Intente nuevamente.");
                }
            } while (!esValido);
            return texto;
        }

        //Pequeño arreglo para mostrar el nombre del tipo de solicitud según la opción seleccionada
        static string obtenerNombreTipoSolicitud(int tipoSolicitud)
        {
            switch (tipoSolicitud)
            {
                case 1:
                    return "Consulta";
                case 2:
                    return "Reclamo";
                case 3:
                    return "Trámite";
                default:
                    return "Desconocido";
            }
        }
        //requerimiento 5 con retorno, calcular la prioridad de la solicitud según el tipo de solicitud
        static string calcularPrioridadSolicitud(int tipoSolicitud)
            {
                switch (tipoSolicitud)
                {
                    case 1:
                        return "Baja";
                    case 3:
                        return "Media";
                    case 2:
                        return "Alta";
                    default:
                        return "Desconocida";
                }
            }
            static void mostrarResumenSolicitud(string codigo, string tipoSolicitud, string prioridad, string descripcion)
            {
                Console.Clear();
                Console.WriteLine($"Resumen de la solicitud:");
                Console.WriteLine($"Código del estudiante: {codigo}");
                Console.WriteLine($"Tipo de solicitud: {tipoSolicitud}");
                Console.WriteLine($"Prioridad: {prioridad}");
                Console.WriteLine($"Descripción: {descripcion}");
                Console.ReadKey();
            }
    }
}