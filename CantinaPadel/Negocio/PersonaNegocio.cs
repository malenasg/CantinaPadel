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

        private void ValidarPersona(Persona persona, bool esCliente, bool esEmpleado, bool esProveedor, DateTime? fechaIngreso)
        {
            if (string.IsNullOrWhiteSpace(persona.Nombre) &&
                string.IsNullOrWhiteSpace(persona.RazonSocial))
            {
                throw new Exception("Debe ingresar un nombre o una razón social.");
            }

            if (!esCliente && !esEmpleado && !esProveedor)
            {
                throw new Exception("Debe seleccionar al menos un tipo: cliente, empleado o proveedor.");
            }

            if (esEmpleado && fechaIngreso == null)
            {
                throw new Exception("Debe ingresar la fecha de ingreso del empleado.");
            }

            if (!string.IsNullOrWhiteSpace(persona.Cuit) && persona.Cuit.Length < 10)
            {
                throw new Exception("El CUIT/CUIL ingresado no es válido.");
            }

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

            if (!string.IsNullOrWhiteSpace(persona.Email) && !persona.Email.Contains("@"))
            {
                throw new Exception("El email ingresado no es válido.");
            }
        }

        public int Insertar(Persona persona, bool esCliente, bool esEmpleado, bool esProveedor, DateTime? fechaIngreso)
        {
            ValidarPersona(persona, esCliente, esEmpleado, esProveedor, fechaIngreso);

            return personaDatos.Insertar(persona, esCliente, esEmpleado, esProveedor, fechaIngreso);
        }

        public void Modificar(Persona persona, bool esCliente, bool esEmpleado, bool esProveedor, DateTime? fechaIngreso)
        {
            if (persona.IdPersona <= 0)
            {
                throw new Exception("Debe seleccionar una persona para modificar.");
            }

            ValidarPersona(persona, esCliente, esEmpleado, esProveedor, fechaIngreso);

            personaDatos.Modificar(persona, esCliente, esEmpleado, esProveedor, fechaIngreso);
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