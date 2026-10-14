using System;
using System.Data;
using CantinaPadel.Datos;
using CantinaPadel.Entidades;

namespace CantinaPadel.Negocio
{
    public class ReservaNegocio
    {
        private ReservaDatos reservaDatos = new ReservaDatos();

        // Obtiene la grilla visual de turnos para una fecha y cancha específicas
        public DataTable ObtenerDisponibilidad(DateTime fecha, int idCancha)
        {
            if (idCancha <= 0)
            {
                throw new Exception("Debe seleccionar una cancha válida para ver su disponibilidad.");
            }

            return reservaDatos.ObtenerDisponibilidad(fecha, idCancha);
        }

        // --- MÉTODO NORMAL (Antes llamado AlquilarTurno) ---
        public void RegistrarReserva(Reserva nuevaReserva)
        {
            // 1. Validaciones básicas de datos
            if (nuevaReserva.IdCliente <= 0)
                throw new Exception("Debe seleccionar un cliente registrado para realizar el alquiler.");

            if (nuevaReserva.IdCancha <= 0)
                throw new Exception("Debe seleccionar una cancha válida.");

            if (nuevaReserva.IdHorario <= 0)
                throw new Exception("Debe seleccionar un bloque de horario válido.");

            if (nuevaReserva.Precio < 0)
                throw new Exception("El precio de la reserva no puede ser negativo.");

            if (nuevaReserva.TipoReserva != "Diaria" && nuevaReserva.TipoReserva != "Fija")
                throw new Exception("El tipo de reserva debe ser 'Diaria' o 'Fija'.");

            // 2. Validación de Fecha Lógica (Bloquea días anteriores)
            if (nuevaReserva.Fecha.Date < DateTime.Now.Date)
            {
                throw new Exception("No se pueden registrar alquileres de canchas para fechas pasadas.");
            }

            // 3. Validación estricta de HORA para el día de HOY
            if (nuevaReserva.Fecha.Date == DateTime.Now.Date)
            {
                // Buscamos la lista de horarios para saber a qué hora empieza el turno elegido
                HorarioDatos horarioDatos = new HorarioDatos();
                DataTable tablaHorarios = horarioDatos.ObtenerTodos();

                TimeSpan horaInicioTurno = new TimeSpan(0, 0, 0); // Valor por defecto

                foreach (DataRow fila in tablaHorarios.Rows)
                {
                    if (Convert.ToInt32(fila["id_horario"]) == nuevaReserva.IdHorario)
                    {
                        horaInicioTurno = (TimeSpan)fila["hora_inicio"];
                        break;
                    }
                }

                // Si la hora de inicio del turno ya pasó en el día de hoy, lo bloqueamos
                if (horaInicioTurno < DateTime.Now.TimeOfDay)
                {
                    throw new Exception("No puede registrar una reserva en un horario que ya pasó en el día de hoy.");
                }
            }

            // 4. ¡EL ESCUDO! Prevención de dobles reservas (Overbooking)
            if (ExisteReservaActiva(nuevaReserva.Fecha, nuevaReserva.IdCancha, nuevaReserva.IdHorario))
            {
                throw new Exception("Este horario ya se encuentra ocupado o finalizado para esta cancha en la fecha seleccionada.");
            }

            // 5. Si pasa todos los controles, se envía a la base de datos
            reservaDatos.Insertar(nuevaReserva);
        }

        // --- NUEVO MÉTODO PARA TURNOS FIJOS ---
        public void RegistrarTurnoFijo(Reserva nuevaReserva, int cantidadSemanas)
        {
            if (cantidadSemanas < 2)
                throw new Exception("Para un turno fijo, la cantidad de semanas debe ser al menos 2.");

            if (nuevaReserva.Fecha.Date < DateTime.Now.Date)
                throw new Exception("No se pueden registrar alquileres para fechas pasadas.");

            DateTime fechaIteracion = nuevaReserva.Fecha.Date;

            // PASO 1: Verificamos que TODAS las fechas futuras estén libres antes de guardar nada
            for (int i = 0; i < cantidadSemanas; i++)
            {
                if (ExisteReservaActiva(fechaIteracion, nuevaReserva.IdCancha, nuevaReserva.IdHorario))
                {
                    throw new Exception($"No se puede registrar el turno fijo. La fecha {fechaIteracion.ToShortDateString()} ya está ocupada.");
                }
                fechaIteracion = fechaIteracion.AddDays(7); // Avanzamos una semana
            }

            // PASO 2: Como están todas libres, procedemos a guardarlas en la base de datos
            fechaIteracion = nuevaReserva.Fecha.Date; // Volvemos a la fecha inicial

            for (int i = 0; i < cantidadSemanas; i++)
            {
                Reserva reservaSemana = new Reserva
                {
                    IdCliente = nuevaReserva.IdCliente,
                    IdCancha = nuevaReserva.IdCancha,
                    IdHorario = nuevaReserva.IdHorario,
                    Precio = nuevaReserva.Precio,
                    Fecha = fechaIteracion,
                    TipoReserva = "Fija"
                };

                reservaDatos.Insertar(reservaSemana);
                fechaIteracion = fechaIteracion.AddDays(7); // Avanzamos una semana
            }
        }

        // Renombrado de CancelarTurno a CancelarReserva
        public void CancelarReserva(int idReserva)
        {
            if (idReserva <= 0)
            {
                throw new Exception("Debe seleccionar un turno válido para cancelar.");
            }

            reservaDatos.Cancelar(idReserva);
        }

        public DataTable BuscarPorCliente(string textoBusqueda)
        {
            if (string.IsNullOrWhiteSpace(textoBusqueda))
            {
                throw new Exception("Debe ingresar un nombre o apellido para buscar.");
            }
            return reservaDatos.ObtenerReservasPorCliente(textoBusqueda);
        }

        public void FinalizarTurno(int idReserva)
        {
            if (idReserva <= 0)
            {
                throw new Exception("Debe seleccionar un turno válido para finalizar/cobrar.");
            }

            reservaDatos.FinalizarTurno(idReserva);
        }

        // --- Método Auxiliar Privado para validar el solapamiento ---
        private bool ExisteReservaActiva(DateTime fecha, int idCancha, int idHorario)
        {
            DataTable disponibilidad = reservaDatos.ObtenerDisponibilidad(fecha, idCancha);

            foreach (DataRow fila in disponibilidad.Rows)
            {
                int idHorarioFila = Convert.ToInt32(fila["id_horario"]);
                string estadoFila = fila["estado_turno"].ToString();

                if (idHorarioFila == idHorario)
                {
                    if (estadoFila != "Libre")
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public DataTable ObtenerReservas()
        {
            return reservaDatos.ObtenerTodasLasReservas();
        }
    }
}