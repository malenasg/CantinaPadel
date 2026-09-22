using CantinaPadel.Entidades;
using MySql.Data.MySqlClient;
using System;
using System.Data;

namespace CantinaPadel.Datos
{
    public class CompraDatos
    {
        // Asumiendo que tenés tu clase de conexión como en los sprints anteriores
        private Conexion conexion = new Conexion();

        public void InsertarCompra(Compra nuevaCompra)
        {
            using (MySqlConnection cn = conexion.CrearConexion())
            {
                cn.Open();
                // Iniciamos la transacción: A partir de acá, MySQL no guarda nada de forma definitiva
                // hasta que le demos la orden de "Commit".
                using (MySqlTransaction transaccion = cn.BeginTransaction())
                {
                    try
                    {
                        // PASO 1: Guardar la cabecera de la compra
                        string queryCompra = @"
                            INSERT INTO compra (fecha, total, estado, id_proveedor) 
                            VALUES (@fecha, @total, 'ACTIVA', @id_proveedor);
                            SELECT LAST_INSERT_ID();"; // Pedimos el ID que MySQL acaba de generar

                        MySqlCommand cmdCompra = new MySqlCommand(queryCompra, cn, transaccion);
                        cmdCompra.Parameters.AddWithValue("@fecha", nuevaCompra.Fecha);
                        cmdCompra.Parameters.AddWithValue("@total", nuevaCompra.Total);
                        cmdCompra.Parameters.AddWithValue("@id_proveedor", nuevaCompra.IdProveedor);

                        // Ejecutamos y guardamos el ID de la compra para usarlo en los detalles
                        int idCompraGenerado = Convert.ToInt32(cmdCompra.ExecuteScalar());

                        // PASO 2 y 3: Recorrer la lista de productos, guardar el detalle y subir el stock
                        string queryDetalle = @"
                            INSERT INTO detalle_compra (id_compra, id_producto, cantidad, precio_unitario, subtotal) 
                            VALUES (@id_compra, @id_producto, @cantidad, @precio_unitario, @subtotal)";

                        // Asumo que la columna en tu tabla producto se llama "stock"
                        string queryStock = "UPDATE producto SET stock = stock + @cantidad WHERE id_producto = @id_producto";

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

                            // 3. Le sumamos la cantidad al stock del producto
                            MySqlCommand cmdStock = new MySqlCommand(queryStock, cn, transaccion);
                            cmdStock.Parameters.AddWithValue("@cantidad", detalle.Cantidad);
                            cmdStock.Parameters.AddWithValue("@id_producto", detalle.IdProducto);
                            cmdStock.ExecuteNonQuery();
                        }

                        // Si el código llega hasta acá sin errores, confirmamos todos los cambios juntos.
                        transaccion.Commit();
                    }
                    catch (Exception ex)
                    {
                        // Si algo falla (ej. error de red, base de datos caída), deshacemos absolutamente todo
                        // para que no quede una factura guardada sin sus detalles ni stock fantasma.
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
                        // 1. Cambiamos el estado (Verificando que no esté anulada previamente)
                        string queryEstado = "UPDATE compra SET estado = 'ANULADA' WHERE id_compra = @id_compra AND estado = 'ACTIVA'";
                        MySqlCommand cmdEstado = new MySqlCommand(queryEstado, cn, transaccion);
                        cmdEstado.Parameters.AddWithValue("@id_compra", idCompra);
                        int filasAfectadas = cmdEstado.ExecuteNonQuery();

                        if (filasAfectadas == 0)
                        {
                            throw new Exception("La compra ya se encuentra anulada o no existe.");
                        }

                        // 2. Restamos el stock cruzando la tabla de productos con el detalle de esta factura específica
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

        // Llena la grilla principal de facturas
        public DataTable ObtenerCompras()
        {
            DataTable tabla = new DataTable();
            using (MySqlConnection cn = conexion.CrearConexion())
            {
                try
                {
                    string query = @"
                SELECT c.id_compra, c.fecha, p.nombre AS proveedor, c.total, c.estado 
                FROM compra c
                INNER JOIN persona p ON c.id_proveedor = p.id_persona
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

        // Llena la grilla secundaria cuando se selecciona una factura
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