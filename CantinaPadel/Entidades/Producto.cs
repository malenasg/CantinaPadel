using System;
using System.Collections.Generic;
using System.Text;

namespace CantinaPadel.Entidades
{
    public class Producto
    {
        public int IdProducto { get; set; }
        public string Codigo { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public int Stock { get; set; }
        public int StockMinimo { get; set; }
        public decimal PrecioCompra { get; set; }
        public decimal PrecioVenta { get; set; }
        public bool Activo { get; set; }

        // Claves Foráneas
        public int? IdCategoria { get; set; }
        public int? IdMarca { get; set; }
        public int? IdProveedor { get; set; }

        // Propiedades de ayuda para mostrar texto en lugar de números en el DataGridView
        public string CategoriaNombre { get; set; }
        public string MarcaNombre { get; set; }
        public string ProveedorNombre { get; set; }
    }
}
