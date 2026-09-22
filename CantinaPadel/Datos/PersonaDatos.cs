using System;
using System.Data;
using MySql.Data.MySqlClient;
using CantinaPadel.Entidades;

namespace CantinaPadel.Datos
{
    public class PersonaDatos
    {
        private Conexion conexion = new Conexion();

        // Permite actualizar la lista de personas desde la base de datos
        public DataTable Actualizar()
        {
            DataTable tabla = new DataTable();

            try
            {
                using (MySqlConnection cn = conexion.CrearConexion())
                {
                    string consulta = @"SELECT p.id_persona AS ID,
                                    CASE 
                                        WHEN pr.razon_social IS NOT NULL AND pr.razon_social <> '' 
                                        THEN pr.razon_social
                                        ELSE CONCAT_WS(' ', p.nombre, p.apellido)
                                    END AS Nombre,

                                    p.cuit AS 'CUIT/CUIL',
                                    p.telefono AS Teléfono,
                                    p.email AS Email,
                                    p.direccion AS Dirección,

                                    CONCAT_WS(', ',
                                        CASE WHEN c.id_cliente IS NOT NULL AND c.activo = TRUE THEN 'Cliente' END,
                                        CASE WHEN e.id_empleado IS NOT NULL AND e.activo = TRUE THEN 'Empleado' END,
                                        CASE WHEN pr.id_proveedor IS NOT NULL AND pr.activo = TRUE THEN 'Proveedor' END
                                    ) AS Tipo,

                                    CASE WHEN p.activo = TRUE THEN 'Sí' ELSE 'No' END AS Activo

                                FROM persona p
                                LEFT JOIN cliente c ON p.id_persona = c.id_persona
                                LEFT JOIN empleado e ON p.id_persona = e.id_persona
                                LEFT JOIN proveedor pr ON p.id_persona = pr.id_persona";

                    MySqlDataAdapter da = new MySqlDataAdapter(consulta, cn);
                    da.Fill(tabla);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al listar personas: " + ex.Message);
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
                                    p.id_persona AS ID,

                                    CASE 
                                        WHEN pr.razon_social IS NOT NULL AND pr.razon_social <> '' 
                                        THEN pr.razon_social
                                        ELSE CONCAT_WS(' ', p.nombre, p.apellido)
                                    END AS Nombre,

                                    p.cuit AS 'CUIT/CUIL',
                                    p.telefono AS Teléfono,
                                    p.email AS Email,
                                    p.direccion AS Dirección,

                                    CONCAT_WS(', ',
                                        CASE WHEN c.id_cliente IS NOT NULL AND c.activo = TRUE THEN 'Cliente' END,
                                        CASE WHEN e.id_empleado IS NOT NULL AND e.activo = TRUE THEN 'Empleado' END,
                                        CASE WHEN pr.id_proveedor IS NOT NULL AND pr.activo = TRUE THEN 'Proveedor' END
                                    ) AS Tipo,

                                    CASE WHEN p.activo = TRUE THEN 'Sí' ELSE 'No' END AS Activo

                                FROM persona p
                                LEFT JOIN cliente c ON p.id_persona = c.id_persona
                                LEFT JOIN empleado e ON p.id_persona = e.id_persona
                                LEFT JOIN proveedor pr ON p.id_persona = pr.id_persona
                                WHERE (
                                    p.nombre LIKE @texto
                                    OR p.apellido LIKE @texto
                                    OR pr.razon_social LIKE @texto
                                    OR p.cuit LIKE @texto
                                    OR p.telefono LIKE @texto
                                    OR p.email LIKE @texto
                                    OR p.direccion LIKE @texto
                                )";

                    MySqlCommand cmd = new MySqlCommand(consulta, cn);
                    cmd.Parameters.AddWithValue("@texto", "%" + texto + "%");

                    MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                    da.Fill(tabla);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al buscar personas: " + ex.Message);
            }

            return tabla;
        }

        public DataTable ObtenerPorId(int idPersona)
        {
            DataTable tabla = new DataTable();

            try
            {
                using (MySqlConnection cn = conexion.CrearConexion())
                {
                    string consulta = @"SELECT 
                                        p.id_persona,
                                        p.nombre,
                                        p.apellido,
                                        pr.razon_social,
                                        p.cuit,
                                        pr.condicion_fiscal,
                                        p.telefono,
                                        p.email,
                                        p.direccion,
                                        p.activo,

                                        CASE WHEN c.id_cliente IS NOT NULL AND c.activo = 1 THEN 1 ELSE 0 END AS es_cliente,
                                        CASE WHEN e.id_empleado IS NOT NULL AND e.activo = 1 THEN 1 ELSE 0 END AS es_empleado,
                                        
                                        e.fecha_ingreso,

                                        CASE WHEN pr.id_proveedor IS NOT NULL AND pr.activo = 1 THEN 1 ELSE 0 END AS es_proveedor

                                    FROM persona p
                                    LEFT JOIN cliente c ON p.id_persona = c.id_persona
                                    LEFT JOIN empleado e ON p.id_persona = e.id_persona
                                    LEFT JOIN proveedor pr ON p.id_persona = pr.id_persona
                                    WHERE p.id_persona = @id_persona";

                    MySqlCommand cmd = new MySqlCommand(consulta, cn);
                    cmd.Parameters.AddWithValue("@id_persona", idPersona);

                    MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                    da.Fill(tabla);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener persona: " + ex.Message);
            }

            return tabla;
        }

        public DataTable ObtenerTodas()
        {
            DataTable tabla = new DataTable();
            using (MySqlConnection cn = conexion.CrearConexion()) 
            {
                try
                {
                    // Traemos los datos básicos para llenar el desplegable
                    string consulta = @"SELECT p.id_persona, p.nombre 
                                        FROM persona p 
                                        INNER JOIN cliente c ON p.id_persona = c.id_cliente";
                    MySqlDataAdapter da = new MySqlDataAdapter(consulta, cn);
                    da.Fill(tabla);
                }
                catch (Exception ex)
                {
                    throw new Exception("Error al cargar la lista de personas: " + ex.Message);
                }
            }
            return tabla;
        }

        public DataTable ObtenerProveedores()
        {
            DataTable dt = new DataTable();
            // Ajustá la conexión a cómo la manejes en tu proyecto
            using (MySqlConnection conexion = new MySqlConnection(Conexion.cadena))
            {
                // Filtramos para traer solo a los proveedores
                string query = "SELECT id_persona, nombre FROM personas WHERE tipo_persona = 'Proveedor' AND estado = 1";
                MySqlCommand comando = new MySqlCommand(query, conexion);
                MySqlDataAdapter adaptador = new MySqlDataAdapter(comando);

                adaptador.Fill(dt);
            }
            return dt;
        }

        public int Insertar(Persona persona, bool esCliente, bool esEmpleado, bool esProveedor)
        {
            int idPersonaGenerado = 0;

            using (MySqlConnection cn = conexion.CrearConexion())
            {
                cn.Open();
                MySqlTransaction transaccion = cn.BeginTransaction();

                try
                {
                    string consultaPersona = @"INSERT INTO persona
                                      (nombre, apellido, cuit, telefono, email, direccion, activo)
                                      VALUES
                                      (@nombre, @apellido, @cuit, @telefono, @email, @direccion, TRUE);
                                      SELECT LAST_INSERT_ID();";

                    MySqlCommand cmdPersona = new MySqlCommand(consultaPersona, cn, transaccion);
                    cmdPersona.Parameters.AddWithValue("@nombre", persona.Nombre);
                    cmdPersona.Parameters.AddWithValue("@apellido", (object)persona.Apellido ?? DBNull.Value);
                    cmdPersona.Parameters.AddWithValue("@cuit", (object)persona.Cuit ?? DBNull.Value);
                    cmdPersona.Parameters.AddWithValue("@telefono", (object)persona.Telefono ?? DBNull.Value);
                    cmdPersona.Parameters.AddWithValue("@email", (object)persona.Email ?? DBNull.Value);
                    cmdPersona.Parameters.AddWithValue("@direccion", (object)persona.Direccion ?? DBNull.Value);

                    idPersonaGenerado = Convert.ToInt32(cmdPersona.ExecuteScalar());

                    if (esCliente)
                    {
                        string consultaCliente = @"INSERT INTO cliente (id_persona, activo) VALUES (@id_persona, TRUE)";
                        MySqlCommand cmdCliente = new MySqlCommand(consultaCliente, cn, transaccion);
                        cmdCliente.Parameters.AddWithValue("@id_persona", idPersonaGenerado);
                        cmdCliente.ExecuteNonQuery();
                    }

                    if (esEmpleado)
                    {
                        string consultaEmpleado = @"INSERT INTO empleado (id_persona, fecha_ingreso, activo) 
                                                    VALUES (@id_persona, @fecha_ingreso, TRUE)";
                        MySqlCommand cmdEmpleado = new MySqlCommand(consultaEmpleado, cn, transaccion);
                        cmdEmpleado.Parameters.AddWithValue("@id_persona", idPersonaGenerado);
                        cmdEmpleado.Parameters.AddWithValue("@fecha_ingreso", (object)persona.FechaIngreso ?? DBNull.Value);
                        cmdEmpleado.ExecuteNonQuery();
                    }

                    if (esProveedor)
                    {
                        string consultaProveedor = @"INSERT INTO proveedor (id_persona, razon_social, condicion_fiscal, activo)
                                                     VALUES (@id_persona, @razon_social, @condicion_fiscal, TRUE)";
                        MySqlCommand cmdProveedor = new MySqlCommand(consultaProveedor, cn, transaccion);
                        cmdProveedor.Parameters.AddWithValue("@id_persona", idPersonaGenerado);
                        cmdProveedor.Parameters.AddWithValue("@razon_social", (object)persona.RazonSocial ?? DBNull.Value);
                        cmdProveedor.Parameters.AddWithValue("@condicion_fiscal", (object)persona.CondicionFiscal ?? DBNull.Value);
                        cmdProveedor.ExecuteNonQuery();
                    }

                    transaccion.Commit();
                }
                catch (Exception ex)
                {
                    transaccion.Rollback();
                    throw new Exception("Error al insertar persona: " + ex.Message);
                }
            }

            return idPersonaGenerado;
        }

        public void Modificar(Persona persona, bool esCliente, bool esEmpleado, bool esProveedor)
        {
            using (MySqlConnection cn = conexion.CrearConexion())
            {
                cn.Open();
                MySqlTransaction transaccion = cn.BeginTransaction();

                try
                {
                    string consultaPersona = @"UPDATE persona SET
                                            nombre = @nombre,
                                            apellido = @apellido,
                                            cuit = @cuit,
                                            telefono = @telefono,
                                            email = @email,
                                            direccion = @direccion
                                       WHERE id_persona = @id_persona";

                    MySqlCommand cmdPersona = new MySqlCommand(consultaPersona, cn, transaccion);
                    cmdPersona.Parameters.AddWithValue("@id_persona", persona.IdPersona);
                    cmdPersona.Parameters.AddWithValue("@nombre", persona.Nombre);
                    cmdPersona.Parameters.AddWithValue("@apellido", (object)persona.Apellido ?? DBNull.Value);
                    cmdPersona.Parameters.AddWithValue("@cuit", (object)persona.Cuit ?? DBNull.Value);
                    cmdPersona.Parameters.AddWithValue("@telefono", (object)persona.Telefono ?? DBNull.Value);
                    cmdPersona.Parameters.AddWithValue("@email", (object)persona.Email ?? DBNull.Value);
                    cmdPersona.Parameters.AddWithValue("@direccion", (object)persona.Direccion ?? DBNull.Value);
                    cmdPersona.ExecuteNonQuery();

                    if (esCliente)
                    {
                        string consultaCliente = @"INSERT INTO cliente(id_persona, activo) VALUES(@id_persona, TRUE)
                                                   ON DUPLICATE KEY UPDATE activo = TRUE";
                        MySqlCommand cmdCliente = new MySqlCommand(consultaCliente, cn, transaccion);
                        cmdCliente.Parameters.AddWithValue("@id_persona", persona.IdPersona);
                        cmdCliente.ExecuteNonQuery();
                    }
                    else
                    {
                        string consultaCliente = @"UPDATE cliente SET activo = FALSE WHERE id_persona = @id_persona";
                        MySqlCommand cmdCliente = new MySqlCommand(consultaCliente, cn, transaccion);
                        cmdCliente.Parameters.AddWithValue("@id_persona", persona.IdPersona);
                        cmdCliente.ExecuteNonQuery();
                    }

                    if (esEmpleado)
                    {
                        string consultaEmpleado = @"INSERT INTO empleado(id_persona, fecha_ingreso, activo)
                                                    VALUES(@id_persona, @fecha_ingreso, TRUE)
                                                    ON DUPLICATE KEY UPDATE fecha_ingreso = @fecha_ingreso, activo = TRUE";
                        MySqlCommand cmdEmpleado = new MySqlCommand(consultaEmpleado, cn, transaccion);
                        cmdEmpleado.Parameters.AddWithValue("@id_persona", persona.IdPersona);
                        cmdEmpleado.Parameters.AddWithValue("@fecha_ingreso", (object)persona.FechaIngreso ?? DBNull.Value);
                        cmdEmpleado.ExecuteNonQuery();
                    }
                    else
                    {
                        string consultaEmpleado = @"UPDATE empleado SET activo = FALSE WHERE id_persona = @id_persona";
                        MySqlCommand cmdEmpleado = new MySqlCommand(consultaEmpleado, cn, transaccion);
                        cmdEmpleado.Parameters.AddWithValue("@id_persona", persona.IdPersona);
                        cmdEmpleado.ExecuteNonQuery();
                    }

                    if (esProveedor)
                    {
                        string consultaProveedor = @"INSERT INTO proveedor(id_persona, razon_social, condicion_fiscal, activo)
                                                     VALUES(@id_persona, @razon_social, @condicion_fiscal, TRUE)
                                                     ON DUPLICATE KEY UPDATE razon_social = @razon_social, condicion_fiscal = @condicion_fiscal, activo = TRUE";
                        MySqlCommand cmdProveedor = new MySqlCommand(consultaProveedor, cn, transaccion);
                        cmdProveedor.Parameters.AddWithValue("@id_persona", persona.IdPersona);
                        cmdProveedor.Parameters.AddWithValue("@razon_social", (object)persona.RazonSocial ?? DBNull.Value);
                        cmdProveedor.Parameters.AddWithValue("@condicion_fiscal", (object)persona.CondicionFiscal ?? DBNull.Value);
                        cmdProveedor.ExecuteNonQuery();
                    }
                    else
                    {
                        string consultaProveedor = @"UPDATE proveedor SET activo = FALSE WHERE id_persona = @id_persona";
                        MySqlCommand cmdProveedor = new MySqlCommand(consultaProveedor, cn, transaccion);
                        cmdProveedor.Parameters.AddWithValue("@id_persona", persona.IdPersona);
                        cmdProveedor.ExecuteNonQuery();
                    }

                    transaccion.Commit();
                }
                catch (Exception ex)
                {
                    transaccion.Rollback();
                    throw new Exception("Error al modificar persona: " + ex.Message);
                }
            }
        }

        public void DarBaja(int idPersona)
        {
            using (MySqlConnection cn = conexion.CrearConexion())
            {
                cn.Open();
                MySqlTransaction transaccion = cn.BeginTransaction();

                try
                {
                    string consultaPersona = @"UPDATE persona SET activo = FALSE WHERE id_persona = @id_persona";
                    MySqlCommand cmdPersona = new MySqlCommand(consultaPersona, cn, transaccion);
                    cmdPersona.Parameters.AddWithValue("@id_persona", idPersona);
                    cmdPersona.ExecuteNonQuery();

                    string consultaCliente = @"UPDATE cliente SET activo = FALSE WHERE id_persona = @id_persona";
                    MySqlCommand cmdCliente = new MySqlCommand(consultaCliente, cn, transaccion);
                    cmdCliente.Parameters.AddWithValue("@id_persona", idPersona);
                    cmdCliente.ExecuteNonQuery();

                    string consultaEmpleado = @"UPDATE empleado SET activo = FALSE WHERE id_persona = @id_persona";
                    MySqlCommand cmdEmpleado = new MySqlCommand(consultaEmpleado, cn, transaccion);
                    cmdEmpleado.Parameters.AddWithValue("@id_persona", idPersona);
                    cmdEmpleado.ExecuteNonQuery();

                    string consultaProveedor = @"UPDATE proveedor SET activo = FALSE WHERE id_persona = @id_persona";
                    MySqlCommand cmdProveedor = new MySqlCommand(consultaProveedor, cn, transaccion);
                    cmdProveedor.Parameters.AddWithValue("@id_persona", idPersona);
                    cmdProveedor.ExecuteNonQuery();

                    transaccion.Commit();
                }
                catch (Exception ex)
                {
                    transaccion.Rollback();
                    throw new Exception("Error al dar de baja la persona: " + ex.Message);
                }
            }
        }
    }
}