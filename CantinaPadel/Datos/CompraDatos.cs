using CantinaPadel.Entidades;
using MySql.Data.MySqlClient;
using System;
using System.Data;

namespace CantinaPadel.Datos
{
    public class CompraDatos
    {
        private Conexion conexion = new Conexion();

        public void InsertarCompra(Compra nuevaCompra)
        {
            using (MySqlConnection cn = conexion.CrearConexion())
            {
                cn.Open();
                using (MySqlTransaction transaccion = cn.BeginTransaction())
                {
                    try
                    {
                        // PASO 1: Guardar la cabecera de la compra
                        string queryCompra = @"
                            INSERT INTO compra (fecha, total, estado, id_proveedor) 
                            VALUES (@fecha, @total, 'ACTIVA', @id_proveedor);
                            SELECT LAST_INSERT_ID();";

                        MySqlCommand cmdCompra = new MySqlCommand(queryCompra, cn, transaccion);
                        cmdCompra.Parameters.AddWithValue("@fecha", nuevaCompra.Fecha);
                        cmdCompra.Parameters.AddWithValue("@total", nuevaCompra.Total);
                        cmdCompra.Parameters.AddWithValue("@id_proveedor", nuevaCompra.IdProveedor);

                        int idCompraGenerado = Convert.ToInt32(cmdCompra.ExecuteScalar());

                        // PASO 2 y 3: Guardar detalles y actualizar stock + precios en cadena
                        string queryDetalle = @"
                            INSERT INTO detalle_compra (id_compra, id_producto, cantidad, precio_unitario, subtotal) 
                            VALUES (@id_compra, @id_producto, @cantidad, @precio_unitario, @subtotal)";

                        // Actualiza el stock, fija el nuevo costo y recalcula el precio de venta usando el porcentaje de ganancia
                        string queryStockYPrecios = @"
                            UPDATE producto 
                            SET stock = stock + @cantidad,
                                precio_compra = @precio_unitario,
                                precio_venta = @precio_unitario + ((@precio_unitario * porcentaje_ganancia) / 100)
                            WHERE id_producto = @id_producto";

                        foreach (DetalleCompra detalle in nuevaCompra.Detalles)
                        {
                            // 2. Guardamos el renglón del detalle
                            MySqlCommand cmdDetalle = new MySqlCommand(queryDetalle, cn, transaccion);
                            cmdDetalle.Parameters.AddWithValue("@id_compra", idCompraGenerado);
                            cmdDetalle.Parameters.AddWithValue("@id_producto", detalle.IdProducto);
                            cmdDetalle.Parameters.AddWithValue("@cantidad", detalle.Cantidad);
                            cmdDetalle.Parameters.AddWithValue("@precio_unitario", detalle.PrecioUnitario);
                            cmdDetalle.Parameters.AddWithValue("@subtotal", detalle.Subtotal);
                            cmdDetalle.ExecuteNonQuery();

                            // 3. Actualizamos stock y precios automáticamente
                            MySqlCommand cmdStockYPrecios = new MySqlCommand(queryStockYPrecios, cn, transaccion);
                            cmdStockYPrecios.Parameters.AddWithValue("@cantidad", detalle.Cantidad);
                            cmdStockYPrecios.Parameters.AddWithValue("@precio_unitario", detalle.PrecioUnitario);
                            cmdStockYPrecios.Parameters.AddWithValue("@id_producto", detalle.IdProducto);
                            cmdStockYPrecios.ExecuteNonQuery();
                        }

                        transaccion.Commit();
                    }
                    catch (Exception ex)
                    {
                        transaccion.Rollback();
                        throw new Exception("Error al procesar la compra: " + ex.Message);
                    }
                }
            }
        }

        public void AnularCompra(int idCompra)
        {
            using (MySqlConnection cn = conexion.CrearConexion())
            {
                cn.Open();
                using (MySqlTransaction transaccion = cn.BeginTransaction())
                {
                    try
                    {
                        // 1. Cambiamos el estado de la compra
                        string queryEstado = "UPDATE compra SET estado = 'ANULADA' WHERE id_compra = @id_compra AND estado = 'ACTIVA'";
                        MySqlCommand cmdEstado = new MySqlCommand(queryEstado, cn, transaccion);
                        cmdEstado.Parameters.AddWithValue("@id_compra", idCompra);
                        int filasAfectadas = cmdEstado.ExecuteNonQuery();

                        if (filasAfectadas == 0)
                        {
                            throw new Exception("La compra ya se encuentra anulada o no existe.");
                        }

                        // 2. Revertimos (restamos) el stock del detalle de esta factura
                        string queryStock = @"
                            UPDATE producto p
                            INNER JOIN detalle_compra d ON p.id_producto = d.id_producto
                            SET p.stock = p.stock - d.cantidad
                            WHERE d.id_compra = @id_compra";

                        MySqlCommand cmdStock = new MySqlCommand(queryStock, cn, transaccion);
                        cmdStock.Parameters.AddWithValue("@id_compra", idCompra);
                        cmdStock.ExecuteNonQuery();

                        transaccion.Commit();
                    }
                    catch (Exception ex)
                    {
                        transaccion.Rollback();
                        throw new Exception("Error al anular la compra: " + ex.Message);
                    }
                }
            }
        }

        public DataTable ObtenerCompras()
        {
            DataTable tabla = new DataTable();
            using (MySqlConnection cn = conexion.CrearConexion())
            {
                try
                {
                    string query = @"
    SELECT c.id_compra, c.fecha, pr.razon_social AS proveedor, c.total, c.estado 
    FROM compra c
    INNER JOIN proveedor pr ON c.id_proveedor = pr.id_proveedor
    ORDER BY c.fecha DESC";

                    MySqlDataAdapter da = new MySqlDataAdapter(query, cn);
                    da.Fill(tabla);
                }
                catch (Exception ex)
                {
                    throw new Exception("Error al cargar las compras: " + ex.Message);
                }
            }
            return tabla;
        }

        public DataTable ObtenerDetallesPorCompra(int idCompra)
        {
            DataTable tabla = new DataTable();
            using (MySqlConnection cn = conexion.CrearConexion())
            {
                try
                {
                    string query = @"
                        SELECT p.nombre AS producto, d.cantidad, d.precio_unitario, d.subtotal 
                        FROM detalle_compra d
                        INNER JOIN producto p ON d.id_producto = p.id_producto
                        WHERE d.id_compra = @id_compra";

                    MySqlCommand cmd = new MySqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@id_compra", idCompra);

                    MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                    da.Fill(tabla);
                }
                catch (Exception ex)
                {
                    throw new Exception("Error al cargar los detalles: " + ex.Message);
                }
            }
            return tabla;
        }
    }
}