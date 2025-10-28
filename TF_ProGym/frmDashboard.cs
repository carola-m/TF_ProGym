using BE;
using BLL;
using System.Data;
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
        private readonly BLLActividad bllActividad = new BLLActividad();

        public frmDashboard()
        {
            InitializeComponent();
        }

        private void frmDashboard_Load(object sender, EventArgs e)
        {
            // Configurar fechas por defecto (ej. último mes)
            // Asegúrate que los controles dtpDesde y dtpHasta existan en tu diseño
            dtpDesde.Value = DateTime.Today.AddMonths(-1);
            dtpHasta.Value = DateTime.Today;
            // Cargar datos al abrir
            CargarDashboard();
        }

        private void btnActualizarDashboard_Click(object sender, EventArgs e)
        {
            // Asegúrate que el botón btnActualizarDashboard exista en tu diseño
            CargarDashboard();
        }

        private void CargarDashboard()
        {
            // Validar rango de fechas
            if (dtpDesde.Value.Date > dtpHasta.Value.Date)
            {
                MessageBox.Show("La fecha 'Desde' no puede ser posterior a la fecha 'Hasta'.", "Rango Inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DateTime desde = dtpDesde.Value.Date;
            // Ajustar 'hasta' para incluir todo el día
            DateTime hasta = dtpHasta.Value.Date.AddDays(1).AddTicks(-1);

            try
            {
                // Cargar KPIs primero
                CargarKPIs(desde, hasta);

                // Luego cargar gráficos y grillas
                CargarGraficoOcupacion(desde, hasta);
                CargarGraficoIngresos(desde, hasta); // Considerar si 'Ingresos' o 'Liquidaciones' es el término correcto
                CargarGridClientesFrecuentes(desde, hasta);
                CargarGraficoRendimientoProfesionales(desde, hasta);
            }
            catch (Exception ex)
            {
                // Mostrar un mensaje de error general si algo falla al cargar
                MessageBox.Show("Error general al actualizar el dashboard: " + ex.Message, "Error de Carga", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // --- Cargar KPIs (Indicadores Clave) ---
        private void CargarKPIs(DateTime desde, DateTime hasta)
        {
            try
            {
                // Total Clientes Activos (según MembresiaActiva)
                // Asumiendo que BLLCliente.Listar() devuelve todos
                int clientesActivos = bllCliente.Listar().Count(c => c.MembresiaActiva);
                lblKPIClientesActivos.Text = clientesActivos.ToString();

                // Total Profesionales Activos
                // Asumiendo que BLLProfesional.Listar() devuelve activos o que no hay flag de activo
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
                // Poner texto de error en labels
                lblKPIClientesActivos.Text = "Err";
                lblKPIProfesionalesActivos.Text = "Err";
                lblKPIAsistenciasPeriodo.Text = "Err";
                lblKPITotalLiquidado.Text = "Err";
            }
        }


        private void CargarGraficoOcupacion(DateTime desde, DateTime hasta)
        {
            // --- ¡CORRECCIÓN APLICADA! ---
            if (this.chartOcupacion == null)
            {
                MessageBox.Show("Error crítico: El control 'chartOcupacion' no existe en el diseño.", "Error de Diseño", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            // --- FIN CORRECCIÓN ---

            try // Envolver en try-catch específico para este gráfico
            {
                // Obtener datos de turnos
                var turnosPeriodo = bllTurno.ListarTurnosPorPeriodo(desde, hasta);
                var actividadesDict = bllActividad.Listar().ToDictionary(act => act.Id);

                // Agrupar por Actividad
                var ocupacionPorActividad = turnosPeriodo
                    .Where(t => t.IdActividad > 0 && actividadesDict.ContainsKey(t.IdActividad))
                    .Select(t => new { Turno = t, ActividadInfo = actividadesDict[t.IdActividad] })
                    .GroupBy(t => t.ActividadInfo.Nombre)
                    .Select(g => new
                    {
                        Actividad = g.Key,
                        TotalCuposOfrecidos = g.Sum(t => t.ActividadInfo.CupoMaximo),
                        // *** CORREGIDO: Usar IdClientesInscritos ***
                        TotalOcupados = g.Sum(t => t.Turno.IdClientesInscritos?.Count ?? 0)
                    })
                    .Where(x => x.TotalCuposOfrecidos > 0)
                    .Select(x => new
                    {
                        x.Actividad,
                        OcupacionPorcentaje = ((double)x.TotalOcupados / x.TotalCuposOfrecidos) * 100
                    })
                    .OrderByDescending(x => x.OcupacionPorcentaje)
                    .ToList();

                // Limpiar gráfico antes de dibujar
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

                // Crear y configurar la serie
                var serieOcupacion = new Series("Ocupacion")
                {
                    ChartType = SeriesChartType.Bar, // Barras Horizontales
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
                    dp.Color = dato.OcupacionPorcentaje > 90 ? Color.FromArgb(255, 100, 100)
                             : dato.OcupacionPorcentaje > 75 ? Color.FromArgb(255, 180, 80)
                             : dato.OcupacionPorcentaje > 50 ? Color.FromArgb(255, 230, 100)
                             : Color.FromArgb(100, 200, 100);
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

        private void CargarGraficoIngresos(DateTime desde, DateTime hasta)
        {
            // --- ¡CORRECCIÓN APLICADA! ---
            if (this.chartIngresos == null)
            {
                MessageBox.Show("Error crítico: El control 'chartIngresos' no existe en el diseño.", "Error de Diseño", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            // --- FIN CORRECCIÓN ---

            try
            {
                var liquidacionesPeriodo = bllLiquidacion.Buscar(null, desde.Date, hasta.Date);

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

                // Configurar Ejes y Título
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

                // Crear y configurar la serie
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

                // Añadir datos
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


        private void CargarGridClientesFrecuentes(DateTime desde, DateTime hasta)
        {
            // --- Comprobación del control DataGridView ---
            if (this.dgvClientesFrecuentes == null)
            {
                MessageBox.Show("Error crítico: El control 'dgvClientesFrecuentes' no existe en el diseño.", "Error de Diseño", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            // --- Fin Comprobación ---

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
                        NombreCliente = clientesDict.ContainsKey(g.Key) ? $"{clientesDict[g.Key].Apellido}, {clientesDict[g.Key].Nombre}" : $"ID: {g.Key}",
                        CantidadAsistencias = g.Count()
                    })
                    .OrderByDescending(x => x.CantidadAsistencias)
                    .Take(10)
                    .ToList();

                // Asignar datos a la grilla
                dgvClientesFrecuentes.DataSource = null;
                dgvClientesFrecuentes.AutoGenerateColumns = false; // Controlar columnas manualmente
                dgvClientesFrecuentes.Columns.Clear();

                // Añadir columnas manualmente
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

                dgvClientesFrecuentes.DataSource = topClientes; // Asignar datos después de definir columnas


                // Estilos generales de la grilla
                dgvClientesFrecuentes.ReadOnly = true;
                dgvClientesFrecuentes.AllowUserToAddRows = false;
                dgvClientesFrecuentes.AllowUserToDeleteRows = false;
                dgvClientesFrecuentes.RowHeadersVisible = false;
                dgvClientesFrecuentes.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dgvClientesFrecuentes.MultiSelect = false;
                dgvClientesFrecuentes.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
                dgvClientesFrecuentes.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(240, 240, 240);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error cargando clientes frecuentes: " + ex.Message, "Error Grilla", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                if (this.dgvClientesFrecuentes != null) dgvClientesFrecuentes.DataSource = null;
            }
        }


        private void CargarGraficoRendimientoProfesionales(DateTime desde, DateTime hasta)
        {
            if (this.chartRendimientoProf == null)
            {
                MessageBox.Show("Error crítico: El control 'chartRendimientoProf' no existe en el diseño.", "Error de Diseño", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
  
            try
            {
                var liquidacionesPeriodo = bllLiquidacion.Buscar(null, desde.Date, hasta.Date);
                var profesionalesDict = bllProfesional.Listar().ToDictionary(p => p.Id);

                // Agrupar liquidaciones por profesional y calcular métricas
                var rendimiento = liquidacionesPeriodo
                    .GroupBy(l => l.IdProfesional)
                    .Select(g => new
                    {
                        IdProfesional = g.Key,
                        NombreProfesional = profesionalesDict.ContainsKey(g.Key) ? $"{profesionalesDict[g.Key].Apellido}, {profesionalesDict[g.Key].Nombre}" : $"ID: {g.Key}",
                        MontoTotalGenerado = g.Sum(l => l.MontoTotal),
                        // *** CORREGIDO: Usar ?? new List<BETurno>() para manejar null si TurnosLiquidados puede serlo ***
                        // *** NOTA: Asegúrate que BELiquidacion.TurnosLiquidados sea realmente List<BETurno> ***
                       // TurnosDictados = g.SelectMany(l => l.TurnosLiquidados ?? new List<BETurno>()).Distinct().Count()
                    })
                    .OrderByDescending(x => x.MontoTotalGenerado)
                    .ToList();

                // Limpiar gráfico
                chartRendimientoProf.Series.Clear();
                chartRendimientoProf.Titles.Clear();
                chartRendimientoProf.Legends.Clear();

                // Configurar Ejes y Título
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

                // Crear Series
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
                    Color = Color.FromArgb(255, 128, 0),
                    IsValueShownAsLabel = true,
                    LabelFormat = "N0",
                    ToolTip = "#VALY Turnos"
                };

                // Añadir datos
                foreach (var dato in rendimiento)
                {
                    serieMonto.Points.AddXY(dato.NombreProfesional, (double)dato.MontoTotalGenerado);
                    serieTurnos.Points.AddXY(dato.NombreProfesional);
                }

                // Añadir series y leyenda
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
