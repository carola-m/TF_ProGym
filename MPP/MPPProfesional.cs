using BE;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Linq;
using XmlHelper;

namespace MPP
{
    public class MPPProfesional
    {
        private readonly string archivo = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "datos", "Profesionales.xml");
        private readonly XmlHelper.XmlHelper xmlHelper;

        public MPPProfesional()
        {
            xmlHelper = new XmlHelper.XmlHelper();
            if (!File.Exists(archivo))
            {
                var doc = new XDocument(new XElement("Profesionales"));
                doc.Save(archivo);
            }
        }

        private int ObtenerNuevoId(XElement root)
        {
            return root.Elements("Profesional")
                       .Select(x => (int?)x.Element("Id") ?? 0)
                       .DefaultIfEmpty(0)
                       .Max() + 1;
        }

        public void Guardar(BEProfesional profesional)
        {
            var doc = XDocument.Load(archivo);
            var root = doc.Element("Profesionales");

            var duplicadoDNI = root.Elements("Profesional")
                .FirstOrDefault(x => (string)x.Element("DNI") == profesional.DNI && (int?)x.Element("Id") != profesional.Id);
            if (duplicadoDNI != null) throw new Exception($"Ya existe un profesional con el DNI {profesional.DNI}.");

            var existente = root.Elements("Profesional").FirstOrDefault(x => (int?)x.Element("Id") == profesional.Id);

            XElement nodoIdsActividades = new XElement("IdsActividadesPuedeDictar",
                    profesional.IdsActividadesPuedeDictar.Select(id => new XElement("IdActividad", id)));


            if (existente != null)
            {
                existente.SetElementValue("DNI", profesional.DNI);
                existente.SetElementValue("Nombre", profesional.Nombre);
                existente.SetElementValue("Apellido", profesional.Apellido);
                existente.SetElementValue("Especialidad", profesional.Especialidad);
                existente.SetElementValue("Email", profesional.Email);
                existente.SetElementValue("Telefono", profesional.Telefono);
                existente.Element("IdsActividadesPuedeDictar")?.Remove(); // Quita el nodo viejo
                existente.Add(nodoIdsActividades); // Agrega el nuevo nodo con los IDs actualizados

            }
            else
            {
                profesional.Id = ObtenerNuevoId(root);
                XElement nuevo = new XElement("Profesional",
                    new XElement("Id", profesional.Id),
                    new XElement("DNI", profesional.DNI),
                    new XElement("Nombre", profesional.Nombre),
                    new XElement("Apellido", profesional.Apellido),
                    new XElement("Especialidad", profesional.Especialidad),
                    new XElement("Email", profesional.Email),
                    new XElement("Telefono", profesional.Telefono),
                    nodoIdsActividades // Agrega el nodo con los IDs
                );
                root.Add(nuevo);
            }
            doc.Save(archivo);
        }

        public List<BEProfesional> Listar()
        {
            List<BEProfesional> lista = new List<BEProfesional>();
            if (!File.Exists(archivo)) return lista;
            var doc = XDocument.Load(archivo);

            foreach (var nodo in doc.Descendants("Profesional"))
            {
                var profesional = new BEProfesional
                {
                    Id = (int?)nodo.Element("Id") ?? 0,
                    DNI = (string)nodo.Element("DNI"),
                    Nombre = (string)nodo.Element("Nombre"),
                    Apellido = (string)nodo.Element("Apellido"),
                    Especialidad = (string)nodo.Element("Especialidad"),
                    Email = (string)nodo.Element("Email"),
                    Telefono = (string)nodo.Element("Telefono")
                };
                // Leer los IDs de actividades
                var idsActividadesNodo = nodo.Element("IdsActividadesPuedeDictar");
                if (idsActividadesNodo != null)
                {
                    profesional.IdsActividadesPuedeDictar = idsActividadesNodo.Elements("IdActividad")
                                                                   .Select(el => (int?)el ?? 0)
                                                                   .Where(id => id != 0) // Filtra posibles errores de parseo
                                                                   .ToList();
                }

                lista.Add(profesional);
            }
            return lista;
        }

        public void Eliminar(int idProfesional)
        {
            // IMPORTANTE: Aquí deberías añadir lógica para verificar si el profesional
            // está asignado a turnos futuros antes de permitir la eliminación.
            // Por simplicidad, aquí solo se elimina del archivo.

            var doc = XDocument.Load(archivo);
            var profesional = doc.Descendants("Profesional")
                                 .FirstOrDefault(p => (int?)p.Element("Id") == idProfesional);
            profesional?.Remove();
            doc.Save(archivo);
        }

        public BEProfesional BuscarPorId(int id)
        {
            if (!File.Exists(archivo)) return null;
            var doc = XDocument.Load(archivo);
            var nodo = doc.Descendants("Profesional").FirstOrDefault(p => (int?)p.Element("Id") == id);
            if (nodo != null)
            {
                var profesional = new BEProfesional
                {
                    Id = (int?)nodo.Element("Id") ?? 0,
                    DNI = (string)nodo.Element("DNI"),
                    Nombre = (string)nodo.Element("Nombre"),
                    Apellido = (string)nodo.Element("Apellido"),
                    Especialidad = (string)nodo.Element("Especialidad"),
                    Email = (string)nodo.Element("Email"),
                    Telefono = (string)nodo.Element("Telefono")
                };
                var idsActividadesNodo = nodo.Element("IdsActividadesPuedeDictar");
                if (idsActividadesNodo != null)
                {
                    profesional.IdsActividadesPuedeDictar = idsActividadesNodo.Elements("IdActividad")
                                                                   .Select(el => (int?)el ?? 0)
                                                                   .Where(idAct => idAct != 0)
                                                                   .ToList();
                }
                return profesional;
            }
            return null;
        }
    }
}