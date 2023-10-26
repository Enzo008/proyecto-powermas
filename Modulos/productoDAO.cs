using Microsoft.Data.SqlClient;
using System.Data;
using proyecto_powermas.Models;
using PROYECTO.Modulos;

namespace proyecto_powermas.Modulos
{
    public class productoDAO
    {
        private conexionDAO cn = new conexionDAO();

        public IEnumerable<Producto> Listado()
        {
            List<Producto> temporal = new List<Producto>();
            try
            {
                cn.getcn.Open();

                SqlCommand cmd = new SqlCommand("usp_obtener_productos", cn.getcn);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader rd = cmd.ExecuteReader();
                while (rd.Read())
                {
                    temporal.Add(new Producto()
                    {
                        ID = rd.GetInt32(0),
                        Nombre = rd.GetString(1),
                        Descripcion = rd.GetString(2),
                        Precio = rd.GetDecimal(3),
                        CantidadEnStock = rd.GetInt32(4),
                        FechaDeCreacion = rd.GetDateTime(5)
                    });
                }
                rd.Close();
            }
            catch (SqlException ex)
            {
                temporal = new List<Producto>();
                Console.WriteLine(ex.Message);
            }
            finally
            {
                cn.getcn.Close();
            }
            return temporal;
        }

        public string Agregar(Producto reg)
        {
            string mensaje = "";
            try
            {
                cn.getcn.Open();
                SqlCommand cmd = new SqlCommand("usp_insertar_producto", cn.getcn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Nombre", reg.Nombre);
                cmd.Parameters.AddWithValue("@Descripcion", reg.Descripcion);
                cmd.Parameters.AddWithValue("@Precio", reg.Precio);
                cmd.Parameters.AddWithValue("@CantidadEnStock", reg.CantidadEnStock);
                int c = cmd.ExecuteNonQuery();
                mensaje = $"Se ha agregado {c} producto(s)";
            }
            catch (SqlException ex)
            {
                mensaje = ex.Message;
                Console.WriteLine(ex.Message);
            }
            finally
            {
                cn.getcn.Close();
            }
            return mensaje;
        }

        public string Actualizar(Producto reg)
        {
            string mensaje = "";
            try
            {
                cn.getcn.Open();
                SqlCommand cmd = new SqlCommand("usp_actualizar_producto", cn.getcn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ID", reg.ID);
                cmd.Parameters.AddWithValue("@Nombre", reg.Nombre);
                cmd.Parameters.AddWithValue("@Descripcion", reg.Descripcion);
                cmd.Parameters.AddWithValue("@Precio", reg.Precio);
                cmd.Parameters.AddWithValue("@CantidadEnStock", reg.CantidadEnStock);
                int c = cmd.ExecuteNonQuery();
                mensaje = $"Se ha actualizado {c} producto(s)";
            }
            catch (SqlException ex)
            {
                mensaje = ex.Message;
                Console.WriteLine(ex.Message);
            }
            finally
            {
                cn.getcn.Close();
            }
            return mensaje;
        }

        public string Eliminar(int id)
        {
            string mensaje = "";
            try
            {
                cn.getcn.Open();
                SqlCommand cmd = new SqlCommand("usp_eliminar_producto", cn.getcn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ID", id);
                int c = cmd.ExecuteNonQuery();
                mensaje = $"Se ha eliminado {c} producto(s)";
            }
            catch (SqlException ex)
            {
                mensaje = ex.Message;
                Console.WriteLine(ex.Message);
            }
            finally
            {
                cn.getcn.Close();
            }
            return mensaje;
        }

        public Producto Buscar(int id)
        {
            Producto producto = null;
            try
            {
                cn.getcn.Open();
                SqlCommand cmd = new SqlCommand("usp_buscar_producto", cn.getcn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ID", id);
                SqlDataReader rd = cmd.ExecuteReader();
                if (rd.Read())
                {
                    producto = new Producto()
                    {
                        ID = rd.GetInt32(0),
                        Nombre = rd.GetString(1),
                        Descripcion = rd.GetString(2),
                        Precio = rd.GetDecimal(3),
                        CantidadEnStock = rd.GetInt32(4),
                        FechaDeCreacion = rd.GetDateTime(5)
                    };
                }
                rd.Close();
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                cn.getcn.Close();
            }
            return producto;
        }


    }
}
