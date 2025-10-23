using BE;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Xml.Linq;
using XmlHelper;

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

            // Validación: Profesional existe? (Podría ir en BLL)
            var mppProfesional = new MPPProfesional();
            if (mppProfesional.BuscarPorId(liquidacion.IdProfesional) == null)
            {
                throw new KeyNotFoundException($"El Profesional con Id {liquidacion.IdProfesional} no existe.");
            }


            var existente = root.Elements("Liquidacion").FirstOrDefault(x => (int?)x.Element("Id") == liquidacion.Id);

            // Nodo para el detalle de turnos liquidados
            XElement nodoDetalle = new XElement("TurnosLiquidados",
                liquidacion.TurnosLiquidados.Select(t => new XElement("TurnoLiquidado",
                    new XElement("IdTurno", t.IdTurno),
                    new XElement("FechaHora", t.FechaHora.ToString("o")),
                    new XElement("NombreActividad", t.NombreActividad),
                    new XElement("ValorTurno", t.ValorTurno)
                ))
            );


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
                liquidacion.FechaEmision = DateTime.Now; // Asegurar fecha de emisión al crear
                XElement nuevo = new XElement("Liquidacion",
                    new XElement("Id", liquidacion.Id),
                    new XElement("IdProfesional", liquidacion.IdProfesional),
                    new XElement("PeriodoDesde", liquidacion.PeriodoDesde.ToString("yyyy-MM-dd")), // Solo fecha
                    new XElement("PeriodoHasta", liquidacion.PeriodoHasta.ToString("yyyy-MM-dd")), // Solo fecha
                    new XElement("MontoTotal", liquidacion.MontoTotal),
                    new XElement("FechaEmision", liquidacion.FechaEmision.ToString("o")),
                    nodoDetalle // Agregar detalle
                );
                root.Add(nuevo);
            }
            doc.Save(archivo);
        }

        public List<BELiquidacion> Listar()
        {
            List<BELiquidacion> lista = new List<BELiquidacion>();
            if (!File.Exists(archivo)) return lista;
            var doc = XDocument.Load(archivo);

            // Precargar profesionales para eficiencia
            var profesionales = new MPPProfesional().Listar().ToDictionary(p => p.Id);


            foreach (var nodo in doc.Descendants("Liquidacion"))
            {
                var liquidacion = new BELiquidacion
                {
                    Id = (int?)nodo.Element("Id") ?? 0,
                    IdProfesional = (int?)nodo.Element("IdProfesional") ?? 0,
                    PeriodoDesde = DateTime.ParseExact((string)nodo.Element("PeriodoDesde"), "yyyy-MM-dd", CultureInfo.InvariantCulture),
                    PeriodoHasta = DateTime.ParseExact((string)nodo.Element("PeriodoHasta"), "yyyy-MM-dd", CultureInfo.InvariantCulture),
                    MontoTotal = (decimal?)nodo.Element("MontoTotal") ?? 0m,
                    FechaEmision = DateTime.ParseExact((string)nodo.Element("FechaEmision"), "o", CultureInfo.InvariantCulture, DateTimeStyles.RoundtripKind),
                    // Cargar detalle
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

                // Enlazar profesional
                if (profesionales.ContainsKey(liquidacion.IdProfesional))
                    liquidacion.Profesional = profesionales[liquidacion.IdProfesional];


                lista.Add(liquidacion);
            }
            return lista;
        }

        public void Eliminar(int idLiquidacion)
        {
            // Considerar si realmente se deben poder eliminar liquidaciones emitidas
            // Quizás un estado "Anulada" sería mejor
            var doc = XDocument.Load(archivo);
            var liquidacion = doc.Descendants("Liquidacion")
                                 .FirstOrDefault(l => (int?)l.Element("Id") == idLiquidacion);
            liquidacion?.Remove();
            doc.Save(archivo);
        }

        public BELiquidacion BuscarPorId(int id)
        {
            // Similar a Listar, pero para uno solo
            if (!File.Exists(archivo)) return null;
            var doc = XDocument.Load(archivo);
            var nodo = doc.Descendants("Liquidacion").FirstOrDefault(l => (int?)l.Element("Id") == id);

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
                // Cargar profesional
                liquidacion.Profesional = new MPPProfesional().BuscarPorId(liquidacion.IdProfesional);
                return liquidacion;
            }
            return null;
        }

        // Método para buscar liquidaciones por profesional y/o período
        public List<BELiquidacion> Buscar(int? idProfesional = null, DateTime? desde = null, DateTime? hasta = null)
        {
            var query = Listar().AsQueryable(); // Usa LINQ

            if (idProfesional.HasValue)
            {
                query = query.Where(l => l.IdProfesional == idProfesional.Value);
            }
            if (desde.HasValue)
            {
                // Compara solo la fecha, ignorando la hora
                query = query.Where(l => l.PeriodoDesde.Date >= desde.Value.Date);
            }
            if (hasta.HasValue)
            {
                // Compara solo la fecha, ignorando la hora
                query = query.Where(l => l.PeriodoHasta.Date <= hasta.Value.Date);
            }

            return query.OrderByDescending(l => l.FechaEmision).ToList(); // Ordena por fecha de emisión
        }
    }
}