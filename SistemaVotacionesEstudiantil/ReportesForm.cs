using System;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Windows.Forms;

namespace SistemaVotacionesEstudiantil
{
    public partial class ReportesForm : Form
    {
        public ReportesForm()
        {
            InitializeComponent();
        }

        // ─── REPORTE 1: Plancha Ganadora ───────────────────────────
        private void btnRptGanadora_Click(object sender, EventArgs e)
        {
            DataTable dt = ObtenerEstadisticasPlanchas();
            ImprimirPlanchaGanadora(dt);
        }

        // ─── REPORTE 2: Integrantes de Plancha ────────────────────
        private void btnRptIntegrantes_Click(object sender, EventArgs e)
        {
            DataTable dt = ObtenerIntegrantes();
            ImprimirIntegrantes(dt, "Todas las Planchas");
        }

        // ─── REPORTE 3: General de Votos ──────────────────────────
        private void btnRptVotos_Click(object sender, EventArgs e)
        {
            DataTable dt = ObtenerEstadisticasPlanchas();
            ImprimirGeneralVotos(dt, 80, 10, 100);
        }

        // ─── REPORTE 4: Listado de Participantes ──────────────────
        private void btnRptParticipantes_Click(object sender, EventArgs e)
        {
            DataTable dt = ObtenerParticipantes();
            ImprimirParticipantes(dt);
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // ══════════════════════════════════════════════════════════
        // DATOS DE EJEMPLO — reemplaza con tus consultas reales a BD
        // ══════════════════════════════════════════════════════════
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
            dt.Rows.Add("Juan García", "2024001", "3ro", "A", "Votante", "1");
            dt.Rows.Add("María López", "2024002", "3ro", "A", "Votante", "0");
            dt.Rows.Add("Pedro Martínez", "2024003", "2do", "B", "Admin", "1");
            return dt;
        }

        // ══════════════════════════════════════════════════════════
        // MOTORES DE IMPRESIÓN
        // ══════════════════════════════════════════════════════════
        private void ImprimirPlanchaGanadora(DataTable dt)
        {
            var doc = new PrintDocument();
            doc.PrintPage += (s, e) =>
            {
                var g = e.Graphics;
                int y = 30, mx = 50, ancho = e.PageBounds.Width - 100;
                var fT = new Font("Segoe UI", 16, FontStyle.Bold);
                var fS = new Font("Segoe UI", 10, FontStyle.Bold);
                var fN = new Font("Segoe UI", 10);
                var azul = Color.FromArgb(0, 51, 102);

                g.FillRectangle(new SolidBrush(azul), mx, y, ancho, 45);
                g.DrawString("SISTEMA DE VOTACIONES ESCOLARES", fT, Brushes.White, mx + 10, y + 8);
                y += 55;
                g.DrawString("REPORTE: PLANCHA GANADORA Y ESTADÍSTICAS", fS,
                              new SolidBrush(azul), mx, y);
                y += 20;
                g.DrawString("Fecha: " + DateTime.Now.ToString("dd/MM/yyyy HH:mm"),
                              fN, Brushes.Gray, mx, y);
                y += 25;
                g.DrawLine(new Pen(azul, 2), mx, y, mx + ancho, y);
                y += 15;

                if (dt.Rows.Count > 0)
                {
                    var fila = dt.Rows[0];
                    g.FillRectangle(new SolidBrush(Color.FromArgb(0, 102, 51)), mx, y, ancho, 28);
                    g.DrawString("PLANCHA GANADORA: " + fila["NombrePlancha"],
                                  new Font("Segoe UI", 11, FontStyle.Bold), Brushes.White, mx + 10, y + 5);
                    y += 38;
                    g.DrawString("Votos obtenidos: " + fila["TotalVotos"] +
                                  "   |   Porcentaje: " + fila["Porcentaje"] + "%",
                                  fS, new SolidBrush(Color.DarkGreen), mx, y);
                    y += 35;
                }

                // Tabla
                int c1 = mx, c2 = mx + 210, c3 = mx + 350, c4 = mx + 450;
                g.FillRectangle(new SolidBrush(azul), mx, y, ancho, 22);
                g.DrawString("Plancha", fS, Brushes.White, c1 + 5, y + 3);
                g.DrawString("Color", fS, Brushes.White, c2 + 5, y + 3);
                g.DrawString("Votos", fS, Brushes.White, c3 + 5, y + 3);
                g.DrawString("Porcentaje", fS, Brushes.White, c4 + 5, y + 3);
                y += 22;

                bool alt = false;
                foreach (DataRow r in dt.Rows)
                {
                    var bg = alt ? Color.FromArgb(220, 235, 255) : Color.White;
                    g.FillRectangle(new SolidBrush(bg), mx, y, ancho, 20);
                    g.DrawString(r["NombrePlancha"].ToString(), fN, Brushes.Black, c1 + 5, y + 2);
                    g.DrawString(r["Color"].ToString(), fN, Brushes.Black, c2 + 5, y + 2);
                    g.DrawString(r["TotalVotos"].ToString(), fN, Brushes.Black, c3 + 5, y + 2);
                    g.DrawString(r["Porcentaje"] + "%", fN, Brushes.Black, c4 + 5, y + 2);
                    y += 20; alt = !alt;
                }

                int pie = e.PageBounds.Height - 35;
                g.DrawLine(Pens.Gray, mx, pie, mx + ancho, pie);
                g.DrawString("Sistema de Votaciones Escolares — " +
                              DateTime.Now.ToString("dd/MM/yyyy"), fN, Brushes.Gray, mx, pie + 5);
                e.HasMorePages = false;
            };

            MostrarVistaPreviaEImprimirr(doc);
        }

        private void ImprimirIntegrantes(DataTable dt, string plancha)
        {
            int startRow = 0;
            var doc = new PrintDocument();
            doc.PrintPage += (s, e) =>
            {
                var g = e.Graphics;
                int y = 30, mx = 50, ancho = e.PageBounds.Width - 100;
                var fT = new Font("Segoe UI", 15, FontStyle.Bold);
                var fS = new Font("Segoe UI", 10, FontStyle.Bold);
                var fN = new Font("Segoe UI", 9);
                var azul = Color.FromArgb(0, 51, 102);

                if (startRow == 0)
                {
                    g.FillRectangle(new SolidBrush(azul), mx, y, ancho, 45);
                    g.DrawString("INTEGRANTES DE PLANCHA", fT, Brushes.White, mx + 10, y + 8);
                    y += 55;
                    g.DrawString("Plancha: " + plancha + "   |   " +
                                  DateTime.Now.ToString("dd/MM/yyyy HH:mm"),
                                  fN, Brushes.Gray, mx, y);
                    y += 25;
                    g.DrawLine(new Pen(azul, 2), mx, y, mx + ancho, y);
                    y += 10;
                }

                int c1 = mx, c2 = mx + 200, c3 = mx + 320, c4 = mx + 400, c5 = mx + 470;
                g.FillRectangle(new SolidBrush(azul), mx, y, ancho, 22);
                g.DrawString("Nombre", fS, Brushes.White, c1 + 5, y + 3);
                g.DrawString("Matrícula", fS, Brushes.White, c2 + 5, y + 3);
                g.DrawString("Curso", fS, Brushes.White, c3 + 5, y + 3);
                g.DrawString("Sección", fS, Brushes.White, c4 + 5, y + 3);
                g.DrawString("Puesto", fS, Brushes.White, c5 + 5, y + 3);
                y += 22;

                bool alt = false;
                int row = startRow;
                while (row < dt.Rows.Count && y < e.PageBounds.Height - 55)
                {
                    var r = dt.Rows[row];
                    var bg = alt ? Color.FromArgb(220, 235, 255) : Color.White;
                    g.FillRectangle(new SolidBrush(bg), mx, y, ancho, 20);
                    g.DrawString(r["Nombre"].ToString(), fN, Brushes.Black, c1 + 5, y + 2);
                    g.DrawString(r["Matricula"].ToString(), fN, Brushes.Black, c2 + 5, y + 2);
                    g.DrawString(r["Curso"].ToString(), fN, Brushes.Black, c3 + 5, y + 2);
                    g.DrawString(r["Seccion"].ToString(), fN, Brushes.Black, c4 + 5, y + 2);
                    g.DrawString(r["Puesto"].ToString(), fN, Brushes.Black, c5 + 5, y + 2);
                    y += 20; alt = !alt; row++;
                }
                startRow = row;

                int pie = e.PageBounds.Height - 35;
                g.DrawLine(Pens.Gray, mx, pie, mx + ancho, pie);
                g.DrawString("Total: " + dt.Rows.Count + " integrantes", fN, Brushes.Gray, mx, pie + 5);
                e.HasMorePages = (startRow < dt.Rows.Count);
            };

            MostrarVistaPreviaEImprimirr(doc);
        }

        private void ImprimirGeneralVotos(DataTable dt, int emitidos, int nulos, int padron)
        {
            var doc = new PrintDocument();
            doc.DefaultPageSettings.Landscape = true;
            doc.PrintPage += (s, e) =>
            {
                var g = e.Graphics;
                int y = 30, mx = 50, ancho = e.PageBounds.Width - 100;
                var fT = new Font("Segoe UI", 15, FontStyle.Bold);
                var fS = new Font("Segoe UI", 10, FontStyle.Bold);
                var fN = new Font("Segoe UI", 10);
                var azul = Color.FromArgb(0, 51, 102);

                g.FillRectangle(new SolidBrush(azul), mx, y, ancho, 45);
                g.DrawString("REPORTE GENERAL DE VOTOS", fT, Brushes.White, mx + 10, y + 8);
                y += 55;
                g.DrawString("Generado: " + DateTime.Now.ToString("dd/MM/yyyy HH:mm"),
                              fN, Brushes.Gray, mx, y);
                y += 25;

                // Tarjetas de resumen
                void Tarjeta(int x, int ty, string titulo, string valor, Color color)
                {
                    g.FillRectangle(new SolidBrush(color), x, ty, 160, 65);
                    g.DrawString(titulo, new Font("Segoe UI", 8, FontStyle.Bold),
                                  Brushes.White, x + 5, ty + 5);
                    g.DrawString(valor, new Font("Segoe UI", 22, FontStyle.Bold),
                                  Brushes.White, x + 10, ty + 22);
                }

                double pct = padron > 0 ? Math.Round(emitidos * 100.0 / padron, 1) : 0;
                Tarjeta(mx, y, "PADRÓN ELECTORAL", padron.ToString(), Color.FromArgb(0, 60, 130));
                Tarjeta(mx + 175, y, "VOTOS EMITIDOS", emitidos.ToString(), Color.FromArgb(0, 100, 50));
                Tarjeta(mx + 350, y, "VOTOS NULOS", nulos.ToString(), Color.FromArgb(130, 20, 20));
                Tarjeta(mx + 525, y, "PARTICIPACIÓN", pct + "%", Color.FromArgb(90, 40, 140));
                y += 85;

                // Tabla
                int c1 = mx, c2 = mx + 230, c3 = mx + 390, c4 = mx + 490, c5 = mx + 600;
                g.FillRectangle(new SolidBrush(azul), mx, y, ancho, 22);
                g.DrawString("Plancha", fS, Brushes.White, c1 + 5, y + 3);
                g.DrawString("Color", fS, Brushes.White, c2 + 5, y + 3);
                g.DrawString("Votos", fS, Brushes.White, c3 + 5, y + 3);
                g.DrawString("Porcentaje", fS, Brushes.White, c4 + 5, y + 3);
                g.DrawString("Posición", fS, Brushes.White, c5 + 5, y + 3);
                y += 22;

                bool alt = false; int pos = 1;
                foreach (DataRow r in dt.Rows)
                {
                    var bg = alt ? Color.FromArgb(220, 235, 255) : Color.White;
                    g.FillRectangle(new SolidBrush(bg), mx, y, ancho, 22);
                    g.DrawString(r["NombrePlancha"].ToString(), fN, Brushes.Black, c1 + 5, y + 3);
                    g.DrawString(r["Color"].ToString(), fN, Brushes.Black, c2 + 5, y + 3);
                    g.DrawString(r["TotalVotos"].ToString(), fN, Brushes.Black, c3 + 5, y + 3);
                    g.DrawString(r["Porcentaje"] + "%", fN, Brushes.Black, c4 + 5, y + 3);
                    g.DrawString("#" + pos, pos == 1
                        ? new Font("Segoe UI", 10, FontStyle.Bold) : fN,
                        pos == 1 ? Brushes.DarkGreen : Brushes.Black, c5 + 5, y + 3);
                    y += 22; alt = !alt; pos++;
                }

                // Fila nulos
                g.FillRectangle(new SolidBrush(Color.FromArgb(255, 225, 225)), mx, y, ancho, 22);
                g.DrawString("VOTOS NULOS", fS, Brushes.DarkRed, c1 + 5, y + 3);
                g.DrawString(nulos.ToString(), fS, Brushes.DarkRed, c3 + 5, y + 3);
                double pctN = emitidos > 0 ? Math.Round(nulos * 100.0 / emitidos, 1) : 0;
                g.DrawString(pctN + "%", fS, Brushes.DarkRed, c4 + 5, y + 3);

                int pie = e.PageBounds.Height - 35;
                g.DrawLine(Pens.Gray, mx, pie, mx + ancho, pie);
                g.DrawString("Sistema de Votaciones Escolares — Confidencial", fN, Brushes.Gray, mx, pie + 5);
                e.HasMorePages = false;
            };

            MostrarVistaPreviaEImprimirr(doc);
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
                var fT = new Font("Segoe UI", 15, FontStyle.Bold);
                var fS = new Font("Segoe UI", 9, FontStyle.Bold);
                var fN = new Font("Segoe UI", 9);
                var azul = Color.FromArgb(0, 51, 102);

                if (startRow == 0)
                {
                    g.FillRectangle(new SolidBrush(azul), mx, y, ancho, 45);
                    g.DrawString("LISTADO GENERAL DE PARTICIPANTES", fT, Brushes.White, mx + 10, y + 8);
                    y += 55;
                    g.DrawString("Total: " + dt.Rows.Count + " registros   |   " +
                                  DateTime.Now.ToString("dd/MM/yyyy HH:mm"), fN, Brushes.Gray, mx, y);
                    y += 20;
                    g.DrawLine(new Pen(azul, 2), mx, y, mx + ancho, y);
                    y += 8;
                }

                int c1 = mx, c2 = mx + 30, c3 = mx + 230, c4 = mx + 360,
                    c5 = mx + 430, c6 = mx + 510, c7 = mx + 610;
                g.FillRectangle(new SolidBrush(azul), mx, y, ancho, 22);
                g.DrawString("#", fS, Brushes.White, c1 + 2, y + 3);
                g.DrawString("Nombre", fS, Brushes.White, c2 + 2, y + 3);
                g.DrawString("Matrícula", fS, Brushes.White, c3 + 2, y + 3);
                g.DrawString("Curso", fS, Brushes.White, c4 + 2, y + 3);
                g.DrawString("Sección", fS, Brushes.White, c5 + 2, y + 3);
                g.DrawString("Rol", fS, Brushes.White, c6 + 2, y + 3);
                g.DrawString("¿Votó?", fS, Brushes.White, c7 + 2, y + 3);
                y += 22;

                bool alt = false;
                int row = startRow, num = startRow + 1;
                while (row < dt.Rows.Count && y < e.PageBounds.Height - 50)
                {
                    var r = dt.Rows[row];
                    var bg = alt ? Color.FromArgb(220, 235, 255) : Color.White;
                    g.FillRectangle(new SolidBrush(bg), mx, y, ancho, 20);

                    bool voto = r["Voto"].ToString() == "1" ||
                                r["Voto"].ToString().ToLower() == "si" ||
                                r["Voto"].ToString().ToLower() == "true";
                    var cVoto = voto ? Color.DarkGreen : Color.DarkRed;

                    g.DrawString(num.ToString(), fN, Brushes.Black, c1 + 2, y + 2);
                    g.DrawString(r["Nombre"].ToString(), fN, Brushes.Black, c2 + 2, y + 2);
                    g.DrawString(r["Matricula"].ToString(), fN, Brushes.Black, c3 + 2, y + 2);
                    g.DrawString(r["Curso"].ToString(), fN, Brushes.Black, c4 + 2, y + 2);
                    g.DrawString(r["Seccion"].ToString(), fN, Brushes.Black, c5 + 2, y + 2);
                    g.DrawString(r["Rol"].ToString(), fN, Brushes.Black, c6 + 2, y + 2);
                    g.DrawString(voto ? "Si" : "No",
                                  new Font("Segoe UI", 9, FontStyle.Bold),
                                  new SolidBrush(cVoto), c7 + 2, y + 2);
                    y += 20; alt = !alt; row++; num++;
                }
                startRow = row;

                int pie = e.PageBounds.Height - 35;
                g.DrawLine(Pens.Gray, mx, pie, mx + ancho, pie);
                g.DrawString("Sistema de Votaciones Escolares — Confidencial", fN, Brushes.Gray, mx, pie + 5);
                e.HasMorePages = (startRow < dt.Rows.Count);
            };

            MostrarVistaPreviaEImprimirr(doc);
        }

        // ── Vista previa antes de imprimir ─────────────────────────
        private void MostrarVistaPreviaEImprimirr(PrintDocument doc)
        {
            var preview = new PrintPreviewDialog();
            preview.Document = doc;
            preview.Width = 1000;
            preview.Height = 720;
            preview.ShowDialog();
        }
    }
}