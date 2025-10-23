using System;
using System.Collections.Generic;

namespace BE
{
    // Representa un permiso individual (hoja en el patrón Composite)
    public class BEPermiso : BEPermisoComponent
    {
        public BEPermiso() { }

        public BEPermiso(int id, string nombre, string nombreInterno)
        {
            Id = id;
            Nombre = nombre;
            NombreInterno = nombreInterno;
        }

        public override void AgregarHijo(BEPermisoComponent c)
        {
            // Un permiso simple no puede tener hijos.
            // Podrías lanzar una excepción o simplemente ignorar la operación.
            Console.WriteLine($"Advertencia: No se puede agregar un hijo al permiso simple '{Nombre}'.");
            // throw new InvalidOperationException("Un permiso simple no puede tener hijos.");
        }

        public override void QuitarHijo(BEPermisoComponent c)
        {
            // Un permiso simple no tiene hijos que quitar.
            Console.WriteLine($"Advertencia: No se puede quitar un hijo del permiso simple '{Nombre}'.");
            // throw new InvalidOperationException("Un permiso simple no tiene hijos.");
        }

        public override IList<BEPermisoComponent> ObtenerHijos()
        {
            // Devuelve una lista vacía porque no tiene hijos.
            return new List<BEPermisoComponent>();
        }
    }
}