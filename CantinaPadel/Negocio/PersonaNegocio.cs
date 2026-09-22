using System;
using System.Data;
using CantinaPadel.Datos;
using CantinaPadel.Entidades;

namespace CantinaPadel.Negocio
{

    public class PersonaNegocio
    {
        
        private PersonaDatos personaDatos = new PersonaDatos();

        // Permite actualizar la lista de personas desde la base de datos
        public DataTable Actualizar()
        {
            return personaDatos.Actualizar();
        }

        // Permite buscar personas por nombre, apellido o CUIT/CUIL
        public DataTable Buscar(string texto)
        {
            if (string.IsNullOrWhiteSpace(texto))
            {
                return personaDatos.Actualizar();
            }

            return personaDatos.Buscar(texto.Trim());
        }

        // Permite obtener los datos de una persona por su ID
        public DataTable ObtenerPorId(int idPersona)
        {
            if (idPersona <= 0)
            {
                throw new Exception("Debe seleccionar una persona.");
            }

            return personaDatos.ObtenerPorId(idPersona);
        }

        // Permite obtener todas las personas de la base de datos
        public DataTable ObtenerTodas()
        {
            return personaDatos.ObtenerTodas(); 
        }

        public DataTable ObtenerProveedores()
        {
            PersonaDatos datos = new PersonaDatos();
            return datos.ObtenerProveedores();
        }

        // Permite validar los datos de una persona antes de insertarla o modificarla
        private void ValidarPersona(Persona persona, bool esCliente, bool esEmpleado, bool esProveedor)
        {
            if (string.IsNullOrWhiteSpace(persona.Nombre))
            {
                throw new Exception("Debe ingresar el nombre de la persona.");
            }

            if (!esCliente && !esEmpleado && !esProveedor)
            {
                throw new Exception("Debe seleccionar al menos un tipo: cliente, empleado o proveedor.");
            }

            if (esEmpleado && persona.FechaIngreso == null)
            {
                throw new Exception("Debe ingresar la fecha de ingreso del empleado.");
            }

            if (esProveedor)
            {
                if (string.IsNullOrWhiteSpace(persona.RazonSocial))
                    throw new Exception("La Razón Social es obligatoria para los proveedores.");
                
                if (string.IsNullOrWhiteSpace(persona.CondicionFiscal))
                    throw new Exception("Debe seleccionar una Condición Fiscal para el proveedor.");
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

        // Permite insertar una nueva persona en la base de datos
        public int Insertar(Persona persona, bool esCliente, bool esEmpleado, bool esProveedor)
        {
            ValidarPersona(persona, esCliente, esEmpleado, esProveedor);
            return personaDatos.Insertar(persona, esCliente, esEmpleado, esProveedor);
        }

        // Permite modificar los datos de una persona existente en la base de datos
        public void Modificar(Persona persona, bool esCliente, bool esEmpleado, bool esProveedor)
        {
            if (persona.IdPersona <= 0)
            {
                throw new Exception("Debe seleccionar una persona para modificar.");
            }

            ValidarPersona(persona, esCliente, esEmpleado, esProveedor);
            personaDatos.Modificar(persona, esCliente, esEmpleado, esProveedor);
        }

        // Permite dar de baja a una persona en la base de datos
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