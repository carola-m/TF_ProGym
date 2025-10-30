using BE;
using BLL;
using System;
using System.Data;
using System.Drawing; // Para Color
using System.Linq;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting; // Para Chart

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
        private readonly BLLActividad bllActividad = new BLLActividad();

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
            if (dtpDesde.Value.Date > dtpHasta.Value.Date)
            {
                MessageBox.Show("La fecha 'Desde' no puede ser posterior a la fecha 'Hasta'.", "Rango Inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DateTime desde = dtpDesde.Value.Date;
            DateTime hasta = dtpHasta.Value.Date.AddDays(1).AddTicks(-1); // Incluye todo el día

            try
            {
                CargarKPIs(desde, hasta);
                CargarGraficoOcupacion(desde, hasta);
                CargarGraficoIngresos(desde, hasta);
                CargarGridClientesFrecuentes(desde, hasta);
                CargarGraficoRendimientoProfesionales(desde, hasta);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error general al actualizar el dashboard: " + ex.Message, "Error de Carga", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Cargar KPIs (Indicadores Clave)
        private void CargarKPIs(DateTime desde, DateTime hasta)
        {
            // Asegurarse de que los controles Label de KPI existan
            if (lblKPIClientesActivos == null || lblKPIProfesionalesActivos == null || lblKPIAsistenciasPeriodo == null || lblKPITotalLiquidado == null)
            {
                MessageBox.Show("Error de diseño: Faltan controles Label para KPIs.", "Error de Diseño", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                // Total Clientes Activos (según MembresiaActiva)
                int clientesActivos = bllCliente.Listar().Count(c => c.MembresiaActiva);
                lblKPIClientesActivos.Text = clientesActivos.ToString();

                // Total Profesionales
                int profActivos = bllProfesional.Listar().Count();
                lblKPIProfesionalesActivos.Text = profActivos.ToString();

                // Total Asistencias en el Período
                int asistenciasPeriodo = bllAsistencia.Listar()
                                           .Count(a => a.FechaHoraRegistro >= desde && a.FechaHoraRegistro <= hasta && a.Presente);
                lblKPIAsistenciasPeriodo.Text = asistenciasPeriodo.ToString();

                // Total Liquidado a Profesionales en el Período
                decimal totalLiquidado = bllLiquidacion.Buscar(null, desde.Date, hasta.Date)
                                           .Sum(l => l.MontoTotal);
                lblKPITotalLiquidado.Text = totalLiquidado.ToString("C2"); // Formato Moneda
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los KPIs: " + ex.Message, "Error KPIs", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                lblKPIClientesActivos.Text = "Err";
                lblKPIProfesionalesActivos.Text = "Err";
                lblKPIAsistenciasPeriodo.Text = "Err";
                lblKPITotalLiquidado.Text = "Err";
            }
        }

        // Carga el gráfico de % de Ocupación por Actividad
        private void CargarGraficoOcupacion(DateTime desde, DateTime hasta)
        {
            if (this.chartOcupacion == null) return; // Seguridad

            try
            {
                var turnosPeriodo = bllTurno.ListarTurnosPorPeriodo(desde, hasta);
                // El ListarTurnosPorPeriodo ya debería cargar Actividad, si no, se necesita un diccionario
                // var actividadesDict = bllActividad.Listar().ToDictionary(act => act.Id);

                var ocupacionPorActividad = turnosPeriodo
                    .Where(t => t.Actividad != null && t.Actividad.CupoMaximo > 0) // Asegura que Actividad esté cargada y cupo sea válido
                    .GroupBy(t => t.Actividad.Nombre) // Agrupa por nombre
                    .Select(g => new
                    {
                        Actividad = g.Key,
                        TotalCuposOfrecidos = g.Sum(t => t.Actividad.CupoMaximo),
                        TotalOcupados = g.Sum(t => t.CuposOcupados) // Usa la propiedad calculada de BETurno
                    })
                    .Where(x => x.TotalCuposOfrecidos > 0)
                    .Select(x => new
                    {
                        x.Actividad,
                        OcupacionPorcentaje = ((double)x.TotalOcupados / x.TotalCuposOfrecidos) * 100
                    })
                    .OrderByDescending(x => x.OcupacionPorcentaje)
                    .ToList();

                // Limpiar gráfico
                chartOcupacion.Series.Clear();
                chartOcupacion.Titles.Clear();
                chartOcupacion.Legends.Clear();

                // Configurar Ejes y Título
                chartOcupacion.Titles.Add($"Ocupación por Actividad ({desde:dd/MM} - {hasta:dd/MM})");
                ChartArea areaOcupacion = chartOcupacion.ChartAreas[0];
                areaOcupacion.AxisX.Title = "Actividad";
                areaOcupacion.AxisY.Title = "Ocupación (%)";
                areaOcupacion.AxisY.Maximum = 100;
                areaOcupacion.AxisY.Minimum = 0;
                areaOcupacion.AxisX.Interval = 1;
                areaOcupacion.AxisX.LabelStyle.Angle = -30;
                areaOcupacion.AxisY.MajorGrid.LineDashStyle = ChartDashStyle.Dot;

                var serieOcupacion = new Series("Ocupacion")
                {
                    ChartType = SeriesChartType.Bar, // Barras Verticales
                    XValueType = ChartValueType.String,
                    YValueType = ChartValueType.Double,
                    IsValueShownAsLabel = true,
                    LabelFormat = "N1",
                    ToolTip = "#VALY{N1}%"
                };

                // Añadir datos a la serie
                foreach (var dato in ocupacionPorActividad)
                {
                    DataPoint dp = new DataPoint();
                    dp.SetValueXY(dato.Actividad, dato.OcupacionPorcentaje);
                    dp.Color = dato.OcupacionPorcentaje > 90 ? Color.FromArgb(220, 53, 69)  // Rojo
                           : dato.OcupacionPorcentaje > 75 ? Color.FromArgb(255, 193, 7)   // Amarillo
                           : Color.FromArgb(40, 167, 69); // Verde
                    serieOcupacion.Points.Add(dp);
                }

                chartOcupacion.Series.Add(serieOcupacion);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error cargando gráfico de ocupación: " + ex.Message, "Error Gráfico", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                if (this.chartOcupacion != null)
                {
                    chartOcupacion.Series.Clear();
                    chartOcupacion.Titles.Clear();
                    chartOcupacion.Titles.Add("Error al cargar datos");
                }
            }
        }

        // Carga el gráfico de Liquidaciones
        private void CargarGraficoIngresos(DateTime desde, DateTime hasta)
        {
            if (this.chartIngresos == null) return; // Seguridad

            try
            {
                var liquidacionesPeriodo = bllLiquidacion.Buscar(null, desde.Date, hasta.Date);

                // Agrupa por mes
                var ingresosPorMes = liquidacionesPeriodo
                    .GroupBy(l => new { l.PeriodoDesde.Year, l.PeriodoDesde.Month })
                    .Select(g => new
                    {
                        Periodo = new DateTime(g.Key.Year, g.Key.Month, 1),
                        TotalLiquidado = g.Sum(l => l.MontoTotal)
                    })
                    .OrderBy(x => x.Periodo)
                    .ToList();

                // Limpiar gráfico
                chartIngresos.Series.Clear();
                chartIngresos.Titles.Clear();
                chartIngresos.Legends.Clear();

                chartIngresos.Titles.Add($"Total Liquidado por Mes ({desde:MMM yyyy} - {hasta:MMM yyyy})");
                ChartArea areaIngresos = chartIngresos.ChartAreas[0];
                areaIngresos.AxisX.Title = "Mes";
                areaIngresos.AxisY.Title = "Monto Total ($)";
                areaIngresos.AxisX.LabelStyle.Format = "MMM yyyy";
                areaIngresos.AxisX.IntervalType = DateTimeIntervalType.Months;
                areaIngresos.AxisX.Interval = 1;
                areaIngresos.AxisY.LabelStyle.Format = "C0";
                areaIngresos.AxisY.MajorGrid.LineDashStyle = ChartDashStyle.Dot;
                areaIngresos.AxisX.MajorGrid.Enabled = false;

                var serieIngresos = new Series("Total Liquidado")
                {
                    ChartType = SeriesChartType.Line,
                    XValueType = ChartValueType.Date,
                    YValueType = ChartValueType.Double,
                    BorderWidth = 3,
                    MarkerStyle = MarkerStyle.Circle,
                    MarkerSize = 8,
                    IsValueShownAsLabel = true,
                    LabelFormat = "C0",
                    ToolTip = "#VALY{C2}"
                };

                foreach (var dato in ingresosPorMes)
                {
                    serieIngresos.Points.AddXY(dato.Periodo, (double)dato.TotalLiquidado);
                }

                chartIngresos.Series.Add(serieIngresos);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error cargando gráfico de liquidaciones: " + ex.Message, "Error Gráfico", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                if (this.chartIngresos != null)
                {
                    chartIngresos.Series.Clear();
                    chartIngresos.Titles.Clear();
                    chartIngresos.Titles.Add("Error al cargar datos");
                }
            }
        }

        // Carga la grilla de Top 10 Clientes
        private void CargarGridClientesFrecuentes(DateTime desde, DateTime hasta)
        {
            if (this.dgvClientesFrecuentes == null) return; // Seguridad

            try
            {
                var asistenciasPeriodo = bllAsistencia.Listar()
                    .Where(a => a.FechaHoraRegistro >= desde && a.FechaHoraRegistro <= hasta && a.Presente);

                var clientesDict = bllCliente.Listar().ToDictionary(c => c.Id);

                var topClientes = asistenciasPeriodo
                    .GroupBy(a => a.IdCliente)
                    .Select(g => new
                    {
                        IdCliente = g.Key,
                        NombreCliente = clientesDict.ContainsKey(g.Key) ? clientesDict[g.Key].ApellidoNombreDNI : $"ID: {g.Key}", // Usa ApellidoNombreDNI
                        CantidadAsistencias = g.Count()
                    })
                    .OrderByDescending(x => x.CantidadAsistencias)
                    .Take(10)
                    .ToList();

                // Configuración de la grilla
                dgvClientesFrecuentes.DataSource = null;
                dgvClientesFrecuentes.AutoGenerateColumns = false;
                dgvClientesFrecuentes.Columns.Clear();

                dgvClientesFrecuentes.Columns.Add(new DataGridViewTextBoxColumn
                {
                    DataPropertyName = "NombreCliente",
                    HeaderText = "Cliente",
                    Name = "colCliente",
                    AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                });
                dgvClientesFrecuentes.Columns.Add(new DataGridViewTextBoxColumn
                {
                    DataPropertyName = "CantidadAsistencias",
                    HeaderText = "Asistencias",
                    Name = "colAsistencias",
                    AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells,
                    DefaultCellStyle = new DataGridViewCellStyle { Alignment = DataGridViewContentAlignment.MiddleCenter }
                });

                dgvClientesFrecuentes.DataSource = topClientes;

                // Estilos
                dgvClientesFrecuentes.ReadOnly = true;
                dgvClientesFrecuentes.AllowUserToAddRows = false;
                dgvClientesFrecuentes.AllowUserToDeleteRows = false;
                dgvClientesFrecuentes.RowHeadersVisible = false;
                dgvClientesFrecuentes.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error cargando clientes frecuentes: " + ex.Message, "Error Grilla", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                if (this.dgvClientesFrecuentes != null) dgvClientesFrecuentes.DataSource = null;
            }
        }

        // Carga el gráfico de Rendimiento de Profesionales
        private void CargarGraficoRendimientoProfesionales(DateTime desde, DateTime hasta)
        {
            if (this.chartRendimientoProf == null) return; // Seguridad

            try
            {
                var liquidacionesPeriodo = bllLiquidacion.Buscar(null, desde.Date, hasta.Date);
                var profesionalesDict = bllProfesional.Listar().ToDictionary(p => p.Id);

                var rendimiento = liquidacionesPeriodo
                    .GroupBy(l => l.IdProfesional)
                    .Select(g => new
                    {
                        IdProfesional = g.Key,
                        NombreProfesional = profesionalesDict.ContainsKey(g.Key) ? profesionalesDict[g.Key].ApellidoNombre : $"ID: {g.Key}", // Usa ApellidoNombre
                        MontoTotalGenerado = g.Sum(l => l.MontoTotal),
                        TurnosDictados = g.Sum(l => l.TurnosLiquidados?.Count ?? 0) // Suma los turnos
                    })
                    .OrderByDescending(x => x.MontoTotalGenerado)
                    .ToList();

                // Limpiar gráfico
                chartRendimientoProf.Series.Clear();
                chartRendimientoProf.Titles.Clear();
                chartRendimientoProf.Legends.Clear();

                chartRendimientoProf.Titles.Add($"Rendimiento por Profesional ({desde:dd/MM} - {hasta:dd/MM})");
                ChartArea areaRendimiento = chartRendimientoProf.ChartAreas[0];
                areaRendimiento.AxisX.Title = "Profesional";
                areaRendimiento.AxisY.Title = "Monto Liquidado ($)";
                areaRendimiento.AxisY.LabelStyle.Format = "C0";
                areaRendimiento.AxisX.Interval = 1;
                areaRendimiento.AxisX.LabelStyle.Angle = -45;
                areaRendimiento.AxisX.MajorGrid.Enabled = false;
                areaRendimiento.AxisY.MajorGrid.LineDashStyle = ChartDashStyle.Dot;

                // Configurar Eje Y Secundario
                areaRendimiento.AxisY2.Enabled = AxisEnabled.True;
                areaRendimiento.AxisY2.Title = "Turnos Dictados (Cant.)";
                areaRendimiento.AxisY2.MajorGrid.Enabled = false;
                areaRendimiento.AxisY2.Minimum = 0;
                areaRendimiento.AxisY2.IntervalAutoMode = IntervalAutoMode.VariableCount;

                var serieMonto = new Series("Monto Liquidado")
                {
                    ChartType = SeriesChartType.Column,
                    YAxisType = AxisType.Primary,
                    IsValueShownAsLabel = true,
                    LabelFormat = "C0",
                    ToolTip = "#VALY{C2}"
                };
                var serieTurnos = new Series("Turnos Dictados")
                {
                    ChartType = SeriesChartType.Line,
                    YAxisType = AxisType.Secondary,
                    BorderWidth = 3,
                    MarkerStyle = MarkerStyle.Circle,
                    MarkerSize = 7,
                    Color = Color.FromArgb(255, 128, 0), // Naranja oscuro
                    IsValueShownAsLabel = true,
                    LabelFormat = "N0",
                    ToolTip = "#VALY Turnos"
                };

                // Añadir datos
                foreach (var dato in rendimiento)
                {
                    serieMonto.Points.AddXY(dato.NombreProfesional, (double)dato.MontoTotalGenerado);
                    serieTurnos.Points.AddXY(dato.NombreProfesional, dato.TurnosDictados);
                }

                chartRendimientoProf.Series.Add(serieMonto);
                chartRendimientoProf.Series.Add(serieTurnos);
                chartRendimientoProf.Legends.Add(new Legend("DefaultLegend"));
                chartRendimientoProf.Legends["DefaultLegend"].Docking = Docking.Bottom;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error cargando gráfico de rendimiento: " + ex.Message, "Error Gráfico", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                if (this.chartRendimientoProf != null)
                {
                    chartRendimientoProf.Series.Clear();
                    chartRendimientoProf.Titles.Clear();
                    chartRendimientoProf.Titles.Add("Error al cargar datos");
                }
            }
        }
    }
}