namespace SistemaVotacionesEstudiantil
{
    partial class PlanchasForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.dgvPlanchas = new System.Windows.Forms.DataGridView();
            this.btnNuevo = new System.Windows.Forms.Button();
            this.btnEditar = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.btnCandidatos = new System.Windows.Forms.Button();
            this.panelEdicion = new System.Windows.Forms.Panel();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.txtLogoUrl = new System.Windows.Forms.TextBox();
            this.chkActiva = new System.Windows.Forms.CheckBox();
            this.picLogo = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPlanchas)).BeginInit();
            this.panelEdicion.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).BeginInit();
            this.SuspendLayout();

            // dgvPlanchas
            this.dgvPlanchas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPlanchas.Location = new System.Drawing.Point(12, 12);
            this.dgvPlanchas.Name = "dgvPlanchas";
            this.dgvPlanchas.Size = new System.Drawing.Size(660, 300);
            this.dgvPlanchas.ReadOnly = true;
            this.dgvPlanchas.AllowUserToAddRows = false;
            this.dgvPlanchas.AllowUserToDeleteRows = false;

            // Botones principales
            this.btnNuevo.Location = new System.Drawing.Point(12, 320);
            this.btnNuevo.Text = "Nuevo";
            this.btnNuevo.Click += new System.EventHandler(this.btnNuevo_Click);

            this.btnEditar.Location = new System.Drawing.Point(100, 320);
            this.btnEditar.Text = "Editar";
            this.btnEditar.Click += new System.EventHandler(this.btnEditar_Click);

            this.btnEliminar.Location = new System.Drawing.Point(188, 320);
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);

            this.btnCandidatos.Location = new System.Drawing.Point(276, 320);
            this.btnCandidatos.Text = "Candidatos";
            this.btnCandidatos.Click += new System.EventHandler(this.btnCandidatos_Click);

            // panelEdicion
            this.panelEdicion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelEdicion.Controls.Add(this.label1);
            this.panelEdicion.Controls.Add(this.label2);
            this.panelEdicion.Controls.Add(this.txtNombre);
            this.panelEdicion.Controls.Add(this.txtLogoUrl);
            this.panelEdicion.Controls.Add(this.chkActiva);
            this.panelEdicion.Controls.Add(this.picLogo);
            this.panelEdicion.Controls.Add(this.btnGuardar);
            this.panelEdicion.Controls.Add(this.btnCancelar);
            this.panelEdicion.Location = new System.Drawing.Point(12, 360);
            this.panelEdicion.Size = new System.Drawing.Size(660, 200);
            this.panelEdicion.Visible = false;

            // labels y campos
            this.label1.Text = "Nombre:";
            this.label1.Location = new System.Drawing.Point(20, 20);
            this.txtNombre.Location = new System.Drawing.Point(100, 17);
            this.txtNombre.Size = new System.Drawing.Size(200, 20);

            this.label2.Text = "Logo (ruta):";
            this.label2.Location = new System.Drawing.Point(20, 55);
            this.txtLogoUrl.Location = new System.Drawing.Point(100, 52);
            this.txtLogoUrl.Size = new System.Drawing.Size(200, 20);

            this.chkActiva.Text = "Activa";
            this.chkActiva.Location = new System.Drawing.Point(100, 85);
            this.chkActiva.Checked = true;

            this.picLogo.Location = new System.Drawing.Point(320, 20);
            this.picLogo.Size = new System.Drawing.Size(100, 100);
            this.picLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;

            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.Location = new System.Drawing.Point(100, 150);
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);

            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.Location = new System.Drawing.Point(200, 150);
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);

            // Tamaños de botones
            this.btnNuevo.Size = new System.Drawing.Size(80, 30);
            this.btnEditar.Size = new System.Drawing.Size(80, 30);
            this.btnEliminar.Size = new System.Drawing.Size(80, 30);
            this.btnCandidatos.Size = new System.Drawing.Size(80, 30);

            // PlanchasForm
            this.ClientSize = new System.Drawing.Size(690, 580);
            this.Controls.Add(this.dgvPlanchas);
            this.Controls.Add(this.btnNuevo);
            this.Controls.Add(this.btnEditar);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.btnCandidatos);
            this.Controls.Add(this.panelEdicion);
            this.Text = "Planchas Electorales";
            this.Load += new System.EventHandler(this.PlanchasForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPlanchas)).EndInit();
            this.panelEdicion.ResumeLayout(false);
            this.panelEdicion.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).EndInit();
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.DataGridView dgvPlanchas;
        private System.Windows.Forms.Button btnNuevo;
        private System.Windows.Forms.Button btnEditar;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.Button btnCandidatos;
        private System.Windows.Forms.Panel panelEdicion;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.TextBox txtLogoUrl;
        private System.Windows.Forms.CheckBox chkActiva;
        private System.Windows.Forms.PictureBox picLogo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}