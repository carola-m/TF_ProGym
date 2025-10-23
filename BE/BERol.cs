using System.Collections.Generic;

namespace BE
{
    public class BERol
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public bool Activo { get; set; } // Para bajas lógicas

        // Lista de permisos asociados directamente (simplificado, podría usar BEPermisoComponent)
        public List<BEPermiso> Permisos { get; set; } = new List<BEPermiso>();

        public BERol()
        {
            Activo = true;
        }

        public override string ToString()
        {
            return Nombre;
        }
    }
}