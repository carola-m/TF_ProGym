
namespace BE
{
    public class BELiquidacion
    {
        public int Id { get; set; }
        public int IdProfesional { get; set; }
        public DateTime PeriodoDesde { get; set; }
        public DateTime PeriodoHasta { get; set; }
        public decimal MontoTotal { get; set; }
        public DateTime FechaEmision { get; set; } 

        public List<TurnoLiquidado> TurnosLiquidados { get; set; } = new List<TurnoLiquidado>();

        [System.Xml.Serialization.XmlIgnore]
        public BEProfesional Profesional { get; set; }
    }


    public class TurnoLiquidado
    {
        public int IdTurno { get; set; }
        public DateTime FechaHora { get; set; }
        public string NombreActividad { get; set; }
        public decimal ValorTurno { get; set; } 
    }
}