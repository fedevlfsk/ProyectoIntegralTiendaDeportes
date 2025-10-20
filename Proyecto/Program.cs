using System;

namespace GestorDeVentas
{
    public class Program
    {
        static void Main()
        {
            Console.Title = "GESTOR DE VENTAS";
            
            AccesoVendedor.IngresoVendedor();

            int opcion = 0;

            do
            {
                    Console.Write(" Seleccione una opción: ");
                    string entrada = Console.ReadLine();
                    Console.Clear();

                    if (int.TryParse(entrada, out opcion))
                    {
                        switch (opcion)
                        {
                            case 1:
                                ModuloVentas.VentaMenu();
                                break;
                            case 2:
                                ModuloProductos.ProductoMenu();
                                break;
                            case 3:
                                ModuloClientes.ClientesMenu();
                                break;
                            case 4:
                                Console.Write(" Saliendo del programa...");
                                break;
                            default:
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine(" La opción no es válida. Ingrese otra opción.");
                                Console.ResetColor();
                                break;
                        }
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine(" Ingrese un número válido.");
                        Console.ResetColor();
                }
                    if (opcion != 4)
                    AccesoVendedor.ImprimirMenu(); //  muestra el menú sin pedir el nombre


            } while (opcion != 4);

            Console.ReadKey();
        }
    }
}

