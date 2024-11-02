using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using CapaDeEntidades;

namespace CapaDeAccesoDatos
{
    public class ProductoDAL
    {
        private readonly string _connectionString = "Server=localhost;Database=GestionFarmacia;Trusted_Connection=True;";

        public void InsertarProducto(Producto producto)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string query = "INSERT INTO RegistroProductos (Id, Nombre, Descripcion, Precio, FechaCaducidad, Cantidad) " +
                               "VALUES (@Id, @Nombre, @Descripcion, @Precio, @FechaCaducidad, @Cantidad)";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Id", producto.Id);
                command.Parameters.AddWithValue("@Nombre", producto.Nombre);
                command.Parameters.AddWithValue("@Descripcion", producto.Descripcion);
                command.Parameters.AddWithValue("@Precio", producto.Precio);
                command.Parameters.AddWithValue("@FechaCaducidad", producto.FechaCaducidad);
                command.Parameters.AddWithValue("@Cantidad", producto.Cantidad);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public DataTable ObtenerProductos()
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string query = "SELECT * FROM RegistroProductos";
                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                DataTable productos = new DataTable();
                adapter.Fill(productos);
                return productos;
            }
        }
    }
}