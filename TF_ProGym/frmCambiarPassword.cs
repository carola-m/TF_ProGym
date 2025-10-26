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
    public partial class frmCambiarPassword : Form
    {
        public frmCambiarPassword()
        {
            InitializeComponent();
        }

        private readonly BEUsuario _usuario; // Guardamos el usuario a modificar
        private readonly BLLSeguridad _bllSeguridad = new BLLSeguridad(); // Usamos BLLSeguridad

        // Constructor principal que recibe el usuario
        public frmCambiarPassword(BEUsuario usuarioLogueado)
        {
            InitializeComponent();
            if (usuarioLogueado == null)
            {
                MessageBox.Show("Error: No se proporcionó un usuario válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                // Cerramos inmediatamente si no hay usuario para evitar errores
                // Usamos Load event para cerrar para evitar problemas en constructor
                this.Load += (s, e) => this.Close();
                return;
            }
            _usuario = usuarioLogueado;

            // Opcional: Mostrar para qué usuario se cambia la contraseña
            // Asegúrate de tener un Label llamado lblInfoUsuario en el diseño
            // Si no lo tienes, comenta o elimina la línea siguiente:
            // lblInfoUsuario.Text = $"Estableciendo contraseña para: {_usuario.NombreUsuario}";

            this.Text = "Establecer Nueva Contraseña";
        }

        // Evento click del botón Guardar (ajusta el nombre si es btnGuardar_Click_1)
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            string nueva = txtNuevaPassword.Text;
            string confirmar = txtConfirmarPassword.Text;

            // Validaciones (iguales a tu modelo)
            if (string.IsNullOrWhiteSpace(nueva) || string.IsNullOrWhiteSpace(confirmar))
            {
                MessageBox.Show("Completar ambos campos.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNuevaPassword.Focus();
                return;
            }

            if (nueva.Length < 4) // Mantén la misma regla de longitud
            {
                MessageBox.Show("La contraseña debe tener al menos 4 caracteres.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNuevaPassword.Focus();
                return;
            }

            if (nueva != confirmar)
            {
                MessageBox.Show("Las contraseñas no coinciden.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtConfirmarPassword.Clear();
                txtConfirmarPassword.Focus();
                return;
            }

            try
            {
                // Llamamos a BLLSeguridad para que encripte (hashee) y guarde la nueva contraseña
                _bllSeguridad.ModificarUsuario(_usuario, nueva);

                // Marcamos que ya no necesita cambiar la contraseña
                _usuario.DebeCambiarPassword = false;
                _bllSeguridad.ModificarUsuario(_usuario); // Llama de nuevo para guardar este cambio

                MessageBox.Show("Contraseña actualizada correctamente. Por favor, inicia sesión nuevamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // **Comportamiento de cierre según tu modelo:**
                // En lugar de DialogResult, mostramos el login y cerramos este form.
                frmLogin frmLogin = new frmLogin(); // Asegúrate que tu form de login se llame frmLogin
                frmLogin.Show();
                this.Close(); // Cierra este formulario (frmCambiarContrasena)
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar la nueva contraseña: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                // No cerramos el form en caso de error
            }
        }

        // Opcional: Permitir guardar con Enter en el campo de confirmar
        private void txtConfirmarContraseña_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                e.Handled = true;
                btnGuardarCambio.PerformClick(); // Llama al evento del botón guardar
            }
        }
        // Opcional: Mover foco con Enter desde nueva contraseña
        private void txtNuevaContraseña_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                e.Handled = true;
                txtConfirmarPassword.Focus();
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            // Decide qué hacer al cancelar: ¿volver al login? ¿cerrar todo?
            frmLogin frmLogin = new frmLogin();
            frmLogin.Show();
            this.Close();
        }
       

    }
}
        