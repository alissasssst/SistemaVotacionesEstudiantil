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
            // Cerrar sesión y volver al login
            Sesion.UsuarioActual = null;
            var login = new LoginForm();
            login.Show();
            this.Close();
        }

        private void MenuForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void btnUsuarios_Click(object sender, EventArgs e)
        {
            var form = new UsuariosForm();
            form.ShowDialog(); // Abre como ventana modal (o Show() si prefieres)
        }
    }
}