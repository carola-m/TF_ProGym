using BE;
using System.Xml.Linq;


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

        // Lee la estructura JERÁRQUICA de permisos desde Permisos.xml
        public List<BEPermisoComponent> ListarDefiniciones()
        {
            if (!File.Exists(archivo)) return new List<BEPermisoComponent>();
            var doc = XDocument.Load(archivo);

            // Inicia el parseo desde la raíz
            return ParsearNodos(doc.Root.Elements());
        }

 
        // Método recursivo para parsear el XML
        private List<BEPermisoComponent> ParsearNodos(IEnumerable<XElement> elementos)
        {
            var lista = new List<BEPermisoComponent>();

            foreach (var nodo in elementos)
            {
                if (nodo.Name == "Categoria")
                {
                    // GRUPO (BECategoriaPermiso)
                    var categoria = new BECategoriaPermiso
                    {
                        Id = (int?)nodo.Attribute("Id") ?? 0,
                        Nombre = (string)nodo.Attribute("Nombre"),
                        NombreInterno = (string)nodo.Attribute("NombreInterno")
                    };

                    // Llama recursivamente para buscar a sus hijos
                    foreach (var hijo in ParsearNodos(nodo.Elements()))
                    {
                        categoria.AgregarHijo(hijo);
                    }
                    lista.Add(categoria);
                }
                else if (nodo.Name == "Permiso")
                {
                    // HOJA (BEPermiso)
                    lista.Add(new BEPermiso
                    {
                        Id = (int?)nodo.Attribute("Id") ?? 0,
                        Nombre = (string)nodo.Attribute("Nombre"),
                        NombreInterno = (string)nodo.Attribute("NombreInterno")
                    });
                }
            }
            return lista;
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

    }
}