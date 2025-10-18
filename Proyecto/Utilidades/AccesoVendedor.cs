using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System;

namespace GestorDeVentas
{
    public static class AccesoVendedor
    {
        public static void IngresoVendedor()
        {
            string[] vendedorNombre = { "Matias", "Federico", "Teo", "German", "Maxi" };
            Array.Sort(vendedorNombre, StringComparer.OrdinalIgnoreCase);

            bool encontrado = false;

            while (!encontrado)
            {
                Console.Write("Ingrese su nombre: ");
                string buscado = Console.ReadLine();
                Console.Clear();

                int index = Array.BinarySearch(vendedorNombre, buscado, StringComparer.OrdinalIgnoreCase);
                if (index >= 0)
                {
                    Console.WriteLine($"\nVendedor autorizado, bienvenido {vendedorNombre[index]}!");
                    encontrado = true;
                    ImprimirMenu();
                }
                else
                {
                    Console.WriteLine("No se encontró un vendedor con ese nombre, intente nuevamente.");
                }
            }
        }

        public static void ImprimirMenu()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\n╔══════════════════════════════════════════════════════╗");
            Console.WriteLine("║                   GESTOR DE VENTAS                   ║");
            Console.WriteLine("╚══════════════════════════════════════════════════════╝");
            Console.ResetColor();

            Console.WriteLine("1. Ventas");
            Console.WriteLine("2. Productos");
            Console.WriteLine("3. Clientes");
            Console.WriteLine("4. Salir");
        }
    }
}

