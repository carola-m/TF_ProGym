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
        // Usamos BLLSeguridad que centraliza la lógica de usuarios, roles y permisos
        private readonly BLLSeguridad bllSeguridad = new BLLSeguridad();

        // Almacenamos la lista de definiciones de permisos para no cargarla cada vez
        private List<BEPermisoComponent> _definicionesPermisosCache;

        public frmUsuarios()
        {
            InitializeComponent();
            // Ya no conectamos eventos aquí, se conectan en el Designer.cs
        }

        private void frmUsuarios_Load(object sender, EventArgs e)
        {
            // Cargar datos iniciales al abrir el formulario
            CargarPermisosEnTreeView();
            CargarComboBoxUsuarios();
            CargarComboBoxRoles();
            MostrarRolesYPermisosDeTodosLosUsuarios(); // Carga la vista general

            // Estado inicial de los campos
            LimpiarCamposUsuario();
            LimpiarCamposRol();
        }

        #region Lógica Carga de Controles

        // Carga el TreeView 'trvwPermisoAasociar' con las definiciones de permisos
        private void CargarPermisosEnTreeView()
        {
            try
            {
                // Obtiene las definiciones (hojas) desde BLLSeguridad
                _definicionesPermisosCache = bllSeguridad.ObtenerDefinicionesPermisos();
                trvwPermisoAasociar.Nodes.Clear();

                // Aquí asumimos una lista plana de permisos (hojas)
                // Si tuvieras un Composite (Categorías) en la definición,
                // necesitarías una función recursiva para construir el árbol.
                foreach (var permiso in _definicionesPermisosCache.OrderBy(p => p.Nombre))
                {
                    TreeNode nodo = new TreeNode(permiso.Nombre);
                    nodo.Tag = permiso; // Almacena el objeto BEPermisoComponent completo
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
                var rolesTodos = bllSeguridad.ListarTodosRoles(); // Incluye activos e inactivos
                var rolesActivos = rolesTodos.Where(r => r.Activo).ToList();

                // Combo para Editar/Baja (muestra todos)
                cbRolEditarEliminar.DataSource = null;
                cbRolEditarEliminar.DataSource = rolesTodos;
                cbRolEditarEliminar.DisplayMember = "Nombre";
                cbRolEditarEliminar.ValueMember = "Id"; // Usamos 'Id'
                cbRolEditarEliminar.SelectedIndex = -1;

                // Combo para Asignar Permisos a Rol (solo activos)
                cbRolParaAsociarApermiso.DataSource = null;
                cbRolParaAsociarApermiso.DataSource = rolesActivos;
                cbRolParaAsociarApermiso.DisplayMember = "Nombre";
                cbRolParaAsociarApermiso.ValueMember = "Id";
                cbRolParaAsociarApermiso.SelectedIndex = -1;

                // Combo para Asignar Rol a Usuario (solo activos)
                cmbRolAasociarAusuario.DataSource = null;
                cmbRolAasociarAusuario.DataSource = rolesActivos;
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
                var usuariosTodos = bllSeguridad.ListarUsuarios(); // BLLSeguridad ya lista todos
                var usuariosActivos = usuariosTodos.Where(u => u.Activo).ToList();

                // Combo para Editar/Baja (muestra todos)
                cbUsuarioEditarEliminar.DataSource = null;
                cbUsuarioEditarEliminar.DataSource = usuariosTodos;
                cbUsuarioEditarEliminar.DisplayMember = "NombreUsuario"; // Coincide con BEUsuario
                cbUsuarioEditarEliminar.ValueMember = "Id"; // Coincide con BEUsuario
                cbUsuarioEditarEliminar.SelectedIndex = -1;

                // Combo para Asignar Rol a Usuario (solo activos)
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
                var usuarios = bllSeguridad.ListarUsuarios(); // Obtiene todos los usuarios

                foreach (var usuario in usuarios)
                {
                    // Nodo principal para el usuario (mostrar si está inactivo)
                    string nombreDisplayUsuario = usuario.Activo ? usuario.NombreUsuario : $"{usuario.NombreUsuario} (Inactivo)";
                    var nodoUsuario = new TreeNode(nombreDisplayUsuario);
                    nodoUsuario.Tag = usuario; // Guardar el objeto usuario

                    // Obtiene los roles (activos) asociados a este usuario
                    var roles = bllSeguridad.ObtenerRolesDeUsuario(usuario.Id);

                    foreach (var rol in roles)
                    {
                        // Nodo para el rol
                        var nodoRol = new TreeNode(rol.Nombre);
                        nodoRol.Tag = rol; // Guardar el objeto rol

                        // Obtiene los permisos (hojas) de ese rol
                        // BLLSeguridad.ObtenerRolesDeUsuario ya devuelve los roles con sus permisos
                        foreach (var permiso in rol.Permisos.OrderBy(p => p.Nombre))
                        {
                            var nodoPermiso = new TreeNode(permiso.Nombre);
                            nodoPermiso.Tag = permiso; // Guardar el objeto permiso
                            nodoRol.Nodes.Add(nodoPermiso);
                        }
                        nodoUsuario.Nodes.Add(nodoRol);
                    }
                    trvRolesyPermisosPorUsuario.Nodes.Add(nodoUsuario);
                }
                trvRolesyPermisosPorUsuario.ExpandAll(); // Expandir todo para ver
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al mostrar la estructura de roles y permisos: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        // Carga el TreeView 'trViewPermisoRol' (Permisos del Rol Seleccionado)
        private void CargarTreeViewPermisosDelRol(int codigoRol)
        {
            trViewPermisoRol.Nodes.Clear();
            try
            {
                // Obtiene el rol específico con sus permisos
                var rol = bllSeguridad.ObtenerRolConPermisos(codigoRol);

                if (rol != null && rol.Permisos != null)
                {
                    foreach (var permiso in rol.Permisos.OrderBy(p => p.Nombre))
                    {
                        // Muestra solo las hojas (permisos simples)
                        var nodo = new TreeNode(permiso.Nombre);
                        nodo.Tag = permiso; // Guarda el objeto BEPermisoComponent
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
                    // DebeCambiarPassword se establece en 'true' por defecto en BE o BLL
                };

                bllSeguridad.CrearUsuario(usuario);
                MessageBox.Show("Usuario creado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                CargarComboBoxUsuarios(); // Recargar listas
                MostrarRolesYPermisosDeTodosLosUsuarios(); // Actualizar vista general
                LimpiarCamposUsuario();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al crear el usuario: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEditarUsuario_Click(object sender, EventArgs e)
        {
            if (cbUsuarioEditarEliminar.SelectedItem is BEUsuario usuarioSeleccionado)
            {
                try
                {
                    // Asigna los valores desde los controles
                    usuarioSeleccionado.NombreUsuario = txtNombreUsuario.Text.Trim();
                    usuarioSeleccionado.Activo = chkActivoUsuario.Checked;

                    // Variable para la nueva contraseña
                    string nuevaPassword = null;

                    // Solo actualiza la contraseña si el usuario escribió algo en el TextBox
                    if (!string.IsNullOrWhiteSpace(txtContraseña.Text))
                    {
                        nuevaPassword = txtContraseña.Text;
                        // Opcional: Forzar a 'false' si un admin resetea la pass
                        // usuarioSeleccionado.DebeCambiarPassword = false; 
                    }

                    // Llama a BLLSeguridad (que encriptará 'nuevaPassword' si no es null)
                    bllSeguridad.ModificarUsuario(usuarioSeleccionado, nuevaPassword);

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

        private void btnBorrarUsuario_Click(object sender, EventArgs e)
        {
            if (cbUsuarioEditarEliminar.SelectedItem is BEUsuario usuarioSeleccionado)
            {
                // Pregunta de confirmación
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
                            // Es una baja lógica
                            bllSeguridad.BajaUsuario(usuarioSeleccionado.Id);
                            MessageBox.Show("Usuario dado de baja correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            // Es una reactivación
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

        private void cbUsuarioEditarEliminar_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbUsuarioEditarEliminar.SelectedItem is BEUsuario usuario)
            {
                txtCodigoUsuario.Text = usuario.Id.ToString();
                txtNombreUsuario.Text = usuario.NombreUsuario;
                chkActivoUsuario.Checked = usuario.Activo;
                // Dejamos el campo de contraseña vacío a propósito
                txtContraseña.Clear();
                txtContraseña.PlaceholderText = "(Dejar vacío para no cambiar)";

                // Ajustar texto del botón Baja/Reactivar
                btnBorrarUsuario.Text = usuario.Activo ? "Baja" : "Reactivar";
            }
        }

        private void btnLimpiarCamposUsuario_Click(object sender, EventArgs e)
        {
            LimpiarCamposUsuario();
        }

        private void LimpiarCamposUsuario()
        {
            // Desconecta temporalmente el evento para evitar que se dispare al limpiar
            cbUsuarioEditarEliminar.SelectedIndexChanged -= cbUsuarioEditarEliminar_SelectedIndexChanged;

            cbUsuarioEditarEliminar.SelectedIndex = -1;
            txtCodigoUsuario.Clear();
            txtNombreUsuario.Clear();
            txtContraseña.Clear();
            txtContraseña.PlaceholderText = "";
            chkActivoUsuario.Checked = true; // Estado por defecto
            btnBorrarUsuario.Text = "Baja"; // Texto por defecto

            // Reconecta el evento
            cbUsuarioEditarEliminar.SelectedIndexChanged += cbUsuarioEditarEliminar_SelectedIndexChanged;
        }

        // El check de Encriptar/Desencriptar fue removido (incompatible con Hashing BCrypt)
        // private void chkEncriptarDesencriptar_CheckedChanged_1(object sender, EventArgs e) { ... }

        #endregion

        #region Lógica Gestión Roles

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

                CargarComboBoxRoles(); // Recargar todos los combos de roles
                LimpiarCamposRol();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al crear el rol: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

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
                    // Asigna los valores desde los controles
                    rolSeleccionado.Nombre = txtNombreRol.Text.Trim();
                    rolSeleccionado.Activo = chkActivoRol.Checked;

                    bllSeguridad.ModificarRol(rolSeleccionado);
                    MessageBox.Show("Rol modificado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    CargarComboBoxRoles();
                    MostrarRolesYPermisosDeTodosLosUsuarios(); // Actualizar vista general por si cambió nombre
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

        // Este es el evento para tu botón "Borrar" (Baja) de Rol
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
                    catch (InvalidOperationException exInv) // Captura reglas (ej. rol en uso)
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

        private void btnLimpiarCamposRol_Click(object sender, EventArgs e)
        {
            LimpiarCamposRol();
        }

        private void LimpiarCamposRol()
        {
            cbRolEditarEliminar.SelectedIndexChanged -= cbRolEditarEliminar_SelectedIndexChanged; // Desconecta
            cbRolEditarEliminar.SelectedIndex = -1;
            txtCodigoRol.Clear();
            txtNombreRol.Clear();
            chkActivoRol.Checked = true;
            btnBorrarRol.Text = "Baja";
            cbRolEditarEliminar.SelectedIndexChanged += cbRolEditarEliminar_SelectedIndexChanged; // Reconecta
        }

        #endregion

        #region Lógica Asignación Permiso <-> Rol

        // Se dispara cuando seleccionas un Rol en el ComboBox de "Asociar Permiso a Rol"
        private void cbRolParaAsociarApermiso_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Desmarcar todos los nodos del árbol de permisos disponibles
            MarcarNodosRecursivo(trvwPermisoAasociar.Nodes, false);
            // Limpiar la vista de permisos del rol
            trViewPermisoRol.Nodes.Clear();

            if (cbRolParaAsociarApermiso.SelectedItem is BERol rolSeleccionado && rolSeleccionado.Id != 0)
            {
                // Cargar los permisos que este rol YA TIENE
                var rolConPermisos = bllSeguridad.ObtenerRolConPermisos(rolSeleccionado.Id);
                if (rolConPermisos != null && rolConPermisos.Permisos != null)
                {
                    // 1. Llenar el TreeView 'trViewPermisoRol' (Permisos que ya tiene)
                    foreach (var permiso in rolConPermisos.Permisos.OrderBy(p => p.Nombre))
                    {
                        TreeNode nodo = new TreeNode(permiso.Nombre);
                        nodo.Tag = permiso;
                        trViewPermisoRol.Nodes.Add(nodo);
                    }

                    // 2. Marcar esos mismos permisos en el TreeView 'trvwPermisoAasociar' (Todos los permisos)
                    var idsPermisosDelRol = rolConPermisos.Permisos.Select(p => p.Id).ToList();
                    MarcarPermisosEnTreeView(trvwPermisoAasociar.Nodes, idsPermisosDelRol);
                }

                // Habilitar/Deshabilitar botones si es el rol Admin
                bool esAdmin = rolSeleccionado.Nombre.Equals("Administrador", StringComparison.OrdinalIgnoreCase);
                btnAsociarPermisoArol.Enabled = !esAdmin;
                btnDesasociarPermisoArol.Enabled = !esAdmin;
                btnAsociarPermisosMarcados.Enabled = !esAdmin;
                if (esAdmin) trViewPermisoRol.Nodes.Insert(0, new TreeNode("PERMISOS DE ADMIN NO MODIFICABLES"));
            }
            else
            {
                // Deshabilitar botones si no hay rol seleccionado
                btnAsociarPermisoArol.Enabled = false;
                btnDesasociarPermisoArol.Enabled = false;
                btnAsociarPermisosMarcados.Enabled = false;
            }
        }

        // Marca (Check) los nodos en el 'trvwPermisoAasociar'
        private void MarcarPermisosEnTreeView(TreeNodeCollection nodos, List<int> idsPermisos)
        {
            foreach (TreeNode nodo in nodos)
            {
                if (nodo.Tag is BEPermisoComponent permiso)
                {
                    nodo.Checked = idsPermisos.Contains(permiso.Id);
                }
                // Recursivo (aunque con lista plana no es estrictamente necesario, es buena práctica)
                if (nodo.Nodes.Count > 0)
                {
                    MarcarPermisosEnTreeView(nodo.Nodes, idsPermisos);
                }
            }
        }

        // Desmarca todos los nodos
        private void MarcarNodosRecursivo(TreeNodeCollection nodos, bool check)
        {
            foreach (TreeNode nodo in nodos)
            {
                nodo.Checked = check;
                if (nodo.Nodes.Count > 0) MarcarNodosRecursivo(nodo.Nodes, check);
            }
        }


        // Botón ">" (Asociar 1 permiso seleccionado)
        private void btnAsociarPermisoArol_Click(object sender, EventArgs e)
        {
            if (cbRolParaAsociarApermiso.SelectedItem is BERol rolSeleccionado && rolSeleccionado.Id != 0 &&
                trvwPermisoAasociar.SelectedNode?.Tag is BEPermisoComponent permisoSeleccionado)
            {
                if (rolSeleccionado.Nombre.Equals("Administrador", StringComparison.OrdinalIgnoreCase)) return;

                try
                {
                    // Obtiene los permisos que ya tiene el rol
                    var permisosActuales = bllSeguridad.ObtenerRolConPermisos(rolSeleccionado.Id).Permisos;

                    // Verifica si ya lo tiene
                    if (permisosActuales.Any(p => p.Id == permisoSeleccionado.Id))
                    {
                        MessageBox.Show("El rol ya tiene este permiso asignado.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }

                    // Agrega el nuevo permiso a la lista
                    permisosActuales.Add(permisoSeleccionado as BEPermiso); // Asume que solo son BEPermiso

                    // Guarda la lista COMPLETA de permisos (los viejos + el nuevo)
                    bllSeguridad.AsignarPermisosARol(rolSeleccionado.Id, permisosActuales.Cast<BEPermisoComponent>().ToList());

                    MessageBox.Show("Permiso asociado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Recargar vistas
                    CargarTreeViewPermisosDelRol(rolSeleccionado.Id); // Actualiza la lista de la derecha
                    trvwPermisoAasociar.SelectedNode.Checked = true; // Marca el nodo en la lista de la izquierda
                    MostrarRolesYPermisosDeTodosLosUsuarios(); // Actualiza la vista general de abajo
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

        // Botón "Desasociar" (Quitar 1 permiso seleccionado DE LA LISTA DERECHA)
        private void btnDesasociarPermisoArol_Click(object sender, EventArgs e)
        {
            if (cbRolParaAsociarApermiso.SelectedItem is BERol rolSeleccionado && rolSeleccionado.Id != 0 &&
               trViewPermisoRol.SelectedNode?.Tag is BEPermisoComponent permisoAQuitar)
            {
                if (rolSeleccionado.Nombre.Equals("Administrador", StringComparison.OrdinalIgnoreCase)) return;

                try
                {
                    var permisosActuales = bllSeguridad.ObtenerRolConPermisos(rolSeleccionado.Id).Permisos;

                    // Busca el permiso en la lista actual por ID
                    var permisoEncontrado = permisosActuales.FirstOrDefault(p => p.Id == permisoAQuitar.Id);
                    if (permisoEncontrado == null)
                    {
                        MessageBox.Show("El rol no tiene este permiso (o ya fue quitado).", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }

                    // Quita el permiso de la lista
                    permisosActuales.Remove(permisoEncontrado);

                    // Guarda la lista actualizada (sin el permiso)
                    bllSeguridad.AsignarPermisosARol(rolSeleccionado.Id, permisosActuales.Cast<BEPermisoComponent>().ToList());

                    MessageBox.Show("Permiso desasociado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Recargar vistas
                    CargarTreeViewPermisosDelRol(rolSeleccionado.Id); // Actualiza la lista de la derecha
                                                                      // Desmarca el nodo en la lista de la izquierda
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


        // Botón "Asociar Múltiples Permisos Marcados"
        private void btnAsociarPermisosMarcados_Click(object sender, EventArgs e)
        {
            if (cbRolParaAsociarApermiso.SelectedItem is BERol rolSeleccionado && rolSeleccionado.Id != 0)
            {
                if (rolSeleccionado.Nombre.Equals("Administrador", StringComparison.OrdinalIgnoreCase)) return;

                try
                {
                    // Recolecta todos los permisos marcados (checked) en el TreeView 'trvwPermisoAasociar'
                    List<BEPermisoComponent> permisosMarcados = ObtenerPermisosSeleccionados(trvwPermisoAasociar.Nodes);

                    // Guarda esta lista (sobrescribe los permisos anteriores del rol)
                    bllSeguridad.AsignarPermisosARol(rolSeleccionado.Id, permisosMarcados);

                    MessageBox.Show("Permisos guardados para el rol (basado en las marcas).", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Recargar vistas
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

        // Función auxiliar para recolectar permisos marcados
        private List<BEPermisoComponent> ObtenerPermisosSeleccionados(TreeNodeCollection nodos)
        {
            var lista = new List<BEPermisoComponent>();
            foreach (TreeNode nodo in nodos)
            {
                // Si el nodo está marcado y tiene un permiso
                if (nodo.Checked && nodo.Tag is BEPermisoComponent permiso)
                {
                    lista.Add(permiso);
                }
                // Búsqueda recursiva (aunque en este diseño es plana, es bueno tenerla)
                if (nodo.Nodes.Count > 0)
                {
                    lista.AddRange(ObtenerPermisosSeleccionados(nodo.Nodes));
                }
            }
            return lista;
        }


        #endregion

        #region Lógica Asignación Usuario <-> Rol

        private void btnAsociarUsuarioArol_Click(object sender, EventArgs e)
        {
            if (cmbUsuarioAasociarRol.SelectedItem is BEUsuario usuario && usuario.Id != 0 &&
                cmbRolAasociarAusuario.SelectedItem is BERol rol && rol.Id != 0)
            {
                try
                {
                    // Validar si ya lo tiene (la BLL también lo hace, pero es bueno chequear antes)
                    var rolesActuales = bllSeguridad.ObtenerRolesDeUsuario(usuario.Id);
                    if (rolesActuales.Any(r => r.Id == rol.Id))
                    {
                        MessageBox.Show("El usuario ya tiene ese rol asignado.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }

                    bllSeguridad.AsignarRolAUsuario(usuario.Id, rol.Id);
                    MessageBox.Show("Rol asociado al usuario correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Actualizar la vista general
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

        private void btnDesasociarUsuarioArol_Click(object sender, EventArgs e)
        {
            if (cmbUsuarioAasociarRol.SelectedItem is BEUsuario usuario && usuario.Id != 0 &&
                cmbRolAasociarAusuario.SelectedItem is BERol rol && rol.Id != 0)
            {
                try
                {
                    // Validar si realmente tiene ese rol
                    var rolesActuales = bllSeguridad.ObtenerRolesDeUsuario(usuario.Id);
                    if (!rolesActuales.Any(r => r.Id == rol.Id))
                    {
                        MessageBox.Show("El usuario no tiene ese rol asignado.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }

                    bllSeguridad.QuitarRolDeUsuario(usuario.Id, rol.Id);
                    MessageBox.Show("Rol desasociado del usuario correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Actualizar la vista general
                    MostrarRolesYPermisosDeTodosLosUsuarios();
                }
                catch (InvalidOperationException exInv) // Captura reglas (ej. quitar admin a admin)
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

        // Métodos de evento vacíos (dejados por si el diseñador los conecta)
        private void trViewPermisoRol_AfterSelect(object sender, TreeViewEventArgs e) { }
        private void cmbRolAasociarAusuario_SelectedIndexChanged(object sender, EventArgs e) { }
        private void trvRolesyPermisosPorUsuario_AfterSelect(object sender, TreeViewEventArgs e) { }
        private void cmbUsuarioAasociarRol_SelectedIndexChanged(object sender, EventArgs e) { }


    }
}
