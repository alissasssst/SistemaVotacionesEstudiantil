using System;
using System.Windows.Forms;

namespace SistemaVotacionesEstudiantil
{
    public partial class MenuForm : Form
    {
        public MenuForm()
        {
            InitializeComponent();
            lblBienvenido.Text = $"Bienvenido, {Sesion.UsuarioActual?.Nombre ?? "Invitado"}";
        }

        private void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            Sesion.UsuarioActual = null;
            var login = new LoginForm();
            login.Show();
            this.Close();
        }

        private void btnVotar_Click(object sender, EventArgs e)
        {
            if (Sesion.UsuarioActual == null)
            {
                MessageBox.Show("Debe iniciar sesión.");
                return;
            }
            var form = new VotacionForm();
            form.ShowDialog();
        }

        private void btnPlanchas_Click(object sender, EventArgs e)
        {
            var form = new PlanchasForm();
            form.ShowDialog();
        }

        private void btnUsuarios_Click(object sender, EventArgs e)
        {
            var form = new UsuariosForm();
            form.ShowDialog();
        }

        // Los demás botones (Datos Generales, Reportes) los implementaremos en próximos módulos.
        // Por ahora los dejamos sin manejador, pero no deberían causar errores.

        private void MenuForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}