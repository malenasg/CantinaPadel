using CantinaPadel.Entidades;
using MySql.Data.MySqlClient;
using System;
using System.Data;

namespace CantinaPadel.Datos
{
    public class MarcaDatos
    {
        private Conexion conexion = new Conexion();

        public DataTable ObtenerTodas()
        {
            DataTable tabla = new DataTable();
            try
            {
                using (MySqlConnection cn = conexion.CrearConexion())
                {
                    string consulta = "SELECT id_marca, nombre FROM marca WHERE activo = TRUE";
                    MySqlDataAdapter da = new MySqlDataAdapter(consulta, cn);
                    da.Fill(tabla);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al cargar las marcas: " + ex.Message);
            }
            return tabla;
        }
        public void Insertar(Marca marca)
        {
            using (MySqlConnection cn = conexion.CrearConexion())
            {
                try
                {
                    string consulta = "INSERT INTO marca (nombre, activo) VALUES (@nombre, TRUE)";
                    MySqlCommand cmd = new MySqlCommand(consulta, cn);
                    cmd.Parameters.AddWithValue("@nombre", marca.Nombre);

                    cn.Open();
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    throw new Exception("Error al insertar marca: " + ex.Message);
                }
            }
        }
    }
}