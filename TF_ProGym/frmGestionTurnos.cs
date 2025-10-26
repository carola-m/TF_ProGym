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
    public partial class frmGestionTurnos : Form
    {
        private BLLTurno bllTurno = new BLLTurno();
        private BLLActividad bllActividad = new BLLActividad();
        private BLLProfesional bllProfesional = new BLLProfesional();
        private BLLCliente bllCliente = new BLLCliente();

        private BETurno turnoSeleccionado = null; // Para saber qué turno gestionar

        public frmGestionTurnos()
        {
            InitializeComponent(); // Esta línea es fundamental
        }

        // El .Designer.cs busca este método
        private void frmGestionTurnos_Load(object sender, EventArgs e)
        {
            // Configurar DataGridView
            dgvTurnosDia.AutoGenerateColumns = false; // Controlaremos las columnas
            ConfigurarColumnasDGV();
            dgvTurnosDia.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvTurnosDia.MultiSelect = false;
            dgvTurnosDia.ReadOnly = true;
            dgvTurnosDia.AllowUserToAddRows = false;
            dgvTurnosDia.AllowUserToDeleteRows = false;
            dgvTurnosDia.RowHeadersVisible = false;

            // Configurar DateTimePickers para hora
            dtpHoraInicio.Format = DateTimePickerFormat.Custom;
            dtpHoraInicio.CustomFormat = "HH:mm"; // Mostrar solo Hora:Minuto
            dtpHoraInicio.ShowUpDown = true;
            dtpHoraFin.Format = DateTimePickerFormat.Custom;
            dtpHoraFin.CustomFormat = "HH:mm";
            dtpHoraFin.ShowUpDown = true;

            // Configurar DateTimePickers para fecha (solo fecha corta)
            dtpFechaInicio.Format = DateTimePickerFormat.Short;
            dtpFechaFin.Format = DateTimePickerFormat.Short;

            // Cargar ComboBoxes
            CargarComboActividades();
            CargarComboProfesionales();
            CargarComboClientes();

            // Cargar turnos para el día actual
            dtpFechaTurnos.Value = DateTime.Today;
            CargarGrillaTurnos(DateTime.Today);

            LimpiarCamposDetalleTurno();
            gbReservaCliente.Enabled = false;
        }

        private void ConfigurarColumnasDGV()
        {
            dgvTurnosDia.Columns.Clear();
            dgvTurnosDia.Columns.Add(new DataGridViewTextBoxColumn { Name = "colId", DataPropertyName = "Id", HeaderText = "ID", Visible = false });
            dgvTurnosDia.Columns.Add(new DataGridViewTextBoxColumn { Name = "colHoraInicio", DataPropertyName = "FechaHoraInicio", HeaderText = "Inicio", DefaultCellStyle = new DataGridViewCellStyle { Format = "HH:mm" } });
            dgvTurnosDia.Columns.Add(new DataGridViewTextBoxColumn { Name = "colHoraFin", DataPropertyName = "FechaHoraFin", HeaderText = "Fin", DefaultCellStyle = new DataGridViewCellStyle { Format = "HH:mm" } });
            dgvTurnosDia.Columns.Add(new DataGridViewTextBoxColumn { Name = "colActividad", DataPropertyName = "ActividadNombre", HeaderText = "Actividad" });
            dgvTurnosDia.Columns.Add(new DataGridViewTextBoxColumn { Name = "colProfesional", DataPropertyName = "ProfesionalNombre", HeaderText = "Profesional" });
            dgvTurnosDia.Columns.Add(new DataGridViewTextBoxColumn { Name = "colCupos", DataPropertyName = "CuposInfo", HeaderText = "Cupos (Ocup/Max)" });

            dgvTurnosDia.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        // --- Propiedades Calculadas (Añadir a BECliente.cs y BEProfesional.cs) ---
        // Ve a BECliente.cs y añade:
        // public string ApellidoNombre => (Id == 0) ? Nombre : $"{Apellido}, {Nombre}";
        // public string ApellidoNombreDNI => (Id == 0) ? Apellido : $"{Apellido}, {Nombre} ({DNI})";

        // Ve a BEProfesional.cs y añade:
        // public string ApellidoNombre => (Id == 0) ? Apellido : $"{Apellido}, {Nombre}";

        private void CargarComboActividades()
        {
            try
            {
                cmbActividad.DataSource = null;
                var actividades = bllActividad.Listar();
                actividades.Insert(0, new BEActividad { Id = 0, Nombre = "[Seleccione Actividad]" });
                cmbActividad.DataSource = actividades;
                cmbActividad.DisplayMember = "Nombre";
                cmbActividad.ValueMember = "Id";
                cmbActividad.SelectedIndex = 0;
            }
            catch (Exception ex) { MessageBox.Show("Error cargando actividades: " + ex.Message); }
        }

        private void CargarComboProfesionales()
        {
            try
            {
                cmbProfesional.DataSource = null;
                var profesionales = bllProfesional.Listar();
                profesionales.Insert(0, new BEProfesional { Id = 0, Apellido = "[Seleccione Profesional]" });
                cmbProfesional.DataSource = profesionales;

                // *** IMPORTANTE: NECESITAS AÑADIR ESTA PROPIEDAD A BEProfesional.cs ***
                // public string ApellidoNombre => (Id == 0) ? Apellido : $"{Apellido}, {Nombre}";
                cmbProfesional.DisplayMember = "ApellidoNombre";

                cmbProfesional.ValueMember = "Id";
                cmbProfesional.SelectedIndex = 0;
            }
            catch (Exception ex) { MessageBox.Show("Error cargando profesionales: " + ex.Message); }
        }

        private void CargarComboClientes()
        {
            try
            {
                cmbCliente.DataSource = null;
                var clientes = bllCliente.Listar().Where(c => c.MembresiaActiva).ToList();
                clientes.Insert(0, new BECliente { Id = 0, Apellido = "[Seleccione Cliente]" });
                cmbCliente.DataSource = clientes;

                // *** IMPORTANTE: NECESITAS AÑADIR ESTA PROPIEDAD A BECliente.cs ***
                // public string ApellidoNombreDNI => (Id == 0) ? Apellido : $"{Apellido}, {Nombre} ({DNI})";
                cmbCliente.DisplayMember = "ApellidoNombreDNI";

                cmbCliente.ValueMember = "Id";
                cmbCliente.SelectedIndex = 0;
            }
            catch (Exception ex) { MessageBox.Show("Error cargando clientes: " + ex.Message); }
        }

        // El .Designer.cs busca este método
        private void dtpFechaTurnos_ValueChanged(object sender, EventArgs e)
        {
            CargarGrillaTurnos(dtpFechaTurnos.Value);
            LimpiarCamposDetalleTurno();
            LimpiarSeccionReservas();
            gbReservaCliente.Enabled = false;
            turnoSeleccionado = null;
        }

        private void CargarGrillaTurnos(DateTime fecha)
        {
            try
            {
                var turnosDelDia = bllTurno.ListarTurnosPorFecha(fecha);

                var dataSource = turnosDelDia.Select(t => new {
                    t.Id,
                    t.FechaHoraInicio,
                    t.FechaHoraFin,
                    ActividadNombre = t.Actividad?.Nombre ?? "N/A",
                    ProfesionalNombre = (t.Profesional != null) ? $"{t.Profesional.Apellido}, {t.Profesional.Nombre}" : "N/A",
                    CuposInfo = $"{t.CuposOcupados} / {t.Actividad?.CupoMaximo ?? 0}"
                }).OrderBy(t => t.FechaHoraInicio).ToList();

                dgvTurnosDia.DataSource = null;
                dgvTurnosDia.DataSource = dataSource;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los turnos del día: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                dgvTurnosDia.DataSource = null;
            }
        }

        // El .Designer.cs busca este método
        private void dgvTurnosDia_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvTurnosDia.CurrentRow != null && dgvTurnosDia.CurrentRow.DataBoundItem != null)
            {
                try
                {
                    int idTurnoSeleccionado = (int)dgvTurnosDia.CurrentRow.Cells["colId"].Value;
                    turnoSeleccionado = bllTurno.BuscarPorId(idTurnoSeleccionado);

                    if (turnoSeleccionado != null)
                    {
                        MostrarDatosTurno(turnoSeleccionado);
                        CargarClientesInscritos(turnoSeleccionado);
                        gbReservaCliente.Enabled = true;
                        btnEliminarTurno.Enabled = true;
                    }
                    else
                    {
                        LimpiarCamposDetalleTurno();
                        LimpiarSeccionReservas();
                        gbReservaCliente.Enabled = false;
                        btnEliminarTurno.Enabled = false;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al seleccionar el turno: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    LimpiarCamposDetalleTurno();
                    LimpiarSeccionReservas();
                    gbReservaCliente.Enabled = false;
                    btnEliminarTurno.Enabled = false;
                    turnoSeleccionado = null;
                }
            }
            else
            {
                LimpiarCamposDetalleTurno();
                LimpiarSeccionReservas();
                gbReservaCliente.Enabled = false;
                btnEliminarTurno.Enabled = false;
                turnoSeleccionado = null;
            }
        }

        private void MostrarDatosTurno(BETurno turno)
        {
            txtIdTurno.Text = turno.Id.ToString();
            cmbActividad.SelectedValue = turno.IdActividad;
            cmbProfesional.SelectedValue = turno.IdProfesional;
            dtpFechaInicio.Value = turno.FechaHoraInicio.Date;
            dtpHoraInicio.Value = turno.FechaHoraInicio;
            dtpFechaFin.Value = turno.FechaHoraFin.Date;
            dtpHoraFin.Value = turno.FechaHoraFin;
        }

        private void LimpiarCamposDetalleTurno()
        {
            txtIdTurno.Clear();
            cmbActividad.SelectedIndex = 0;
            cmbProfesional.SelectedIndex = 0;
            DateTime fechaBase = dtpFechaTurnos.Value.Date;
            dtpFechaInicio.Value = fechaBase;
            dtpHoraInicio.Value = fechaBase.AddHours(DateTime.Now.Hour);
            dtpFechaFin.Value = fechaBase;
            dtpHoraFin.Value = fechaBase.AddHours(DateTime.Now.Hour + 1);

            dgvTurnosDia.ClearSelection();
            btnEliminarTurno.Enabled = false;
        }

        // El .Designer.cs busca este método
        private void btnNuevoTurno_Click(object sender, EventArgs e)
        {
            LimpiarCamposDetalleTurno();
            LimpiarSeccionReservas();
            gbReservaCliente.Enabled = false;
            turnoSeleccionado = null;
            cmbActividad.Focus();
        }

        // El .Designer.cs busca este método
        private void btnGuardarTurno_Click(object sender, EventArgs e)
        {
            try
            {
                if (cmbActividad.SelectedValue == null || (int)cmbActividad.SelectedValue == 0)
                {
                    MessageBox.Show("Seleccione una actividad.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cmbActividad.Focus(); return;
                }
                if (cmbProfesional.SelectedValue == null || (int)cmbProfesional.SelectedValue == 0)
                {
                    MessageBox.Show("Seleccione un profesional.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cmbProfesional.Focus(); return;
                }

                DateTime fechaInicio = dtpFechaInicio.Value.Date;
                DateTime horaInicio = dtpHoraInicio.Value;
                DateTime inicioCompleto = fechaInicio.AddHours(horaInicio.Hour).AddMinutes(horaInicio.Minute);

                DateTime fechaFin = dtpFechaFin.Value.Date;
                DateTime horaFin = dtpHoraFin.Value;
                DateTime finCompleto = fechaFin.AddHours(horaFin.Hour).AddMinutes(horaFin.Minute);

                BETurno turnoAGuardar;
                bool esNuevo = string.IsNullOrEmpty(txtIdTurno.Text) || txtIdTurno.Text == "0";

                if (!esNuevo && turnoSeleccionado != null && turnoSeleccionado.Id.ToString() == txtIdTurno.Text)
                {
                    turnoAGuardar = turnoSeleccionado;
                }
                else
                {
                    turnoAGuardar = new BETurno();
                    esNuevo = true;
                }

                turnoAGuardar.IdActividad = (int)cmbActividad.SelectedValue;
                turnoAGuardar.IdProfesional = (int)cmbProfesional.SelectedValue;
                turnoAGuardar.FechaHoraInicio = inicioCompleto;
                turnoAGuardar.FechaHoraFin = finCompleto;

                bllTurno.Guardar(turnoAGuardar);

                MessageBox.Show(esNuevo ? "Turno creado correctamente." : "Turno modificado correctamente.",
                                "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                CargarGrillaTurnos(dtpFechaTurnos.Value);
                LimpiarCamposDetalleTurno();
                LimpiarSeccionReservas();
                gbReservaCliente.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar el turno: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // El .Designer.cs busca este método
        private void btnEliminarTurno_Click(object sender, EventArgs e)
        {
            if (turnoSeleccionado == null)
            {
                MessageBox.Show("Seleccione un turno de la lista para eliminar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult confirmacion = MessageBox.Show($"¿Está seguro de eliminar el turno de '{turnoSeleccionado.Actividad?.Nombre}' a las {turnoSeleccionado.FechaHoraInicio:HH:mm}?",
                                                      "Confirmar Eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirmacion == DialogResult.Yes)
            {
                try
                {
                    bllTurno.Eliminar(turnoSeleccionado.Id);
                    MessageBox.Show("Turno eliminado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    CargarGrillaTurnos(dtpFechaTurnos.Value);
                    LimpiarCamposDetalleTurno();
                    LimpiarSeccionReservas();
                    gbReservaCliente.Enabled = false;
                }
                catch (InvalidOperationException exInv)
                {
                    MessageBox.Show(exInv.Message, "Operación no permitida", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al eliminar el turno: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // --- Sección Reservas ---

        private void LimpiarSeccionReservas()
        {
            cmbCliente.SelectedIndex = 0;
            lstClientesInscritos.DataSource = null;
            lblCupoInfo.Text = "Cupos: -/-";
        }

        private void CargarClientesInscritos(BETurno turno)
        {
            lstClientesInscritos.DataSource = null;
            if (turno != null && turno.IdClientesInscritos.Any())
            {
                var clientesInscritos = bllCliente.Listar()
                                                  .Where(c => turno.IdClientesInscritos.Contains(c.Id))
                                                  .OrderBy(c => c.Apellido).ThenBy(c => c.Nombre)
                                                  .ToList();
                lstClientesInscritos.DataSource = clientesInscritos;

                // *** IMPORTANTE: NECESITAS AÑADIR ESTA PROPIEDAD A BECliente.cs ***
                // public string ApellidoNombreDNI => (Id == 0) ? Apellido : $"{Apellido}, {Nombre} ({DNI})";
                lstClientesInscritos.DisplayMember = "ApellidoNombreDNI";

                lstClientesInscritos.ValueMember = "Id";
            }

            if (turno?.Actividad != null)
                lblCupoInfo.Text = $"Cupos: {turno.CuposOcupados} / {turno.Actividad.CupoMaximo}";
            else
                lblCupoInfo.Text = "Cupos: -/-";
        }

        // El .Designer.cs busca este método
        private void btnReservarCliente_Click(object sender, EventArgs e)
        {
            if (turnoSeleccionado == null)
            {
                MessageBox.Show("Primero seleccione un turno de la lista.", "Acción requerida", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (cmbCliente.SelectedValue == null || (int)cmbCliente.SelectedValue == 0)
            {
                MessageBox.Show("Seleccione un cliente para reservar.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbCliente.Focus();
                return;
            }

            int idClienteAReservar = (int)cmbCliente.SelectedValue;

            try
            {
                bllTurno.ReservarTurno(turnoSeleccionado.Id, idClienteAReservar);
                MessageBox.Show("Cliente reservado con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                turnoSeleccionado = bllTurno.BuscarPorId(turnoSeleccionado.Id);
                CargarClientesInscritos(turnoSeleccionado);
                CargarGrillaTurnos(dtpFechaTurnos.Value);
                cmbCliente.SelectedIndex = 0;
                cmbCliente.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al reservar: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // El .Designer.cs busca este método
        private void btnCancelarReserva_Click(object sender, EventArgs e)
        {
            if (turnoSeleccionado == null)
            {
                MessageBox.Show("Primero seleccione un turno de la lista.", "Acción requerida", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (lstClientesInscritos.SelectedItem == null)
            {
                MessageBox.Show("Seleccione un cliente de la lista de inscritos para cancelar su reserva.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                lstClientesInscritos.Focus();
                return;
            }

            BECliente clienteACancelar = (BECliente)lstClientesInscritos.SelectedItem;

            DialogResult confirmacion = MessageBox.Show($"¿Está seguro de cancelar la reserva de {clienteACancelar.ToString()} para este turno?",
                                                     "Confirmar Cancelación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirmacion == DialogResult.Yes)
            {
                try
                {
                    bllTurno.CancelarReserva(turnoSeleccionado.Id, clienteACancelar.Id);
                    MessageBox.Show("Reserva cancelada con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    turnoSeleccionado = bllTurno.BuscarPorId(turnoSeleccionado.Id);
                    CargarClientesInscritos(turnoSeleccionado);
                    CargarGrillaTurnos(dtpFechaTurnos.Value);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al cancelar la reserva: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
