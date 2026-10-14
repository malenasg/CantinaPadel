using System;
using System.Collections.Generic;
using System.Text;

namespace CantinaPadel.Entidades
{
    public class Horario
    {
        public int IdHorario { get; set; }
        public TimeSpan HoraInicio { get; set; }
        public TimeSpan HoraFin { get; set; }

        // Propiedad extra para mostrar lindo en los combos o grillas (ej: "18:30 - 20:00")
        public string RangoVisual
        {
            get
            {
                return $"{HoraInicio:hh\\:mm} - {HoraFin:hh\\:mm}";
            }
        }
    }
}
