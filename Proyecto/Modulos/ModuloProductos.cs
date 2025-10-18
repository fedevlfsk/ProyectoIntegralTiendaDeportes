using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System;
using System.Collections.Generic;

namespace GestorDeVentas
{
    public static class ModuloProductos
    {
        static List<Producto> productos = new List<Producto>()
        {
            new Producto(1, "Zapatillas Running Nike Air", "39, 40, 41, 42, 43", 98000 , 170000 , 15),
            new Producto(2, "Remera Adidas", "L, XL", 56000, 97000, 30),
            new Producto(3, "Short Entrenamiento", "36, 38, 40", 23000, 48000, 25),
            new Producto(4, "Campera Rompeviento", "S, M, L", 68000, 119000, 10),
            new Producto(5, "Pelota Fútbol Adidas", "5", 19000, 45000, 20),
            new Producto(6, "Guantes de Arquero", "unico", 18000, 37000, 12),
            new Producto(7, "Mochila Nike Brasilia", "30L", 64000, 128000, 5),
            new Producto(8, "Medias Deportivas (pack x3)", "unico", 8000, 19000, 40),
            new Producto(9, "Botines Puma Ultra", "39, 40, 41, 42, 43", 120000, 239000, 8),
            new Producto(10, "Gorra Under Armour", "unico", 18000, 27000, 22)
        };
        public static void ProductoMenu()
        {
            int opcion = 0;

            do
            {
                Console.WriteLine("\n         PRODUCTOS       ");
                Console.WriteLine("--------------------");
                Console.WriteLine("1. Ver productos");
                Console.WriteLine("2. Buscar producto");
                Console.WriteLine("3. Agregar producto");
                Console.WriteLine("4. Modificar producto");
                Console.WriteLine("5. Eliminar producto");
                Console.WriteLine("6. Volver");

                Console.Write("\nSeleccione una opción: ");
                string entrada = Console.ReadLine();
                Console.Clear();

                if (int.TryParse(entrada, out opcion))
                {
                    switch (opcion)
                    {
                        case 1: VerProductos(); break;
                        case 2: BuscarProducto(); break;
                        case 3: AgregarProducto(); break;
                        case 4: ModificarProducto(); break;
                        case 5: EliminarProducto(); break;
                        case 6: return;
                        default: Console.WriteLine("La opción no es válida."); break;
                    }
                }
            } while (true);
        }

        public static void VerProductos()
        {
            Console.WriteLine("Listado de productos");
            Console.WriteLine(new string('-', 100));
            Console.WriteLine($"{"Id",-5} {"Nombre",-30} {"Descripcion",-25} {"Costo",-12} {"PDV",-12} {"Stock",-6}");
            Console.WriteLine(new string('-', 100));

            foreach (var pro in productos)
            {
                Console.WriteLine($"{pro.Id,-5} {pro.Nombre,-30} {pro.Descripcion,-25} {pro.Costo,-12:C0} {pro.Precio,-12:C0} {pro.Stock,-6}");
                if (pro.Stock <= 4)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"¡Stock bajo {pro.Nombre}!");
                    Console.ResetColor();
                }
            }
            Console.WriteLine();
        }

        public static void BuscarProducto()
        {
            Console.Write("Ingrese el nombre del producto a buscar: ");
            string buscado = Console.ReadLine().ToLower();
            Console.Clear();

            bool encontrado = false;

            foreach (var pro in productos)
            {
                if (pro.Nombre.ToLower().Contains(buscado))
                {
                    Console.WriteLine($"{"Id",-5} {"Nombre",-30} {"Descripcion",-25} {"Costo",-12} {"PDV",-12} {"Stock",-6}");
                    Console.WriteLine(new string('-', 100));
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine($"{pro.Id,-5} {pro.Nombre,-30} {pro.Descripcion,-25} {pro.Costo,-12:C0} {pro.Precio,-12:C0} {pro.Stock,-6}");
                    Console.ResetColor();
                    encontrado = true;
                }
            }

            if (!encontrado)
                Console.WriteLine("No se encontró el producto.");
        }

        public static void AgregarProducto()
        {
            Producto nuevoProducto = new Producto();

            Console.WriteLine("Ingrese el nombre del producto:");
            nuevoProducto.Nombre = Console.ReadLine();

            Console.WriteLine("Ingrese la descripcion:");
            nuevoProducto.Descripcion = Console.ReadLine();

            nuevoProducto.Costo = AccesoVendedor.LeerDouble("Ingrese el costo:");

            nuevoProducto.Precio = AccesoVendedor.LeerEntero("Ingrese el precio de venta:");

            nuevoProducto.Stock = AccesoVendedor.LeerEntero("Ingrese el stock:");

            productos.Add(nuevoProducto);
            Console.WriteLine("Producto agregado.\n");
        }

        public static void ModificarProducto()
        {
            VerProductos();
            Console.Write("Seleccione el ID del producto a modificar: ");
            int index = int.Parse(Console.ReadLine()) - 1;

            if (index >= 0 && index < productos.Count)
            {
                Producto pro = productos[index];
                Console.WriteLine("Datos a modificar (dejar vacío para no modificar):");

                Console.Write("Nuevo nombre: ");
                string nuevoNombre = Console.ReadLine();
                if (!string.IsNullOrEmpty(nuevoNombre)) pro.Nombre = nuevoNombre;

                Console.Write("Nueva descripcion: ");
                string nuevaDesc = Console.ReadLine();
                if (!string.IsNullOrEmpty(nuevaDesc)) pro.Descripcion = nuevaDesc;

                Console.Write("Nuevo costo: ");
                if (double.TryParse(Console.ReadLine(), out double costo)) pro.Costo = costo;

                Console.Write("Nuevo precio: ");
                if (double.TryParse(Console.ReadLine(), out double precio)) pro.Precio = precio;

                Console.Write("Nuevo stock: ");
                if (int.TryParse(Console.ReadLine(), out int stock)) pro.Stock = stock;

                productos[index] = pro;
            }
            else
            {
                Console.WriteLine("Producto no encontrado");
            }
        }

        public static void EliminarProducto()
        {
            VerProductos();
            Console.Write("Seleccione el ID del producto a eliminar: ");
            int index = int.Parse(Console.ReadLine()) - 1;

            if (index >= 0 && index < productos.Count)
            {
                productos.RemoveAt(index);
                Console.WriteLine("Producto eliminado.\n");
            }
            else
            {
                Console.WriteLine("Producto no encontrado.\n");
            }
        }
    }
}
