using BE;
using System.Globalization;
using System.Xml.Linq;


namespace MPP
{
    public class MPPLiquidacion
    {
        private readonly string archivo = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "datos", "Liquidaciones.xml");
        private readonly XmlHelper.XmlHelper xmlHelper;

        public MPPLiquidacion()
        {
            xmlHelper = new XmlHelper.XmlHelper();
            if (!File.Exists(archivo))
            {
                var doc = new XDocument(new XElement("Liquidaciones"));
                doc.Save(archivo);
            }
        }

        private int ObtenerNuevoId(XElement root)
        {
            return root.Elements("Liquidacion")
                       .Select(x => (int?)x.Element("Id") ?? 0)
                       .DefaultIfEmpty(0)
                       .Max() + 1;
        }

        public void Guardar(BELiquidacion liquidacion)
        {
            var doc = XDocument.Load(archivo);
            var root = doc.Element("Liquidaciones");
            var mppProfesional = new MPPProfesional();
            if (mppProfesional.BuscarPorId(liquidacion.IdProfesional) == null)
            {
                throw new KeyNotFoundException($"El Profesional con Id {liquidacion.IdProfesional} no existe.");
            }


            var existente = root.Elements("Liquidacion").FirstOrDefault(x => (int?)x.Element("Id") == liquidacion.Id);

            XElement nodoDetalle = new XElement("TurnosLiquidados",
                liquidacion.TurnosLiquidados.Select(t => new XElement("TurnoLiquidado",
                    new XElement("IdTurno", t.IdTurno),
                    new XElement("FechaHora", t.FechaHora.ToString("o")),
                    new XElement("NombreActividad", t.NombreActividad),
                    new XElement("ValorTurno", t.ValorTurno)
                ))
            );

            //REVISAR
            if (existente != null)
            {
                // Generalmente las liquidaciones no se editan, se anulan y se crean nuevas
                // Pero si necesitaras editar:
                existente.SetElementValue("IdProfesional", liquidacion.IdProfesional);
                existente.SetElementValue("PeriodoDesde", liquidacion.PeriodoDesde.ToString("yyyy-MM-dd"));
                existente.SetElementValue("PeriodoHasta", liquidacion.PeriodoHasta.ToString("yyyy-MM-dd"));
                existente.SetElementValue("MontoTotal", liquidacion.MontoTotal);
                existente.SetElementValue("FechaEmision", liquidacion.FechaEmision.ToString("o"));
                // Reemplazar detalle
                existente.Element("TurnosLiquidados")?.Remove();
                existente.Add(nodoDetalle);

            }
            else
            {
                liquidacion.Id = ObtenerNuevoId(root);
                liquidacion.FechaEmision = DateTime.Now; 
                XElement nuevo = new XElement("Liquidacion",
                    new XElement("Id", liquidacion.Id),
                    new XElement("IdProfesional", liquidacion.IdProfesional),
                    new XElement("PeriodoDesde", liquidacion.PeriodoDesde.ToString("yyyy-MM-dd")), 
                    new XElement("PeriodoHasta", liquidacion.PeriodoHasta.ToString("yyyy-MM-dd")), 
                    new XElement("MontoTotal", liquidacion.MontoTotal),
                    new XElement("FechaEmision", liquidacion.FechaEmision.ToString("o")),
                    nodoDetalle 
                );
                root.Add(nuevo);
            }
            doc.Save(archivo);
        }

  

        public List<BELiquidacion> Listar()
        {
            List<BELiquidacion> lista = new List<BELiquidacion>();
            if (!File.Exists(archivo)) return lista;
            var doc = xmlHelper.CargarXml(archivo);
            if (doc.Root == null) return lista;

          
            var profesionales = new MPPProfesional().Listar().ToDictionary(p => p.Id);
         

            foreach (var nodo in doc.Root.Elements("Liquidacion")) 
            {
                var liquidacion = new BELiquidacion
                {
                    Id = (int?)nodo.Element("Id") ?? 0,
                    IdProfesional = (int?)nodo.Element("IdProfesional") ?? 0,
                    PeriodoDesde = DateTime.ParseExact((string)nodo.Element("PeriodoDesde"), "yyyy-MM-dd", CultureInfo.InvariantCulture),
                    PeriodoHasta = DateTime.ParseExact((string)nodo.Element("PeriodoHasta"), "yyyy-MM-dd", CultureInfo.InvariantCulture),
                    MontoTotal = (decimal?)nodo.Element("MontoTotal") ?? 0m,
                    FechaEmision = DateTime.ParseExact((string)nodo.Element("FechaEmision"), "o", CultureInfo.InvariantCulture, DateTimeStyles.RoundtripKind),
                    TurnosLiquidados = nodo.Element("TurnosLiquidados")?
                                       .Elements("TurnoLiquidado")
                                       .Select(t => new TurnoLiquidado
                                       {
                                           IdTurno = (int?)t.Element("IdTurno") ?? 0,
                                           FechaHora = DateTime.ParseExact((string)t.Element("FechaHora"), "o", CultureInfo.InvariantCulture, DateTimeStyles.RoundtripKind),
                                           NombreActividad = (string)t.Element("NombreActividad"),
                                           ValorTurno = (decimal?)t.Element("ValorTurno") ?? 0m
                                       }).ToList() ?? new List<TurnoLiquidado>()
                };

                if (profesionales.ContainsKey(liquidacion.IdProfesional))
                {
                    liquidacion.Profesional = profesionales[liquidacion.IdProfesional];
                }
       

                lista.Add(liquidacion);
            }
            return lista;
        }

        public void Eliminar(int idLiquidacion)
        {
            var doc = XDocument.Load(archivo);
            var liquidacion = doc.Descendants("Liquidacion")
                                 .FirstOrDefault(l => (int?)l.Element("Id") == idLiquidacion);
            liquidacion?.Remove();
            doc.Save(archivo);
        }

        public BELiquidacion BuscarPorId(int id)
        {
            var doc = xmlHelper.CargarXml(archivo);
            if (doc.Root == null) return null;
            var nodo = doc.Root.Elements("Liquidacion").FirstOrDefault(l => (int?)l.Element("Id") == id);

            if (nodo != null)
            {
                var liquidacion = new BELiquidacion
                {
                    Id = (int?)nodo.Element("Id") ?? 0,
                    IdProfesional = (int?)nodo.Element("IdProfesional") ?? 0,
                    PeriodoDesde = DateTime.ParseExact((string)nodo.Element("PeriodoDesde"), "yyyy-MM-dd", CultureInfo.InvariantCulture),
                    PeriodoHasta = DateTime.ParseExact((string)nodo.Element("PeriodoHasta"), "yyyy-MM-dd", CultureInfo.InvariantCulture),
                    MontoTotal = (decimal?)nodo.Element("MontoTotal") ?? 0m,
                    FechaEmision = DateTime.ParseExact((string)nodo.Element("FechaEmision"), "o", CultureInfo.InvariantCulture, DateTimeStyles.RoundtripKind),
                    TurnosLiquidados = nodo.Element("TurnosLiquidados")?
                                      .Elements("TurnoLiquidado")
                                      .Select(t => new TurnoLiquidado
                                      {
                                          IdTurno = (int?)t.Element("IdTurno") ?? 0,
                                          FechaHora = DateTime.ParseExact((string)t.Element("FechaHora"), "o", CultureInfo.InvariantCulture, DateTimeStyles.RoundtripKind),
                                          NombreActividad = (string)t.Element("NombreActividad"),
                                          ValorTurno = (decimal?)t.Element("ValorTurno") ?? 0m
                                      }).ToList() ?? new List<TurnoLiquidado>()
                };

                liquidacion.Profesional = new MPPProfesional().BuscarPorId(liquidacion.IdProfesional);

                return liquidacion;
            }
            return null;
        }

        // Método para buscar liquidaciones por profesional y/o período
        public List<BELiquidacion> Buscar(int? idProfesional = null, DateTime? desde = null, DateTime? hasta = null)
        {
            var query = Listar().AsQueryable(); 

            if (idProfesional.HasValue)
            {
                query = query.Where(l => l.IdProfesional == idProfesional.Value);
            }
            if (desde.HasValue)
            {
                query = query.Where(l => l.PeriodoDesde.Date >= desde.Value.Date);
            }
            if (hasta.HasValue)
            {
                query = query.Where(l => l.PeriodoHasta.Date <= hasta.Value.Date);
            }

            return query.OrderByDescending(l => l.FechaEmision).ToList(); 
        }
    }
}