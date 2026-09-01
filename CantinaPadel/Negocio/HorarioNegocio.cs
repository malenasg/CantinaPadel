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
            ValidarTiempos(horario);
            horarioDatos.Insertar(horario);
        }

        public void Modificar(Horario horario)
        {
            ValidarTiempos(horario);
            horarioDatos.Modificar(horario);
        }

        public void Eliminar(int idHorario)
        {
            horarioDatos.Eliminar(idHorario);
        }

        // Validación de negocio para evitar incongruencias
        private void ValidarTiempos(Horario horario)
        {
            if (horario.HoraInicio >= horario.HoraFin)
            {
                throw new Exception("La hora de inicio debe ser estrictamente menor a la hora de fin.");
            }
        }
    }
}