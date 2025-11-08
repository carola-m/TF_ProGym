
using System;

namespace BE
{
    public class BEBitacora
    {
        public int Id { get; set; } 
        public DateTime FechaRegistro { get; set; } 
        public string Detalle { get; set; } 
        public int IdUsuario { get; set; }
        public string NombreUsuario { get; set; } 
        public string NombreArchivo { get; set; } 
    }
}