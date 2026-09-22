using System;
using System.Data;
using CantinaPadel.Datos;
using CantinaPadel.Entidades;

namespace CantinaPadel.Negocio
{
    public class ProductoNegocio
    {
        private ProductoDatos productoDatos = new ProductoDatos();

        public DataTable Actualizar()
        {
            return productoDatos.Actualizar();
        }

        public DataTable Buscar(string texto)
        {
            if (string.IsNullOrWhiteSpace(texto))
            {
                return productoDatos.Actualizar();
            }
            return productoDatos.Buscar(texto.Trim());
        }

        public Producto ObtenerPorId(int idProducto)
        {
            if (idProducto <= 0)
            {
                throw new Exception("Debe seleccionar un producto válido.");
            }
            return productoDatos.ObtenerPorId(idProducto);
        }

        public DataTable ObtenerProductos()
        {
            ProductoDatos datos = new ProductoDatos();
            return datos.ObtenerProductos();
        }

        public DataTable ObtenerMarcas()
        {
            ProductoDatos datos = new ProductoDatos();
            return datos.ObtenerMarcas();
        }

        public DataTable ObtenerCategorias()
        {
            ProductoDatos datos = new ProductoDatos();
            return datos.ObtenerCategorias();
        }

        private void ValidarProducto(Producto producto)
        {
            if (string.IsNullOrWhiteSpace(producto.Nombre))
            {
                throw new Exception("El nombre del producto es obligatorio.");
            }

            if (producto.PrecioVenta <= 0)
            {
                throw new Exception("El precio de venta debe ser mayor a cero.");
            }

            if (producto.PrecioCompra < 0)
            {
                throw new Exception("El precio de compra no puede ser negativo.");
            }

            if (producto.Stock < 0 || producto.StockMinimo < 0)
            {
                throw new Exception("El stock no puede ser un valor negativo.");
            }

            // Regla de negocio de control (opcional, evita pérdidas de dinero)
            if (producto.PrecioVenta < producto.PrecioCompra)
            {
                throw new Exception("El precio de venta no puede ser menor al precio de compra.");
            }
        }

        public void Insertar(Producto producto)
        {
            ValidarProducto(producto);
            productoDatos.Insertar(producto);
        }

        public void Modificar(Producto producto)
        {
            if (producto.IdProducto <= 0)
            {
                throw new Exception("Debe seleccionar un producto para modificar.");
            }

            ValidarProducto(producto);
            productoDatos.Modificar(producto);
        }

        public void DarBaja(int idProducto)
        {
            if (idProducto <= 0)
            {
                throw new Exception("Debe seleccionar un producto para dar de baja.");
            }

            productoDatos.DarBaja(idProducto);
        }

        public void AumentarPreciosMasivo(decimal porcentaje, string columnaFiltro, int idFiltro)
        {
            if (porcentaje <= 0)
            {
                throw new Exception("El porcentaje de aumento debe ser mayor a cero.");
            }

            if (idFiltro <= 0)
            {
                throw new Exception("Debe seleccionar a qué categoría, marca o proveedor aplicarle el aumento.");
            }

            productoDatos.AumentarPreciosMasivo(porcentaje, columnaFiltro, idFiltro);
        }
    }
}