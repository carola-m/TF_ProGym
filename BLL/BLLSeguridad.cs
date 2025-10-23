using BE;
using MPP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography; // Para encriptación más segura
using System.Text; // Para encriptación


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

            // Verifica si el usuario existe, está activo y la contraseña coincide
            if (usuario != null && usuario.Activo && VerificarPassword(password, usuario.Password))
            {
                return usuario;
            }
            return null; // Usuario no encontrado, inactivo o contraseña incorrecta
        }

        public void CrearUsuario(BEUsuario usuario)
        {
            if (usuario == null) throw new ArgumentNullException("El usuario no puede ser nulo.");
            if (string.IsNullOrWhiteSpace(usuario.NombreUsuario)) throw new ArgumentException("El nombre de usuario es obligatorio.");
            if (string.IsNullOrWhiteSpace(usuario.Password)) throw new ArgumentException("La contraseña es obligatoria.");
            if (usuario.Password.Length < 4) throw new ArgumentException("La contraseña debe tener al menos 4 caracteres."); // Ejemplo de regla


            // Encripta la contraseña antes de guardarla
            usuario.Password = EncriptarPassword(usuario.Password);
            // Asegura que el estado inicial sea el correcto
            usuario.Activo = true;
            // Forzar cambio de contraseña, excepto para admin
            usuario.DebeCambiarPassword = !usuario.NombreUsuario.Equals("admin", StringComparison.OrdinalIgnoreCase);


            mppUsuario.Guardar(usuario); // Guardar se encarga de verificar duplicados de nombre
        }

        public void ModificarUsuario(BEUsuario usuario, string nuevaPassword = null)
        {
            if (usuario == null) throw new ArgumentNullException("El usuario no puede ser nulo.");
            if (string.IsNullOrWhiteSpace(usuario.NombreUsuario)) throw new ArgumentException("El nombre de usuario es obligatorio.");

            // Busca el usuario existente para no perder datos no modificables aquí (como el ID)
            var usuarioExistente = mppUsuario.BuscarPorId(usuario.Id);
            if (usuarioExistente == null) throw new KeyNotFoundException("Usuario no encontrado para modificar.");

            // Actualiza los campos permitidos
            usuarioExistente.NombreUsuario = usuario.NombreUsuario;
            usuarioExistente.Activo = usuario.Activo; // Permite activar/desactivar
            usuarioExistente.DebeCambiarPassword = usuario.DebeCambiarPassword;


            // Si se proporciona una nueva contraseña, la encripta y actualiza
            if (!string.IsNullOrWhiteSpace(nuevaPassword))
            {
                if (nuevaPassword.Length < 4) throw new ArgumentException("La nueva contraseña debe tener al menos 4 caracteres.");
                usuarioExistente.Password = EncriptarPassword(nuevaPassword);
                // Opcional: Podrías querer resetear DebeCambiarPassword aquí si la cambia un admin
                // usuarioExistente.DebeCambiarPassword = false;
            }
            // Si no se proporciona nueva contraseña, MANTIENE LA EXISTENTE (no la borra)
            else
            {
                // Asegurarse de no perder la contraseña existente si no se pasa una nueva
                usuario.Password = usuarioExistente.Password;
            }


            mppUsuario.Guardar(usuarioExistente); // Guardar maneja la actualización
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
            if (!VerificarPassword(passwordActual, usuario.Password))
                throw new UnauthorizedAccessException("La contraseña actual es incorrecta.");

            // Encriptar y guardar la nueva
            usuario.Password = EncriptarPassword(nuevaPassword);
            usuario.DebeCambiarPassword = false; // Marcar como cambiada
            mppUsuario.Guardar(usuario);
        }


        public void BajaUsuario(int idUsuario) // Baja lógica
        {
            mppUsuario.Eliminar(idUsuario); // El MPP maneja la baja lógica
        }

        public void ReactivarUsuario(int idUsuario)
        {
            var usuario = mppUsuario.BuscarPorId(idUsuario);
            if (usuario == null) throw new KeyNotFoundException("Usuario no encontrado.");
            usuario.Activo = true;
            // Opcional: Forzar cambio de contraseña al reactivar?
            // usuario.DebeCambiarPassword = true;
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
            rol.Activo = true; // Asegurar estado inicial

            mppRol.GuardarRolBasico(rol); // Guarda info básica y crea entrada en RolesPermisos
                                          // Los permisos se asignan por separado
        }

        public void ModificarRol(BERol rol)
        {
            if (rol == null) throw new ArgumentNullException("El rol no puede ser nulo.");
            if (string.IsNullOrWhiteSpace(rol.Nombre)) throw new ArgumentException("El nombre del rol es obligatorio.");

            var rolExistente = mppRol.ListarRolesBasico().FirstOrDefault(r => r.Id == rol.Id);
            if (rolExistente == null) throw new KeyNotFoundException("Rol no encontrado para modificar.");

            // No permitir cambiar nombre de Administrador?
            if (rolExistente.Nombre.Equals("Administrador", StringComparison.OrdinalIgnoreCase) &&
                !rol.Nombre.Equals("Administrador", StringComparison.OrdinalIgnoreCase))
            {
                throw new InvalidOperationException("No se puede cambiar el nombre del rol Administrador.");
            }


            mppRol.GuardarRolBasico(rol); // Guarda info básica y actualiza nombre en RolesPermisos
        }

        public void BajaRol(int idRol) // Baja lógica
        {
            var rol = mppRol.ListarRolesBasico().FirstOrDefault(r => r.Id == idRol);
            if (rol != null)
            {
                if (rol.Nombre.Equals("Administrador", StringComparison.OrdinalIgnoreCase))
                {
                    throw new InvalidOperationException("No se puede dar de baja al rol Administrador.");
                }

                // Validar si está asignado a usuarios ACTIVOS antes de dar de baja lógica
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
            // Devuelve roles activos por defecto
            return mppRol.ListarRolesBasico().Where(r => r.Activo).ToList();
        }

        public List<BERol> ListarTodosRoles() // Incluye inactivos
        {
            return mppRol.ListarRolesBasico();
        }


        #endregion

        #region Gestión Permisos y Asignación

        // Obtiene la lista de definiciones de permisos (hojas)
        public List<BEPermisoComponent> ObtenerDefinicionesPermisos()
        {
            return mppPermiso.ListarDefiniciones();
        }

        // Obtiene un Rol específico con sus permisos (hojas) asignados
        public BERol ObtenerRolConPermisos(int idRol)
        {
            return mppRol.ObtenerRolConPermisos(idRol);
        }


        // Guarda/Actualiza la lista COMPLETA de permisos para un rol
        public void AsignarPermisosARol(int idRol, List<BEPermisoComponent> permisos)
        {
            var rol = mppRol.ListarRolesBasico().FirstOrDefault(r => r.Id == idRol);
            if (rol == null) throw new KeyNotFoundException("Rol no encontrado.");
            if (rol.Nombre.Equals("Administrador", StringComparison.OrdinalIgnoreCase))
            {
                throw new InvalidOperationException("No se pueden modificar los permisos del rol Administrador.");
            }


            // Validar que todos los permisos a asignar existan en la definición
            var permisosDefinidos = ObtenerDefinicionesPermisos().Select(p => p.NombreInterno).ToList();
            var permisosSimplesAAsignar = ObtenerPermisosSimplesRecursivo(permisos); // Asegura que solo sean hojas

            foreach (var pAsignar in permisosSimplesAAsignar)
            {
                if (!permisosDefinidos.Contains(pAsignar.NombreInterno))
                    throw new KeyNotFoundException($"El permiso '{pAsignar.Nombre}' (Interno: {pAsignar.NombreInterno}) no es un permiso válido definido en el sistema.");
            }


            mppRol.GuardarPermisosParaRol(idRol, rol.Nombre, permisosSimplesAAsignar.ToList());
        }


        // Obtiene todos los roles con sus permisos asignados
        public List<BERol> ObtenerTodosRolesConPermisos()
        {
            return mppRol.ListarRolesConPermisos();
        }


        #endregion

        #region Gestión Usuario-Rol

        public void AsignarRolAUsuario(int idUsuario, int idRol)
        {
            // Validar que usuario y rol existan y estén activos
            var usuario = mppUsuario.BuscarPorId(idUsuario);
            if (usuario == null || !usuario.Activo) throw new KeyNotFoundException("Usuario no encontrado o inactivo.");

            var rol = mppRol.ListarRolesBasico().FirstOrDefault(r => r.Id == idRol);
            if (rol == null || !rol.Activo) throw new KeyNotFoundException("Rol no encontrado o inactivo.");


            mppUsuarioRol.Asociar(idUsuario, idRol);
        }

        public void QuitarRolDeUsuario(int idUsuario, int idRol)
        {
            // Validar si es el rol admin del usuario admin (no permitir quitar)
            var usuario = mppUsuario.BuscarPorId(idUsuario);
            var rol = mppRol.ListarRolesBasico().FirstOrDefault(r => r.Id == idRol);

            if (usuario != null && usuario.NombreUsuario.Equals("admin", StringComparison.OrdinalIgnoreCase) &&
                rol != null && rol.Nombre.Equals("Administrador", StringComparison.OrdinalIgnoreCase))
            {
                throw new InvalidOperationException("No se puede quitar el rol Administrador al usuario admin.");
            }

            // Validar que el usuario tenga al menos un rol restante? (depende de la lógica)


            mppUsuarioRol.Desasociar(idUsuario, idRol);
        }

        public List<BERol> ObtenerRolesDeUsuario(int idUsuario)
        {
            var idsRoles = mppUsuarioRol.ObtenerIdsRolesDeUsuario(idUsuario);
            if (!idsRoles.Any()) return new List<BERol>();

            // Carga la info completa (con permisos) de cada rol asignado
            return idsRoles.Select(id => ObtenerRolConPermisos(id))
                          .Where(r => r != null && r.Activo) // Solo roles activos
                          .ToList();
        }

        // Obtiene la lista CONSOLIDADA de permisos SIMPLES (hojas) de un usuario
        public List<BEPermisoComponent> ObtenerPermisosUsuario(int idUsuario)
        {
            var roles = ObtenerRolesDeUsuario(idUsuario); // Obtiene roles activos con sus permisos
            var permisosConsolidados = new HashSet<BEPermisoComponent>(); // HashSet para evitar duplicados

            foreach (var rol in roles)
            {
                // Asegurarse de que rol.Permisos contenga solo BEPermiso (hojas)
                // La carga en MPPRol->ObtenerRolConPermisos debería garantizar esto.
                foreach (var permiso in rol.Permisos) // Asumiendo que rol.Permisos ya son las hojas
                {
                    permisosConsolidados.Add(permiso);
                }
            }

            return permisosConsolidados.OrderBy(p => p.Nombre).ToList(); // Devuelve lista ordenada
        }

        // Verifica si un usuario tiene un permiso específico (por NombreInterno)
        public bool UsuarioTienePermiso(int idUsuario, string nombreInternoPermiso)
        {
            if (string.IsNullOrWhiteSpace(nombreInternoPermiso)) return false;
            var permisosUsuario = ObtenerPermisosUsuario(idUsuario);
            return permisosUsuario.Any(p => p.NombreInterno.Equals(nombreInternoPermiso, StringComparison.OrdinalIgnoreCase));
        }


        #endregion

        // Asegúrate de tener esto al principio de BLLSeguridad.cs:
        // using BCryptNet = BCrypt.Net.BCrypt; // Alias para evitar colisiones si hubiera otra clase BCrypt

        #region Encriptación Segura (BCrypt)

        // Encripta usando BCrypt con un work factor (costo) adecuado
        private string EncriptarPassword(string passwordPlana)
        {
            if (string.IsNullOrEmpty(passwordPlana)) return string.Empty;
            // El work factor (ej. 11 o 12) determina la "lentitud" del hash. Más alto = más seguro pero más lento.
            // BCrypt genera y almacena la "sal" automáticamente dentro del hash resultante.
            return BCrypt.Net.BCrypt.HashPassword(passwordPlana, workFactor: 11);
        }

        // Verifica si la contraseña ingresada coincide con el hash almacenado
        private bool VerificarPassword(string passwordIngresada, string hashAlmacenado)
        {
            if (string.IsNullOrEmpty(passwordIngresada) || string.IsNullOrEmpty(hashAlmacenado))
                return false;

            try
            {
                // BCrypt.Verify extrae la sal del hashAlmacenado y la usa para hashear la passwordIngresada
                return BCrypt.Net.BCrypt.Verify(passwordIngresada, hashAlmacenado);
            }
            catch (Exception ex) // Captura posibles errores de BCrypt (ej. hash mal formado)
            {
                Console.WriteLine($"Error al verificar password: {ex.Message}");
                return false;
            }
        }

        #endregion

        #region Métodos Auxiliares

        // Método auxiliar recursivo para obtener solo los permisos simples (hojas) de una lista
        private IEnumerable<BEPermisoComponent> ObtenerPermisosSimplesRecursivo(IEnumerable<BEPermisoComponent> componentes)
        {
            foreach (var comp in componentes ?? Enumerable.Empty<BEPermisoComponent>())
            {
                if (comp is BEPermiso) // Si es un permiso simple (hoja)
                {
                    yield return comp;
                }
                else if (comp is BECategoriaPermiso) // Si es una categoría (compuesto)
                {
                    // Llama recursivamente para obtener las hojas dentro de la categoría
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