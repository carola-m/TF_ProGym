using BE;
using MPP;
using iTextSharp.text;
using iTextSharp.text.pdf;


namespace BLL
{
    public class BLLLiquidacion
    {
        private readonly MPPLiquidacion mppLiquidacion;
        private readonly BLLTurno bllTurno;
        private readonly BLLActividad bllActividad;
        private readonly BLLProfesional bllProfesional;

        public BLLLiquidacion()
        {
            mppLiquidacion = new MPPLiquidacion();
            bllTurno = new BLLTurno();
            bllActividad = new BLLActividad();
            bllProfesional = new BLLProfesional();
        }

        public BELiquidacion CalcularLiquidacion(int idProfesional, DateTime periodoDesde, DateTime periodoHasta)
        {
            var profesional = bllProfesional.BuscarPorId(idProfesional);
            if (profesional == null) throw new KeyNotFoundException("Profesional no encontrado.");

            DateTime inicioPeriodo = periodoDesde.Date;
            DateTime finPeriodo = periodoHasta.Date.AddDays(1).AddTicks(-1);

            var turnosDictados = bllTurno.ListarTurnosPorProfesionalYPeriodo(idProfesional, inicioPeriodo, finPeriodo)
                                        .Where(t => t.FechaHoraInicio <= DateTime.Now)
                                        .ToList();

            if (!turnosDictados.Any())
            {
                return new BELiquidacion
                {
                    IdProfesional = idProfesional,
                    Profesional = profesional,
                    PeriodoDesde = inicioPeriodo,
                    PeriodoHasta = periodoHasta.Date,
                    MontoTotal = 0,
                    FechaEmision = DateTime.Now,
                    TurnosLiquidados = new List<TurnoLiquidado>()
                };
            }

            var liquidacion = new BELiquidacion
            {
                IdProfesional = idProfesional,
                Profesional = profesional,
                PeriodoDesde = inicioPeriodo,
                PeriodoHasta = periodoHasta.Date,
                FechaEmision = DateTime.Now,
                TurnosLiquidados = new List<TurnoLiquidado>()
            };

            decimal montoTotalCalculado = 0;

            foreach (var turno in turnosDictados)
            {
                if (turno.Actividad == null)
                {
                    turno.Actividad = bllActividad.BuscarPorId(turno.IdActividad);
                }

                if (turno.Actividad != null)
                {
                    decimal valorTurno = turno.Actividad.TarifaPorTurno;
                    montoTotalCalculado += valorTurno;

                    liquidacion.TurnosLiquidados.Add(new TurnoLiquidado
                    {
                        IdTurno = turno.Id,
                        FechaHora = turno.FechaHoraInicio,
                        NombreActividad = turno.Actividad.Nombre,
                        ValorTurno = valorTurno
                    });
                }
                else
                {
                    // Log de advertencia: no se pudo encontrar la actividad
                    Console.WriteLine($"Advertencia: No se encontró la actividad con ID {turno.IdActividad} para el turno {turno.Id}. No se incluirá en la liquidación.");
                }
            }

            liquidacion.MontoTotal = montoTotalCalculado;

            return liquidacion;
        }

        public void GuardarLiquidacionCalculada(BELiquidacion liquidacion)
        {
            if (liquidacion == null) throw new ArgumentNullException("La liquidación no puede ser nula.");
            if (liquidacion.IdProfesional <= 0) throw new ArgumentException("La liquidación debe estar asociada a un profesional.");

            try
            {
                mppLiquidacion.Guardar(liquidacion);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al guardar la liquidación: " + ex.Message);
            }
        }

        public List<BELiquidacion> GenerarYGuardarLiquidacionesPeriodo(DateTime periodoDesde, DateTime periodoHasta)
        {
            var profesionalesActivos = bllProfesional.Listar();
            var liquidacionesGeneradas = new List<BELiquidacion>();

            foreach (var prof in profesionalesActivos)
            {
                try
                {
                    var liq = CalcularLiquidacion(prof.Id, periodoDesde, periodoHasta);

                    if (liq.MontoTotal > 0 || liq.TurnosLiquidados.Any())
                    {
                        GuardarLiquidacionCalculada(liq);
                        liquidacionesGeneradas.Add(liq);
                    }
                }
                catch (Exception ex)
                {
                    // Log de error por profesional
                    Console.WriteLine($"Error al calcular/guardar liquidación para {prof.Nombre} {prof.Apellido}: {ex.Message}");
                }
            }
            return liquidacionesGeneradas;
        }


        public List<BELiquidacion> Listar()
        {
            return mppLiquidacion.Listar();
        }

        public BELiquidacion BuscarPorId(int id)
        {
            return mppLiquidacion.BuscarPorId(id);
        }

        public List<BELiquidacion> Buscar(int? idProfesional = null, DateTime? desde = null, DateTime? hasta = null)
        {
            return mppLiquidacion.Buscar(idProfesional, desde, hasta);
        }


        /// <summary>
        /// Genera un archivo PDF para una liquidación específica.
        /// </summary>
        /// <param name="idLiquidacion">El ID de la liquidación a emitir.</param>
        /// <returns>La ruta completa del archivo PDF generado.</returns>
        public string EmitirLiquidacionPDF(int idLiquidacion)
        {
            var liquidacion = BuscarPorId(idLiquidacion);
            if (liquidacion == null) throw new KeyNotFoundException("Liquidación no encontrada.");
            if (liquidacion.Profesional == null) throw new InvalidOperationException("Faltan datos del profesional en la liquidación.");

            string carpetaReportes = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "LiquidacionesPDF");
            Directory.CreateDirectory(carpetaReportes);

            string nombreArchivo = $"Liquidacion_{liquidacion.Profesional.Apellido}_{liquidacion.PeriodoDesde:yyyyMMdd}.pdf";
            string rutaCompleta = Path.Combine(carpetaReportes, nombreArchivo);

            try
            {
                using (FileStream fs = new FileStream(rutaCompleta, FileMode.Create))
                {
                    Document doc = new Document(PageSize.A4, 30, 30, 30, 30);
                    PdfWriter writer = PdfWriter.GetInstance(doc, fs);
                    doc.Open();

                    // --- Definición de Fuentes ---
                    Font tituloFont = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 18, BaseColor.BLACK);
                    Font subTituloFont = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 14, BaseColor.BLACK);
                    Font boldFont = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 10, BaseColor.BLACK);
                    Font normalFont = FontFactory.GetFont(FontFactory.HELVETICA, 10, BaseColor.BLACK);
                    Font headerTableFont = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 10, BaseColor.WHITE);

                    // --- Encabezado del Documento ---
                    Paragraph tituloApp = new Paragraph("ProGym", tituloFont) { Alignment = Element.ALIGN_LEFT };
                    Paragraph tituloDoc = new Paragraph("Liquidación de Honorarios", subTituloFont) { Alignment = Element.ALIGN_RIGHT };

                    PdfPTable headerTable = new PdfPTable(2) { WidthPercentage = 100 };
                    headerTable.SetWidths(new float[] { 50f, 50f });
                    headerTable.DefaultCell.Border = PdfPCell.NO_BORDER;
                    headerTable.AddCell(tituloApp);
                    headerTable.AddCell(tituloDoc);
                    doc.Add(headerTable);

                    Paragraph fechaEmision = new Paragraph($"Fecha Emisión: {liquidacion.FechaEmision:dd/MM/yyyy HH:mm}", normalFont) { Alignment = Element.ALIGN_RIGHT };
                    doc.Add(fechaEmision);

                    doc.Add(Chunk.NEWLINE);

                    // --- Datos del Profesional ---
                    PdfPTable infoTable = new PdfPTable(2) { WidthPercentage = 100 };
                    infoTable.DefaultCell.Border = PdfPCell.NO_BORDER;
                    infoTable.SetWidths(new float[] { 20f, 80f });

                    infoTable.AddCell(new Phrase("Profesional:", boldFont));
                    infoTable.AddCell(new Phrase($"{liquidacion.Profesional.Nombre} {liquidacion.Profesional.Apellido}", normalFont));
                    infoTable.AddCell(new Phrase("DNI:", boldFont));
                    infoTable.AddCell(new Phrase(liquidacion.Profesional.DNI, normalFont));
                    infoTable.AddCell(new Phrase("Especialidad:", boldFont));
                    infoTable.AddCell(new Phrase(liquidacion.Profesional.Especialidad, normalFont));
                    infoTable.AddCell(new Phrase("Período:", boldFont));
                    infoTable.AddCell(new Phrase($"{liquidacion.PeriodoDesde:dd/MM/yyyy} al {liquidacion.PeriodoHasta:dd/MM/yyyy}", normalFont));
                    doc.Add(infoTable);

                    doc.Add(Chunk.NEWLINE);

                    // --- Línea Separadora ---
                    doc.Add(Chunk.NEWLINE);

                    // --- Detalle de Turnos ---
                    doc.Add(new Paragraph("Detalle de Turnos Dictados", subTituloFont) { SpacingAfter = 10f });

                    if (liquidacion.TurnosLiquidados.Any())
                    {
                        PdfPTable tablaDetalle = new PdfPTable(3);
                        tablaDetalle.WidthPercentage = 100;
                        tablaDetalle.SetWidths(new float[] { 30f, 50f, 20f });

                        // Encabezados de tabla
                        PdfPCell cellFecha = new PdfPCell(new Phrase("Fecha y Hora", headerTableFont)) { BackgroundColor = BaseColor.DARK_GRAY, HorizontalAlignment = Element.ALIGN_CENTER, Padding = 5 };
                        PdfPCell cellAct = new PdfPCell(new Phrase("Actividad", headerTableFont)) { BackgroundColor = BaseColor.DARK_GRAY, HorizontalAlignment = Element.ALIGN_CENTER, Padding = 5 };
                        PdfPCell cellValor = new PdfPCell(new Phrase("Valor", headerTableFont)) { BackgroundColor = BaseColor.DARK_GRAY, HorizontalAlignment = Element.ALIGN_CENTER, Padding = 5 };
                        tablaDetalle.AddCell(cellFecha);
                        tablaDetalle.AddCell(cellAct);
                        tablaDetalle.AddCell(cellValor);

                        // Filas de tabla
                        foreach (var turnoLiq in liquidacion.TurnosLiquidados.OrderBy(t => t.FechaHora))
                        {
                            tablaDetalle.AddCell(new Phrase(turnoLiq.FechaHora.ToString("g"), normalFont) { Leading = 12f });
                            tablaDetalle.AddCell(new Phrase(turnoLiq.NombreActividad, normalFont) { Leading = 12f });

                            PdfPCell cellMonto = new PdfPCell(new Phrase($"${turnoLiq.ValorTurno:N2}", normalFont) { Leading = 12f }); cellMonto.HorizontalAlignment = Element.ALIGN_RIGHT;
                            tablaDetalle.AddCell(cellMonto);
                        }
                        doc.Add(tablaDetalle);
                    }
                    else
                    {
                        doc.Add(new Paragraph("No se registraron turnos dictados en este período.", normalFont));
                    }

                    doc.Add(Chunk.NEWLINE);

                    // --- Total ---
                    Font totalFont = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 14, BaseColor.BLACK);
                    Paragraph total = new Paragraph($"Monto Total a Pagar: ${liquidacion.MontoTotal:N2}", totalFont)
                    {
                        Alignment = Element.ALIGN_RIGHT,
                        SpacingBefore = 15f
                    };
                    doc.Add(total);

                    doc.Close();
                    writer.Close();
                }
                return rutaCompleta; // Devuelve la ruta del archivo generado
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al generar PDF para liquidación {idLiquidacion}: {ex.Message}");
                throw new Exception($"Error al generar el PDF de la liquidación: {ex.Message}");
            }
        }
    }
}