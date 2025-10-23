using System;
using System.Collections.Generic;

namespace BE
{
    // Representa el pago calculado para un profesional en un período
    public class BELiquidacion
    {
        public int Id { get; set; }
        public int IdProfesional { get; set; }
        public DateTime PeriodoDesde { get; set; }
        public DateTime PeriodoHasta { get; set; }
        public decimal MontoTotal { get; set; }
        public DateTime FechaEmision { get; set; } // Fecha en que se calculó/generó

        // Detalle simplificado: lista de turnos considerados y su valor
        // Podrías crear una clase BEDetalleLiquidacion si necesitas más info
        public List<TurnoLiquidado> TurnosLiquidados { get; set; } = new List<TurnoLiquidado>();

        // Propiedad de solo lectura para facilitar acceso
        [System.Xml.Serialization.XmlIgnore]
        public BEProfesional Profesional { get; set; }
    }

    // Clase auxiliar para el detalle
    public class TurnoLiquidado
    {
        public int IdTurno { get; set; }
        public DateTime FechaHora { get; set; }
        public string NombreActividad { get; set; }
        public decimal ValorTurno { get; set; } // Lo que se paga por ese turno específico
    }
}