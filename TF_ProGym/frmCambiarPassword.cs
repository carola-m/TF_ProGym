using BE;
using BLL;


namespace CapaPresentacion
{
    public partial class frmCambiarPassword : Form
    {
        public frmCambiarPassword()
        {
            InitializeComponent();
        }

        private readonly BEUsuario _usuario; // Guardamos el usuario a modificar
        private readonly BLLSeguridad _bllSeguridad = new BLLSeguridad();

        public frmCambiarPassword(BEUsuario usuarioLogueado)
        {
            InitializeComponent();
            if (usuarioLogueado == null)
            {
                MessageBox.Show("Error: No se proporcionó un usuario válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Load += (s, e) => this.Close();
                return;
            }
            _usuario = usuarioLogueado;

            this.Text = "Establecer Nueva Contraseña";
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            string nueva = txtNuevaPassword.Text;
            string confirmar = txtConfirmarPassword.Text;

            if (string.IsNullOrWhiteSpace(nueva) || string.IsNullOrWhiteSpace(confirmar))
            {
                MessageBox.Show("Completar ambos campos.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNuevaPassword.Focus();
                return;
            }

            if (nueva.Length < 4)
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
                // Llamamos a BLLSeguridad para que encripte y guarde la nueva contraseña
                _bllSeguridad.ModificarUsuario(_usuario, nueva);

                // Marcamos que ya no necesita cambiar la contraseña
                _usuario.DebeCambiarPassword = false;
                _bllSeguridad.ModificarUsuario(_usuario); // Llama de nuevo para guardar este cambio

                MessageBox.Show("Contraseña actualizada correctamente. Por favor, inicia sesión nuevamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar la nueva contraseña: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Permitir guardar con Enter en el campo de confirmar
        private void txtConfirmarContraseña_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter) ; 
            
        }
        
        // Mover foco con Enter desde nueva contraseña
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
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void chkVerPasswordNueva_CheckedChanged(object sender, EventArgs e)
        {
            if (chkVerPasswordNueva.Checked)
            {
                txtNuevaPassword.PasswordChar = '\0';
                txtConfirmarPassword.PasswordChar = '\0';
            }
            else
            {
                txtNuevaPassword.PasswordChar = '*';
                txtConfirmarPassword.PasswordChar = '*';
            }
        }
    }
}