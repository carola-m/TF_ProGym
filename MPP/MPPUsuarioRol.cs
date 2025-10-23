using BE;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Linq;
using XmlHelper;

namespace MPP
{
    public class MPPUsuarioRol
    {
        private readonly string archivo = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "datos", "UsuarioRol.xml");
        private readonly XmlHelper.XmlHelper xmlHelper;
        // Rutas para validación
        private readonly string archivoUsuarios = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "datos", "Usuarios.xml");
        private readonly string archivoRoles = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "datos", "Roles.xml");


        public MPPUsuarioRol()
        {
            xmlHelper = new XmlHelper.XmlHelper();
            if (!File.Exists(archivo))
            {
                var doc = new XDocument(new XElement("UsuarioRoles"));
                doc.Save(archivo);
            }
            // Asegurar que existan archivos referenciados
            if (!File.Exists(archivoUsuarios)) new XDocument(new XElement("Usuarios")).Save(archivoUsuarios);
            if (!File.Exists(archivoRoles)) new XDocument(new XElement("Roles")).Save(archivoRoles);
        }

        // Asocia un usuario a un rol
        public void Asociar(int idUsuario, int idRol)
        {
            // --- Validaciones ---
            var docUsuarios = XDocument.Load(archivoUsuarios);
            if (!docUsuarios.Root.Elements("Usuario").Any(u => (int?)u.Element("Id") == idUsuario))
                throw new KeyNotFoundException($"Usuario con Id {idUsuario} no encontrado.");

            var docRoles = XDocument.Load(archivoRoles);
            if (!docRoles.Root.Elements("Rol").Any(r => (int?)r.Element("Id") == idRol))
                throw new KeyNotFoundException($"Rol con Id {idRol} no encontrado.");
            // --- Fin Validaciones ---


            var doc = XDocument.Load(archivo);
            var root = doc.Element("UsuarioRoles");

            // Evitar duplicados
            bool yaExiste = root.Elements("UsuarioRol")
                               .Any(ur => (int?)ur.Attribute("usuarioId") == idUsuario && (int?)ur.Attribute("rolId") == idRol);

            if (!yaExiste)
            {
                root.Add(new XElement("UsuarioRol",
                    new XAttribute("usuarioId", idUsuario),
                    new XAttribute("rolId", idRol)
                ));
                doc.Save(archivo);
            }
            // else { podrías lanzar excepción o ignorar si ya existe }
        }

        // Desasocia un usuario de un rol específico
        public void Desasociar(int idUsuario, int idRol)
        {
            if (!File.Exists(archivo)) return;
            var doc = XDocument.Load(archivo);
            doc.Root.Elements("UsuarioRol")
                .Where(ur => (int?)ur.Attribute("usuarioId") == idUsuario && (int?)ur.Attribute("rolId") == idRol)
                .Remove();
            doc.Save(archivo);
        }

        // Desasocia un usuario de TODOS los roles
        public void DesasociarDeTodosRoles(int idUsuario)
        {
            if (!File.Exists(archivo)) return;
            var doc = XDocument.Load(archivo);
            doc.Root.Elements("UsuarioRol")
                .Where(ur => (int?)ur.Attribute("usuarioId") == idUsuario)
                .Remove();
            doc.Save(archivo);
        }

        // Desasocia un rol de TODOS los usuarios
        public void DesasociarRolDeTodosUsuarios(int idRol)
        {
            if (!File.Exists(archivo)) return;
            var doc = XDocument.Load(archivo);
            doc.Root.Elements("UsuarioRol")
                .Where(ur => (int?)ur.Attribute("rolId") == idRol)
                .Remove();
            doc.Save(archivo);
        }


        // Obtiene la lista de IDs de Roles asociados a un Usuario
        public List<int> ObtenerIdsRolesDeUsuario(int idUsuario)
        {
            if (!File.Exists(archivo)) return new List<int>();
            var doc = XDocument.Load(archivo);
            return doc.Root.Elements("UsuarioRol")
                      .Where(ur => (int?)ur.Attribute("usuarioId") == idUsuario)
                      .Select(ur => (int?)ur.Attribute("rolId") ?? 0)
                      .Where(id => id != 0) // Filtra posibles errores
                      .Distinct() // Asegura que no haya IDs duplicados
                      .ToList();
        }

        // Obtiene la lista de IDs de Usuarios asociados a un Rol
        public List<int> ObtenerIdsUsuariosDeRol(int idRol)
        {
            if (!File.Exists(archivo)) return new List<int>();
            var doc = XDocument.Load(archivo);
            return doc.Root.Elements("UsuarioRol")
                      .Where(ur => (int?)ur.Attribute("rolId") == idRol)
                      .Select(ur => (int?)ur.Attribute("usuarioId") ?? 0)
                      .Where(id => id != 0)
                      .Distinct()
                      .ToList();
        }

        // Verifica si un usuario tiene un rol específico
        public bool UsuarioTieneRol(int idUsuario, int idRol)
        {
            if (!File.Exists(archivo)) return false;
            var doc = XDocument.Load(archivo);
            return doc.Root.Elements("UsuarioRol")
                      .Any(ur => (int?)ur.Attribute("usuarioId") == idUsuario && (int?)ur.Attribute("rolId") == idRol);
        }
    }
}