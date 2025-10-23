// BLL/BLLBackup.cs
using System;
using System.IO;
using System.Linq;
// No necesita BE directamente, pero sí BLLBitacora

namespace BLL
{
    public class BLLBackup
    {
        private readonly BLLBitacora bllBitacora = new BLLBitacora();

        public string RealizarBackup()
        {
            string dataDirectory = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "datos");
            string backupBaseDirectory = Path.Combine(dataDirectory, "Backups"); // Carpeta Backups dentro de datos
            Directory.CreateDirectory(backupBaseDirectory); // Asegura que exista

            // Nombre único para la carpeta del backup
            string nombreBackup = "Backup_" + DateTime.Now.ToString("yyyyMMdd_HHmmss");
            string carpetaDestino = Path.Combine(backupBaseDirectory, nombreBackup);
            Directory.CreateDirectory(carpetaDestino);

            string bitacoraFileName = "Bitacora.xml"; // Nombre exacto del archivo a excluir

            try
            {
                // Obtener todos los archivos XML en /datos, EXCEPTO Bitacora.xml
                var archivosACopiar = Directory.GetFiles(dataDirectory, "*.xml")
                                             .Where(f => !Path.GetFileName(f).Equals(bitacoraFileName, StringComparison.OrdinalIgnoreCase));

                if (!archivosACopiar.Any())
                {
                    // Si no hay archivos de datos, igual registra el intento? O lanza error?
                    // Por ahora, solo registramos que no había archivos.
                    bllBitacora.Registrar("Backup Intento (Sin archivos)", nombreBackup);
                    // Limpiar carpeta creada si está vacía? Opcional.
                    // Directory.Delete(carpetaDestino);
                    throw new InvalidOperationException("No se encontraron archivos de datos (.xml) para realizar el backup.");
                }


                foreach (var archivoOrigen in archivosACopiar)
                {
                    string nombreArchivo = Path.GetFileName(archivoOrigen);
                    string rutaDestinoArchivo = Path.Combine(carpetaDestino, nombreArchivo);
                    File.Copy(archivoOrigen, rutaDestinoArchivo, true); // true = sobrescribir si existe (poco probable aquí)
                }

                // Registrar éxito en Bitácora
                bllBitacora.Registrar("Backup", nombreBackup); // Registra la carpeta del backup

                return carpetaDestino; // Devuelve la ruta donde se guardó el backup
            }
            catch (Exception ex)
            {
                // Registrar error en Bitácora
                bllBitacora.Registrar($"Backup Fallido: {ex.Message}", nombreBackup);
                // Limpiar carpeta destino si falló? Podría dejar archivos parciales.
                try { if (Directory.Exists(carpetaDestino)) Directory.Delete(carpetaDestino, true); } catch { /* Ignorar error al limpiar */ }

                // Relanzar la excepción para informar a la UI
                throw new Exception($"Error al realizar el backup: {ex.Message}", ex);
            }
        }
    }
}