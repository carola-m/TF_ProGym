using BE;
using BLL;
using Services;


namespace CapaPresentacion
{
    public partial class frmLogin : Form
    {
        private readonly BLLSeguridad bllSeguridad = new BLLSeguridad();

        public frmLogin()
        {
            InitializeComponent();
        }

        // Conecta el evento Click de tu btnIngresar a este método
        private void btnIngresar_Click_1(object sender, EventArgs e)
        {
            string nombreUsuario = txtUsuario.Text.Trim();
            string password = txtPassword.Text;

            if (string.IsNullOrEmpty(nombreUsuario) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Por favor, ingrese usuario y contraseña.", "Campos vacíos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtUsuario.Focus(); // Poner foco en usuario
                return;
            }
            try
            {
                BEUsuario usuario = bllSeguridad.Login(nombreUsuario, password);

                if (usuario != null)
                {
                    // Obtener los permisos consolidados del usuario
                    List<BEPermisoComponent> permisos = bllSeguridad.ObtenerPermisosUsuario(usuario.Id);

                    // Iniciar la sesión global
                    Session.ObtenerInstancia.IniciarSesion(usuario, permisos);

                    // Verificar si debe cambiar contraseña (y no es admin)
                    if (usuario.DebeCambiarPassword && !usuario.NombreUsuario.Equals("admin", StringComparison.OrdinalIgnoreCase))
                    {
                        MessageBox.Show("Es tu primer inicio de sesión o se ha reseteado tu contraseña. Debes cambiarla ahora.", "Cambiar Contraseña", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        using (frmCambiarPassword frmCambio = new frmCambiarPassword(usuario))
                        {
                            var result = frmCambio.ShowDialog(); // Mostrar modalmente
                            if (result == DialogResult.OK)
                            {
                                MessageBox.Show("Contraseña cambiada. Por favor, inicia sesión de nuevo.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                // Limpiar campos y mantener el login abierto para reintentar
                                txtPassword.Clear();
                                txtUsuario.Focus();
                                Session.ObtenerInstancia.CerrarSesion(); // Cierra la sesión temporal
                            }
                            else
                            {
                                // Si cancela el cambio, cierra la aplicación o lo desloguea
                                Session.ObtenerInstancia.CerrarSesion();
                                Application.Exit(); // O cierra solo este form: this.Close();
                            }
                        }
                    }
                    else
                    {
                        frmInicio frmPrincipal = new frmInicio();
                        frmPrincipal.FormClosed += (s, args) => this.Close(); // Cierra login si se cierra el principal
                        frmPrincipal.Show();
                        this.Hide(); // Ocultar el formulario de login
                    }
                }
                else
                {
                    MessageBox.Show("Usuario o contraseña incorrectos, o usuario inactivo.", "Error de Login", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtPassword.Clear();
                    txtUsuario.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error inesperado durante el login: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Conecta el evento Click de tu btnCancelar a este método
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        // Conecta el evento KeyPress de tu txtPassword a este método
        private void txtPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                e.Handled = true; // Evita el sonido 'ding'
                // Asegúrate de que el nombre del botón sea 'btnIngresar' en el diseñador
                btnIngresar.PerformClick(); // Simula el clic en el botón Ingresar
            }
        }

        // Conecta el evento KeyPress de tu txtUsuario a este método
        private void txtUsuario_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                e.Handled = true;
                txtPassword.Focus(); // Mueve el foco al siguiente campo
            }
        }

        // --- NUEVO MÉTODO ---
        // Evento para el CheckBox de "Mostrar contraseña"
        private void chkVerPassword_CheckedChanged(object sender, EventArgs e)
        {
            if (chkVerPassword.Checked)
            {
                txtPassword.PasswordChar = '\0'; 
            }
            else
            {
                txtPassword.PasswordChar = '*';
            }
        }
    }
}