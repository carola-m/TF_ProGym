using BE;
using BLL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaPresentacion
{
    public partial class frmRegistroAsistencia : Form
    {
        private BLLTurno bllTurno = new BLLTurno();
        private BLLCliente bllCliente = new BLLCliente();
        private BLLAsistencia bllAsistencia = new BLLAsistencia();

        private List<BECliente> _listaClientesCompleta; // Cache de clientes
        private List<BETurno> _turnosDelDia; // Cache de turnos

        public frmRegistroAsistencia()
        {
            InitializeComponent();
        }

        private void frmRegistroAsistencia_Load(object sender, EventArgs e)
        {
            try
            {
                // Carga la lista completa de clientes (para no consultarla mil veces)
                _listaClientesCompleta = bllCliente.Listar();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error fatal al cargar lista de clientes: " + ex.Message);
                _listaClientesCompleta = new List<BECliente>();
            }

            dtpFechaAsistencia.Value = DateTime.Today;
            CargarTurnosDelDia(DateTime.Today);
        }

        private void dtpFechaAsistencia_ValueChanged(object sender, EventArgs e)
        {
            CargarTurnosDelDia(dtpFechaAsistencia.Value);
            LimpiarSeleccionTurno();
        }

        private void CargarTurnosDelDia(DateTime fecha)
        {
            try
            {
                // Obtiene turnos (BLLTurno.ListarTurnosPorFecha ya los trae con Actividad y Profesional)
                _turnosDelDia = bllTurno.ListarTurnosPorFecha(fecha);

                // Crear una lista de objetos anónimos para mostrar en el ComboBox
                var dataSource = _turnosDelDia.Select(t => new {
                    Id = t.Id,
                    // Texto descriptivo para el ComboBox
                    Descripcion = $"{t.FechaHoraInicio:HH:mm} - {t.Actividad?.Nombre ?? "N/A"} ({t.Profesional?.ApellidoNombre ?? "N/A"})"
                }).ToList();

                dataSource.Insert(0, new { Id = 0, Descripcion = "[Seleccione un Turno]" });

                cmbTurnosDelDia.DataSource = null;
                cmbTurnosDelDia.DataSource = dataSource;
                cmbTurnosDelDia.DisplayMember = "Descripcion";
                cmbTurnosDelDia.ValueMember = "Id";
                cmbTurnosDelDia.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los turnos del día: " + ex.Message);
            }
        }

        private void LimpiarSeleccionTurno()
        {
            gbAsistencia.Enabled = false;
            clbClientesInscritos.Items.Clear();
            lblInfoCupo.Text = "Inscritos: - / -";
        }

        private void cmbTurnosDelDia_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbTurnosDelDia.SelectedValue == null || (int)cmbTurnosDelDia.SelectedValue == 0)
            {
                LimpiarSeleccionTurno();
                return;
            }

            try
            {
                int idTurno = (int)cmbTurnosDelDia.SelectedValue;
                BETurno turno = _turnosDelDia.FirstOrDefault(t => t.Id == idTurno);

                if (turno == null)
                {
                    MessageBox.Show("No se encontró el detalle del turno seleccionado.");
                    LimpiarSeleccionTurno();
                    return;
                }

                CargarClientesParaAsistencia(turno);
                gbAsistencia.Enabled = true; // Habilita el GroupBox
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al seleccionar el turno: " + ex.Message);
                LimpiarSeleccionTurno();
            }
        }

        private void CargarClientesParaAsistencia(BETurno turno)
        {
            clbClientesInscritos.Items.Clear();
            lblInfoCupo.Text = $"Inscritos: {turno.CuposOcupados} / {turno.Actividad?.CupoMaximo ?? 0}";

            if (turno.IdClientesInscritos != null && turno.IdClientesInscritos.Any())
            {
                // Busca los clientes inscritos en la lista cacheada
                var clientesInscritos = _listaClientesCompleta
                                        .Where(c => turno.IdClientesInscritos.Contains(c.Id))
                                        .OrderBy(c => c.Apellido).ThenBy(c => c.Nombre)
                                        .ToList();

                // Carga el CheckedListBox
                foreach (var cliente in clientesInscritos)
                {
                    // Añade el objeto BECliente al item
                    // Asume que BECliente.ToString() está sobreescrito para mostrar Apellido, Nombre (DNI)
                    clbClientesInscritos.Items.Add(cliente, false);
                }

                // Marcar los que ya tienen asistencia registrada para este turno
                var asistenciasPrevias = bllAsistencia.ListarPorTurno(turno.Id);
                for (int i = 0; i < clbClientesInscritos.Items.Count; i++)
                {
                    if (clbClientesInscritos.Items[i] is BECliente cliente)
                    {
                        var asistencia = asistenciasPrevias.FirstOrDefault(a => a.IdCliente == cliente.Id);
                        if (asistencia != null)
                        {
                            clbClientesInscritos.SetItemChecked(i, asistencia.Presente);
                        }
                    }
                }
            }
        }

        private void btnGuardarAsistencia_Click(object sender, EventArgs e)
        {
            if (cmbTurnosDelDia.SelectedValue == null || (int)cmbTurnosDelDia.SelectedValue == 0)
            {
                MessageBox.Show("No hay un turno seleccionado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int idTurno = (int)cmbTurnosDelDia.SelectedValue;
            int contador = 0;

            try
            {
                // Recorre la lista de clientes en el CheckedListBox
                for (int i = 0; i < clbClientesInscritos.Items.Count; i++)
                {
                    if (clbClientesInscritos.Items[i] is BECliente cliente)
                    {
                        bool estaPresente = clbClientesInscritos.GetItemChecked(i);

                        // Llama a BLL para CADA cliente (presente o ausente)
                        bllAsistencia.RegistrarAsistencia(idTurno, cliente.Id, estaPresente);
                        contador++;
                    }
                }

                MessageBox.Show($"Se guardó la asistencia para {contador} clientes.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar la asistencia: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
