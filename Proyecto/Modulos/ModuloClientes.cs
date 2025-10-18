using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace GestorDeVentas
{
    public static class ModuloClientes
    {
        // === MODULOS CLIENTES ===
        static List<Cliente> clientes = new List<Cliente>()
        {
            new Cliente(1, "Juan Pérez", "juan.perez@email.com"),
            new Cliente(2, "María Gómez", "maria.gomez@email.com"),
            new Cliente(3, "Carlos López", "carlos.lopez@email.com"),
            new Cliente(4, "Ana Fernández", "ana.fernandez@email.com"),
            new Cliente(5, "Santiago Rodríguez", "santiago.rodriguez@email.com"),
            new Cliente(6, "Lucía Martínez", "lucia.martinez@email.com"),
            new Cliente(7, "Pedro García", "pedro.garcia@email.com"),
            new Cliente(8, "Sofía Torres", "sofia.torres@email.com"),
            new Cliente(9, "Javier Ramírez", "javier.ramirez@email.com"),
            new Cliente(10, "Camila Morales", "camila.morales@email.com")
        };

        // Menú principal de clientes
        public static void Cliente()
        {
            int opcion = 0;

            do
            {
                Console.WriteLine("       Clientes      ");
                Console.WriteLine(" --------------------");
                Console.WriteLine(" 1. Ver clientes");
                Console.WriteLine(" 2. Buscar cliente");
                Console.WriteLine(" 3. Agregar cliente");
                Console.WriteLine(" 4. Modificar cliente");
                Console.WriteLine(" 5. Volver");

                Console.Write("\n Seleccione una opción: ");
                string entrada = Console.ReadLine();
                Console.Clear();

                if (int.TryParse(entrada, out opcion))
                {
                    switch (opcion)
                    {
                        case 1:
                            VerClientes();
                            break;
                        case 2:
                            BuscarCliente();
                            break;
                        case 3:
                            AgregarCliente();
                            break;
                        case 4:
                            ModificarCliente();
                            break;
                        case 5:
                            Console.WriteLine(" Volviendo al menú principal...");
                            return;
                        default:
                            Console.WriteLine(" La opción no es válida. Ingrese otra opción.");
                            break;
                    }
                }
            } while (opcion != 5);

            Console.ReadKey();
            Console.Clear();
        }

        public static void VerClientes()
        {
            Console.WriteLine(" Listado de clientes");
            Console.WriteLine(" --------------------");
            Console.WriteLine(" Codigo Nombre Contacto");

            for (int i = 0; i < clientes.Count; i++)
            {
                Cliente cli = clientes[i];
                Console.WriteLine($" {i + 1} {cli.Nombre} {cli.Contacto}");
            }
            Console.WriteLine();
        }

        public static void BuscarCliente()
        {
            if (clientes.Count == 0)
            {
                Console.WriteLine(" No hay clientes cargados.");
                Console.WriteLine("\n Presione una tecla para continuar...");
                Console.ReadKey(true);
                Console.Clear();
                return;
            }

            Console.Write(" Ingrese el nombre o correo del cliente a buscar: ");
            string textoBuscado = (Console.ReadLine() ?? "").Trim().ToLower();
            Console.Clear();

            Console.WriteLine(" Resultados de la búsqueda");
            Console.WriteLine(" ------------------------");
            Console.WriteLine($" {"N°",-4} {"Nombre",-25} {"Correo",-30}");
            Console.WriteLine(new string('-', 65));

            bool encontrado = false;

            for (int i = 0; i < clientes.Count; i++)
            {
                Cliente clienteActual = clientes[i];

                if (clienteActual.Nombre.ToLower().Contains(textoBuscado) ||
                    clienteActual.Contacto.ToLower().Contains(textoBuscado))
                {
                    Console.WriteLine($" {i + 1,-4} {clienteActual.Nombre,-25} {clienteActual.Contacto,-30}");
                    encontrado = true;
                }
            }

            if (!encontrado)
                Console.WriteLine(" No se encontraron clientes con ese dato.");

            Console.WriteLine("\n Presione una tecla para continuar...");
            Console.ReadKey(true);
            Console.Clear();
        }

        public static void AgregarCliente()
        {
            Cliente nuevoCliente = new Cliente(); // Crea un nuevo cliente

            // Validar nombre 
            string nombre;
            do
            {
                Console.Write(" Ingrese nombre y apellido del cliente: ");
                nombre = (Console.ReadLine() ?? "").Trim();

                if (string.IsNullOrEmpty(nombre))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(" El nombre no puede estar vacío.");
                    Console.ResetColor();
                }
            } while (string.IsNullOrEmpty(nombre));
            nuevoCliente.Nombre = nombre;

            // Validar correo 
            string correo;
            do
            {
                Console.Write(" Ingrese un mail de contacto: ");
                correo = (Console.ReadLine() ?? "").Trim();

                if (string.IsNullOrEmpty(correo) || !correo.Contains("@") || !correo.Contains("."))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(" El correo electrónico no es válido. Ejemplo: nombre@dominio.com");
                    Console.ResetColor();
                    correo = null; // fuerza repetir
                }
            } while (string.IsNullOrEmpty(correo));
            nuevoCliente.Contacto = correo;

            // Asignar ID automático
            nuevoCliente.Id = clientes.Count + 1;

            // Agregar a la lista
            clientes.Add(nuevoCliente);

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\n Cliente agregado correctamente.\n");
            Console.ResetColor();

            Console.WriteLine(" Presione una tecla para continuar...");
            Console.ReadKey(true);
            Console.Clear();
        }

        public static void ModificarCliente()
        {
            VerClientes();

            Console.Write(" Seleccione el ID del cliente a modificar: ");
            string entrada = Console.ReadLine();
            if (!int.TryParse(entrada, out int index))
            {
                Console.WriteLine(" Valor inválido.");
                return;
            }
            index -= 1;

            if (index >= 0 && index < clientes.Count)
            {
                Cliente cli = clientes[index];

                Console.WriteLine(" Datos a modificar (dejar vacío para no modificar):");

                Console.Write(" Nuevo nombre: ");
                string nuevoNombre = (Console.ReadLine() ?? "").Trim();
                if (!string.IsNullOrEmpty(nuevoNombre))
                    cli.Nombre = nuevoNombre;

                Console.Write(" Nuevo email: ");
                string nuevoCorreo = (Console.ReadLine() ?? "").Trim();
                if (!string.IsNullOrEmpty(nuevoCorreo) && nuevoCorreo.Contains("@") && nuevoCorreo.Contains("."))
                    cli.Contacto = nuevoCorreo;

                clientes[index] = cli; // guardar cambios

                Console.WriteLine("\n Cliente actualizado.\n");
                VerClientes();
            }
            else
            {
                Console.WriteLine(" Cliente no encontrado.");
            }
        }
    }
}
