using System;
using System.Collections.Generic;
using System.Text;

namespace CantinaPadel.Entidades
{
    public class Persona
    {
        // Datos básicos de la tabla "Persona"
        public int IdPersona { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Telefono { get; set; }
        public string Email { get; set; }
        public string Direccion { get; set; }
        public bool Activo { get; set; }


        // Datos específicos de la tabla "Proveedor"
        public string RazonSocial { get; set; }
        public string Cuit { get; set; }
        public string CondicionFiscal { get; set; }


        // Datos específicos de la tabla "Empleado"
        public DateTime? FechaIngreso { get; set; }
    }
}