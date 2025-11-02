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
    public partial class frmGestionClientes : Form
    {
        private BLLCliente bllCliente = new BLLCliente();
        private BECliente clienteSeleccionado = null;

        public frmGestionClientes()
        {
            InitializeComponent();
        }

        private void frmGestionClientes_Load(object sender, EventArgs e)
        {
            // Configuración inicial del DataGridView
            dgvClientes.AutoGenerateColumns = true;
            dgvClientes.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvClientes.MultiSelect = false;
            dgvClientes.ReadOnly = true;
            dgvClientes.AllowUserToAddRows = false;
            dgvClientes.AllowUserToDeleteRows = false;
            dgvClientes.RowHeadersVisible = true; // Restaurado a default
            // dgvClientes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill; // Eliminado para estilo default

            CargarGrilla();
            LimpiarCamposYSeleccion();
        }

        private void CargarGrilla(string filtro = null)
        {
            try
            {
                var listaClientes = bllCliente.Listar();

                if (!string.IsNullOrWhiteSpace(filtro))
                {
                    filtro = filtro.ToLower();
                    listaClientes = listaClientes.Where(c => c.DNI.Contains(filtro) ||
                                                             (c.Nombre?.ToLower().Contains(filtro) ?? false) ||
                                                             (c.Apellido?.ToLower().Contains(filtro) ?? false))
                                                 .ToList();
                }

                dgvClientes.DataSource = null;
                dgvClientes.DataSource = listaClientes;

                // Ocultar columnas no deseadas después de asignar el DataSource
                if (dgvClientes.Columns.Contains("Id"))
                {
                    dgvClientes.Columns["Id"].Visible = false;
                }
                if (dgvClientes.Columns.Contains("ApellidoNombreDNI"))
                {
                    dgvClientes.Columns["ApellidoNombreDNI"].Visible = false;
                }
                if (dgvClientes.Columns.Contains("FechaRegistro"))
                {
                    dgvClientes.Columns["FechaRegistro"].HeaderText = "Fecha Reg.";
                }
                if (dgvClientes.Columns.Contains("MembresiaActiva"))
                {
                    dgvClientes.Columns["MembresiaActiva"].HeaderText = "Activo";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar la lista de clientes: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Evento que se dispara al cambiar la selección en la grilla.
        /// </summary>
        private void dgvClientes_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvClientes.CurrentRow != null && dgvClientes.CurrentRow.DataBoundItem is BECliente cliente)
            {
                clienteSeleccionado = cliente;
                MostrarDatosCliente(cliente);
                HabilitarCampos(true);
                btnEliminar.Enabled = true;
            }
            else
            {
                clienteSeleccionado = null;
            }
        }

        /// <summary>
        /// Muestra los datos de un cliente en los controles del formulario.
        /// </summary>
        private void MostrarDatosCliente(BECliente cliente)
        {
            txtIdCliente.Text = cliente.Id.ToString();
            txtDNI.Text = cliente.DNI;
            txtNombre.Text = cliente.Nombre;
            txtApellido.Text = cliente.Apellido;
            txtEmail.Text = cliente.Email;
            txtTelefono.Text = cliente.Telefono;
            chkMembresiaActiva.Checked = cliente.MembresiaActiva;
        }

        /// <summary>
        /// Limpia los campos del formulario y la selección de la grilla.
        /// </summary>
        private void LimpiarCamposYSeleccion()
        {
            clienteSeleccionado = null;
            txtIdCliente.Clear();
            txtDNI.Clear();
            txtNombre.Clear();
            txtApellido.Clear();
            txtEmail.Clear();
            txtTelefono.Clear();
            chkMembresiaActiva.Checked = true;

            dgvClientes.ClearSelection();
            HabilitarCampos(true);
            btnEliminar.Enabled = false;
            txtDNI.Focus();
        }

        /// <summary>
        /// Habilita o deshabilita los campos de edición.
        /// </summary>
        private void HabilitarCampos(bool habilitar)
        {
            txtDNI.Enabled = habilitar;
            txtNombre.Enabled = habilitar;
            txtApellido.Enabled = habilitar;
            txtEmail.Enabled = habilitar;
            txtTelefono.Enabled = habilitar;
            chkMembresiaActiva.Enabled = habilitar;
            btnGuardar.Enabled = habilitar;
        }

        /// <summary>
        /// Prepara el formulario para ingresar un nuevo cliente.
        /// </summary>
        private void btnNuevo_Click(object sender, EventArgs e)
        {
            LimpiarCamposYSeleccion();
        }

        /// <summary>
        /// Guarda un cliente nuevo o modifica uno existente.
        /// </summary>
        private void btnGuardar_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtDNI.Text) || string.IsNullOrWhiteSpace(txtNombre.Text) || string.IsNullOrWhiteSpace(txtApellido.Text))
                {
                    MessageBox.Show("DNI, Nombre y Apellido son obligatorios.", "Campos requeridos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (txtDNI.Text.Trim().Length < 7 || txtDNI.Text.Trim().Length > 8 || !txtDNI.Text.Trim().All(char.IsDigit))
                {
                    MessageBox.Show("El DNI debe tener 7 u 8 dígitos numéricos.", "DNI inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtDNI.Focus();
                    return;
                }
                if (!string.IsNullOrWhiteSpace(txtEmail.Text) && !txtEmail.Text.Contains("@"))
                {
                    MessageBox.Show("El formato del Email no parece válido.", "Email inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtEmail.Focus();
                    return;
                }

                BECliente clienteAGuardar;
                bool esNuevo = false;

                // Determina si es un cliente nuevo o una modificación
                if (clienteSeleccionado != null && clienteSeleccionado.Id.ToString() == txtIdCliente.Text && clienteSeleccionado.Id != 0)
                {
                    clienteAGuardar = clienteSeleccionado;
                    esNuevo = false;
                }
                else
                {
                    clienteAGuardar = new BECliente();
                    esNuevo = true;
                }

                // Asigna los valores de los controles al objeto
                clienteAGuardar.DNI = txtDNI.Text.Trim();
                clienteAGuardar.Nombre = txtNombre.Text.Trim();
                clienteAGuardar.Apellido = txtApellido.Text.Trim();
                clienteAGuardar.Email = txtEmail.Text.Trim();
                clienteAGuardar.Telefono = txtTelefono.Text.Trim();
                clienteAGuardar.MembresiaActiva = chkMembresiaActiva.Checked;

                bllCliente.Guardar(clienteAGuardar);

                MessageBox.Show(esNuevo ? "Cliente creado correctamente." : "Cliente modificado correctamente.",
                                "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                CargarGrilla();
                LimpiarCamposYSeleccion();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar el cliente: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Elimina el cliente seleccionado, previa confirmación.
        /// </summary>
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (clienteSeleccionado == null)
            {
                MessageBox.Show("Seleccione un cliente de la lista para eliminar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult confirmacion = MessageBox.Show($"¿Está seguro de eliminar a {clienteSeleccionado.Nombre} {clienteSeleccionado.Apellido} (DNI: {clienteSeleccionado.DNI})?",
                                                      "Confirmar Eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirmacion == DialogResult.Yes)
            {
                try
                {
                    bllCliente.Eliminar(clienteSeleccionado.Id);

                    MessageBox.Show("Cliente eliminado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    CargarGrilla();
                    LimpiarCamposYSeleccion();
                }
                catch (InvalidOperationException exInv)
                {
                    MessageBox.Show(exInv.Message, "Operación no permitida", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al eliminar el cliente: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        /// <summary>
        /// Filtra la grilla según el texto ingresado.
        /// </summary>
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            CargarGrilla(txtBuscar.Text.Trim());
        }

        /// <summary>
        /// Permite buscar presionando Enter en el cuadro de texto.
        /// </summary>
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