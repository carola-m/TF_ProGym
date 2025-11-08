

namespace BE
{
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
            Console.WriteLine($"Advertencia: No se puede agregar un hijo al permiso simple '{Nombre}'.");
            throw new InvalidOperationException("Un permiso simple no puede tener hijos.");
        }

        public override void QuitarHijo(BEPermisoComponent c)
        {
            Console.WriteLine($"Advertencia: No se puede quitar un hijo del permiso simple '{Nombre}'.");
            throw new InvalidOperationException("Un permiso simple no tiene hijos.");
        }

        public override IList<BEPermisoComponent> ObtenerHijos()
        {
            return new List<BEPermisoComponent>();
        }
    }
}