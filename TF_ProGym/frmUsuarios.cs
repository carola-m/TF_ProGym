using BE;
using BLL;
using System.Data;


namespace CapaPresentacion
{
    public partial class frmUsuarios : Form
    {
        private readonly BLLSeguridad bllSeguridad = new BLLSeguridad();
        private List<BEPermisoComponent> _definicionesPermisosCache;

        public frmUsuarios()
        {
            InitializeComponent();
        }

        // Cargar datos iniciales al abrir el formulario
        private void frmUsuarios_Load(object sender, EventArgs e)
        {
            CargarPermisosEnTreeView();
            CargarComboBoxUsuarios();
            CargarComboBoxRoles();
            MostrarRolesYPermisosDeTodosLosUsuarios();

            LimpiarCamposUsuario();
            LimpiarCamposRol();
        }

        #region Lógica Carga de Controles

        // Carga el TreeView  con las definiciones de permisos
        private void CargarPermisosEnTreeView()
        {
            try
            {
                trvwPermisoAasociar.AfterCheck -= trvwPermisoAasociar_AfterCheck;

                _definicionesPermisosCache = bllSeguridad.ObtenerDefinicionesPermisos();
                trvwPermisoAasociar.Nodes.Clear();

                // carga en la raíz del TreeView
                foreach (var componente in _definicionesPermisosCache.OrderBy(p => p.Nombre))
                {
                    AgregarNodoAlTreeView(trvwPermisoAasociar.Nodes, componente);
                }
                trvwPermisoAasociar.ExpandAll(); 
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar permisos: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                trvwPermisoAasociar.AfterCheck += trvwPermisoAasociar_AfterCheck;
            }
        }

        // Método para poblar el TreeView
        private void AgregarNodoAlTreeView(TreeNodeCollection nodosPadre, BEPermisoComponent componente)
        {
            var nodo = new TreeNode(componente.Nombre);
            nodo.Tag = componente; // Guardamos el objeto BE (Hoja o Grupo)

            if (componente is BECategoriaPermiso)
            {
                // Si es un grupo, iteramos sus hijos
                foreach (var hijo in componente.ObtenerHijos().OrderBy(p => p.Nombre))
                {
                    AgregarNodoAlTreeView(nodo.Nodes, hijo); // Recursividad
                }
            }

            nodosPadre.Add(nodo);
        }


        // Carga los roles
        private void CargarComboBoxRoles()
        {
            try
            {
                var rolesTodos = bllSeguridad.ListarTodosRoles();
                var rolesActivos = rolesTodos.Where(r => r.Activo).ToList();

                cbRolEditarEliminar.DataSource = null;
                cbRolEditarEliminar.DataSource = rolesTodos;
                cbRolEditarEliminar.DisplayMember = "Nombre";
                cbRolEditarEliminar.ValueMember = "Id";
                cbRolEditarEliminar.SelectedIndex = -1;

                cbRolParaAsociarApermiso.DataSource = null;
                cbRolParaAsociarApermiso.DataSource = rolesActivos.ToList();
                cbRolParaAsociarApermiso.DisplayMember = "Nombre";
                cbRolParaAsociarApermiso.ValueMember = "Id";
                cbRolParaAsociarApermiso.SelectedIndex = -1;

                cmbRolAasociarAusuario.DataSource = null;
                cmbRolAasociarAusuario.DataSource = rolesActivos.ToList();
                cmbRolAasociarAusuario.DisplayMember = "Nombre";
                cmbRolAasociarAusuario.ValueMember = "Id";
                cmbRolAasociarAusuario.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar roles: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Carga los usuarios
        private void CargarComboBoxUsuarios()
        {
            try
            {
                var usuariosTodos = bllSeguridad.ListarUsuarios();
                var usuariosActivos = usuariosTodos.Where(u => u.Activo).ToList();

                cbUsuarioEditarEliminar.DataSource = null;
                cbUsuarioEditarEliminar.DataSource = usuariosTodos;
                cbUsuarioEditarEliminar.DisplayMember = "NombreUsuario";
                cbUsuarioEditarEliminar.ValueMember = "Id";
                cbUsuarioEditarEliminar.SelectedIndex = -1;

                cmbUsuarioAasociarRol.DataSource = null;
                cmbUsuarioAasociarRol.DataSource = usuariosActivos;
                cmbUsuarioAasociarRol.DisplayMember = "NombreUsuario";
                cmbUsuarioAasociarRol.ValueMember = "Id";
                cmbUsuarioAasociarRol.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar usuarios: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Carga el TreeView con la vista general
        private void MostrarRolesYPermisosDeTodosLosUsuarios()
        {
            trvRolesyPermisosPorUsuario.Nodes.Clear();
            try
            {
                var usuarios = bllSeguridad.ListarUsuarios();

                foreach (var usuario in usuarios)
                {
                    string nombreDisplayUsuario = usuario.Activo ? usuario.NombreUsuario : $"{usuario.NombreUsuario} (Inactivo)";
                    var nodoUsuario = new TreeNode(nombreDisplayUsuario);
                    nodoUsuario.Tag = usuario;

                    var roles = bllSeguridad.ObtenerRolesDeUsuario(usuario.Id);

                    foreach (var rol in roles)
                    {
                        var nodoRol = new TreeNode(rol.Nombre);
                        nodoRol.Tag = rol;

                        foreach (var permiso in rol.Permisos.OrderBy(p => p.Nombre))
                        {
                            var nodoPermiso = new TreeNode(permiso.Nombre);
                            nodoPermiso.Tag = permiso;
                            nodoRol.Nodes.Add(nodoPermiso);
                        }
                        nodoUsuario.Nodes.Add(nodoRol);
                    }
                    trvRolesyPermisosPorUsuario.Nodes.Add(nodoUsuario);
                }
                trvRolesyPermisosPorUsuario.ExpandAll();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al mostrar la estructura de roles y permisos: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        // Carga el TreeView (Permisos del Rol Seleccionado)
        private void CargarTreeViewPermisosDelRol(int rolId)
        {
            trViewPermisoRol.Nodes.Clear();
            try
            {
                var rol = bllSeguridad.ObtenerRolConPermisos(rolId);

                if (rol != null && rol.Permisos != null)
                {
                    foreach (var permiso in rol.Permisos.OrderBy(p => p.Nombre))
                    {
                        var nodo = new TreeNode(permiso.Nombre);
                        nodo.Tag = permiso;
                        trViewPermisoRol.Nodes.Add(nodo);
                    }
                    trViewPermisoRol.ExpandAll();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar permisos para el rol: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        #endregion

        #region Lógica Gestión Usuarios

        // Da de alta un nuevo usuario
        private void btnAltaUsuario_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNombreUsuario.Text) || string.IsNullOrWhiteSpace(txtContraseña.Text))
            {
                MessageBox.Show("El Nombre de Usuario y la Contraseña son obligatorios.", "Campos incompletos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                var usuario = new BEUsuario
                {
                    NombreUsuario = txtNombreUsuario.Text.Trim(),
                    Password = txtContraseña.Text, 
                    Activo = chkActivoUsuario.Checked
                };

                bllSeguridad.CrearUsuario(usuario);
                MessageBox.Show("Usuario creado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                CargarComboBoxUsuarios();
                MostrarRolesYPermisosDeTodosLosUsuarios();
                LimpiarCamposUsuario();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al crear el usuario: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Modifica los datos del usuario seleccionado
        private void btnEditarUsuario_Click(object sender, EventArgs e)
        {
            if (cbUsuarioEditarEliminar.SelectedItem is BEUsuario usuarioSeleccionado)
            {
                try
                {
                    // 1. Preparar los datos del usuario (Nombre, Activo)
                    usuarioSeleccionado.NombreUsuario = txtNombreUsuario.Text.Trim();
                    usuarioSeleccionado.Activo = chkActivoUsuario.Checked;

                    // 2. Determinar si la contraseña cambió
                    string nuevaPassword = null;
                    string passEnTextbox = txtContraseña.Text;

                    if (string.IsNullOrWhiteSpace(passEnTextbox))
                    {
                        MessageBox.Show("La contraseña no puede estar vacía.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    // Lógica para determinar si la contraseña cambió
                    string passOriginalPlana = BLLSeguridad.DesencriptarClave(usuarioSeleccionado.Password);

                    if (chkEncriptarDesencriptar.Checked) 
                    {
                        if (passEnTextbox != passOriginalPlana)
                            nuevaPassword = passEnTextbox; 
                    }
                    else //modo Base64
                    {
                        if (passEnTextbox != usuarioSeleccionado.Password)
                        {
                            nuevaPassword = passEnTextbox;
                        }
                    }

                    // 3. Llamar a la BLL 
                    // La BLL se encargará de encriptar 'nuevaPassword' si no es nulo.
                    bllSeguridad.ModificarUsuario(usuarioSeleccionado, nuevaPassword);

                    MessageBox.Show("Usuario modificado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Guardamos el estado actual del combo para recargarlo
                    int idSeleccionado = usuarioSeleccionado.Id;
                    CargarComboBoxUsuarios();
                    cbUsuarioEditarEliminar.SelectedValue = idSeleccionado; // Mantenemos la selección

                    MostrarRolesYPermisosDeTodosLosUsuarios();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al modificar el usuario: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Seleccione un usuario de la lista para editar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }


        // Realiza la baja lógica (Inactivo) o reactiva el usuario seleccionado
        private void btnBorrarUsuario_Click(object sender, EventArgs e)
        {
            if (cbUsuarioEditarEliminar.SelectedItem is BEUsuario usuarioSeleccionado)
            {
                string accion = usuarioSeleccionado.Activo ? "dar de baja" : "reactivar";
                string nuevoEstado = usuarioSeleccionado.Activo ? "Inactivo" : "Activo";

                DialogResult confirm = MessageBox.Show($"¿Está seguro que desea {accion} al usuario '{usuarioSeleccionado.NombreUsuario}'? \n(Su estado cambiará a {nuevoEstado})",
                                                      "Confirmar Operación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (confirm == DialogResult.Yes)
                {
                    try
                    {
                        if (usuarioSeleccionado.Activo)
                        {
                            bllSeguridad.BajaUsuario(usuarioSeleccionado.Id);
                            MessageBox.Show("Usuario dado de baja correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            bllSeguridad.ReactivarUsuario(usuarioSeleccionado.Id);
                            MessageBox.Show("Usuario reactivado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }

                        CargarComboBoxUsuarios();
                        MostrarRolesYPermisosDeTodosLosUsuarios();
                        LimpiarCamposUsuario();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error al {accion} el usuario: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Seleccione un usuario de la lista.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }



        // Al seleccionar un usuario, carga sus datos en los campos de edición
        private void cbUsuarioEditarEliminar_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbUsuarioEditarEliminar.SelectedItem is BEUsuario usuario)
            {
                txtCodigoUsuario.Text = usuario.Id.ToString();
                txtNombreUsuario.Text = usuario.NombreUsuario;
                chkActivoUsuario.Checked = usuario.Activo;
                btnBorrarUsuario.Text = usuario.Activo ? "Baja" : "Reactivar";

                // Desconectar el evento del checkbox antes de cambiarlo
                chkEncriptarDesencriptar.CheckedChanged -= chkEncriptarDesencriptar_CheckedChanged;

                // Establecer estado por defecto (oculto = Base64)
                chkEncriptarDesencriptar.Checked = false;
                txtContraseña.PasswordChar = '\0'; 
                txtContraseña.Text = usuario.Password; // Cargar la contraseña Base64
                txtContraseña.PlaceholderText = "";

                // Reconectar el evento
                chkEncriptarDesencriptar.CheckedChanged += chkEncriptarDesencriptar_CheckedChanged;
            }
        }

  
        // Muestra/Oculta la contraseña en texto plano o en base64
        private void chkEncriptarDesencriptar_CheckedChanged(object sender, EventArgs e)
        {
            if (cbUsuarioEditarEliminar.SelectedItem == null)
            {
                txtContraseña.PasswordChar = chkEncriptarDesencriptar.Checked ? '\0' : '*';
                return;
            }

            txtContraseña.PasswordChar = '\0';

            BEUsuario usuarioSeleccionado = (BEUsuario)cbUsuarioEditarEliminar.SelectedItem;
            string textoActual = txtContraseña.Text;

            if (chkEncriptarDesencriptar.Checked)
            {
                // Solo desencriptar si el texto actual es el Base64 original
                if (textoActual == usuarioSeleccionado.Password)
                {
                    txtContraseña.Text = BLLSeguridad.DesencriptarClave(usuarioSeleccionado.Password);
                }
            }
            else
            {
                // El usuario quiere OCULTAR (volver a Base64)
                // Solo re-encriptar si el texto actual es el plano original
                string passOriginalPlana = BLLSeguridad.DesencriptarClave(usuarioSeleccionado.Password);
                if (textoActual == passOriginalPlana)
                {
                    txtContraseña.Text = usuarioSeleccionado.Password;
                }
            }
        }


        // Limpia los campos de gestión de usuarios
        private void btnLimpiarCamposUsuario_Click(object sender, EventArgs e)
        {
            LimpiarCamposUsuario();
        }


        // Resetea los controles del panel de gestión de usuarios a su estado inicial
        private void LimpiarCamposUsuario()
        {
            cbUsuarioEditarEliminar.SelectedIndexChanged -= cbUsuarioEditarEliminar_SelectedIndexChanged;
            chkEncriptarDesencriptar.CheckedChanged -= chkEncriptarDesencriptar_CheckedChanged;

            cbUsuarioEditarEliminar.SelectedIndex = -1;
            txtCodigoUsuario.Clear();
            txtNombreUsuario.Clear();
            txtContraseña.Clear();
            txtContraseña.PlaceholderText = "Ingresar nueva contraseña";
            chkActivoUsuario.Checked = true;

            chkEncriptarDesencriptar.Checked = false;
            txtContraseña.PasswordChar = '*'; 

            btnBorrarUsuario.Text = "Baja";

            cbUsuarioEditarEliminar.SelectedIndexChanged += cbUsuarioEditarEliminar_SelectedIndexChanged;
            chkEncriptarDesencriptar.CheckedChanged += chkEncriptarDesencriptar_CheckedChanged;
        }


        #endregion

        #region Lógica Gestión Roles

        // Da de alta un nuevo rol
        private void btnAltaRol_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNombreRol.Text))
            {
                MessageBox.Show("El nombre del rol es obligatorio.", "Campo requerido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                var rol = new BERol
                {
                    Nombre = txtNombreRol.Text.Trim(),
                    Activo = chkActivoRol.Checked
                };

                bllSeguridad.CrearRol(rol);
                MessageBox.Show("Rol creado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                CargarComboBoxRoles();
                LimpiarCamposRol();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al crear el rol: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Modifica el nombre o estado del rol seleccionado
        private void btnEditarRol_Click(object sender, EventArgs e)
        {
            if (cbRolEditarEliminar.SelectedItem is BERol rolSeleccionado)
            {
                if (string.IsNullOrWhiteSpace(txtNombreRol.Text))
                {
                    MessageBox.Show("El nombre del rol no puede estar vacío.", "Campo requerido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                try
                {
                    rolSeleccionado.Nombre = txtNombreRol.Text.Trim();
                    rolSeleccionado.Activo = chkActivoRol.Checked;

                    bllSeguridad.ModificarRol(rolSeleccionado);
                    MessageBox.Show("Rol modificado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    CargarComboBoxRoles();
                    MostrarRolesYPermisosDeTodosLosUsuarios();
                    LimpiarCamposRol();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al modificar el rol: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Seleccione un rol de la lista para editar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        // Realiza la baja lógica (Inactivo) o reactiva el rol seleccionado
        private void btnBorrarRol_Click(object sender, EventArgs e)
        {
            if (cbRolEditarEliminar.SelectedItem is BERol rolSeleccionado)
            {
                string accion = rolSeleccionado.Activo ? "dar de baja" : "reactivar";
                string nuevoEstado = rolSeleccionado.Activo ? "Inactivo" : "Activo";

                DialogResult confirm = MessageBox.Show($"¿Está seguro que desea {accion} el rol '{rolSeleccionado.Nombre}'? \n(Su estado cambiará a {nuevoEstado})",
                                                      "Confirmar Operación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (confirm == DialogResult.Yes)
                {
                    try
                    {
                        if (rolSeleccionado.Activo)
                        {
                            bllSeguridad.BajaRol(rolSeleccionado.Id);
                            MessageBox.Show("Rol dado de baja correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            bllSeguridad.ReactivarRol(rolSeleccionado.Id);
                            MessageBox.Show("Rol reactivado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }

                        CargarComboBoxRoles();
                        MostrarRolesYPermisosDeTodosLosUsuarios();
                        LimpiarCamposRol();
                    }
                    catch (InvalidOperationException exInv)
                    {
                        MessageBox.Show(exInv.Message, "Operación no permitida", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error al {accion} el rol: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Seleccione un rol de la lista.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        // Al seleccionar un rol, carga sus datos en los campos de edición
        private void cbRolEditarEliminar_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbRolEditarEliminar.SelectedItem is BERol rol)
            {
                txtCodigoRol.Text = rol.Id.ToString();
                txtNombreRol.Text = rol.Nombre;
                chkActivoRol.Checked = rol.Activo;
                btnBorrarRol.Text = rol.Activo ? "Baja" : "Reactivar";
            }
        }

        // Limpia los campos de gestión de roles
        private void btnLimpiarCamposRol_Click(object sender, EventArgs e)
        {
            LimpiarCamposRol();
        }

        // Resetea los controles del panel de gestión de roles a su estado inicial
        private void LimpiarCamposRol()
        {
            cbRolEditarEliminar.SelectedIndexChanged -= cbRolEditarEliminar_SelectedIndexChanged;
            cbRolEditarEliminar.SelectedIndex = -1;
            txtCodigoRol.Clear();
            txtNombreRol.Clear();
            chkActivoRol.Checked = true;
            btnBorrarRol.Text = "Baja";
            cbRolEditarEliminar.SelectedIndexChanged += cbRolEditarEliminar_SelectedIndexChanged;
        }

        #endregion

        #region Lógica Asignación Permiso <-> Rol

        // Al seleccionar un rol, muestra sus permisos asignados y marca los permisos en la lista general
        private void cbRolParaAsociarApermiso_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Desconectar evento
            trvwPermisoAasociar.AfterCheck -= trvwPermisoAasociar_AfterCheck;

            MarcarNodosRecursivo(trvwPermisoAasociar.Nodes, false);
            trViewPermisoRol.Nodes.Clear();

            if (cbRolParaAsociarApermiso.SelectedItem is BERol rolSeleccionado && rolSeleccionado.Id != 0)
            {
                var rolConPermisos = bllSeguridad.ObtenerRolConPermisos(rolSeleccionado.Id);
                if (rolConPermisos != null && rolConPermisos.Permisos != null)
                {
                    foreach (var permiso in rolConPermisos.Permisos.OrderBy(p => p.Nombre))
                    {
                        TreeNode nodo = new TreeNode(permiso.Nombre);
                        nodo.Tag = permiso;
                        trViewPermisoRol.Nodes.Add(nodo);
                    }
                    var idsPermisosDelRol = rolConPermisos.Permisos.Select(p => p.Id).ToList();
                    MarcarPermisosEnTreeView(trvwPermisoAasociar.Nodes, idsPermisosDelRol);
                }

                bool esAdmin = rolSeleccionado.Nombre.Equals("Administrador", StringComparison.OrdinalIgnoreCase);
                btnAsociarPermisoArol.Enabled = !esAdmin;
                btnDesasociarPermisoArol.Enabled = !esAdmin;
                btnAsociarPermisosMarcados.Enabled = !esAdmin;
                trvwPermisoAasociar.Enabled = !esAdmin; // Deshabilita el treeview si es Admin

                if (esAdmin) trViewPermisoRol.Nodes.Insert(0, new TreeNode("PERMISOS DE ADMIN NO MODIFICABLES"));
            }
            else
            {
                btnAsociarPermisoArol.Enabled = false;
                btnDesasociarPermisoArol.Enabled = false;
                btnAsociarPermisosMarcados.Enabled = false;
                trvwPermisoAasociar.Enabled = true; // Habilita por defecto
            }

            // Reconectar evento
            trvwPermisoAasociar.AfterCheck += trvwPermisoAasociar_AfterCheck;
        }

        // Marca (check) los nodos del TreeView de permisos que ya están asignados al rol
        private void MarcarPermisosEnTreeView(TreeNodeCollection nodos, List<int> idsPermisos)
        {
            foreach (TreeNode nodo in nodos)
            {
                if (nodo.Tag is BEPermiso permiso) // Solo marca las hojas
                {
                    nodo.Checked = idsPermisos.Contains(permiso.Id);
                }

                if (nodo.Nodes.Count > 0)
                {
                    MarcarPermisosEnTreeView(nodo.Nodes, idsPermisos);
                    // Marcar padre si todos los hijos están marcados
                    MarcarPadre(nodo);
                }
            }
        }

        // Función auxiliar para marcar o desmarcar todos los nodos de un TreeView
        private void MarcarNodosRecursivo(TreeNodeCollection nodos, bool check)
        {
            foreach (TreeNode nodo in nodos)
            {
                nodo.Checked = check;
                if (nodo.Nodes.Count > 0) MarcarNodosRecursivo(nodo.Nodes, check);
            }
        }

        // Asocia un permiso (seleccionado en 'trvwPermisoAasociar') al rol seleccionado
        private void btnAsociarPermisoArol_Click(object sender, EventArgs e)
        {
            if (cbRolParaAsociarApermiso.SelectedItem is BERol rolSeleccionado && rolSeleccionado.Id != 0 &&
                trvwPermisoAasociar.SelectedNode?.Tag is BEPermisoComponent permisoSeleccionado)
            {
                if (rolSeleccionado.Nombre.Equals("Administrador", StringComparison.OrdinalIgnoreCase)) return;

                //  Obtener solo las hojas del permiso seleccionado
                List<BEPermisoComponent> permisosAAsignar = new List<BEPermisoComponent>();
                if (permisoSeleccionado is BEPermiso)
                {
                    permisosAAsignar.Add(permisoSeleccionado);
                }
                else if (permisoSeleccionado is BECategoriaPermiso)
                {
                    permisosAAsignar.AddRange(ObtenerHojasRecursivo(permisoSeleccionado));
                }

                try
                {
                    var permisosActuales = bllSeguridad.ObtenerRolConPermisos(rolSeleccionado.Id).Permisos.Cast<BEPermisoComponent>().ToList();
                    bool huboCambios = false;

                    foreach (var permiso in permisosAAsignar)
                    {
                        if (!permisosActuales.Any(p => p.Id == permiso.Id))
                        {
                            permisosActuales.Add(permiso);
                            huboCambios = true;
                        }
                    }

                    if (!huboCambios)
                    {
                        MessageBox.Show("El rol ya tiene este permiso (o permisos) asignado.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }

                    bllSeguridad.AsignarPermisosARol(rolSeleccionado.Id, permisosActuales);

                    MessageBox.Show("Permiso(s) asociado(s) correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Recargar vistas
                    trvwPermisoAasociar.AfterCheck -= trvwPermisoAasociar_AfterCheck;
                    CargarTreeViewPermisosDelRol(rolSeleccionado.Id);
                    MarcarPermisosEnTreeView(trvwPermisoAasociar.Nodes, permisosActuales.Select(p => p.Id).ToList());
                    trvwPermisoAasociar.AfterCheck += trvwPermisoAasociar_AfterCheck;

                    MostrarRolesYPermisosDeTodosLosUsuarios();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al asociar permiso: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Seleccione un rol y un permiso disponible para asociar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        // Quita un permiso  del rol seleccionado
        private void btnDesasociarPermisoArol_Click(object sender, EventArgs e)
        {
            if (cbRolParaAsociarApermiso.SelectedItem is BERol rolSeleccionado && rolSeleccionado.Id != 0 &&
               trViewPermisoRol.SelectedNode?.Tag is BEPermisoComponent permisoAQuitar)
            {
                if (rolSeleccionado.Nombre.Equals("Administrador", StringComparison.OrdinalIgnoreCase)) return;

                try
                {
                    var permisosActuales = bllSeguridad.ObtenerRolConPermisos(rolSeleccionado.Id).Permisos;
                    var permisoEncontrado = permisosActuales.FirstOrDefault(p => p.Id == permisoAQuitar.Id);

                    if (permisoEncontrado == null)
                    {
                        MessageBox.Show("El rol no tiene este permiso (o ya fue quitado).", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }

                    permisosActuales.Remove(permisoEncontrado);

                    bllSeguridad.AsignarPermisosARol(rolSeleccionado.Id, permisosActuales.Cast<BEPermisoComponent>().ToList());
                    MessageBox.Show("Permiso desasociado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    trvwPermisoAasociar.AfterCheck -= trvwPermisoAasociar_AfterCheck;
                    CargarTreeViewPermisosDelRol(rolSeleccionado.Id);
                    MarcarPermisosEnTreeView(trvwPermisoAasociar.Nodes, permisosActuales.Select(p => p.Id).ToList());
                    trvwPermisoAasociar.AfterCheck += trvwPermisoAasociar_AfterCheck;

                    MostrarRolesYPermisosDeTodosLosUsuarios();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al desasociar permiso: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Seleccione un rol y un permiso *ya asignado* (de la lista 'Permisos por rol') para desasociar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        // Guarda todos los permisos marcados (check) en 'trvwPermisoAasociar' para el rol seleccionado
        private void btnAsociarPermisosMarcados_Click(object sender, EventArgs e)
        {
            if (cbRolParaAsociarApermiso.SelectedItem is BERol rolSeleccionado && rolSeleccionado.Id != 0)
            {
                if (rolSeleccionado.Nombre.Equals("Administrador", StringComparison.OrdinalIgnoreCase)) return;

                try
                {
                    List<BEPermisoComponent> permisosMarcados = ObtenerHojasSeleccionadas(trvwPermisoAasociar.Nodes);

                    bllSeguridad.AsignarPermisosARol(rolSeleccionado.Id, permisosMarcados);
                    MessageBox.Show("Permisos guardados para el rol (basado en las marcas).", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    trvwPermisoAasociar.AfterCheck -= trvwPermisoAasociar_AfterCheck;
                    CargarTreeViewPermisosDelRol(rolSeleccionado.Id);
                    MarcarPermisosEnTreeView(trvwPermisoAasociar.Nodes, permisosMarcados.Select(p => p.Id).ToList());
                    trvwPermisoAasociar.AfterCheck += trvwPermisoAasociar_AfterCheck;

                    MostrarRolesYPermisosDeTodosLosUsuarios();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al guardar los permisos marcados: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Seleccione un rol para asignar los permisos marcados.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        // Recorre el TreeView y devuelve una lista de las HOJAS (BEPermiso) marcadas (check)
        private List<BEPermisoComponent> ObtenerHojasSeleccionadas(TreeNodeCollection nodos)
        {
            var lista = new List<BEPermisoComponent>();
            foreach (TreeNode nodo in nodos)
            {
                if (nodo.Checked && nodo.Tag is BEPermiso permisoHoja)
                {
                    lista.Add(permisoHoja);
                }
                if (nodo.Nodes.Count > 0)
                {
                    lista.AddRange(ObtenerHojasSeleccionadas(nodo.Nodes));
                }
            }
            return lista;
        }


        // Obtiene todas las hojas de un componente (ya sea una hoja o un grupo)
        private List<BEPermisoComponent> ObtenerHojasRecursivo(BEPermisoComponent componente)
        {
            var lista = new List<BEPermisoComponent>();
            if (componente is BEPermiso)
            {
                lista.Add(componente);
            }
            else if (componente is BECategoriaPermiso)
            {
                foreach (var hijo in componente.ObtenerHijos())
                {
                    lista.AddRange(ObtenerHojasRecursivo(hijo));
                }
            }
            return lista;
        }


        #endregion

        #region Lógica Asignación Usuario <-> Rol

        // Asocia el rol seleccionado al usuario seleccionado
        private void btnAsociarUsuarioArol_Click(object sender, EventArgs e)
        {
            if (cmbUsuarioAasociarRol.SelectedItem is BEUsuario usuario && usuario.Id != 0 &&
                cmbRolAasociarAusuario.SelectedItem is BERol rol && rol.Id != 0)
            {
                try
                {
                    var rolesActuales = bllSeguridad.ObtenerRolesDeUsuario(usuario.Id);
                    if (rolesActuales.Any(r => r.Id == rol.Id))
                    {
                        MessageBox.Show("El usuario ya tiene ese rol asignado.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }

                    bllSeguridad.AsignarRolAUsuario(usuario.Id, rol.Id);
                    MessageBox.Show("Rol asociado al usuario correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    MostrarRolesYPermisosDeTodosLosUsuarios();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al asociar rol: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Seleccione un usuario y un rol válidos.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        // Quita el rol seleccionado del usuario seleccionado
        private void btnDesasociarUsuarioArol_Click(object sender, EventArgs e)
        {
            if (cmbUsuarioAasociarRol.SelectedItem is BEUsuario usuario && usuario.Id != 0 &&
                cmbRolAasociarAusuario.SelectedItem is BERol rol && rol.Id != 0)
            {
                try
                {
                    var rolesActuales = bllSeguridad.ObtenerRolesDeUsuario(usuario.Id);
                    if (!rolesActuales.Any(r => r.Id == rol.Id))
                    {
                        MessageBox.Show("El usuario no tiene ese rol asignado.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }

                    bllSeguridad.QuitarRolDeUsuario(usuario.Id, rol.Id);
                    MessageBox.Show("Rol desasociado del usuario correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    MostrarRolesYPermisosDeTodosLosUsuarios();
                }
                catch (InvalidOperationException exInv)
                {
                    MessageBox.Show(exInv.Message, "Operación no permitida", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al desasociar rol: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Seleccione un usuario y un rol válidos.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        #endregion

        #region Eventos TreeView Permisos

     
        // Evento que se dispara después de marcar o desmarcar un nodo
        private void trvwPermisoAasociar_AfterCheck(object sender, TreeViewEventArgs e)
        {
            if (e.Action == TreeViewAction.Unknown) return;

            // 1. Marcar/Desmarcar todos los hijos recursivamente
            MarcarHijos(e.Node, e.Node.Checked);

            // 2. Actualizar estado del padre
            if (e.Node.Parent != null)
            {
                MarcarPadre(e.Node.Parent);
            }
        }

        // Función auxiliar para marcar hijos
        private void MarcarHijos(TreeNode nodoPadre, bool marcado)
        {
            foreach (TreeNode nodoHijo in nodoPadre.Nodes)
            {
                if (nodoHijo.Checked != marcado)
                {
                    nodoHijo.Checked = marcado; 
                }
            }
        }

        // Función auxiliar para marcar al padre
        private void MarcarPadre(TreeNode nodoPadre)
        {
            bool todosHijosMarcados = true;
            foreach (TreeNode nodoHijo in nodoPadre.Nodes)
            {
                if (!nodoHijo.Checked)
                {
                    todosHijosMarcados = false;
                    break;
                }
            }

            if (nodoPadre.Checked != todosHijosMarcados)
            {
                nodoPadre.Checked = todosHijosMarcados;
            }
        }

        #endregion
    }
}