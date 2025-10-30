using BE;
using Services;
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
    public partial class frmInicio : Form
    {
        private Form formularioActivo = null;

        public frmInicio()
        {
            InitializeComponent();
        }

        // Evento Load: Se ejecuta cuando el formulario se carga por primera vez
        private void frmInicio_Load(object sender, EventArgs e)
        {
            PersonalizarUI(); // Aplica permisos a los menús
            lblTituloFormHijo.Text = "Bienvenido"; // Título inicial
        }

        private void PersonalizarUI()
        {
            BEUsuario usuario = Session.ObtenerInstancia.UsuarioLogueado;

            if (usuario != null)
            {
                lblUsuarioLogueado.Text = $"Usuario: {usuario.NombreUsuario}";

                menuGestionClientes.Visible = Session.ObtenerInstancia.TienePermiso("PERM_GEST_CLIENTES");
                menuGestionProfesionales.Visible = Session.ObtenerInstancia.TienePermiso("PERM_GEST_PROFESIONALES");
                menuGestionActividades.Visible = Session.ObtenerInstancia.TienePermiso("PERM_GEST_ACTIVIDADES");

                // --- INICIO DE CORRECCIÓN (Permisos Submenú) ---
                bool tienePermisoTurnos = Session.ObtenerInstancia.TienePermiso("PERM_GEST_TURNOS");
                bool tienePermisoAsistencia = Session.ObtenerInstancia.TienePermiso("PERM_REG_ASISTENCIA"); // Asume este permiso

                // El menú padre es visible si tiene al menos un hijo visible
                menuGestionTurnos.Visible = tienePermisoTurnos || tienePermisoAsistencia;
                // Asigna visibilidad a cada hijo
                subMenuGestionarTurnos.Visible = tienePermisoTurnos;
                subMenuRegistroAsistencia.Visible = tienePermisoAsistencia;

                menuLiquidaciones.Visible = Session.ObtenerInstancia.TienePermiso("PERM_CALC_LIQ") ||
                                           Session.ObtenerInstancia.TienePermiso("PERM_EMIT_LIQ");

                menuDashboard.Visible = Session.ObtenerInstancia.TienePermiso("PERM_VER_DASHBOARD");
                menuSeguridad.Visible = Session.ObtenerInstancia.TienePermiso("PERM_GEST_SEGURIDAD");

                // Asume PERM_BACKUP, PERM_RESTORE, PERM_BITACORA
                bool tienePermisoBackup = Session.ObtenerInstancia.TienePermiso("PERM_BACKUP");
                bool tienePermisoRestore = Session.ObtenerInstancia.TienePermiso("PERM_RESTORE");
                bool tienePermisoBitacora = Session.ObtenerInstancia.TienePermiso("PERM_BITACORA");

                menuBackupRestore.Visible = tienePermisoBackup || tienePermisoRestore || tienePermisoBitacora;
                subMenuBackup.Visible = tienePermisoBackup;
                subMenuRestore.Visible = tienePermisoRestore;
                subMenuBitacora.Visible = tienePermisoBitacora;
            }
            else
            {
                MessageBox.Show("Error: Sesión no válida. Se cerrará la aplicación.", "Error de Sesión", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }
        }

        private void AbrirFormularioHijo(Form formularioHijo)
        {
            if (formularioHijo == null) return;

            if (formularioActivo != null && formularioActivo.GetType() == formularioHijo.GetType())
            {
                formularioHijo.Dispose();
                formularioActivo.BringToFront();
                return;
            }

            if (formularioActivo != null)
            {
                formularioActivo.Close();
            }

            formularioActivo = formularioHijo;
            formularioHijo.TopLevel = false;
            formularioHijo.FormBorderStyle = FormBorderStyle.None;
            formularioHijo.Dock = DockStyle.Fill;
            panelContenedor.Controls.Add(formularioHijo);
            panelContenedor.Tag = formularioHijo;
            formularioHijo.BringToFront();
            formularioHijo.FormClosed += FormularioHijo_FormClosed;
            formularioHijo.Show();

            lblTituloFormHijo.Text = formularioHijo.Text;
            lblTituloFormHijo.BringToFront();
        }

        private void FormularioHijo_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (sender == formularioActivo)
            {
                formularioActivo = null;
                lblTituloFormHijo.Text = "Bienvenido";
            }
            if (sender is Form form)
            {
                form.Dispose();
            }
        }

        // --- Eventos Click de los Menús ---

        private void menuGestionClientes_Click(object sender, EventArgs e)
        {
            AbrirFormularioHijo(new frmGestionClientes());
        }

        private void menuGestionProfesionales_Click(object sender, EventArgs e)
        {
            AbrirFormularioHijo(new frmGestionProfesionales());
        }

        private void menuGestionActividades_Click(object sender, EventArgs e)
        {
            AbrirFormularioHijo(new frmGestionActividades());
        }

        // --- MÉTODOS DE SUBMENÚ ---
        private void subMenuGestionarTurnos_Click(object sender, EventArgs e)
        {
            AbrirFormularioHijo(new frmGestionTurnos());
        }

        private void subMenuRegistroAsistencia_Click(object sender, EventArgs e)
        {
            // Asegúrate de haber creado frmRegistroAsistencia.cs
            AbrirFormularioHijo(new frmRegistroAsistencia());
        }
        // --- FIN MÉTODOS DE SUBMENÚ ---

        private void menuLiquidaciones_Click(object sender, EventArgs e)
        {
            AbrirFormularioHijo(new frmGestionLiquidaciones());
        }

        private void menuDashboard_Click(object sender, EventArgs e)
        {
            AbrirFormularioHijo(new frmDashboard());
        }

        private void menuSeguridad_Click(object sender, EventArgs e)
        {
            AbrirFormularioHijo(new frmUsuarios());
        }

        private void subMenuBackup_Click(object sender, EventArgs e)
        {
            AbrirFormularioHijo(new frmBackup());
        }

        private void subMenuRestore_Click(object sender, EventArgs e)
        {
            AbrirFormularioHijo(new frmRestore());
        }

        private void subMenuBitacora_Click(object sender, EventArgs e)
        {
            AbrirFormularioHijo(new frmBitacora());
        }

        private void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            DialogResult resultado = MessageBox.Show("¿Está seguro que desea cerrar la sesión?", "Cerrar Sesión", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (resultado == DialogResult.Yes)
            {
                Session.ObtenerInstancia.CerrarSesion();
                this.Hide();
                frmLogin loginForm = new frmLogin();
                loginForm.FormClosed += (s, args) => Application.ExitThread();
                loginForm.Show();
            }
        }

        private void frmInicio_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing && Session.ObtenerInstancia.IsLoggedIn)
            {
                DialogResult resultado = MessageBox.Show("¿Está seguro que desea salir de la aplicación?", "Salir", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (resultado == DialogResult.No)
                {
                    e.Cancel = true;
                }
                else
                {
                    Application.Exit();
                }
            }
        }
    }
}