

namespace BE
{
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
            if (c != null && !_hijos.Any(h => h.Equals(c))) 
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
                // Busca y elimina el hijo específico 
                _hijos.Remove(c);

                foreach (var hijo in _hijos.OfType<BECategoriaPermiso>())
                {
                    hijo.QuitarHijo(c);
                }
            }
        }

        public override IList<BEPermisoComponent> ObtenerHijos()
        {
            return _hijos.ToList().AsReadOnly();
        }
    }
}