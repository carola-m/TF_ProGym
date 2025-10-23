using BE;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Services
{
    public sealed class Session // Sealed para prevenir herencia
    {
        // Instancia única (Singleton) - Volatile asegura visibilidad entre hilos
        private static volatile Session instancia;
        private static readonly object lockObj = new object(); // Objeto para bloqueo

        // Propiedades de la sesión (privadas para escritura externa)
        public BEUsuario UsuarioLogueado { get; private set; }
        public List<BEPermisoComponent> PermisosUsuario { get; private set; } // Lista consolidada de permisos simples

        // Constructor privado para evitar instanciación externa
        private Session() { }

        // Propiedad estática para acceder a la instancia única (Double-Checked Locking)
        public static Session ObtenerInstancia
        {
            get
            {
                // Primera verificación (sin bloqueo) para rendimiento
                if (instancia == null)
                {
                    // Bloqueo solo si la instancia es nula
                    lock (lockObj)
                    {
                        // Segunda verificación (dentro del bloqueo) para evitar creación múltiple
                        if (instancia == null)
                        {
                            instancia = new Session();
                        }
                    }
                }
                return instancia;
            }
        }

        // Método para iniciar la sesión de un usuario
        // Recibe el usuario y la lista CONSOLIDADA de sus permisos simples (hojas)
        public void IniciarSesion(BEUsuario usuario, List<BEPermisoComponent> permisosConsolidados)
        {
            if (usuario == null)
                throw new ArgumentNullException(nameof(usuario), "El usuario no puede ser nulo para iniciar sesión.");

            this.UsuarioLogueado = usuario;
            // Asegura que la lista de permisos no sea nula
            this.PermisosUsuario = permisosConsolidados ?? new List<BEPermisoComponent>();
        }

        // Método para cerrar la sesión actual
        public void CerrarSesion()
        {
            this.UsuarioLogueado = null;
            this.PermisosUsuario = null;
            // Opcional: Destruir la instancia singleton si se requiere un reinicio completo
            // instancia = null;
        }

        // Método para verificar si el usuario logueado tiene un permiso específico por su NombreInterno
        public bool TienePermiso(string nombreInternoPermiso)
        {
            // Verifica que haya un usuario logueado, que la lista de permisos exista,
            // y que el nombre del permiso no esté vacío.
            if (UsuarioLogueado == null || PermisosUsuario == null || string.IsNullOrWhiteSpace(nombreInternoPermiso))
            {
                return false;
            }

            // Busca si algún permiso en la lista del usuario coincide con el NombreInterno (ignorando mayúsculas/minúsculas)
            return PermisosUsuario.Any(p => p.NombreInterno != null &&
                                            p.NombreInterno.Equals(nombreInternoPermiso, StringComparison.OrdinalIgnoreCase));
        }

        // Propiedad para verificar rápidamente si hay una sesión activa
        public bool IsLoggedIn => UsuarioLogueado != null;
    }
}