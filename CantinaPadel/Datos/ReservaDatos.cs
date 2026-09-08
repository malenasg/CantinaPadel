using System;
using System.Data;
using MySql.Data.MySqlClient;
using CantinaPadel.Entidades;

namespace CantinaPadel.Datos
{
    public class ReservaDatos
    {
        private Conexion conexion = new Conexion();

        // Verifica si la cancha está libre en esa fecha y hora
        public bool VerificarDisponibilidad(int idCancha, int idHorario, DateTime fecha)
        {
            bool disponible = true;
            using (MySqlConnection cn = conexion.CrearConexion())
            {
                try
                {
                    // Buscamos si existe alguna reserva activa en esa cancha y día, 
                    // cuyos minutos se choquen con el horario que queremos insertar.
                    string consulta = @"
                SELECT COUNT(*) 
                FROM reserva r
                INNER JOIN horario h_reservado ON r.id_horario = h_reservado.id_horario
                WHERE r.id_cancha = @cancha 
                  AND r.fecha = @fecha 
                  AND r.estado != 'Cancelada'
                  AND (
                      h_reservado.hora_inicio < (SELECT hora_fin FROM horario WHERE id_horario = @horario)
                      AND 
                      h_reservado.hora_fin > (SELECT hora_inicio FROM horario WHERE id_horario = @horario)
                  )";

                    MySqlCommand cmd = new MySqlCommand(consulta, cn);
                    cmd.Parameters.AddWithValue("@cancha", idCancha);
                    cmd.Parameters.AddWithValue("@fecha", fecha.Date);
                    cmd.Parameters.AddWithValue("@horario", idHorario);

                    cn.Open();
                    int superposiciones = Convert.ToInt32(cmd.ExecuteScalar());

                    if (superposiciones > 0)
                    {
                        disponible = false; // La cancha está ocupada en esa franja horaria
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Error al verificar disponibilidad: " + ex.Message);
                }
            }
            return disponible;
        }

        // Inserta la nueva reserva
        public void Insertar(Reserva reserva)
        {
            using (MySqlConnection cn = conexion.CrearConexion())
            {
                try
                {
                    string consulta = "INSERT INTO reserva (id_cliente, id_cancha, id_horario, fecha, precio, estado, tipo_reserva) " +
                                      "VALUES (@cliente, @cancha, @horario, @fecha, @precio, 'Reservada', @tipo)";
                    MySqlCommand cmd = new MySqlCommand(consulta, cn);
                    cmd.Parameters.AddWithValue("@cliente", reserva.IdCliente);
                    cmd.Parameters.AddWithValue("@cancha", reserva.IdCancha);
                    cmd.Parameters.AddWithValue("@horario", reserva.IdHorario);
                    cmd.Parameters.AddWithValue("@fecha", reserva.Fecha.Date);
                    cmd.Parameters.AddWithValue("@precio", reserva.Precio);
                    cmd.Parameters.AddWithValue("@tipo", reserva.TipoReserva);

                    cn.Open();
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    throw new Exception("Error al guardar la reserva: " + ex.Message);
                }
            }
        }

        // Cancelación lógica de la reserva
        public void Cancelar(int idReserva)
        {
            using (MySqlConnection cn = conexion.CrearConexion())
            {
                try
                {
                    string consulta = "UPDATE reserva SET estado = 'Cancelada' WHERE id_reserva = @id";
                    MySqlCommand cmd = new MySqlCommand(consulta, cn);
                    cmd.Parameters.AddWithValue("@id", idReserva);

                    cn.Open();
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    throw new Exception("Error al cancelar la reserva: " + ex.Message);
                }
            }
        }

        // Ver las reservas realizadas
        public DataTable ObtenerReservas()
        {
            DataTable tabla = new DataTable();
            using (MySqlConnection cn = conexion.CrearConexion())
            {
                try
                {
                    // Traemos los datos cruzados para que Naiara los pueda mostrar fácil en la grilla
                    string consulta = @"SELECT r.id_reserva, r.fecha, c.nombre AS Cancha, 
                           TIME_FORMAT(h.hora_inicio, '%H:%i') AS hora_inicio, 
                           TIME_FORMAT(h.hora_fin, '%H:%i') AS hora_fin, 
                           r.estado, r.tipo_reserva 
                    FROM reserva r 
                    INNER JOIN cancha c ON r.id_cancha = c.id_cancha
                    INNER JOIN horario h ON r.id_horario = h.id_horario
                    ORDER BY r.fecha, h.hora_inicio";

                    MySqlDataAdapter da = new MySqlDataAdapter(consulta, cn);
                    da.Fill(tabla);
                }
                catch (Exception ex)
                {
                    throw new Exception("Error al cargar las reservas: " + ex.Message);
                }
            }
            return tabla;
        }
    }
}