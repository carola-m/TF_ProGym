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
    public partial class frmRestore : Form
    {
        private BLLRestore bllRestore = new BLLRestore();
        private string _rutaBaseBackups; // Ruta a la carpeta /datos/Backups

        public frmRestore()
        {
            InitializeComponent();
            _rutaBaseBackups = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "datos", "Backups");
        }

        private void frmRestore_Load(object sender, EventArgs e)
        {
            CargarBackupsDisponibles();
        }

        private void CargarBackupsDisponibles()
        {
            try
            {
                treeBackups.Nodes.Clear(); // Limpia el árbol

                if (!Directory.Exists(_rutaBaseBackups))
                {
                    MessageBox.Show("La carpeta de Backups no existe. Realice un backup primero.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                // Obtiene solo las carpetas (cada carpeta es un backup)
                var carpetas = Directory.GetDirectories(_rutaBaseBackups);

                if (!carpetas.Any())
                {
                    treeBackups.Nodes.Add("No hay backups disponibles.");
                    return;
                }

                foreach (var carpeta in carpetas)
                {
                    string nombreCarpeta = Path.GetFileName(carpeta); // Ej: "Backup_20251027_193000"
                    TreeNode nodoBackup = new TreeNode(nombreCarpeta);
                    nodoBackup.Tag = carpeta; // Guarda la ruta completa en el Tag

                    // Opcional: Mostrar los archivos XML dentro de cada backup
                    try
                    {
                        var archivos = Directory.GetFiles(carpeta, "*.xml");
                        foreach (var archivo in archivos)
                        {
                            string nombreArchivo = Path.GetFileName(archivo);
                            // No permitir seleccionar archivos hijos, solo la carpeta
                            TreeNode nodoArchivo = new TreeNode(nombreArchivo) { ForeColor = System.Drawing.Color.Gray };
                            nodoBackup.Nodes.Add(nodoArchivo);
                        }
                    }
                    catch (Exception exArchivos)
                    {
                        // No pudo leer los archivos, pero la carpeta existe
                        nodoBackup.Nodes.Add($"Error al leer archivos: {exArchivos.Message}");
                    }

                    treeBackups.Nodes.Add(nodoBackup);
                }
                treeBackups.ExpandAll();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar la lista de backups: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRecargar_Click(object sender, EventArgs e)
        {
            CargarBackupsDisponibles();
        }

        private void btnRestore_Click(object sender, EventArgs e)
        {
            // Asegurarse de que el nodo seleccionado sea un nodo raíz (una carpeta de backup)
            if (treeBackups.SelectedNode == null || treeBackups.SelectedNode.Parent != null)
            {
                MessageBox.Show("Seleccione una carpeta de Backup (un nodo raíz) de la lista.", "Selección requerida", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string nombreBackup = treeBackups.SelectedNode.Text; // El nombre de la carpeta

            // ADVERTENCIA
            DialogResult confirmacion = MessageBox.Show(
                $"¡ADVERTENCIA!\n\nEsto sobrescribirá TODOS los datos actuales con los datos del backup '{nombreBackup}'.\n" +
                "Esta acción NO se puede deshacer.\n\n¿Está seguro que desea continuar?",
                "Confirmar Restore",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Stop, // Ícono de Peligro
                MessageBoxDefaultButton.Button2); // Botón "No" por defecto

            if (confirmacion == DialogResult.Yes)
            {
                try
                {
                    // Llama a la BLL para que haga el trabajo
                    bllRestore.RealizarRestore(nombreBackup);
                    MessageBox.Show("Restore completado con éxito.\n\nLa aplicación se cerrará. Por favor, vuelva a abrirla para ver los datos restaurados.", "Restore Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Forzar el cierre de la aplicación para recargar los datos
                    Application.Exit();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error CRÍTICO al realizar el restore: " + ex.Message, "Error de Restore", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}