using BE;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text; // <--- Añade este using
using System.Xml.Linq;
using XmlHelper;

namespace MPP
{
    public class MPPUsuario
    {
        private readonly string archivo; // = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "datos", "Usuarios.xml");
        private readonly string archivoUsuarioRol; // = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "datos", "UsuarioRol.xml");
        private readonly XmlHelper.XmlHelper xmlHelper;

        // En MPP/MPPUsuario.cs

        public MPPUsuario()
        {
            xmlHelper = new XmlHelper.XmlHelper();

            // Define las rutas en el constructor
            string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
            string dataDirectory = Path.Combine(baseDirectory, "datos");
            archivo = Path.Combine(dataDirectory, "Usuarios.xml");
            archivoUsuarioRol = Path.Combine(dataDirectory, "UsuarioRol.xml");

            // Asegura que la carpeta 'datos' exista y los archivos
            xmlHelper.AsegurarArchivoXml("Usuarios.xml", "Usuarios");
            xmlHelper.AsegurarArchivoXml("UsuarioRol.xml", "UsuarioRoles");

            // Verifica si el archivo de usuarios está *vacío* (recién creado)
            var doc = xmlHelper.CargarXml(archivo);
            if (doc.Root != null && !doc.Root.HasElements)
            {
                // --- INICIO DE CORRECCIÓN (Encriptación Base64) ---
                string adminPasswordPlana = "admin";

                // CORRECCIÓN: Hacemos la encriptación aquí mismo, sin llamar a BLL
                string adminPasswordBase64 = Convert.ToBase64String(Encoding.UTF8.GetBytes(adminPasswordPlana));

                var adminUser = new XElement("Usuario",
                    new XElement("Id", 1),
                    new XElement("NombreUsuario", "admin"),
                    new XElement("Password", adminPasswordBase64), // Guarda la clave en Base64
                    new XElement("DebeCambiarPassword", false),
                    new XElement("Activo", true));

                doc.Root.Add(adminUser);
                xmlHelper.GuardarXml(doc, archivo);
            }
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
            var doc = xmlHelper.CargarXml(archivo);
            if (doc.Root == null) return new List<BEUsuario>();

            return doc.Root.Elements("Usuario") // Cambiado de Descendants a Elements
                         .Select(u => MapearElementoAUsuario(u))
                         .ToList();
        }

        public void Guardar(BEUsuario usuario)
        {
            var doc = xmlHelper.CargarXml(archivo);
            var root = doc.Element("Usuarios");
            if (root == null)
            {
                root = new XElement("Usuarios");
                doc.Add(root);
            }

            var duplicado = root.Elements("Usuario")
                                .FirstOrDefault(u => ((string)u.Element("NombreUsuario")).Equals(usuario.NombreUsuario, StringComparison.OrdinalIgnoreCase)
                                                     && (int?)u.Element("Id") != usuario.Id);
            if (duplicado != null) throw new Exception($"Ya existe un usuario con el nombre '{usuario.NombreUsuario}'.");

            var existente = root.Elements("Usuario").FirstOrDefault(u => (int?)u.Element("Id") == usuario.Id);

            if (existente != null) // Actualizar
            {
                existente.SetElementValue("NombreUsuario", usuario.NombreUsuario);
                // BLLSeguridad ya debe pasar la contraseña encriptada (Base64)
                if (!string.IsNullOrEmpty(usuario.Password))
                {
                    existente.SetElementValue("Password", usuario.Password);
                }
                existente.SetElementValue("DebeCambiarPassword", usuario.DebeCambiarPassword);
                existente.SetElementValue("Activo", usuario.Activo);
            }
            else // Crear nuevo
            {
                usuario.Id = ObtenerNuevoId(root);
                if (!usuario.NombreUsuario.Equals("admin", StringComparison.OrdinalIgnoreCase))
                {
                    usuario.DebeCambiarPassword = true;
                }
                root.Add(new XElement("Usuario",
                    new XElement("Id", usuario.Id),
                    new XElement("NombreUsuario", usuario.NombreUsuario),
                    new XElement("Password", usuario.Password), // BLL debe pasarla encriptada (Base64)
                    new XElement("DebeCambiarPassword", usuario.DebeCambiarPassword),
                    new XElement("Activo", usuario.Activo)
                 ));
            }
            xmlHelper.GuardarXml(doc, archivo);
        }

        public void Eliminar(int idUsuario) // Baja lógica
        {
            var usuario = BuscarPorId(idUsuario);
            if (usuario != null)
            {
                if (usuario.NombreUsuario.Equals("admin", StringComparison.OrdinalIgnoreCase))
                {
                    throw new InvalidOperationException("No se puede eliminar al usuario administrador.");
                }
                usuario.Activo = false; // Baja lógica
                Guardar(usuario);
            }
        }

        public BEUsuario BuscarPorNombre(string nombreUsuario)
        {
            var doc = xmlHelper.CargarXml(archivo);
            if (doc.Root == null) return null;
            var usuarioElement = doc.Root.Elements("Usuario")
                                    .FirstOrDefault(u => ((string)u.Element("NombreUsuario")).Equals(nombreUsuario, StringComparison.OrdinalIgnoreCase));

            return MapearElementoAUsuario(usuarioElement);
        }

        public BEUsuario BuscarPorId(int idUsuario)
        {
            var doc = xmlHelper.CargarXml(archivo);
            if (doc.Root == null) return null;
            var usuarioElement = doc.Root.Elements("Usuario")
                                   .FirstOrDefault(u => (int?)u.Element("Id") == idUsuario);
            return MapearElementoAUsuario(usuarioElement);
        }

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