using System;
using System.Data;
using MySql.Data.MySqlClient;
using CantinaPadel.Entidades;

namespace CantinaPadel.Datos
{
    public class ReservaDatos
    {
        private Conexion conexion = new Conexion();

        // 1. EL BUSCADOR DE DISPONIBILIDAD (¡La consulta estrella para Naiara!)
        public DataTable ObtenerDisponibilidad(DateTime fecha, int idCancha)
        {
            DataTable tabla = new DataTable();
            using (MySqlConnection cn = conexion.CrearConexion())
            {
                try
                {
                    // Esta consulta trae TODOS los horarios y cruza con las reservas de ese día y esa cancha.
                    // Si r.id_reserva es NULL o el estado es 'Cancelada', el horario está "Libre".
                    string query = @"
                        SELECT 
                            h.id_horario,
                            CONCAT(TIME_FORMAT(h.hora_inicio, '%H:%i'), ' - ', TIME_FORMAT(h.hora_fin, '%H:%i')) AS horario,
                            IFNULL(r.id_reserva, 0) AS id_reserva,
                            CASE 
                                WHEN r.id_reserva IS NULL OR r.estado = 'Cancelada' THEN 'Libre'
                                ELSE r.estado 
                            END AS estado_turno,
                            IFNULL(p.nombre, '') AS cliente_nombre,
                            IFNULL(p.apellido, '') AS cliente_apellido,
                            IFNULL(r.tipo_reserva, '') AS modalidad,
                            IFNULL(r.precio, 0) AS precio
                        FROM horario h
                        LEFT JOIN reserva r ON h.id_horario = r.id_horario 
                                            AND r.fecha = @fecha 
                                            AND r.id_cancha = @id_cancha
                                            AND r.estado != 'Cancelada'
                        LEFT JOIN persona p ON r.id_cliente = p.id_persona
                        ORDER BY h.hora_inicio";

                    MySqlCommand cmd = new MySqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@fecha", fecha.Date); // Solo la fecha, sin la hora
                    cmd.Parameters.AddWithValue("@id_cancha", idCancha);

                    MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                    da.Fill(tabla);
                }
                catch (Exception ex)
                {
                    throw new Exception("Error al consultar la disponibilidad: " + ex.Message);
                }
            }
            return tabla;
        }
        // BUSCADOR DE HISTORIAL POR CLIENTE
        public DataTable ObtenerReservasPorCliente(string textoBusqueda)
        {
            DataTable tabla = new DataTable();
            using (MySqlConnection cn = conexion.CrearConexion())
            {
                try
                {
                    // Traemos solo las reservas reales y cruzamos los datos para que se lea lindo
                    string query = @"
                SELECT 
                    r.id_reserva,
                    r.fecha AS Fecha,
                    CONCAT(TIME_FORMAT(h.hora_inicio, '%H:%i'), ' - ', TIME_FORMAT(h.hora_fin, '%H:%i')) AS Horario,
                    c.nombre AS Cancha,
                    CONCAT(p.nombre, ' ', p.apellido) AS Cliente,
                    r.estado AS Estado,
                    r.tipo_reserva AS Modalidad
                FROM reserva r
                INNER JOIN persona p ON r.id_cliente = p.id_persona
                INNER JOIN cancha c ON r.id_cancha = c.id_cancha
                INNER JOIN horario h ON r.id_horario = h.id_horario
                WHERE p.nombre LIKE @busqueda OR p.apellido LIKE @busqueda
                ORDER BY r.fecha DESC, h.hora_inicio DESC";

                    MySqlCommand cmd = new MySqlCommand(query, cn);
                    // El % permite buscar coincidencias parciales (ej: si busca "Ju", trae "Juan" y "Julieta")
                    cmd.Parameters.AddWithValue("@busqueda", "%" + textoBusqueda + "%");

                    MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                    da.Fill(tabla);
                }
                catch (Exception ex)
                {
                    throw new Exception("Error al buscar el historial del cliente: " + ex.Message);
                }
            }
            return tabla;
        }


        // 2. INSERTAR UNA RESERVA (Alquilar la cancha)
        public void Insertar(Reserva reserva)
        {
            using (MySqlConnection cn = conexion.CrearConexion())
            {
                try
                {
                    string query = @"
                        INSERT INTO reserva (id_cliente, id_cancha, id_horario, fecha, precio, estado, tipo_reserva) 
                        VALUES (@id_cliente, @id_cancha, @id_horario, @fecha, @precio, 'Reservada', @tipo_reserva)";

                    MySqlCommand cmd = new MySqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@id_cliente", reserva.IdCliente);
                    cmd.Parameters.AddWithValue("@id_cancha", reserva.IdCancha);
                    cmd.Parameters.AddWithValue("@id_horario", reserva.IdHorario);
                    cmd.Parameters.AddWithValue("@fecha", reserva.Fecha.Date);
                    cmd.Parameters.AddWithValue("@precio", reserva.Precio);
                    cmd.Parameters.AddWithValue("@tipo_reserva", reserva.TipoReserva);

                    cn.Open();
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    throw new Exception("Error al registrar la reserva: " + ex.Message);
                }
            }
        }

        public DataTable ObtenerTodasLasReservas()
        {
            DataTable tabla = new DataTable();
            using (MySqlConnection cn = conexion.CrearConexion())
            {
                try
                {
                    string query = @"
                SELECT 
                    r.id_reserva,
                    r.fecha,
                    CONCAT(TIME_FORMAT(h.hora_inicio, '%H:%i'), ' - ', TIME_FORMAT(h.hora_fin, '%H:%i')) AS horario,
                    c.nombre AS cancha,
                    CONCAT(p.nombre, ' ', p.apellido) AS cliente,
                    r.precio,
                    r.estado AS estado_turno,
                    r.tipo_reserva AS modalidad
                FROM reserva r
                INNER JOIN persona p ON r.id_cliente = p.id_persona
                INNER JOIN cancha c ON r.id_cancha = c.id_cancha
                INNER JOIN horario h ON r.id_horario = h.id_horario
                ORDER BY r.fecha DESC, h.hora_inicio ASC";

                    MySqlCommand cmd = new MySqlCommand(query, cn);
                    MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                    da.Fill(tabla);
                }
                catch (Exception ex)
                {
                    throw new Exception("Error al obtener el listado general de reservas: " + ex.Message);
                }
            }
            return tabla;
        }

        // 3. CANCELAR UNA RESERVA (Libera la cancha al instante)
        public void Cancelar(int idReserva)
        {
            using (MySqlConnection cn = conexion.CrearConexion())
            {
                try
                {
                    // Solo cambiamos el estado a 'Cancelada'. 
                    // No la borramos para que quede un registro, pero el ObtenerDisponibilidad() la va a ver como Libre.
                    string query = "UPDATE reserva SET estado = 'Cancelada' WHERE id_reserva = @id_reserva";

                    MySqlCommand cmd = new MySqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@id_reserva", idReserva);

                    cn.Open();
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    throw new Exception("Error al cancelar el turno: " + ex.Message);
                }
            }
        }

        // 4. FINALIZAR / COBRAR UN TURNO (Para que el cajero rinda la caja)
        public void FinalizarTurno(int idReserva)
        {
            using (MySqlConnection cn = conexion.CrearConexion())
            {
                try
                {
                    string query = "UPDATE reserva SET estado = 'Finalizada' WHERE id_reserva = @id_reserva AND estado = 'Reservada'";

                    MySqlCommand cmd = new MySqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@id_reserva", idReserva);

                    cn.Open();
                    int filasAfectadas = cmd.ExecuteNonQuery();

                    if (filasAfectadas == 0)
                    {
                        throw new Exception("El turno no pudo ser finalizado. Verifique que no esté cancelado previamente.");
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Error al finalizar el turno: " + ex.Message);
                }
            }
        }
    }
}