// BLL/BLLBitacora.cs
using BE;
using MPP;
using System;
using System.Collections.Generic;

namespace BLL
{
    public class BLLBitacora
    {
        private readonly MPPBitacora mppBitacora = new MPPBitacora();

        public void Registrar(string detalle, string nombreArchivo = null) // Simplificado
        {
            // Obtener usuario de la sesión
            var sesion = Services.Session.ObtenerInstancia;
            if (!sesion.IsLoggedIn)
            {
                // Decide qué hacer si no hay sesión (¿lanzar error, usar usuario default?)
                // Por ahora, usamos un ID y nombre genéricos
                Console.WriteLine("Advertencia: Intentando registrar en bitácora sin sesión activa.");
                // return; // Opcional: no registrar si no hay sesión
            }


            var entrada = new BEBitacora
            {
                FechaRegistro = DateTime.Now,
                Detalle = detalle, // "Backup", "Restore", u otro evento
                IdUsuario = sesion.IsLoggedIn ? sesion.UsuarioLogueado.Id : 0, // 0 si no hay sesión
                NombreUsuario = sesion.IsLoggedIn ? sesion.UsuarioLogueado.NombreUsuario : "Sistema", // "Sistema" si no hay sesión
                NombreArchivo = nombreArchivo // Nombre de la carpeta/archivo relevante
            };

            try
            {
                mppBitacora.Guardar(entrada);
            }
            catch (Exception ex)
            {
                // Manejar error de guardado de bitácora (ej. loguearlo en archivo de texto)
                Console.WriteLine($"Error CRÍTICO al guardar en Bitácora: {ex.Message}");
                // NO lanzar excepción aquí usualmente, para no detener la operación principal (backup/restore)
            }
        }

        public List<BEBitacora> Listar()
        {
            try
            {
                return mppBitacora.Listar();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al listar Bitácora: {ex.Message}");
                return new List<BEBitacora>(); // Devolver lista vacía en caso de error
            }
        }
    }
}