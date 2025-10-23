using System;

namespace BE
{
    public class BEAsistencia
    {
        public int Id { get; set; } // Id único para el registro de asistencia
        public int IdTurno { get; set; }
        public int IdCliente { get; set; }
        public DateTime FechaHoraRegistro { get; set; }
        public bool Presente { get; set; } // True si asistió, False si estuvo ausente (pero reservó)

        // Propiedades de solo lectura para facilitar acceso (requieren carga en BLL/MPP)
        [System.Xml.Serialization.XmlIgnore]
        public BETurno Turno { get; set; }
        [System.Xml.Serialization.XmlIgnore]
        public BECliente Cliente { get; set; }
    }
}