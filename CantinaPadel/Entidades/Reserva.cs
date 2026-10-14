using System;
using System.Collections.Generic;
using System.Text;

namespace CantinaPadel.Entidades
{
    public class Reserva
    {
        public int IdReserva { get; set; }
        public int IdCliente { get; set; }
        public int IdCancha { get; set; }
        public int IdHorario { get; set; }
        public DateTime Fecha { get; set; }
        public decimal Precio { get; set; }
        public string Estado { get; set; } 
        public string TipoReserva { get; set; }

        public string NombreCliente { get; set; }
        public string NombreCancha { get; set; }
        public string RangoHorario { get; set; }
    }
}
