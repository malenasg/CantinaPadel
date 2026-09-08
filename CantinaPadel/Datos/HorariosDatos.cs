using System;
using System.Data;
using MySql.Data.MySqlClient;
using CantinaPadel.Entidades;

namespace CantinaPadel.Datos
{
    public class HorarioDatos
    {
        private Conexion conexion = new Conexion();

        public DataTable ObtenerTodos()
        {
            DataTable tabla = new DataTable();
            try
            {
                using (MySqlConnection cn = conexion.CrearConexion())
                {
                    // Ordenamos por hora para que en la grilla se vean ordenaditos de mañana a noche
                    string consulta = "SELECT id_horario, TIME_FORMAT(hora_inicio, '%H:%i') AS hora_inicio, TIME_FORMAT(hora_fin, '%H:%i') AS hora_fin FROM horario";
                    MySqlDataAdapter da = new MySqlDataAdapter(consulta, cn);
                    da.Fill(tabla);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al cargar horarios: " + ex.Message);
            }
            return tabla;
        }

        public void Insertar(Horario horario)
        {
            using (MySqlConnection cn = conexion.CrearConexion())
            {
                try
                {
                    string consulta = "INSERT INTO horario (hora_inicio, hora_fin) VALUES (@inicio, @fin)";
                    MySqlCommand cmd = new MySqlCommand(consulta, cn);
                    cmd.Parameters.AddWithValue("@inicio", horario.HoraInicio);
                    cmd.Parameters.AddWithValue("@fin", horario.HoraFin);

                    cn.Open();
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    throw new Exception("Error al insertar horario: " + ex.Message);
                }
            }
        }

        public void Modificar(Horario horario)
        {
            using (MySqlConnection cn = conexion.CrearConexion())
            {
                try
                {
                    string consulta = "UPDATE horario SET hora_inicio = @inicio, hora_fin = @fin WHERE id_horario = @id";
                    MySqlCommand cmd = new MySqlCommand(consulta, cn);
                    cmd.Parameters.AddWithValue("@inicio", horario.HoraInicio);
                    cmd.Parameters.AddWithValue("@fin", horario.HoraFin);
                    cmd.Parameters.AddWithValue("@id", horario.IdHorario);

                    cn.Open();
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    throw new Exception("Error al modificar horario: " + ex.Message);
                }
            }
        }

        public void Eliminar(int idHorario)
        {
            using (MySqlConnection cn = conexion.CrearConexion())
            {
                try
                {
                    string consulta = "DELETE FROM horario WHERE id_horario = @id";
                    MySqlCommand cmd = new MySqlCommand(consulta, cn);
                    cmd.Parameters.AddWithValue("@id", idHorario);

                    cn.Open();
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    throw new Exception("Error al eliminar horario: " + ex.Message);
                }
            }
        }
    }
}