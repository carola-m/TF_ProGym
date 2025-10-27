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
    public partial class frmBackup : Form
    {
        private BLLBackup bllBackup = new BLLBackup();
        private BLLBitacora bllBitacora = new BLLBitacora();

        public frmBackup()
        {
            InitializeComponent();
        }

        private void frmBackup_Load(object sender, EventArgs e)
        {
            // Configurar DGV
            dgvBackups.AutoGenerateColumns = false;
            ConfigurarColumnasDGV();
            dgvBackups.ReadOnly = true;
            dgvBackups.AllowUserToAddRows = false;
            dgvBackups.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            CargarHistorialBackups();
        }

        private void ConfigurarColumnasDGV()
        {
            dgvBackups.Columns.Clear();
            dgvBackups.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colFecha",
                DataPropertyName = "FechaRegistro",
                HeaderText = "Fecha y Hora",
                DefaultCellStyle = new DataGridViewCellStyle { Format = "dd/MM/yyyy HH:mm:ss" },
                Width = 150
            });
            dgvBackups.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colUsuario",
                DataPropertyName = "NombreUsuario",
                HeaderText = "Usuario",
                Width = 120
            });
            dgvBackups.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colArchivo",
                DataPropertyName = "NombreArchivo",
                HeaderText = "Nombre del Backup",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            });
        }

        private void CargarHistorialBackups()
        {
            try
            {
                // Obtenemos la bitácora y filtramos solo los backups exitosos
                var historial = bllBitacora.Listar()
                                .Where(b => b.Detalle != null && b.Detalle.Equals("Backup", StringComparison.OrdinalIgnoreCase))
                                .OrderByDescending(b => b.FechaRegistro)
                                .ToList();

                dgvBackups.DataSource = null;
                dgvBackups.DataSource = historial;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar el historial de backups: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRealizarBackup_Click(object sender, EventArgs e)
        {
            try
            {
                // Llama a la BLL para que haga el trabajo
                string rutaBackup = bllBackup.RealizarBackup();

                MessageBox.Show($"Backup realizado con éxito en:\n{rutaBackup}", "Backup Completado", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Recargar la grilla para mostrar el nuevo registro
                CargarHistorialBackups();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al realizar el backup: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}