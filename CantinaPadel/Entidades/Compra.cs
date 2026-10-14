using System;
using System.Collections.Generic;

namespace CantinaPadel.Entidades
{
    public class Compra
    {
        public int IdCompra { get; set; }
        public DateTime Fecha { get; set; }
        public decimal Total { get; set; }
        public string Estado { get; set; } = string.Empty;
        public int IdProveedor { get; set; }

        // public int IdUsuario { get; set; } // Si se desea registrar quién realizó la compra

        // Esta lista recibe todos los productos juntos desde el formulario
        public List<DetalleCompra> Detalles { get; set; }

        public Compra()
        {
            // Inicializamos la lista vacía para que no tire error de referencia nula
            Detalles = new List<DetalleCompra>();
        }
    }
}