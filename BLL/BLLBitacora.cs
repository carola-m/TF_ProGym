
using BE;
using MPP;


namespace BLL
{
    public class BLLBitacora
    {
        private readonly MPPBitacora mppBitacora = new MPPBitacora();

        public void Registrar(string detalle, string nombreArchivo = null)
        {
            // Obtener usuario de la sesión
            var sesion = Services.Session.ObtenerInstancia;
            if (!sesion.IsLoggedIn)
            {
                Console.WriteLine("Advertencia: Intentando registrar en bitácora sin sesión activa.");
                return; 
            }


            var entrada = new BEBitacora
            {
                FechaRegistro = DateTime.Now,
                Detalle = detalle, 
                IdUsuario = sesion.IsLoggedIn ? sesion.UsuarioLogueado.Id : 0, 
                NombreUsuario = sesion.IsLoggedIn ? sesion.UsuarioLogueado.NombreUsuario : "Sistema", 
                NombreArchivo = nombreArchivo
            };

            try
            {
                mppBitacora.Guardar(entrada);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error CRÍTICO al guardar en Bitácora: {ex.Message}");
            }
        }

        public List<BEBitacora> Listar()
        {
            try
            {
                return mppBitacora.Listar();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al listar Bitácora: {ex.Message}");
                return new List<BEBitacora>(); // Devolver lista vacía en caso de error
            }
        }
    }
}