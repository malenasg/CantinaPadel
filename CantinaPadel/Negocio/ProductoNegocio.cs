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
            return productoDatos.ObtenerProductos();
        }

        public DataTable ObtenerMarcas()
        {
            return productoDatos.ObtenerMarcas();
        }

        public DataTable ObtenerCategorias()
        {
            return productoDatos.ObtenerCategorias();
        }

        private void ValidarProducto(Producto producto)
        {
            if (string.IsNullOrWhiteSpace(producto.Nombre))
            {
                throw new Exception("El nombre del producto es obligatorio.");
            }

            // CAMBIO 1: Ahora permitimos que sea 0 (solo tira error si ponen números negativos)
            if (producto.PrecioVenta < 0)
            {
                throw new Exception("El precio de venta no puede ser negativo.");
            }

            if (producto.PrecioCompra < 0)
            {
                throw new Exception("El precio de compra no puede ser negativo.");
            }

            if (producto.Stock < 0 || producto.StockMinimo < 0)
            {
                throw new Exception("El stock no puede ser un valor negativo.");
            }

            // CAMBIO 2: Solo controlamos la pérdida de dinero si el precio de venta YA se calculó (es mayor a cero)
            if (producto.PrecioVenta > 0 && producto.PrecioVenta < producto.PrecioCompra)
            {
                throw new Exception("El precio de venta no puede ser menor al precio de compra.");
            }
        }

        private void CalcularPrecioVenta(Producto producto)
        {
            decimal ganancia = (producto.PrecioCompra * producto.PorcentajeGanancia) / 100;
            producto.PrecioVenta = producto.PrecioCompra + ganancia;
        }

        public void Insertar(Producto producto)
        {
            ValidarProducto(producto);

            if (productoDatos.ExisteCodigo(producto.Codigo))
            {
                throw new Exception("Error: El código ingresado ya pertenece a otro producto registrado.");
            }

            CalcularPrecioVenta(producto);
            productoDatos.Insertar(producto);

        }

        public void Modificar(Producto producto)
        {
            if (producto.IdProducto <= 0)
            {
                throw new Exception("Debe seleccionar un producto para modificar.");
            }

            ValidarProducto(producto);

            if (productoDatos.ExisteCodigo(producto.Codigo, producto.IdProducto))
            {
                throw new Exception("Error: El código ingresado ya pertenece a otro producto registrado.");
            }

            CalcularPrecioVenta(producto);
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

        public void DarAlta(int idProducto)
        {
            if (idProducto <= 0)
            {
                throw new Exception("Debe seleccionar un producto para reactivar.");
            }
            productoDatos.DarAlta(idProducto);
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