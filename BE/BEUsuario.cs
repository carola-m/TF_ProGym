namespace BE
{
    public class BEUsuario
    {
        public int Id { get; set; } // Renombrado de Codigo a Id para consistencia
        public string NombreUsuario { get; set; } // Renombrado de Usuario a NombreUsuario
        public string Password { get; set; } // Renombrado de Psw a Password
        public bool DebeCambiarPassword { get; set; } // Renombrado
        public bool Activo { get; set; } // Para bajas lógicas

        public BEUsuario()
        {
            Activo = true; // Por defecto activo al crear
            DebeCambiarPassword = true; // Forzar cambio al primer login (excepto admin)
        }

        public override string ToString()
        {
            return NombreUsuario;
        }
    }
}