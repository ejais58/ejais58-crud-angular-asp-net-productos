using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace back_emprendimiento.Models
{
    public class GestorProducto
    {
        public List<Producto> getProducto()
        {
            List<Producto> lista = new List<Producto>();
            string connection = ConfigurationManager.ConnectionStrings["db_emprendimiento"].ToString();
            using (SqlConnection conn = new SqlConnection(connection))
            {
                conn.Open();
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "Productos_All";
                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    int id = dr.GetInt32(0);
                    string nombre = dr.GetString(1).Trim();
                    string desc = dr.GetString(2).Trim();
                    string precio = dr.GetString(3).Trim();
                    

                    Producto producto = new Producto (id, nombre, desc, precio);

                    lista.Add(producto);
                }

                dr.Close();
                conn.Close();
                
            }

            return lista;
        }

        public bool addProducto(Producto producto)
        {
            bool respuesta = false;

            string connection = ConfigurationManager.ConnectionStrings["db_emprendimiento"].ToString();

            using (SqlConnection conn = new SqlConnection(connection))
            {
                SqlCommand cmd = conn.CreateCommand();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                cmd.CommandText = "Productos_Add";
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@nombre", producto.nombre);
                cmd.Parameters.AddWithValue("@desc", producto.descripcion);
                cmd.Parameters.AddWithValue("@precio", producto.precio);


                try
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    respuesta = true;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    respuesta = false;
                    throw;
                }
                finally
                {
                    cmd.Parameters.Clear();
                    conn.Close();
                }
                return respuesta;
            }

        }

        public bool updateProducto( int id, Producto producto)
      {
            bool respuesta = false;

            string connection = ConfigurationManager.ConnectionStrings["db_emprendimiento"].ToString();

            using (SqlConnection conn = new SqlConnection(connection))
            {
                SqlCommand cmd = conn.CreateCommand();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                cmd.CommandText = "Productos_Update";
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@id", id);
                cmd.Parameters.AddWithValue("@nombre", producto.nombre);
                cmd.Parameters.AddWithValue("@desc", producto.descripcion);
                cmd.Parameters.AddWithValue("@precio", producto.precio);

                try
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    respuesta = true;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    respuesta = false;
                    throw;
                }
                finally
                {
                    cmd.Parameters.Clear();
                    conn.Close();
                }
                return respuesta;
            }

        }

        public bool deleteProducto(int id)
        {
            bool respuesta = false;

            string connection = ConfigurationManager.ConnectionStrings["db_emprendimiento"].ToString();

            using (SqlConnection conn = new SqlConnection(connection))
            {
                SqlCommand cmd = conn.CreateCommand();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                cmd.CommandText = "Productos_Delete";
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@id", id);

                try
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    respuesta = true;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    respuesta = false;
                    throw;
                }
                finally
                {
                    cmd.Parameters.Clear();
                    conn.Close();
                }
                return respuesta;
            }

        }


    }
}