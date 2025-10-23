// BE/BEBitacora.cs
using System;

namespace BE
{
    // Define la estructura para una entrada en la bitácora de eventos (Backup/Restore)
    public class BEBitacora
    {
        public int Id { get; set; } // Identificador único autoincremental
        public DateTime FechaRegistro { get; set; } // Fecha y hora en que ocurrió el evento
        public string Detalle { get; set; } // Descripción del evento (ej: "Backup", "Restore", "Restore Fallido")
        public int IdUsuario { get; set; } // ID del usuario que realizó la acción
        public string NombreUsuario { get; set; } // Nombre del usuario para fácil lectura
        public string NombreArchivo { get; set; } // Nombre de la carpeta o archivo asociado (ej: nombre del backup)
    }
}