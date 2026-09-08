using CantinaPadel.Datos;
using CantinaPadel.Entidades;
using System;
using System.Data;

namespace CantinaPadel.Negocio
{
    public class ReservaNegocio
    {
        private ReservaDatos reservaDatos = new ReservaDatos();

        public void RegistrarReserva(Reserva reserva)
        {
            // Regla 1: Verificar que la cancha no esté ocupada
            bool disponible = reservaDatos.VerificarDisponibilidad(reserva.IdCancha, reserva.IdHorario, reserva.Fecha);

            if (!disponible)
            {
                throw new Exception("La cancha ya se encuentra reservada en ese horario y fecha.");
            }

            // Si está libre, la mandamos a guardar
            reservaDatos.Insertar(reserva);
        }

        public void CancelarReserva(int idReserva)
        {
            reservaDatos.Cancelar(idReserva);
        }

        public DataTable ObtenerReservas()
        {
            return reservaDatos.ObtenerReservas();
        }

        public void RegistrarTurnoFijo(Reserva reservaBase, int cantidadSemanas)
        {
            // Primero, verificamos que TODOS los días requeridos estén libres antes de guardar nada
            for (int i = 0; i < cantidadSemanas; i++)
            {
                DateTime fechaEvaluada = reservaBase.Fecha.AddDays(i * 7);
                bool disponible = reservaDatos.VerificarDisponibilidad(reservaBase.IdCancha, reservaBase.IdHorario, fechaEvaluada);

                if (!disponible)
                {
                    throw new Exception($"El turno fijo no se puede crear porque la cancha ya está ocupada el día {fechaEvaluada.ToShortDateString()}.");
                }
            }

            // Si pasó la verificación y todos los días están libres, los guardamos uno por uno
            for (int i = 0; i < cantidadSemanas; i++)
            {
                Reserva nuevaReserva = new Reserva
                {
                    IdCliente = reservaBase.IdCliente,
                    IdCancha = reservaBase.IdCancha,
                    IdHorario = reservaBase.IdHorario,
                    Fecha = reservaBase.Fecha.AddDays(i * 7),
                    Precio = reservaBase.Precio,
                    TipoReserva = "Fija"
                };

                reservaDatos.Insertar(nuevaReserva);
            }
        }
    }
}