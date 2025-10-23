using BE;
using MPP;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BLL
{
    public class BLLTurno
    {
        private readonly MPPTurno mppTurno;
        private readonly MPPActividad mppActividad; // Para obtener datos de actividad (cupo)
        private readonly MPPProfesional mppProfesional; // Para validar profesional
        private readonly MPPCliente mppCliente; // Para validar cliente

        public BLLTurno()
        {
            mppTurno = new MPPTurno();
            mppActividad = new MPPActividad();
            mppProfesional = new MPPProfesional();
            mppCliente = new MPPCliente();
        }

        public void Guardar(BETurno turno)
        {
            // --- Validaciones de Negocio ---
            if (turno == null) throw new ArgumentNullException("El turno no puede ser nulo.");
            if (turno.IdActividad <= 0) throw new ArgumentException("Debe seleccionar una Actividad válida.");
            if (turno.IdProfesional <= 0) throw new ArgumentException("Debe seleccionar un Profesional válido.");
            if (turno.FechaHoraInicio >= turno.FechaHoraFin) throw new ArgumentException("La fecha/hora de inicio debe ser anterior a la fecha/hora de fin.");
            if (turno.FechaHoraInicio < DateTime.Now && turno.Id == 0) throw new ArgumentException("No se pueden crear turnos en el pasado."); // Solo al crear

            // Validar existencia de Actividad y Profesional (ya se hace en MPP, pero puede hacerse aquí también)
            var actividad = mppActividad.BuscarPorId(turno.IdActividad);
            if (actividad == null) throw new KeyNotFoundException($"Actividad con ID {turno.IdActividad} no encontrada.");

            var profesional = mppProfesional.BuscarPorId(turno.IdProfesional);
            if (profesional == null) throw new KeyNotFoundException($"Profesional con ID {turno.IdProfesional} no encontrado.");

            // Validar que el profesional pueda dictar esa actividad (si tienes esa lógica)
            // if (!profesional.IdsActividadesPuedeDictar.Contains(turno.IdActividad))
            //     throw new InvalidOperationException($"El profesional {profesional.Nombre} {profesional.Apellido} no está habilitado para dictar la actividad {actividad.Nombre}.");


            // Validar superposición de horarios para el MISMO profesional
            var turnosProfesional = Listar().Where(t => t.IdProfesional == turno.IdProfesional && t.Id != turno.Id); // Excluir el turno actual si se edita
            foreach (var existente in turnosProfesional)
            {
                // Verifica si hay solapamiento: (InicioA < FinB) y (FinA > InicioB)
                if (turno.FechaHoraInicio < existente.FechaHoraFin && turno.FechaHoraFin > existente.FechaHoraInicio)
                {
                    throw new InvalidOperationException($"El profesional ya tiene un turno asignado que se superpone en ese horario ({existente.FechaHoraInicio:g} - {existente.FechaHoraFin:g}).");
                }
            }

            // Validar que los clientes inscritos existan (ya se hace en MPP, redundante aquí si confías en MPP)


            // Validar cupo si se están agregando clientes directamente al guardar el turno
            if (turno.IdClientesInscritos.Count > actividad.CupoMaximo)
            {
                throw new InvalidOperationException($"La cantidad de clientes inscritos ({turno.IdClientesInscritos.Count}) supera el cupo máximo ({actividad.CupoMaximo}) de la actividad.");
            }


            // --- Fin Validaciones ---

            try
            {
                mppTurno.Guardar(turno);
            }
            catch (Exception ex)
            {
                // Podrías loguear el error original ex
                throw new Exception("Error al guardar el turno: " + ex.Message);
            }
        }

        public List<BETurno> Listar()
        {
            // Carga los turnos y sus relaciones básicas (Actividad, Profesional)
            return mppTurno.Listar();
        }

        public void Eliminar(int idTurno)
        {
            // Regla de negocio: No eliminar si el turno ya pasó o si tiene asistencias registradas
            var turno = mppTurno.BuscarPorId(idTurno);
            if (turno == null) throw new KeyNotFoundException("Turno no encontrado.");

            if (turno.FechaHoraInicio <= DateTime.Now)
            {
                throw new InvalidOperationException("No se puede eliminar un turno que ya ha comenzado o finalizado.");
            }

            // Validar si tiene asistencias (necesitarías BLLAsistencia)
            var bllAsistencia = new BLLAsistencia(); // Asume que existe
            if (bllAsistencia.ListarPorTurno(idTurno).Any())
            {
                throw new InvalidOperationException("No se puede eliminar el turno porque ya tiene registros de asistencia asociados.");
            }


            mppTurno.Eliminar(idTurno);
        }

        public BETurno BuscarPorId(int id)
        {
            return mppTurno.BuscarPorId(id);
        }

        // --- Gestión de Reservas (Clientes en Turnos) ---

        public void ReservarTurno(int idTurno, int idCliente)
        {
            // Validaciones de negocio
            var turno = BuscarPorId(idTurno);
            if (turno == null) throw new KeyNotFoundException("Turno no encontrado.");
            if (turno.Actividad == null) throw new InvalidOperationException("El turno no tiene una actividad válida."); // Actividad debe estar cargada
            if (turno.FechaHoraInicio <= DateTime.Now) throw new InvalidOperationException("No se puede reservar un turno que ya ha comenzado o finalizado.");

            var cliente = mppCliente.Listar().FirstOrDefault(c => c.Id == idCliente); // O un mppCliente.BuscarPorId(idCliente);
            if (cliente == null) throw new KeyNotFoundException("Cliente no encontrado.");
            if (!cliente.MembresiaActiva) throw new InvalidOperationException("El cliente no tiene una membresía activa para reservar.");


            if (turno.IdClientesInscritos.Contains(idCliente)) throw new InvalidOperationException("El cliente ya está inscrito.");
            if (turno.CuposOcupados >= turno.Actividad.CupoMaximo) throw new InvalidOperationException("No hay cupos disponibles.");

            try
            {
                mppTurno.AgregarClienteTurno(idTurno, idCliente);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al reservar el turno: " + ex.Message);
            }
        }

        public void CancelarReserva(int idTurno, int idCliente)
        {
            // Validaciones de negocio
            var turno = BuscarPorId(idTurno);
            if (turno == null) throw new KeyNotFoundException("Turno no encontrado.");
            // Podrías añadir una regla de tiempo límite para cancelar (ej. 24hs antes)
            // if (turno.FechaHoraInicio <= DateTime.Now.AddHours(24))
            //     throw new InvalidOperationException("No se puede cancelar la reserva con menos de 24 horas de anticipación.");


            var cliente = mppCliente.Listar().FirstOrDefault(c => c.Id == idCliente); // O BuscarPorId
            if (cliente == null) throw new KeyNotFoundException("Cliente no encontrado.");

            if (!turno.IdClientesInscritos.Contains(idCliente)) throw new InvalidOperationException("El cliente no tiene una reserva en este turno.");

            // Validar si ya se registró asistencia para este cliente en este turno (no se podría cancelar)
            var bllAsistencia = new BLLAsistencia();
            if (bllAsistencia.BuscarAsistenciaTurnoCliente(idTurno, idCliente) != null)
            {
                throw new InvalidOperationException("No se puede cancelar la reserva porque ya se registró la asistencia (o ausencia) para este turno.");
            }


            try
            {
                mppTurno.QuitarClienteTurno(idTurno, idCliente);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al cancelar la reserva: " + ex.Message);
            }
        }

        // --- Búsquedas Adicionales ---
        public List<BETurno> ListarTurnosPorFecha(DateTime fecha)
        {
            return Listar().Where(t => t.FechaHoraInicio.Date == fecha.Date)
                           .OrderBy(t => t.FechaHoraInicio)
                           .ToList();
        }

        public List<BETurno> ListarTurnosPorPeriodo(DateTime desde, DateTime hasta)
        {
            // Asegura que 'hasta' incluya todo el día
            DateTime hastaFinDia = hasta.Date.AddDays(1).AddTicks(-1);
            return Listar().Where(t => t.FechaHoraInicio >= desde.Date && t.FechaHoraInicio <= hastaFinDia)
                           .OrderBy(t => t.FechaHoraInicio)
                           .ToList();
        }

        public List<BETurno> ListarTurnosPorProfesionalYPeriodo(int idProfesional, DateTime desde, DateTime hasta)
        {
            DateTime hastaFinDia = hasta.Date.AddDays(1).AddTicks(-1);
            return Listar().Where(t => t.IdProfesional == idProfesional
                                     && t.FechaHoraInicio >= desde.Date
                                     && t.FechaHoraInicio <= hastaFinDia)
                           .OrderBy(t => t.FechaHoraInicio)
                           .ToList();
        }
    }
}