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
        private BLLActividad bllActividad = new BLLActividad(); // Para cargar actividades
        private BEProfesional profesionalSeleccionado = null;
        private List<BEActividad> _listaActividadesDisponibles; // Para el CheckedListBox

        public frmGestionProfesionales()
        {
            InitializeComponent();
        }

        private void frmGestionProfesionales_Load(object sender, EventArgs e)
        {
            // Configurar DataGridView para autogenerar
            dgvProfesionales.AutoGenerateColumns = true; // <-- Habilitar autogeneración
            dgvProfesionales.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvProfesionales.MultiSelect = false;
            dgvProfesionales.ReadOnly = true;
            dgvProfesionales.AllowUserToAddRows = false;
            dgvProfesionales.AllowUserToDeleteRows = false;
            dgvProfesionales.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            // Cargar datos iniciales
            CargarActividadesDisponibles();
            CargarGrilla();
            LimpiarCamposYSeleccion();
        }

        // Ya NO necesitamos ConfigurarColumnasDGV()

        // Carga las actividades disponibles en el CheckedListBox
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
            // Desmarcar todos inicialmente
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
                // Selecciona solo las propiedades que quieres mostrar y en el orden deseado
                // Esto ayuda a controlar qué columnas se autogeneran si no quieres mostrar todo.
                var dataSource = listaProfesionales.Select(p => new {
                    p.Id, // Mantenemos ID para lógica interna, luego se oculta
                    p.DNI,
                    p.Nombre,
                    p.Apellido,
                    p.Especialidad,
                    p.Email,
                    p.Telefono
                    // Omitimos IdsActividadesPuedeDictar para que no se muestre como columna simple
                }).ToList();

                dgvProfesionales.DataSource = dataSource;

                // Ocultar columnas después de asignar el DataSource
                if (dgvProfesionales.Columns.Contains("Id"))
                {
                    dgvProfesionales.Columns["Id"].Visible = false;
                }
                // Podrías renombrar encabezados si quieres
                if (dgvProfesionales.Columns.Contains("DNI")) dgvProfesionales.Columns["DNI"].HeaderText = "DNI";
                // ... etc ...

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar la lista de profesionales: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvProfesionales_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvProfesionales.CurrentRow != null)
            {
                // Como el DataSource es una lista anónima, necesitamos obtener el ID
                // y buscar el objeto BEProfesional completo en la lista original
                int idSeleccionado = (int)dgvProfesionales.CurrentRow.Cells["Id"].Value; // Obtiene el ID de la fila seleccionada
                profesionalSeleccionado = bllProfesional.BuscarPorId(idSeleccionado); // Busca el objeto completo

                if (profesionalSeleccionado != null)
                {
                    MostrarDatosProfesional(profesionalSeleccionado);
                    HabilitarCampos(true);
                    btnEliminar.Enabled = true;
                }
                else
                {
                    // Si no se encuentra el objeto completo (raro, pero posible)
                    LimpiarCamposYSeleccion();
                }
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
            for (int i = 0; i < clbActividades.Items.Count; i++)
            {
                if (clbActividades.Items[i] is BEActividad act)
                {
                    bool asignada = profesional.IdsActividadesPuedeDictar?.Contains(act.Id) ?? false;
                    clbActividades.SetItemChecked(i, asignada);
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

            for (int i = 0; i < clbActividades.Items.Count; i++)
            {
                clbActividades.SetItemChecked(i, false);
            }

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
                // ... (Añadir las otras validaciones de BLL aquí si quieres) ...

                BEProfesional profesionalAGuardar;
                bool esNuevo = string.IsNullOrEmpty(txtIdProfesional.Text) || txtIdProfesional.Text == "0";

                if (!esNuevo && profesionalSeleccionado != null && profesionalSeleccionado.Id.ToString() == txtIdProfesional.Text)
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

                // Llama a BLL
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
