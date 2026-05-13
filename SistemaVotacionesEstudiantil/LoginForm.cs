using System;
using System.Linq;
using System.Windows.Forms;
using SistemaVotacionesEstudiantil.Data;

namespace SistemaVotacionesEstudiantil
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            string mat = txtMatricula.Text.Trim();
            string pass = txtPassword.Text;

            using (var db = new AppDbContext())
            {
                var usuario = db.Usuarios.FirstOrDefault(u => u.Matricula == mat);
                if (usuario == null || !BCrypt.Net.BCrypt.Verify(pass, usuario.PasswordHash))
                {
                    lblError.Text = "Matrícula o contraseña incorrecta.";
                    lblError.Visible = true;
                    return;
                }

                Sesion.UsuarioActual = usuario;
                var menu = new MenuForm();
                menu.Show();
                this.Hide();
            }
        }

        private void LoginForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}