namespace SistemaVotacionesEstudiantil
{
    partial class UsuariosForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.dgvUsuarios = new System.Windows.Forms.DataGridView();
            this.btnNuevo = new System.Windows.Forms.Button();
            this.btnEditar = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.panelEdicion = new System.Windows.Forms.Panel();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.txtMatricula = new System.Windows.Forms.TextBox();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.txtApellido = new System.Windows.Forms.TextBox();
            this.txtCurso = new System.Windows.Forms.TextBox();
            this.txtSeccion = new System.Windows.Forms.TextBox();
            this.cmbRol = new System.Windows.Forms.ComboBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsuarios)).BeginInit();
            this.panelEdicion.SuspendLayout();
            this.SuspendLayout();

            // dgvUsuarios
            this.dgvUsuarios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvUsuarios.Location = new System.Drawing.Point(12, 12);
            this.dgvUsuarios.Name = "dgvUsuarios";
            this.dgvUsuarios.Size = new System.Drawing.Size(660, 300);
            this.dgvUsuarios.ReadOnly = true;
            this.dgvUsuarios.AllowUserToAddRows = false;
            this.dgvUsuarios.AllowUserToDeleteRows = false;

            // btnNuevo
            this.btnNuevo.Location = new System.Drawing.Point(12, 320);
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.Size = new System.Drawing.Size(75, 30);
            this.btnNuevo.Text = "Nuevo";
            this.btnNuevo.UseVisualStyleBackColor = true;
            this.btnNuevo.Click += new System.EventHandler(this.btnNuevo_Click);

            // btnEditar
            this.btnEditar.Location = new System.Drawing.Point(100, 320);
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(75, 30);
            this.btnEditar.Text = "Editar";
            this.btnEditar.UseVisualStyleBackColor = true;
            this.btnEditar.Click += new System.EventHandler(this.btnEditar_Click);

            // btnEliminar
            this.btnEliminar.Location = new System.Drawing.Point(188, 320);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(75, 30);
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.UseVisualStyleBackColor = true;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);

            // panelEdicion
            this.panelEdicion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelEdicion.Controls.Add(this.btnCancelar);
            this.panelEdicion.Controls.Add(this.btnGuardar);
            this.panelEdicion.Controls.Add(this.label1);
            this.panelEdicion.Controls.Add(this.label2);
            this.panelEdicion.Controls.Add(this.label3);
            this.panelEdicion.Controls.Add(this.label4);
            this.panelEdicion.Controls.Add(this.label5);
            this.panelEdicion.Controls.Add(this.label6);
            this.panelEdicion.Controls.Add(this.label7);
            this.panelEdicion.Controls.Add(this.txtMatricula);
            this.panelEdicion.Controls.Add(this.txtNombre);
            this.panelEdicion.Controls.Add(this.txtApellido);
            this.panelEdicion.Controls.Add(this.txtCurso);
            this.panelEdicion.Controls.Add(this.txtSeccion);
            this.panelEdicion.Controls.Add(this.cmbRol);
            this.panelEdicion.Controls.Add(this.txtPassword);
            this.panelEdicion.Location = new System.Drawing.Point(12, 360);
            this.panelEdicion.Name = "panelEdicion";
            this.panelEdicion.Size = new System.Drawing.Size(660, 200);
            this.panelEdicion.Visible = false;

            // Labels & TextBoxes
            this.label1.Text = "Matrícula:";
            this.label1.Location = new System.Drawing.Point(30, 20);
            this.txtMatricula.Location = new System.Drawing.Point(120, 17);

            this.label2.Text = "Nombre:";
            this.label2.Location = new System.Drawing.Point(30, 50);
            this.txtNombre.Location = new System.Drawing.Point(120, 47);

            this.label3.Text = "Apellido:";
            this.label3.Location = new System.Drawing.Point(30, 80);
            this.txtApellido.Location = new System.Drawing.Point(120, 77);

            this.label4.Text = "Curso:";
            this.label4.Location = new System.Drawing.Point(300, 20);
            this.txtCurso.Location = new System.Drawing.Point(380, 17);

            this.label5.Text = "Sección:";
            this.label5.Location = new System.Drawing.Point(300, 50);
            this.txtSeccion.Location = new System.Drawing.Point(380, 47);

            this.label6.Text = "Rol:";
            this.label6.Location = new System.Drawing.Point(300, 80);
            this.cmbRol.Items.AddRange(new string[] { "Votante", "Admin", "Partido" });
            this.cmbRol.SelectedIndex = 0;
            this.cmbRol.Location = new System.Drawing.Point(380, 77);

            this.label7.Text = "Contraseña:";
            this.label7.Location = new System.Drawing.Point(30, 110);
            this.txtPassword.Location = new System.Drawing.Point(120, 107);
            this.txtPassword.UseSystemPasswordChar = true;

            // Tamaños
            this.txtMatricula.Size = new System.Drawing.Size(150, 20);
            this.txtNombre.Size = new System.Drawing.Size(150, 20);
            this.txtApellido.Size = new System.Drawing.Size(150, 20);
            this.txtCurso.Size = new System.Drawing.Size(150, 20);
            this.txtSeccion.Size = new System.Drawing.Size(150, 20);
            this.cmbRol.Size = new System.Drawing.Size(150, 21);
            this.txtPassword.Size = new System.Drawing.Size(150, 20);

            // Botones guardar/cancelar
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.Location = new System.Drawing.Point(150, 150);
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);

            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.Location = new System.Drawing.Point(250, 150);
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);

            // UsuariosForm
            this.ClientSize = new System.Drawing.Size(690, 580);
            this.Controls.Add(this.dgvUsuarios);
            this.Controls.Add(this.btnNuevo);
            this.Controls.Add(this.btnEditar);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.panelEdicion);
            this.Text = "Registro de Usuarios";
            this.Load += new System.EventHandler(this.UsuariosForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsuarios)).EndInit();
            this.panelEdicion.ResumeLayout(false);
            this.panelEdicion.PerformLayout();
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.DataGridView dgvUsuarios;
        private System.Windows.Forms.Button btnNuevo;
        private System.Windows.Forms.Button btnEditar;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.Panel panelEdicion;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.TextBox txtMatricula;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.TextBox txtApellido;
        private System.Windows.Forms.TextBox txtCurso;
        private System.Windows.Forms.TextBox txtSeccion;
        private System.Windows.Forms.ComboBox cmbRol;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Label label1, label2, label3, label4, label5, label6, label7;
    }
}