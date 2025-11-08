using System.Collections.Generic;

namespace BE
{
    public abstract class BEPermisoComponent
    {
        public int Id { get; set; } 
        public string Nombre { get; set; } 
        public string NombreInterno { get; set; } 

        // Métodos abstractos para manejar la estructura jerárquica
        public abstract void AgregarHijo(BEPermisoComponent c);
        public abstract void QuitarHijo(BEPermisoComponent c);
        public abstract IList<BEPermisoComponent> ObtenerHijos();

        public override string ToString()
        {
            return Nombre;
        }
        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
                return false;

            BEPermisoComponent other = (BEPermisoComponent)obj;
            return (!string.IsNullOrEmpty(NombreInterno) && NombreInterno.Equals(other.NombreInterno));
        }

        public override int GetHashCode()
        {
            return NombreInterno?.GetHashCode() ?? 0;
        }
    }
}