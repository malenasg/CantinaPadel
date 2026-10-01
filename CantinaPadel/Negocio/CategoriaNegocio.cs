using System;
using CantinaPadel.Datos;
using CantinaPadel.Entidades;
using System.Data;

namespace CantinaPadel.Negocio
{
    public class CategoriaNegocio
    {
        private CategoriaDatos categoriaDatos = new CategoriaDatos();

        public DataTable ObtenerTodas()
        {
            return categoriaDatos.ObtenerTodas();
        }

        public void Insertar(Categoria categoria)
        {
            if (string.IsNullOrWhiteSpace(categoria.Nombre))
            {
                throw new Exception("El nombre de la categoría es obligatorio.");
            }

            if (categoriaDatos.ExisteNombre(categoria.Nombre))
            {
                throw new Exception("Error: Ya existe una categoría registrada con ese nombre.");
            }

            categoriaDatos.Insertar(categoria);
        }
    }
}