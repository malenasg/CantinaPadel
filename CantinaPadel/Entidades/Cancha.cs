using System;
using System.Collections.Generic;
using System.Text;

namespace CantinaPadel.Entidades
{
    public class Cancha
    {
        public int IdCancha { get; set; }
        public string Nombre { get; set; }
        public string Estado { get; set; } // "Activa" o "Inactiva"
    }
}
