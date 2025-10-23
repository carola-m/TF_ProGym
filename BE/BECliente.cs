using System;

namespace BE
{
    public class BECliente
    {
        public int Id { get; set; } // Identificador único
        public string DNI { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Email { get; set; }
        public string Telefono { get; set; }
        public DateTime FechaRegistro { get; set; }
        public bool MembresiaActiva { get; set; }

        public override string ToString()
        {
            return $"{Nombre} {Apellido} ({DNI})";
        }
    }
}