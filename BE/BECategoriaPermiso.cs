using System;
using System.Collections.Generic;
using System.Linq;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace BE
{
    // Representa una familia o categoría de permisos (nodo compuesto en el patrón Composite)
    public class BECategoriaPermiso : BEPermisoComponent
    {
        private List<BEPermisoComponent> _hijos = new List<BEPermisoComponent>();

        public BECategoriaPermiso() { }

        public BECategoriaPermiso(int id, string nombre, string nombreInterno)
        {
            Id = id;
            Nombre = nombre;
            NombreInterno = nombreInterno;
        }

        public override void AgregarHijo(BEPermisoComponent c)
        {
            if (c != null && !_hijos.Any(h => h.Equals(c))) // Evita duplicados basados en NombreInterno
            {
                _hijos.Add(c);
            }
            else if (c != null)
            {
                Console.WriteLine($"Advertencia: El permiso '{c.Nombre}' ya existe en la categoría '{Nombre}'.");
            }
        }

        public override void QuitarHijo(BEPermisoComponent c)
        {
            if (c != null)
            {
                // Busca y elimina el hijo específico (basado en Equals/GetHashCode)
                _hijos.Remove(c);

                // Opcionalmente, buscar recursivamente en los hijos si son categorías
                foreach (var hijo in _hijos.OfType<BECategoriaPermiso>())
                {
                    hijo.QuitarHijo(c);
                }
            }
        }

        public override IList<BEPermisoComponent> ObtenerHijos()
        {
            // Devuelve una copia para evitar modificaciones externas directas de la lista interna.
            return _hijos.ToList().AsReadOnly();
        }
    }
}