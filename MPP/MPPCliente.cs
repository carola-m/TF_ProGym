using BE;
using XmlHelper; 
using System;
using System.Collections.Generic;
using System.Globalization; 
using System.IO;
using System.Linq;
using System.Xml.Linq;

namespace MPP
{
    public class MPPCliente
    {
        // Usa la ruta completa y el XmlHelper instanciado
        private readonly string archivo; // Ruta completa al archivo XML
        private readonly XmlHelper.XmlHelper xmlHelper;

        // Constructor para inicializar el helper y la ruta
        public MPPCliente()
        {
            // Define la ruta base donde está la carpeta 'datos'
            string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
            string dataDirectory = Path.Combine(baseDirectory, "datos");
            // Define la ruta completa al archivo específico
            archivo = Path.Combine(dataDirectory, "Clientes.xml");

            xmlHelper = new XmlHelper.XmlHelper(); // Crea una instancia del helper

            // Asegura que el archivo XML exista con el nodo raíz correcto
            xmlHelper.AsegurarArchivoXml("Clientes.xml", "Clientes");
        }


        // Obtiene el siguiente ID disponible
        private int ObtenerNuevoId(XElement root)
        {
            if (root == null || !root.HasElements) return 1; // Si no hay elementos, empieza en 1
            return root.Elements("Cliente")
                       .Select(x => (int?)x.Element("Id") ?? 0)
                       .DefaultIfEmpty(0)
                       .Max() + 1;
        }

        // Guarda un cliente nuevo o actualiza uno existente
        public void Guardar(BECliente cliente) // Usa BECliente
        {
            // Carga el documento XML usando el helper
            var doc = xmlHelper.CargarXml(archivo);
            var root = doc.Root; // Obtener el elemento raíz (<Clientes>)

            if (root == null) // Si el archivo estaba vacío o corrupto y CargarXml creó uno nuevo en memoria
            {
                root = new XElement("Clientes"); // Crea el nodo raíz si falta
                doc.Add(root); // Añade el nodo raíz al documento
            }


            // Validar DNI duplicado (excepto para el mismo cliente si se edita)
            var duplicado = root.Elements("Cliente")
                .FirstOrDefault(x => (string)x.Element("DNI") == cliente.DNI && (int?)x.Element("Id") != cliente.Id);
            if (duplicado != null)
            {
                throw new Exception($"Ya existe un cliente con el DNI {cliente.DNI}.");
            }

            // Buscar si existe por ID para actualizar
            var existente = root.Elements("Cliente").FirstOrDefault(x => (int?)x.Element("Id") == cliente.Id);

            if (existente != null)
            {
                // Actualizar datos
                existente.SetElementValue("DNI", cliente.DNI);
                existente.SetElementValue("Nombre", cliente.Nombre);
                existente.SetElementValue("Apellido", cliente.Apellido);
                existente.SetElementValue("Email", cliente.Email);
                existente.SetElementValue("Telefono", cliente.Telefono);
                existente.SetElementValue("MembresiaActiva", cliente.MembresiaActiva);
                // FechaRegistro usualmente no se actualiza al editar
            }
            else
            {
                // Es nuevo, asignar ID y agregar
                cliente.Id = ObtenerNuevoId(root);
                cliente.FechaRegistro = DateTime.Now; // Asignar fecha de registro al crear
                XElement nuevo = new XElement("Cliente",
                    new XElement("Id", cliente.Id),
                    new XElement("DNI", cliente.DNI),
                    new XElement("Nombre", cliente.Nombre),
                    new XElement("Apellido", cliente.Apellido),
                    new XElement("Email", cliente.Email),
                    new XElement("Telefono", cliente.Telefono),
                    // Guarda fecha en formato ISO 8601 recomendado para XML
                    new XElement("FechaRegistro", cliente.FechaRegistro.ToString("o", CultureInfo.InvariantCulture)),
                    new XElement("MembresiaActiva", cliente.MembresiaActiva)
                );
                root.Add(nuevo);
            }

            // Guarda el documento modificado usando el helper
            xmlHelper.GuardarXml(doc, archivo);
        }

        // Lista todos los clientes desde el XML
        public List<BECliente> Listar() // Devuelve List<BECliente>
        {
            List<BECliente> lista = new List<BECliente>();
            // Carga el documento XML usando el helper
            var doc = xmlHelper.CargarXml(archivo);
            // Verifica si el documento o el nodo raíz existen
            if (doc == null || doc.Root == null) return lista;


            foreach (var nodo in doc.Root.Elements("Cliente")) // Itera sobre los elementos Cliente
            {
                try // Añadir try-catch para evitar que un nodo mal formado rompa toda la carga
                {
                    lista.Add(new BECliente // Crea BECliente
                    {
                        Id = (int?)nodo.Element("Id") ?? 0,
                        DNI = (string)nodo.Element("DNI"),
                        Nombre = (string)nodo.Element("Nombre"),
                        Apellido = (string)nodo.Element("Apellido"),
                        Email = (string)nodo.Element("Email"),
                        Telefono = (string)nodo.Element("Telefono"),
                        // Parsea la fecha desde formato ISO 8601
                        FechaRegistro = DateTime.ParseExact((string)nodo.Element("FechaRegistro") ?? DateTime.MinValue.ToString("o"), "o", CultureInfo.InvariantCulture, DateTimeStyles.RoundtripKind),
                        MembresiaActiva = (bool?)nodo.Element("MembresiaActiva") ?? false
                    });
                }
                catch (Exception ex)
                {
                    // Informa sobre el nodo problemático si falla el parseo
                    Console.WriteLine($"Error al parsear nodo cliente (Id: {(int?)nodo.Element("Id") ?? -1}): {ex.Message}");
                    // Puedes decidir si continuar o relanzar la excepción
                }
            }
            return lista;
        }

        // Elimina un cliente por su ID
        public void Eliminar(int idCliente)
        {
            // Carga el documento XML usando el helper
            var doc = xmlHelper.CargarXml(archivo);
            // Verifica si el documento o el nodo raíz existen
            if (doc == null || doc.Root == null) return;

            var cliente = doc.Root.Elements("Cliente")
                             .FirstOrDefault(u => (int?)u.Element("Id") == idCliente);

            if (cliente != null)
            {
                cliente.Remove();
                // Guarda el documento modificado usando el helper
                xmlHelper.GuardarXml(doc, archivo);
            }
            // else { podrías lanzar una excepción si el cliente no se encuentra }
        }

        // Busca un cliente por DNI (ya lo tenías, revisado)
        public BECliente BuscarPorDNI(string dni) // Usa BECliente
        {
            // Carga el documento XML usando el helper
            var doc = xmlHelper.CargarXml(archivo);
            // Verifica si el documento o el nodo raíz existen
            if (doc == null || doc.Root == null) return null;

            var nodo = doc.Root.Elements("Cliente").FirstOrDefault(c => (string)c.Element("DNI") == dni);

            if (nodo != null)
            {
                try
                {
                    return new BECliente // Crea BECliente
                    {
                        Id = (int?)nodo.Element("Id") ?? 0,
                        DNI = (string)nodo.Element("DNI"),
                        Nombre = (string)nodo.Element("Nombre"),
                        Apellido = (string)nodo.Element("Apellido"),
                        Email = (string)nodo.Element("Email"),
                        Telefono = (string)nodo.Element("Telefono"),
                        FechaRegistro = DateTime.ParseExact((string)nodo.Element("FechaRegistro") ?? DateTime.MinValue.ToString("o"), "o", CultureInfo.InvariantCulture, DateTimeStyles.RoundtripKind),
                        MembresiaActiva = (bool?)nodo.Element("MembresiaActiva") ?? false
                    };
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error al parsear nodo cliente encontrado por DNI '{dni}': {ex.Message}");
                    return null; // Devuelve null si falla el parseo
                }
            }
            return null; // No encontrado
        }

        // Busca un cliente por ID (añadido para consistencia)
        public BECliente BuscarPorId(int id) // Usa BECliente
        {
            var doc = xmlHelper.CargarXml(archivo);
            if (doc == null || doc.Root == null) return null;

            var nodo = doc.Root.Elements("Cliente").FirstOrDefault(c => (int?)c.Element("Id") == id);

            if (nodo != null)
            {
                try
                {
                    return new BECliente // Crea BECliente
                    {
                        Id = (int?)nodo.Element("Id") ?? 0,
                        DNI = (string)nodo.Element("DNI"),
                        Nombre = (string)nodo.Element("Nombre"),
                        Apellido = (string)nodo.Element("Apellido"),
                        Email = (string)nodo.Element("Email"),
                        Telefono = (string)nodo.Element("Telefono"),
                        FechaRegistro = DateTime.ParseExact((string)nodo.Element("FechaRegistro") ?? DateTime.MinValue.ToString("o"), "o", CultureInfo.InvariantCulture, DateTimeStyles.RoundtripKind),
                        MembresiaActiva = (bool?)nodo.Element("MembresiaActiva") ?? false
                    };
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error al parsear nodo cliente encontrado por ID '{id}': {ex.Message}");
                    return null;
                }
            }
            return null; // No encontrado
        }

        // Elimina los métodos ObtenerPorCodigo y ObtenerPorDNI si son redundantes con BuscarPorId y BuscarPorDNI
        /*
         public BECliente ObtenerPorCodigo(int codigo) // OJO: ¿Usas Codigo o Id como identificador principal? Usa Id consistentemente.
         {
             // Si Codigo es lo mismo que Id, usa BuscarPorId(codigo)
             // Si Codigo es un campo diferente, necesitas buscar por ese campo:
             // var nodo = doc.Root.Elements("Cliente").FirstOrDefault(c => (int?)c.Element("Codigo") == codigo);
             // ... mapear nodo ...
             return BuscarPorId(codigo); // Asumiendo que Codigo es el Id
         }
        */

    }
}

