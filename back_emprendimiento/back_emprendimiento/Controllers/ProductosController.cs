using back_emprendimiento.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace back_emprendimiento.Controllers
{
    [EnableCors(origins: "*", headers: "*",methods: "GET, POST, PUT, DELETE, OPTIONS" )]
    public class ProductosController : ApiController
    {
        // GET: api/Productos
        public IEnumerable<Producto> Get()
        {
            GestorProducto gProductos = new GestorProducto();
            return gProductos.getProducto();
        }

        // GET: api/Productos/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Productos
        public bool Post([FromBody]Producto producto)
        {
            GestorProducto gProductos = new GestorProducto();
            bool respuesta = gProductos.addProducto(producto);

            return respuesta;
        }

        // PUT: api/Productos/5
        [HttpPut]
        public bool Put(int id, [FromBody] Producto producto)
        {
            GestorProducto gProductos = new GestorProducto();
            bool respuesta = gProductos.updateProducto(id,producto);

            return respuesta;
        }

        // DELETE: api/Productos/5
        public bool Delete(int id)
        {
            GestorProducto gProductos = new GestorProducto();
            bool respuesta = gProductos.deleteProducto(id);

            return respuesta;
        }
    }
}
