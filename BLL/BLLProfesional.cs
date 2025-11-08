using BE;
using MPP;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BLL
{
    public class BLLProfesional
    {
        private readonly MPPProfesional mppProfesional;
        private readonly MPPActividad mppActividad; // Para validar IDs de actividades
        private readonly MPPTurno mppTurno; // Para validar si se puede eliminar

        public BLLProfesional()
        {
            mppProfesional = new MPPProfesional();
            mppActividad = new MPPActividad();
            mppTurno = new MPPTurno(); 
        }

        public void Guardar(BEProfesional profesional)
        {
            if (profesional == null) throw new ArgumentNullException("El profesional no puede ser nulo.");
            if (string.IsNullOrWhiteSpace(profesional.DNI)) throw new ArgumentException("El DNI es obligatorio.");
            if (string.IsNullOrWhiteSpace(profesional.Nombre)) throw new ArgumentException("El Nombre es obligatorio.");
            if (string.IsNullOrWhiteSpace(profesional.Apellido)) throw new ArgumentException("El Apellido es obligatorio.");
            if (profesional.DNI.Length < 7 || profesional.DNI.Length > 8 || !profesional.DNI.All(char.IsDigit))
                throw new ArgumentException("El DNI debe tener 7 u 8 dígitos numéricos.");
            // Validar formato de Email si existe
            if (!string.IsNullOrEmpty(profesional.Email) && !profesional.Email.Contains("@")) 
                throw new ArgumentException("El formato del Email no es válido.");

            // Validar que los IDs de actividades asignadas existan
            var idsActividadesExistentes = mppActividad.Listar().Select(a => a.Id).ToList();
            foreach (var idActividad in profesional.IdsActividadesPuedeDictar)
            {
                if (!idsActividadesExistentes.Contains(idActividad))
                    throw new KeyNotFoundException($"La actividad con ID {idActividad} asignada al profesional no existe.");
            }


            try
            {
                mppProfesional.Guardar(profesional);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al guardar el profesional: " + ex.Message);
            }
        }

        public List<BEProfesional> Listar()
        {
            return mppProfesional.Listar();
        }

        public void Eliminar(int idProfesional)
        {
            // Regla de negocio: No eliminar si tiene turnos futuros asignados
            var turnosFuturos = mppTurno.Listar()
                                        .Where(t => t.IdProfesional == idProfesional && t.FechaHoraInicio > DateTime.Now);
            if (turnosFuturos.Any())
            {
                throw new InvalidOperationException("No se puede eliminar el profesional porque tiene turnos futuros asignados.");
            }

            mppProfesional.Eliminar(idProfesional);
        }

        public BEProfesional BuscarPorId(int id)
        {
            return mppProfesional.BuscarPorId(id);
        }

        public List<BEProfesional> BuscarPorEspecialidad(string especialidad)
        {
            if (string.IsNullOrWhiteSpace(especialidad)) return Listar();
            return mppProfesional.Listar()
                   .Where(p => p.Especialidad.Equals(especialidad, StringComparison.OrdinalIgnoreCase))
                   .ToList();
        }
    }
}