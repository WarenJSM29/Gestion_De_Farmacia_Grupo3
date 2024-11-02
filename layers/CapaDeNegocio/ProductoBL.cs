using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDeEntidades;
using CapaDeAccesoDatos;

namespace CapaDeNegocio
{
    public class ProductoBL
    {
        private ProductoDAL productoDAL = new ProductoDAL();

        public void RegistrarProducto(Producto producto)
        {
            productoDAL.InsertarProducto(producto);
        }

        public DataTable ObtenerListaProductos()
        {
            return productoDAL.ObtenerProductos();
        }
    }
}