namespace SistemaVotacionesEstudiantil
{
    partial class VotacionForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.lblUsuario = new System.Windows.Forms.Label();
            this.panelPlanchas = new System.Windows.Forms.FlowLayoutPanel();
            this.SuspendLayout();

            // lblUsuario
            this.lblUsuario.AutoSize = true;
            this.lblUsuario.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lblUsuario.Location = new System.Drawing.Point(12, 9);
            this.lblUsuario.Name = "lblUsuario";
            this.lblUsuario.Size = new System.Drawing.Size(180, 21);

            // panelPlanchas (FlowLayoutPanel para tarjetas)
            this.panelPlanchas.AutoScroll = true;
            this.panelPlanchas.Location = new System.Drawing.Point(12, 40);
            this.panelPlanchas.Name = "panelPlanchas";
            this.panelPlanchas.Size = new System.Drawing.Size(340, 400);
            this.panelPlanchas.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.panelPlanchas.WrapContents = false;

            // VotacionForm
            this.ClientSize = new System.Drawing.Size(370, 460);
            this.Controls.Add(this.lblUsuario);
            this.Controls.Add(this.panelPlanchas);
            this.Text = "Emitir Voto";
            this.Load += new System.EventHandler(this.VotacionForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Label lblUsuario;
        private System.Windows.Forms.FlowLayoutPanel panelPlanchas;
    }
}