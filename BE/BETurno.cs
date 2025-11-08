using System;
using System.Collections.Generic;

namespace BE
{
    public class BETurno
    {
        public int Id { get; set; }
        public int IdActividad { get; set; }
        public int IdProfesional { get; set; } 
        public DateTime FechaHoraInicio { get; set; }
        public DateTime FechaHoraFin { get; set; }

        public List<int> IdClientesInscritos { get; set; } = new List<int>();


        [System.Xml.Serialization.XmlIgnore] 
        public BEActividad Actividad { get; set; }
        [System.Xml.Serialization.XmlIgnore]
        public BEProfesional Profesional { get; set; }

        public int CuposDisponibles => (Actividad?.CupoMaximo ?? 0) - IdClientesInscritos.Count;
        public int CuposOcupados => IdClientesInscritos.Count;

    }
}