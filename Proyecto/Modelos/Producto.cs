using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorDeVentas
{
    public struct Producto
    {
        public int Id;
        public string Nombre;
        public string Descripcion;
        public double Costo;
        public double Precio;
        public int Stock;

        public Producto(int id, string nombre, string descripcion, double costo, double precio, int stock)
        {
            Id = id;
            Nombre = nombre;
            Descripcion = descripcion;
            Costo = costo;
            Precio = precio;
            Stock = stock;
        }
    }
}

