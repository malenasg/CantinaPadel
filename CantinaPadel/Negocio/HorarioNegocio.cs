using System;
using System.Data;
using CantinaPadel.Datos;
using CantinaPadel.Entidades;

namespace CantinaPadel.Negocio
{
    public class HorarioNegocio
    {
        private HorarioDatos horarioDatos = new HorarioDatos();

        public DataTable ObtenerTodos()
        {
            return horarioDatos.ObtenerTodos();
        }

        public void Insertar(Horario horario)
        {
            // 1. Validar que la hora de fin sea mayor a la de inicio
            if (horario.HoraFin <= horario.HoraInicio)
            {
                throw new Exception("La hora de finalización debe ser posterior a la hora de inicio.");
            }

            // 2. Validar que el turno dure al menos 1 hora o 1 hora y media (como pautan los requerimientos)
            // Calculamos la diferencia de tiempo
            TimeSpan duracion = horario.HoraFin - horario.HoraInicio;

            // Si dura menos de 1 hora (60 minutos)
            if (duracion.TotalMinutes < 60)
            {
                throw new Exception("La duración mínima de un turno de pádel debe ser de 1 hora.");
            }

            // Si dura más de 2 horas (por si el administrador se equivocó al tipear)
            if (duracion.TotalMinutes > 120)
            {
                throw new Exception("La duración máxima permitida para un bloque de turno es de 2 horas.");
            }

            // Si pasa las validaciones, lo mandamos a la base de datos
            horarioDatos.Insertar(horario);
        }

        public void Eliminar(int idHorario)
        {
            if (idHorario <= 0)
            {
                throw new Exception("Debe seleccionar un bloque horario válido para eliminar.");
            }

            horarioDatos.Eliminar(idHorario);
        }
    }
}