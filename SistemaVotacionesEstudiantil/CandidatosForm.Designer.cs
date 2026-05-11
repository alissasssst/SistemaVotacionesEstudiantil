namespace SistemaVotacionesEstudiantil
{
    partial class CandidatosForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.dgvCandidatos = new System.Windows.Forms.DataGridView();
            this.btnNuevo = new System.Windows.Forms.Button();
            this.btnEditar = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.panelEdicion = new System.Windows.Forms.Panel();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.txtApellido = new System.Windows.Forms.TextBox();
            this.cmbPuesto = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCandidatos)).BeginInit();
            this.panelEdicion.SuspendLayout();
            this.SuspendLayout();

            // dgvCandidatos
            this.dgvCandidatos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCandidatos.Location = new System.Drawing.Point(12, 12);
            this.dgvCandidatos.Size = new System.Drawing.Size(550, 250);
            this.dgvCandidatos.ReadOnly = true;

            // Botones
            this.btnNuevo.Location = new System.Drawing.Point(12, 270);
            this.btnNuevo.Text = "Nuevo";
            this.btnNuevo.Click += new System.EventHandler(this.btnNuevo_Click);

            this.btnEditar.Location = new System.Drawing.Point(100, 270);
            this.btnEditar.Text = "Editar";
            this.btnEditar.Click += new System.EventHandler(this.btnEditar_Click);

            this.btnEliminar.Location = new System.Drawing.Point(188, 270);
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);

            // panelEdicion
            this.panelEdicion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelEdicion.Controls.Add(this.label1);
            this.panelEdicion.Controls.Add(this.label2);
            this.panelEdicion.Controls.Add(this.label3);
            this.panelEdicion.Controls.Add(this.txtNombre);
            this.panelEdicion.Controls.Add(this.txtApellido);
            this.panelEdicion.Controls.Add(this.cmbPuesto);
            this.panelEdicion.Controls.Add(this.btnGuardar);
            this.panelEdicion.Controls.Add(this.btnCancelar);
            this.panelEdicion.Location = new System.Drawing.Point(12, 310);
            this.panelEdicion.Size = new System.Drawing.Size(550, 150);
            this.panelEdicion.Visible = false;

            this.label1.Text = "Nombre:";
            this.label1.Location = new System.Drawing.Point(20, 20);
            this.txtNombre.Location = new System.Drawing.Point(100, 17);

            this.label2.Text = "Apellido:";
            this.label2.Location = new System.Drawing.Point(20, 50);
            this.txtApellido.Location = new System.Drawing.Point(100, 47);

            this.label3.Text = "Puesto:";
            this.label3.Location = new System.Drawing.Point(20, 80);
            this.cmbPuesto.Items.AddRange(new string[] { "Presidente", "Vicepresidente", "Secretario", "Tesorero" });
            this.cmbPuesto.SelectedIndex = 0;
            this.cmbPuesto.Location = new System.Drawing.Point(100, 77);

            this.txtNombre.Size = new System.Drawing.Size(150, 20);
            this.txtApellido.Size = new System.Drawing.Size(150, 20);
            this.cmbPuesto.Size = new System.Drawing.Size(150, 21);

            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.Location = new System.Drawing.Point(100, 110);
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);

            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.Location = new System.Drawing.Point(200, 110);
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);

            // Tamaños
            this.btnNuevo.Size = new System.Drawing.Size(80, 30);
            this.btnEditar.Size = new System.Drawing.Size(80, 30);
            this.btnEliminar.Size = new System.Drawing.Size(80, 30);

            // CandidatosForm
            this.ClientSize = new System.Drawing.Size(580, 480);
            this.Controls.Add(this.dgvCandidatos);
            this.Controls.Add(this.btnNuevo);
            this.Controls.Add(this.btnEditar);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.panelEdicion);
            this.Text = "Candidatos";
            this.Load += new System.EventHandler(this.CandidatosForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCandidatos)).EndInit();
            this.panelEdicion.ResumeLayout(false);
            this.panelEdicion.PerformLayout();
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.DataGridView dgvCandidatos;
        private System.Windows.Forms.Button btnNuevo;
        private System.Windows.Forms.Button btnEditar;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.Panel panelEdicion;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.TextBox txtApellido;
        private System.Windows.Forms.ComboBox cmbPuesto;
        private System.Windows.Forms.Label label1, label2, label3;
    }
}