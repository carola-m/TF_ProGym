using BE;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Linq;
using XmlHelper;

namespace MPP
{
    public class MPPUsuario
    {
        private readonly string archivo = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "datos", "Usuarios.xml");
        private readonly string archivoUsuarioRol = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "datos", "UsuarioRol.xml");
        private readonly XmlHelper.XmlHelper xmlHelper;

        public MPPUsuario()
        {
            xmlHelper = new XmlHelper.XmlHelper();
            if (!File.Exists(archivo))
            {
                var doc = new XDocument(new XElement("Usuarios"));
                // Opcional: Crear usuario admin inicial
                var adminUser = new XElement("Usuario",
                    new XElement("Id", 1),
                    new XElement("NombreUsuario", "admin"),
                    // ¡IMPORTANTE! En un caso real, la contraseña inicial debería ser más segura
                    // y preferiblemente encriptada aquí mismo con una clave conocida o configuración.
                    new XElement("Password", "admin"), // Simplificado para el ejemplo
                    new XElement("DebeCambiarPassword", false), // Admin no necesita cambiarla
                    new XElement("Activo", true));
                doc.Root.Add(adminUser);

                doc.Save(archivo);
            }
            // Asegurarse que el archivo de relaciones exista
            if (!File.Exists(archivoUsuarioRol)) new XDocument(new XElement("UsuarioRoles")).Save(archivoUsuarioRol);
        }

        private int ObtenerNuevoId(XElement root)
        {
            return root.Elements("Usuario")
                       .Select(x => (int?)x.Element("Id") ?? 0)
                       .DefaultIfEmpty(0)
                       .Max() + 1;
        }

        public List<BEUsuario> Listar()
        {
            if (!File.Exists(archivo)) return new List<BEUsuario>();
            var doc = XDocument.Load(archivo);
            return doc.Descendants("Usuario")
                         .Select(u => new BEUsuario
                         {
                             Id = (int?)u.Element("Id") ?? 0,
                             NombreUsuario = (string)u.Element("NombreUsuario"),
                             Password = (string)u.Element("Password"), // Mantenemos la contraseña (posiblemente encriptada)
                             DebeCambiarPassword = (bool?)u.Element("DebeCambiarPassword") ?? false,
                             Activo = (bool?)u.Element("Activo") ?? true // Asume activo si falta el nodo
                         }).ToList();
        }

        public void Guardar(BEUsuario usuario)
        {
            var doc = XDocument.Load(archivo);
            var root = doc.Element("Usuarios");

            // Validar nombre de usuario único
            var duplicado = root.Elements("Usuario")
                                .FirstOrDefault(u => ((string)u.Element("NombreUsuario")).Equals(usuario.NombreUsuario, StringComparison.OrdinalIgnoreCase)
                                                     && (int?)u.Element("Id") != usuario.Id);
            if (duplicado != null) throw new Exception($"Ya existe un usuario con el nombre '{usuario.NombreUsuario}'.");


            var existente = root.Elements("Usuario").FirstOrDefault(u => (int?)u.Element("Id") == usuario.Id);

            if (existente != null) // Actualizar
            {
                existente.SetElementValue("NombreUsuario", usuario.NombreUsuario);
                // Solo actualizar contraseña si se proporciona una nueva (no está vacía)
                if (!string.IsNullOrEmpty(usuario.Password))
                {
                    existente.SetElementValue("Password", usuario.Password); // Guardar la contraseña (ya debería venir encriptada desde BLL)
                }
                existente.SetElementValue("DebeCambiarPassword", usuario.DebeCambiarPassword);
                existente.SetElementValue("Activo", usuario.Activo);

            }
            else // Crear nuevo
            {
                usuario.Id = ObtenerNuevoId(root);
                // Por defecto, al crear, forzar cambio de contraseña (excepto si es 'admin')
                if (!usuario.NombreUsuario.Equals("admin", StringComparison.OrdinalIgnoreCase))
                {
                    usuario.DebeCambiarPassword = true;
                }
                root.Add(new XElement("Usuario",
                    new XElement("Id", usuario.Id),
                    new XElement("NombreUsuario", usuario.NombreUsuario),
                    new XElement("Password", usuario.Password), // Guardar contraseña (encriptada desde BLL)
                    new XElement("DebeCambiarPassword", usuario.DebeCambiarPassword),
                    new XElement("Activo", usuario.Activo)
                 ));
            }
            doc.Save(archivo);
        }

        public void Eliminar(int idUsuario) // Baja lógica por defecto
        {
            var usuario = BuscarPorId(idUsuario);
            if (usuario != null)
            {
                if (usuario.NombreUsuario.Equals("admin", StringComparison.OrdinalIgnoreCase))
                {
                    throw new InvalidOperationException("No se puede eliminar al usuario administrador.");
                }

                usuario.Activo = false; // Baja lógica
                Guardar(usuario); // Reutilizamos Guardar para actualizar el estado

                // Opcional: Eliminar asociaciones de roles (depende de la lógica de negocio)
                // EliminarAsociacionesRoles(idUsuario);
            }

            // Si quisieras eliminación física:
            /*
             var doc = XDocument.Load(archivo);
             var usuarioElement = doc.Descendants("Usuario")
                                     .FirstOrDefault(u => (int?)u.Element("Id") == idUsuario);

              if (usuarioElement != null && ((string)usuarioElement.Element("NombreUsuario")).Equals("admin", StringComparison.OrdinalIgnoreCase))
              {
                  throw new InvalidOperationException("No se puede eliminar al usuario administrador.");
              }

             usuarioElement?.Remove();
             doc.Save(archivo);
             EliminarAsociacionesRoles(idUsuario); // Eliminar relaciones si se borra físicamente
             */
        }

        // Método auxiliar para borrar relaciones Usuario-Rol
        private void EliminarAsociacionesRoles(int idUsuario)
        {
            if (!File.Exists(archivoUsuarioRol)) return;
            var docRoles = XDocument.Load(archivoUsuarioRol);
            docRoles.Root.Elements("UsuarioRol")
                          .Where(ur => (int?)ur.Attribute("usuarioId") == idUsuario)
                          .Remove(); // Elimina todas las asociaciones para ese usuario
            docRoles.Save(archivoUsuarioRol);
        }


        public BEUsuario BuscarPorNombre(string nombreUsuario)
        {
            if (!File.Exists(archivo)) return null;
            var doc = XDocument.Load(archivo);
            var usuarioElement = doc.Descendants("Usuario")
                                    .FirstOrDefault(u => ((string)u.Element("NombreUsuario")).Equals(nombreUsuario, StringComparison.OrdinalIgnoreCase)); // Ignorar mayúsculas/minúsculas

            return MapearElementoAUsuario(usuarioElement);
        }

        public BEUsuario BuscarPorId(int idUsuario)
        {
            if (!File.Exists(archivo)) return null;
            var doc = XDocument.Load(archivo);
            var usuarioElement = doc.Descendants("Usuario")
                                   .FirstOrDefault(u => (int?)u.Element("Id") == idUsuario);
            return MapearElementoAUsuario(usuarioElement);
        }


        // Método auxiliar para convertir XElement a BEUsuario
        private BEUsuario MapearElementoAUsuario(XElement usuarioElement)
        {
            if (usuarioElement == null) return null;

            return new BEUsuario
            {
                Id = (int?)usuarioElement.Element("Id") ?? 0,
                NombreUsuario = (string)usuarioElement.Element("NombreUsuario"),
                Password = (string)usuarioElement.Element("Password"),
                DebeCambiarPassword = (bool?)usuarioElement.Element("DebeCambiarPassword") ?? false,
                Activo = (bool?)usuarioElement.Element("Activo") ?? true
            };
        }
    }
}