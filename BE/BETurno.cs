using System;
using System.Collections.Generic;

namespace BE
{
    public class BETurno
    {
        public int Id { get; set; }
        public int IdActividad { get; set; }
        public int IdProfesional { get; set; } // Profesional asignado
        public DateTime FechaHoraInicio { get; set; }
        public DateTime FechaHoraFin { get; set; }
        // Para gestionar reservas y cupos
        public List<int> IdClientesInscritos { get; set; } = new List<int>();

        // Propiedades de solo lectura para facilitar acceso (requieren carga en BLL/MPP)
        [System.Xml.Serialization.XmlIgnore] // Para evitar serialización directa si usas XML con estas propiedades
        public BEActividad Actividad { get; set; }
        [System.Xml.Serialization.XmlIgnore]
        public BEProfesional Profesional { get; set; }

        public int CuposDisponibles => (Actividad?.CupoMaximo ?? 0) - IdClientesInscritos.Count;
        public int CuposOcupados => IdClientesInscritos.Count;

    }
}