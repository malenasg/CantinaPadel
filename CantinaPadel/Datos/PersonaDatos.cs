using System;
using System.Data;
using MySql.Data.MySqlClient;
using CantinaPadel.Entidades;

namespace CantinaPadel.Datos
{
    public class PersonaDatos
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
                                    p.id_persona AS ID,

                                    CASE 
                                        WHEN p.razon_social IS NOT NULL AND p.razon_social <> '' 
                                        THEN p.razon_social
                                        ELSE CONCAT(p.nombre, ' ', p.apellido)
                                    END AS Nombre,

                                    p.cuit AS 'CUIT/CUIL',
                                    p.telefono AS Teléfono,
                                    p.email AS Email,
                                    p.direccion AS Dirección,

                                    CONCAT_WS(', ',
                                        CASE 
                                            WHEN c.id_cliente IS NOT NULL AND c.activo = TRUE THEN 'Cliente' 
                                        END,
                                        CASE 
                                            WHEN e.id_empleado IS NOT NULL AND e.activo = TRUE THEN 'Empleado' 
                                        END,
                                        CASE 
                                            WHEN pr.id_proveedor IS NOT NULL AND pr.activo = TRUE THEN 'Proveedor' 
                                        END
                                    ) AS Tipo,

                                    CASE 
                                        WHEN p.activo = TRUE THEN 'Sí'
                                        ELSE 'No'
                                    END AS Activo

                                FROM persona p
                                LEFT JOIN cliente c ON p.id_persona = c.id_persona
                                LEFT JOIN empleado e ON p.id_persona = e.id_persona
                                LEFT JOIN proveedor pr ON p.id_persona = pr.id_persona
                                WHERE p.activo = TRUE";

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
                                        WHEN p.razon_social IS NOT NULL AND p.razon_social <> '' 
                                        THEN p.razon_social
                                        ELSE CONCAT(p.nombre, ' ', p.apellido)
                                    END AS Nombre,

                                    p.cuit AS 'CUIT/CUIL',
                                    p.telefono AS Teléfono,
                                    p.email AS Email,
                                    p.direccion AS Dirección,

                                    CONCAT_WS(', ',
                                        CASE 
                                            WHEN c.id_cliente IS NOT NULL AND c.activo = TRUE THEN 'Cliente' 
                                        END,
                                        CASE 
                                            WHEN e.id_empleado IS NOT NULL AND e.activo = TRUE THEN 'Empleado' 
                                        END,
                                        CASE 
                                            WHEN pr.id_proveedor IS NOT NULL AND pr.activo = TRUE THEN 'Proveedor' 
                                        END
                                    ) AS Tipo,

                                    CASE 
                                        WHEN p.activo = TRUE THEN 'Sí'
                                        ELSE 'No'
                                    END AS Activo

                                FROM persona p
                                LEFT JOIN cliente c ON p.id_persona = c.id_persona
                                LEFT JOIN empleado e ON p.id_persona = e.id_persona
                                LEFT JOIN proveedor pr ON p.id_persona = pr.id_persona
                                WHERE p.activo = TRUE
                                AND (
                                    p.nombre LIKE @texto
                                    OR p.apellido LIKE @texto
                                    OR p.razon_social LIKE @texto
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
                                        p.razon_social,
                                        p.cuit,
                                        p.telefono,
                                        p.email,
                                        p.direccion,
                                        p.activo,

                                        CASE 
                                            WHEN c.id_cliente IS NOT NULL AND c.activo = 1 THEN 1
                                            ELSE 0
                                        END AS es_cliente,

                                        CASE 
                                            WHEN e.id_empleado IS NOT NULL AND e.activo = 1 THEN 1
                                            ELSE 0
                                        END AS es_empleado,

                                        e.fecha_ingreso,

                                        CASE 
                                            WHEN pr.id_proveedor IS NOT NULL AND pr.activo = 1 THEN 1
                                            ELSE 0
                                        END AS es_proveedor

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

        public int Insertar(Persona persona, bool esCliente, bool esEmpleado, bool esProveedor, DateTime? fechaIngreso)
        {
            int idPersonaGenerado = 0;

            using (MySqlConnection cn = conexion.CrearConexion())
            {
                cn.Open();

                MySqlTransaction transaccion = cn.BeginTransaction();

                try
                {
                    string consultaPersona = @"INSERT INTO persona
                                      (nombre, apellido, razon_social, cuit, telefono, email, direccion, activo)
                                      VALUES
                                      (@nombre, @apellido, @razon_social, @cuit, @telefono, @email, @direccion, TRUE);
                                      SELECT LAST_INSERT_ID();";

                    MySqlCommand cmdPersona = new MySqlCommand(consultaPersona, cn, transaccion);

                    cmdPersona.Parameters.AddWithValue("@nombre", persona.Nombre);
                    cmdPersona.Parameters.AddWithValue("@apellido", persona.Apellido);
                    cmdPersona.Parameters.AddWithValue("@razon_social", persona.RazonSocial);
                    cmdPersona.Parameters.AddWithValue("@cuit", persona.Cuit);
                    cmdPersona.Parameters.AddWithValue("@telefono", persona.Telefono);
                    cmdPersona.Parameters.AddWithValue("@email", persona.Email);
                    cmdPersona.Parameters.AddWithValue("@direccion", persona.Direccion);

                    idPersonaGenerado = Convert.ToInt32(cmdPersona.ExecuteScalar());

                    if (esCliente)
                    {
                        string consultaCliente = @"INSERT INTO cliente
                                          (id_persona, activo)
                                          VALUES
                                          (@id_persona, TRUE)";

                        MySqlCommand cmdCliente = new MySqlCommand(consultaCliente, cn, transaccion);
                        cmdCliente.Parameters.AddWithValue("@id_persona", idPersonaGenerado);
                        cmdCliente.ExecuteNonQuery();
                    }

                    if (esEmpleado)
                    {
                        string consultaEmpleado = @"INSERT INTO empleado
                                           (id_persona, fecha_ingreso, activo)
                                           VALUES
                                           (@id_persona, @fecha_ingreso, TRUE)";

                        MySqlCommand cmdEmpleado = new MySqlCommand(consultaEmpleado, cn, transaccion);
                        cmdEmpleado.Parameters.AddWithValue("@id_persona", idPersonaGenerado);
                        cmdEmpleado.Parameters.AddWithValue("@fecha_ingreso", fechaIngreso);
                        cmdEmpleado.ExecuteNonQuery();
                    }

                    if (esProveedor)
                    {
                        string consultaProveedor = @"INSERT INTO proveedor
                                            (id_persona, activo)
                                            VALUES
                                            (@id_persona, TRUE)";

                        MySqlCommand cmdProveedor = new MySqlCommand(consultaProveedor, cn, transaccion);
                        cmdProveedor.Parameters.AddWithValue("@id_persona", idPersonaGenerado);
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

        public void Modificar(Persona persona, bool esCliente, bool esEmpleado, bool esProveedor, DateTime? fechaIngreso)
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
                                            razon_social = @razon_social,
                                            cuit = @cuit,
                                            telefono = @telefono,
                                            email = @email,
                                            direccion = @direccion
                                       WHERE id_persona = @id_persona";

                    MySqlCommand cmdPersona = new MySqlCommand(consultaPersona, cn, transaccion);

                    cmdPersona.Parameters.AddWithValue("@id_persona", persona.IdPersona);
                    cmdPersona.Parameters.AddWithValue("@nombre", persona.Nombre);
                    cmdPersona.Parameters.AddWithValue("@apellido", persona.Apellido);
                    cmdPersona.Parameters.AddWithValue("@razon_social", persona.RazonSocial);
                    cmdPersona.Parameters.AddWithValue("@cuit", persona.Cuit);
                    cmdPersona.Parameters.AddWithValue("@telefono", persona.Telefono);
                    cmdPersona.Parameters.AddWithValue("@email", persona.Email);
                    cmdPersona.Parameters.AddWithValue("@direccion", persona.Direccion);

                    cmdPersona.ExecuteNonQuery();

                    if (esCliente)
                    {
                        string consultaCliente = @"INSERT INTO cliente(id_persona, activo)
                                           VALUES(@id_persona, TRUE)
                                           ON DUPLICATE KEY UPDATE activo = TRUE";

                        MySqlCommand cmdCliente = new MySqlCommand(consultaCliente, cn, transaccion);
                        cmdCliente.Parameters.AddWithValue("@id_persona", persona.IdPersona);
                        cmdCliente.ExecuteNonQuery();
                    }
                    else
                    {
                        string consultaCliente = @"UPDATE cliente
                                           SET activo = FALSE
                                           WHERE id_persona = @id_persona";

                        MySqlCommand cmdCliente = new MySqlCommand(consultaCliente, cn, transaccion);
                        cmdCliente.Parameters.AddWithValue("@id_persona", persona.IdPersona);
                        cmdCliente.ExecuteNonQuery();
                    }

                    if (esEmpleado)
                    {
                        string consultaEmpleado = @"INSERT INTO empleado(id_persona, fecha_ingreso, activo)
                                            VALUES(@id_persona, @fecha_ingreso, TRUE)
                                            ON DUPLICATE KEY UPDATE 
                                                fecha_ingreso = @fecha_ingreso,
                                                activo = TRUE";

                        MySqlCommand cmdEmpleado = new MySqlCommand(consultaEmpleado, cn, transaccion);
                        cmdEmpleado.Parameters.AddWithValue("@id_persona", persona.IdPersona);
                        cmdEmpleado.Parameters.AddWithValue("@fecha_ingreso", fechaIngreso);
                        cmdEmpleado.ExecuteNonQuery();
                    }
                    else
                    {
                        string consultaEmpleado = @"UPDATE empleado
                                            SET activo = FALSE
                                            WHERE id_persona = @id_persona";

                        MySqlCommand cmdEmpleado = new MySqlCommand(consultaEmpleado, cn, transaccion);
                        cmdEmpleado.Parameters.AddWithValue("@id_persona", persona.IdPersona);
                        cmdEmpleado.ExecuteNonQuery();
                    }

                    if (esProveedor)
                    {
                        string consultaProveedor = @"INSERT INTO proveedor(id_persona, activo)
                                             VALUES(@id_persona, TRUE)
                                             ON DUPLICATE KEY UPDATE activo = TRUE";

                        MySqlCommand cmdProveedor = new MySqlCommand(consultaProveedor, cn, transaccion);
                        cmdProveedor.Parameters.AddWithValue("@id_persona", persona.IdPersona);
                        cmdProveedor.ExecuteNonQuery();
                    }
                    else
                    {
                        string consultaProveedor = @"UPDATE proveedor
                                             SET activo = FALSE
                                             WHERE id_persona = @id_persona";

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
                    string consultaPersona = @"UPDATE persona
                                       SET activo = FALSE
                                       WHERE id_persona = @id_persona";

                    MySqlCommand cmdPersona = new MySqlCommand(consultaPersona, cn, transaccion);
                    cmdPersona.Parameters.AddWithValue("@id_persona", idPersona);
                    cmdPersona.ExecuteNonQuery();

                    string consultaCliente = @"UPDATE cliente
                                       SET activo = FALSE
                                       WHERE id_persona = @id_persona";

                    MySqlCommand cmdCliente = new MySqlCommand(consultaCliente, cn, transaccion);
                    cmdCliente.Parameters.AddWithValue("@id_persona", idPersona);
                    cmdCliente.ExecuteNonQuery();

                    string consultaEmpleado = @"UPDATE empleado
                                        SET activo = FALSE
                                        WHERE id_persona = @id_persona";

                    MySqlCommand cmdEmpleado = new MySqlCommand(consultaEmpleado, cn, transaccion);
                    cmdEmpleado.Parameters.AddWithValue("@id_persona", idPersona);
                    cmdEmpleado.ExecuteNonQuery();

                    string consultaProveedor = @"UPDATE proveedor
                                         SET activo = FALSE
                                         WHERE id_persona = @id_persona";

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