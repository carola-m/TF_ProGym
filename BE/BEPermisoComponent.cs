using System.Collections.Generic;

namespace BE
{
    // Componente abstracto para patrón Composite (Permisos simples y familias)
    public abstract class BEPermisoComponent
    {
        public int Id { get; set; } // Identificador del permiso o familia
        public string Nombre { get; set; } // Nombre descriptivo (ej: "Gestionar Clientes")
        public string NombreInterno { get; set; } // Identificador único interno (ej: "PERMISO_GESTION_CLIENTES")

        // Métodos abstractos para manejar la estructura jerárquica
        public abstract void AgregarHijo(BEPermisoComponent c);
        public abstract void QuitarHijo(BEPermisoComponent c);
        public abstract IList<BEPermisoComponent> ObtenerHijos();

        public override string ToString()
        {
            return Nombre;
        }

        // Sobrescribir Equals y GetHashCode para comparaciones correctas
        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
                return false;

            BEPermisoComponent other = (BEPermisoComponent)obj;
            // Comparar por NombreInterno asegura unicidad
            return (!string.IsNullOrEmpty(NombreInterno) && NombreInterno.Equals(other.NombreInterno));
        }

        public override int GetHashCode()
        {
            return NombreInterno?.GetHashCode() ?? 0;
        }
    }
}