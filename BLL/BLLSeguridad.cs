using BE;
using MPP;
using System.Text;

namespace BLL
{
    public class BLLSeguridad
    {
        private readonly MPPUsuario mppUsuario;
        private readonly MPPRol mppRol;
        private readonly MPPPermiso mppPermiso;
        private readonly MPPUsuarioRol mppUsuarioRol;

        public BLLSeguridad()
        {
            mppUsuario = new MPPUsuario();
            mppRol = new MPPRol();
            mppPermiso = new MPPPermiso();
            mppUsuarioRol = new MPPUsuarioRol();
        }

        #region Gestión Usuarios

        public BEUsuario Login(string nombreUsuario, string password)
        {
            if (string.IsNullOrWhiteSpace(nombreUsuario) || string.IsNullOrWhiteSpace(password))
                return null;

            var usuario = mppUsuario.BuscarPorNombre(nombreUsuario);

            // Encriptamos la contraseña ingresada para compararla
            string passwordEncriptada = EncriptarClave(password);

            // Verifica si el usuario existe, está activo y la contraseña encriptada coincide  --
            if (usuario != null && usuario.Activo && usuario.Password == passwordEncriptada)
            {
                return usuario;
            }
            return null;
        }

        public void CrearUsuario(BEUsuario usuario)
        {
            if (usuario == null) throw new ArgumentNullException("El usuario no puede ser nulo.");
            if (string.IsNullOrWhiteSpace(usuario.NombreUsuario)) throw new ArgumentException("El nombre de usuario es obligatorio.");
            if (string.IsNullOrWhiteSpace(usuario.Password)) throw new ArgumentException("La contraseña es obligatoria.");
           // if (usuario.Password.Length < 4) throw new ArgumentException("La contraseña debe tener al menos 4 caracteres.");

            // Encripta la contraseña antes de guardarla
            usuario.Password = EncriptarClave(usuario.Password);
            usuario.Activo = true;
            usuario.DebeCambiarPassword = !usuario.NombreUsuario.Equals("admin", StringComparison.OrdinalIgnoreCase);

            mppUsuario.Guardar(usuario);
        }

        public void ModificarUsuario(BEUsuario usuario, string nuevaPassword = null)
        {
            if (usuario == null) throw new ArgumentNullException("El usuario no puede ser nulo.");
            if (string.IsNullOrWhiteSpace(usuario.NombreUsuario)) throw new ArgumentException("El nombre de usuario es obligatorio.");

            var usuarioExistente = mppUsuario.BuscarPorId(usuario.Id);
            if (usuarioExistente == null) throw new KeyNotFoundException("Usuario no encontrado para modificar.");

            usuarioExistente.NombreUsuario = usuario.NombreUsuario;
            usuarioExistente.Activo = usuario.Activo;
            usuarioExistente.DebeCambiarPassword = usuario.DebeCambiarPassword;

            if (!string.IsNullOrWhiteSpace(nuevaPassword))
            {
                if (nuevaPassword.Length < 4) throw new ArgumentException("La nueva contraseña debe tener al menos 4 caracteres.");
                usuarioExistente.Password = EncriptarClave(nuevaPassword);
            }

            mppUsuario.Guardar(usuarioExistente);
        }

        public void CambiarPasswordPropio(int idUsuario, string passwordActual, string nuevaPassword)
        {
            if (string.IsNullOrWhiteSpace(passwordActual) || string.IsNullOrWhiteSpace(nuevaPassword))
                throw new ArgumentException("Debe proporcionar la contraseña actual y la nueva.");
            if (nuevaPassword.Length < 4)
                throw new ArgumentException("La nueva contraseña debe tener al menos 4 caracteres.");
            if (passwordActual == nuevaPassword)
                throw new ArgumentException("La nueva contraseña no puede ser igual a la actual.");

            var usuario = mppUsuario.BuscarPorId(idUsuario);
            if (usuario == null) throw new KeyNotFoundException("Usuario no encontrado.");

            // Verificar contraseña actual 
            if (EncriptarClave(passwordActual) != usuario.Password)
                throw new UnauthorizedAccessException("La contraseña actual es incorrecta.");

            usuario.Password = EncriptarClave(nuevaPassword);
            usuario.DebeCambiarPassword = false;
            mppUsuario.Guardar(usuario);
        }


        public void BajaUsuario(int idUsuario)
        {
            mppUsuario.Eliminar(idUsuario);
        }

        public void ReactivarUsuario(int idUsuario)
        {
            var usuario = mppUsuario.BuscarPorId(idUsuario);
            if (usuario == null) throw new KeyNotFoundException("Usuario no encontrado.");
            usuario.Activo = true;
            mppUsuario.Guardar(usuario);
        }

        public List<BEUsuario> ListarUsuarios()
        {
            return mppUsuario.Listar();
        }

        public BEUsuario BuscarUsuarioPorId(int id)
        {
            return mppUsuario.BuscarPorId(id);
        }

        #endregion

        #region Gestión Roles
        public void CrearRol(BERol rol)
        {
            if (rol == null) throw new ArgumentNullException("El rol no puede ser nulo.");
            if (string.IsNullOrWhiteSpace(rol.Nombre)) throw new ArgumentException("El nombre del rol es obligatorio.");
            rol.Activo = true;
            mppRol.GuardarRolBasico(rol);
        }

        public void ModificarRol(BERol rol)
        {
            if (rol == null) throw new ArgumentNullException("El rol no puede ser nulo.");
            if (string.IsNullOrWhiteSpace(rol.Nombre)) throw new ArgumentException("El nombre del rol es obligatorio.");
            var rolExistente = mppRol.ListarRolesBasico().FirstOrDefault(r => r.Id == rol.Id);
            if (rolExistente == null) throw new KeyNotFoundException("Rol no encontrado para modificar.");
            if (rolExistente.Nombre.Equals("Administrador", StringComparison.OrdinalIgnoreCase) &&
                !rol.Nombre.Equals("Administrador", StringComparison.OrdinalIgnoreCase))
            {
                throw new InvalidOperationException("No se puede cambiar el nombre del rol Administrador.");
            }
            mppRol.GuardarRolBasico(rol);
        }

        public void BajaRol(int idRol)
        {
            var rol = mppRol.ListarRolesBasico().FirstOrDefault(r => r.Id == idRol);
            if (rol != null)
            {
                if (rol.Nombre.Equals("Administrador", StringComparison.OrdinalIgnoreCase))
                {
                    throw new InvalidOperationException("No se puede dar de baja al rol Administrador.");
                }
                var usuariosConRol = mppUsuarioRol.ObtenerIdsUsuariosDeRol(idRol);
                var usuariosActivos = mppUsuario.Listar().Where(u => u.Activo).Select(u => u.Id);
                if (usuariosConRol.Any(idUser => usuariosActivos.Contains(idUser)))
                {
                    throw new InvalidOperationException("No se puede dar de baja el rol porque está asignado a usuarios activos.");
                }
                rol.Activo = false;
                mppRol.GuardarRolBasico(rol);
            }
        }

        public void ReactivarRol(int idRol)
        {
            var rol = mppRol.ListarRolesBasico().FirstOrDefault(r => r.Id == idRol);
            if (rol == null) throw new KeyNotFoundException("Rol no encontrado.");
            rol.Activo = true;
            mppRol.GuardarRolBasico(rol);
        }

        public List<BERol> ListarRoles()
        {
            return mppRol.ListarRolesBasico().Where(r => r.Activo).ToList();
        }

        public List<BERol> ListarTodosRoles()
        {
            return mppRol.ListarRolesBasico();
        }

        #endregion

        #region Gestión Permisos y Asignación


        public List<BEPermisoComponent> ObtenerDefinicionesPermisos()
        {
            return mppPermiso.ListarDefiniciones();
        }

        public BERol ObtenerRolConPermisos(int idRol)
        {
            return mppRol.ObtenerRolConPermisos(idRol);
        }

        public void AsignarPermisosARol(int idRol, List<BEPermisoComponent> permisos)
        {
            var rol = mppRol.ListarRolesBasico().FirstOrDefault(r => r.Id == idRol);
            if (rol == null) throw new KeyNotFoundException("Rol no encontrado.");
            if (rol.Nombre.Equals("Administrador", StringComparison.OrdinalIgnoreCase))
            {
                throw new InvalidOperationException("No se pueden modificar los permisos del rol Administrador.");
            }

            // 1. Obtiene la lista jerárquica (con grupos)
            var todasLasDefiniciones = ObtenerDefinicionesPermisos();
            // 2. Aplana la lista para obtener solo los permisos simples (hojas)
            var permisosDefinidos = ObtenerPermisosSimplesRecursivo(todasLasDefiniciones).Select(p => p.NombreInterno).ToList();

            // 3. Obtiene las hojas de la lista de permisos a asignar
            var permisosSimplesAAsignar = ObtenerPermisosSimplesRecursivo(permisos);

            // 4. Valida que las hojas a asignar existan en la lista de hojas definidas
            foreach (var pAsignar in permisosSimplesAAsignar)
            {
                if (!permisosDefinidos.Contains(pAsignar.NombreInterno))
                    throw new KeyNotFoundException($"El permiso '{pAsignar.Nombre}' (Interno: {pAsignar.NombreInterno}) no es un permiso válido definido en el sistema.");
            }

            // 5. Guarda la lista de hojas
            mppRol.GuardarPermisosParaRol(idRol, rol.Nombre, permisosSimplesAAsignar.ToList());
        }

        public List<BERol> ObtenerTodosRolesConPermisos()
        {
            return mppRol.ListarRolesConPermisos();
        }

        #endregion

        #region Gestión Usuario-Rol


        public void AsignarRolAUsuario(int idUsuario, int idRol)
        {
            var usuario = mppUsuario.BuscarPorId(idUsuario);
            if (usuario == null || !usuario.Activo) throw new KeyNotFoundException("Usuario no encontrado o inactivo.");
            var rol = mppRol.ListarRolesBasico().FirstOrDefault(r => r.Id == idRol);
            if (rol == null || !rol.Activo) throw new KeyNotFoundException("Rol no encontrado o inactivo.");
            mppUsuarioRol.Asociar(idUsuario, idRol);
        }

        public void QuitarRolDeUsuario(int idUsuario, int idRol)
        {
            var usuario = mppUsuario.BuscarPorId(idUsuario);
            var rol = mppRol.ListarRolesBasico().FirstOrDefault(r => r.Id == idRol);
            if (usuario != null && usuario.NombreUsuario.Equals("admin", StringComparison.OrdinalIgnoreCase) &&
                rol != null && rol.Nombre.Equals("Administrador", StringComparison.OrdinalIgnoreCase))
            {
                throw new InvalidOperationException("No se puede quitar el rol Administrador al usuario admin.");
            }
            mppUsuarioRol.Desasociar(idUsuario, idRol);
        }

        public List<BERol> ObtenerRolesDeUsuario(int idUsuario)
        {
            var idsRoles = mppUsuarioRol.ObtenerIdsRolesDeUsuario(idUsuario);
            if (!idsRoles.Any()) return new List<BERol>();
            return idsRoles.Select(id => ObtenerRolConPermisos(id))
                          .Where(r => r != null && r.Activo)
                          .ToList();
        }

        public List<BEPermisoComponent> ObtenerPermisosUsuario(int idUsuario)
        {
            var roles = ObtenerRolesDeUsuario(idUsuario);
            var permisosConsolidados = new HashSet<BEPermisoComponent>();
            foreach (var rol in roles)
            {
                foreach (var permiso in rol.Permisos)
                {
                    permisosConsolidados.Add(permiso);
                }
            }
            return permisosConsolidados.OrderBy(p => p.Nombre).ToList();
        }

        public bool UsuarioTienePermiso(int idUsuario, string nombreInternoPermiso)
        {
            if (string.IsNullOrWhiteSpace(nombreInternoPermiso)) return false;
            var permisosUsuario = ObtenerPermisosUsuario(idUsuario);
            return permisosUsuario.Any(p => p.NombreInterno.Equals(nombreInternoPermiso, StringComparison.OrdinalIgnoreCase));
        }

        #endregion

        #region

        // Método para encriptar
        public static string EncriptarClave(string rawData)
        {
            if (string.IsNullOrEmpty(rawData)) return string.Empty;
            byte[] encrypted = Encoding.UTF8.GetBytes(rawData);
            return Convert.ToBase64String(encrypted);
        }

        // Método para "desencriptar" una clave de Base64
        public static string DesencriptarClave(string cadenaADesencriptar)
        {
            if (string.IsNullOrEmpty(cadenaADesencriptar)) return string.Empty;
            try
            {
                byte[] decrypted = Convert.FromBase64String(cadenaADesencriptar);
                return Encoding.UTF8.GetString(decrypted);
            }
            catch (FormatException)
            {
                return cadenaADesencriptar;
            }
        }

        #endregion


        #region Métodos Auxiliares

        /// <summary>
        /// Recorre una lista de componentes (que pueden ser hojas o grupos)
        /// y devuelve una lista plana que contiene solo las hojas (BEPermiso).
        /// </summary>
        private IEnumerable<BEPermisoComponent> ObtenerPermisosSimplesRecursivo(IEnumerable<BEPermisoComponent> componentes)
        {
            foreach (var comp in componentes ?? Enumerable.Empty<BEPermisoComponent>())
            {
                if (comp is BEPermiso)
                {
                    yield return comp;
                }
                else if (comp is BECategoriaPermiso)
                {
                    foreach (var hoja in ObtenerPermisosSimplesRecursivo(comp.ObtenerHijos()))
                    {
                        yield return hoja;
                    }
                }
            }
        }
        #endregion
    }
}