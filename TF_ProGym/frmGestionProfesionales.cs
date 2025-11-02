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

        // Carga inicial del formulario, DGV y Carga de Actividades
        private void frmGestionProfesionales_Load(object sender, EventArgs e)
        {
            dgvProfesionales.AutoGenerateColumns = true;
            dgvProfesionales.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvProfesionales.MultiSelect = false;
            dgvProfesionales.ReadOnly = true;
            dgvProfesionales.AllowUserToAddRows = false;
            dgvProfesionales.AllowUserToDeleteRows = false;
            dgvProfesionales.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvProfesionales.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            dgvProfesionales.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;

            CargarActividadesDisponibles();
            CargarGrilla();
            LimpiarCamposYSeleccion();
        }

        // Obtiene la lista de todas las actividades para el CheckedListBox
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

        // Desmarca todos los items del CheckedListBox
        private void DesmarcarActividades()
        {
            for (int i = 0; i < clbActividades.Items.Count; i++)
            {
                clbActividades.SetItemChecked(i, false);
            }
        }

        // Carga la grilla de profesionales, opcionalmente filtrada
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
                dgvProfesionales.DataSource = listaProfesionales;

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

        // Muestra los datos del profesional seleccionado en los campos de edición
        private void dgvProfesionales_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvProfesionales.CurrentRow != null && dgvProfesionales.CurrentRow.DataBoundItem is BEProfesional profesional)
            {
                profesionalSeleccionado = profesional;
                MostrarDatosProfesional(profesionalSeleccionado);
                HabilitarCampos(true);
                btnEliminar.Enabled = true;
            }
            else
            {
                profesionalSeleccionado = null;
            }
        }

        // Pasa los datos de un objeto BEProfesional a los controles del formulario
        private void MostrarDatosProfesional(BEProfesional profesional)
        {
            txtIdProfesional.Text = profesional.Id.ToString();
            txtDNI.Text = profesional.DNI;
            txtNombre.Text = profesional.Nombre;
            txtApellido.Text = profesional.Apellido;
            txtEspecialidad.Text = profesional.Especialidad;
            txtEmail.Text = profesional.Email;
            txtTelefono.Text = profesional.Telefono;

            DesmarcarActividades();
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

        // Limpia todos los campos de entrada y deselecciona la grilla
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

        // Habilita o deshabilita los controles de edición
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

        // Prepara el formulario para la creación de un nuevo profesional
        private void btnNuevo_Click(object sender, EventArgs e)
        {
            LimpiarCamposYSeleccion();
        }

        // Valida y guarda un profesional (nuevo o existente) en la base de datos
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

                if (profesionalSeleccionado != null && profesionalSeleccionado.Id.ToString() == txtIdProfesional.Text && profesionalSeleccionado.Id != 0)
                {
                    profesionalAGuardar = profesionalSeleccionado;
                }
                else
                {
                    profesionalAGuardar = new BEProfesional();
                    esNuevo = true;
                }

                profesionalAGuardar.DNI = txtDNI.Text.Trim();
                profesionalAGuardar.Nombre = txtNombre.Text.Trim();
                profesionalAGuardar.Apellido = txtApellido.Text.Trim();
                profesionalAGuardar.Especialidad = txtEspecialidad.Text.Trim();
                profesionalAGuardar.Email = txtEmail.Text.Trim();
                profesionalAGuardar.Telefono = txtTelefono.Text.Trim();

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

        // Elimina el profesional seleccionado, previa confirmación
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

        // Filtra la grilla según el texto ingresado
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            CargarGrilla(txtBuscar.Text.Trim());
        }

        // Permite buscar presionando Enter en el cuadro de texto
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