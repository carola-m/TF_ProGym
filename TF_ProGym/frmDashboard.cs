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
using System.Windows.Forms.DataVisualization.Charting;

namespace CapaPresentacion
{
    public partial class frmDashboard : Form
    {
        // Instanciar todas las BLL necesarias
        private BLLTurno bllTurno = new BLLTurno();
        private BLLAsistencia bllAsistencia = new BLLAsistencia();
        private BLLLiquidacion bllLiquidacion = new BLLLiquidacion();
        private BLLCliente bllCliente = new BLLCliente();
        private BLLProfesional bllProfesional = new BLLProfesional();

        public frmDashboard()
        {
            InitializeComponent();
        }

        private void frmDashboard_Load(object sender, EventArgs e)
        {
            // Configurar fechas por defecto (ej. último mes)
            dtpDesde.Value = DateTime.Today.AddMonths(-1);
            dtpHasta.Value = DateTime.Today;
            // Cargar datos al abrir
            CargarDashboard();
        }

        private void btnActualizarDashboard_Click(object sender, EventArgs e)
        {
            CargarDashboard();
        }

        private void CargarDashboard()
        {
            DateTime desde = dtpDesde.Value.Date;
            DateTime hasta = dtpHasta.Value.Date; // BLLs ajustarán para incluir todo el día

            try
            {
                CargarGraficoOcupacion(desde, hasta);
                CargarGraficoIngresos(desde, hasta);
                CargarGridClientesFrecuentes(desde, hasta);
                CargarGraficoRendimientoProfesionales(desde, hasta);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al actualizar el dashboard: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CargarGraficoOcupacion(DateTime desde, DateTime hasta)
        {
            var turnosPeriodo = bllTurno.ListarTurnosPorPeriodo(desde, hasta);

            // Agrupar por Actividad
            var ocupacionPorActividad = turnosPeriodo
                                .Where(t => t.Actividad != null) // Solo turnos con actividad válida
                                .GroupBy(t => t.Actividad.Nombre)
                                .Select(g => new {
                                    Actividad = g.Key,
                                    TotalCupos = g.Sum(t => t.Actividad.CupoMaximo),
                                    TotalOcupados = g.Sum(t => t.CuposOcupados)
                                })
                                .Where(x => x.TotalCupos > 0) // Evitar división por cero
                                .Select(x => new {
                                    x.Actividad,
                                    // Calcular porcentaje de ocupación
                                    OcupacionPorcentaje = ((double)x.TotalOcupados / x.TotalCupos) * 100
                                })
                                .OrderByDescending(x => x.OcupacionPorcentaje)
                                .ToList();

            chartOcupacion.Series.Clear();
            chartOcupacion.ChartAreas[0].AxisX.Title = "Actividad";
            chartOcupacion.ChartAreas[0].AxisY.Title = "Ocupación (%)";
            chartOcupacion.ChartAreas[0].AxisY.Maximum = 100;
            chartOcupacion.ChartAreas[0].AxisX.Interval = 1; // Mostrar todas las etiquetas
            chartOcupacion.Legends[0].Enabled = false; // Ocultar leyenda si es una sola serie

            var serieOcupacion = new Series("Ocupacion")
            {
                ChartType = SeriesChartType.Bar, // Gráfico de barras
                XValueType = ChartValueType.String,
                YValueType = ChartValueType.Double,
                IsValueShownAsLabel = true // Mostrar el valor en la barra
            };
            serieOcupacion.LabelFormat = "{0:N1}%"; // Formato del label (1 decimal)

            foreach (var dato in ocupacionPorActividad)
            {
                DataPoint dp = new DataPoint();
                dp.SetValueXY(dato.Actividad, dato.OcupacionPorcentaje);
                dp.Color = dato.OcupacionPorcentaje > 80 ? Color.IndianRed : (dato.OcupacionPorcentaje > 50 ? Color.Gold : Color.SeaGreen); // Colores por %
                dp.ToolTip = $"Ocupación: {dato.OcupacionPorcentaje:N1}%"; // Tooltip al pasar el mouse
                serieOcupacion.Points.Add(dp);
            }
            chartOcupacion.Series.Add(serieOcupacion);
            chartOcupacion.DataBind();
        }

        private void CargarGraficoIngresos(DateTime desde, DateTime hasta)
        {
            // Usaremos las Liquidaciones (pagos a profesionales)
            var liquidacionesPeriodo = bllLiquidacion.Buscar(null, desde, hasta);

            // Agrupar por mes
            var ingresosPorMes = liquidacionesPeriodo
                                .GroupBy(l => new { l.PeriodoDesde.Year, l.PeriodoDesde.Month })
                                .Select(g => new {
                                    Periodo = new DateTime(g.Key.Year, g.Key.Month, 1),
                                    Total = g.Sum(l => l.MontoTotal)
                                })
                                .OrderBy(x => x.Periodo)
                                .ToList();

            chartIngresos.Series.Clear();
            chartIngresos.ChartAreas[0].AxisX.Title = "Mes";
            chartIngresos.ChartAreas[0].AxisY.Title = "Monto Total Liquidado";
            chartIngresos.ChartAreas[0].AxisX.LabelStyle.Format = "MMM yyyy";
            chartIngresos.Legends[0].Enabled = true;

            var serieIngresos = new Series("Liquidado")
            {
                ChartType = SeriesChartType.Column,
                XValueType = ChartValueType.Date,
                YValueType = ChartValueType.Auto,
                LabelFormat = "C0", // Formato moneda sin decimales
                IsValueShownAsLabel = true
            };

            foreach (var dato in ingresosPorMes)
            {
                serieIngresos.Points.AddXY(dato.Periodo, dato.Total);
            }
            chartIngresos.Series.Add(serieIngresos);
            chartIngresos.DataBind();
        }

        private void CargarGridClientesFrecuentes(DateTime desde, DateTime hasta)
        {
            try
            {
                var asistenciasPeriodo = bllAsistencia.Listar()
                                        .Where(a => a.FechaHoraRegistro.Date >= desde && a.FechaHoraRegistro.Date <= hasta && a.Presente);

                var clientes = bllCliente.Listar().ToDictionary(c => c.Id, c => $"{c.Apellido}, {c.Nombre}");

                var topClientes = asistenciasPeriodo
                                .GroupBy(a => a.IdCliente)
                                .Select(g => new {
                                    IdCliente = g.Key,
                                    NombreCliente = clientes.ContainsKey(g.Key) ? clientes[g.Key] : $"ID: {g.Key}",
                                    CantidadAsistencias = g.Count()
                                })
                                .OrderByDescending(x => x.CantidadAsistencias)
                                .Take(10) // Top 10
                                .ToList();

                dgvClientesFrecuentes.DataSource = null;
                dgvClientesFrecuentes.DataSource = topClientes;
                // Configurar columnas (asumiendo AutoGenerateColumns = true para el DGV)
                if (dgvClientesFrecuentes.Columns.Contains("IdCliente")) dgvClientesFrecuentes.Columns["IdCliente"].Visible = false;
                if (dgvClientesFrecuentes.Columns.Contains("NombreCliente")) dgvClientesFrecuentes.Columns["NombreCliente"].HeaderText = "Cliente";
                if (dgvClientesFrecuentes.Columns.Contains("CantidadAsistencias")) dgvClientesFrecuentes.Columns["CantidadAsistencias"].HeaderText = "Asistencias";
                dgvClientesFrecuentes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dgvClientesFrecuentes.ReadOnly = true;
                dgvClientesFrecuentes.AllowUserToAddRows = false;
                dgvClientesFrecuentes.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error cargando clientes frecuentes: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                dgvClientesFrecuentes.DataSource = null;
            }
        }

        private void CargarGraficoRendimientoProfesionales(DateTime desde, DateTime hasta)
        {
            var liquidacionesPeriodo = bllLiquidacion.Buscar(null, desde, hasta);
            var profesionales = bllProfesional.Listar().ToDictionary(p => p.Id, p => $"{p.Apellido}, {p.Nombre}");

            var rendimiento = liquidacionesPeriodo
                             .GroupBy(l => l.IdProfesional)
                             .Select(g => new {
                                 IdProfesional = g.Key,
                                 NombreProfesional = profesionales.ContainsKey(g.Key) ? profesionales[g.Key] : $"ID: {g.Key}",
                                 MontoTotalGenerado = g.Sum(l => l.MontoTotal),
                                 TurnosDictados = g.Sum(l => l.TurnosLiquidados.Count)
                             })
                             .OrderByDescending(x => x.MontoTotalGenerado)
                             .ToList();

            chartRendimientoProf.Series.Clear();
            chartRendimientoProf.ChartAreas[0].AxisX.Title = "Profesional";
            chartRendimientoProf.ChartAreas[0].AxisY.Title = "Monto Liquidado ($)";
            chartRendimientoProf.ChartAreas[0].AxisX.Interval = 1;
            chartRendimientoProf.ChartAreas[0].AxisX.LabelStyle.Angle = -45; // Inclinar etiquetas si son largas
            chartRendimientoProf.Legends[0].Enabled = true;
            chartRendimientoProf.Legends[0].Docking = Docking.Bottom; // Poner leyenda abajo

            // Eje Y secundario para Turnos
            string area = chartRendimientoProf.ChartAreas[0].Name;
            chartRendimientoProf.ChartAreas[area].AxisY2.Enabled = AxisEnabled.True;
            chartRendimientoProf.ChartAreas[area].AxisY2.Title = "Turnos Dictados (Cant.)";
            chartRendimientoProf.ChartAreas[area].AxisY2.MajorGrid.Enabled = false; // Ocultar grilla eje secundario


            var serieMonto = new Series("Monto Liquidado")
            {
                ChartType = SeriesChartType.Column,
                YAxisType = AxisType.Primary
            };
            var serieTurnos = new Series("Turnos Dictados")
            {
                ChartType = SeriesChartType.Line,
                YAxisType = AxisType.Secondary,
                BorderWidth = 3,
                MarkerStyle = MarkerStyle.Circle,
                MarkerSize = 6,
                Color = Color.OrangeRed
            };

            foreach (var dato in rendimiento)
            {
                // Añadir Monto (Columnas)
                int pointIndex = serieMonto.Points.AddXY(dato.NombreProfesional, dato.MontoTotalGenerado);
                serieMonto.Points[pointIndex].LabelFormat = "C0";
                serieMonto.Points[pointIndex].ToolTip = $"{dato.NombreProfesional}: {dato.MontoTotalGenerado:C2}";

                // Añadir Turnos (Línea)
                pointIndex = serieTurnos.Points.AddXY(dato.NombreProfesional, dato.TurnosDictados);
                serieTurnos.Points[pointIndex].Label = dato.TurnosDictados.ToString();
                serieTurnos.Points[pointIndex].ToolTip = $"{dato.NombreProfesional}: {dato.TurnosDictados} turnos";

            }

            chartRendimientoProf.Series.Add(serieMonto);
            chartRendimientoProf.Series.Add(serieTurnos);
            chartRendimientoProf.DataBind();
        }
    }
}