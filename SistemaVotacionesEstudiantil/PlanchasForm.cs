using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using SistemaVotacionesEstudiantil.Data;
using SistemaVotacionesEstudiantil.Models;

namespace SistemaVotacionesEstudiantil
{
    public partial class PlanchasForm : Form
    {
        private AppDbContext db = new AppDbContext();
        private Plancha planchaSeleccionada = null;

        public PlanchasForm()
        {
            InitializeComponent();
        }

        private void PlanchasForm_Load(object sender, EventArgs e)
        {
            if (Sesion.UsuarioActual == null)
            {
                MessageBox.Show("Debe iniciar sesión.");
                Close();
                return;
            }
            CargarPlanchas();
            OcultarPanelEdicion();
        }

        private void CargarPlanchas()
        {
            var planchas = db.Planchas.ToList();
            dgvPlanchas.DataSource = planchas.Select(p => new
            {
                p.Id,
                p.Nombre,
                p.LogoUrl,
                p.Activa
            }).ToList();
            if (dgvPlanchas.Columns.Contains("Id"))
                dgvPlanchas.Columns["Id"].Visible = false;
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            planchaSeleccionada = null;
            txtNombre.Clear();
            txtLogoUrl.Clear();
            picLogo.Image = null;
            chkActiva.Checked = true;
            panelEdicion.Visible = true;
            btnGuardar.Text = "Guardar Nueva";
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dgvPlanchas.SelectedRows.Count == 0) return;
            int id = (int)dgvPlanchas.SelectedRows[0].Cells["Id"].Value;
            planchaSeleccionada = db.Planchas.Find(id);
            if (planchaSeleccionada != null)
            {
                txtNombre.Text = planchaSeleccionada.Nombre;
                txtLogoUrl.Text = planchaSeleccionada.LogoUrl;
                chkActiva.Checked = planchaSeleccionada.Activa;
                if (!string.IsNullOrEmpty(planchaSeleccionada.LogoUrl) && File.Exists(planchaSeleccionada.LogoUrl))
                    picLogo.Image = Image.FromFile(planchaSeleccionada.LogoUrl);
                else
                    picLogo.Image = null;
                panelEdicion.Visible = true;
                btnGuardar.Text = "Guardar Cambios";
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvPlanchas.SelectedRows.Count == 0) return;
            int id = (int)dgvPlanchas.SelectedRows[0].Cells["Id"].Value;
            var plancha = db.Planchas.Find(id);
            if (plancha != null)
            {
                var result = MessageBox.Show($"¿Eliminar la plancha {plancha.Nombre}?", "Confirmar", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    db.Planchas.Remove(plancha);
                    db.SaveChanges();
                    CargarPlanchas();
                }
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNombre.Text))
            {
                MessageBox.Show("El nombre es obligatorio.");
                return;
            }

            string logoUrl = txtLogoUrl.Text.Trim();
            if (planchaSeleccionada == null) // Nueva
            {
                var nueva = new Plancha
                {
                    Nombre = txtNombre.Text.Trim(),
                    LogoUrl = logoUrl,
                    Activa = chkActiva.Checked
                };
                db.Planchas.Add(nueva);
            }
            else // Editar
            {
                planchaSeleccionada.Nombre = txtNombre.Text.Trim();
                planchaSeleccionada.LogoUrl = logoUrl;
                planchaSeleccionada.Activa = chkActiva.Checked;
                db.Entry(planchaSeleccionada).State = System.Data.Entity.EntityState.Modified;
            }
            db.SaveChanges();
            CargarPlanchas();
            OcultarPanelEdicion();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            OcultarPanelEdicion();
        }

        private void btnCandidatos_Click(object sender, EventArgs e)
        {
            if (dgvPlanchas.SelectedRows.Count == 0)
            {
                MessageBox.Show("Seleccione una plancha primero.");
                return;
            }
            int id = (int)dgvPlanchas.SelectedRows[0].Cells["Id"].Value;
            var plancha = db.Planchas.Find(id);
            if (plancha != null)
            {
                var candidatosForm = new CandidatosForm(plancha);
                candidatosForm.ShowDialog();
                CargarPlanchas(); // por si se modificaron los candidatos (aunque aquí no afecta la tabla plancha)
            }
        }

        private void OcultarPanelEdicion()
        {
            panelEdicion.Visible = false;
            txtNombre.Clear();
            txtLogoUrl.Clear();
            picLogo.Image = null;
            chkActiva.Checked = true;
        }
    }
}