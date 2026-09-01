using CantinaPadel.Datos;
using CantinaPadel.Entidades;
using System.Data;

namespace CantinaPadel.Negocio
{
    public class MarcaNegocio
    {
        private MarcaDatos marcaDatos = new MarcaDatos();

        public DataTable ObtenerTodas()
        {
            return marcaDatos.ObtenerTodas();
        }
        public void Insertar(Marca marca)
        {
            if (string.IsNullOrWhiteSpace(marca.Nombre))
            {
                throw new Exception("El nombre de la marca es obligatorio.");
            }
            marcaDatos.Insertar(marca);
        }
    }
}