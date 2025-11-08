
using BE;
using System.Globalization;
using System.Xml.Linq;

namespace MPP
{
    public class MPPBitacora
    {
        private readonly string archivo;
        private readonly XmlHelper.XmlHelper xmlHelper;

        public MPPBitacora()
        {
            string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
            string dataDirectory = Path.Combine(baseDirectory, "datos");
            archivo = Path.Combine(dataDirectory, "Bitacora.xml"); // Ruta completa

            xmlHelper = new XmlHelper.XmlHelper();
            xmlHelper.AsegurarArchivoXml("Bitacora.xml", "Bitacoras");
        }

        private int ObtenerNuevoId(XElement root)
        {
            if (root == null || !root.HasElements) return 1;
            return root.Elements("Bitacora")
                       .Select(x => (int?)x.Element("Id") ?? 0)
                       .DefaultIfEmpty(0)
                       .Max() + 1;
        }

        public void Guardar(BEBitacora entrada)
        {
            var doc = xmlHelper.CargarXml(archivo);
            var root = doc.Root;
            if (root == null)
            {
                root = new XElement("Bitacoras");
                doc.Add(root);
            }


            entrada.Id = ObtenerNuevoId(root); // Asignar ID autoincremental

            XElement nuevaEntrada = new XElement("Bitacora",
                new XElement("Id", entrada.Id),
                // Usar formato ISO 8601 para fechas
                new XElement("FechaRegistro", entrada.FechaRegistro.ToString("o", CultureInfo.InvariantCulture)),
                new XElement("Detalle", entrada.Detalle ?? string.Empty), // Backup o Restore
                new XElement("IdUsuario", entrada.IdUsuario),
                new XElement("NombreUsuario", entrada.NombreUsuario ?? string.Empty),
                new XElement("NombreArchivo", entrada.NombreArchivo ?? string.Empty) // Carpeta/Archivo del backup/restore
            );

            root.Add(nuevaEntrada);
            xmlHelper.GuardarXml(doc, archivo);
        }

        public List<BEBitacora> Listar()
        {
            List<BEBitacora> lista = new List<BEBitacora>();
            var doc = xmlHelper.CargarXml(archivo);
            if (doc == null || doc.Root == null) return lista;


            foreach (var nodo in doc.Root.Elements("Bitacora"))
            {
                try
                {
                    lista.Add(new BEBitacora
                    {
                        Id = (int?)nodo.Element("Id") ?? 0,
                        // Parsear fecha desde formato ISO 8601
                        FechaRegistro = DateTime.ParseExact((string)nodo.Element("FechaRegistro"), "o", CultureInfo.InvariantCulture, DateTimeStyles.RoundtripKind),
                        Detalle = (string)nodo.Element("Detalle"),
                        IdUsuario = (int?)nodo.Element("IdUsuario") ?? 0,
                        NombreUsuario = (string)nodo.Element("NombreUsuario"),
                        NombreArchivo = (string)nodo.Element("NombreArchivo")
                    });
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error parseando entrada Bitacora (Id: {(int?)nodo.Element("Id") ?? -1}): {ex.Message}");
                }
            }
            return lista.OrderByDescending(b => b.FechaRegistro).ToList(); // Ordenar por fecha descendente
        }
    }
}