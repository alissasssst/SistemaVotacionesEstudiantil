using System;
using System.Linq;
using System.Windows.Forms;
using SistemaVotacionesEstudiantil.Data;
using SistemaVotacionesEstudiantil.Models;

namespace SistemaVotacionesEstudiantil
{
    public partial class UsuariosForm : Form
    {
        private AppDbContext db = new AppDbContext();
        private Usuario usuarioSeleccionado = null;

        public UsuariosForm()
        {
            InitializeComponent();
        }

        private void UsuariosForm_Load(object sender, EventArgs e)
        {
            if (Sesion.UsuarioActual == null)
            {
                MessageBox.Show("Debe iniciar sesión.");
                this.Close();
                return;
            }
            CargarUsuarios();
            OcultarPanelEdicion();
        }

        private void CargarUsuarios()
        {
            var usuarios = db.Usuarios.Include("PadronElectoral").ToList();
            dgvUsuarios.DataSource = usuarios.Select(u => new
            {
                u.Id,
                u.Matricula,
                u.Nombre,
                u.Apellido,
                u.Curso,
                u.Seccion,
                u.Rol,
                Padron = u.PadronElectoral?.Nombre ?? "Sin padrón"
            }).ToList();

            if (dgvUsuarios.Columns.Contains("Id"))
                dgvUsuarios.Columns["Id"].Visible = false;
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            usuarioSeleccionado = null;
            LimpiarCampos();
            panelEdicion.Visible = true;
            btnGuardar.Text = "Guardar Nuevo";
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dgvUsuarios.SelectedRows.Count == 0) return;
            int id = (int)dgvUsuarios.SelectedRows[0].Cells["Id"].Value;
            usuarioSeleccionado = db.Usuarios.Find(id);
            if (usuarioSeleccionado != null)
            {
                txtMatricula.Text = usuarioSeleccionado.Matricula;
                txtNombre.Text = usuarioSeleccionado.Nombre;
                txtApellido.Text = usuarioSeleccionado.Apellido;
                txtCurso.Text = usuarioSeleccionado.Curso;
                txtSeccion.Text = usuarioSeleccionado.Seccion;
                cmbRol.SelectedItem = usuarioSeleccionado.Rol;
                txtPassword.Clear();
                panelEdicion.Visible = true;
                btnGuardar.Text = "Guardar Cambios";
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvUsuarios.SelectedRows.Count == 0) return;
            int id = (int)dgvUsuarios.SelectedRows[0].Cells["Id"].Value;
            var usuario = db.Usuarios.Find(id);
            if (usuario != null)
            {
                var result = MessageBox.Show($"¿Eliminar a {usuario.Nombre}?", "Confirmar", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    db.Usuarios.Remove(usuario);
                    db.SaveChanges();
                    CargarUsuarios();
                }
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMatricula.Text) || string.IsNullOrWhiteSpace(txtNombre.Text))
            {
                MessageBox.Show("Matrícula y Nombre son obligatorios.");
                return;
            }

            string password = txtPassword.Text.Trim();

            if (usuarioSeleccionado == null && password.Length == 0)
            {
                MessageBox.Show("Debe asignar una contraseña.");
                return;
            }

            if (usuarioSeleccionado == null) // Nuevo
            {
                var nuevo = new Usuario
                {
                    Matricula = txtMatricula.Text.Trim(),
                    Nombre = txtNombre.Text.Trim(),
                    Apellido = txtApellido.Text.Trim(),
                    Curso = txtCurso.Text.Trim(),
                    Seccion = txtSeccion.Text.Trim(),
                    Rol = cmbRol.SelectedItem?.ToString() ?? "Votante",
                    PasswordHash = BCrypt.Net.BCrypt.HashPassword(password),
                    PadronElectoralId = null
                };
                db.Usuarios.Add(nuevo);
            }
            else // Editar
            {
                usuarioSeleccionado.Matricula = txtMatricula.Text.Trim();
                usuarioSeleccionado.Nombre = txtNombre.Text.Trim();
                usuarioSeleccionado.Apellido = txtApellido.Text.Trim();
                usuarioSeleccionado.Curso = txtCurso.Text.Trim();
                usuarioSeleccionado.Seccion = txtSeccion.Text.Trim();
                usuarioSeleccionado.Rol = cmbRol.SelectedItem?.ToString() ?? "Votante";
                if (!string.IsNullOrEmpty(password))
                {
                    usuarioSeleccionado.PasswordHash = BCrypt.Net.BCrypt.HashPassword(password);
                }
                db.Entry(usuarioSeleccionado).State = System.Data.Entity.EntityState.Modified;
            }
            db.SaveChanges();
            CargarUsuarios();
            OcultarPanelEdicion();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            OcultarPanelEdicion();
        }

        private void LimpiarCampos()
        {
            txtMatricula.Clear();
            txtNombre.Clear();
            txtApellido.Clear();
            txtCurso.Clear();
            txtSeccion.Clear();
            cmbRol.SelectedIndex = 0;
            txtPassword.Clear();
        }

        private void OcultarPanelEdicion()
        {
            panelEdicion.Visible = false;
            LimpiarCampos();
        }
    }
}