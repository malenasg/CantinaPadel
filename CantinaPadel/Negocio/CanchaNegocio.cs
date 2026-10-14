using System;
using System.Data;
using CantinaPadel.Datos;
using CantinaPadel.Entidades;

namespace CantinaPadel.Negocio
{
    public class CanchaNegocio
    {
        private CanchaDatos canchaDatos = new CanchaDatos();

        public DataTable ObtenerTodas()
        {
            return canchaDatos.ObtenerTodas();
        }

        public DataTable ObtenerActivas()
        {
            return canchaDatos.ObtenerActivas();
        }

        public void Insertar(Cancha cancha)
        {
            // Validación de reglas de negocio
            if (string.IsNullOrWhiteSpace(cancha.Nombre))
            {
                throw new Exception("El nombre de la cancha es obligatorio.");
            }

            if (cancha.Nombre.Length > 100)
            {
                throw new Exception("El nombre de la cancha es demasiado largo (máximo 100 caracteres).");
            }

            canchaDatos.Insertar(cancha);
        }

        public void Modificar(Cancha cancha)
        {
            if (cancha.IdCancha <= 0)
            {
                throw new Exception("Debe seleccionar una cancha válida para modificar.");
            }

            if (string.IsNullOrWhiteSpace(cancha.Nombre))
            {
                throw new Exception("El nombre de la cancha es obligatorio.");
            }

            canchaDatos.Modificar(cancha);
        }

        // Método inteligente para dar de baja o reactivar
        public void CambiarEstado(int idCancha, string estadoActual)
        {
            if (idCancha <= 0)
            {
                throw new Exception("Debe seleccionar una cancha válida.");
            }

            // Alternamos el estado: si está activa pasa a inactiva, y viceversa
            string nuevoEstado = (estadoActual == "Activa") ? "Inactiva" : "Activa";

            canchaDatos.CambiarEstado(idCancha, nuevoEstado);
        }
    }
}