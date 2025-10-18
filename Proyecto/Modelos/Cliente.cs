using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorDeVentas
{
    public struct Cliente
    {
        public int Id;
        public string Nombre;
        public string Contacto;

        public Cliente(int id, string nombre, string contacto)
        {
            Id = id;
            Nombre = nombre;
            Contacto = contacto;
        }
    }
}

