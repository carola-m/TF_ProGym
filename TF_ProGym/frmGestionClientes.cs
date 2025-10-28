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
        private BECliente clienteSeleccionado = null; // Para guardar el cliente al editar/eliminar

        public frmGestionClientes()
        {
            InitializeComponent();
        }

        private void frmGestionClientes_Load(object sender, EventArgs e)
        {
            // Configuración inicial del DataGridView para autogenerar columnas
            dgvClientes.AutoGenerateColumns = true; // <-- Habilitar autogeneración
            dgvClientes.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvClientes.MultiSelect = false;
            dgvClientes.ReadOnly = true; // Hace toda la grilla de solo lectura visualmente
            dgvClientes.AllowUserToAddRows = false;
            dgvClientes.AllowUserToDeleteRows = false; // No permitir borrar filas directamente
            dgvClientes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill; // Ajustar columnas

            CargarGrilla();
            LimpiarCamposYSeleccion(); // Estado inicial limpio
        }

        // Ya no necesitamos ConfigurarColumnasDGV()

        private void CargarGrilla(string filtro = null)
        {
            try
            {
                var listaClientes = bllCliente.Listar();

                if (!string.IsNullOrWhiteSpace(filtro))
                {
                    filtro = filtro.ToLower();
                    // Filtrar por DNI, Nombre o Apellido (ignorando mayúsculas/minúsculas)
                    listaClientes = listaClientes.Where(c => c.DNI.Contains(filtro) ||
                                                             (c.Nombre?.ToLower().Contains(filtro) ?? false) ||
                                                             (c.Apellido?.ToLower().Contains(filtro) ?? false))
                                                 .ToList();
                }

                dgvClientes.DataSource = null; // Limpiar enlace anterior
                dgvClientes.DataSource = listaClientes; // Asignar la lista directamente

                // Ocultar columnas no deseadas (ej. ID) DESPUÉS de asignar el DataSource
                if (dgvClientes.Columns.Contains("Id"))
                {
                    dgvClientes.Columns["Id"].Visible = false;
                }
                // Puedes ocultar otras columnas si es necesario:
                // if (dgvClientes.Columns.Contains("FechaRegistro"))
                // {
                //     dgvClientes.Columns["FechaRegistro"].HeaderText = "Fecha Reg."; // Cambiar título
                //     // dgvClientes.Columns["FechaRegistro"].DefaultCellStyle.Format = "dd/MM/yy"; // Formatear fecha
                // }
                if (dgvClientes.Columns.Contains("MembresiaActiva"))
                {
                    dgvClientes.Columns["MembresiaActiva"].HeaderText = "Activo"; // Cambiar título
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar la lista de clientes: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Evento cuando cambia la selección en la grilla
        private void dgvClientes_SelectionChanged(object sender, EventArgs e)
        {
            // Asegurarse de que hay una fila seleccionada y que el objeto asociado es un BECliente
            if (dgvClientes.CurrentRow != null && dgvClientes.CurrentRow.DataBoundItem is BECliente cliente)
            {
                clienteSeleccionado = cliente; // Guarda la referencia al cliente seleccionado
                MostrarDatosCliente(cliente); // Muestra los datos en los campos de texto/checkbox
                HabilitarCampos(true); // Habilita los campos para posible edición
                btnEliminar.Enabled = true; // Habilita el botón de eliminar
            }
            else
            {
                // Si no hay selección válida, limpia la referencia
                // clienteSeleccionado = null;
                // Opcional: Podrías llamar a LimpiarCamposYSeleccion() si quieres que los campos se limpien al deseleccionar
            }
        }

        // Muestra los datos de un cliente en los controles del formulario
        private void MostrarDatosCliente(BECliente cliente)
        {
            txtIdCliente.Text = cliente.Id.ToString(); // Muestra el ID (campo ReadOnly)
            txtDNI.Text = cliente.DNI;
            txtNombre.Text = cliente.Nombre;
            txtApellido.Text = cliente.Apellido;
            txtEmail.Text = cliente.Email;
            txtTelefono.Text = cliente.Telefono;
            chkMembresiaActiva.Checked = cliente.MembresiaActiva;
        }

        // Limpia los campos del formulario y la selección de la grilla
        private void LimpiarCamposYSeleccion()
        {
            clienteSeleccionado = null; // Ya no hay cliente seleccionado
            txtIdCliente.Clear();
            txtDNI.Clear();
            txtNombre.Clear();
            txtApellido.Clear();
            txtEmail.Clear();
            txtTelefono.Clear();
            chkMembresiaActiva.Checked = true; // Estado por defecto para un nuevo cliente

            dgvClientes.ClearSelection(); // Quita la selección visual de la grilla
            HabilitarCampos(true); // Habilita campos para ingresar un nuevo cliente
            btnEliminar.Enabled = false; // Deshabilita el botón Eliminar
            txtDNI.Focus(); // Pone el foco en el campo DNI para empezar a escribir
        }

        // Habilita o deshabilita los campos de edición
        private void HabilitarCampos(bool habilitar)
        {
            txtDNI.Enabled = habilitar;
            txtNombre.Enabled = habilitar;
            txtApellido.Enabled = habilitar;
            txtEmail.Enabled = habilitar;
            txtTelefono.Enabled = habilitar;
            chkMembresiaActiva.Enabled = habilitar;
            btnGuardar.Enabled = habilitar;
            // El botón eliminar se habilita/deshabilita según si hay selección en la grilla
        }


        // Evento Click del botón Nuevo
        private void btnNuevo_Click(object sender, EventArgs e)
        {
            LimpiarCamposYSeleccion(); // Limpia todo para un nuevo ingreso
        }


        // Evento Click del botón Guardar (Crea o Modifica)
        private void btnGuardar_Click_1(object sender, EventArgs e)
        {
            try
            {
                // **Validaciones de Entrada** (importante hacerlas antes de llamar a BLL)
                if (string.IsNullOrWhiteSpace(txtDNI.Text) || string.IsNullOrWhiteSpace(txtNombre.Text) || string.IsNullOrWhiteSpace(txtApellido.Text))
                {
                    MessageBox.Show("DNI, Nombre y Apellido son obligatorios.", "Campos requeridos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return; // Detiene la ejecución si faltan datos
                }
                if (txtDNI.Text.Trim().Length < 7 || txtDNI.Text.Trim().Length > 8 || !txtDNI.Text.Trim().All(char.IsDigit))
                {
                    MessageBox.Show("El DNI debe tener 7 u 8 dígitos numéricos.", "DNI inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtDNI.Focus(); // Pone el foco en el campo DNI
                    return;
                }
                // Validación simple de email (solo si se ingresó algo)
                if (!string.IsNullOrWhiteSpace(txtEmail.Text) && !txtEmail.Text.Contains("@"))
                {
                    MessageBox.Show("El formato del Email no parece válido.", "Email inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtEmail.Focus();
                    return;
                }
                // Puedes añadir más validaciones (teléfono, etc.)


                BECliente clienteAGuardar;
                bool esNuevo = false;

                // Determina si es un cliente nuevo o una modificación
                if (clienteSeleccionado != null && clienteSeleccionado.Id.ToString() == txtIdCliente.Text && clienteSeleccionado.Id != 0)
                {
                    // Es una Modificación: Usa el objeto que ya tenemos seleccionado
                    clienteAGuardar = clienteSeleccionado;
                    esNuevo = false;
                }
                else
                {
                    // Es un Nuevo Cliente: Crea una nueva instancia
                    clienteAGuardar = new BECliente();
                    esNuevo = true;
                    // El ID se asignará en la capa MPP al guardar
                }

                // **Asigna los valores** de los controles al objeto cliente
                clienteAGuardar.DNI = txtDNI.Text.Trim();
                clienteAGuardar.Nombre = txtNombre.Text.Trim();
                clienteAGuardar.Apellido = txtApellido.Text.Trim();
                clienteAGuardar.Email = txtEmail.Text.Trim();
                clienteAGuardar.Telefono = txtTelefono.Text.Trim();
                clienteAGuardar.MembresiaActiva = chkMembresiaActiva.Checked;
                // La FechaRegistro la maneja MPP si es nuevo, o se mantiene si es modificación

                // **Llama a la capa BLL** para realizar la operación de guardado
                bllCliente.Guardar(clienteAGuardar);

                // Informa al usuario
                MessageBox.Show(esNuevo ? "Cliente creado correctamente." : "Cliente modificado correctamente.",
                                "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                CargarGrilla(); // Recarga la grilla para mostrar los cambios
                LimpiarCamposYSeleccion(); // Limpia los campos para la siguiente operación
            }
            catch (Exception ex) // Captura cualquier error que ocurra en BLL o MPP
            {
                MessageBox.Show("Error al guardar el cliente: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Evento Click del botón Eliminar
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            // Verifica si hay un cliente seleccionado en la grilla
            if (clienteSeleccionado == null)
            {
                MessageBox.Show("Seleccione un cliente de la lista para eliminar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Pide confirmación al usuario
            DialogResult confirmacion = MessageBox.Show($"¿Está seguro de eliminar a {clienteSeleccionado.Nombre} {clienteSeleccionado.Apellido} (DNI: {clienteSeleccionado.DNI})?",
                                                      "Confirmar Eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirmacion == DialogResult.Yes)
            {
                try
                {
                    // Llama a la capa BLL para eliminar
                    bllCliente.Eliminar(clienteSeleccionado.Id);

                    MessageBox.Show("Cliente eliminado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    CargarGrilla(); // Recarga la grilla
                    LimpiarCamposYSeleccion(); // Limpia los campos
                }
                catch (InvalidOperationException exInv) // Captura errores específicos de reglas de negocio (ej. membresía activa)
                {
                    MessageBox.Show(exInv.Message, "Operación no permitida", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                catch (Exception ex) // Captura otros errores (ej. de archivo)
                {
                    MessageBox.Show("Error al eliminar el cliente: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // Evento Click del botón Buscar
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            CargarGrilla(txtBuscar.Text.Trim()); // Llama a CargarGrilla pasándole el texto del filtro
        }

        // Opcional: Ejecutar búsqueda al presionar Enter en el TextBox de búsqueda
        private void txtBuscar_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                e.Handled = true;
                btnBuscar.PerformClick(); // Simula un clic en el botón Buscar
            }
        }
    }
}
