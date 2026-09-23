using System;
namespace SoporteAcademico
{
    class Program
    {
static void Main(string[] args)
        {
            bool continuar = true;

            //Requerimiento 8: Definir arreglos para almacenar los datos de las solicitudes
            int maxSolicitudes = 100; // Definir un límite máximo de solicitudes
            string [] codigosEstudiantes = new string[maxSolicitudes];
            string [] tiposSolicitudes = new string[maxSolicitudes];
            string [] prioridadesSolicitudes = new string[maxSolicitudes];
            string [] descripcionesSolicitudes = new string[maxSolicitudes];
            int cantidadSolicitudes = 0; // Contador de solicitudes registradas

            while (continuar)
            {
                Console.Clear();
                MostrarMenu();
                string opcion = Console.ReadLine() ?? "";

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

                        //reqyuerimiento 5 calcular la prioridad de la solicitud según el tipo de solicitud
                        string prioridad=calcularPrioridadSolicitud(tipoSolicitud);

                        //requerimiento 6 descripción de la solicitud
                        string descripcion=leerTextoObligatorio("Ingrese la descripción de la solicitud (mínimo 10 caracteres):", 10);

                        //arreglos paralelos
                        if (cantidadSolicitudes < maxSolicitudes)
                        {
                            codigosEstudiantes[cantidadSolicitudes] = codigo;
                            tiposSolicitudes[cantidadSolicitudes] = nombreTipo;
                            prioridadesSolicitudes[cantidadSolicitudes] = prioridad;
                            descripcionesSolicitudes[cantidadSolicitudes] = descripcion;
                            cantidadSolicitudes++;
                        }

                        //requerimiento 7 mostrar un resumen de la solicitud ingresada por el usuario
                        mostrarResumenSolicitud(codigo, nombreTipo, prioridad, descripcion);
                        break;
                    case "2":
                        //requerimiento 8 mostrar un listado de todas las solicitudes registradas por el usuario
                        mostrarListadoSolicitudes(codigosEstudiantes, tiposSolicitudes, prioridadesSolicitudes, descripcionesSolicitudes, cantidadSolicitudes);
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
            //Requerimiento 7 sin retorno, mostrar un resumen de la solicitud ingresada por el usuario
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
    //requerimiento 8 sin retorno, mostrar un listado de todas las solicitudes registradas por el usuario
    static void mostrarListadoSolicitudes(string [] codigosEstudiantes, string [] tiposSolicitudes, string [] prioridadesSolicitudes, string [] descripcionesSolicitudes, int cantidadSolicitudes)
    {
        Console.Clear();
        Console.WriteLine("Listado de solicitudes registradas:");
        if (cantidadSolicitudes == 0)
        {
            Console.WriteLine("No hay solicitudes registradas.");
        }
        else
        {
            for (int i = 0; i < cantidadSolicitudes; i++)
            {
                Console.WriteLine($"Solicitud {i + 1}:");
                Console.WriteLine($"Código del estudiante: {codigosEstudiantes[i]}");
                Console.WriteLine($"Tipo de solicitud: {tiposSolicitudes[i]}");
                Console.WriteLine($"Prioridad: {prioridadesSolicitudes[i]}");
                Console.WriteLine($"Descripción: {descripcionesSolicitudes[i]}");
                Console.WriteLine("-----------------------------");
            }
        }
        Console.WriteLine("Presione cualquier tecla para volver al menú...");
        Console.ReadKey();
    }
    }
}