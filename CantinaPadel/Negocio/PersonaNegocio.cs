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
            // 1. VALIDACIÓN DE ROLES
            if (!esCliente && !esEmpleado && !esProveedor)
            {
                throw new Exception("Debe seleccionar al menos un rol: cliente, empleado o proveedor.");
            }

            // 2. VALIDACIONES PARA EMPLEADOS Y CLIENTES (Personas Físicas)
            if (esEmpleado || esCliente)
            {
                if (string.IsNullOrWhiteSpace(persona.Nombre))
                    throw new Exception("El nombre es obligatorio.");

                if (string.IsNullOrWhiteSpace(persona.Apellido)) // Asumiendo que tu entidad tiene propiedad Apellido
                    throw new Exception("El apellido es obligatorio.");

                // Validar CUIT (Típicamente entre 11 números en Argentina)
                if (string.IsNullOrWhiteSpace(persona.Cuit)) // Asumiendo propiedad Cuit
                    throw new Exception("El CUIT es obligatorio.");
                else if (persona.Cuit.Length < 11)
                    throw new Exception("El CUIT ingresado no es válido.");

                if (esEmpleado && persona.FechaIngreso == null)
                    throw new Exception("Debe ingresar la fecha de ingreso del empleado.");
            }

            // 3. VALIDACIONES PARA PROVEEDORES (Personas Jurídicas/Empresas)
            if (esProveedor)
            {
                if (string.IsNullOrWhiteSpace(persona.RazonSocial))
                    throw new Exception("La Razón Social es obligatoria para los proveedores.");

                // COMPLETANDO LA CONDICIÓN FISCAL:
                // Evitamos que guarde si está vacío o si dejaron la opción por defecto del ComboBox
                if (string.IsNullOrWhiteSpace(persona.CondicionFiscal) ||
                    persona.CondicionFiscal.ToLower() == "seleccione" ||
                    persona.CondicionFiscal.ToLower() == "seleccione...")
                {
                    throw new Exception("Debe seleccionar una condición fiscal válida para el proveedor.");
                }
            }

            // 4. VALIDACIÓN DE CUIL/CUIT (Enmascarado)
            if (!string.IsNullOrWhiteSpace(persona.Cuit))
            {
                string cuitLimpio = persona.Cuit.Replace("-", "").Replace(" ", "");
                if (cuitLimpio.Length > 0 && cuitLimpio.Length < 11)
                {
                    throw new Exception("El CUIT/CUIL está incompleto. Debe tener exactamente 11 números.");
                }
            }

            // 5. VALIDACIÓN DE TELÉFONO (Enmascarado)
            if (!string.IsNullOrWhiteSpace(persona.Telefono))
            {
                string telLimpio = persona.Telefono.Replace("-", "").Replace(" ", "").Replace("(", "").Replace(")", "");
                if (telLimpio.Length > 0 && telLimpio.Length < 10)
                {
                    throw new Exception("El número de teléfono está incompleto. Debe tener al menos 10 dígitos.");
                }
            }

            // 6. VALIDACIÓN DE EMAIL
            if (!string.IsNullOrWhiteSpace(persona.Email))
            {
                // Forma más segura de validar que tenga un formato real (ej: texto@texto.com)
                if (!System.Text.RegularExpressions.Regex.IsMatch(persona.Email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
                {
                    throw new Exception("El formato del correo electrónico no es válido.");
                }
            }
        }

        // Permite insertar una nueva persona en la base de datos
        public int Insertar(Persona persona, bool esCliente, bool esEmpleado, bool esProveedor)
        {
            ValidarPersona(persona, esCliente, esEmpleado, esProveedor);

            if (personaDatos.ExisteCuit(persona.Cuit))
            {
                throw new Exception("Error: El CUIT/CUIL ingresado ya se encuentra registrado en el sistema.");
            }

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

            if (personaDatos.ExisteCuit(persona.Cuit, persona.IdPersona))
            {
                throw new Exception("Error: El CUIT/CUIL ingresado ya pertenece a otra persona registrada.");
            }

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

        public void DarAlta(int idPersona)
        {
            if (idPersona <= 0)
            {
                throw new Exception("Debe seleccionar una persona válida para reactivar.");
            }

            personaDatos.DarAlta(idPersona);
        }
    }
}