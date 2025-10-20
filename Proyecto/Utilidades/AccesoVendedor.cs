using System;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorDeVentas
{
    public static class AccesoVendedor
    {
        public static void IngresoVendedor()
        {
            string[] vendedorNombre = { "Matias", "Federico", "Teo", "German", "Maxi" };
            string[] vendedorContrasena = { "12345", "abcde", "teo2025", "ger02", "gauthier2" };

            Array.Sort(vendedorNombre, vendedorContrasena, StringComparer.OrdinalIgnoreCase);

            bool encontrado = false;

            while (!encontrado)
            {
                Console.Write(" Ingrese su nombre: ");
                string buscado = Console.ReadLine();
                Console.Clear();
 
                int index = Array.BinarySearch(vendedorNombre, buscado, StringComparer.OrdinalIgnoreCase);
                if (index >= 0)
                {
                    int intentos = 3;

                    while (intentos > 0)
                    {
                        Console.Write(" Ingrese la contraseña: ");
                        string contrasenaBuscada = Console.ReadLine();
                        Console.Clear();

                        if (vendedorContrasena[index] == contrasenaBuscada)
                        {
                            Console.WriteLine($"\n      Vendedor autorizado, bienvenido {vendedorNombre[index]}!");
                            encontrado = true;
                            ImprimirMenu();
                            return;
                        }
                        else
                        {
                            intentos--;
                            Console.Write($" Contraseña incorrecta. Intentos restantes: ");
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine($"{intentos}");
                            Console.ResetColor();
                        }
                    }

                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\n Se acabaron los intentos. ACCESO BLOQUEADO.");
                    Console.ResetColor();
                    Console.Write(" Presione una tecla para salir...");
                    Console.ReadKey();
                    return;
                }

                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(" No se encontró un vendedor con ese nombre, intente nuevamente.\n");
                    Console.ResetColor();
                }
            }
        }

        public static void ImprimirMenu()
        {
            // Caracteres para bordes
            char esquinaSupIzq = '╔';
            char esquinaSupDer = '╗';
            char esquinaInfIzq = '╚';
            char esquinaInfDer = '╝';
            char bordeHorizontal = '═';
            char bordeVertical = '║';

            // Borde superior
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write($"\n {esquinaSupIzq}");
            for (int i = 0; i < 47; i++) Console.Write(bordeHorizontal);
            Console.WriteLine(esquinaSupDer);

            // Nombre del menú
            Console.WriteLine($" {bordeVertical}                                               {bordeVertical}");
            Console.WriteLine($" {bordeVertical}                GESTOR DE VENTAS               {bordeVertical}");
            Console.WriteLine($" {bordeVertical}                                               {bordeVertical}");

            // Borde inferior
            Console.Write($" {esquinaInfIzq}");
            for (int i = 0; i < 47; i++) Console.Write(bordeHorizontal);
            Console.WriteLine(esquinaInfDer);
            Console.ResetColor();

            // Opciones
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write($" {esquinaSupIzq}");
            for (int i = 0; i < 47; i++) Console.Write(bordeHorizontal);
            Console.WriteLine(esquinaSupDer);
            Console.WriteLine($" {bordeVertical}               ¿Que desea hacer?               {bordeVertical}");
            Console.WriteLine($" {bordeVertical} --------------------------------------------- {bordeVertical}");
            Console.WriteLine($" {bordeVertical}                                               {bordeVertical}");
            Console.WriteLine($" {bordeVertical} 1. Ventas                                     {bordeVertical}");
            Console.WriteLine($" {bordeVertical} 2. Productos                                  {bordeVertical}");
            Console.WriteLine($" {bordeVertical} 3. Clientes                                   {bordeVertical}");
            Console.WriteLine($" {bordeVertical} 4. Salir                                      {bordeVertical}");

            Console.Write($" {esquinaInfIzq}");
            for (int i = 0; i < 47; i++) Console.Write(bordeHorizontal);
            Console.WriteLine(esquinaInfDer);
            Console.ResetColor();
        }

        // Modulo TryParse para Double
        public static double LeerDouble(string mensaje)
        {
            double valor;
            Console.Write(mensaje);
            while (!double.TryParse(Console.ReadLine(), out valor))
            {
                Console.WriteLine(" Entrada inválida. Intente de nuevo.");
            }
            return valor;
        }

        // Modulo TryParse para Enteros
        public static int LeerEntero(string mensaje)
        {
            int valor;
            Console.Write(mensaje);
            while (!int.TryParse(Console.ReadLine(), out valor))
            {
                Console.WriteLine(" Entrada inválida. Intente de nuevo.");
            }
            return valor;
        }
    }
}


