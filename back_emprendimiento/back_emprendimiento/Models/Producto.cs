using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace back_emprendimiento.Models
{
    public class Producto
    {
        public int idProducto { get; set; }
        public string nombre { get; set; }
        public string descripcion { get; set; }
        public string precio { get; set; }
        public DateTime fecha { get; set; }
        public string stock { get; set; }

        public Producto()
        {

        }


        public Producto(string nombre)
        {

        }

        public Producto(int IdProducto, string Nombre, string Descripcion, string Precio, DateTime Fecha, string Stock)
        {
            this.idProducto = IdProducto;
            this.nombre = Nombre;
            this.descripcion = Descripcion;
            this.precio = Precio;
            this.fecha = Fecha;
            this.stock = Stock;
        }

        public Producto(int IdProducto, string Nombre, string Descripcion, string Precio)
        {
            this.idProducto = IdProducto;
            this.nombre = Nombre;
            this.descripcion = Descripcion;
            this.precio = Precio;
        }


    }
}