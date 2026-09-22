using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace CantinaPadel.Datos
{
    public class Conexion
    {
        public static string cadena = "server=localhost;port=3306;database=cantina_padel;user=root;password=;";

        public MySqlConnection CrearConexion()
        {
            return new MySqlConnection(cadena);
        }
    }
}
