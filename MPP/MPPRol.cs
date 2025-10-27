using BE;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Linq;
using XmlHelper; 

namespace MPP
{
    public class MPPRol
    {
        private readonly XmlHelper.XmlHelper xmlHelper = new XmlHelper.XmlHelper();
        private readonly string basePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "datos");
        private readonly string rolFilePath; // Archivo solo con info básica del rol (Id, Nombre, Activo)
        private readonly string rolPermisoFilePath; // Archivo que relaciona Roles con Permisos
        private readonly string usuarioRolFilePath; // Archivo que relaciona Usuarios con Roles
        private readonly string permisoFilePath; // Archivo que define los Permisos

        public MPPRol()
        {
            rolFilePath = Path.Combine(basePath, "Roles.xml");
            rolPermisoFilePath = Path.Combine(basePath, "RolesPermisos.xml"); // Nuevo archivo para la relación
            usuarioRolFilePath = Path.Combine(basePath, "UsuarioRol.xml");
            permisoFilePath = Path.Combine(basePath, "Permisos.xml"); // Necesario para buscar permisos

            // Asegurar que los archivos XML necesarios existan
            if (!File.Exists(rolFilePath)) CrearArchivoXmlInicial(rolFilePath, "Roles");
            if (!File.Exists(rolPermisoFilePath)) CrearArchivoXmlInicial(rolPermisoFilePath, "RolesPermisos");
            if (!File.Exists(usuarioRolFilePath)) CrearArchivoXmlInicial(usuarioRolFilePath, "UsuarioRoles");
            if (!File.Exists(permisoFilePath)) CrearArchivoXmlPermisosInicial(permisoFilePath); // Crear con permisos base
        }

        private void CrearArchivoXmlInicial(string filePath, string rootElement)
        {
            var xmlDoc = new XDocument(new XElement(rootElement));
            xmlDoc.Save(filePath);
        }

        // Método específico para crear el archivo de permisos con una estructura inicial si no existe
        private void CrearArchivoXmlPermisosInicial(string filePath)
        {
            // Define aquí tu estructura inicial de permisos y categorías si lo deseas
            // Ejemplo simple:
            var xmlDoc = new XDocument(
                new XElement("Permisos",
                    // Permisos Simples
                    new XElement("Permiso", new XAttribute("Id", "1"), new XAttribute("Nombre", "Gestionar Clientes"), new XAttribute("NombreInterno", "PERM_GEST_CLIENTES")),
                    new XElement("Permiso", new XAttribute("Id", "2"), new XAttribute("Nombre", "Gestionar Profesionales"), new XAttribute("NombreInterno", "PERM_GEST_PROFESIONALES")),
                    new XElement("Permiso", new XAttribute("Id", "3"), new XAttribute("Nombre", "Gestionar Actividades"), new XAttribute("NombreInterno", "PERM_GEST_ACTIVIDADES")),
                    new XElement("Permiso", new XAttribute("Id", "4"), new XAttribute("Nombre", "Gestionar Turnos"), new XAttribute("NombreInterno", "PERM_GEST_TURNOS")),
                    new XElement("Permiso", new XAttribute("Id", "5"), new XAttribute("Nombre", "Registrar Asistencia"), new XAttribute("NombreInterno", "PERM_REG_ASISTENCIA")),
                    new XElement("Permiso", new XAttribute("Id", "6"), new XAttribute("Nombre", "Calcular Liquidaciones"), new XAttribute("NombreInterno", "PERM_CALC_LIQ")),
                    new XElement("Permiso", new XAttribute("Id", "7"), new XAttribute("Nombre", "Emitir Liquidaciones"), new XAttribute("NombreInterno", "PERM_EMIT_LIQ")),
                    new XElement("Permiso", new XAttribute("Id", "8"), new XAttribute("Nombre", "Consultar Dashboard"), new XAttribute("NombreInterno", "PERM_VER_DASHBOARD")),
                     new XElement("Permiso", new XAttribute("Id", "9"), new XAttribute("Nombre", "Gestionar Usuarios y Roles"), new XAttribute("NombreInterno", "PERM_GEST_SEGURIDAD"))
                // Podrías añadir categorías aquí si usas el Composite en XML,
                // pero es más fácil manejarlo en código o con un archivo de relaciones separado
                )
            );
            xmlDoc.Save(filePath);

            // Crear Rol Administrador inicial en Roles.xml y RolesPermisos.xml
            CrearRolAdminInicial();

        }

        // Crea el rol Admin y le asigna todos los permisos iniciales
        // En MPP/MPPRol.cs

        // Crea el rol Admin y le asigna todos los permisos iniciales
        private void CrearRolAdminInicial()
        {
            // 1. Crear Rol Admin en Roles.xml
            if (!File.Exists(rolFilePath)) CrearArchivoXmlInicial(rolFilePath, "Roles");
            var docRoles = XDocument.Load(rolFilePath);
            if (!docRoles.Root.Elements("Rol").Any(r => (string)r.Element("Nombre") == "Administrador"))
            {
                int adminId = ObtenerSiguienteIdRol(docRoles.Root);
                docRoles.Root.Add(new XElement("Rol",
                    new XElement("Id", adminId),
                    new XElement("Nombre", "Administrador"),
                    new XElement("Activo", true)
                ));
                docRoles.Save(rolFilePath);

                // 2. Asignar todos los permisos al Rol Admin en RolesPermisos.xml
                if (!File.Exists(rolPermisoFilePath)) CrearArchivoXmlInicial(rolPermisoFilePath, "RolesPermisos");
                var docRolPerm = XDocument.Load(rolPermisoFilePath);
                var docPermisos = XDocument.Load(permisoFilePath); // Carga los permisos definidos

                // Elimina cualquier entrada previa para Admin para evitar duplicados
                docRolPerm.Root.Elements("RolPermiso")
                   .Where(rp => (int?)rp.Element("Rol")?.Element("Id") == adminId)
                   .Remove();


                var permisosAdmin = new XElement("Permisos");
                // Agrega todos los permisos simples definidos en Permisos.xml
                foreach (var permElem in docPermisos.Root.Elements("Permiso"))
                {
                    permisosAdmin.Add(new XElement("Permiso",
                        new XAttribute("Id", (string)permElem.Attribute("Id")),
                        new XAttribute("NombreInterno", (string)permElem.Attribute("NombreInterno"))
                    ));
                }

                // --- INICIO DE LA CORRECCIÓN ---
                // El nodo 'permisosAdmin' debe estar DENTRO del nodo 'Rol'
                docRolPerm.Root.Add(new XElement("RolPermiso",
                    new XElement("Rol",
                        new XElement("Id", adminId),
                        new XElement("Nombre", "Administrador"),
                        permisosAdmin  // <--- ESTA ES LA POSICIÓN CORRECTA
                    )
                // (Se elimina 'permisosAdmin' de aquí fuera)
                ));
                // --- FIN DE LA CORRECCIÓN ---

                docRolPerm.Save(rolPermisoFilePath);

                // 3. Opcional: Asignar Rol Admin al usuario 'admin' en UsuarioRol.xml
                if (!File.Exists(usuarioRolFilePath)) CrearArchivoXmlInicial(usuarioRolFilePath, "UsuarioRoles");
                var docUserRol = XDocument.Load(usuarioRolFilePath);

                // Usamos una nueva instancia de MPPUsuario aquí como la usabas antes
                var userAdmin = new MPPUsuario().BuscarPorNombre("admin");

                if (userAdmin != null && !docUserRol.Root.Elements("UsuarioRol")
                                            .Any(ur => (int?)ur.Attribute("usuarioId") == userAdmin.Id && (int?)ur.Attribute("rolId") == adminId))
                {
                    docUserRol.Root.Add(new XElement("UsuarioRol",
                        new XAttribute("usuarioId", userAdmin.Id),
                        new XAttribute("rolId", adminId)
                    ));
                    docUserRol.Save(usuarioRolFilePath);
                }
            }
        }


        private int ObtenerSiguienteIdRol(XElement root)
        {
            return root.Elements("Rol")
                       .Select(x => (int?)x.Element("Id") ?? 0)
                       .DefaultIfEmpty(0)
                       .Max() + 1;
        }


        // Obtiene la lista básica de roles (Id, Nombre, Activo)
        public List<BERol> ListarRolesBasico()
        {
            if (!File.Exists(rolFilePath)) return new List<BERol>();
            var doc = XDocument.Load(rolFilePath);
            return doc.Descendants("Rol")
                      .Select(r => new BERol
                      {
                          Id = (int?)r.Element("Id") ?? 0,
                          Nombre = (string)r.Element("Nombre"),
                          Activo = (bool?)r.Element("Activo") ?? true
                      }).ToList();
        }

        // Guarda la información básica del Rol en Roles.xml
        public void GuardarRolBasico(BERol rol)
        {
            var doc = XDocument.Load(rolFilePath);
            var root = doc.Element("Roles");

            // Validar nombre único
            var duplicado = root.Elements("Rol")
                                .FirstOrDefault(r => ((string)r.Element("Nombre")).Equals(rol.Nombre, StringComparison.OrdinalIgnoreCase)
                                                     && (int?)r.Element("Id") != rol.Id);
            if (duplicado != null) throw new Exception($"Ya existe un rol con el nombre '{rol.Nombre}'.");


            var existente = root.Elements("Rol").FirstOrDefault(r => (int?)r.Element("Id") == rol.Id);

            if (existente != null) // Actualizar
            {
                existente.SetElementValue("Nombre", rol.Nombre);
                existente.SetElementValue("Activo", rol.Activo);
            }
            else // Crear
            {
                rol.Id = ObtenerSiguienteIdRol(root);
                root.Add(new XElement("Rol",
                    new XElement("Id", rol.Id),
                    new XElement("Nombre", rol.Nombre),
                    new XElement("Activo", rol.Activo)
                ));
            }
            doc.Save(rolFilePath);

            // Si es un rol nuevo, crea una entrada vacía en RolesPermisos.xml
            if (existente == null)
            {
                GuardarPermisosParaRol(rol.Id, rol.Nombre, new List<BEPermisoComponent>());
            }
            else // Si se actualiza el nombre, actualizarlo también en RolesPermisos.xml
            {
                ActualizarNombreRolEnPermisos(rol.Id, rol.Nombre);
            }

        }

        // Elimina el rol de Roles.xml y sus asociaciones de RolesPermisos.xml y UsuarioRol.xml
        public void EliminarRolCompleto(int idRol)
        {
            // 0. Validar si es el rol Administrador
            var rol = ListarRolesBasico().FirstOrDefault(r => r.Id == idRol);
            if (rol != null && rol.Nombre.Equals("Administrador", StringComparison.OrdinalIgnoreCase))
            {
                throw new InvalidOperationException("No se puede eliminar el rol Administrador.");
            }


            // 1. Validar si está asignado a usuarios
            if (File.Exists(usuarioRolFilePath))
            {
                var docUserRol = XDocument.Load(usuarioRolFilePath);
                if (docUserRol.Root.Elements("UsuarioRol").Any(ur => (int?)ur.Attribute("rolId") == idRol))
                {
                    throw new InvalidOperationException("No se puede eliminar el rol porque está asignado a uno o más usuarios.");
                }
            }

            // 2. Eliminar de Roles.xml
            var docRoles = XDocument.Load(rolFilePath);
            docRoles.Root.Elements("Rol").FirstOrDefault(r => (int?)r.Element("Id") == idRol)?.Remove();
            docRoles.Save(rolFilePath);

            // 3. Eliminar de RolesPermisos.xml
            if (File.Exists(rolPermisoFilePath))
            {
                var docRolPerm = XDocument.Load(rolPermisoFilePath);
                docRolPerm.Root.Elements("RolPermiso")
                          .FirstOrDefault(rp => (int?)rp.Element("Rol")?.Element("Id") == idRol)?.Remove();
                docRolPerm.Save(rolPermisoFilePath);
            }
        }

        // Guarda/Actualiza la lista de permisos para un rol en RolesPermisos.xml
        public void GuardarPermisosParaRol(int idRol, string nombreRol, List<BEPermisoComponent> permisos)
        {
            if (!File.Exists(rolPermisoFilePath)) CrearArchivoXmlInicial(rolPermisoFilePath, "RolesPermisos");
            var doc = XDocument.Load(rolPermisoFilePath);

            // Elimina la entrada existente para ese rol
            doc.Root.Elements("RolPermiso")
                .FirstOrDefault(rp => (int?)rp.Element("Rol")?.Element("Id") == idRol)?.Remove();

            // Crea la nueva entrada
            var nuevoRolPermiso = new XElement("RolPermiso",
                new XElement("Rol",
                    new XElement("Id", idRol),
                    new XElement("Nombre", nombreRol) // Guarda el nombre actual
                ),
                new XElement("Permisos")
            );

            // Agrega los permisos (solo los simples/hojas)
            var permisosElement = nuevoRolPermiso.Element("Rol").Element("Permisos");
            foreach (var permiso in ObtenerPermisosSimplesRecursivo(permisos)) // Obtiene solo las hojas
            {
                permisosElement.Add(new XElement("Permiso",
                     new XAttribute("Id", permiso.Id), // Guarda Id y NombreInterno
                    new XAttribute("NombreInterno", permiso.NombreInterno)
                 ));
            }


            doc.Root.Add(nuevoRolPermiso);
            doc.Save(rolPermisoFilePath);
        }

        // Obtiene el Rol con su lista de permisos cargada
        public BERol ObtenerRolConPermisos(int idRol)
        {
            var rolBasico = ListarRolesBasico().FirstOrDefault(r => r.Id == idRol);
            if (rolBasico == null) return null;

            if (File.Exists(rolPermisoFilePath))
            {
                var docRolPerm = XDocument.Load(rolPermisoFilePath);
                var rolPermisoElement = docRolPerm.Root.Elements("RolPermiso")
                                           .FirstOrDefault(rp => (int?)rp.Element("Rol")?.Element("Id") == idRol);

                if (rolPermisoElement != null)
                {
                    // Se busca "Permisos" DENTRO de "Rol"
                    var permisosGuardados = rolPermisoElement.Element("Rol")?.Element("Permisos")?.Elements("Permiso") ?? Enumerable.Empty<XElement>();

                    var nombresInternosPermisos = permisosGuardados.Select(p => (string)p.Attribute("NombreInterno")).ToList();

                    var todosLosPermisosDefinidos = CargarDefinicionPermisos();

                    rolBasico.Permisos = todosLosPermisosDefinidos
                        .Where(p => nombresInternosPermisos.Contains(p.NombreInterno))
                        .Select(p => new BEPermiso { Id = p.Id, Nombre = p.Nombre, NombreInterno = p.NombreInterno })
                        .ToList<BEPermiso>();
                }
            }
            return rolBasico;
        }

        // Carga la definición de todos los permisos simples desde Permisos.xml
        private List<BEPermiso> CargarDefinicionPermisos()
        {
            if (!File.Exists(permisoFilePath)) return new List<BEPermiso>();
            var docPermisos = XDocument.Load(permisoFilePath);
            return docPermisos.Root.Elements("Permiso") // Asume estructura simple
                              .Select(p => new BEPermiso
                              {
                                  Id = (int?)p.Attribute("Id") ?? 0,
                                  Nombre = (string)p.Attribute("Nombre"),
                                  NombreInterno = (string)p.Attribute("NombreInterno")
                              })
                              .Where(p => p.Id != 0 && !string.IsNullOrEmpty(p.NombreInterno)) // Filtra inválidos
                              .ToList();
        }

        // Obtiene todos los roles con sus permisos cargados
        public List<BERol> ListarRolesConPermisos()
        {
            var rolesBasicos = ListarRolesBasico();
            var rolesConPermisos = new List<BERol>();

            foreach (var rolB in rolesBasicos)
            {
                // Reutiliza ObtenerRolConPermisos para cargar los permisos de cada uno
                var rolCompleto = ObtenerRolConPermisos(rolB.Id);
                if (rolCompleto != null) // Debería encontrarlo siempre si existe en Roles.xml
                {
                    rolesConPermisos.Add(rolCompleto);
                }
            }
            return rolesConPermisos;
        }


        // Método auxiliar recursivo para obtener solo los permisos simples (hojas)
        private IEnumerable<BEPermisoComponent> ObtenerPermisosSimplesRecursivo(IEnumerable<BEPermisoComponent> componentes)
        {
            foreach (var comp in componentes)
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

        // Método para actualizar el nombre del rol en RolesPermisos.xml si cambia en Roles.xml
        private void ActualizarNombreRolEnPermisos(int idRol, string nuevoNombre)
        {
            if (!File.Exists(rolPermisoFilePath)) return;
            var doc = XDocument.Load(rolPermisoFilePath);
            var rolPermisoElement = doc.Root.Elements("RolPermiso")
                                       .FirstOrDefault(rp => (int?)rp.Element("Rol")?.Element("Id") == idRol);
            if (rolPermisoElement != null)
            {
                rolPermisoElement.Element("Rol")?.SetElementValue("Nombre", nuevoNombre);
                doc.Save(rolPermisoFilePath);
            }
        }
    }
}