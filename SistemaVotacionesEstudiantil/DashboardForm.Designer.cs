namespace SistemaVotacionesEstudiantil
{
    partial class DashboardForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.lblPeriodo = new System.Windows.Forms.Label();
            this.lblTiempoRestante = new System.Windows.Forms.Label();
            this.lblVotantesRegistrados = new System.Windows.Forms.Label();
            this.lblVotosEmitidos = new System.Windows.Forms.Label();
            this.lblVotosNulos = new System.Windows.Forms.Label();
            this.lblParticipacion = new System.Windows.Forms.Label();
            this.dgvResultados = new System.Windows.Forms.DataGridView();
            this.btnActualizar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvResultados)).BeginInit();
            this.SuspendLayout();

            // lblPeriodo
            this.lblPeriodo.AutoSize = true;
            this.lblPeriodo.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblPeriodo.Location = new System.Drawing.Point(20, 20);
            this.lblPeriodo.Text = "Período activo:";

            // lblTiempoRestante
            this.lblTiempoRestante.AutoSize = true;
            this.lblTiempoRestante.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblTiempoRestante.Location = new System.Drawing.Point(20, 50);
            this.lblTiempoRestante.Text = "Tiempo restante:";

            // lblVotantesRegistrados
            this.lblVotantesRegistrados.AutoSize = true;
            this.lblVotantesRegistrados.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblVotantesRegistrados.Location = new System.Drawing.Point(20, 90);
            this.lblVotantesRegistrados.Text = "Votantes registrados:";

            // lblVotosEmitidos
            this.lblVotosEmitidos.AutoSize = true;
            this.lblVotosEmitidos.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblVotosEmitidos.Location = new System.Drawing.Point(20, 120);
            this.lblVotosEmitidos.Text = "Votos emitidos:";

            // lblVotosNulos
            this.lblVotosNulos.AutoSize = true;
            this.lblVotosNulos.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblVotosNulos.Location = new System.Drawing.Point(20, 150);
            this.lblVotosNulos.Text = "Votos nulos:";

            // lblParticipacion
            this.lblParticipacion.AutoSize = true;
            this.lblParticipacion.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblParticipacion.Location = new System.Drawing.Point(20, 180);
            this.lblParticipacion.Text = "Participación:";

            // dgvResultados
            this.dgvResultados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvResultados.Location = new System.Drawing.Point(20, 220);
            this.dgvResultados.Name = "dgvResultados";
            this.dgvResultados.Size = new System.Drawing.Size(500, 200);
            this.dgvResultados.ReadOnly = true;
            this.dgvResultados.AllowUserToAddRows = false;

            // btnActualizar
            this.btnActualizar.Location = new System.Drawing.Point(20, 440);
            this.btnActualizar.Name = "btnActualizar";
            this.btnActualizar.Size = new System.Drawing.Size(100, 30);
            this.btnActualizar.Text = "Actualizar";
            this.btnActualizar.UseVisualStyleBackColor = true;
            this.btnActualizar.Click += new System.EventHandler(this.btnActualizar_Click);

            // DashboardForm
            this.ClientSize = new System.Drawing.Size(550, 500);
            this.Controls.Add(this.lblPeriodo);
            this.Controls.Add(this.lblTiempoRestante);
            this.Controls.Add(this.lblVotantesRegistrados);
            this.Controls.Add(this.lblVotosEmitidos);
            this.Controls.Add(this.lblVotosNulos);
            this.Controls.Add(this.lblParticipacion);
            this.Controls.Add(this.dgvResultados);
            this.Controls.Add(this.btnActualizar);
            this.Text = "Datos Generales";
            this.Load += new System.EventHandler(this.DashboardForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvResultados)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Label lblPeriodo;
        private System.Windows.Forms.Label lblTiempoRestante;
        private System.Windows.Forms.Label lblVotantesRegistrados;
        private System.Windows.Forms.Label lblVotosEmitidos;
        private System.Windows.Forms.Label lblVotosNulos;
        private System.Windows.Forms.Label lblParticipacion;
        private System.Windows.Forms.DataGridView dgvResultados;
        private System.Windows.Forms.Button btnActualizar;
    }
}