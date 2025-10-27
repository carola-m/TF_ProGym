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
    public partial class frmGestionLiquidaciones : Form
    {
        private BLLLiquidacion bllLiquidacion = new BLLLiquidacion();
        private BLLProfesional bllProfesional = new BLLProfesional();
        private List<BELiquidacion> _listaActual; // Cache para el PDF

        public frmGestionLiquidaciones()
        {
            InitializeComponent();
        }

        private void frmGestionLiquidaciones_Load(object sender, EventArgs e)
        {
            // Configurar DGV
            dgvLiquidaciones.AutoGenerateColumns = false;
            ConfigurarColumnasDGV();
            dgvLiquidaciones.ReadOnly = true;
            dgvLiquidaciones.AllowUserToAddRows = false;
            dgvLiquidaciones.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            // Configurar fechas
            dtpDesdeCalc.Value = DateTime.Today.AddMonths(-1).Date;
            dtpHastaCalc.Value = DateTime.Today.Date;
            dtpDesde.Value = DateTime.Today.AddMonths(-3).Date; // Ver más historial
            dtpHasta.Value = DateTime.Today.Date;

            CargarComboProfesionales();
            CargarGrilla();
        }

        private void ConfigurarColumnasDGV()
        {
            dgvLiquidaciones.Columns.Clear();
            dgvLiquidaciones.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colId",
                DataPropertyName = "Id",
                HeaderText = "ID",
                Width = 50
            });
            dgvLiquidaciones.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colFechaEmision",
                DataPropertyName = "FechaEmision",
                HeaderText = "Fecha Emisión",
                DefaultCellStyle = new DataGridViewCellStyle { Format = "dd/MM/yyyy" },
                Width = 100
            });
            dgvLiquidaciones.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colProfesional",
                DataPropertyName = "NombreProfesional",
                HeaderText = "Profesional",
                Width = 200
            });
            dgvLiquidaciones.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colPeriodo",
                DataPropertyName = "Periodo",
                HeaderText = "Período Liquidado",
                Width = 150
            });
            dgvLiquidaciones.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colCantTurnos",
                DataPropertyName = "CantidadTurnos",
                HeaderText = "Turnos",
                Width = 60
            });
            dgvLiquidaciones.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colMonto",
                DataPropertyName = "MontoTotal",
                HeaderText = "Monto Total",
                DefaultCellStyle = new DataGridViewCellStyle { Format = "C2" }, // Formato Moneda
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            });
        }

        private void CargarComboProfesionales()
        {
            try
            {
                var lista = bllProfesional.Listar();
                // Añadir "Todos"
                lista.Insert(0, new BEProfesional { Id = 0, Apellido = "[Todos]" });

                cmbProfesionalFiltro.DataSource = null;
                cmbProfesionalFiltro.DataSource = lista;
                cmbProfesionalFiltro.DisplayMember = "ApellidoNombre"; // Usa la propiedad calculada
                cmbProfesionalFiltro.ValueMember = "Id";
                cmbProfesionalFiltro.SelectedIndex = 0; // Seleccionar "Todos"
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar profesionales: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CargarGrilla()
        {
            try
            {
                // Obtener filtros
                int? idProfesional = (int)cmbProfesionalFiltro.SelectedValue;
                if (idProfesional == 0) idProfesional = null; // Si es "Todos", pasa null

                DateTime desde = dtpDesde.Value.Date;
                DateTime hasta = dtpHasta.Value.Date;

                // Buscar
                _listaActual = bllLiquidacion.Buscar(idProfesional, desde, hasta);

                // Preparar datos para la grilla (con propiedades calculadas)
                var dataSource = _listaActual.Select(liq => new {
                    liq.Id,
                    liq.FechaEmision,
                    NombreProfesional = liq.Profesional?.ApellidoNombre ?? $"ID: {liq.IdProfesional}",
                    Periodo = $"{liq.PeriodoDesde:dd/MM/yy} al {liq.PeriodoHasta:dd/MM/yy}",
                    CantidadTurnos = liq.TurnosLiquidados?.Count ?? 0,
                    liq.MontoTotal
                }).ToList();

                dgvLiquidaciones.DataSource = null;
                dgvLiquidaciones.DataSource = dataSource;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar liquidaciones: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            CargarGrilla();
        }

        private void btnCalcularLiquidaciones_Click(object sender, EventArgs e)
        {
            DateTime desde = dtpDesdeCalc.Value.Date;
            DateTime hasta = dtpHastaCalc.Value.Date;

            if (desde > hasta)
            {
                MessageBox.Show("La fecha 'Desde' no puede ser posterior a la fecha 'Hasta'.", "Error de Fechas", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult confirm = MessageBox.Show($"¿Está seguro de generar y guardar las liquidaciones para el período del {desde:dd/MM/yyyy} al {hasta:dd/MM/yyyy}?\n" +
                                                 "Esto calculará los pagos para TODOS los profesionales activos.",
                                                 "Confirmar Cálculo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirm == DialogResult.Yes)
            {
                try
                {
                    // Llamar a BLL para generar TODAS las liquidaciones del período
                    var liquidacionesGeneradas = bllLiquidacion.GenerarYGuardarLiquidacionesPeriodo(desde, hasta);

                    if (liquidacionesGeneradas.Any())
                    {
                        MessageBox.Show($"Se generaron y guardaron {liquidacionesGeneradas.Count} liquidaciones correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("No se generaron liquidaciones. Es posible que no haya habido turnos dictados en ese período.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                    // Recargar la grilla para mostrar los nuevos cálculos
                    CargarGrilla();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al calcular las liquidaciones: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // Evento para el botón de exportar PDF (requiere iTextSharp)
        private void btnExportarPDF_Click(object sender, EventArgs e)
        {
            MessageBox.Show("La funcionalidad de exportar a PDF (con iTextSharp) debe implementarse.\n" +
                            "Descomenta el código en BLLLiquidacion.cs y en este botón, e instala el paquete NuGet 'iTextSharp'.",
                            "Funcionalidad Pendiente", MessageBoxButtons.OK, MessageBoxIcon.Information);

            /*
            // --- CÓDIGO EJEMPLO iTextSharp (DESCOMENTAR CUANDO ESTÉ INSTALADO) ---
            if (dgvLiquidaciones.CurrentRow == null || dgvLiquidaciones.CurrentRow.DataBoundItem == null)
            {
                 MessageBox.Show("Seleccione una liquidación de la grilla para exportar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                 return;
            }

            try
            {
                 // Obtener el ID del objeto anónimo
                 int idLiquidacion = (int)dgvLiquidaciones.CurrentRow.Cells["colId"].Value;
                 
                 // Llamar a la BLL para generar el PDF
                 string rutaPDF = bllLiquidacion.EmitirLiquidacionPDF(idLiquidacion); // Asume que BLL lo implementa

                 MessageBox.Show($"PDF generado correctamente en:\n{rutaPDF}", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                 
                 // Abrir el PDF
                 System.Diagnostics.Process.Start(rutaPDF);
            }
            catch(Exception ex)
            {
                 MessageBox.Show("Error al generar el PDF: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            */
        }
    }
}