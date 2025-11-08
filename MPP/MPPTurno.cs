using BE;
using XmlHelper;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Xml.Linq;
using XmlHelper;

namespace MPP
{
    public class MPPTurno
    {
        private readonly string archivo = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "datos", "Turnos.xml");
        private readonly XmlHelper.XmlHelper xmlHelper;

        // Rutas a otros archivos para validaciones/referencias
        private readonly string archivoActividades = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "datos", "Actividades.xml");
        private readonly string archivoProfesionales = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "datos", "Profesionales.xml");
        private readonly string archivoClientes = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "datos", "Clientes.xml");


        public MPPTurno()
        {
            xmlHelper = new XmlHelper.XmlHelper();
            if (!File.Exists(archivo))
            {
                var doc = new XDocument(new XElement("Turnos"));
                doc.Save(archivo);
            }
            if (!File.Exists(archivoActividades)) new XDocument(new XElement("Actividades")).Save(archivoActividades);
            if (!File.Exists(archivoProfesionales)) new XDocument(new XElement("Profesionales")).Save(archivoProfesionales);
            if (!File.Exists(archivoClientes)) new XDocument(new XElement("Clientes")).Save(archivoClientes);
        }

        private int ObtenerNuevoId(XElement root)
        {
            return root.Elements("Turno")
                       .Select(x => (int?)x.Element("Id") ?? 0)
                       .DefaultIfEmpty(0)
                       .Max() + 1;
        }

        public void Guardar(BETurno turno)
        {
            var doc = XDocument.Load(archivo);
            var root = doc.Element("Turnos");

            // --- Validaciones de existencia de IDs referenciados ---
            // Validar Actividad
            var docActividades = XDocument.Load(archivoActividades);
            if (!docActividades.Descendants("Actividad").Any(a => (int?)a.Element("Id") == turno.IdActividad))
                throw new KeyNotFoundException($"La Actividad con Id {turno.IdActividad} no existe.");

            // Validar Profesional
            var docProfesionales = XDocument.Load(archivoProfesionales);
            if (!docProfesionales.Descendants("Profesional").Any(p => (int?)p.Element("Id") == turno.IdProfesional))
                throw new KeyNotFoundException($"El Profesional con Id {turno.IdProfesional} no existe.");

            // Validar Clientes inscritos 
            if (turno.IdClientesInscritos.Any())
            {
                var docClientes = XDocument.Load(archivoClientes);
                var idsClientesExistentes = docClientes.Descendants("Cliente").Select(c => (int?)c.Element("Id") ?? 0).ToList();
                foreach (var idCliente in turno.IdClientesInscritos)
                {
                    if (!idsClientesExistentes.Contains(idCliente))
                        throw new KeyNotFoundException($"El Cliente con Id {idCliente} no existe.");
                }
            }


            var existente = root.Elements("Turno").FirstOrDefault(x => (int?)x.Element("Id") == turno.Id);

            // Nodo para los clientes inscritos
            XElement nodoClientes = new XElement("IdClientesInscritos",
                turno.IdClientesInscritos.Select(id => new XElement("IdCliente", id)));


            if (existente != null)
            {
                existente.SetElementValue("IdActividad", turno.IdActividad);
                existente.SetElementValue("IdProfesional", turno.IdProfesional);
                existente.SetElementValue("FechaHoraInicio", turno.FechaHoraInicio.ToString("o"));
                existente.SetElementValue("FechaHoraFin", turno.FechaHoraFin.ToString("o"));
                existente.Element("IdClientesInscritos")?.Remove();
                existente.Add(nodoClientes);

            }
            else
            {
                turno.Id = ObtenerNuevoId(root);
                XElement nuevo = new XElement("Turno",
                    new XElement("Id", turno.Id),
                    new XElement("IdActividad", turno.IdActividad),
                    new XElement("IdProfesional", turno.IdProfesional),
                    new XElement("FechaHoraInicio", turno.FechaHoraInicio.ToString("o")),
                    new XElement("FechaHoraFin", turno.FechaHoraFin.ToString("o")),
                    nodoClientes 
                );
                root.Add(nuevo);
            }
            doc.Save(archivo);
        }

        public List<BETurno> Listar()
        {
            List<BETurno> lista = new List<BETurno>();
            if (!File.Exists(archivo)) return lista;
            var doc = XDocument.Load(archivo);

            // Precargar datos relacionados para eficiencia
            var actividades = new MPPActividad().Listar().ToDictionary(a => a.Id);
            var profesionales = new MPPProfesional().Listar().ToDictionary(p => p.Id);

            foreach (var nodo in doc.Descendants("Turno"))
            {
                var turno = new BETurno
                {
                    Id = (int?)nodo.Element("Id") ?? 0,
                    IdActividad = (int?)nodo.Element("IdActividad") ?? 0,
                    IdProfesional = (int?)nodo.Element("IdProfesional") ?? 0,
                    FechaHoraInicio = DateTime.ParseExact((string)nodo.Element("FechaHoraInicio"), "o", CultureInfo.InvariantCulture, DateTimeStyles.RoundtripKind),
                    FechaHoraFin = DateTime.ParseExact((string)nodo.Element("FechaHoraFin"), "o", CultureInfo.InvariantCulture, DateTimeStyles.RoundtripKind),
                    // Cargar IDs de clientes
                    IdClientesInscritos = nodo.Element("IdClientesInscritos")?
                                           .Elements("IdCliente")
                                           .Select(el => (int?)el ?? 0)
                                           .Where(id => id != 0)
                                           .ToList() ?? new List<int>()
                };

                // Enlazar objetos relacionados si existen en los diccionarios
                if (actividades.ContainsKey(turno.IdActividad))
                    turno.Actividad = actividades[turno.IdActividad];
                if (profesionales.ContainsKey(turno.IdProfesional))
                    turno.Profesional = profesionales[turno.IdProfesional];


                lista.Add(turno);
            }
            return lista;
        }

        public void Eliminar(int idTurno)
        {
            var doc = XDocument.Load(archivo);
            var turno = doc.Descendants("Turno").FirstOrDefault(t => (int?)t.Element("Id") == idTurno);
            turno?.Remove();
            doc.Save(archivo);
        }

        public BETurno BuscarPorId(int id)
        {
            if (!File.Exists(archivo)) return null;
            var doc = XDocument.Load(archivo);
            var nodo = doc.Descendants("Turno").FirstOrDefault(t => (int?)t.Element("Id") == id);

            if (nodo != null)
            {
                var turno = new BETurno
                {
                    Id = (int?)nodo.Element("Id") ?? 0,
                    IdActividad = (int?)nodo.Element("IdActividad") ?? 0,
                    IdProfesional = (int?)nodo.Element("IdProfesional") ?? 0,
                    FechaHoraInicio = DateTime.ParseExact((string)nodo.Element("FechaHoraInicio"), "o", CultureInfo.InvariantCulture, DateTimeStyles.RoundtripKind),
                    FechaHoraFin = DateTime.ParseExact((string)nodo.Element("FechaHoraFin"), "o", CultureInfo.InvariantCulture, DateTimeStyles.RoundtripKind),
                    IdClientesInscritos = nodo.Element("IdClientesInscritos")?
                                           .Elements("IdCliente")
                                           .Select(el => (int?)el ?? 0)
                                           .Where(idC => idC != 0)
                                           .ToList() ?? new List<int>()
                };
                turno.Actividad = new MPPActividad().BuscarPorId(turno.IdActividad);
                turno.Profesional = new MPPProfesional().BuscarPorId(turno.IdProfesional);
                return turno;
            }
            return null;
        }

        // Método para agregar un cliente a un turno (reserva)
        public void AgregarClienteTurno(int idTurno, int idCliente)
        {
            var turno = BuscarPorId(idTurno);
            if (turno == null) throw new KeyNotFoundException("Turno no encontrado.");
            if (turno.Actividad == null) throw new InvalidOperationException("El turno no tiene una actividad asociada válida.");

            // Validar si el cliente existe
            var cliente = new MPPCliente().Listar().FirstOrDefault(c => c.Id == idCliente); 
            if (cliente == null) throw new KeyNotFoundException("Cliente no encontrado.");


            if (turno.IdClientesInscritos.Contains(idCliente))
                throw new InvalidOperationException("El cliente ya está inscrito en este turno.");

            if (turno.CuposOcupados >= turno.Actividad.CupoMaximo)
                throw new InvalidOperationException("No hay cupos disponibles para este turno.");

            turno.IdClientesInscritos.Add(idCliente);
            Guardar(turno); // Guardar actualiza el turno existente
        }

        // Método para quitar un cliente de un turno (cancelación)
        public void QuitarClienteTurno(int idTurno, int idCliente)
        {
            var turno = BuscarPorId(idTurno);
            if (turno == null) throw new KeyNotFoundException("Turno no encontrado.");

            if (!turno.IdClientesInscritos.Contains(idCliente))
                throw new InvalidOperationException("El cliente no está inscrito en este turno.");

            turno.IdClientesInscritos.Remove(idCliente);
            Guardar(turno); // Guardar actualiza el turno existente
        }

    }
}