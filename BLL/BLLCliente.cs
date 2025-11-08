using BE;
using MPP;


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
            // reglas de negocio
            if (cliente == null) throw new ArgumentNullException("El cliente no puede ser nulo.");
            if (string.IsNullOrWhiteSpace(cliente.DNI)) throw new ArgumentException("El DNI es obligatorio.");
            if (string.IsNullOrWhiteSpace(cliente.Nombre)) throw new ArgumentException("El Nombre es obligatorio.");
            if (string.IsNullOrWhiteSpace(cliente.Apellido)) throw new ArgumentException("El Apellido es obligatorio.");
            if (string.IsNullOrWhiteSpace(cliente.Telefono)) throw new ArgumentException("El Teléfono es obligatorio.");
            if (string.IsNullOrWhiteSpace(cliente.Email)) throw new ArgumentException("El Email es obligatorio.");


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
                throw new Exception("Error al guardar el cliente: " + ex.Message);
            }
        }

        public List<BECliente> Listar()
        {
            return mppCliente.Listar();
        }

        public void Eliminar(int idCliente)
        {
            // Reglas de negocio antes de eliminar 
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

        public void CambiarEstadoMembresia(int idCliente, bool nuevoEstado)
        {
            var cliente = Listar().FirstOrDefault(c => c.Id == idCliente);
            if (cliente == null) throw new KeyNotFoundException("Cliente no encontrado.");

            cliente.MembresiaActiva = nuevoEstado;
            mppCliente.Guardar(cliente); // Reutilizamos Guardar para actualizar
        }

    }
}