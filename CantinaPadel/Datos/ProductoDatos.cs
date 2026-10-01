using System;
using System.Data;
using MySql.Data.MySqlClient;
using CantinaPadel.Entidades;

namespace CantinaPadel.Datos
{
    public class ProductoDatos
    {
        private Conexion conexion = new Conexion();

        public DataTable Actualizar()
        {
            DataTable tabla = new DataTable();
            try
            {
                using (MySqlConnection cn = conexion.CrearConexion())
                {
                    string consulta = @"SELECT 
                                        p.id_producto AS ID,
                                        p.codigo AS Código,
                                        p.nombre AS Nombre,
                                        c.nombre AS Categoría,
                                        m.nombre AS Marca,
                                        p.stock AS Stock,
                                        p.precio_venta AS 'Precio Venta',
                                        CASE WHEN p.activo = 1 THEN 'Sí' ELSE 'No' END AS Activo
                                    FROM producto p
                                    LEFT JOIN categoria c ON p.id_categoria = c.id_categoria
                                    LEFT JOIN marca m ON p.id_marca = m.id_marca";

                    MySqlDataAdapter da = new MySqlDataAdapter(consulta, cn);
                    da.Fill(tabla);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al listar productos: " + ex.Message);
            }
            return tabla;
        }

        public DataTable Buscar(string texto)
        {
            DataTable tabla = new DataTable();
            try
            {
                using (MySqlConnection cn = conexion.CrearConexion())
                {
                    string consulta = @"SELECT 
                                        p.id_producto AS ID,
                                        p.codigo AS Código,
                                        p.nombre AS Nombre,
                                        c.nombre AS Categoría,
                                        m.nombre AS Marca,
                                        p.stock AS Stock,
                                        p.precio_venta AS 'Precio Venta',
                                        CASE WHEN p.activo = 1 THEN 'Sí' ELSE 'No' END AS Activo
                                    FROM producto p
                                    LEFT JOIN categoria c ON p.id_categoria = c.id_categoria
                                    LEFT JOIN marca m ON p.id_marca = m.id_marca
                                    WHERE p.nombre LIKE @texto 
                                       OR p.codigo LIKE @texto 
                                       OR c.nombre LIKE @texto
                                       OR m.nombre LIKE @texto";

                    MySqlCommand cmd = new MySqlCommand(consulta, cn);
                    cmd.Parameters.AddWithValue("@texto", "%" + texto + "%");

                    MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                    da.Fill(tabla);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al buscar productos: " + ex.Message);
            }
            return tabla;
        }

        public Producto ObtenerPorId(int idProducto)
        {
            Producto producto = new Producto();
            try
            {
                using (MySqlConnection cn = conexion.CrearConexion())
                {
                    string consulta = @"SELECT * FROM producto WHERE id_producto = @id_producto";
                    MySqlCommand cmd = new MySqlCommand(consulta, cn);
                    cmd.Parameters.AddWithValue("@id_producto", idProducto);

                    cn.Open();
                    using (MySqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                        {
                            producto.IdProducto = Convert.ToInt32(dr["id_producto"]);
                            producto.Nombre = dr["nombre"].ToString();
                            producto.Codigo = dr["codigo"] != DBNull.Value ? dr["codigo"].ToString() : "";
                            producto.Stock = dr["stock"] != DBNull.Value ? Convert.ToInt32(dr["stock"]) : 0;
                            producto.StockMinimo = dr["stock_minimo"] != DBNull.Value ? Convert.ToInt32(dr["stock_minimo"]) : 0;
                            producto.PrecioCompra = dr["precio_compra"] != DBNull.Value ? Convert.ToDecimal(dr["precio_compra"]) : 0;
                            producto.PorcentajeGanancia = dr["porcentaje_ganancia"] != DBNull.Value ? Convert.ToDecimal(dr["porcentaje_ganancia"]) : 0;
                            producto.PrecioVenta = Convert.ToDecimal(dr["precio_venta"]);
                            producto.Activo = Convert.ToBoolean(dr["activo"]);
                            producto.IdCategoria = dr["id_categoria"] != DBNull.Value ? Convert.ToInt32(dr["id_categoria"]) : (int?)null;
                            producto.IdMarca = dr["id_marca"] != DBNull.Value ? Convert.ToInt32(dr["id_marca"]) : (int?)null;
                            producto.IdProveedor = dr["id_proveedor"] != DBNull.Value ? Convert.ToInt32(dr["id_proveedor"]) : (int?)null;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener producto: " + ex.Message);
            }
            return producto;
        }

        public DataTable ObtenerProductos()
        {
            DataTable dt = new DataTable();
            using (MySqlConnection cn = conexion.CrearConexion())
            {
                // Traemos solo los productos activos
                string query = "SELECT id_producto, nombre FROM producto WHERE activo = 1";
                MySqlCommand comando = new MySqlCommand(query, cn);
                MySqlDataAdapter adaptador = new MySqlDataAdapter(comando);

                adaptador.Fill(dt);
            }
            return dt;
        }

        // Método para traer las Marcas
        public DataTable ObtenerMarcas()
        {
            DataTable dt = new DataTable();
            using (MySqlConnection cn = conexion.CrearConexion())
            {
                // Ajustá el nombre de la tabla si en tu BD se llama diferente
                string query = "SELECT id_marca, nombre FROM marca";
                MySqlCommand comando = new MySqlCommand(query, cn);
                MySqlDataAdapter adaptador = new MySqlDataAdapter(comando);

                adaptador.Fill(dt);
            }
            return dt;
        }

        // Método para traer las Categorías
        public DataTable ObtenerCategorias()
        {
            DataTable dt = new DataTable();
            using (MySqlConnection cn = conexion.CrearConexion())
            {
                // Ajustá el nombre de la tabla si en tu BD se llama diferente
                string query = "SELECT id_categoria, nombre FROM categoria";
                MySqlCommand comando = new MySqlCommand(query, cn);
                MySqlDataAdapter adaptador = new MySqlDataAdapter(comando);

                adaptador.Fill(dt);
            }
            return dt;
        }

        public void Insertar(Producto producto)
        {
            using (MySqlConnection cn = conexion.CrearConexion())
            {
                try
                {
                    string consulta = @"INSERT INTO producto 
                                        (nombre, stock, stock_minimo, precio_compra, precio_venta, codigo, id_categoria, id_marca, id_proveedor, activo) 
                                        VALUES 
                                        (@nombre, @stock, @stock_minimo, @precio_compra, @precio_venta, @codigo, @id_categoria, @id_marca, @id_proveedor, TRUE)";

                    MySqlCommand cmd = new MySqlCommand(consulta, cn);
                    cmd.Parameters.AddWithValue("@nombre", producto.Nombre);
                    cmd.Parameters.AddWithValue("@stock", producto.Stock);
                    cmd.Parameters.AddWithValue("@stock_minimo", producto.StockMinimo);
                    cmd.Parameters.AddWithValue("@precio_compra", producto.PrecioCompra);
                    cmd.Parameters.AddWithValue("@porcentaje_ganancia", producto.PorcentajeGanancia);
                    cmd.Parameters.AddWithValue("@precio_venta", producto.PrecioVenta);
                    cmd.Parameters.AddWithValue("@codigo", string.IsNullOrEmpty(producto.Codigo) ? (object)DBNull.Value : producto.Codigo);

                    cmd.Parameters.AddWithValue("@id_categoria", producto.IdCategoria ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@id_marca", producto.IdMarca ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@id_proveedor", producto.IdProveedor ?? (object)DBNull.Value);

                    cn.Open();
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    throw new Exception("Error al insertar producto: " + ex.Message);
                }
            }
        }

        public void Modificar(Producto producto)
        {
            using (MySqlConnection cn = conexion.CrearConexion())
            {
                try
                {
                    string consulta = @"UPDATE producto SET 
                                        nombre = @nombre, 
                                        stock = @stock, 
                                        stock_minimo = @stock_minimo, 
                                        precio_compra = @precio_compra, 
                                        porcentaje_ganancia = @porcentaje_ganancia, -- ¡ACÁ ESTABA EL FALTANTE!
                                        precio_venta = @precio_venta, 
                                        codigo = @codigo, 
                                        id_categoria = @id_categoria, 
                                        id_marca = @id_marca, 
                                        id_proveedor = @id_proveedor 
                                        WHERE id_producto = @id_producto";

                    MySqlCommand cmd = new MySqlCommand(consulta, cn);
                    cmd.Parameters.AddWithValue("@id_producto", producto.IdProducto);
                    cmd.Parameters.AddWithValue("@nombre", producto.Nombre);
                    cmd.Parameters.AddWithValue("@stock", producto.Stock);
                    cmd.Parameters.AddWithValue("@stock_minimo", producto.StockMinimo);
                    cmd.Parameters.AddWithValue("@precio_compra", producto.PrecioCompra);
                    cmd.Parameters.AddWithValue("@porcentaje_ganancia", producto.PorcentajeGanancia);
                    cmd.Parameters.AddWithValue("@precio_venta", producto.PrecioVenta);
                    cmd.Parameters.AddWithValue("@codigo", string.IsNullOrEmpty(producto.Codigo) ? (object)DBNull.Value : producto.Codigo);

                    cmd.Parameters.AddWithValue("@id_categoria", producto.IdCategoria ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@id_marca", producto.IdMarca ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@id_proveedor", producto.IdProveedor ?? (object)DBNull.Value);

                    cn.Open();
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    throw new Exception("Error al modificar producto: " + ex.Message);
                }
            }
        }

        public void DarBaja(int idProducto)
        {
            using (MySqlConnection cn = conexion.CrearConexion())
            {
                try
                {
                    string consulta = @"UPDATE producto SET activo = 0 WHERE id_producto = @id_producto";
                    MySqlCommand cmd = new MySqlCommand(consulta, cn);
                    cmd.Parameters.AddWithValue("@id_producto", idProducto);

                    cn.Open();
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    throw new Exception("Error al dar de baja el producto: " + ex.Message);
                }
            }
        }
        public void DarAlta(int idProducto)
        {
            using (MySqlConnection cn = conexion.CrearConexion())
            {
                try
                {
                    string consulta = @"UPDATE producto SET activo = 1 WHERE id_producto = @id_producto";
                    MySqlCommand cmd = new MySqlCommand(consulta, cn);
                    cmd.Parameters.AddWithValue("@id_producto", idProducto);

                    cn.Open();
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    throw new Exception("Error al reactivar el producto: " + ex.Message);
                }
            }
        }

        public bool ExisteCodigo(string codigo, int idProductoExcluido = 0)
        {
            if (string.IsNullOrWhiteSpace(codigo)) return false;

            using (MySqlConnection cn = conexion.CrearConexion())
            {
                cn.Open();
                string query = @"SELECT COUNT(*) FROM producto 
                         WHERE codigo = @codigo AND id_producto != @id_producto";

                MySqlCommand cmd = new MySqlCommand(query, cn);
                cmd.Parameters.AddWithValue("@codigo", codigo);
                cmd.Parameters.AddWithValue("@id_producto", idProductoExcluido);

                int cantidad = Convert.ToInt32(cmd.ExecuteScalar());
                return cantidad > 0;
            }
        }

        public void AumentarPreciosMasivo(decimal porcentaje, string columnaFiltro, int idFiltro)
        {
            using (MySqlConnection cn = conexion.CrearConexion())
            {
                try
                {
                    // 1. Validamos que el filtro sea seguro. 
                    // (Agregué 'id_producto' para cumplir el requerimiento de aumento por unidad/producto individual)
                    if (columnaFiltro != "id_marca" &&
                        columnaFiltro != "id_categoria" &&
                        columnaFiltro != "id_proveedor" &&
                        columnaFiltro != "id_producto")
                    {
                        throw new Exception("Filtro de aumento no válido.");
                    }

                    // 2. La magia en SQL: 
                    // - Primero sube el precio de compra según el porcentaje ingresado.
                    // - Segundo, usa ese NUEVO precio de compra para recalcular el precio de venta usando el margen de ganancia de cada producto.
                    string query = $@"UPDATE producto 
                              SET precio_compra = precio_compra * (1 + (@porcentaje / 100)),
                                  precio_venta = precio_compra + ((precio_compra * porcentaje_ganancia) / 100)
                              WHERE {columnaFiltro} = @id_filtro AND activo = 1";

                    MySqlCommand cmd = new MySqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@porcentaje", porcentaje);
                    cmd.Parameters.AddWithValue("@id_filtro", idFiltro);

                    cn.Open();
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    throw new Exception("Error al actualizar precios en la base de datos: " + ex.Message);
                }
            }
        }
    }
}