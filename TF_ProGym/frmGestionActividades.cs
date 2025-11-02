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
    public partial class frmGestionActividades : Form
    {
        private BLLActividad bllActividad = new BLLActividad();
        private BEActividad actividadSeleccionada = null;

        public frmGestionActividades()
        {
            InitializeComponent();
        }

        private void frmGestionActividades_Load(object sender, EventArgs e)
        {
            // Configurar DataGridView
            dgvActividades.AutoGenerateColumns = true;
            dgvActividades.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvActividades.MultiSelect = false;
            dgvActividades.ReadOnly = true;
            dgvActividades.AllowUserToAddRows = false;
            dgvActividades.AllowUserToDeleteRows = false;
            // Estilos restaurados a un formato más default
            dgvActividades.RowHeadersVisible = true;
            dgvActividades.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            dgvActividades.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;


            // Configurar NumericUpDown
            numCupoMaximo.Minimum = 1;
            numCupoMaximo.Maximum = 1000;

            CargarGrilla();
            LimpiarCamposYSeleccion();
        }

        /// <summary>
        /// Carga la grilla de actividades, opcionalmente filtrada.
        /// </summary>
        private void CargarGrilla(string filtro = null)
        {
            try
            {
                var listaActividades = bllActividad.Listar();

                if (!string.IsNullOrWhiteSpace(filtro))
                {
                    filtro = filtro.ToLower();
                    listaActividades = listaActividades.Where(a => a.Nombre.ToLower().Contains(filtro) ||
                                                                   (a.Descripcion?.ToLower().Contains(filtro) ?? false))
                                                     .ToList();
                }

                dgvActividades.DataSource = null;
                dgvActividades.DataSource = listaActividades;

                // Ocultar/personalizar columnas después de asignar datos
                if (dgvActividades.Columns.Contains("Id"))
                {
                    dgvActividades.Columns["Id"].Visible = false;
                }
                if (dgvActividades.Columns.Contains("TarifaPorTurno"))
                {
                    dgvActividades.Columns["TarifaPorTurno"].HeaderText = "Tarifa x Turno";
                    dgvActividades.Columns["TarifaPorTurno"].DefaultCellStyle.Format = "C2";
                }
                if (dgvActividades.Columns.Contains("CupoMaximo"))
                {
                    dgvActividades.Columns["CupoMaximo"].HeaderText = "Cupo";
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar la lista de actividades: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Evento al seleccionar una fila: carga los datos en los campos de edición.
        /// </summary>
        private void dgvActividades_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvActividades.CurrentRow != null && dgvActividades.CurrentRow.DataBoundItem is BEActividad actividad)
            {
                actividadSeleccionada = actividad;
                MostrarDatosActividad(actividad);
                HabilitarCampos(true);
                btnEliminar.Enabled = true;
            }
            else
            {
                actividadSeleccionada = null;
            }
        }

        /// <summary>
        /// Rellena los campos del formulario con los datos de la actividad seleccionada.
        /// </summary>
        private void MostrarDatosActividad(BEActividad actividad)
        {
            txtIdActividad.Text = actividad.Id.ToString();
            txtNombreActividad.Text = actividad.Nombre;
            txtDescripcionActividad.Text = actividad.Descripcion;

            if (actividad.CupoMaximo >= numCupoMaximo.Minimum && actividad.CupoMaximo <= numCupoMaximo.Maximum)
            {
                numCupoMaximo.Value = actividad.CupoMaximo;
            }
            else
            {
                numCupoMaximo.Value = numCupoMaximo.Minimum;
            }
            txtTarifaTurno.Text = actividad.TarifaPorTurno.ToString("F2");
        }

        /// <summary>
        /// Limpia los campos de edición y deselecciona la grilla.
        /// </summary>
        private void LimpiarCamposYSeleccion()
        {
            actividadSeleccionada = null;
            txtIdActividad.Clear();
            txtNombreActividad.Clear();
            txtDescripcionActividad.Clear();
            numCupoMaximo.Value = 1;
            txtTarifaTurno.Text = "0.00";

            dgvActividades.ClearSelection();
            HabilitarCampos(true);
            btnEliminar.Enabled = false;
            txtNombreActividad.Focus();
        }

        private void HabilitarCampos(bool habilitar)
        {
            txtNombreActividad.Enabled = habilitar;
            txtDescripcionActividad.Enabled = habilitar;
            numCupoMaximo.Enabled = habilitar;
            txtTarifaTurno.Enabled = habilitar;
            btnGuardar.Enabled = habilitar;
        }

        /// <summary>
        /// Prepara el formulario para crear una nueva actividad.
        /// </summary>
        private void btnNuevo_Click(object sender, EventArgs e)
        {
            LimpiarCamposYSeleccion();
        }

        /// <summary>
        /// Guarda una actividad nueva o actualiza una existente.
        /// </summary>
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                // Validaciones
                if (string.IsNullOrWhiteSpace(txtNombreActividad.Text))
                {
                    MessageBox.Show("El nombre de la actividad es obligatorio.", "Campo requerido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtNombreActividad.Focus();
                    return;
                }
                if (!decimal.TryParse(txtTarifaTurno.Text, out decimal tarifa) || tarifa < 0)
                {
                    MessageBox.Show("La tarifa por turno debe ser un número válido no negativo.", "Tarifa inválida", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtTarifaTurno.Focus();
                    return;
                }

                BEActividad actividadAGuardar;
                bool esNueva = false;

                // Determina si es una actividad nueva o una modificación
                if (actividadSeleccionada != null && actividadSeleccionada.Id.ToString() == txtIdActividad.Text && actividadSeleccionada.Id != 0)
                {
                    actividadAGuardar = actividadSeleccionada;
                }
                else
                {
                    actividadAGuardar = new BEActividad();
                    esNueva = true;
                }

                // Asignar valores
                actividadAGuardar.Nombre = txtNombreActividad.Text.Trim();
                actividadAGuardar.Descripcion = txtDescripcionActividad.Text.Trim();
                actividadAGuardar.CupoMaximo = (int)numCupoMaximo.Value;
                actividadAGuardar.TarifaPorTurno = tarifa;

                bllActividad.Guardar(actividadAGuardar);

                MessageBox.Show(esNueva ? "Actividad creada correctamente." : "Actividad modificada correctamente.",
                                "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                CargarGrilla();
                LimpiarCamposYSeleccion();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar la actividad: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Elimina la actividad seleccionada, previa confirmación.
        /// </summary>
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (actividadSeleccionada == null)
            {
                MessageBox.Show("Seleccione una actividad de la lista para eliminar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult confirmacion = MessageBox.Show($"¿Está seguro de eliminar la actividad '{actividadSeleccionada.Nombre}'?",
                                                      "Confirmar Eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirmacion == DialogResult.Yes)
            {
                try
                {
                    bllActividad.Eliminar(actividadSeleccionada.Id);
                    MessageBox.Show("Actividad eliminada correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CargarGrilla();
                    LimpiarCamposYSeleccion();
                }
                catch (InvalidOperationException exInv)
                {
                    MessageBox.Show(exInv.Message, "Operación no permitida", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al eliminar la actividad: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            CargarGrilla(txtBuscar.Text.Trim());
        }

        private void txtBuscar_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                e.Handled = true;
                btnBuscar.PerformClick();
            }
        }
    }
}