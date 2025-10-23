using BE;
using MPP;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BLL
{
    public class BLLAsistencia
    {
        private readonly MPPAsistencia mppAsistencia;
        private readonly MPPTurno mppTurno; // Para validaciones
        private readonly MPPCliente mppCliente; // Para validaciones

        public BLLAsistencia()
        {
            mppAsistencia = new MPPAsistencia();
            mppTurno = new MPPTurno();
            mppCliente = new MPPCliente();
        }

        public void RegistrarAsistencia(int idTurno, int idCliente, bool presente)
        {
            // --- Validaciones ---
            var turno = mppTurno.BuscarPorId(idTurno);
            if (turno == null) throw new KeyNotFoundException("Turno no encontrado.");
            // Opcional: Validar que el turno sea del día actual o pasado reciente para registrar asistencia
            // if (turno.FechaHoraInicio.Date > DateTime.Today)
            //     throw new InvalidOperationException("No se puede registrar asistencia para un turno futuro.");


            var cliente = mppCliente.Listar().FirstOrDefault(c => c.Id == idCliente); // o BuscarPorId
            if (cliente == null) throw new KeyNotFoundException("Cliente no encontrado.");

            // Validar que el cliente estuviera inscrito en el turno (si es requerido)
            // if (!turno.IdClientesInscritos.Contains(idCliente))
            //     throw new InvalidOperationException("El cliente no estaba inscrito en este turno.");


            // Verificar si ya existe un registro para actualizarlo o crear uno nuevo
            var asistenciaExistente = mppAsistencia.BuscarAsistenciaTurnoCliente(idTurno, idCliente);

            BEAsistencia asistencia;
            if (asistenciaExistente != null)
            {
                asistencia = asistenciaExistente;
                asistencia.Presente = presente; // Actualiza el estado
                asistencia.FechaHoraRegistro = DateTime.Now; // Actualiza la hora del registro/modificación
            }
            else
            {
                asistencia = new BEAsistencia
                {
                    IdTurno = idTurno,
                    IdCliente = idCliente,
                    Presente = presente,
                    FechaHoraRegistro = DateTime.Now
                };
            }


            try
            {
                mppAsistencia.Guardar(asistencia);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al registrar la asistencia: " + ex.Message);
            }
        }

        public List<BEAsistencia> Listar()
        {
            // Podría añadir lógica para cargar los objetos Turno y Cliente si es necesario
            return mppAsistencia.Listar();
        }

        public List<BEAsistencia> ListarPorTurno(int idTurno)
        {
            return mppAsistencia.ListarPorTurno(idTurno);
        }

        public List<BEAsistencia> ListarPorCliente(int idCliente)
        {
            return mppAsistencia.ListarPorCliente(idCliente);
        }

        public List<BEAsistencia> ListarPorClienteYPeriodo(int idCliente, DateTime desde, DateTime hasta)
        {
            DateTime hastaFinDia = hasta.Date.AddDays(1).AddTicks(-1);
            return mppAsistencia.ListarPorCliente(idCliente)
                                .Where(a => a.FechaHoraRegistro >= desde.Date && a.FechaHoraRegistro <= hastaFinDia)
                                .OrderBy(a => a.FechaHoraRegistro)
                                .ToList();
        }

        public BEAsistencia BuscarAsistenciaTurnoCliente(int idTurno, int idCliente)
        {
            return mppAsistencia.BuscarAsistenciaTurnoCliente(idTurno, idCliente);
        }

        public void Eliminar(int idAsistencia)
        {
            // Considerar si se debe permitir eliminar registros de asistencia
            // Podría requerir permisos especiales o solo permitir en ciertos casos
            mppAsistencia.Eliminar(idAsistencia);
        }
    }
}