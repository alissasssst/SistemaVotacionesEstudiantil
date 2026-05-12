namespace SistemaVotacionesEstudiantil
{
    partial class LoginForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.txtMatricula = new System.Windows.Forms.TextBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.btnIngresar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblError = new System.Windows.Forms.Label();
            this.SuspendLayout();

            // txtMatricula
            this.txtMatricula.Location = new System.Drawing.Point(120, 40);
            this.txtMatricula.Name = "txtMatricula";
            this.txtMatricula.Size = new System.Drawing.Size(200, 20);

            // txtPassword
            this.txtPassword.Location = new System.Drawing.Point(120, 80);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(200, 20);
            this.txtPassword.PasswordChar = '*';

            // btnIngresar
            this.btnIngresar.Location = new System.Drawing.Point(150, 130);
            this.btnIngresar.Name = "btnIngresar";
            this.btnIngresar.Size = new System.Drawing.Size(100, 30);
            this.btnIngresar.Text = "Ingresar";
            this.btnIngresar.UseVisualStyleBackColor = true;
            this.btnIngresar.Click += new System.EventHandler(this.btnIngresar_Click);

            // label1
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(50, 43);
            this.label1.Text = "Matrícula:";

            // label2
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(50, 83);
            this.label2.Text = "Contraseña:";

            // lblError
            this.lblError.AutoSize = true;
            this.lblError.ForeColor = System.Drawing.Color.Red;
            this.lblError.Location = new System.Drawing.Point(80, 105);
            this.lblError.Visible = false;

            // LoginForm
            this.ClientSize = new System.Drawing.Size(400, 200);
            this.Controls.Add(this.txtMatricula);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.btnIngresar);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblError);
            this.Text = "Login - Sistema de Votaciones";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.LoginForm_FormClosed);
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.TextBox txtMatricula;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Button btnIngresar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblError;
    }
}