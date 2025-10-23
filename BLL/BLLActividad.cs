using BE;
using MPP;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BLL
{
    public class BLLActividad
    {
        private readonly MPPActividad mppActividad;
        private readonly MPPTurno mppTurno; // Para validaciones

        public BLLActividad()
        {
            mppActividad = new MPPActividad();
            mppTurno = new MPPTurno();
        }

        public void Guardar(BEActividad actividad)
        {
            if (actividad == null) throw new ArgumentNullException("La actividad no puede ser nula.");
            if (string.IsNullOrWhiteSpace(actividad.Nombre)) throw new ArgumentException("El Nombre es obligatorio.");
            if (actividad.CupoMaximo <= 0) throw new ArgumentException("El Cupo Máximo debe ser mayor a cero.");
            if (actividad.TarifaPorTurno < 0) throw new ArgumentException("La Tarifa por Turno no puede ser negativa.");

            try
            {
                mppActividad.Guardar(actividad);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al guardar la actividad: " + ex.Message);
            }
        }

        public List<BEActividad> Listar()
        {
            return mppActividad.Listar();
        }

        public void Eliminar(int idActividad)
        {
            // Regla de negocio: No eliminar si tiene turnos futuros asociados
            var turnosFuturos = mppTurno.Listar()
                                        .Where(t => t.IdActividad == idActividad && t.FechaHoraInicio > DateTime.Now);
            if (turnosFuturos.Any())
            {
                throw new InvalidOperationException("No se puede eliminar la actividad porque tiene turnos futuros programados.");
            }

            mppActividad.Eliminar(idActividad);
        }

        public BEActividad BuscarPorId(int id)
        {
            return mppActividad.BuscarPorId(id);
        }
    }
}