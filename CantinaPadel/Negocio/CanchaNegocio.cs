using System.Data;
using CantinaPadel.Datos; 
using CantinaPadel.Entidades;
using System.Data;

namespace CantinaPadel.Negocio
{
    public class CanchaNegocio
    {
        private CanchaDatos canchaDatos = new CanchaDatos();
        public DataTable ObtenerTodas()
        {
            return canchaDatos.ObtenerTodas();
        }

        public void Insertar(Cancha cancha)
        {
            if (string.IsNullOrWhiteSpace(cancha.Nombre))
            {
                throw new Exception("El nombre de la cancha es obligatorio.");
            }
            canchaDatos.Insertar(cancha);
        }

        public void Modificar(Cancha cancha)
        {
            if (string.IsNullOrWhiteSpace(cancha.Nombre))
            {
                throw new Exception("El nombre de la cancha es obligatorio.");
            }
            canchaDatos.Modificar(cancha);
        }

        public void Eliminar(int idCancha)
        {
            canchaDatos.Eliminar(idCancha);
        }
    }
}