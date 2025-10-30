using BE;
using MPP;
using System;
using System.Collections.Generic;
using System.Linq;
// --- INICIO PDF ---
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;
using System.Diagnostics; // Para Process.Start
// --- FIN PDF ---

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

            // Asumimos que BLLTurno.Listar... ya trae Actividad y Profesional cargado
            var turnosDictados = bllTurno.ListarTurnosPorProfesionalYPeriodo(idProfesional, inicioPeriodo, finPeriodo);

            // Filtramos turnos que ya ocurrieron
            turnosDictados = turnosDictados.Where(t => t.FechaHoraInicio <= DateTime.Now).ToList();


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
                    // Intenta recargar la actividad si falta
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
                    else
                    {
                        Console.WriteLine($"Profesional {prof.Nombre} {prof.Apellido} no tuvo turnos en el período.");
                    }
                }
                catch (Exception ex)
                {
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
            // BLL llama a MPP, MPP carga el Profesional.
            return mppLiquidacion.Buscar(idProfesional, desde, hasta);
        }


        // --- Generación de PDF (DESCOMENTADO) ---
        public string EmitirLiquidacionPDF(int idLiquidacion)
        {
            var liquidacion = BuscarPorId(idLiquidacion);
            if (liquidacion == null) throw new KeyNotFoundException("Liquidación no encontrada.");
            if (liquidacion.Profesional == null) throw new InvalidOperationException("Faltan datos del profesional en la liquidación.");

            string carpetaReportes = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "LiquidacionesPDF");
            Directory.CreateDirectory(carpetaReportes);

            string nombreArchivo = $"Liquidacion_{liquidacion.Profesional.Apellido}_{liquidacion.Profesional.Nombre}_{liquidacion.PeriodoDesde:yyyyMMdd}_{liquidacion.PeriodoHasta:yyyyMMdd}.pdf";
            string rutaCompleta = Path.Combine(carpetaReportes, nombreArchivo);

            try
            {
                using (FileStream fs = new FileStream(rutaCompleta, FileMode.Create))
                {
                    Document doc = new Document(PageSize.A4, 30, 30, 30, 30);
                    PdfWriter writer = PdfWriter.GetInstance(doc, fs);
                    doc.Open();

                    // --- Contenido del PDF ---
                    Font tituloFont = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 16);
                    Font subtituloFont = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 12);
                    Font normalFont = FontFactory.GetFont(FontFactory.HELVETICA, 10);
                    Font boldFont = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 10);

                    // Encabezado
                    Paragraph titulo = new Paragraph("Liquidación de Honorarios", tituloFont) { Alignment = Element.ALIGN_CENTER };
                    doc.Add(titulo);
                    doc.Add(Chunk.NEWLINE);

                    doc.Add(new Paragraph($"Período: {liquidacion.PeriodoDesde:dd/MM/yyyy} - {liquidacion.PeriodoHasta:dd/MM/yyyy}", subtituloFont));
                    doc.Add(new Paragraph($"Fecha Emisión: {liquidacion.FechaEmision:dd/MM/yyyy HH:mm}", normalFont));
                    doc.Add(Chunk.NEWLINE);

                    doc.Add(new Paragraph("Datos del Profesional:", subtituloFont));
                    doc.Add(new Paragraph($"Nombre: {liquidacion.Profesional.Nombre} {liquidacion.Profesional.Apellido}", normalFont));
                    doc.Add(new Paragraph($"DNI: {liquidacion.Profesional.DNI}", normalFont));
                    doc.Add(new Paragraph($"Especialidad: {liquidacion.Profesional.Especialidad}", normalFont));
                    doc.Add(Chunk.NEWLINE);

                    // Detalle de Turnos
                    doc.Add(new Paragraph("Detalle de Turnos Dictados:", subtituloFont));
                    if (liquidacion.TurnosLiquidados.Any())
                    {
                        PdfPTable tabla = new PdfPTable(3); // Fecha, Actividad, Valor
                        tabla.WidthPercentage = 100;
                        tabla.SetWidths(new float[] { 30f, 50f, 20f });

                        // Encabezados tabla
                        tabla.AddCell(new Phrase("Fecha y Hora", boldFont));
                        tabla.AddCell(new Phrase("Actividad", boldFont));

                        PdfPCell headerCell = new PdfPCell(new Phrase("Valor", boldFont));
                        headerCell.HorizontalAlignment = Element.ALIGN_RIGHT; // Alinea la CELDA
                        tabla.AddCell(headerCell);
    

                        // Filas tabla
                        foreach (var turnoLiq in liquidacion.TurnosLiquidados.OrderBy(t => t.FechaHora))
                        {
                            tabla.AddCell(new Phrase(turnoLiq.FechaHora.ToString("g"), normalFont));
                            tabla.AddCell(new Phrase(turnoLiq.NombreActividad, normalFont));

    
                            PdfPCell dataCell = new PdfPCell(new Phrase(turnoLiq.ValorTurno.ToString("C2"), normalFont));
                            dataCell.HorizontalAlignment = Element.ALIGN_RIGHT; // Alinea la CELDA
                            tabla.AddCell(dataCell);
         
                        }
                        doc.Add(tabla);
                    }
                    else
                    {
                        doc.Add(new Paragraph("No se registraron turnos dictados en este período.", normalFont));
                    }
                    doc.Add(Chunk.NEWLINE);

                    // Total
                    Paragraph total = new Paragraph($"Monto Total a Pagar: {liquidacion.MontoTotal:C2}", subtituloFont) { Alignment = Element.ALIGN_RIGHT };
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