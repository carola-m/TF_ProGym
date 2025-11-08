
using System.Xml.Linq;

namespace XmlHelper
{
    public class XmlHelper
    {
        // Define la ruta base a la carpeta 'datos'
        private readonly string basePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "datos");

        public XmlHelper()
        {
            Directory.CreateDirectory(basePath);
        }

        // Método genérico para crear un archivo XML inicial si no existe
        public void AsegurarArchivoXml(string nombreArchivo, string rootElement)
        {
            string filePath = Path.Combine(basePath, nombreArchivo);
            if (!File.Exists(filePath))
            {
                var xmlDoc = new XDocument(new XElement(rootElement));
                try
                {
                    xmlDoc.Save(filePath);
                }
                catch (IOException ex)
                {
                    Console.WriteLine($"Error al crear archivo XML inicial '{filePath}': {ex.Message}");
                    throw;
                }
            }
        }

        // Carga un documento XML desde una ruta completa
        public XDocument CargarXml(string filePath)
        {
            // Verifica que la carpeta exista antes de intentar cargar
            string directory = Path.GetDirectoryName(filePath);
            if (!Directory.Exists(directory))
            {
                throw new DirectoryNotFoundException($"El directorio '{directory}' para el archivo XML no existe.");
            }


            if (File.Exists(filePath))
            {
                try
                {
                    // Carga el documento
                    return XDocument.Load(filePath);
                }
                catch (System.Xml.XmlException ex)
                {
                    // Manejar XML mal formado
                    Console.WriteLine($"Error al cargar XML mal formado '{filePath}': {ex.Message}");
                    // intentar renombrar el archivo corrupto y crear uno nuevo
                    // File.Move(filePath, filePath + ".corrupt." + DateTime.Now.ToString("yyyyMMddHHmmss"));
                    // return new XDocument(new XElement(Path.GetFileNameWithoutExtension(filePath) + "s")); // Crear uno nuevo vacío
                    throw; 
                }
                catch (IOException ex)
                {
                    // Manejar error de lectura 
                    Console.WriteLine($"Error de IO al cargar archivo XML '{filePath}': {ex.Message}");
                    throw;
                }

            }
            else
            {
                // Si el archivo no existe, devuelve un documento vacío con el nodo raíz esperado
                string rootName = Path.GetFileNameWithoutExtension(filePath);
                // Si el archivo esperado tiene un nombre raíz diferente
                if (rootName.EndsWith("y")) 
                    rootName = rootName.Substring(0, rootName.Length - 1) + "ies";
                else if (!rootName.EndsWith("s")) 
                    rootName += "s";

                Console.WriteLine($"Advertencia: Archivo XML '{filePath}' no encontrado. Se creará uno nuevo con raíz '<{rootName}>'.");
                return new XDocument(new XElement(rootName)); 

            }
        }

        // Guarda un documento XML en una ruta completa
        public void GuardarXml(XDocument xmlDoc, string filePath)
        {
            if (xmlDoc == null) throw new ArgumentNullException(nameof(xmlDoc), "El documento XML no puede ser nulo.");
            // Asegura que el directorio exista antes de guardar
            string directory = Path.GetDirectoryName(filePath);
            Directory.CreateDirectory(directory); // Crea si no existe


            try
            {
                xmlDoc.Save(filePath);
            }
            catch (IOException ex)
            {
                // Manejar error de escritura
                Console.WriteLine($"Error de IO al guardar archivo XML '{filePath}': {ex.Message}");
                throw;
            }
            catch (UnauthorizedAccessException ex)
            {
                // Manejar error de permisos
                Console.WriteLine($"Error de permisos al guardar archivo XML '{filePath}': {ex.Message}");
                throw;
            }

        }
    }
}