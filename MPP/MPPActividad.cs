using BE;
using System.Xml.Linq;

namespace MPP
{
    public class MPPActividad
    {
        private readonly string archivo = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "datos", "Actividades.xml");
        private readonly XmlHelper.XmlHelper xmlHelper;

        public MPPActividad()
        {
            xmlHelper = new XmlHelper.XmlHelper();
            if (!File.Exists(archivo))
            {
                var doc = new XDocument(new XElement("Actividades"));
                doc.Save(archivo);
            }
        }

        private int ObtenerNuevoId(XElement root)
        {
            return root.Elements("Actividad")
                       .Select(x => (int?)x.Element("Id") ?? 0)
                       .DefaultIfEmpty(0)
                       .Max() + 1;
        }

        public void Guardar(BEActividad actividad)
        {
            var doc = XDocument.Load(archivo);
            var root = doc.Element("Actividades");

            // Validar nombre duplicado
            var duplicado = root.Elements("Actividad")
                .FirstOrDefault(x => ((string)x.Element("Nombre")).Equals(actividad.Nombre, StringComparison.OrdinalIgnoreCase)
                                     && (int?)x.Element("Id") != actividad.Id);
            if (duplicado != null) throw new Exception($"Ya existe una actividad con el nombre '{actividad.Nombre}'.");


            var existente = root.Elements("Actividad").FirstOrDefault(x => (int?)x.Element("Id") == actividad.Id);

            if (existente != null)
            {
                existente.SetElementValue("Nombre", actividad.Nombre);
                existente.SetElementValue("Descripcion", actividad.Descripcion);
                existente.SetElementValue("CupoMaximo", actividad.CupoMaximo);
                existente.SetElementValue("TarifaPorTurno", actividad.TarifaPorTurno);
            }
            else
            {
                actividad.Id = ObtenerNuevoId(root);
                XElement nuevo = new XElement("Actividad",
                    new XElement("Id", actividad.Id),
                    new XElement("Nombre", actividad.Nombre),
                    new XElement("Descripcion", actividad.Descripcion),
                    new XElement("CupoMaximo", actividad.CupoMaximo),
                    new XElement("TarifaPorTurno", actividad.TarifaPorTurno)
                );
                root.Add(nuevo);
            }
            doc.Save(archivo);
        }

        public List<BEActividad> Listar()
        {
            List<BEActividad> lista = new List<BEActividad>();
            if (!File.Exists(archivo)) return lista;
            var doc = XDocument.Load(archivo);

            foreach (var nodo in doc.Descendants("Actividad"))
            {
                lista.Add(new BEActividad
                {
                    Id = (int?)nodo.Element("Id") ?? 0,
                    Nombre = (string)nodo.Element("Nombre"),
                    Descripcion = (string)nodo.Element("Descripcion"),
                    CupoMaximo = (int?)nodo.Element("CupoMaximo") ?? 0,
                    TarifaPorTurno = (decimal?)nodo.Element("TarifaPorTurno") ?? 0m
                });
            }
            return lista;
        }

        public void Eliminar(int idActividad)
        {
            var doc = XDocument.Load(archivo);
            var actividad = doc.Descendants("Actividad")
                               .FirstOrDefault(a => (int?)a.Element("Id") == idActividad);
            actividad?.Remove();
            doc.Save(archivo);
        }

        public BEActividad BuscarPorId(int id)
        {
            if (!File.Exists(archivo)) return null;
            var doc = XDocument.Load(archivo);
            var nodo = doc.Descendants("Actividad").FirstOrDefault(a => (int?)a.Element("Id") == id);
            if (nodo != null)
            {
                return new BEActividad
                {
                    Id = (int?)nodo.Element("Id") ?? 0,
                    Nombre = (string)nodo.Element("Nombre"),
                    Descripcion = (string)nodo.Element("Descripcion"),
                    CupoMaximo = (int?)nodo.Element("CupoMaximo") ?? 0,
                    TarifaPorTurno = (decimal?)nodo.Element("TarifaPorTurno") ?? 0m
                };
            }
            return null;
        }
    }
}