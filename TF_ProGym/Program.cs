using CapaPresentacion;

namespace TF_ProGym
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            CrearCarpetaDatos();
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();

            Application.Run(new frmLogin());
        }

        private static void CrearCarpetaDatos()
        {
            try
            {
                // Usa AppDomain.CurrentDomain.BaseDirectory para ser más robusto
                string rutaDatos = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "datos");

                if (!Directory.Exists(rutaDatos))
                {
                    Directory.CreateDirectory(rutaDatos);
                }
            }
            catch (Exception ex)
            {
                // Informa al usuario si no se pueden crear las carpetas
                MessageBox.Show($"Error crítico al crear la carpeta de datos: {ex.Message}\n" +
                                "Asegúrese de tener permisos de escritura en la carpeta de la aplicación.",
                                "Error de Inicialización", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit(); // Cierra si no puede crear la carpeta
            }
        }
    }
}