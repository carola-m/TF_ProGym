using BE;
using MPP;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BLL
{
    public class BLLCliente
    {
        private readonly MPPCliente mppCliente;

        public BLLCliente()
        {
            mppCliente = new MPPCliente();
        }

        public void Guardar(BECliente cliente)
        {
            // Aplicar reglas de negocio antes de guardar
            if (cliente == null) throw new ArgumentNullException("El cliente no puede ser nulo.");
            if (string.IsNullOrWhiteSpace(cliente.DNI)) throw new ArgumentException("El DNI es obligatorio.");
            if (string.IsNullOrWhiteSpace(cliente.Nombre)) throw new ArgumentException("El Nombre es obligatorio.");
            if (string.IsNullOrWhiteSpace(cliente.Apellido)) throw new ArgumentException("El Apellido es obligatorio.");
            // Añadir más validaciones (formato email, teléfono, etc.)

            // Validar longitud y formato del DNI
            if (cliente.DNI.Length < 7 || cliente.DNI.Length > 8 || !cliente.DNI.All(char.IsDigit))
            {
                throw new ArgumentException("El DNI debe tener 7 u 8 dígitos numéricos.");
            }


            try
            {
                mppCliente.Guardar(cliente);
            }
            catch (Exception ex)
            {
                // Podrías registrar el error o relanzar una excepción más específica
                throw new Exception("Error al guardar el cliente: " + ex.Message);
            }
        }

        public List<BECliente> Listar()
        {
            return mppCliente.Listar();
        }

        public void Eliminar(int idCliente)
        {
            // Reglas de negocio antes de eliminar (ej. verificar si tiene deudas, turnos activos)
            // Ejemplo simple: no permitir eliminar si tiene membresía activa
            var cliente = Listar().FirstOrDefault(c => c.Id == idCliente);
            if (cliente != null && cliente.MembresiaActiva)
            {
                throw new InvalidOperationException("No se puede eliminar un cliente con membresía activa.");
            }


            mppCliente.Eliminar(idCliente);
        }

        public BECliente BuscarPorDNI(string dni)
        {
            if (string.IsNullOrWhiteSpace(dni)) return null;
            return mppCliente.BuscarPorDNI(dni);
        }

        // Otros métodos BLL (ej. ActivarMembresia, DesactivarMembresia, ObtenerHistorialAsistencia, etc.)
        public void CambiarEstadoMembresia(int idCliente, bool nuevoEstado)
        {
            var cliente = Listar().FirstOrDefault(c => c.Id == idCliente);
            if (cliente == null) throw new KeyNotFoundException("Cliente no encontrado.");

            cliente.MembresiaActiva = nuevoEstado;
            mppCliente.Guardar(cliente); // Reutilizamos Guardar para actualizar
        }

    }
}