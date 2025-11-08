using BE;
using System.Globalization;
using System.Xml.Linq;

namespace MPP
{
    public class MPPAsistencia
    {
        private readonly string archivo = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "datos", "Asistencias.xml");
        private readonly XmlHelper.XmlHelper xmlHelper;

        public MPPAsistencia()
        {
            xmlHelper = new XmlHelper.XmlHelper();
            if (!File.Exists(archivo))
            {
                var doc = new XDocument(new XElement("Asistencias"));
                doc.Save(archivo);
            }
        }

        private int ObtenerNuevoId(XElement root)
        {
            return root.Elements("Asistencia")
                       .Select(x => (int?)x.Element("Id") ?? 0)
                       .DefaultIfEmpty(0)
                       .Max() + 1;
        }

        public void Guardar(BEAsistencia asistencia)
        {
            var doc = XDocument.Load(archivo);
            var root = doc.Element("Asistencias");

            // Validar si ya existe un registro para este cliente en este turno (para evitar duplicados)
            var existente = root.Elements("Asistencia")
                                .FirstOrDefault(x => (int?)x.Element("IdTurno") == asistencia.IdTurno
                                                   && (int?)x.Element("IdCliente") == asistencia.IdCliente);

            // Si existe, actualizamos el estado (presente/ausente) y la hora
            if (existente != null)
            {
                // Si se guarda un registro existente, usar su ID
                asistencia.Id = (int?)existente.Element("Id") ?? asistencia.Id;
                existente.SetElementValue("FechaHoraRegistro", asistencia.FechaHoraRegistro.ToString("o"));
                existente.SetElementValue("Presente", asistencia.Presente);
            }
            else // Si no existe, es un nuevo registro
            {
                // --- Validaciones de existencia de IDs referenciados ---
                var mppTurno = new MPPTurno(); // Para verificar si el turno existe
                if (mppTurno.BuscarPorId(asistencia.IdTurno) == null)
                    throw new KeyNotFoundException($"El Turno con Id {asistencia.IdTurno} no existe.");

                var mppCliente = new MPPCliente(); // Para verificar si el cliente existe
                if (mppCliente.Listar().All(c => c.Id != asistencia.IdCliente)) 
                    throw new KeyNotFoundException($"El Cliente con Id {asistencia.IdCliente} no existe.");
        

                asistencia.Id = ObtenerNuevoId(root); // Asignar nuevo ID
                XElement nuevo = new XElement("Asistencia",
                    new XElement("Id", asistencia.Id),
                    new XElement("IdTurno", asistencia.IdTurno),
                    new XElement("IdCliente", asistencia.IdCliente),
                    new XElement("FechaHoraRegistro", asistencia.FechaHoraRegistro.ToString("o")),
                    new XElement("Presente", asistencia.Presente)
                );
                root.Add(nuevo);
            }

            doc.Save(archivo);
        }

        public List<BEAsistencia> Listar()
        {
            List<BEAsistencia> lista = new List<BEAsistencia>();
            if (!File.Exists(archivo)) return lista;
            var doc = XDocument.Load(archivo);

            foreach (var nodo in doc.Descendants("Asistencia"))
            {
                var asistencia = new BEAsistencia
                {
                    Id = (int?)nodo.Element("Id") ?? 0,
                    IdTurno = (int?)nodo.Element("IdTurno") ?? 0,
                    IdCliente = (int?)nodo.Element("IdCliente") ?? 0,
                    FechaHoraRegistro = DateTime.ParseExact((string)nodo.Element("FechaHoraRegistro"), "o", CultureInfo.InvariantCulture, DateTimeStyles.RoundtripKind),
                    Presente = (bool?)nodo.Element("Presente") ?? false
                };


                lista.Add(asistencia);
            }
            return lista;
        }

        public void Eliminar(int idAsistencia)
        {
            var doc = XDocument.Load(archivo);
            var asistencia = doc.Descendants("Asistencia")
                                .FirstOrDefault(a => (int?)a.Element("Id") == idAsistencia);
            asistencia?.Remove();
            doc.Save(archivo);
        }

        public List<BEAsistencia> ListarPorTurno(int idTurno)
        {
            return Listar().Where(a => a.IdTurno == idTurno).ToList();
        }

        public List<BEAsistencia> ListarPorCliente(int idCliente)
        {
            return Listar().Where(a => a.IdCliente == idCliente).ToList();
        }

        public BEAsistencia BuscarAsistenciaTurnoCliente(int idTurno, int idCliente)
        {
            return Listar().FirstOrDefault(a => a.IdTurno == idTurno && a.IdCliente == idCliente);
        }
    }
}