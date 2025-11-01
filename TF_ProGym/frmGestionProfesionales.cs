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
    public partial class frmGestionProfesionales : Form
    {
        private BLLProfesional bllProfesional = new BLLProfesional();
        private BLLActividad bllActividad = new BLLActividad();
        private BEProfesional profesionalSeleccionado = null;
        private List<BEActividad> _listaActividadesDisponibles;

        public frmGestionProfesionales()
        {
            InitializeComponent();
        }

        private void frmGestionProfesionales_Load(object sender, EventArgs e)
        {
            // Configurar DataGridView
            dgvProfesionales.AutoGenerateColumns = true; // Usar autogeneración
            dgvProfesionales.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvProfesionales.MultiSelect = false;
            dgvProfesionales.ReadOnly = true;
            dgvProfesionales.AllowUserToAddRows = false;
            dgvProfesionales.AllowUserToDeleteRows = false;
            dgvProfesionales.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            CargarActividadesDisponibles();
            CargarGrilla();
            LimpiarCamposYSeleccion();
        }


        private void CargarActividadesDisponibles()
        {
            try
            {
                _listaActividadesDisponibles = bllActividad.Listar();
                clbActividades.DataSource = null;
                clbActividades.DataSource = _listaActividadesDisponibles;
                clbActividades.DisplayMember = "Nombre";
                clbActividades.ValueMember = "Id";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar la lista de actividades: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                clbActividades.Enabled = false;
            }
            DesmarcarActividades();
        }

        private void DesmarcarActividades()
        {
            for (int i = 0; i < clbActividades.Items.Count; i++)
            {
                clbActividades.SetItemChecked(i, false);
            }
        }


        private void CargarGrilla(string filtro = null)
        {
            try
            {
                var listaProfesionales = bllProfesional.Listar();

                if (!string.IsNullOrWhiteSpace(filtro))
                {
                    filtro = filtro.ToLower();
                    listaProfesionales = listaProfesionales.Where(p => p.DNI.Contains(filtro) ||
                                                                    (p.Nombre?.ToLower().Contains(filtro) ?? false) ||
                                                                    (p.Apellido?.ToLower().Contains(filtro) ?? false) ||
                                                                    (p.Especialidad?.ToLower().Contains(filtro) ?? false))
                                                         .ToList();
                }

                dgvProfesionales.DataSource = null;
                dgvProfesionales.DataSource = listaProfesionales; // Bindear la lista completa

                // Ocultar columnas después de asignar el DataSource
                if (dgvProfesionales.Columns.Contains("Id"))
                {
                    dgvProfesionales.Columns["Id"].Visible = false;
                }
                if (dgvProfesionales.Columns.Contains("IdsActividadesPuedeDictar"))
                {
                    dgvProfesionales.Columns["IdsActividadesPuedeDictar"].Visible = false;
                }
                if (dgvProfesionales.Columns.Contains("ApellidoNombre"))
                {
                    dgvProfesionales.Columns["ApellidoNombre"].Visible = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar la lista de profesionales: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvProfesionales_SelectionChanged(object sender, EventArgs e)
        {
            // Lógica de selección simplificada, igual a Clientes
            if (dgvProfesionales.CurrentRow != null && dgvProfesionales.CurrentRow.DataBoundItem is BEProfesional profesional)
            {
                profesionalSeleccionado = profesional; // Guardar el objeto completo
                MostrarDatosProfesional(profesionalSeleccionado);
                HabilitarCampos(true);
                btnEliminar.Enabled = true;
            }
            else
            {
                profesionalSeleccionado = null;
            }
        }

        private void MostrarDatosProfesional(BEProfesional profesional)
        {
            txtIdProfesional.Text = profesional.Id.ToString();
            txtDNI.Text = profesional.DNI;
            txtNombre.Text = profesional.Nombre;
            txtApellido.Text = profesional.Apellido;
            txtEspecialidad.Text = profesional.Especialidad;
            txtEmail.Text = profesional.Email;
            txtTelefono.Text = profesional.Telefono;

            // Marcar las actividades asignadas en el CheckedListBox
            DesmarcarActividades(); // Limpiar primero
            if (profesional.IdsActividadesPuedeDictar != null)
            {
                for (int i = 0; i < clbActividades.Items.Count; i++)
                {
                    if (clbActividades.Items[i] is BEActividad act)
                    {
                        if (profesional.IdsActividadesPuedeDictar.Contains(act.Id))
                        {
                            clbActividades.SetItemChecked(i, true);
                        }
                    }
                }
            }
        }

        private void LimpiarCamposYSeleccion()
        {
            profesionalSeleccionado = null;
            txtIdProfesional.Clear();
            txtDNI.Clear();
            txtNombre.Clear();
            txtApellido.Clear();
            txtEspecialidad.Clear();
            txtEmail.Clear();
            txtTelefono.Clear();

            DesmarcarActividades();

            dgvProfesionales.ClearSelection();
            HabilitarCampos(true);
            btnEliminar.Enabled = false;
            txtDNI.Focus();
        }

        private void HabilitarCampos(bool habilitar)
        {
            txtDNI.Enabled = habilitar;
            txtNombre.Enabled = habilitar;
            txtApellido.Enabled = habilitar;
            txtEspecialidad.Enabled = habilitar;
            txtEmail.Enabled = habilitar;
            txtTelefono.Enabled = habilitar;
            clbActividades.Enabled = habilitar;
            btnGuardar.Enabled = habilitar;
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            LimpiarCamposYSeleccion();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtDNI.Text) || string.IsNullOrWhiteSpace(txtNombre.Text) || string.IsNullOrWhiteSpace(txtApellido.Text))
                {
                    MessageBox.Show("DNI, Nombre y Apellido son obligatorios.", "Campos requeridos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                BEProfesional profesionalAGuardar;
                bool esNuevo = false;

                // Lógica Nuevo/Editar idéntica a frmGestionClientes
                if (profesionalSeleccionado != null && profesionalSeleccionado.Id.ToString() == txtIdProfesional.Text && profesionalSeleccionado.Id != 0)
                {
                    profesionalAGuardar = profesionalSeleccionado;
                }
                else
                {
                    profesionalAGuardar = new BEProfesional();
                    esNuevo = true;
                }

                // Asignar valores
                profesionalAGuardar.DNI = txtDNI.Text.Trim();
                profesionalAGuardar.Nombre = txtNombre.Text.Trim();
                profesionalAGuardar.Apellido = txtApellido.Text.Trim();
                profesionalAGuardar.Especialidad = txtEspecialidad.Text.Trim();
                profesionalAGuardar.Email = txtEmail.Text.Trim();
                profesionalAGuardar.Telefono = txtTelefono.Text.Trim();

                // Recolectar IDs de actividades seleccionadas
                profesionalAGuardar.IdsActividadesPuedeDictar = new List<int>();
                foreach (var item in clbActividades.CheckedItems)
                {
                    if (item is BEActividad act)
                    {
                        profesionalAGuardar.IdsActividadesPuedeDictar.Add(act.Id);
                    }
                }

                bllProfesional.Guardar(profesionalAGuardar);

                MessageBox.Show(esNuevo ? "Profesional creado correctamente." : "Profesional modificado correctamente.",
                                "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                CargarGrilla();
                LimpiarCamposYSeleccion();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (profesionalSeleccionado == null)
            {
                MessageBox.Show("Seleccione un profesional de la lista para eliminar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult confirmacion = MessageBox.Show($"¿Está seguro de eliminar a {profesionalSeleccionado.Nombre} {profesionalSeleccionado.Apellido}?",
                                                      "Confirmar Eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirmacion == DialogResult.Yes)
            {
                try
                {
                    bllProfesional.Eliminar(profesionalSeleccionado.Id);
                    MessageBox.Show("Profesional eliminado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CargarGrilla();
                    LimpiarCamposYSeleccion();
                }
                catch (InvalidOperationException exInv)
                {
                    MessageBox.Show(exInv.Message, "Operación no permitida", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al eliminar: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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