

namespace BLL
{
    public class BLLRestore
    {
        private readonly BLLBitacora bllBitacora = new BLLBitacora();

        public void RealizarRestore(string nombreBackup) 
        {
            string dataDirectory = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "datos");
            string backupBaseDirectory = Path.Combine(dataDirectory, "Backups");
            string carpetaOrigen = Path.Combine(backupBaseDirectory, nombreBackup);

            if (!Directory.Exists(carpetaOrigen))
            {
                throw new DirectoryNotFoundException($"La carpeta de backup '{nombreBackup}' no fue encontrada.");
            }

            string bitacoraFileName = "Bitacora.xml";

            try
            {
                // Obtener archivos XML DENTRO de la carpeta del backup
                var archivosARestaurar = Directory.GetFiles(carpetaOrigen, "*.xml");

                if (!archivosARestaurar.Any())
                {
                    throw new InvalidOperationException($"La carpeta de backup '{nombreBackup}' no contiene archivos .xml para restaurar.");
                }


                foreach (var archivoOrigen in archivosARestaurar)
                {
                    string nombreArchivo = Path.GetFileName(archivoOrigen);

                    // NO restaurar el archivo de bitácora
                    if (nombreArchivo.Equals(bitacoraFileName, StringComparison.OrdinalIgnoreCase))
                    {
                        continue; // Salta este archivo
                    }


                    string rutaDestinoArchivo = Path.Combine(dataDirectory, nombreArchivo);
                    File.Copy(archivoOrigen, rutaDestinoArchivo, true); // true = SOBRESCRIBIR
                }

                // Registrar éxito en Bitácora
                bllBitacora.Registrar("Restore", nombreBackup);
            }
            catch (Exception ex)
            {
                // Registrar error en Bitácora
                bllBitacora.Registrar($"Restore Fallido: {ex.Message}", nombreBackup);
                throw new Exception($"Error CRÍTICO al realizar el restore desde '{nombreBackup}': {ex.Message}", ex);
            }
        }
    }
}