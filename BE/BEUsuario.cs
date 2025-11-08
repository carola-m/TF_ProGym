namespace BE
{
    public class BEUsuario
    {
        public int Id { get; set; } 
        public string NombreUsuario { get; set; } 
        public string Password { get; set; } 
        public bool DebeCambiarPassword { get; set; } 
        public bool Activo { get; set; } 

        public BEUsuario()
        {
            Activo = true; 
            DebeCambiarPassword = true; 
        }

        public override string ToString()
        {
            return NombreUsuario;
        }
    }
}