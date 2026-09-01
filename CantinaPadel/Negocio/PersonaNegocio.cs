using System;
using System.Data;
using CantinaPadel.Datos;
using CantinaPadel.Entidades;

namespace CantinaPadel.Negocio
{
    public class PersonaNegocio
    {
        private PersonaDatos personaDatos = new PersonaDatos();

        public DataTable Actualizar()
        {
            return personaDatos.Actualizar();
        }

        public DataTable Buscar(string texto)
        {
            if (string.IsNullOrWhiteSpace(texto))
            {
                return personaDatos.Actualizar();
            }

            return personaDatos.Buscar(texto.Trim());
        }

        public DataTable ObtenerPorId(int idPersona)
        {
            if (idPersona <= 0)
            {
                throw new Exception("Debe seleccionar una persona.");
            }

            return personaDatos.ObtenerPorId(idPersona);
        }

        private void ValidarPersona(Persona persona, bool esCliente, bool esEmpleado, bool esProveedor)
        {
            // 1. El nombre ahora siempre es obligatorio (sea la persona física o el contacto del proveedor)
            if (string.IsNullOrWhiteSpace(persona.Nombre))
            {
                throw new Exception("El nombre (o nombre de contacto) es obligatorio.");
            }

            // 2. Al menos un rol seleccionado
            if (!esCliente && !esEmpleado && !esProveedor)
            {
                throw new Exception("Debe seleccionar al menos un tipo: cliente, empleado o proveedor.");
            }

            // 3. Validaciones de Empleado
            if (esEmpleado && persona.FechaIngreso == null)
            {
                throw new Exception("Debe ingresar la fecha de ingreso del empleado.");
            }

            // 4. Validaciones de Proveedor (Nuevas)
            if (esProveedor)
            {
                if (string.IsNullOrWhiteSpace(persona.RazonSocial))
                    throw new Exception("La Razón Social es obligatoria para los proveedores.");
                
                if (string.IsNullOrWhiteSpace(persona.CondicionFiscal))
                    throw new Exception("Debe seleccionar una Condición Fiscal para el proveedor.");
            }

            // 5. Formato de CUIT
            if (!string.IsNullOrWhiteSpace(persona.Cuit) && persona.Cuit.Length < 10)
            {
                throw new Exception("El CUIT/CUIL ingresado no es válido.");
            }

            // 6. Formato de Teléfono
            if (!string.IsNullOrWhiteSpace(persona.Telefono))
            {
                foreach (char caracter in persona.Telefono)
                {
                    if (!char.IsDigit(caracter) && caracter != '-' && caracter != ' ')
                    {
                        throw new Exception("El teléfono solo puede contener números, espacios o guiones.");
                    }
                }
            }

            // 7. Formato de Email
            if (!string.IsNullOrWhiteSpace(persona.Email) && !persona.Email.Contains("@"))
            {
                throw new Exception("El email ingresado no es válido.");
            }
        }

        public int Insertar(Persona persona, bool esCliente, bool esEmpleado, bool esProveedor)
        {
            ValidarPersona(persona, esCliente, esEmpleado, esProveedor);
            return personaDatos.Insertar(persona, esCliente, esEmpleado, esProveedor);
        }

        public void Modificar(Persona persona, bool esCliente, bool esEmpleado, bool esProveedor)
        {
            if (persona.IdPersona <= 0)
            {
                throw new Exception("Debe seleccionar una persona para modificar.");
            }

            ValidarPersona(persona, esCliente, esEmpleado, esProveedor);
            personaDatos.Modificar(persona, esCliente, esEmpleado, esProveedor);
        }

        public void DarBaja(int idPersona)
        {
            if (idPersona <= 0)
            {
                throw new Exception("Debe seleccionar una persona para dar de baja.");
            }

            personaDatos.DarBaja(idPersona);
        }
    }
}