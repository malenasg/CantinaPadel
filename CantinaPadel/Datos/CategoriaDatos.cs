using System;
using System.Data;
using MySql.Data.MySqlClient;
using CantinaPadel.Entidades;

namespace CantinaPadel.Datos
{
    public class CategoriaDatos
    {
        private Conexion conexion = new Conexion();

        public DataTable ObtenerTodas()
        {
            DataTable tabla = new DataTable();
            try
            {
                using (MySqlConnection cn = conexion.CrearConexion())
                {
                    string consulta = "SELECT id_categoria, nombre FROM categoria WHERE activo = TRUE";
                    MySqlDataAdapter da = new MySqlDataAdapter(consulta, cn);
                    da.Fill(tabla);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al cargar las categorías: " + ex.Message);
            }
            return tabla;
        }

        public void Insertar(Categoria categoria)
        {
            using (MySqlConnection cn = conexion.CrearConexion())
            {
                try
                {
                    string consulta = "INSERT INTO categoria (nombre, activo) VALUES (@nombre, TRUE)";
                    MySqlCommand cmd = new MySqlCommand(consulta, cn);
                    cmd.Parameters.AddWithValue("@nombre", categoria.Nombre);

                    cn.Open();
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    throw new Exception("Error al insertar categoría: " + ex.Message);
                }
            }
        }

        // NUEVO MÉTODO: Evita cargar categorías repetidas
        public bool ExisteNombre(string nombre, int idCategoriaExcluida = 0)
        {
            if (string.IsNullOrWhiteSpace(nombre)) return false;

            using (MySqlConnection cn = conexion.CrearConexion())
            {
                cn.Open();
                string query = @"SELECT COUNT(*) FROM categoria 
                                 WHERE nombre = @nombre AND id_categoria != @id_categoria";

                MySqlCommand cmd = new MySqlCommand(query, cn);
                cmd.Parameters.AddWithValue("@nombre", nombre);
                cmd.Parameters.AddWithValue("@id_categoria", idCategoriaExcluida);

                int cantidad = Convert.ToInt32(cmd.ExecuteScalar());
                return cantidad > 0;
            }
        }
    }
}