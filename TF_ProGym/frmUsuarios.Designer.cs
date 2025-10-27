
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
            this.gbCrearUsuario = new System.Windows.Forms.GroupBox();
            this.btnLimpiarCamposUsuario = new System.Windows.Forms.Button();
            this.btnBorrarUsuario = new System.Windows.Forms.Button();
            this.btnEditarUsuario = new System.Windows.Forms.Button();
            this.btnAltaUsuario = new System.Windows.Forms.Button();
            this.chkActivoUsuario = new System.Windows.Forms.CheckBox();
            this.txtContraseña = new System.Windows.Forms.TextBox();
            this.lblPassword = new System.Windows.Forms.Label();
            this.txtNombreUsuario = new System.Windows.Forms.TextBox();
            this.lblUsuario = new System.Windows.Forms.Label();
            this.txtCodigoUsuario = new System.Windows.Forms.TextBox();
            this.lblCodigoUsuario = new System.Windows.Forms.Label();
            this.cbUsuarioEditarEliminar = new System.Windows.Forms.ComboBox();
            this.lblUsuarioEditar = new System.Windows.Forms.Label();
            this.gbCrearRol = new System.Windows.Forms.GroupBox();
            this.btnLimpiarCamposRol = new System.Windows.Forms.Button();
            this.btnBorrarRol = new System.Windows.Forms.Button();
            this.btnEditarRol = new System.Windows.Forms.Button();
            this.btnAltaRol = new System.Windows.Forms.Button();
            this.chkActivoRol = new System.Windows.Forms.CheckBox();
            this.txtNombreRol = new System.Windows.Forms.TextBox();
            this.lblNombreRol = new System.Windows.Forms.Label();
            this.txtCodigoRol = new System.Windows.Forms.TextBox();
            this.lblCodigoRol = new System.Windows.Forms.Label();
            this.cbRolEditarEliminar = new System.Windows.Forms.ComboBox();
            this.lblRolEditar = new System.Windows.Forms.Label();
            this.gbAsociarUsuarioRol = new System.Windows.Forms.GroupBox();
            this.btnDesasociarUsuarioArol = new System.Windows.Forms.Button();
            this.btnAsociarUsuarioArol = new System.Windows.Forms.Button();
            this.cmbRolAasociarAusuario = new System.Windows.Forms.ComboBox();
            this.lblRolAsociar = new System.Windows.Forms.Label();
            this.cmbUsuarioAasociarRol = new System.Windows.Forms.ComboBox();
            this.lblUsuarioAsociar = new System.Windows.Forms.Label();
            this.gbAsociarPermisoRol = new System.Windows.Forms.GroupBox();
            this.btnDesasociarPermisoArol = new System.Windows.Forms.Button();
            this.btnAsociarPermisoArol = new System.Windows.Forms.Button();
            this.trViewPermisoRol = new System.Windows.Forms.TreeView();
            this.lblPermisosRol = new System.Windows.Forms.Label();
            this.btnAsociarPermisosMarcados = new System.Windows.Forms.Button();
            this.cbRolParaAsociarApermiso = new System.Windows.Forms.ComboBox();
            this.lblRolDisponible = new System.Windows.Forms.Label();
            this.trvwPermisoAasociar = new System.Windows.Forms.TreeView();
            this.lblPermisosDisponibles = new System.Windows.Forms.Label();
            this.gbRolesYPermisosUsuario = new System.Windows.Forms.GroupBox();
            this.trvRolesyPermisosPorUsuario = new System.Windows.Forms.TreeView();
            this.chkEncriptarDesencriptar = new System.Windows.Forms.CheckBox(); // Control del modelo
            this.gbCrearUsuario.SuspendLayout();
            this.gbCrearRol.SuspendLayout();
            this.gbAsociarUsuarioRol.SuspendLayout();
            this.gbAsociarPermisoRol.SuspendLayout();
            this.gbRolesYPermisosUsuario.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbCrearUsuario
            // 
            this.gbCrearUsuario.Controls.Add(this.chkEncriptarDesencriptar); // Añadido
            this.gbCrearUsuario.Controls.Add(this.btnLimpiarCamposUsuario);
            this.gbCrearUsuario.Controls.Add(this.btnBorrarUsuario);
            this.gbCrearUsuario.Controls.Add(this.btnEditarUsuario);
            this.gbCrearUsuario.Controls.Add(this.btnAltaUsuario);
            this.gbCrearUsuario.Controls.Add(this.chkActivoUsuario);
            this.gbCrearUsuario.Controls.Add(this.txtContraseña);
            this.gbCrearUsuario.Controls.Add(this.lblPassword);
            this.gbCrearUsuario.Controls.Add(this.txtNombreUsuario);
            this.gbCrearUsuario.Controls.Add(this.lblUsuario);
            this.gbCrearUsuario.Controls.Add(this.txtCodigoUsuario);
            this.gbCrearUsuario.Controls.Add(this.lblCodigoUsuario);
            this.gbCrearUsuario.Controls.Add(this.cbUsuarioEditarEliminar);
            this.gbCrearUsuario.Controls.Add(this.lblUsuarioEditar);
            this.gbCrearUsuario.Location = new System.Drawing.Point(12, 12);
            this.gbCrearUsuario.Name = "gbCrearUsuario";
            this.gbCrearUsuario.Size = new System.Drawing.Size(350, 240);
            this.gbCrearUsuario.TabIndex = 0;
            this.gbCrearUsuario.TabStop = false;
            this.gbCrearUsuario.Text = "Gestión Usuario";
            // 
            // btnLimpiarCamposUsuario
            // 
            this.btnLimpiarCamposUsuario.Location = new System.Drawing.Point(300, 160);
            this.btnLimpiarCamposUsuario.Name = "btnLimpiarCamposUsuario";
            this.btnLimpiarCamposUsuario.Size = new System.Drawing.Size(40, 25);
            this.btnLimpiarCamposUsuario.TabIndex = 8;
            this.btnLimpiarCamposUsuario.Text = "Limp.";
            this.btnLimpiarCamposUsuario.UseVisualStyleBackColor = true;
            this.btnLimpiarCamposUsuario.Click += new System.EventHandler(this.btnLimpiarCamposUsuario_Click);
            // 
            // btnBorrarUsuario
            // 
            this.btnBorrarUsuario.Location = new System.Drawing.Point(250, 160);
            this.btnBorrarUsuario.Name = "btnBorrarUsuario";
            this.btnBorrarUsuario.Size = new System.Drawing.Size(40, 25);
            this.btnBorrarUsuario.TabIndex = 7;
            this.btnBorrarUsuario.Text = "Baja";
            this.btnBorrarUsuario.UseVisualStyleBackColor = true;
            this.btnBorrarUsuario.Click += new System.EventHandler(this.btnBorrarUsuario_Click);
            // 
            // btnEditarUsuario
            // 
            this.btnEditarUsuario.Location = new System.Drawing.Point(250, 80);
            this.btnEditarUsuario.Name = "btnEditarUsuario";
            this.btnEditarUsuario.Size = new System.Drawing.Size(90, 30);
            this.btnEditarUsuario.TabIndex = 6;
            this.btnEditarUsuario.Text = "Editar";
            this.btnEditarUsuario.UseVisualStyleBackColor = true;
            this.btnEditarUsuario.Click += new System.EventHandler(this.btnEditarUsuario_Click);
            // 
            // btnAltaUsuario
            // 
            this.btnAltaUsuario.Location = new System.Drawing.Point(250, 40);
            this.btnAltaUsuario.Name = "btnAltaUsuario";
            this.btnAltaUsuario.Size = new System.Drawing.Size(90, 30);
            this.btnAltaUsuario.TabIndex = 5;
            this.btnAltaUsuario.Text = "Alta";
            this.btnAltaUsuario.UseVisualStyleBackColor = true;
            this.btnAltaUsuario.Click += new System.EventHandler(this.btnAltaUsuario_Click);
            // 
            // chkActivoUsuario
            // 
            this.chkActivoUsuario.AutoSize = true;
            this.chkActivoUsuario.Checked = true;
            this.chkActivoUsuario.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkActivoUsuario.Location = new System.Drawing.Point(15, 210);
            this.chkActivoUsuario.Name = "chkActivoUsuario";
            this.chkActivoUsuario.Size = new System.Drawing.Size(60, 19);
            this.chkActivoUsuario.TabIndex = 4;
            this.chkActivoUsuario.Text = "Activo";
            this.chkActivoUsuario.UseVisualStyleBackColor = true;
            // 
            // txtContraseña
            // 
            this.txtContraseña.Location = new System.Drawing.Point(80, 175);
            this.txtContraseña.Name = "txtContraseña";
            this.txtContraseña.PasswordChar = '*';
            this.txtContraseña.Size = new System.Drawing.Size(150, 23);
            this.txtContraseña.TabIndex = 3;
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.Location = new System.Drawing.Point(12, 178);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(60, 15);
            this.lblPassword.TabIndex = 0;
            this.lblPassword.Text = "Password:";
            // 
            // txtNombreUsuario
            // 
            this.txtNombreUsuario.Location = new System.Drawing.Point(80, 140);
            this.txtNombreUsuario.Name = "txtNombreUsuario";
            this.txtNombreUsuario.Size = new System.Drawing.Size(150, 23);
            this.txtNombreUsuario.TabIndex = 2;
            // 
            // lblUsuario
            // 
            this.lblUsuario.AutoSize = true;
            this.lblUsuario.Location = new System.Drawing.Point(12, 143);
            this.lblUsuario.Name = "lblUsuario";
            this.lblUsuario.Size = new System.Drawing.Size(50, 15);
            this.lblUsuario.TabIndex = 0;
            this.lblUsuario.Text = "Usuario:";
            // 
            // txtCodigoUsuario
            // 
            this.txtCodigoUsuario.Location = new System.Drawing.Point(80, 105);
            this.txtCodigoUsuario.Name = "txtCodigoUsuario";
            this.txtCodigoUsuario.ReadOnly = true;
            this.txtCodigoUsuario.Size = new System.Drawing.Size(70, 23);
            this.txtCodigoUsuario.TabIndex = 1;
            this.txtCodigoUsuario.TabStop = false;
            // 
            // lblCodigoUsuario
            // 
            this.lblCodigoUsuario.AutoSize = true;
            this.lblCodigoUsuario.Location = new System.Drawing.Point(12, 108);
            this.lblCodigoUsuario.Name = "lblCodigoUsuario";
            this.lblCodigoUsuario.Size = new System.Drawing.Size(21, 15);
            this.lblCodigoUsuario.TabIndex = 0;
            this.lblCodigoUsuario.Text = "ID:";
            // 
            // cbUsuarioEditarEliminar
            // 
            this.cbUsuarioEditarEliminar.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbUsuarioEditarEliminar.FormattingEnabled = true;
            this.cbUsuarioEditarEliminar.Location = new System.Drawing.Point(15, 45);
            this.cbUsuarioEditarEliminar.Name = "cbUsuarioEditarEliminar";
            this.cbUsuarioEditarEliminar.Size = new System.Drawing.Size(215, 23);
            this.cbUsuarioEditarEliminar.TabIndex = 0;
            this.cbUsuarioEditarEliminar.SelectedIndexChanged += new System.EventHandler(this.cbUsuarioEditarEliminar_SelectedIndexChanged);
            // 
            // lblUsuarioEditar
            // 
            this.lblUsuarioEditar.AutoSize = true;
            this.lblUsuarioEditar.Location = new System.Drawing.Point(15, 25);
            this.lblUsuarioEditar.Name = "lblUsuarioEditar";
            this.lblUsuarioEditar.Size = new System.Drawing.Size(124, 15);
            this.lblUsuarioEditar.TabIndex = 0;
            this.lblUsuarioEditar.Text = "Usuario a editar/baja:";
            // 
            // chkEncriptarDesencriptar
            // 
            this.chkEncriptarDesencriptar.AutoSize = true;
            this.chkEncriptarDesencriptar.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.chkEncriptarDesencriptar.Location = new System.Drawing.Point(90, 210);
            this.chkEncriptarDesencriptar.Name = "chkEncriptarDesencriptar";
            this.chkEncriptarDesencriptar.Size = new System.Drawing.Size(140, 17); // Ajustado
            this.chkEncriptarDesencriptar.TabIndex = 9;
            this.chkEncriptarDesencriptar.Text = "Mostrar/Ocultar Pass"; // Texto cambiado
            this.chkEncriptarDesencriptar.UseVisualStyleBackColor = true;
            this.chkEncriptarDesencriptar.CheckedChanged += new System.EventHandler(this.chkEncriptarDesencriptar_CheckedChanged);
            // 
            // gbCrearRol
            // 
            this.gbCrearRol.Controls.Add(this.btnLimpiarCamposRol);
            this.gbCrearRol.Controls.Add(this.btnBorrarRol);
            this.gbCrearRol.Controls.Add(this.btnEditarRol);
            this.gbCrearRol.Controls.Add(this.btnAltaRol);
            this.gbCrearRol.Controls.Add(this.chkActivoRol);
            this.gbCrearRol.Controls.Add(this.txtNombreRol);
            this.gbCrearRol.Controls.Add(this.lblNombreRol);
            this.gbCrearRol.Controls.Add(this.txtCodigoRol);
            this.gbCrearRol.Controls.Add(this.lblCodigoRol);
            this.gbCrearRol.Controls.Add(this.cbRolEditarEliminar);
            this.gbCrearRol.Controls.Add(this.lblRolEditar);
            this.gbCrearRol.Location = new System.Drawing.Point(12, 260);
            this.gbCrearRol.Name = "gbCrearRol";
            this.gbCrearRol.Size = new System.Drawing.Size(350, 200);
            this.gbCrearRol.TabIndex = 1;
            this.gbCrearRol.TabStop = false;
            this.gbCrearRol.Text = "Gestión Rol";
            // 
            // btnLimpiarCamposRol
            // 
            this.btnLimpiarCamposRol.Location = new System.Drawing.Point(300, 160);
            this.btnLimpiarCamposRol.Name = "btnLimpiarCamposRol";
            this.btnLimpiarCamposRol.Size = new System.Drawing.Size(40, 25);
            this.btnLimpiarCamposRol.TabIndex = 17;
            this.btnLimpiarCamposRol.Text = "Limp.";
            this.btnLimpiarCamposRol.UseVisualStyleBackColor = true;
            this.btnLimpiarCamposRol.Click += new System.EventHandler(this.btnLimpiarCamposRol_Click);
            // 
            // btnBorrarRol
            // 
            this.btnBorrarRol.Location = new System.Drawing.Point(250, 160);
            this.btnBorrarRol.Name = "btnBorrarRol";
            this.btnBorrarRol.Size = new System.Drawing.Size(40, 25);
            this.btnBorrarRol.TabIndex = 16;
            this.btnBorrarRol.Text = "Baja";
            this.btnBorrarRol.UseVisualStyleBackColor = true;
            this.btnBorrarRol.Click += new System.EventHandler(this.btnBorrarRol_Click);
            // 
            // btnEditarRol
            // 
            this.btnEditarRol.Location = new System.Drawing.Point(250, 80);
            this.btnEditarRol.Name = "btnEditarRol";
            this.btnEditarRol.Size = new System.Drawing.Size(90, 30);
            this.btnEditarRol.TabIndex = 15;
            this.btnEditarRol.Text = "Editar";
            this.btnEditarRol.UseVisualStyleBackColor = true;
            this.btnEditarRol.Click += new System.EventHandler(this.btnEditarRol_Click);
            // 
            // btnAltaRol
            // 
            this.btnAltaRol.Location = new System.Drawing.Point(250, 40);
            this.btnAltaRol.Name = "btnAltaRol";
            this.btnAltaRol.Size = new System.Drawing.Size(90, 30);
            this.btnAltaRol.TabIndex = 14;
            this.btnAltaRol.Text = "Alta";
            this.btnAltaRol.UseVisualStyleBackColor = true;
            this.btnAltaRol.Click += new System.EventHandler(this.btnAltaRol_Click);
            // 
            // chkActivoRol
            // 
            this.chkActivoRol.AutoSize = true;
            this.chkActivoRol.Checked = true;
            this.chkActivoRol.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkActivoRol.Location = new System.Drawing.Point(15, 165);
            this.chkActivoRol.Name = "chkActivoRol";
            this.chkActivoRol.Size = new System.Drawing.Size(60, 19);
            this.chkActivoRol.TabIndex = 13;
            this.chkActivoRol.Text = "Activo";
            this.chkActivoRol.UseVisualStyleBackColor = true;
            // 
            // txtNombreRol
            // 
            this.txtNombreRol.Location = new System.Drawing.Point(80, 130);
            this.txtNombreRol.Name = "txtNombreRol";
            this.txtNombreRol.Size = new System.Drawing.Size(150, 23);
            this.txtNombreRol.TabIndex = 12;
            // 
            // lblNombreRol
            // 
            this.lblNombreRol.AutoSize = true;
            this.lblNombreRol.Location = new System.Drawing.Point(12, 133);
            this.lblNombreRol.Name = "lblNombreRol";
            this.lblNombreRol.Size = new System.Drawing.Size(54, 15);
            this.lblNombreRol.TabIndex = 0;
            this.lblNombreRol.Text = "Nombre:";
            // 
            // txtCodigoRol
            // 
            this.txtCodigoRol.Location = new System.Drawing.Point(80, 95);
            this.txtCodigoRol.Name = "txtCodigoRol";
            this.txtCodigoRol.ReadOnly = true;
            this.txtCodigoRol.Size = new System.Drawing.Size(70, 23);
            this.txtCodigoRol.TabIndex = 11;
            this.txtCodigoRol.TabStop = false;
            // 
            // lblCodigoRol
            // 
            this.lblCodigoRol.AutoSize = true;
            this.lblCodigoRol.Location = new System.Drawing.Point(12, 98);
            this.lblCodigoRol.Name = "lblCodigoRol";
            this.lblCodigoRol.Size = new System.Drawing.Size(21, 15);
            this.lblCodigoRol.TabIndex = 0;
            this.lblCodigoRol.Text = "ID:";
            // 
            // cbRolEditarEliminar
            // 
            this.cbRolEditarEliminar.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbRolEditarEliminar.FormattingEnabled = true;
            this.cbRolEditarEliminar.Location = new System.Drawing.Point(15, 45);
            this.cbRolEditarEliminar.Name = "cbRolEditarEliminar";
            this.cbRolEditarEliminar.Size = new System.Drawing.Size(215, 23);
            this.cbRolEditarEliminar.TabIndex = 10;
            this.cbRolEditarEliminar.SelectedIndexChanged += new System.EventHandler(this.cbRolEditarEliminar_SelectedIndexChanged);
            // 
            // lblRolEditar
            // 
            this.lblRolEditar.AutoSize = true;
            this.lblRolEditar.Location = new System.Drawing.Point(15, 25);
            this.lblRolEditar.Name = "lblRolEditar";
            this.lblRolEditar.Size = new System.Drawing.Size(102, 15);
            this.lblRolEditar.TabIndex = 0;
            this.lblRolEditar.Text = "Rol a editar/baja:";
            // 
            // gbAsociarUsuarioRol
            // 
            this.gbAsociarUsuarioRol.Controls.Add(this.btnDesasociarUsuarioArol);
            this.gbAsociarUsuarioRol.Controls.Add(this.btnAsociarUsuarioArol);
            this.gbAsociarUsuarioRol.Controls.Add(this.cmbRolAasociarAusuario);
            this.gbAsociarUsuarioRol.Controls.Add(this.lblRolAsociar);
            this.gbAsociarUsuarioRol.Controls.Add(this.cmbUsuarioAasociarRol);
            this.gbAsociarUsuarioRol.Controls.Add(this.lblUsuarioAsociar);
            this.gbAsociarUsuarioRol.Location = new System.Drawing.Point(12, 470);
            this.gbAsociarUsuarioRol.Name = "gbAsociarUsuarioRol";
            this.gbAsociarUsuarioRol.Size = new System.Drawing.Size(350, 150);
            this.gbAsociarUsuarioRol.TabIndex = 2;
            this.gbAsociarUsuarioRol.TabStop = false;
            this.gbAsociarUsuarioRol.Text = "Asociar Usuario a Rol";
            // 
            // btnDesasociarUsuarioArol
            // 
            this.btnDesasociarUsuarioArol.Location = new System.Drawing.Point(250, 90);
            this.btnDesasociarUsuarioArol.Name = "btnDesasociarUsuarioArol";
            this.btnDesasociarUsuarioArol.Size = new System.Drawing.Size(90, 30);
            this.btnDesasociarUsuarioArol.TabIndex = 22;
            this.btnDesasociarUsuarioArol.Text = "Desasociar";
            this.btnDesasociarUsuarioArol.UseVisualStyleBackColor = true;
            this.btnDesasociarUsuarioArol.Click += new System.EventHandler(this.btnDesasociarUsuarioArol_Click);
            // 
            // btnAsociarUsuarioArol
            // 
            this.btnAsociarUsuarioArol.Location = new System.Drawing.Point(250, 45);
            this.btnAsociarUsuarioArol.Name = "btnAsociarUsuarioArol";
            this.btnAsociarUsuarioArol.Size = new System.Drawing.Size(90, 30);
            this.btnAsociarUsuarioArol.TabIndex = 21;
            this.btnAsociarUsuarioArol.Text = "Asociar";
            this.btnAsociarUsuarioArol.UseVisualStyleBackColor = true;
            this.btnAsociarUsuarioArol.Click += new System.EventHandler(this.btnAsociarUsuarioArol_Click);
            // 
            // cmbRolAasociarAusuario
            // 
            this.cmbRolAasociarAusuario.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbRolAasociarAusuario.FormattingEnabled = true;
            this.cmbRolAasociarAusuario.Location = new System.Drawing.Point(15, 100);
            this.cmbRolAasociarAusuario.Name = "cmbRolAasociarAusuario";
            this.cmbRolAasociarAusuario.Size = new System.Drawing.Size(215, 23);
            this.cmbRolAasociarAusuario.TabIndex = 20;
            // 
            // lblRolAsociar
            // 
            this.lblRolAsociar.AutoSize = true;
            this.lblRolAsociar.Location = new System.Drawing.Point(15, 80);
            this.lblRolAsociar.Name = "lblRolAsociar";
            this.lblRolAsociar.Size = new System.Drawing.Size(121, 15);
            this.lblRolAsociar.TabIndex = 0;
            this.lblRolAsociar.Text = "Rol a asociar al usuario:";
            // 
            // cmbUsuarioAasociarRol
            // 
            this.cmbUsuarioAasociarRol.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbUsuarioAasociarRol.FormattingEnabled = true;
            this.cmbUsuarioAasociarRol.Location = new System.Drawing.Point(15, 45);
            this.cmbUsuarioAasociarRol.Name = "cmbUsuarioAasociarRol";
            this.cmbUsuarioAasociarRol.Size = new System.Drawing.Size(215, 23);
            this.cmbUsuarioAasociarRol.TabIndex = 19;
            // 
            // lblUsuarioAsociar
            // 
            this.lblUsuarioAsociar.AutoSize = true;
            this.lblUsuarioAsociar.Location = new System.Drawing.Point(15, 25);
            this.lblUsuarioAsociar.Name = "lblUsuarioAsociar";
            this.lblUsuarioAsociar.Size = new System.Drawing.Size(117, 15);
            this.lblUsuarioAsociar.TabIndex = 0;
            this.lblUsuarioAsociar.Text = "Seleccionar usuario:";
            // 
            // gbAsociarPermisoRol
            // 
            this.gbAsociarPermisoRol.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbAsociarPermisoRol.Controls.Add(this.btnDesasociarPermisoArol);
            this.gbAsociarPermisoRol.Controls.Add(this.btnAsociarPermisoArol);
            this.gbAsociarPermisoRol.Controls.Add(this.trViewPermisoRol);
            this.gbAsociarPermisoRol.Controls.Add(this.lblPermisosRol);
            this.gbAsociarPermisoRol.Controls.Add(this.btnAsociarPermisosMarcados);
            this.gbAsociarPermisoRol.Controls.Add(this.cbRolParaAsociarApermiso);
            this.gbAsociarPermisoRol.Controls.Add(this.lblRolDisponible);
            this.gbAsociarPermisoRol.Controls.Add(this.trvwPermisoAasociar);
            this.gbAsociarPermisoRol.Controls.Add(this.lblPermisosDisponibles);
            this.gbAsociarPermisoRol.Location = new System.Drawing.Point(375, 12);
            this.gbAsociarPermisoRol.Name = "gbAsociarPermisoRol";
            this.gbAsociarPermisoRol.Size = new System.Drawing.Size(490, 310);
            this.gbAsociarPermisoRol.TabIndex = 3;
            this.gbAsociarPermisoRol.TabStop = false;
            this.gbAsociarPermisoRol.Text = "Asociar Permiso a Rol";
            // 
            // btnDesasociarPermisoArol
            // 
            this.btnDesasociarPermisoArol.Location = new System.Drawing.Point(340, 60);
            this.btnDesasociarPermisoArol.Name = "btnDesasociarPermisoArol";
            this.btnDesasociarPermisoArol.Size = new System.Drawing.Size(80, 25);
            this.btnDesasociarPermisoArol.TabIndex = 27;
            this.btnDesasociarPermisoArol.Text = "Desasociar";
            this.btnDesasociarPermisoArol.UseVisualStyleBackColor = true;
            this.btnDesasociarPermisoArol.Click += new System.EventHandler(this.btnDesasociarPermisoArol_Click);
            // 
            // btnAsociarPermisoArol
            // 
            this.btnAsociarPermisoArol.Location = new System.Drawing.Point(250, 60);
            this.btnAsociarPermisoArol.Name = "btnAsociarPermisoArol";
            this.btnAsociarPermisoArol.Size = new System.Drawing.Size(80, 25);
            this.btnAsociarPermisoArol.TabIndex = 26;
            this.btnAsociarPermisoArol.Text = "Asociar >";
            this.btnAsociarPermisoArol.UseVisualStyleBackColor = true;
            this.btnAsociarPermisoArol.Click += new System.EventHandler(this.btnAsociarPermisoArol_Click);
            // 
            // trViewPermisoRol
            // 
            this.trViewPermisoRol.Location = new System.Drawing.Point(250, 115);
            this.trViewPermisoRol.Name = "trViewPermisoRol";
            this.trViewPermisoRol.Size = new System.Drawing.Size(220, 150);
            this.trViewPermisoRol.TabIndex = 28;
            // 
            // lblPermisosRol
            // 
            this.lblPermisosRol.AutoSize = true;
            this.lblPermisosRol.Location = new System.Drawing.Point(250, 95);
            this.lblPermisosRol.Name = "lblPermisosRol";
            this.lblPermisosRol.Size = new System.Drawing.Size(88, 15);
            this.lblPermisosRol.TabIndex = 0;
            this.lblPermisosRol.Text = "Permisos por rol:";
            // 
            // btnAsociarPermisosMarcados
            // 
            this.btnAsociarPermisosMarcados.Location = new System.Drawing.Point(15, 270);
            this.btnAsociarPermisosMarcados.Name = "btnAsociarPermisosMarcados";
            this.btnAsociarPermisosMarcados.Size = new System.Drawing.Size(220, 30);
            this.btnAsociarPermisosMarcados.TabIndex = 25;
            this.btnAsociarPermisosMarcados.Text = "Asociar Múltiples Permisos Marcados";
            this.btnAsociarPermisosMarcados.UseVisualStyleBackColor = true;
            this.btnAsociarPermisosMarcados.Click += new System.EventHandler(this.btnAsociarPermisosMarcados_Click);
            // 
            // cbRolParaAsociarApermiso
            // 
            this.cbRolParaAsociarApermiso.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbRolParaAsociarApermiso.FormattingEnabled = true;
            this.cbRolParaAsociarApermiso.Location = new System.Drawing.Point(250, 25);
            this.cbRolParaAsociarApermiso.Name = "cbRolParaAsociarApermiso";
            this.cbRolParaAsociarApermiso.Size = new System.Drawing.Size(220, 23);
            this.cbRolParaAsociarApermiso.TabIndex = 23;
            this.cbRolParaAsociarApermiso.SelectedIndexChanged += new System.EventHandler(this.cbRolParaAsociarApermiso_SelectedIndexChanged);
            // 
            // lblRolDisponible
            // 
            this.lblRolDisponible.AutoSize = true;
            this.lblRolDisponible.Location = new System.Drawing.Point(250, 5);
            this.lblRolDisponible.Name = "lblRolDisponible";
            this.lblRolDisponible.Size = new System.Drawing.Size(99, 15);
            this.lblRolDisponible.TabIndex = 0;
            this.lblRolDisponible.Text = "Roles disponibles:";
            // 
            // trvwPermisoAasociar
            // 
            this.trvwPermisoAasociar.CheckBoxes = true;
            this.trvwPermisoAasociar.Location = new System.Drawing.Point(15, 45);
            this.trvwPermisoAasociar.Name = "trvwPermisoAasociar";
            this.trvwPermisoAasociar.Size = new System.Drawing.Size(220, 220);
            this.trvwPermisoAasociar.TabIndex = 24;
            // 
            // lblPermisosDisponibles
            // 
            this.lblPermisosDisponibles.AutoSize = true;
            this.lblPermisosDisponibles.Location = new System.Drawing.Point(15, 25);
            this.lblPermisosDisponibles.Name = "lblPermisosDisponibles";
            this.lblPermisosDisponibles.Size = new System.Drawing.Size(122, 15);
            this.lblPermisosDisponibles.TabIndex = 0;
            this.lblPermisosDisponibles.Text = "Permisos disponibles:";
            // 
            // gbRolesYPermisosUsuario
            // 
            this.gbRolesYPermisosUsuario.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbRolesYPermisosUsuario.Controls.Add(this.trvRolesyPermisosPorUsuario);
            this.gbRolesYPermisosUsuario.Location = new System.Drawing.Point(375, 330);
            this.gbRolesYPermisosUsuario.Name = "gbRolesYPermisosUsuario";
            this.gbRolesYPermisosUsuario.Size = new System.Drawing.Size(490, 290);
            this.gbRolesYPermisosUsuario.TabIndex = 4;
            this.gbRolesYPermisosUsuario.TabStop = false;
            this.gbRolesYPermisosUsuario.Text = "Roles y permisos del usuario (Vista)";
            // 
            // trvRolesyPermisosPorUsuario
            // 
            this.trvRolesyPermisosPorUsuario.Dock = System.Windows.Forms.DockStyle.Fill;
            this.trvRolesyPermisosPorUsuario.Location = new System.Drawing.Point(3, 19);
            this.trvRolesyPermisosPorUsuario.Name = "trvRolesyPermisosPorUsuario";
            this.trvRolesyPermisosPorUsuario.Size = new System.Drawing.Size(484, 268);
            this.trvRolesyPermisosPorUsuario.TabIndex = 29;
            // 
            // frmUsuarios
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F); // .NET Core/5+ default
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(879, 631);
            this.Controls.Add(this.gbRolesYPermisosUsuario);
            this.Controls.Add(this.gbAsociarPermisoRol);
            this.Controls.Add(this.gbAsociarUsuarioRol);
            this.Controls.Add(this.gbCrearRol);
            this.Controls.Add(this.gbCrearUsuario);
            this.MinimumSize = new System.Drawing.Size(895, 670);
            this.Name = "frmUsuarios";
            this.Text = "Gestión de Seguridad (Usuarios, Roles y Permisos)";
            this.Load += new System.EventHandler(this.frmUsuarios_Load);
            this.gbCrearUsuario.ResumeLayout(false);
            this.gbCrearUsuario.PerformLayout();
            this.gbCrearRol.ResumeLayout(false);
            this.gbCrearRol.PerformLayout();
            this.gbAsociarUsuarioRol.ResumeLayout(false);
            this.gbAsociarUsuarioRol.PerformLayout();
            this.gbAsociarPermisoRol.ResumeLayout(false);
            this.gbAsociarPermisoRol.PerformLayout();
            this.gbRolesYPermisosUsuario.ResumeLayout(false);
            this.ResumeLayout(false);

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
        private System.Windows.Forms.CheckBox chkEncriptarDesencriptar; // Control del modelo
    }
}