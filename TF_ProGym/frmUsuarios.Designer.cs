namespace CapaPresentacion
{
    partial class frmUsuarios
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            gbCrearUsuario = new GroupBox();
            chkEncriptarDesencriptar = new CheckBox();
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
            gbCrearUsuario.Controls.Add(chkEncriptarDesencriptar);
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
            gbCrearUsuario.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point);
            gbCrearUsuario.Location = new Point(14, 16);
            gbCrearUsuario.Margin = new Padding(3, 4, 3, 4);
            gbCrearUsuario.Name = "gbCrearUsuario";
            gbCrearUsuario.Padding = new Padding(3, 4, 3, 4);
            gbCrearUsuario.Size = new Size(400, 320);
            gbCrearUsuario.TabIndex = 0;
            gbCrearUsuario.TabStop = false;
            gbCrearUsuario.Text = "Gestión Usuario";
            // 
            // chkEncriptarDesencriptar
            // 
            chkEncriptarDesencriptar.AutoSize = true;
            chkEncriptarDesencriptar.Font = new Font("Segoe UI", 8F);
            chkEncriptarDesencriptar.Location = new Point(103, 280);
            chkEncriptarDesencriptar.Margin = new Padding(3, 4, 3, 4);
            chkEncriptarDesencriptar.Name = "chkEncriptarDesencriptar";
            chkEncriptarDesencriptar.Size = new Size(135, 17);
            chkEncriptarDesencriptar.TabIndex = 9;
            chkEncriptarDesencriptar.Text = "Mostrar/Ocultar Pass";
            chkEncriptarDesencriptar.UseVisualStyleBackColor = true;
            chkEncriptarDesencriptar.CheckedChanged += chkEncriptarDesencriptar_CheckedChanged;
            // 
            // btnLimpiarCamposUsuario
            // 
            btnLimpiarCamposUsuario.BackColor = Color.Gainsboro;
            btnLimpiarCamposUsuario.FlatAppearance.BorderSize = 0;
            btnLimpiarCamposUsuario.FlatStyle = FlatStyle.Flat;
            btnLimpiarCamposUsuario.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            btnLimpiarCamposUsuario.ForeColor = Color.Black;
            btnLimpiarCamposUsuario.Location = new Point(306, 224);
            btnLimpiarCamposUsuario.Margin = new Padding(3, 4, 3, 4);
            btnLimpiarCamposUsuario.Name = "btnLimpiarCamposUsuario";
            btnLimpiarCamposUsuario.Size = new Size(70, 33);
            btnLimpiarCamposUsuario.TabIndex = 8;
            btnLimpiarCamposUsuario.Text = "Limpiar";
            btnLimpiarCamposUsuario.UseVisualStyleBackColor = false;
            btnLimpiarCamposUsuario.Click += btnLimpiarCamposUsuario_Click;
            // 
            // btnBorrarUsuario
            // 
            btnBorrarUsuario.BackColor = Color.IndianRed;
            btnBorrarUsuario.FlatAppearance.BorderSize = 0;
            btnBorrarUsuario.FlatStyle = FlatStyle.Flat;
            btnBorrarUsuario.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            btnBorrarUsuario.ForeColor = Color.White;
            btnBorrarUsuario.Location = new Point(286, 159);
            btnBorrarUsuario.Margin = new Padding(3, 4, 3, 4);
            btnBorrarUsuario.Name = "btnBorrarUsuario";
            btnBorrarUsuario.Size = new Size(103, 40);
            btnBorrarUsuario.TabIndex = 7;
            btnBorrarUsuario.Text = "Baja";
            btnBorrarUsuario.UseVisualStyleBackColor = false;
            btnBorrarUsuario.Click += btnBorrarUsuario_Click;
            // 
            // btnEditarUsuario
            // 
            btnEditarUsuario.BackColor = Color.SteelBlue;
            btnEditarUsuario.FlatAppearance.BorderSize = 0;
            btnEditarUsuario.FlatStyle = FlatStyle.Flat;
            btnEditarUsuario.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            btnEditarUsuario.ForeColor = Color.White;
            btnEditarUsuario.Location = new Point(286, 107);
            btnEditarUsuario.Margin = new Padding(3, 4, 3, 4);
            btnEditarUsuario.Name = "btnEditarUsuario";
            btnEditarUsuario.Size = new Size(103, 40);
            btnEditarUsuario.TabIndex = 6;
            btnEditarUsuario.Text = "Editar";
            btnEditarUsuario.UseVisualStyleBackColor = false;
            btnEditarUsuario.Click += btnEditarUsuario_Click;
            // 
            // btnAltaUsuario
            // 
            btnAltaUsuario.BackColor = Color.SteelBlue;
            btnAltaUsuario.FlatAppearance.BorderSize = 0;
            btnAltaUsuario.FlatStyle = FlatStyle.Flat;
            btnAltaUsuario.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            btnAltaUsuario.ForeColor = Color.White;
            btnAltaUsuario.Location = new Point(286, 53);
            btnAltaUsuario.Margin = new Padding(3, 4, 3, 4);
            btnAltaUsuario.Name = "btnAltaUsuario";
            btnAltaUsuario.Size = new Size(103, 40);
            btnAltaUsuario.TabIndex = 5;
            btnAltaUsuario.Text = "Alta";
            btnAltaUsuario.UseVisualStyleBackColor = false;
            btnAltaUsuario.Click += btnAltaUsuario_Click;
            // 
            // chkActivoUsuario
            // 
            chkActivoUsuario.AutoSize = true;
            chkActivoUsuario.Checked = true;
            chkActivoUsuario.CheckState = CheckState.Checked;
            chkActivoUsuario.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            chkActivoUsuario.Location = new Point(17, 280);
            chkActivoUsuario.Margin = new Padding(3, 4, 3, 4);
            chkActivoUsuario.Name = "chkActivoUsuario";
            chkActivoUsuario.Size = new Size(62, 21);
            chkActivoUsuario.TabIndex = 4;
            chkActivoUsuario.Text = "Activo";
            chkActivoUsuario.UseVisualStyleBackColor = true;
            // 
            // txtContraseña
            // 
            txtContraseña.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            txtContraseña.Location = new Point(91, 233);
            txtContraseña.Margin = new Padding(3, 4, 3, 4);
            txtContraseña.Name = "txtContraseña";
            txtContraseña.PasswordChar = '*';
            txtContraseña.Size = new Size(171, 25);
            txtContraseña.TabIndex = 3;
            // 
            // lblPassword
            // 
            lblPassword.AutoSize = true;
            lblPassword.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point);
            lblPassword.Location = new Point(14, 237);
            lblPassword.Name = "lblPassword";
            lblPassword.Size = new Size(60, 15);
            lblPassword.TabIndex = 0;
            lblPassword.Text = "Password:";
            // 
            // txtNombreUsuario
            // 
            txtNombreUsuario.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            txtNombreUsuario.Location = new Point(91, 187);
            txtNombreUsuario.Margin = new Padding(3, 4, 3, 4);
            txtNombreUsuario.Name = "txtNombreUsuario";
            txtNombreUsuario.Size = new Size(171, 25);
            txtNombreUsuario.TabIndex = 2;
            // 
            // lblUsuario
            // 
            lblUsuario.AutoSize = true;
            lblUsuario.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point);
            lblUsuario.Location = new Point(14, 191);
            lblUsuario.Name = "lblUsuario";
            lblUsuario.Size = new System.Drawing.Size(50, 15);
            lblUsuario.TabIndex = 0;
            lblUsuario.Text = "Usuario:";
            // 
            // txtCodigoUsuario
            // 
            txtCodigoUsuario.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            txtCodigoUsuario.Location = new Point(91, 140);
            txtCodigoUsuario.Margin = new Padding(3, 4, 3, 4);
            txtCodigoUsuario.Name = "txtCodigoUsuario";
            txtCodigoUsuario.ReadOnly = true;
            txtCodigoUsuario.Size = new Size(79, 25);
            txtCodigoUsuario.TabIndex = 1;
            txtCodigoUsuario.TabStop = false;
            // 
            // lblCodigoUsuario
            // 
            lblCodigoUsuario.AutoSize = true;
            lblCodigoUsuario.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point);
            lblCodigoUsuario.Location = new Point(14, 144);
            lblCodigoUsuario.Name = "lblCodigoUsuario";
            lblCodigoUsuario.Size = new System.Drawing.Size(21, 15);
            lblCodigoUsuario.TabIndex = 0;
            lblCodigoUsuario.Text = "ID:";
            // 
            // cbUsuarioEditarEliminar
            // 
            cbUsuarioEditarEliminar.DropDownStyle = ComboBoxStyle.DropDownList;
            cbUsuarioEditarEliminar.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            cbUsuarioEditarEliminar.FormattingEnabled = true;
            cbUsuarioEditarEliminar.Location = new Point(17, 60);
            cbUsuarioEditarEliminar.Margin = new Padding(3, 4, 3, 4);
            cbUsuarioEditarEliminar.Name = "cbUsuarioEditarEliminar";
            cbUsuarioEditarEliminar.Size = new Size(245, 25);
            cbUsuarioEditarEliminar.TabIndex = 0;
            cbUsuarioEditarEliminar.SelectedIndexChanged += cbUsuarioEditarEliminar_SelectedIndexChanged;
            // 
            // lblUsuarioEditar
            // 
            lblUsuarioEditar.AutoSize = true;
            lblUsuarioEditar.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point);
            lblUsuarioEditar.Location = new Point(17, 33);
            lblUsuarioEditar.Name = "lblUsuarioEditar";
            lblUsuarioEditar.Size = new System.Drawing.Size(120, 15);
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
            gbCrearRol.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point);
            gbCrearRol.Location = new Point(14, 347);
            gbCrearRol.Margin = new Padding(3, 4, 3, 4);
            gbCrearRol.Name = "gbCrearRol";
            gbCrearRol.Padding = new Padding(3, 4, 3, 4);
            gbCrearRol.Size = new Size(400, 267);
            gbCrearRol.TabIndex = 1;
            gbCrearRol.TabStop = false;
            gbCrearRol.Text = "Gestión Rol";
            // 
            // btnLimpiarCamposRol
            // 
            btnLimpiarCamposRol.BackColor = Color.Gainsboro;
            btnLimpiarCamposRol.FlatAppearance.BorderSize = 0;
            btnLimpiarCamposRol.FlatStyle = FlatStyle.Flat;
            btnLimpiarCamposRol.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            btnLimpiarCamposRol.ForeColor = Color.Black;
            btnLimpiarCamposRol.Location = new Point(313, 213);
            btnLimpiarCamposRol.Margin = new Padding(3, 4, 3, 4);
            btnLimpiarCamposRol.Name = "btnLimpiarCamposRol";
            btnLimpiarCamposRol.Size = new Size(76, 33);
            btnLimpiarCamposRol.TabIndex = 17;
            btnLimpiarCamposRol.Text = "Limpiar";
            btnLimpiarCamposRol.UseVisualStyleBackColor = false;
            btnLimpiarCamposRol.Click += btnLimpiarCamposRol_Click;
            // 
            // btnBorrarRol
            // 
            btnBorrarRol.BackColor = Color.IndianRed;
            btnBorrarRol.FlatAppearance.BorderSize = 0;
            btnBorrarRol.FlatStyle = FlatStyle.Flat;
            btnBorrarRol.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            btnBorrarRol.ForeColor = Color.White;
            btnBorrarRol.Location = new Point(286, 159);
            btnBorrarRol.Margin = new Padding(3, 4, 3, 4);
            btnBorrarRol.Name = "btnBorrarRol";
            btnBorrarRol.Size = new Size(103, 40);
            btnBorrarRol.TabIndex = 16;
            btnBorrarRol.Text = "Baja";
            btnBorrarRol.UseVisualStyleBackColor = false;
            btnBorrarRol.Click += btnBorrarRol_Click;
            // 
            // btnEditarRol
            // 
            btnEditarRol.BackColor = Color.SteelBlue;
            btnEditarRol.FlatAppearance.BorderSize = 0;
            btnEditarRol.FlatStyle = FlatStyle.Flat;
            btnEditarRol.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            btnEditarRol.ForeColor = Color.White;
            btnEditarRol.Location = new Point(286, 107);
            btnEditarRol.Margin = new Padding(3, 4, 3, 4);
            btnEditarRol.Name = "btnEditarRol";
            btnEditarRol.Size = new Size(103, 40);
            btnEditarRol.TabIndex = 15;
            btnEditarRol.Text = "Editar";
            btnEditarRol.UseVisualStyleBackColor = false;
            btnEditarRol.Click += btnEditarRol_Click;
            // 
            // btnAltaRol
            // 
            btnAltaRol.BackColor = Color.SteelBlue;
            btnAltaRol.FlatAppearance.BorderSize = 0;
            btnAltaRol.FlatStyle = FlatStyle.Flat;
            btnAltaRol.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            btnAltaRol.ForeColor = Color.White;
            btnAltaRol.Location = new Point(286, 53);
            btnAltaRol.Margin = new Padding(3, 4, 3, 4);
            btnAltaRol.Name = "btnAltaRol";
            btnAltaRol.Size = new Size(103, 40);
            btnAltaRol.TabIndex = 14;
            btnAltaRol.Text = "Alta";
            btnAltaRol.UseVisualStyleBackColor = false;
            btnAltaRol.Click += btnAltaRol_Click;
            // 
            // chkActivoRol
            // 
            chkActivoRol.AutoSize = true;
            chkActivoRol.Checked = true;
            chkActivoRol.CheckState = CheckState.Checked;
            chkActivoRol.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            chkActivoRol.Location = new Point(17, 220);
            chkActivoRol.Margin = new Padding(3, 4, 3, 4);
            chkActivoRol.Name = "chkActivoRol";
            chkActivoRol.Size = new Size(62, 21);
            chkActivoRol.TabIndex = 13;
            chkActivoRol.Text = "Activo";
            chkActivoRol.UseVisualStyleBackColor = true;
            // 
            // txtNombreRol
            // 
            txtNombreRol.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            txtNombreRol.Location = new Point(91, 173);
            txtNombreRol.Margin = new Padding(3, 4, 3, 4);
            txtNombreRol.Name = "txtNombreRol";
            txtNombreRol.Size = new Size(171, 25);
            txtNombreRol.TabIndex = 12;
            // 
            // lblNombreRol
            // 
            lblNombreRol.AutoSize = true;
            lblNombreRol.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point);
            lblNombreRol.Location = new Point(14, 177);
            lblNombreRol.Name = "lblNombreRol";
            lblNombreRol.Size = new System.Drawing.Size(54, 15);
            lblNombreRol.TabIndex = 0;
            lblNombreRol.Text = "Nombre:";
            // 
            // txtCodigoRol
            // 
            txtCodigoRol.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            txtCodigoRol.Location = new Point(91, 127);
            txtCodigoRol.Margin = new Padding(3, 4, 3, 4);
            txtCodigoRol.Name = "txtCodigoRol";
            txtCodigoRol.ReadOnly = true;
            txtCodigoRol.Size = new Size(79, 25);
            txtCodigoRol.TabIndex = 11;
            txtCodigoRol.TabStop = false;
            // 
            // lblCodigoRol
            // 
            lblCodigoRol.AutoSize = true;
            lblCodigoRol.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point);
            lblCodigoRol.Location = new Point(14, 131);
            lblCodigoRol.Name = "lblCodigoRol";
            lblCodigoRol.Size = new System.Drawing.Size(21, 15);
            lblCodigoRol.TabIndex = 0;
            lblCodigoRol.Text = "ID:";
            // 
            // cbRolEditarEliminar
            // 
            cbRolEditarEliminar.DropDownStyle = ComboBoxStyle.DropDownList;
            cbRolEditarEliminar.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            cbRolEditarEliminar.FormattingEnabled = true;
            cbRolEditarEliminar.Location = new Point(17, 60);
            cbRolEditarEliminar.Margin = new Padding(3, 4, 3, 4);
            cbRolEditarEliminar.Name = "cbRolEditarEliminar";
            cbRolEditarEliminar.Size = new Size(245, 25);
            cbRolEditarEliminar.TabIndex = 10;
            cbRolEditarEliminar.SelectedIndexChanged += cbRolEditarEliminar_SelectedIndexChanged;
            // 
            // lblRolEditar
            // 
            lblRolEditar.AutoSize = true;
            lblRolEditar.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point);
            lblRolEditar.Location = new Point(17, 33);
            lblRolEditar.Name = "lblRolEditar";
            lblRolEditar.Size = new System.Drawing.Size(98, 15);
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
            gbAsociarUsuarioRol.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point);
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
            btnDesasociarUsuarioArol.BackColor = Color.IndianRed;
            btnDesasociarUsuarioArol.FlatAppearance.BorderSize = 0;
            btnDesasociarUsuarioArol.FlatStyle = FlatStyle.Flat;
            btnDesasociarUsuarioArol.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            btnDesasociarUsuarioArol.ForeColor = Color.White;
            btnDesasociarUsuarioArol.Location = new Point(286, 120);
            btnDesasociarUsuarioArol.Margin = new Padding(3, 4, 3, 4);
            btnDesasociarUsuarioArol.Name = "btnDesasociarUsuarioArol";
            btnDesasociarUsuarioArol.Size = new Size(103, 40);
            btnDesasociarUsuarioArol.TabIndex = 22;
            btnDesasociarUsuarioArol.Text = "Desasociar";
            btnDesasociarUsuarioArol.UseVisualStyleBackColor = false;
            btnDesasociarUsuarioArol.Click += btnDesasociarUsuarioArol_Click;
            // 
            // btnAsociarUsuarioArol
            // 
            btnAsociarUsuarioArol.BackColor = Color.SteelBlue;
            btnAsociarUsuarioArol.FlatAppearance.BorderSize = 0;
            btnAsociarUsuarioArol.FlatStyle = FlatStyle.Flat;
            btnAsociarUsuarioArol.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            btnAsociarUsuarioArol.ForeColor = Color.White;
            btnAsociarUsuarioArol.Location = new Point(286, 60);
            btnAsociarUsuarioArol.Margin = new Padding(3, 4, 3, 4);
            btnAsociarUsuarioArol.Name = "btnAsociarUsuarioArol";
            btnAsociarUsuarioArol.Size = new Size(103, 40);
            btnAsociarUsuarioArol.TabIndex = 21;
            btnAsociarUsuarioArol.Text = "Asociar";
            btnAsociarUsuarioArol.UseVisualStyleBackColor = false;
            btnAsociarUsuarioArol.Click += btnAsociarUsuarioArol_Click;
            // 
            // cmbRolAasociarAusuario
            // 
            cmbRolAasociarAusuario.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbRolAasociarAusuario.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            cmbRolAasociarAusuario.FormattingEnabled = true;
            cmbRolAasociarAusuario.Location = new Point(17, 133);
            cmbRolAasociarAusuario.Margin = new Padding(3, 4, 3, 4);
            cmbRolAasociarAusuario.Name = "cmbRolAasociarAusuario";
            cmbRolAasociarAusuario.Size = new Size(245, 25);
            cmbRolAasociarAusuario.TabIndex = 20;
            // 
            // lblRolAsociar
            // 
            lblRolAsociar.AutoSize = true;
            lblRolAsociar.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point);
            lblRolAsociar.Location = new Point(17, 107);
            lblRolAsociar.Name = "lblRolAsociar";
            lblRolAsociar.Size = new System.Drawing.Size(129, 15);
            lblRolAsociar.TabIndex = 0;
            lblRolAsociar.Text = "Rol a asociar al usuario:";
            // 
            // cmbUsuarioAasociarRol
            // 
            cmbUsuarioAasociarRol.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbUsuarioAasociarRol.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            cmbUsuarioAasociarRol.FormattingEnabled = true;
            cmbUsuarioAasociarRol.Location = new Point(17, 60);
            cmbUsuarioAasociarRol.Margin = new Padding(3, 4, 3, 4);
            cmbUsuarioAasociarRol.Name = "cmbUsuarioAasociarRol";
            cmbUsuarioAasociarRol.Size = new Size(245, 25);
            cmbUsuarioAasociarRol.TabIndex = 19;
            // 
            // lblUsuarioAsociar
            // 
            lblUsuarioAsociar.AutoSize = true;
            lblUsuarioAsociar.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point);
            lblUsuarioAsociar.Location = new Point(17, 33);
            lblUsuarioAsociar.Name = "lblUsuarioAsociar";
            lblUsuarioAsociar.Size = new System.Drawing.Size(113, 15);
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
            gbAsociarPermisoRol.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point);
            gbAsociarPermisoRol.Location = new Point(429, 16);
            gbAsociarPermisoRol.Margin = new Padding(3, 4, 3, 4);
            gbAsociarPermisoRol.Name = "gbAsociarPermisoRol";
            gbAsociarPermisoRol.Padding = new Padding(3, 4, 3, 4);
            gbAsociarPermisoRol.Size = new Size(560, 413);
            gbAsociarPermisoRol.TabIndex = 3;
            gbAsociarPermisoRol.TabStop = false;
            gbAsociarPermisoRol.Text = "Asociar Permiso a Rol";
            // 
            // btnDesasociarPermisoArol
            // 
            btnDesasociarPermisoArol.BackColor = Color.IndianRed;
            btnDesasociarPermisoArol.FlatAppearance.BorderSize = 0;
            btnDesasociarPermisoArol.FlatStyle = FlatStyle.Flat;
            btnDesasociarPermisoArol.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            btnDesasociarPermisoArol.ForeColor = Color.White;
            btnDesasociarPermisoArol.Location = new Point(389, 80);
            btnDesasociarPermisoArol.Margin = new Padding(3, 4, 3, 4);
            btnDesasociarPermisoArol.Name = "btnDesasociarPermisoArol";
            btnDesasociarPermisoArol.Size = new Size(91, 33);
            btnDesasociarPermisoArol.TabIndex = 27;
            btnDesasociarPermisoArol.Text = "Desasociar";
            btnDesasociarPermisoArol.UseVisualStyleBackColor = false;
            btnDesasociarPermisoArol.Click += btnDesasociarPermisoArol_Click;
            // 
            // btnAsociarPermisoArol
            // 
            btnAsociarPermisoArol.BackColor = Color.SteelBlue;
            btnAsociarPermisoArol.FlatAppearance.BorderSize = 0;
            btnAsociarPermisoArol.FlatStyle = FlatStyle.Flat;
            btnAsociarPermisoArol.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            btnAsociarPermisoArol.ForeColor = Color.White;
            btnAsociarPermisoArol.Location = new Point(286, 80);
            btnAsociarPermisoArol.Margin = new Padding(3, 4, 3, 4);
            btnAsociarPermisoArol.Name = "btnAsociarPermisoArol";
            btnAsociarPermisoArol.Size = new Size(91, 33);
            btnAsociarPermisoArol.TabIndex = 26;
            btnAsociarPermisoArol.Text = "Asociar >";
            btnAsociarPermisoArol.UseVisualStyleBackColor = false;
            btnAsociarPermisoArol.Click += btnAsociarPermisoArol_Click;
            // 
            // trViewPermisoRol
            // 
            trViewPermisoRol.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            trViewPermisoRol.Location = new Point(286, 153);
            trViewPermisoRol.Margin = new Padding(3, 4, 3, 4);
            trViewPermisoRol.Name = "trViewPermisoRol";
            trViewPermisoRol.Size = new Size(251, 199);
            trViewPermisoRol.TabIndex = 28;
            // 
            // lblPermisosRol
            // 
            lblPermisosRol.AutoSize = true;
            lblPermisosRol.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point);
            lblPermisosRol.Location = new Point(286, 127);
            lblPermisosRol.Name = "lblPermisosRol";
            lblPermisosRol.Size = new System.Drawing.Size(95, 15);
            lblPermisosRol.TabIndex = 0;
            lblPermisosRol.Text = "Permisos por rol:";
            // 
            // btnAsociarPermisosMarcados
            // 
            btnAsociarPermisosMarcados.BackColor = Color.SteelBlue;
            btnAsociarPermisosMarcados.FlatAppearance.BorderSize = 0;
            btnAsociarPermisosMarcados.FlatStyle = FlatStyle.Flat;
            btnAsociarPermisosMarcados.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            btnAsociarPermisosMarcados.ForeColor = Color.White;
            btnAsociarPermisosMarcados.Location = new Point(17, 360);
            btnAsociarPermisosMarcados.Margin = new Padding(3, 4, 3, 4);
            btnAsociarPermisosMarcados.Name = "btnAsociarPermisosMarcados";
            btnAsociarPermisosMarcados.Size = new Size(251, 40);
            btnAsociarPermisosMarcados.TabIndex = 25;
            btnAsociarPermisosMarcados.Text = "Guardar Permisos Marcados";
            btnAsociarPermisosMarcados.UseVisualStyleBackColor = false;
            btnAsociarPermisosMarcados.Click += btnAsociarPermisosMarcados_Click;
            // 
            // cbRolParaAsociarApermiso
            // 
            cbRolParaAsociarApermiso.DropDownStyle = ComboBoxStyle.DropDownList;
            cbRolParaAsociarApermiso.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            cbRolParaAsociarApermiso.FormattingEnabled = true;
            cbRolParaAsociarApermiso.Location = new Point(286, 33);
            cbRolParaAsociarApermiso.Margin = new Padding(3, 4, 3, 4);
            cbRolParaAsociarApermiso.Name = "cbRolParaAsociarApermiso";
            cbRolParaAsociarApermiso.Size = new Size(251, 25);
            cbRolParaAsociarApermiso.TabIndex = 23;
            cbRolParaAsociarApermiso.SelectedIndexChanged += cbRolParaAsociarApermiso_SelectedIndexChanged;
            // 
            // lblRolDisponible
            // 
            lblRolDisponible.AutoSize = true;
            lblRolDisponible.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point);
            lblRolDisponible.Location = new Point(286, 12);
            lblRolDisponible.Name = "lblRolDisponible";
            lblRolDisponible.Size = new System.Drawing.Size(102, 15);
            lblRolDisponible.TabIndex = 0;
            lblRolDisponible.Text = "Roles disponibles:";
            // 
            // trvwPermisoAasociar
            // 
            trvwPermisoAasociar.CheckBoxes = true;
            trvwPermisoAasociar.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            trvwPermisoAasociar.Location = new Point(17, 60);
            trvwPermisoAasociar.Margin = new Padding(3, 4, 3, 4);
            trvwPermisoAasociar.Name = "trvwPermisoAasociar";
            trvwPermisoAasociar.Size = new Size(251, 292);
            trvwPermisoAasociar.TabIndex = 24;
            // 
            // lblPermisosDisponibles
            // 
            lblPermisosDisponibles.AutoSize = true;
            lblPermisosDisponibles.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point);
            lblPermisosDisponibles.Location = new Point(17, 33);
            lblPermisosDisponibles.Name = "lblPermisosDisponibles";
            lblPermisosDisponibles.Size = new System.Drawing.Size(122, 15);
            lblPermisosDisponibles.TabIndex = 0;
            lblPermisosDisponibles.Text = "Permisos disponibles:";
            // 
            // gbRolesYPermisosUsuario
            // 
            gbRolesYPermisosUsuario.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            gbRolesYPermisosUsuario.Controls.Add(trvRolesyPermisosPorUsuario);
            gbRolesYPermisosUsuario.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point);
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
            trvRolesyPermisosPorUsuario.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            trvRolesyPermisosPorUsuario.Location = new Point(3, 20);
            trvRolesyPermisosPorUsuario.Margin = new Padding(3, 4, 3, 4);
            trvRolesyPermisosPorUsuario.Name = "trvRolesyPermisosPorUsuario";
            trvRolesyPermisosPorUsuario.Size = new Size(554, 363);
            trvRolesyPermisosPorUsuario.TabIndex = 29;
            // 
            // frmUsuarios
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
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
            Load += frmUsuarios_Load;
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
        private System.Windows.Forms.CheckBox chkEncriptarDesencriptar;
    }
}