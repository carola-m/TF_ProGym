using System;

namespace BE
{
    public class BEAsistencia
    {
        public int Id { get; set; } 
        public int IdTurno { get; set; }
        public int IdCliente { get; set; }
        public DateTime FechaHoraRegistro { get; set; }
        public bool Presente { get; set; } 

        [System.Xml.Serialization.XmlIgnore]
        public BETurno Turno { get; set; }
        [System.Xml.Serialization.XmlIgnore]
        public BECliente Cliente { get; set; }
    }
}