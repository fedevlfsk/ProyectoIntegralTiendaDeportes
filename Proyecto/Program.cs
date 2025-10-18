using System;

namespace GestorDeVentas
{
    public class Program
    {
        static void Main()
        {
            Console.Title = "GESTOR DE VENTAS";
            int opcion = 0;

            do
            {
                AccesoVendedor.IngresoVendedor();

                Console.Write("Seleccione una opción: ");
                string entrada = Console.ReadLine();
                Console.Clear();

                if (int.TryParse(entrada, out opcion))
                {
                    switch (opcion)
                    {
                        case 1:
                            break;
                        case 2:
                            ModuloProductos.ProductoMenu();
                            break;
                        case 3:
                            break;
                        case 4:
                            Console.Write("Saliendo del programa...");
                            break;
                        default:
                            Console.WriteLine("La opción no es válida. Ingrese otra opción.");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Ingrese un número válido.");
                }
            } while (opcion != 4);

            Console.ReadKey();
        }
    }
}

