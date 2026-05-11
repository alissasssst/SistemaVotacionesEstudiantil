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
            this.lblBienvenido = new System.Windows.Forms.Label();
            this.panelMenu = new System.Windows.Forms.Panel();
            this.btnVotar = new System.Windows.Forms.Button();
            this.btnDatosGenerales = new System.Windows.Forms.Button();
            this.btnPlanchas = new System.Windows.Forms.Button();
            this.btnUsuarios = new System.Windows.Forms.Button();
            this.btnReportes = new System.Windows.Forms.Button();
            this.btnCerrarSesion = new System.Windows.Forms.Button();
            this.panelMenu.SuspendLayout();
            this.SuspendLayout();

            // lblBienvenido
            this.lblBienvenido.AutoSize = true;
            this.lblBienvenido.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblBienvenido.Location = new System.Drawing.Point(30, 20);
            this.lblBienvenido.Name = "lblBienvenido";
            this.lblBienvenido.Size = new System.Drawing.Size(200, 25);
            this.lblBienvenido.Text = "Bienvenido, Usuario";

            // panelMenu
            this.panelMenu.BackColor = System.Drawing.Color.LightSteelBlue;
            this.panelMenu.Controls.Add(this.btnVotar);
            this.panelMenu.Controls.Add(this.btnDatosGenerales);
            this.panelMenu.Controls.Add(this.btnPlanchas);
            this.panelMenu.Controls.Add(this.btnUsuarios);
            this.panelMenu.Controls.Add(this.btnReportes);
            this.panelMenu.Controls.Add(this.btnCerrarSesion);
            this.panelMenu.Location = new System.Drawing.Point(30, 60);
            this.panelMenu.Name = "panelMenu";
            this.panelMenu.Size = new System.Drawing.Size(250, 350);
            this.panelMenu.Padding = new System.Windows.Forms.Padding(10);

            // btnVotar
            this.btnVotar.Location = new System.Drawing.Point(15, 15);
            this.btnVotar.Name = "btnVotar";
            this.btnVotar.Size = new System.Drawing.Size(220, 40);
            this.btnVotar.Text = "🗳️ Votar";
            this.btnVotar.UseVisualStyleBackColor = true;
            this.btnVotar.Click += new System.EventHandler(this.btnVotar_Click);

            // btnDatosGenerales
            this.btnDatosGenerales.Location = new System.Drawing.Point(15, 65);
            this.btnDatosGenerales.Name = "btnDatosGenerales";
            this.btnDatosGenerales.Size = new System.Drawing.Size(220, 40);
            this.btnDatosGenerales.Text = "📊 Datos Generales";
            this.btnDatosGenerales.UseVisualStyleBackColor = true;

            // btnPlanchas
            this.btnPlanchas.Location = new System.Drawing.Point(15, 115);
            this.btnPlanchas.Name = "btnPlanchas";
            this.btnPlanchas.Size = new System.Drawing.Size(220, 40);
            this.btnPlanchas.Text = "🏛️ Planchas Electorales";
            this.btnPlanchas.UseVisualStyleBackColor = true;
            this.btnPlanchas.Click += new System.EventHandler(this.btnPlanchas_Click);

            // btnUsuarios
            this.btnUsuarios.Location = new System.Drawing.Point(15, 165);
            this.btnUsuarios.Name = "btnUsuarios";
            this.btnUsuarios.Size = new System.Drawing.Size(220, 40);
            this.btnUsuarios.Text = "👥 Registro de Usuarios";
            this.btnUsuarios.UseVisualStyleBackColor = true;
            this.btnUsuarios.Click += new System.EventHandler(this.btnUsuarios_Click);

            // btnReportes
            this.btnReportes.Location = new System.Drawing.Point(15, 215);
            this.btnReportes.Name = "btnReportes";
            this.btnReportes.Size = new System.Drawing.Size(220, 40);
            this.btnReportes.Text = "📄 Reportes";
            this.btnReportes.UseVisualStyleBackColor = true;

            // btnCerrarSesion
            this.btnCerrarSesion.Location = new System.Drawing.Point(15, 280);
            this.btnCerrarSesion.Name = "btnCerrarSesion";
            this.btnCerrarSesion.Size = new System.Drawing.Size(220, 40);
            this.btnCerrarSesion.Text = "🚪 Cerrar sesión";
            this.btnCerrarSesion.UseVisualStyleBackColor = true;
            this.btnCerrarSesion.Click += new System.EventHandler(this.btnCerrarSesion_Click);

            // MenuForm
            this.ClientSize = new System.Drawing.Size(320, 450);
            this.Controls.Add(this.lblBienvenido);
            this.Controls.Add(this.panelMenu);
            this.Text = "Sistema de Votaciones – Menú Principal";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MenuForm_FormClosed);
            this.panelMenu.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();
        }

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