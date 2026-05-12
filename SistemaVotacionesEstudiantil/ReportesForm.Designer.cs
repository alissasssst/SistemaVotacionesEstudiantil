namespace SistemaVotacionesEstudiantil
{
    partial class ReportesForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.panelHeader = new System.Windows.Forms.Panel();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.lblSubtitulo = new System.Windows.Forms.Label();
            this.panelBotones = new System.Windows.Forms.Panel();
            this.btnRptGanadora = new System.Windows.Forms.Button();
            this.btnRptIntegrantes = new System.Windows.Forms.Button();
            this.btnRptVotos = new System.Windows.Forms.Button();
            this.btnRptParticipantes = new System.Windows.Forms.Button();
            this.btnCerrar = new System.Windows.Forms.Button();
            this.panelHeader.SuspendLayout();
            this.panelBotones.SuspendLayout();
            this.SuspendLayout();

            // ── FORM
            this.BackColor = System.Drawing.Color.FromArgb(10, 25, 60);
            this.ClientSize = new System.Drawing.Size(480, 560);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Reportes del Sistema";
            this.Font = new System.Drawing.Font("Segoe UI", 9F);

            // ── panelHeader
            this.panelHeader.BackColor = System.Drawing.Color.FromArgb(8, 20, 55);
            this.panelHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelHeader.Height = 110;
            this.panelHeader.Controls.Add(this.lblTitulo);
            this.panelHeader.Controls.Add(this.lblSubtitulo);

            this.lblTitulo.AutoSize = false;
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.ForeColor = System.Drawing.Color.White;
            this.lblTitulo.Location = new System.Drawing.Point(0, 18);
            this.lblTitulo.Size = new System.Drawing.Size(480, 42);
            this.lblTitulo.Text = "REPORTES";
            this.lblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            this.lblSubtitulo.AutoSize = false;
            this.lblSubtitulo.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblSubtitulo.ForeColor = System.Drawing.Color.FromArgb(100, 180, 255);
            this.lblSubtitulo.Location = new System.Drawing.Point(0, 65);
            this.lblSubtitulo.Size = new System.Drawing.Size(480, 28);
            this.lblSubtitulo.Text = "Selecciona el reporte que deseas generar";
            this.lblSubtitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            // ── panelBotones
            this.panelBotones.BackColor = System.Drawing.Color.FromArgb(15, 40, 90);
            this.panelBotones.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelBotones.Location = new System.Drawing.Point(30, 130);
            this.panelBotones.Size = new System.Drawing.Size(420, 360);
            this.panelBotones.Controls.Add(this.btnRptGanadora);
            this.panelBotones.Controls.Add(this.btnRptIntegrantes);
            this.panelBotones.Controls.Add(this.btnRptVotos);
            this.panelBotones.Controls.Add(this.btnRptParticipantes);
            this.panelBotones.Controls.Add(this.btnCerrar);

            // ── Colores reutilizables
            var cBoton = System.Drawing.Color.FromArgb(0, 55, 120);
            var cBorde = System.Drawing.Color.FromArgb(100, 180, 255);
            var fBtn = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);

            // ── btnRptGanadora
            this.btnRptGanadora.BackColor = cBoton;
            this.btnRptGanadora.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRptGanadora.FlatAppearance.BorderColor = cBorde;
            this.btnRptGanadora.FlatAppearance.BorderSize = 1;
            this.btnRptGanadora.Font = fBtn;
            this.btnRptGanadora.ForeColor = System.Drawing.Color.White;
            this.btnRptGanadora.Location = new System.Drawing.Point(20, 20);
            this.btnRptGanadora.Size = new System.Drawing.Size(380, 52);
            this.btnRptGanadora.Text = "🏆   Plancha Ganadora";
            this.btnRptGanadora.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRptGanadora.Padding = new System.Windows.Forms.Padding(14, 0, 0, 0);
            this.btnRptGanadora.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRptGanadora.Click += new System.EventHandler(this.btnRptGanadora_Click);

            // ── btnRptIntegrantes
            this.btnRptIntegrantes.BackColor = cBoton;
            this.btnRptIntegrantes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRptIntegrantes.FlatAppearance.BorderColor = cBorde;
            this.btnRptIntegrantes.FlatAppearance.BorderSize = 1;
            this.btnRptIntegrantes.Font = fBtn;
            this.btnRptIntegrantes.ForeColor = System.Drawing.Color.White;
            this.btnRptIntegrantes.Location = new System.Drawing.Point(20, 85);
            this.btnRptIntegrantes.Size = new System.Drawing.Size(380, 52);
            this.btnRptIntegrantes.Text = "👥   Integrantes de Plancha";
            this.btnRptIntegrantes.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRptIntegrantes.Padding = new System.Windows.Forms.Padding(14, 0, 0, 0);
            this.btnRptIntegrantes.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRptIntegrantes.Click += new System.EventHandler(this.btnRptIntegrantes_Click);

            // ── btnRptVotos
            this.btnRptVotos.BackColor = cBoton;
            this.btnRptVotos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRptVotos.FlatAppearance.BorderColor = cBorde;
            this.btnRptVotos.FlatAppearance.BorderSize = 1;
            this.btnRptVotos.Font = fBtn;
            this.btnRptVotos.ForeColor = System.Drawing.Color.White;
            this.btnRptVotos.Location = new System.Drawing.Point(20, 150);
            this.btnRptVotos.Size = new System.Drawing.Size(380, 52);
            this.btnRptVotos.Text = "📊   General de Votos";
            this.btnRptVotos.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRptVotos.Padding = new System.Windows.Forms.Padding(14, 0, 0, 0);
            this.btnRptVotos.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRptVotos.Click += new System.EventHandler(this.btnRptVotos_Click);

            // ── btnRptParticipantes
            this.btnRptParticipantes.BackColor = cBoton;
            this.btnRptParticipantes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRptParticipantes.FlatAppearance.BorderColor = cBorde;
            this.btnRptParticipantes.FlatAppearance.BorderSize = 1;
            this.btnRptParticipantes.Font = fBtn;
            this.btnRptParticipantes.ForeColor = System.Drawing.Color.White;
            this.btnRptParticipantes.Location = new System.Drawing.Point(20, 215);
            this.btnRptParticipantes.Size = new System.Drawing.Size(380, 52);
            this.btnRptParticipantes.Text = "📋   Listado de Participantes";
            this.btnRptParticipantes.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRptParticipantes.Padding = new System.Windows.Forms.Padding(14, 0, 0, 0);
            this.btnRptParticipantes.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRptParticipantes.Click += new System.EventHandler(this.btnRptParticipantes_Click);

            // ── btnCerrar
            this.btnCerrar.BackColor = System.Drawing.Color.FromArgb(110, 20, 20);
            this.btnCerrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCerrar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(255, 100, 100);
            this.btnCerrar.FlatAppearance.BorderSize = 1;
            this.btnCerrar.Font = fBtn;
            this.btnCerrar.ForeColor = System.Drawing.Color.White;
            this.btnCerrar.Location = new System.Drawing.Point(20, 290);
            this.btnCerrar.Size = new System.Drawing.Size(380, 48);
            this.btnCerrar.Text = "✕   CERRAR";
            this.btnCerrar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCerrar.Padding = new System.Windows.Forms.Padding(14, 0, 0, 0);
            this.btnCerrar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);

            // ── Agregar al Form
            this.Controls.Add(this.panelHeader);
            this.Controls.Add(this.panelBotones);

            this.panelHeader.ResumeLayout(false);
            this.panelBotones.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblSubtitulo;
        private System.Windows.Forms.Panel panelBotones;
        private System.Windows.Forms.Button btnRptGanadora;
        private System.Windows.Forms.Button btnRptIntegrantes;
        private System.Windows.Forms.Button btnRptVotos;
        private System.Windows.Forms.Button btnRptParticipantes;
        private System.Windows.Forms.Button btnCerrar;
    }
}