namespace SistemaVotacionesEstudiantil
{
    partial class MenuForm
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
            this.lblBienvenido = new System.Windows.Forms.Label();
            this.panelMenu = new System.Windows.Forms.Panel();
            this.btnVotar = new System.Windows.Forms.Button();
            this.btnDatosGenerales = new System.Windows.Forms.Button();
            this.btnPlanchas = new System.Windows.Forms.Button();
            this.btnUsuarios = new System.Windows.Forms.Button();
            this.btnReportes = new System.Windows.Forms.Button();
            this.btnCerrarSesion = new System.Windows.Forms.Button();
            this.panelHeader.SuspendLayout();
            this.panelMenu.SuspendLayout();
            this.SuspendLayout();

            // ── FORM ────────────────────────────────────────────────
            this.BackColor = System.Drawing.Color.FromArgb(10, 25, 60);
            this.ClientSize = new System.Drawing.Size(420, 620);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sistema de Votaciones – Menú Principal";
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MenuForm_FormClosed);

            // ── PANEL HEADER ────────────────────────────────────────
            this.panelHeader.BackColor = System.Drawing.Color.FromArgb(8, 20, 55);
            this.panelHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelHeader.Height = 120;
            this.panelHeader.Controls.Add(this.lblTitulo);
            this.panelHeader.Controls.Add(this.lblSubtitulo);

            this.lblTitulo.AutoSize = false;
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.ForeColor = System.Drawing.Color.White;
            this.lblTitulo.Location = new System.Drawing.Point(0, 20);
            this.lblTitulo.Size = new System.Drawing.Size(420, 40);
            this.lblTitulo.Text = "SISTEMA DE VOTACIONES";
            this.lblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            this.lblSubtitulo.AutoSize = false;
            this.lblSubtitulo.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblSubtitulo.ForeColor = System.Drawing.Color.FromArgb(100, 180, 255);
            this.lblSubtitulo.Location = new System.Drawing.Point(0, 65);
            this.lblSubtitulo.Size = new System.Drawing.Size(420, 25);
            this.lblSubtitulo.Text = "Menú Principal";
            this.lblSubtitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            // ── LABEL BIENVENIDO ────────────────────────────────────
            this.lblBienvenido.AutoSize = false;
            this.lblBienvenido.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblBienvenido.ForeColor = System.Drawing.Color.FromArgb(200, 220, 255);
            this.lblBienvenido.Location = new System.Drawing.Point(20, 135);
            this.lblBienvenido.Name = "lblBienvenido";
            this.lblBienvenido.Size = new System.Drawing.Size(380, 28);
            this.lblBienvenido.Text = "👤  Bienvenido, Usuario";
            this.lblBienvenido.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

            // ── PANEL MENÚ ──────────────────────────────────────────
            this.panelMenu.BackColor = System.Drawing.Color.FromArgb(15, 40, 90);
            this.panelMenu.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelMenu.Location = new System.Drawing.Point(20, 175);
            this.panelMenu.Name = "panelMenu";
            this.panelMenu.Size = new System.Drawing.Size(380, 390);
            this.panelMenu.Controls.Add(this.btnVotar);
            this.panelMenu.Controls.Add(this.btnDatosGenerales);
            this.panelMenu.Controls.Add(this.btnPlanchas);
            this.panelMenu.Controls.Add(this.btnUsuarios);
            this.panelMenu.Controls.Add(this.btnReportes);
            this.panelMenu.Controls.Add(this.btnCerrarSesion);

            // ── HELPER — colores de botones ─────────────────────────
            System.Drawing.Color colorBoton = System.Drawing.Color.FromArgb(0, 55, 120);
            System.Drawing.Color colorBorde = System.Drawing.Color.FromArgb(100, 180, 255);
            System.Drawing.Color colorCerrar = System.Drawing.Color.FromArgb(110, 20, 20);
            System.Drawing.Color colorBordeCierre = System.Drawing.Color.FromArgb(255, 100, 100);

            // ── btnVotar ────────────────────────────────────────────
            this.btnVotar.BackColor = colorBoton;
            this.btnVotar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVotar.FlatAppearance.BorderColor = colorBorde;
            this.btnVotar.FlatAppearance.BorderSize = 1;
            this.btnVotar.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnVotar.ForeColor = System.Drawing.Color.White;
            this.btnVotar.Location = new System.Drawing.Point(20, 20);
            this.btnVotar.Name = "btnVotar";
            this.btnVotar.Size = new System.Drawing.Size(338, 48);
            this.btnVotar.Text = "🗳️   VOTAR";
            this.btnVotar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnVotar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnVotar.Padding = new System.Windows.Forms.Padding(12, 0, 0, 0);
            this.btnVotar.Click += new System.EventHandler(this.btnVotar_Click);

            // ── btnDatosGenerales ───────────────────────────────────
            this.btnDatosGenerales.BackColor = colorBoton;
            this.btnDatosGenerales.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDatosGenerales.FlatAppearance.BorderColor = colorBorde;
            this.btnDatosGenerales.FlatAppearance.BorderSize = 1;
            this.btnDatosGenerales.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnDatosGenerales.ForeColor = System.Drawing.Color.White;
            this.btnDatosGenerales.Location = new System.Drawing.Point(20, 80);
            this.btnDatosGenerales.Name = "btnDatosGenerales";
            this.btnDatosGenerales.Size = new System.Drawing.Size(338, 48);
            this.btnDatosGenerales.Text = "📊   DATOS GENERALES";
            this.btnDatosGenerales.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDatosGenerales.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDatosGenerales.Padding = new System.Windows.Forms.Padding(12, 0, 0, 0);
            this.btnDatosGenerales.Click += new System.EventHandler(this.btnDatosGenerales_Click);

            // ── btnPlanchas ─────────────────────────────────────────
            this.btnPlanchas.BackColor = colorBoton;
            this.btnPlanchas.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPlanchas.FlatAppearance.BorderColor = colorBorde;
            this.btnPlanchas.FlatAppearance.BorderSize = 1;
            this.btnPlanchas.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnPlanchas.ForeColor = System.Drawing.Color.White;
            this.btnPlanchas.Location = new System.Drawing.Point(20, 140);
            this.btnPlanchas.Name = "btnPlanchas";
            this.btnPlanchas.Size = new System.Drawing.Size(338, 48);
            this.btnPlanchas.Text = "🏛️   PLANCHAS ELECTORALES";
            this.btnPlanchas.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPlanchas.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPlanchas.Padding = new System.Windows.Forms.Padding(12, 0, 0, 0);
            this.btnPlanchas.Click += new System.EventHandler(this.btnPlanchas_Click);

            // ── btnUsuarios ─────────────────────────────────────────
            this.btnUsuarios.BackColor = colorBoton;
            this.btnUsuarios.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUsuarios.FlatAppearance.BorderColor = colorBorde;
            this.btnUsuarios.FlatAppearance.BorderSize = 1;
            this.btnUsuarios.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnUsuarios.ForeColor = System.Drawing.Color.White;
            this.btnUsuarios.Location = new System.Drawing.Point(20, 200);
            this.btnUsuarios.Name = "btnUsuarios";
            this.btnUsuarios.Size = new System.Drawing.Size(338, 48);
            this.btnUsuarios.Text = "👥   REGISTRO DE USUARIOS";
            this.btnUsuarios.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnUsuarios.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnUsuarios.Padding = new System.Windows.Forms.Padding(12, 0, 0, 0);
            this.btnUsuarios.Click += new System.EventHandler(this.btnUsuarios_Click);

            // ── btnReportes ─────────────────────────────────────────
            this.btnReportes.BackColor = colorBoton;
            this.btnReportes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReportes.FlatAppearance.BorderColor = colorBorde;
            this.btnReportes.FlatAppearance.BorderSize = 1;
            this.btnReportes.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnReportes.ForeColor = System.Drawing.Color.White;
            this.btnReportes.Location = new System.Drawing.Point(20, 260);
            this.btnReportes.Name = "btnReportes";
            this.btnReportes.Size = new System.Drawing.Size(338, 48);
            this.btnReportes.Text = "📄   REPORTES";
            this.btnReportes.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnReportes.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnReportes.Padding = new System.Windows.Forms.Padding(12, 0, 0, 0);
            this.btnReportes.Click += new System.EventHandler(this.btnReportes_Click); // ✅ AÑADIDO

            // ── btnCerrarSesion ─────────────────────────────────────
            this.btnCerrarSesion.BackColor = colorCerrar;
            this.btnCerrarSesion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCerrarSesion.FlatAppearance.BorderColor = colorBordeCierre;
            this.btnCerrarSesion.FlatAppearance.BorderSize = 1;
            this.btnCerrarSesion.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnCerrarSesion.ForeColor = System.Drawing.Color.White;
            this.btnCerrarSesion.Location = new System.Drawing.Point(20, 325);
            this.btnCerrarSesion.Name = "btnCerrarSesion";
            this.btnCerrarSesion.Size = new System.Drawing.Size(338, 48);
            this.btnCerrarSesion.Text = "🚪   CERRAR SESIÓN";
            this.btnCerrarSesion.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCerrarSesion.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCerrarSesion.Padding = new System.Windows.Forms.Padding(12, 0, 0, 0);
            this.btnCerrarSesion.Click += new System.EventHandler(this.btnCerrarSesion_Click);

            // ── Agregar controles al Form ───────────────────────────
            this.Controls.Add(this.panelHeader);
            this.Controls.Add(this.lblBienvenido);
            this.Controls.Add(this.panelMenu);

            this.panelHeader.ResumeLayout(false);
            this.panelMenu.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblSubtitulo;
        private System.Windows.Forms.Label lblBienvenido;
        private System.Windows.Forms.Panel panelMenu;
        private System.Windows.Forms.Button btnVotar;
        private System.Windows.Forms.Button btnDatosGenerales;
        private System.Windows.Forms.Button btnPlanchas;
        private System.Windows.Forms.Button btnUsuarios;
        private System.Windows.Forms.Button btnReportes;
        private System.Windows.Forms.Button btnCerrarSesion;
    }
}