using System;
using System.Linq;
using System.Windows.Forms;
using SistemaVotacionesEstudiantil.Data;
using SistemaVotacionesEstudiantil.Models;

namespace SistemaVotacionesEstudiantil
{
    public partial class CandidatosForm : Form
    {
        private AppDbContext db = new AppDbContext();
        private Plancha plancha;
        private Candidato candidatoSeleccionado = null;

        public CandidatosForm(Plancha plancha)
        {
            InitializeComponent();
            this.plancha = plancha;
            Text = $"Candidatos de {plancha.Nombre}";
        }

        private void CandidatosForm_Load(object sender, EventArgs e)
        {
            CargarCandidatos();
            OcultarPanel();
        }

        private void CargarCandidatos()
        {
            var candidatos = db.Candidatos.Where(c => c.PlanchaId == plancha.Id).ToList();
            dgvCandidatos.DataSource = candidatos.Select(c => new
            {
                c.Id,
                c.Nombre,
                c.Apellido,
                c.Puesto
            }).ToList();

            if (dgvCandidatos.Columns.Contains("Id"))
                dgvCandidatos.Columns["Id"].Visible = false;
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            candidatoSeleccionado = null;
            txtNombre.Clear();
            txtApellido.Clear();
            cmbPuesto.SelectedIndex = 0;
            panelEdicion.Visible = true;
            btnGuardar.Text = "Agregar";
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dgvCandidatos.SelectedRows.Count == 0) return;
            int id = (int)dgvCandidatos.SelectedRows[0].Cells["Id"].Value;
            candidatoSeleccionado = db.Candidatos.Find(id);
            if (candidatoSeleccionado != null)
            {
                txtNombre.Text = candidatoSeleccionado.Nombre;
                txtApellido.Text = candidatoSeleccionado.Apellido;
                cmbPuesto.SelectedItem = candidatoSeleccionado.Puesto;
                panelEdicion.Visible = true;
                btnGuardar.Text = "Guardar Cambios";
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvCandidatos.SelectedRows.Count == 0) return;
            int id = (int)dgvCandidatos.SelectedRows[0].Cells["Id"].Value;
            var candidato = db.Candidatos.Find(id);
            if (candidato != null)
            {
                var result = MessageBox.Show($"¿Eliminar a {candidato.Nombre}?", "Confirmar", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    db.Candidatos.Remove(candidato);
                    db.SaveChanges();
                    CargarCandidatos();
                }
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNombre.Text) || string.IsNullOrWhiteSpace(txtApellido.Text))
            {
                MessageBox.Show("Nombre y Apellido son obligatorios.");
                return;
            }

            string puesto = cmbPuesto.SelectedItem?.ToString();

            if (candidatoSeleccionado == null) // Nuevo
            {
                var nuevo = new Candidato
                {
                    Nombre = txtNombre.Text.Trim(),
                    Apellido = txtApellido.Text.Trim(),
                    Puesto = puesto,
                    PlanchaId = plancha.Id
                };
                db.Candidatos.Add(nuevo);
            }
            else // Editar
            {
                candidatoSeleccionado.Nombre = txtNombre.Text.Trim();
                candidatoSeleccionado.Apellido = txtApellido.Text.Trim();
                candidatoSeleccionado.Puesto = puesto;
                db.Entry(candidatoSeleccionado).State = System.Data.Entity.EntityState.Modified;
            }
            db.SaveChanges();
            CargarCandidatos();
            OcultarPanel();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            OcultarPanel();
        }

        private void OcultarPanel()
        {
            panelEdicion.Visible = false;
            txtNombre.Clear();
            txtApellido.Clear();
            cmbPuesto.SelectedIndex = 0;
        }
    }
}