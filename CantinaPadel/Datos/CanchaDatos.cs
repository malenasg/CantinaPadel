using System;
using System.Data;
using MySql.Data.MySqlClient;
using CantinaPadel.Entidades;

namespace CantinaPadel.Datos
{
    public class CanchaDatos
    {
        private Conexion conexion = new Conexion();

        public DataTable ObtenerTodas()
        {
            DataTable tabla = new DataTable();
            using (MySqlConnection cn = conexion.CrearConexion())
            {
                try
                {
                    string query = "SELECT id_cancha, nombre, estado FROM cancha";
                    MySqlCommand cmd = new MySqlCommand(query, cn);
                    MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                    da.Fill(tabla);
                }
                catch (Exception ex)
                {
                    throw new Exception("Error al cargar las canchas: " + ex.Message);
                }
            }
            return tabla;
        }

        public DataTable ObtenerActivas()
        {
            DataTable tabla = new DataTable();
            using (MySqlConnection cn = conexion.CrearConexion())
            {
                try
                {
                    string query = "SELECT id_cancha, nombre FROM cancha WHERE estado = 'Activa'";
                    MySqlCommand cmd = new MySqlCommand(query, cn);
                    MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                    da.Fill(tabla);
                }
                catch (Exception ex)
                {
                    throw new Exception("Error al cargar las canchas activas: " + ex.Message);
                }
            }
            return tabla;
        }

        public void Insertar(Cancha cancha)
        {
            using (MySqlConnection cn = conexion.CrearConexion())
            {
                try
                {
                    string query = "INSERT INTO cancha (nombre, estado) VALUES (@nombre, 'Activa')";
                    MySqlCommand cmd = new MySqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@nombre", cancha.Nombre);

                    cn.Open();
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    throw new Exception("Error al guardar la cancha: " + ex.Message);
                }
            }
        }

        public void Modificar(Cancha cancha)
        {
            using (MySqlConnection cn = conexion.CrearConexion())
            {
                try
                {
                    string query = "UPDATE cancha SET nombre = @nombre WHERE id_cancha = @id_cancha";
                    MySqlCommand cmd = new MySqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@nombre", cancha.Nombre);
                    cmd.Parameters.AddWithValue("@id_cancha", cancha.IdCancha);

                    cn.Open();
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    throw new Exception("Error al modificar la cancha: " + ex.Message);
                }
            }
        }

        // Este es el método que vas a enlazar al "btnAlta" inteligente
        public void CambiarEstado(int idCancha, string nuevoEstado)
        {
            using (MySqlConnection cn = conexion.CrearConexion())
            {
                try
                {
                    string query = "UPDATE cancha SET estado = @estado WHERE id_cancha = @id_cancha";
                    MySqlCommand cmd = new MySqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@estado", nuevoEstado);
                    cmd.Parameters.AddWithValue("@id_cancha", idCancha);

                    cn.Open();
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    throw new Exception("Error al cambiar el estado de la cancha: " + ex.Message);
                }
            }
        }
    }
}