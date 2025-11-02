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

        // Carga el TreeView 'trvwPermisoAasociar' con las definiciones de permisos
        private void CargarPermisosEnTreeView()
        {
            try
            {
                _definicionesPermisosCache = bllSeguridad.ObtenerDefinicionesPermisos();
                trvwPermisoAasociar.Nodes.Clear();

                foreach (var permiso in _definicionesPermisosCache.OrderBy(p => p.Nombre))
                {
                    TreeNode nodo = new TreeNode(permiso.Nombre);
                    nodo.Tag = permiso;
                    trvwPermisoAasociar.Nodes.Add(nodo);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar permisos: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Carga los ComboBox de Roles (cbRolEditarEliminar, cbRolParaAsociarApermiso, cmbRolAasociarAusuario)
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

        // Carga los ComboBox de Usuarios (cbUsuarioEditarEliminar, cmbUsuarioAasociarRol)
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

        // Carga el TreeView 'trvRolesyPermisosPorUsuario' con la vista general
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


        // Carga el TreeView 'trViewPermisoRol' (Permisos del Rol Seleccionado)
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
                    Password = txtContraseña.Text, // BLL se encarga de encriptar
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
                    usuarioSeleccionado.NombreUsuario = txtNombreUsuario.Text.Trim();
                    usuarioSeleccionado.Activo = chkActivoUsuario.Checked;

                    string nuevaPassword = null;

                    if (!chkEncriptarDesencriptar.Checked && !string.IsNullOrWhiteSpace(txtContraseña.Text))
                    {
                        nuevaPassword = txtContraseña.Text; // Se pasará a BLL para encriptar
                    }
                    else if (chkEncriptarDesencriptar.Checked && !string.IsNullOrWhiteSpace(txtContraseña.Text))
                    {
                        usuarioSeleccionado.Password = txtContraseña.Text;
                        bllSeguridad.ModificarUsuario(usuarioSeleccionado, null); // Llama sin nueva password
                    }
                    else
                    {
                        bllSeguridad.ModificarUsuario(usuarioSeleccionado, null);
                    }

                    if (nuevaPassword != null)
                    {
                        bllSeguridad.ModificarUsuario(usuarioSeleccionado, nuevaPassword);
                    }


                    MessageBox.Show("Usuario modificado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    CargarComboBoxUsuarios();
                    MostrarRolesYPermisosDeTodosLosUsuarios();
                    LimpiarCamposUsuario();
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

                txtContraseña.Text = usuario.Password;

                chkEncriptarDesencriptar_CheckedChanged(sender, e);
            }
        }

        // Muestra/Oculta la contraseña en texto plano o "encriptada" (Base64)
        private void chkEncriptarDesencriptar_CheckedChanged(object sender, EventArgs e)
        {
            txtContraseña.PasswordChar = '\0';
            string passMostrada = txtContraseña.Text;

            if (chkEncriptarDesencriptar.Checked)
            {
                txtContraseña.Text = BLLSeguridad.DesencriptarClave(passMostrada);
            }
            else
            {
                bool estaEncriptada = (passMostrada.Length % 4 == 0) && System.Text.RegularExpressions.Regex.IsMatch(passMostrada, @"^[a-zA-Z0-9\+/]*={0,3}$", System.Text.RegularExpressions.RegexOptions.None);

                if (!estaEncriptada)
                {
                    txtContraseña.Text = BLLSeguridad.EncriptarClave(passMostrada);
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
                if (esAdmin) trViewPermisoRol.Nodes.Insert(0, new TreeNode("PERMISOS DE ADMIN NO MODIFICABLES"));
            }
            else
            {
                btnAsociarPermisoArol.Enabled = false;
                btnDesasociarPermisoArol.Enabled = false;
                btnAsociarPermisosMarcados.Enabled = false;
            }
        }

        // Marca (check) los nodos del TreeView de permisos que ya están asignados al rol
        private void MarcarPermisosEnTreeView(TreeNodeCollection nodos, List<int> idsPermisos)
        {
            foreach (TreeNode nodo in nodos)
            {
                if (nodo.Tag is BEPermisoComponent permiso)
                {
                    nodo.Checked = idsPermisos.Contains(permiso.Id);
                }
                if (nodo.Nodes.Count > 0)
                {
                    MarcarPermisosEnTreeView(nodo.Nodes, idsPermisos);
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

                try
                {
                    var permisosActuales = bllSeguridad.ObtenerRolConPermisos(rolSeleccionado.Id).Permisos;

                    if (permisosActuales.Any(p => p.Id == permisoSeleccionado.Id))
                    {
                        MessageBox.Show("El rol ya tiene este permiso asignado.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }

                    permisosActuales.Add(permisoSeleccionado as BEPermiso);

                    bllSeguridad.AsignarPermisosARol(rolSeleccionado.Id, permisosActuales.Cast<BEPermisoComponent>().ToList());

                    MessageBox.Show("Permiso asociado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    CargarTreeViewPermisosDelRol(rolSeleccionado.Id);
                    trvwPermisoAasociar.SelectedNode.Checked = true;
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

        // Quita un permiso (seleccionado en 'trViewPermisoRol') del rol seleccionado
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

                    CargarTreeViewPermisosDelRol(rolSeleccionado.Id);
                    MarcarPermisosEnTreeView(trvwPermisoAasociar.Nodes, permisosActuales.Select(p => p.Id).ToList());
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
                    List<BEPermisoComponent> permisosMarcados = ObtenerPermisosSeleccionados(trvwPermisoAasociar.Nodes);

                    bllSeguridad.AsignarPermisosARol(rolSeleccionado.Id, permisosMarcados);
                    MessageBox.Show("Permisos guardados para el rol (basado en las marcas).", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    CargarTreeViewPermisosDelRol(rolSeleccionado.Id);
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

        // Recorre el TreeView y devuelve una lista de los componentes de permiso marcados (check)
        private List<BEPermisoComponent> ObtenerPermisosSeleccionados(TreeNodeCollection nodos)
        {
            var lista = new List<BEPermisoComponent>();
            foreach (TreeNode nodo in nodos)
            {
                if (nodo.Checked && nodo.Tag is BEPermisoComponent permiso)
                {
                    lista.Add(permiso);
                }
                if (nodo.Nodes.Count > 0)
                {
                    lista.AddRange(ObtenerPermisosSeleccionados(nodo.Nodes));
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
    }
}