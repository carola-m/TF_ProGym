using BE;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Linq;
using XmlHelper;

namespace MPP
{
    public class MPPPermiso
    {
        private readonly string archivo = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "datos", "Permisos.xml");
        private readonly XmlHelper.XmlHelper xmlHelper;

        public MPPPermiso()
        {
            xmlHelper = new XmlHelper.XmlHelper();
            // Asegura que el archivo exista (debería crearlo MPPRol si no existe)
            if (!File.Exists(archivo))
            {
                // Lanza excepción o crea uno vacío (depende de tu lógica)
                // CrearArchivoXmlPermisosInicial(archivo); // Podrías llamar al método de MPPRol si lo haces público/estático
                throw new FileNotFoundException("El archivo de definición de Permisos no existe.", archivo);
            }
        }

        // Lee la estructura plana de permisos desde Permisos.xml
        // NO maneja jerarquía aquí, solo la definición básica.
        public List<BEPermisoComponent> ListarDefiniciones()
        {
            if (!File.Exists(archivo)) return new List<BEPermisoComponent>();
            var doc = XDocument.Load(archivo);
            var lista = new List<BEPermisoComponent>();

            // Asume una estructura plana en Permisos.xml por simplicidad
            foreach (var nodo in doc.Root.Elements("Permiso"))
            {
                // Aquí siempre creamos BEPermiso (hoja), la jerarquía se maneja en BLL o al asignar a roles
                lista.Add(new BEPermiso
                {
                    Id = (int?)nodo.Attribute("Id") ?? 0,
                    Nombre = (string)nodo.Attribute("Nombre"),
                    NombreInterno = (string)nodo.Attribute("NombreInterno") // Importante leer el identificador único
                });
            }
            // Filtra los que no tengan ID o NombreInterno válidos
            return lista.Where(p => p.Id != 0 && !string.IsNullOrEmpty(p.NombreInterno)).ToList();
        }

        // Buscar una definición de permiso por su NombreInterno
        public BEPermisoComponent BuscarDefinicionPorNombreInterno(string nombreInterno)
        {
            return ListarDefiniciones()
                   .FirstOrDefault(p => p.NombreInterno.Equals(nombreInterno, StringComparison.OrdinalIgnoreCase));
        }

        // Buscar una definición de permiso por su ID
        public BEPermisoComponent BuscarDefinicionPorId(int id)
        {
            return ListarDefiniciones().FirstOrDefault(p => p.Id == id);
        }

        // NO hay método Guardar/Eliminar aquí, la definición de permisos se maneja manualmente en el XML
        // o a través de una herramienta de configuración separada.
    }
}