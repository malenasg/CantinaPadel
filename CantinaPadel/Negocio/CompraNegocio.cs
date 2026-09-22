using CantinaPadel.Datos;
using CantinaPadel.Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace CantinaPadel.Negocio
{
    public class CompraNegocio
    {
        private CompraDatos compraDatos = new CompraDatos();

        public void RegistrarCompra(Compra nuevaCompra)
        {
            // 1. Validar que la compra tenga al menos un producto
            if (nuevaCompra.Detalles == null || nuevaCompra.Detalles.Count == 0)
            {
                throw new Exception("No se puede registrar una compra vacía. Agregue al menos un producto a la lista.");
            }

            // 2. Validar Proveedor
            if (nuevaCompra.IdProveedor <= 0)
            {
                throw new Exception("Debe seleccionar un proveedor válido.");
            }

            // 3. Validar Fecha
            if (nuevaCompra.Fecha > DateTime.Now)
            {
                throw new Exception("La fecha de la compra no puede ser superior al día de hoy.");
            }

            // 4. Validar Detalles y Matemática
            decimal sumaSubtotales = 0;

            foreach (DetalleCompra detalle in nuevaCompra.Detalles)
            {
                if (detalle.IdProducto <= 0)
                    throw new Exception("Se detectó un producto inválido en el detalle.");

                if (detalle.Cantidad <= 0)
                    throw new Exception("La cantidad de todos los productos ingresados debe ser mayor a cero.");

                if (detalle.PrecioUnitario < 0)
                    throw new Exception("El precio unitario de los productos no puede ser negativo.");

                // Recalculamos el subtotal por seguridad y lo sumamos al acumulador
                decimal subtotalReal = detalle.Cantidad * detalle.PrecioUnitario;
                sumaSubtotales += subtotalReal;
            }

            // 5. Verificar que el Total general coincida con la suma de las partes
            if (nuevaCompra.Total != sumaSubtotales)
            {
                throw new Exception("Inconsistencia de datos: El total de la compra no coincide con la suma de los subtotales de los productos.");
            }

            // Si pasa todas las validaciones exitosamente, viaja a la base de datos
            compraDatos.InsertarCompra(nuevaCompra);
        }

        public void AnularCompra(int idCompra)
        {
            // Validación mínima antes de ir a la base de datos
            if (idCompra <= 0)
            {
                throw new Exception("Por favor, seleccione una compra válida para anular.");
            }

            compraDatos.AnularCompra(idCompra);
        }

        public DataTable ObtenerCompras()
        {
            // Este pasa directo, no necesita validaciones porque solo trae la tabla
            return compraDatos.ObtenerCompras();
        }

        public DataTable ObtenerDetallesPorCompra(int idCompra)
        {
            if (idCompra <= 0) return new DataTable(); // Devuelve tabla vacía si no hay ID
            return compraDatos.ObtenerDetallesPorCompra(idCompra);
        }
    }
}
