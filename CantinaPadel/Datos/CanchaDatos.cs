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
            try
            {
                using (MySqlConnection cn = conexion.CrearConexion())
                {
                    // Usamos el campo 'estado' que definiste en tu base de datos
                    string consulta = "SELECT id_cancha, nombre, estado FROM cancha WHERE estado = 'Activa'";
                    MySqlDataAdapter da = new MySqlDataAdapter(consulta, cn);
                    da.Fill(tabla);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al cargar las canchas: " + ex.Message);
            }
            return tabla;
        }

        public void Insertar(Cancha cancha)
        {
            using (MySqlConnection cn = conexion.CrearConexion())
            {
                try
                {
                    // Insertamos el nombre y el estado por defecto 'Activa'
                    string consulta = "INSERT INTO cancha (nombre, estado) VALUES (@nombre, 'Activa')";
                    MySqlCommand cmd = new MySqlCommand(consulta, cn);
                    cmd.Parameters.AddWithValue("@nombre", cancha.Nombre);

                    cn.Open();
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    throw new Exception("Error al insertar cancha: " + ex.Message);
                }
            }
        }

        public void Modificar(Cancha cancha)
        {
            using (MySqlConnection cn = conexion.CrearConexion())
            {
                try
                {
                    string consulta = "UPDATE cancha SET nombre = @nombre, estado = @estado WHERE id_cancha = @id";

                    MySqlCommand cmd = new MySqlCommand(consulta, cn);

                    cmd.Parameters.AddWithValue("@nombre", cancha.Nombre);
                    cmd.Parameters.AddWithValue("@estado", cancha.Estado);
                    cmd.Parameters.AddWithValue("@id", cancha.IdCancha);

                    cn.Open();
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    throw new Exception("Error al modificar la cancha: " + ex.Message);
                }
            }
        }

        public void Eliminar(int idCancha)
        {
            using (MySqlConnection cn = conexion.CrearConexion())
            {
                try
                {
                    string consulta = "UPDATE cancha SET estado = 'Inactiva' WHERE id_cancha = @id";
                    MySqlCommand cmd = new MySqlCommand(consulta, cn);
                    cmd.Parameters.AddWithValue("@id", idCancha);

                    cn.Open();
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    throw new Exception("Error al eliminar la cancha: " + ex.Message);
                }
            }
        }
    }
}