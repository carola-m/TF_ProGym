using System;

namespace BE
{
    public class BEActividad
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public int CupoMaximo { get; set; }
        public decimal TarifaPorTurno { get; set; }

        public override string ToString()
        {
            return Nombre;
        }
    }
}