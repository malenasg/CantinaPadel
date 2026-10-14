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
            using (MySqlConnection cn = conexion.CrearConexion())
            {
                try
                {
                    // Formateamos la hora directo en SQL para que la UI la reciba lista para mostrar
                    string query = @"
                        SELECT id_horario, 
                               hora_inicio, 
                               hora_fin,
                               CONCAT(TIME_FORMAT(hora_inicio, '%H:%i'), ' - ', TIME_FORMAT(hora_fin, '%H:%i')) AS rango_visual
                        FROM horario 
                        ORDER BY hora_inicio";

                    MySqlCommand cmd = new MySqlCommand(query, cn);
                    MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                    da.Fill(tabla);
                }
                catch (Exception ex)
                {
                    throw new Exception("Error al cargar los horarios: " + ex.Message);
                }
            }
            return tabla;
        }

        public void Insertar(Horario horario)
        {
            using (MySqlConnection cn = conexion.CrearConexion())
            {
                try
                {
                    string query = "INSERT INTO horario (hora_inicio, hora_fin) VALUES (@hora_inicio, @hora_fin)";
                    MySqlCommand cmd = new MySqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@hora_inicio", horario.HoraInicio);
                    cmd.Parameters.AddWithValue("@hora_fin", horario.HoraFin);

                    cn.Open();
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    throw new Exception("Error al guardar el horario: " + ex.Message);
                }
            }
        }

        public void Eliminar(int idHorario)
        {
            using (MySqlConnection cn = conexion.CrearConexion())
            {
                try
                {
                    string query = "DELETE FROM horario WHERE id_horario = @id_horario";
                    MySqlCommand cmd = new MySqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@id_horario", idHorario);

                    cn.Open();
                    cmd.ExecuteNonQuery();
                }
                catch (MySqlException sqlEx)
                {
                    // Si tira error 1451 es porque ese horario ya está usado en una reserva
                    if (sqlEx.Number == 1451)
                        throw new Exception("No se puede eliminar este horario porque ya existen reservas asociadas al mismo.");
                    else
                        throw new Exception("Error de base de datos al eliminar el horario: " + sqlEx.Message);
                }
                catch (Exception ex)
                {
                    throw new Exception("Error al eliminar el horario: " + ex.Message);
                }
            }
        }
    }
}