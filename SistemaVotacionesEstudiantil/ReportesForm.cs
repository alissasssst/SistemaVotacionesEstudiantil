using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Windows.Forms;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace SistemaVotacionesEstudiantil
{
    public partial class ReportesForm : Form
    {
        public ReportesForm()
        {
            InitializeComponent();
        }

        // ═══════════════════════════════════════════════════════════
        // BOTONES DE VISTA PREVIA (PrintDocument)
        // ═══════════════════════════════════════════════════════════

        private void btnRptGanadora_Click(object sender, EventArgs e)
        {
            ImprimirPlanchaGanadora(ObtenerEstadisticasPlanchas());
        }

        private void btnRptIntegrantes_Click(object sender, EventArgs e)
        {
            ImprimirIntegrantes(ObtenerIntegrantes(), "Todas las Planchas");
        }

        private void btnRptVotos_Click(object sender, EventArgs e)
        {
            ImprimirGeneralVotos(ObtenerEstadisticasPlanchas(), 80, 10, 100);
        }

        private void btnRptParticipantes_Click(object sender, EventArgs e)
        {
            ImprimirParticipantes(ObtenerParticipantes());
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // ═══════════════════════════════════════════════════════════
        // EXPORTAR TODO A PDF
        // ═══════════════════════════════════════════════════════════

        private void btnExportarTodo_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog
            {
                Filter = "PDF files (*.pdf)|*.pdf",
                FileName = "ReportesCompletos_" + DateTime.Now.ToString("yyyyMMdd_HHmm") + ".pdf"
            };

            if (sfd.ShowDialog() != DialogResult.OK) return;

            try
            {
                using (FileStream fs = new FileStream(sfd.FileName, FileMode.Create))
                {
                    Document doc = new Document(PageSize.A4, 30, 30, 40, 30);
                    PdfWriter.GetInstance(doc, fs);
                    doc.Open();

                    // ── Portada ──────────────────────────────────────
                    var fPortada = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 22,
                                    new BaseColor(0, 51, 102));
                    var fFecha = FontFactory.GetFont(FontFactory.HELVETICA, 11,
                                    new BaseColor(100, 100, 100));
                    var fSub = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 13,
                                    new BaseColor(0, 51, 102));

                    doc.Add(new Paragraph("\n\n"));
                    var titulo = new Paragraph("SISTEMA DE VOTACIONES ESCOLARES", fPortada);
                    titulo.Alignment = Element.ALIGN_CENTER;
                    doc.Add(titulo);

                    doc.Add(new Paragraph("\n"));
                    var sub = new Paragraph("Reporte General del Proceso Electoral", fSub);
                    sub.Alignment = Element.ALIGN_CENTER;
                    doc.Add(sub);

                    doc.Add(new Paragraph("\n"));
                    var fecha = new Paragraph("Generado el: " +
                                DateTime.Now.ToString("dd/MM/yyyy HH:mm"), fFecha);
                    fecha.Alignment = Element.ALIGN_CENTER;
                    doc.Add(fecha);

                    doc.Add(new Paragraph("\n\n"));

                    // ── Los 4 reportes ───────────────────────────────
                    AgregarTablaAlPDF(doc, "1. PLANCHA GANADORA Y ESTADÍSTICAS",
                                      ObtenerEstadisticasPlanchas());

                    AgregarTablaAlPDF(doc, "2. INTEGRANTES DE PLANCHA",
                                      ObtenerIntegrantes());

                    // Reporte general con resumen
                    AgregarResumenVotosAlPDF(doc, ObtenerEstadisticasPlanchas(), 80, 10, 100);

                    AgregarTablaAlPDF(doc, "4. LISTADO GENERAL DE PARTICIPANTES",
                                      ObtenerParticipantes());

                    doc.Close();
                }

                MessageBox.Show("✅ PDF generado exitosamente en:\n" + sfd.FileName,
                                "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Abrir automáticamente el PDF
                System.Diagnostics.Process.Start(sfd.FileName);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al generar PDF:\n" + ex.Message,
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ── Tabla genérica ──────────────────────────────────────────
        private void AgregarTablaAlPDF(Document doc, string titulo, DataTable dt)
        {
            var fTitulo = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 13,
                           new BaseColor(255, 255, 255));
            var fHeader = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 10,
                           new BaseColor(255, 255, 255));
            var fNormal = FontFactory.GetFont(FontFactory.HELVETICA, 9,
                           new BaseColor(30, 30, 30));

            // Celda de título
            PdfPTable tblTitulo = new PdfPTable(1);
            tblTitulo.WidthPercentage = 100;
            PdfPCell celdaTitulo = new PdfPCell(new Phrase("  " + titulo, fTitulo))
            {
                BackgroundColor = new BaseColor(0, 51, 102),
                Padding = 8,
                Border = PdfPCell.NO_BORDER
            };
            tblTitulo.AddCell(celdaTitulo);
            doc.Add(tblTitulo);

            // Tabla de datos
            PdfPTable tabla = new PdfPTable(dt.Columns.Count);
            tabla.WidthPercentage = 100;
            tabla.SpacingAfter = 20f;

            // Encabezados
            foreach (DataColumn col in dt.Columns)
            {
                PdfPCell h = new PdfPCell(new Phrase(col.ColumnName, fHeader))
                {
                    BackgroundColor = new BaseColor(0, 80, 150),
                    Padding = 6,
                    HorizontalAlignment = Element.ALIGN_CENTER
                };
                tabla.AddCell(h);
            }

            // Filas alternadas
            bool alt = false;
            foreach (DataRow row in dt.Rows)
            {
                var bgFila = alt
                    ? new BaseColor(220, 235, 255)
                    : new BaseColor(255, 255, 255);

                foreach (var val in row.ItemArray)
                {
                    PdfPCell c = new PdfPCell(new Phrase(val?.ToString() ?? "", fNormal))
                    {
                        BackgroundColor = bgFila,
                        Padding = 5
                    };
                    tabla.AddCell(c);
                }
                alt = !alt;
            }

            doc.Add(tabla);
        }

        // ── Resumen especial de votos ───────────────────────────────
        private void AgregarResumenVotosAlPDF(Document doc, DataTable dt,
                                               int emitidos, int nulos, int padron)
        {
            var fTitulo = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 13,
                          new BaseColor(255, 255, 255));
            var fHeader = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 10,
                          new BaseColor(255, 255, 255));
            var fNormal = FontFactory.GetFont(FontFactory.HELVETICA, 9,
                          new BaseColor(30, 30, 30));
            var fBold = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 9,
                          new BaseColor(30, 30, 30));

            // Título
            PdfPTable tblTitulo = new PdfPTable(1);
            tblTitulo.WidthPercentage = 100;
            tblTitulo.AddCell(new PdfPCell(new Phrase("  3. REPORTE GENERAL DE VOTOS", fTitulo))
            {
                BackgroundColor = new BaseColor(0, 51, 102),
                Padding = 8,
                Border = PdfPCell.NO_BORDER
            });
            doc.Add(tblTitulo);

            // Tarjetas de resumen (4 columnas)
            PdfPTable resumen = new PdfPTable(4);
            resumen.WidthPercentage = 100;
            resumen.SpacingAfter = 10f;

            double pct = padron > 0 ? Math.Round(emitidos * 100.0 / padron, 1) : 0;

            void Tarjeta(string etiqueta, string valor, BaseColor color)
            {
                var fEtiq = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 8,
                            new BaseColor(220, 235, 255));
                var fVal = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 18,
                            new BaseColor(255, 255, 255));
                PdfPTable inner = new PdfPTable(1);
                inner.AddCell(new PdfPCell(new Phrase(etiqueta, fEtiq))
                {
                    Border = PdfPCell.NO_BORDER,
                    BackgroundColor = color,
                    PaddingTop = 8,
                    PaddingLeft = 6
                });
                inner.AddCell(new PdfPCell(new Phrase(valor, fVal))
                {
                    Border = PdfPCell.NO_BORDER,
                    BackgroundColor = color,
                    PaddingBottom = 8,
                    PaddingLeft = 10
                });
                resumen.AddCell(new PdfPCell(inner)
                { Border = PdfPCell.NO_BORDER, Padding = 2 });
            }

            Tarjeta("PADRÓN ELECTORAL", padron.ToString(), new BaseColor(0, 60, 130));
            Tarjeta("VOTOS EMITIDOS", emitidos.ToString(), new BaseColor(0, 100, 50));
            Tarjeta("VOTOS NULOS", nulos.ToString(), new BaseColor(130, 20, 20));
            Tarjeta("PARTICIPACIÓN", pct + "%", new BaseColor(90, 40, 140));
            doc.Add(resumen);

            // Tabla por planchas
            AgregarTablaAlPDF(doc, "", dt);
        }

        // ═══════════════════════════════════════════════════════════
        // DATOS DE EJEMPLO — reemplaza con tus consultas reales a BD
        // ═══════════════════════════════════════════════════════════

        private DataTable ObtenerEstadisticasPlanchas()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("NombrePlancha");
            dt.Columns.Add("Color");
            dt.Columns.Add("TotalVotos");
            dt.Columns.Add("Porcentaje");
            dt.Rows.Add("Plancha Libertad", "Azul", "45", "56.25");
            dt.Rows.Add("Plancha Unidad", "Rojo", "25", "31.25");
            dt.Rows.Add("Plancha Futuro", "Verde", "10", "12.50");
            return dt;
        }

        private DataTable ObtenerIntegrantes()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Nombre");
            dt.Columns.Add("Matricula");
            dt.Columns.Add("Curso");
            dt.Columns.Add("Seccion");
            dt.Columns.Add("Puesto");
            dt.Rows.Add("Juan García", "2024001", "3ro", "A", "Presidente");
            dt.Rows.Add("María López", "2024002", "3ro", "A", "Vicepresidente");
            dt.Rows.Add("Pedro Martínez", "2024003", "2do", "B", "Secretario");
            return dt;
        }

        private DataTable ObtenerParticipantes()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Nombre");
            dt.Columns.Add("Matricula");
            dt.Columns.Add("Curso");
            dt.Columns.Add("Seccion");
            dt.Columns.Add("Rol");
            dt.Columns.Add("Voto");
            dt.Rows.Add("Juan García", "2024001", "3ro", "A", "Votante", "Sí");
            dt.Rows.Add("María López", "2024002", "3ro", "A", "Votante", "No");
            dt.Rows.Add("Pedro Martínez", "2024003", "2do", "B", "Admin", "Sí");
            return dt;
        }

        // ═══════════════════════════════════════════════════════════
        // MOTORES DE IMPRESIÓN (vista previa)
        // ═══════════════════════════════════════════════════════════

        private void ImprimirPlanchaGanadora(DataTable dt)
        {
            var doc = new PrintDocument();
            doc.PrintPage += (s, e) =>
            {
                var g = e.Graphics;
                int y = 30, mx = 50, ancho = e.PageBounds.Width - 100;
                var fT = new System.Drawing.Font("Segoe UI", 16, FontStyle.Bold);
                var fS = new System.Drawing.Font("Segoe UI", 10, FontStyle.Bold);
                var fN = new System.Drawing.Font("Segoe UI", 10);
                var azul = System.Drawing.Color.FromArgb(0, 51, 102);

                g.FillRectangle(new SolidBrush(azul), mx, y, ancho, 45);
                g.DrawString("SISTEMA DE VOTACIONES ESCOLARES", fT,
                              System.Drawing.Brushes.White, mx + 10, y + 8);
                y += 55;
                g.DrawString("PLANCHA GANADORA Y ESTADÍSTICAS", fS,
                              new SolidBrush(azul), mx, y);
                y += 20;
                g.DrawString("Fecha: " + DateTime.Now.ToString("dd/MM/yyyy HH:mm"),
                              fN, System.Drawing.Brushes.Gray, mx, y);
                y += 25;
                g.DrawLine(new System.Drawing.Pen(azul, 2), mx, y, mx + ancho, y);
                y += 15;

                if (dt.Rows.Count > 0)
                {
                    var f = dt.Rows[0];
                    g.FillRectangle(new SolidBrush(System.Drawing.Color.FromArgb(0, 102, 51)),
                                    mx, y, ancho, 28);
                    g.DrawString("GANADORA: " + f["NombrePlancha"],
                                  new System.Drawing.Font("Segoe UI", 11, FontStyle.Bold),
                                  System.Drawing.Brushes.White, mx + 10, y + 5);
                    y += 40;
                    g.DrawString("Votos: " + f["TotalVotos"] +
                                  "   Porcentaje: " + f["Porcentaje"] + "%",
                                  fS, new SolidBrush(System.Drawing.Color.DarkGreen), mx, y);
                    y += 35;
                }

                int c1 = mx, c2 = mx + 220, c3 = mx + 360, c4 = mx + 460;
                g.FillRectangle(new SolidBrush(azul), mx, y, ancho, 22);
                g.DrawString("Plancha", fS, System.Drawing.Brushes.White, c1 + 5, y + 3);
                g.DrawString("Color", fS, System.Drawing.Brushes.White, c2 + 5, y + 3);
                g.DrawString("Votos", fS, System.Drawing.Brushes.White, c3 + 5, y + 3);
                g.DrawString("Porcentaje", fS, System.Drawing.Brushes.White, c4 + 5, y + 3);
                y += 22;

                bool alt = false;
                foreach (DataRow r in dt.Rows)
                {
                    var bg = alt ? System.Drawing.Color.FromArgb(220, 235, 255)
                                 : System.Drawing.Color.White;
                    g.FillRectangle(new SolidBrush(bg), mx, y, ancho, 20);
                    g.DrawString(r["NombrePlancha"].ToString(), fN, System.Drawing.Brushes.Black, c1 + 5, y + 2);
                    g.DrawString(r["Color"].ToString(), fN, System.Drawing.Brushes.Black, c2 + 5, y + 2);
                    g.DrawString(r["TotalVotos"].ToString(), fN, System.Drawing.Brushes.Black, c3 + 5, y + 2);
                    g.DrawString(r["Porcentaje"] + "%", fN, System.Drawing.Brushes.Black, c4 + 5, y + 2);
                    y += 20; alt = !alt;
                }
                e.HasMorePages = false;
            };
            MostrarVistaPrevia(doc);
        }

        private void ImprimirIntegrantes(DataTable dt, string plancha)
        {
            int startRow = 0;
            var doc = new PrintDocument();
            doc.PrintPage += (s, e) =>
            {
                var g = e.Graphics;
                int y = 30, mx = 50, ancho = e.PageBounds.Width - 100;
                var fT = new System.Drawing.Font("Segoe UI", 15, FontStyle.Bold);
                var fS = new System.Drawing.Font("Segoe UI", 10, FontStyle.Bold);
                var fN = new System.Drawing.Font("Segoe UI", 9);
                var azul = System.Drawing.Color.FromArgb(0, 51, 102);

                if (startRow == 0)
                {
                    g.FillRectangle(new SolidBrush(azul), mx, y, ancho, 45);
                    g.DrawString("INTEGRANTES DE PLANCHA", fT,
                                  System.Drawing.Brushes.White, mx + 10, y + 8);
                    y += 55;
                    g.DrawString("Plancha: " + plancha + "   |   " +
                                  DateTime.Now.ToString("dd/MM/yyyy"),
                                  fN, System.Drawing.Brushes.Gray, mx, y);
                    y += 22;
                }

                int c1 = mx, c2 = mx + 200, c3 = mx + 320, c4 = mx + 400, c5 = mx + 470;
                g.FillRectangle(new SolidBrush(azul), mx, y, ancho, 22);
                g.DrawString("Nombre", fS, System.Drawing.Brushes.White, c1 + 5, y + 3);
                g.DrawString("Matrícula", fS, System.Drawing.Brushes.White, c2 + 5, y + 3);
                g.DrawString("Curso", fS, System.Drawing.Brushes.White, c3 + 5, y + 3);
                g.DrawString("Sección", fS, System.Drawing.Brushes.White, c4 + 5, y + 3);
                g.DrawString("Puesto", fS, System.Drawing.Brushes.White, c5 + 5, y + 3);
                y += 22;

                bool alt = false;
                int row = startRow;
                while (row < dt.Rows.Count && y < e.PageBounds.Height - 55)
                {
                    var r = dt.Rows[row];
                    var bg = alt ? System.Drawing.Color.FromArgb(220, 235, 255)
                                 : System.Drawing.Color.White;
                    g.FillRectangle(new SolidBrush(bg), mx, y, ancho, 20);
                    g.DrawString(r["Nombre"].ToString(), fN, System.Drawing.Brushes.Black, c1 + 5, y + 2);
                    g.DrawString(r["Matricula"].ToString(), fN, System.Drawing.Brushes.Black, c2 + 5, y + 2);
                    g.DrawString(r["Curso"].ToString(), fN, System.Drawing.Brushes.Black, c3 + 5, y + 2);
                    g.DrawString(r["Seccion"].ToString(), fN, System.Drawing.Brushes.Black, c4 + 5, y + 2);
                    g.DrawString(r["Puesto"].ToString(), fN, System.Drawing.Brushes.Black, c5 + 5, y + 2);
                    y += 20; alt = !alt; row++;
                }
                startRow = row;
                e.HasMorePages = (startRow < dt.Rows.Count);
            };
            MostrarVistaPrevia(doc);
        }

        private void ImprimirGeneralVotos(DataTable dt, int emitidos, int nulos, int padron)
        {
            var doc = new PrintDocument();
            doc.DefaultPageSettings.Landscape = true;
            doc.PrintPage += (s, e) =>
            {
                var g = e.Graphics;
                int y = 30, mx = 50, ancho = e.PageBounds.Width - 100;
                var fT = new System.Drawing.Font("Segoe UI", 15, FontStyle.Bold);
                var fS = new System.Drawing.Font("Segoe UI", 10, FontStyle.Bold);
                var fN = new System.Drawing.Font("Segoe UI", 10);
                var azul = System.Drawing.Color.FromArgb(0, 51, 102);

                g.FillRectangle(new SolidBrush(azul), mx, y, ancho, 45);
                g.DrawString("REPORTE GENERAL DE VOTOS", fT,
                              System.Drawing.Brushes.White, mx + 10, y + 8);
                y += 60;

                void Card(int x, int ty, string label, string val, System.Drawing.Color c)
                {
                    g.FillRectangle(new SolidBrush(c), x, ty, 165, 65);
                    g.DrawString(label, new System.Drawing.Font("Segoe UI", 8, FontStyle.Bold),
                                  System.Drawing.Brushes.White, x + 5, ty + 6);
                    g.DrawString(val, new System.Drawing.Font("Segoe UI", 22, FontStyle.Bold),
                                  System.Drawing.Brushes.White, x + 8, ty + 22);
                }

                double pct = padron > 0 ? Math.Round(emitidos * 100.0 / padron, 1) : 0;
                Card(mx, y, "PADRÓN", padron.ToString(), System.Drawing.Color.FromArgb(0, 60, 130));
                Card(mx + 180, y, "EMITIDOS", emitidos.ToString(), System.Drawing.Color.FromArgb(0, 100, 50));
                Card(mx + 360, y, "NULOS", nulos.ToString(), System.Drawing.Color.FromArgb(130, 20, 20));
                Card(mx + 540, y, "PARTICIPACIÓN", pct + "%", System.Drawing.Color.FromArgb(90, 40, 140));
                y += 85;

                int c1 = mx, c2 = mx + 240, c3 = mx + 400, c4 = mx + 500, c5 = mx + 610;
                g.FillRectangle(new SolidBrush(azul), mx, y, ancho, 22);
                g.DrawString("Plancha", fS, System.Drawing.Brushes.White, c1 + 5, y + 3);
                g.DrawString("Color", fS, System.Drawing.Brushes.White, c2 + 5, y + 3);
                g.DrawString("Votos", fS, System.Drawing.Brushes.White, c3 + 5, y + 3);
                g.DrawString("Porcentaje", fS, System.Drawing.Brushes.White, c4 + 5, y + 3);
                g.DrawString("Posición", fS, System.Drawing.Brushes.White, c5 + 5, y + 3);
                y += 22;

                bool alt = false; int pos = 1;
                foreach (DataRow r in dt.Rows)
                {
                    var bg = alt ? System.Drawing.Color.FromArgb(220, 235, 255)
                                 : System.Drawing.Color.White;
                    g.FillRectangle(new SolidBrush(bg), mx, y, ancho, 22);
                    g.DrawString(r["NombrePlancha"].ToString(), fN, System.Drawing.Brushes.Black, c1 + 5, y + 3);
                    g.DrawString(r["Color"].ToString(), fN, System.Drawing.Brushes.Black, c2 + 5, y + 3);
                    g.DrawString(r["TotalVotos"].ToString(), fN, System.Drawing.Brushes.Black, c3 + 5, y + 3);
                    g.DrawString(r["Porcentaje"] + "%", fN, System.Drawing.Brushes.Black, c4 + 5, y + 3);
                    g.DrawString("#" + pos, pos == 1
                        ? new System.Drawing.Font("Segoe UI", 10, FontStyle.Bold) : fN,
                        pos == 1 ? System.Drawing.Brushes.DarkGreen
                               : System.Drawing.Brushes.Black, c5 + 5, y + 3);
                    y += 22; alt = !alt; pos++;
                }
                e.HasMorePages = false;
            };
            MostrarVistaPrevia(doc);
        }

        private void ImprimirParticipantes(DataTable dt)
        {
            int startRow = 0;
            var doc = new PrintDocument();
            doc.DefaultPageSettings.Landscape = true;
            doc.PrintPage += (s, e) =>
            {
                var g = e.Graphics;
                int y = 30, mx = 40, ancho = e.PageBounds.Width - 80;
                var fT = new System.Drawing.Font("Segoe UI", 15, FontStyle.Bold);
                var fS = new System.Drawing.Font("Segoe UI", 9, FontStyle.Bold);
                var fN = new System.Drawing.Font("Segoe UI", 9);
                var azul = System.Drawing.Color.FromArgb(0, 51, 102);

                if (startRow == 0)
                {
                    g.FillRectangle(new SolidBrush(azul), mx, y, ancho, 45);
                    g.DrawString("LISTADO GENERAL DE PARTICIPANTES", fT,
                                  System.Drawing.Brushes.White, mx + 10, y + 8);
                    y += 55;
                    g.DrawString("Total: " + dt.Rows.Count + " registros   |   " +
                                  DateTime.Now.ToString("dd/MM/yyyy"),
                                  fN, System.Drawing.Brushes.Gray, mx, y);
                    y += 20;
                }

                int c1 = mx, c2 = mx + 30, c3 = mx + 230, c4 = mx + 360, c5 = mx + 430, c6 = mx + 510, c7 = mx + 610;
                g.FillRectangle(new SolidBrush(azul), mx, y, ancho, 22);
                g.DrawString("#", fS, System.Drawing.Brushes.White, c1 + 2, y + 3);
                g.DrawString("Nombre", fS, System.Drawing.Brushes.White, c2 + 2, y + 3);
                g.DrawString("Matrícula", fS, System.Drawing.Brushes.White, c3 + 2, y + 3);
                g.DrawString("Curso", fS, System.Drawing.Brushes.White, c4 + 2, y + 3);
                g.DrawString("Sección", fS, System.Drawing.Brushes.White, c5 + 2, y + 3);
                g.DrawString("Rol", fS, System.Drawing.Brushes.White, c6 + 2, y + 3);
                g.DrawString("¿Votó?", fS, System.Drawing.Brushes.White, c7 + 2, y + 3);
                y += 22;

                bool alt = false;
                int row = startRow, num = startRow + 1;
                while (row < dt.Rows.Count && y < e.PageBounds.Height - 50)
                {
                    var r = dt.Rows[row];
                    var bg = alt ? System.Drawing.Color.FromArgb(220, 235, 255)
                                 : System.Drawing.Color.White;
                    g.FillRectangle(new SolidBrush(bg), mx, y, ancho, 20);

                    bool voto = r["Voto"].ToString() == "1" ||
                                r["Voto"].ToString().ToLower() == "si" ||
                                r["Voto"].ToString().ToLower() == "sí";
                    var cVoto = voto ? System.Drawing.Color.DarkGreen
                                     : System.Drawing.Color.DarkRed;

                    g.DrawString(num.ToString(), fN, System.Drawing.Brushes.Black, c1 + 2, y + 2);
                    g.DrawString(r["Nombre"].ToString(), fN, System.Drawing.Brushes.Black, c2 + 2, y + 2);
                    g.DrawString(r["Matricula"].ToString(), fN, System.Drawing.Brushes.Black, c3 + 2, y + 2);
                    g.DrawString(r["Curso"].ToString(), fN, System.Drawing.Brushes.Black, c4 + 2, y + 2);
                    g.DrawString(r["Seccion"].ToString(), fN, System.Drawing.Brushes.Black, c5 + 2, y + 2);
                    g.DrawString(r["Rol"].ToString(), fN, System.Drawing.Brushes.Black, c6 + 2, y + 2);
                    g.DrawString(voto ? "Sí" : "No",
                                  new System.Drawing.Font("Segoe UI", 9, FontStyle.Bold),
                                  new SolidBrush(cVoto), c7 + 2, y + 2);
                    y += 20; alt = !alt; row++; num++;
                }
                startRow = row;
                e.HasMorePages = (startRow < dt.Rows.Count);
            };
            MostrarVistaPrevia(doc);
        }

        private void MostrarVistaPrevia(PrintDocument doc)
        {
            var preview = new PrintPreviewDialog();
            preview.Document = doc;
            preview.Width = 1000;
            preview.Height = 720;
            preview.ShowDialog();
        }
    }
}