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
                            producto.Descripcion = dr["descripcion"] != DBNull.Value ? dr["descripcion"].ToString() : "";
                            producto.Stock = dr["stock"] != DBNull.Value ? Convert.ToInt32(dr["stock"]) : 0;
                            producto.StockMinimo = dr["stock_minimo"] != DBNull.Value ? Convert.ToInt32(dr["stock_minimo"]) : 0;
                            producto.PrecioCompra = dr["precio_compra"] != DBNull.Value ? Convert.ToDecimal(dr["precio_compra"]) : 0;
                            producto.PrecioVenta = Convert.ToDecimal(dr["precio_venta"]);

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
            using (MySqlConnection conexion = new MySqlConnection(Conexion.cadena))
            {
                // Traemos solo los productos activos
                string query = "SELECT id_producto, nombre FROM productos WHERE estado = 1";
                MySqlCommand comando = new MySqlCommand(query, conexion);
                MySqlDataAdapter adaptador = new MySqlDataAdapter(comando);

                adaptador.Fill(dt);
            }
            return dt;
        }

        // Método para traer las Marcas
        public DataTable ObtenerMarcas()
        {
            DataTable dt = new DataTable();
            using (MySqlConnection conexion = new MySqlConnection(Conexion.cadena))
            {
                // Ajustá el nombre de la tabla si en tu BD se llama diferente
                string query = "SELECT id_marca, nombre FROM marcas";
                MySqlCommand comando = new MySqlCommand(query, conexion);
                MySqlDataAdapter adaptador = new MySqlDataAdapter(comando);

                adaptador.Fill(dt);
            }
            return dt;
        }

        // Método para traer las Categorías
        public DataTable ObtenerCategorias()
        {
            DataTable dt = new DataTable();
            using (MySqlConnection conexion = new MySqlConnection(Conexion.cadena))
            {
                // Ajustá el nombre de la tabla si en tu BD se llama diferente
                string query = "SELECT id_categoria, nombre FROM categorias";
                MySqlCommand comando = new MySqlCommand(query, conexion);
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
                                        (nombre, descripcion, stock, stock_minimo, precio_compra, precio_venta, codigo, id_categoria, id_marca, id_proveedor, activo) 
                                        VALUES 
                                        (@nombre, @descripcion, @stock, @stock_minimo, @precio_compra, @precio_venta, @codigo, @id_categoria, @id_marca, @id_proveedor, TRUE)";

                    MySqlCommand cmd = new MySqlCommand(consulta, cn);
                    cmd.Parameters.AddWithValue("@nombre", producto.Nombre);
                    cmd.Parameters.AddWithValue("@descripcion", string.IsNullOrEmpty(producto.Descripcion) ? (object)DBNull.Value : producto.Descripcion);
                    cmd.Parameters.AddWithValue("@stock", producto.Stock);
                    cmd.Parameters.AddWithValue("@stock_minimo", producto.StockMinimo);
                    cmd.Parameters.AddWithValue("@precio_compra", producto.PrecioCompra);
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
                                        descripcion = @descripcion, 
                                        stock = @stock, 
                                        stock_minimo = @stock_minimo, 
                                        precio_compra = @precio_compra, 
                                        precio_venta = @precio_venta, 
                                        codigo = @codigo, 
                                        id_categoria = @id_categoria, 
                                        id_marca = @id_marca, 
                                        id_proveedor = @id_proveedor 
                                        WHERE id_producto = @id_producto";

                    MySqlCommand cmd = new MySqlCommand(consulta, cn);
                    cmd.Parameters.AddWithValue("@id_producto", producto.IdProducto);
                    cmd.Parameters.AddWithValue("@nombre", producto.Nombre);
                    cmd.Parameters.AddWithValue("@descripcion", string.IsNullOrEmpty(producto.Descripcion) ? (object)DBNull.Value : producto.Descripcion);
                    cmd.Parameters.AddWithValue("@stock", producto.Stock);
                    cmd.Parameters.AddWithValue("@stock_minimo", producto.StockMinimo);
                    cmd.Parameters.AddWithValue("@precio_compra", producto.PrecioCompra);
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
                    // Cambiamos el UPDATE por un DELETE físico
                    string consulta = @"DELETE FROM producto WHERE id_producto = @id_producto";
                    MySqlCommand cmd = new MySqlCommand(consulta, cn);
                    cmd.Parameters.AddWithValue("@id_producto", idProducto);

                    cn.Open();
                    cmd.ExecuteNonQuery();
                }
                catch (MySqlException ex)
                {
                    // El error 1451 ocurre si el producto está en detalle_venta o detalle_compra
                    if (ex.Number == 1451)
                    {
                        throw new Exception("No se puede eliminar el producto físicamente porque ya tiene ventas o compras asociadas en el sistema.");
                    }
                    throw new Exception("Error de base de datos al eliminar el producto: " + ex.Message);
                }
                catch (Exception ex)
                {
                    throw new Exception("Error al eliminar el producto: " + ex.Message);
                }
            }
        }

        public void AumentarPreciosMasivo(decimal porcentaje, string columnaFiltro, int idFiltro)
        {
            using (MySqlConnection cn = conexion.CrearConexion())
            {
                try
                {
                    // Validamos que el nombre de la columna sea seguro para evitar inyección SQL
                    if (columnaFiltro != "id_marca" && columnaFiltro != "id_categoria" && columnaFiltro != "id_proveedor")
                    {
                        throw new Exception("Filtro no válido.");
                    }

                    // Calculamos el aumento directo en MySQL: precio * (1 + (porcentaje / 100))
                    string query = $"UPDATE producto SET precio = precio * (1 + (@porcentaje / 100)) WHERE {columnaFiltro} = @id_filtro";

                    MySqlCommand cmd = new MySqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@porcentaje", porcentaje);
                    cmd.Parameters.AddWithValue("@id_filtro", idFiltro);

                    cn.Open();
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    throw new Exception("Error al actualizar precios: " + ex.Message);
                }
            }
        }
    }
}