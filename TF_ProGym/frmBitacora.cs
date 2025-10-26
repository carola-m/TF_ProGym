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
    public partial class frmBitacora : Form
    {
        private BLLBitacora bllBitacora = new BLLBitacora();
        private List<BEBitacora> _listaCompleta; // Cache de la lista completa

        public frmBitacora()
        {
            InitializeComponent();
        }

        private void frmBitacora_Load(object sender, EventArgs e)
        {
            // Configurar DGV
            dgvBitacora.AutoGenerateColumns = false; // Manual
            ConfigurarColumnasDGV();
            dgvBitacora.ReadOnly = true;
            dgvBitacora.AllowUserToAddRows = false;
            dgvBitacora.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            // Configurar fechas
            dtpDesde.Value = DateTime.Today.AddMonths(-1); // Último mes
            dtpHasta.Value = DateTime.Today;

            CargarListaCompletaYFiltrar();
        }

        private void ConfigurarColumnasDGV()
        {
            dgvBitacora.Columns.Clear();
            dgvBitacora.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colId",
                DataPropertyName = "Id",
                HeaderText = "ID",
                Width = 50
            });
            dgvBitacora.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colFecha",
                DataPropertyName = "FechaRegistro",
                HeaderText = "Fecha y Hora",
                DefaultCellStyle = new DataGridViewCellStyle { Format = "dd/MM/yyyy HH:mm:ss" },
                Width = 150
            });
            dgvBitacora.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colDetalle",
                DataPropertyName = "Detalle",
                HeaderText = "Evento",
                Width = 100
            });
            dgvBitacora.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colUsuario",
                DataPropertyName = "NombreUsuario",
                HeaderText = "Usuario",
                Width = 120
            });
            dgvBitacora.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colArchivo",
                DataPropertyName = "NombreArchivo",
                HeaderText = "Archivo/Carpeta",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill // Ocupa el resto
            });
        }


        private void CargarListaCompletaYFiltrar()
        {
            try
            {
                _listaCompleta = bllBitacora.Listar(); // Carga la lista completa desde BLL
                AplicarFiltros(); // Aplica los filtros seleccionados
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar la bitácora: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                _listaCompleta = new List<BEBitacora>(); // Asigna lista vacía en caso de error
                dgvBitacora.DataSource = null;
            }
        }

        private void AplicarFiltros()
        {
            if (_listaCompleta == null) return; // No hacer nada si la lista no se cargó

            IEnumerable<BEBitacora> listaFiltrada = _listaCompleta; // Empezar con la lista completa

            // 1. Filtrar por Tipo de Evento (RadioButtons)
            if (rbBackups.Checked)
            {
                listaFiltrada = listaFiltrada.Where(b => b.Detalle != null && b.Detalle.Equals("Backup", StringComparison.OrdinalIgnoreCase));
            }
            else if (rbRestores.Checked)
            {
                listaFiltrada = listaFiltrada.Where(b => b.Detalle != null && b.Detalle.Equals("Restore", StringComparison.OrdinalIgnoreCase));
            }
            // Si rbTodos está chequeado, no se aplica filtro de detalle

            // 2. Filtrar por Rango de Fechas
            DateTime fechaDesde = dtpDesde.Value.Date; // Inicio del día
            DateTime fechaHasta = dtpHasta.Value.Date.AddDays(1).AddTicks(-1); // Fin del día

            listaFiltrada = listaFiltrada.Where(b => b.FechaRegistro >= fechaDesde && b.FechaRegistro <= fechaHasta);

            // Asignar resultado al DataGridView
            dgvBitacora.DataSource = null;
            dgvBitacora.DataSource = listaFiltrada.ToList(); // Convertir a Lista para enlazar
        }


        // Evento Click del botón Filtrar (que ahora se llama Recargar en el Designer)
        // Renombraremos el botón en el Designer a btnFiltrar (como puse en el Designer)
        // O si prefieres "Recargar", cambia el nombre del método aquí y en el Designer
        private void btnFiltrar_Click(object sender, EventArgs e)
        {
            // Solo aplica los filtros sobre la lista ya cargada en memoria
            AplicarFiltros();
        }

        // Evento Click del botón Recargar
        private void btnRecargar_Click(object sender, EventArgs e)
        {
            // Vuelve a cargar TODO desde el archivo XML y aplica filtros
            CargarListaCompletaYFiltrar();
        }
    }
}
