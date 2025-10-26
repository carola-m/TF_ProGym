
namespace CapaPresentacion
{
    partial class frmUsuarios
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            gbCrearUsuario = new GroupBox();
            btnLimpiarCamposUsuario = new Button();
            btnBorrarUsuario = new Button();
            btnEditarUsuario = new Button();
            btnAltaUsuario = new Button();
            chkActivoUsuario = new CheckBox();
            txtContraseña = new TextBox();
            lblPassword = new Label();
            txtNombreUsuario = new TextBox();
            lblUsuario = new Label();
            txtCodigoUsuario = new TextBox();
            lblCodigoUsuario = new Label();
            cbUsuarioEditarEliminar = new ComboBox();
            lblUsuarioEditar = new Label();
            gbCrearRol = new GroupBox();
            btnLimpiarCamposRol = new Button();
            btnBorrarRol = new Button();
            btnEditarRol = new Button();
            btnAltaRol = new Button();
            chkActivoRol = new CheckBox();
            txtNombreRol = new TextBox();
            lblNombreRol = new Label();
            txtCodigoRol = new TextBox();
            lblCodigoRol = new Label();
            cbRolEditarEliminar = new ComboBox();
            lblRolEditar = new Label();
            gbAsociarUsuarioRol = new GroupBox();
            btnDesasociarUsuarioArol = new Button();
            btnAsociarUsuarioArol = new Button();
            cmbRolAasociarAusuario = new ComboBox();
            lblRolAsociar = new Label();
            cmbUsuarioAasociarRol = new ComboBox();
            lblUsuarioAsociar = new Label();
            gbAsociarPermisoRol = new GroupBox();
            btnDesasociarPermisoArol = new Button();
            btnAsociarPermisoArol = new Button();
            trViewPermisoRol = new TreeView();
            lblPermisosRol = new Label();
            btnAsociarPermisosMarcados = new Button();
            cbRolParaAsociarApermiso = new ComboBox();
            lblRolDisponible = new Label();
            trvwPermisoAasociar = new TreeView();
            lblPermisosDisponibles = new Label();
            gbRolesYPermisosUsuario = new GroupBox();
            trvRolesyPermisosPorUsuario = new TreeView();
            gbCrearUsuario.SuspendLayout();
            gbCrearRol.SuspendLayout();
            gbAsociarUsuarioRol.SuspendLayout();
            gbAsociarPermisoRol.SuspendLayout();
            gbRolesYPermisosUsuario.SuspendLayout();
            SuspendLayout();
            // 
            // gbCrearUsuario
            // 
            gbCrearUsuario.Controls.Add(btnLimpiarCamposUsuario);
            gbCrearUsuario.Controls.Add(btnBorrarUsuario);
            gbCrearUsuario.Controls.Add(btnEditarUsuario);
            gbCrearUsuario.Controls.Add(btnAltaUsuario);
            gbCrearUsuario.Controls.Add(chkActivoUsuario);
            gbCrearUsuario.Controls.Add(txtContraseña);
            gbCrearUsuario.Controls.Add(lblPassword);
            gbCrearUsuario.Controls.Add(txtNombreUsuario);
            gbCrearUsuario.Controls.Add(lblUsuario);
            gbCrearUsuario.Controls.Add(txtCodigoUsuario);
            gbCrearUsuario.Controls.Add(lblCodigoUsuario);
            gbCrearUsuario.Controls.Add(cbUsuarioEditarEliminar);
            gbCrearUsuario.Controls.Add(lblUsuarioEditar);
            gbCrearUsuario.Location = new Point(14, 16);
            gbCrearUsuario.Margin = new Padding(3, 4, 3, 4);
            gbCrearUsuario.Name = "gbCrearUsuario";
            gbCrearUsuario.Padding = new Padding(3, 4, 3, 4);
            gbCrearUsuario.Size = new Size(400, 320);
            gbCrearUsuario.TabIndex = 0;
            gbCrearUsuario.TabStop = false;
            gbCrearUsuario.Text = "Crear Usuario";
            // 
            // btnLimpiarCamposUsuario
            // 
            btnLimpiarCamposUsuario.Location = new Point(343, 213);
            btnLimpiarCamposUsuario.Margin = new Padding(3, 4, 3, 4);
            btnLimpiarCamposUsuario.Name = "btnLimpiarCamposUsuario";
            btnLimpiarCamposUsuario.Size = new Size(46, 33);
            btnLimpiarCamposUsuario.TabIndex = 8;
            btnLimpiarCamposUsuario.Text = "Limp.";
            btnLimpiarCamposUsuario.UseVisualStyleBackColor = true;
            // 
            // btnBorrarUsuario
            // 
            btnBorrarUsuario.Location = new Point(286, 213);
            btnBorrarUsuario.Margin = new Padding(3, 4, 3, 4);
            btnBorrarUsuario.Name = "btnBorrarUsuario";
            btnBorrarUsuario.Size = new Size(46, 33);
            btnBorrarUsuario.TabIndex = 7;
            btnBorrarUsuario.Text = "Baja";
            btnBorrarUsuario.UseVisualStyleBackColor = true;
            // 
            // btnEditarUsuario
            // 
            btnEditarUsuario.Location = new Point(286, 107);
            btnEditarUsuario.Margin = new Padding(3, 4, 3, 4);
            btnEditarUsuario.Name = "btnEditarUsuario";
            btnEditarUsuario.Size = new Size(103, 40);
            btnEditarUsuario.TabIndex = 6;
            btnEditarUsuario.Text = "Editar";
            btnEditarUsuario.UseVisualStyleBackColor = true;
            // 
            // btnAltaUsuario
            // 
            btnAltaUsuario.Location = new Point(286, 53);
            btnAltaUsuario.Margin = new Padding(3, 4, 3, 4);
            btnAltaUsuario.Name = "btnAltaUsuario";
            btnAltaUsuario.Size = new Size(103, 40);
            btnAltaUsuario.TabIndex = 5;
            btnAltaUsuario.Text = "Alta";
            btnAltaUsuario.UseVisualStyleBackColor = true;
            // 
            // chkActivoUsuario
            // 
            chkActivoUsuario.AutoSize = true;
            chkActivoUsuario.Checked = true;
            chkActivoUsuario.CheckState = CheckState.Checked;
            chkActivoUsuario.Location = new Point(17, 280);
            chkActivoUsuario.Margin = new Padding(3, 4, 3, 4);
            chkActivoUsuario.Name = "chkActivoUsuario";
            chkActivoUsuario.Size = new Size(73, 24);
            chkActivoUsuario.TabIndex = 4;
            chkActivoUsuario.Text = "Activo";
            chkActivoUsuario.UseVisualStyleBackColor = true;
            // 
            // txtContraseña
            // 
            txtContraseña.Location = new Point(91, 233);
            txtContraseña.Margin = new Padding(3, 4, 3, 4);
            txtContraseña.Name = "txtContraseña";
            txtContraseña.PasswordChar = '*';
            txtContraseña.Size = new Size(171, 27);
            txtContraseña.TabIndex = 3;
            // 
            // lblPassword
            // 
            lblPassword.AutoSize = true;
            lblPassword.Location = new Point(14, 237);
            lblPassword.Name = "lblPassword";
            lblPassword.Size = new Size(73, 20);
            lblPassword.TabIndex = 0;
            lblPassword.Text = "Password:";
            // 
            // txtNombreUsuario
            // 
            txtNombreUsuario.Location = new Point(91, 187);
            txtNombreUsuario.Margin = new Padding(3, 4, 3, 4);
            txtNombreUsuario.Name = "txtNombreUsuario";
            txtNombreUsuario.Size = new Size(171, 27);
            txtNombreUsuario.TabIndex = 2;
            // 
            // lblUsuario
            // 
            lblUsuario.AutoSize = true;
            lblUsuario.Location = new Point(14, 191);
            lblUsuario.Name = "lblUsuario";
            lblUsuario.Size = new Size(62, 20);
            lblUsuario.TabIndex = 0;
            lblUsuario.Text = "Usuario:";
            // 
            // txtCodigoUsuario
            // 
            txtCodigoUsuario.Location = new Point(91, 140);
            txtCodigoUsuario.Margin = new Padding(3, 4, 3, 4);
            txtCodigoUsuario.Name = "txtCodigoUsuario";
            txtCodigoUsuario.ReadOnly = true;
            txtCodigoUsuario.Size = new Size(79, 27);
            txtCodigoUsuario.TabIndex = 1;
            txtCodigoUsuario.TabStop = false;
            // 
            // lblCodigoUsuario
            // 
            lblCodigoUsuario.AutoSize = true;
            lblCodigoUsuario.Location = new Point(14, 144);
            lblCodigoUsuario.Name = "lblCodigoUsuario";
            lblCodigoUsuario.Size = new Size(61, 20);
            lblCodigoUsuario.TabIndex = 0;
            lblCodigoUsuario.Text = "Código:";
            // 
            // cbUsuarioEditarEliminar
            // 
            cbUsuarioEditarEliminar.DropDownStyle = ComboBoxStyle.DropDownList;
            cbUsuarioEditarEliminar.FormattingEnabled = true;
            cbUsuarioEditarEliminar.Location = new Point(17, 60);
            cbUsuarioEditarEliminar.Margin = new Padding(3, 4, 3, 4);
            cbUsuarioEditarEliminar.Name = "cbUsuarioEditarEliminar";
            cbUsuarioEditarEliminar.Size = new Size(245, 28);
            cbUsuarioEditarEliminar.TabIndex = 0;
            // 
            // lblUsuarioEditar
            // 
            lblUsuarioEditar.AutoSize = true;
            lblUsuarioEditar.Location = new Point(17, 33);
            lblUsuarioEditar.Name = "lblUsuarioEditar";
            lblUsuarioEditar.Size = new Size(152, 20);
            lblUsuarioEditar.TabIndex = 0;
            lblUsuarioEditar.Text = "Usuario a editar/baja:";
            // 
            // gbCrearRol
            // 
            gbCrearRol.Controls.Add(btnLimpiarCamposRol);
            gbCrearRol.Controls.Add(btnBorrarRol);
            gbCrearRol.Controls.Add(btnEditarRol);
            gbCrearRol.Controls.Add(btnAltaRol);
            gbCrearRol.Controls.Add(chkActivoRol);
            gbCrearRol.Controls.Add(txtNombreRol);
            gbCrearRol.Controls.Add(lblNombreRol);
            gbCrearRol.Controls.Add(txtCodigoRol);
            gbCrearRol.Controls.Add(lblCodigoRol);
            gbCrearRol.Controls.Add(cbRolEditarEliminar);
            gbCrearRol.Controls.Add(lblRolEditar);
            gbCrearRol.Location = new Point(14, 347);
            gbCrearRol.Margin = new Padding(3, 4, 3, 4);
            gbCrearRol.Name = "gbCrearRol";
            gbCrearRol.Padding = new Padding(3, 4, 3, 4);
            gbCrearRol.Size = new Size(400, 267);
            gbCrearRol.TabIndex = 1;
            gbCrearRol.TabStop = false;
            gbCrearRol.Text = "Crear Rol";
            // 
            // btnLimpiarCamposRol
            // 
            btnLimpiarCamposRol.Location = new Point(343, 213);
            btnLimpiarCamposRol.Margin = new Padding(3, 4, 3, 4);
            btnLimpiarCamposRol.Name = "btnLimpiarCamposRol";
            btnLimpiarCamposRol.Size = new Size(46, 33);
            btnLimpiarCamposRol.TabIndex = 17;
            btnLimpiarCamposRol.Text = "Limp.";
            btnLimpiarCamposRol.UseVisualStyleBackColor = true;
            // 
            // btnBorrarRol
            // 
            btnBorrarRol.Location = new Point(286, 213);
            btnBorrarRol.Margin = new Padding(3, 4, 3, 4);
            btnBorrarRol.Name = "btnBorrarRol";
            btnBorrarRol.Size = new Size(46, 33);
            btnBorrarRol.TabIndex = 16;
            btnBorrarRol.Text = "Baja";
            btnBorrarRol.UseVisualStyleBackColor = true;
            // 
            // btnEditarRol
            // 
            btnEditarRol.Location = new Point(286, 107);
            btnEditarRol.Margin = new Padding(3, 4, 3, 4);
            btnEditarRol.Name = "btnEditarRol";
            btnEditarRol.Size = new Size(103, 40);
            btnEditarRol.TabIndex = 15;
            btnEditarRol.Text = "Editar";
            btnEditarRol.UseVisualStyleBackColor = true;
            // 
            // btnAltaRol
            // 
            btnAltaRol.Location = new Point(286, 53);
            btnAltaRol.Margin = new Padding(3, 4, 3, 4);
            btnAltaRol.Name = "btnAltaRol";
            btnAltaRol.Size = new Size(103, 40);
            btnAltaRol.TabIndex = 14;
            btnAltaRol.Text = "Alta";
            btnAltaRol.UseVisualStyleBackColor = true;
            // 
            // chkActivoRol
            // 
            chkActivoRol.AutoSize = true;
            chkActivoRol.Checked = true;
            chkActivoRol.CheckState = CheckState.Checked;
            chkActivoRol.Location = new Point(17, 220);
            chkActivoRol.Margin = new Padding(3, 4, 3, 4);
            chkActivoRol.Name = "chkActivoRol";
            chkActivoRol.Size = new Size(73, 24);
            chkActivoRol.TabIndex = 13;
            chkActivoRol.Text = "Activo";
            chkActivoRol.UseVisualStyleBackColor = true;
            // 
            // txtNombreRol
            // 
            txtNombreRol.Location = new Point(91, 173);
            txtNombreRol.Margin = new Padding(3, 4, 3, 4);
            txtNombreRol.Name = "txtNombreRol";
            txtNombreRol.Size = new Size(171, 27);
            txtNombreRol.TabIndex = 12;
            // 
            // lblNombreRol
            // 
            lblNombreRol.AutoSize = true;
            lblNombreRol.Location = new Point(14, 177);
            lblNombreRol.Name = "lblNombreRol";
            lblNombreRol.Size = new Size(67, 20);
            lblNombreRol.TabIndex = 0;
            lblNombreRol.Text = "Nombre:";
            // 
            // txtCodigoRol
            // 
            txtCodigoRol.Location = new Point(91, 127);
            txtCodigoRol.Margin = new Padding(3, 4, 3, 4);
            txtCodigoRol.Name = "txtCodigoRol";
            txtCodigoRol.ReadOnly = true;
            txtCodigoRol.Size = new Size(79, 27);
            txtCodigoRol.TabIndex = 11;
            txtCodigoRol.TabStop = false;
            // 
            // lblCodigoRol
            // 
            lblCodigoRol.AutoSize = true;
            lblCodigoRol.Location = new Point(14, 131);
            lblCodigoRol.Name = "lblCodigoRol";
            lblCodigoRol.Size = new Size(61, 20);
            lblCodigoRol.TabIndex = 0;
            lblCodigoRol.Text = "Código:";
            // 
            // cbRolEditarEliminar
            // 
            cbRolEditarEliminar.DropDownStyle = ComboBoxStyle.DropDownList;
            cbRolEditarEliminar.FormattingEnabled = true;
            cbRolEditarEliminar.Location = new Point(17, 60);
            cbRolEditarEliminar.Margin = new Padding(3, 4, 3, 4);
            cbRolEditarEliminar.Name = "cbRolEditarEliminar";
            cbRolEditarEliminar.Size = new Size(245, 28);
            cbRolEditarEliminar.TabIndex = 10;
            // 
            // lblRolEditar
            // 
            lblRolEditar.AutoSize = true;
            lblRolEditar.Location = new Point(17, 33);
            lblRolEditar.Name = "lblRolEditar";
            lblRolEditar.Size = new Size(124, 20);
            lblRolEditar.TabIndex = 0;
            lblRolEditar.Text = "Rol a editar/baja:";
            // 
            // gbAsociarUsuarioRol
            // 
            gbAsociarUsuarioRol.Controls.Add(btnDesasociarUsuarioArol);
            gbAsociarUsuarioRol.Controls.Add(btnAsociarUsuarioArol);
            gbAsociarUsuarioRol.Controls.Add(cmbRolAasociarAusuario);
            gbAsociarUsuarioRol.Controls.Add(lblRolAsociar);
            gbAsociarUsuarioRol.Controls.Add(cmbUsuarioAasociarRol);
            gbAsociarUsuarioRol.Controls.Add(lblUsuarioAsociar);
            gbAsociarUsuarioRol.Location = new Point(14, 627);
            gbAsociarUsuarioRol.Margin = new Padding(3, 4, 3, 4);
            gbAsociarUsuarioRol.Name = "gbAsociarUsuarioRol";
            gbAsociarUsuarioRol.Padding = new Padding(3, 4, 3, 4);
            gbAsociarUsuarioRol.Size = new Size(400, 200);
            gbAsociarUsuarioRol.TabIndex = 2;
            gbAsociarUsuarioRol.TabStop = false;
            gbAsociarUsuarioRol.Text = "Asociar Usuario a Rol";
            // 
            // btnDesasociarUsuarioArol
            // 
            btnDesasociarUsuarioArol.Location = new Point(286, 120);
            btnDesasociarUsuarioArol.Margin = new Padding(3, 4, 3, 4);
            btnDesasociarUsuarioArol.Name = "btnDesasociarUsuarioArol";
            btnDesasociarUsuarioArol.Size = new Size(103, 40);
            btnDesasociarUsuarioArol.TabIndex = 22;
            btnDesasociarUsuarioArol.Text = "Desasociar";
            btnDesasociarUsuarioArol.UseVisualStyleBackColor = true;
            // 
            // btnAsociarUsuarioArol
            // 
            btnAsociarUsuarioArol.Location = new Point(286, 60);
            btnAsociarUsuarioArol.Margin = new Padding(3, 4, 3, 4);
            btnAsociarUsuarioArol.Name = "btnAsociarUsuarioArol";
            btnAsociarUsuarioArol.Size = new Size(103, 40);
            btnAsociarUsuarioArol.TabIndex = 21;
            btnAsociarUsuarioArol.Text = "Asociar";
            btnAsociarUsuarioArol.UseVisualStyleBackColor = true;
            // 
            // cmbRolAasociarAusuario
            // 
            cmbRolAasociarAusuario.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbRolAasociarAusuario.FormattingEnabled = true;
            cmbRolAasociarAusuario.Location = new Point(17, 133);
            cmbRolAasociarAusuario.Margin = new Padding(3, 4, 3, 4);
            cmbRolAasociarAusuario.Name = "cmbRolAasociarAusuario";
            cmbRolAasociarAusuario.Size = new Size(245, 28);
            cmbRolAasociarAusuario.TabIndex = 20;
            // 
            // lblRolAsociar
            // 
            lblRolAsociar.AutoSize = true;
            lblRolAsociar.Location = new Point(17, 107);
            lblRolAsociar.Name = "lblRolAsociar";
            lblRolAsociar.Size = new Size(165, 20);
            lblRolAsociar.TabIndex = 0;
            lblRolAsociar.Text = "Rol a asociar al usuario:";
            // 
            // cmbUsuarioAasociarRol
            // 
            cmbUsuarioAasociarRol.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbUsuarioAasociarRol.FormattingEnabled = true;
            cmbUsuarioAasociarRol.Location = new Point(17, 60);
            cmbUsuarioAasociarRol.Margin = new Padding(3, 4, 3, 4);
            cmbUsuarioAasociarRol.Name = "cmbUsuarioAasociarRol";
            cmbUsuarioAasociarRol.Size = new Size(245, 28);
            cmbUsuarioAasociarRol.TabIndex = 19;
            // 
            // lblUsuarioAsociar
            // 
            lblUsuarioAsociar.AutoSize = true;
            lblUsuarioAsociar.Location = new Point(17, 33);
            lblUsuarioAsociar.Name = "lblUsuarioAsociar";
            lblUsuarioAsociar.Size = new Size(140, 20);
            lblUsuarioAsociar.TabIndex = 0;
            lblUsuarioAsociar.Text = "Seleccionar usuario:";
            // 
            // gbAsociarPermisoRol
            // 
            gbAsociarPermisoRol.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            gbAsociarPermisoRol.Controls.Add(btnDesasociarPermisoArol);
            gbAsociarPermisoRol.Controls.Add(btnAsociarPermisoArol);
            gbAsociarPermisoRol.Controls.Add(trViewPermisoRol);
            gbAsociarPermisoRol.Controls.Add(lblPermisosRol);
            gbAsociarPermisoRol.Controls.Add(btnAsociarPermisosMarcados);
            gbAsociarPermisoRol.Controls.Add(cbRolParaAsociarApermiso);
            gbAsociarPermisoRol.Controls.Add(lblRolDisponible);
            gbAsociarPermisoRol.Controls.Add(trvwPermisoAasociar);
            gbAsociarPermisoRol.Controls.Add(lblPermisosDisponibles);
            gbAsociarPermisoRol.Location = new Point(429, 16);
            gbAsociarPermisoRol.Margin = new Padding(3, 4, 3, 4);
            gbAsociarPermisoRol.Name = "gbAsociarPermisoRol";
            gbAsociarPermisoRol.Padding = new Padding(3, 4, 3, 4);
            gbAsociarPermisoRol.Size = new Size(560, 413);
            gbAsociarPermisoRol.TabIndex = 3;
            gbAsociarPermisoRol.TabStop = false;
            gbAsociarPermisoRol.Text = "Asociar Permiso a Rol";
           // gbAsociarPermisoRol.Enter += gbAsociarPermisoRol_Enter;
            // 
            // btnDesasociarPermisoArol
            // 
            btnDesasociarPermisoArol.Location = new Point(389, 80);
            btnDesasociarPermisoArol.Margin = new Padding(3, 4, 3, 4);
            btnDesasociarPermisoArol.Name = "btnDesasociarPermisoArol";
            btnDesasociarPermisoArol.Size = new Size(91, 33);
            btnDesasociarPermisoArol.TabIndex = 27;
            btnDesasociarPermisoArol.Text = "Desasociar";
            btnDesasociarPermisoArol.UseVisualStyleBackColor = true;
            // 
            // btnAsociarPermisoArol
            // 
            btnAsociarPermisoArol.Location = new Point(286, 80);
            btnAsociarPermisoArol.Margin = new Padding(3, 4, 3, 4);
            btnAsociarPermisoArol.Name = "btnAsociarPermisoArol";
            btnAsociarPermisoArol.Size = new Size(91, 33);
            btnAsociarPermisoArol.TabIndex = 26;
            btnAsociarPermisoArol.Text = "Asociar >";
            btnAsociarPermisoArol.UseVisualStyleBackColor = true;
            // 
            // trViewPermisoRol
            // 
            trViewPermisoRol.Location = new Point(286, 153);
            trViewPermisoRol.Margin = new Padding(3, 4, 3, 4);
            trViewPermisoRol.Name = "trViewPermisoRol";
            trViewPermisoRol.Size = new Size(251, 199);
            trViewPermisoRol.TabIndex = 28;
            // 
            // lblPermisosRol
            // 
            lblPermisosRol.AutoSize = true;
            lblPermisosRol.Location = new Point(286, 127);
            lblPermisosRol.Name = "lblPermisosRol";
            lblPermisosRol.Size = new Size(119, 20);
            lblPermisosRol.TabIndex = 0;
            lblPermisosRol.Text = "Permisos por rol:";
            // 
            // btnAsociarPermisosMarcados
            // 
            btnAsociarPermisosMarcados.Location = new Point(17, 360);
            btnAsociarPermisosMarcados.Margin = new Padding(3, 4, 3, 4);
            btnAsociarPermisosMarcados.Name = "btnAsociarPermisosMarcados";
            btnAsociarPermisosMarcados.Size = new Size(251, 40);
            btnAsociarPermisosMarcados.TabIndex = 25;
            btnAsociarPermisosMarcados.Text = "Asociar Múltiples Permisos Marcados";
            btnAsociarPermisosMarcados.UseVisualStyleBackColor = true;
            // 
            // cbRolParaAsociarApermiso
            // 
            cbRolParaAsociarApermiso.DropDownStyle = ComboBoxStyle.DropDownList;
            cbRolParaAsociarApermiso.FormattingEnabled = true;
            cbRolParaAsociarApermiso.Location = new Point(286, 33);
            cbRolParaAsociarApermiso.Margin = new Padding(3, 4, 3, 4);
            cbRolParaAsociarApermiso.Name = "cbRolParaAsociarApermiso";
            cbRolParaAsociarApermiso.Size = new Size(251, 28);
            cbRolParaAsociarApermiso.TabIndex = 23;
            // 
            // lblRolDisponible
            // 
            lblRolDisponible.AutoSize = true;
            lblRolDisponible.Location = new Point(286, 7);
            lblRolDisponible.Name = "lblRolDisponible";
            lblRolDisponible.Size = new Size(128, 20);
            lblRolDisponible.TabIndex = 0;
            lblRolDisponible.Text = "Roles disponibles:";
            // 
            // trvwPermisoAasociar
            // 
            trvwPermisoAasociar.CheckBoxes = true;
            trvwPermisoAasociar.Location = new Point(17, 60);
            trvwPermisoAasociar.Margin = new Padding(3, 4, 3, 4);
            trvwPermisoAasociar.Name = "trvwPermisoAasociar";
            trvwPermisoAasociar.Size = new Size(251, 292);
            trvwPermisoAasociar.TabIndex = 24;
            // 
            // lblPermisosDisponibles
            // 
            lblPermisosDisponibles.AutoSize = true;
            lblPermisosDisponibles.Location = new Point(17, 33);
            lblPermisosDisponibles.Name = "lblPermisosDisponibles";
            lblPermisosDisponibles.Size = new Size(150, 20);
            lblPermisosDisponibles.TabIndex = 0;
            lblPermisosDisponibles.Text = "Permisos disponibles:";
            // 
            // gbRolesYPermisosUsuario
            // 
            gbRolesYPermisosUsuario.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            gbRolesYPermisosUsuario.Controls.Add(trvRolesyPermisosPorUsuario);
            gbRolesYPermisosUsuario.Location = new Point(429, 440);
            gbRolesYPermisosUsuario.Margin = new Padding(3, 4, 3, 4);
            gbRolesYPermisosUsuario.Name = "gbRolesYPermisosUsuario";
            gbRolesYPermisosUsuario.Padding = new Padding(3, 4, 3, 4);
            gbRolesYPermisosUsuario.Size = new Size(560, 387);
            gbRolesYPermisosUsuario.TabIndex = 4;
            gbRolesYPermisosUsuario.TabStop = false;
            gbRolesYPermisosUsuario.Text = "Roles y permisos del usuario (Vista)";
            // 
            // trvRolesyPermisosPorUsuario
            // 
            trvRolesyPermisosPorUsuario.Dock = DockStyle.Fill;
            trvRolesyPermisosPorUsuario.Location = new Point(3, 24);
            trvRolesyPermisosPorUsuario.Margin = new Padding(3, 4, 3, 4);
            trvRolesyPermisosPorUsuario.Name = "trvRolesyPermisosPorUsuario";
            trvRolesyPermisosPorUsuario.Size = new Size(554, 359);
            trvRolesyPermisosPorUsuario.TabIndex = 29;
            // 
            // frmUsuarios
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1005, 841);
            Controls.Add(gbRolesYPermisosUsuario);
            Controls.Add(gbAsociarPermisoRol);
            Controls.Add(gbAsociarUsuarioRol);
            Controls.Add(gbCrearRol);
            Controls.Add(gbCrearUsuario);
            Margin = new Padding(3, 4, 3, 4);
            MinimumSize = new Size(1020, 878);
            Name = "frmUsuarios";
            Text = "Gestión de Seguridad (Usuarios, Roles y Permisos)";
            gbCrearUsuario.ResumeLayout(false);
            gbCrearUsuario.PerformLayout();
            gbCrearRol.ResumeLayout(false);
            gbCrearRol.PerformLayout();
            gbAsociarUsuarioRol.ResumeLayout(false);
            gbAsociarUsuarioRol.PerformLayout();
            gbAsociarPermisoRol.ResumeLayout(false);
            gbAsociarPermisoRol.PerformLayout();
            gbRolesYPermisosUsuario.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        // Declaraciones de todos los controles
        private System.Windows.Forms.GroupBox gbCrearUsuario;
        private System.Windows.Forms.Button btnLimpiarCamposUsuario;
        private System.Windows.Forms.Button btnBorrarUsuario;
        private System.Windows.Forms.Button btnEditarUsuario;
        private System.Windows.Forms.Button btnAltaUsuario;
        private System.Windows.Forms.CheckBox chkActivoUsuario;
        private System.Windows.Forms.TextBox txtContraseña;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.TextBox txtNombreUsuario;
        private System.Windows.Forms.Label lblUsuario;
        private System.Windows.Forms.TextBox txtCodigoUsuario;
        private System.Windows.Forms.Label lblCodigoUsuario;
        private System.Windows.Forms.ComboBox cbUsuarioEditarEliminar;
        private System.Windows.Forms.Label lblUsuarioEditar;
        private System.Windows.Forms.GroupBox gbCrearRol;
        private System.Windows.Forms.Button btnLimpiarCamposRol;
        private System.Windows.Forms.Button btnBorrarRol;
        private System.Windows.Forms.Button btnEditarRol;
        private System.Windows.Forms.Button btnAltaRol;
        private System.Windows.Forms.CheckBox chkActivoRol;
        private System.Windows.Forms.TextBox txtNombreRol;
        private System.Windows.Forms.Label lblNombreRol;
        private System.Windows.Forms.TextBox txtCodigoRol;
        private System.Windows.Forms.Label lblCodigoRol;
        private System.Windows.Forms.ComboBox cbRolEditarEliminar;
        private System.Windows.Forms.Label lblRolEditar;
        private System.Windows.Forms.GroupBox gbAsociarUsuarioRol;
        private System.Windows.Forms.Button btnDesasociarUsuarioArol;
        private System.Windows.Forms.Button btnAsociarUsuarioArol;
        private System.Windows.Forms.ComboBox cmbRolAasociarAusuario;
        private System.Windows.Forms.Label lblRolAsociar;
        private System.Windows.Forms.ComboBox cmbUsuarioAasociarRol;
        private System.Windows.Forms.Label lblUsuarioAsociar;
        private System.Windows.Forms.GroupBox gbAsociarPermisoRol;
        private System.Windows.Forms.Button btnDesasociarPermisoArol;
        private System.Windows.Forms.Button btnAsociarPermisoArol;
        private System.Windows.Forms.TreeView trViewPermisoRol;
        private System.Windows.Forms.Label lblPermisosRol;
        private System.Windows.Forms.Button btnAsociarPermisosMarcados;
        private System.Windows.Forms.ComboBox cbRolParaAsociarApermiso;
        private System.Windows.Forms.Label lblRolDisponible;
        private System.Windows.Forms.TreeView trvwPermisoAasociar;
        private System.Windows.Forms.Label lblPermisosDisponibles;
        private System.Windows.Forms.GroupBox gbRolesYPermisosUsuario;
        private System.Windows.Forms.TreeView trvRolesyPermisosPorUsuario;
     //   private EventHandler cbRolParaAsociarApermiso_SelectedIndexChanged;
       // private readonly EventHandler btnLimpiarCamposUsuario_Click;
    }
}