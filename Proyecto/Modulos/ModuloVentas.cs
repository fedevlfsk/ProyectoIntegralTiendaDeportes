using System;
using System.Collections.Generic;
using System.Linq;

namespace GestorDeVentas
{
    public struct Venta
    {
        public int Id;
        public Cliente Cliente;
        public List<(Producto Producto, int Cantidad)> Detalles;
        public double Total;
        public DateTime Fecha;

        public Venta(int id, Cliente cliente, List<(Producto Producto, int Cantidad)> detalles)
        {
            Id = id;
            Cliente = cliente;
            Detalles = detalles;
            Total = detalles.Sum(d => d.Producto.Precio * d.Cantidad);
            Fecha = DateTime.Now;
        }
    }

    public static class ModuloVentas
    {
        static List<Venta> ventas = new List<Venta>();
        static List<Cliente> clientes = new List<Cliente>()
        {
            new Cliente(1, "Lucas Pérez", "lucas@gmail.com"),
            new Cliente(2, "Ana García", "ana.garcia@gmail.com"),
            new Cliente(3, "Juan Torres", "juan.torres@gmail.com")
        };

        public static void VentaMenu()
        {
            int opcion = 0;
            do
            {
                Console.WriteLine("\n       MÓDULO DE VENTAS       ");
                Console.WriteLine("--------------------------------");
                Console.WriteLine("1. Registrar nueva venta");
                Console.WriteLine("2. Ver historial de ventas");
                Console.WriteLine("3. Buscar venta por cliente");
                Console.WriteLine("4. Volver");

                Console.Write("\nSeleccione una opción: ");
                string entrada = Console.ReadLine();
                Console.Clear();

                if (int.TryParse(entrada, out opcion))
                {
                    switch (opcion)
                    {
                        case 1: RegistrarVenta(); break;
                        case 2: VerHistorial(); break;
                        case 3: BuscarPorCliente(); break;
                        case 4: return;
                        default: Console.WriteLine("Opción no válida."); break;
                    }
                }

            } while (true);
        }

        public static void RegistrarVenta()
        {
            Console.WriteLine("Seleccione un cliente:");
            foreach (var cli in clientes)
                Console.WriteLine($"{cli.Id}. {cli.Nombre}");

            int idCliente = AccesoVendedor.LeerEntero("Ingrese el ID del cliente: ");
            Cliente cliente = clientes.FirstOrDefault(c => c.Id == idCliente);

            if (cliente.Nombre == null)
            {
                Console.WriteLine("Cliente no encontrado.");
                return;
            }

            List<(Producto Producto, int Cantidad)> detalles = new List<(Producto, int)>();
            bool continuar = true;

            while (continuar)
            {
                ModuloProductos.VerProductos();
                int idProducto = AccesoVendedor.LeerEntero("Ingrese el ID del producto: ");
                int cantidad = AccesoVendedor.LeerEntero("Ingrese la cantidad: ");

                // Accedemos directamente a la lista de productos
                Producto producto = ModuloProductos.productos.FirstOrDefault(p => p.Id == idProducto);

                if (producto.Nombre == null)
                {
                    Console.WriteLine("Producto no encontrado.");
                    continue;
                }

                if (producto.Stock < cantidad)
                {
                    Console.WriteLine("Stock insuficiente.");
                    continue;
                }

                // Restamos el stock directamente
                producto.Stock -= cantidad;
                ModuloProductos.productos[ModuloProductos.productos.FindIndex(p => p.Id == producto.Id)] = producto;

                detalles.Add((producto, cantidad));

                Console.Write("¿Agregar otro producto? (s/n): ");
                continuar = Console.ReadLine().ToLower() == "s";
            }

            Venta nuevaVenta = new Venta(ventas.Count + 1, cliente, detalles);
            ventas.Add(nuevaVenta);

            Console.WriteLine($"\nVenta registrada con éxito.");
            Console.WriteLine($"Cliente: {cliente.Nombre}");
            Console.WriteLine($"Total: {nuevaVenta.Total:C0}");
            Console.WriteLine($"Fecha: {nuevaVenta.Fecha}");
        }

        public static void VerHistorial()
        {
            Console.WriteLine("Historial de Ventas");
            Console.WriteLine(new string('-', 80));

            foreach (var venta in ventas)
            {
                Console.WriteLine($"Venta #{venta.Id} - {venta.Cliente.Nombre} - {venta.Fecha}");
                foreach (var d in venta.Detalles)
                    Console.WriteLine($"  {d.Producto.Nombre,-30} x{d.Cantidad} = {(d.Producto.Precio * d.Cantidad):C0}");

                Console.WriteLine($"Total: {venta.Total:C0}");
                Console.WriteLine(new string('-', 80));
            }

            if (ventas.Count == 0)
                Console.WriteLine("No hay ventas registradas.");
        }

        public static void BuscarPorCliente()
        {
            Console.Write("Ingrese el nombre del cliente: ");
            string nombre = Console.ReadLine().ToLower();

            var resultados = ventas.Where(v => v.Cliente.Nombre.ToLower().Contains(nombre)).ToList();

            if (resultados.Count == 0)
            {
                Console.WriteLine("No se encontraron ventas para ese cliente.");
                return;
            }

            foreach (var venta in resultados)
            {
                Console.WriteLine($"Venta #{venta.Id} - {venta.Fecha} - Total: {venta.Total:C0}");
            }
        }
    }
}
