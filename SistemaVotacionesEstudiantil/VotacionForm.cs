using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using SistemaVotacionesEstudiantil.Data;
using SistemaVotacionesEstudiantil.Models;

namespace SistemaVotacionesEstudiantil
{
    public partial class VotacionForm : Form
    {
        private AppDbContext db = new AppDbContext();
        private Usuario usuarioActual;

        public VotacionForm()
        {
            InitializeComponent();
            usuarioActual = Sesion.UsuarioActual;
        }

        private void VotacionForm_Load(object sender, EventArgs e)
        {
            if (usuarioActual == null)
            {
                MessageBox.Show("Debe iniciar sesión.");
                Close();
                return;
            }

            // Verificar si ya votó
            if (db.Votaciones.Any(v => v.UsuarioId == usuarioActual.Id))
            {
                MessageBox.Show("Usted ya ha emitido su voto.");
                Close();
                return;
            }

            // Verificar período electoral activo
            var periodoActivo = db.PeriodosElectorales.FirstOrDefault(p => p.Activo && DateTime.Now >= p.FechaInicio && DateTime.Now <= p.FechaFin);
            if (periodoActivo == null)
            {
                MessageBox.Show("No hay un período electoral activo en este momento.");
                Close();
                return;
            }

            lblUsuario.Text = $"Votante: {usuarioActual.Nombre} {usuarioActual.Apellido}";
            CargarPlanchas();
        }

        private void CargarPlanchas()
        {
            var planchas = db.Planchas.Where(p => p.Activa).ToList();
            panelPlanchas.Controls.Clear();

            int yPos = 10;
            foreach (var plancha in planchas)
            {
                // Crear un panel para cada plancha (similar a una tarjeta)
                Panel card = new Panel
                {
                    Width = 300,
                    Height = 180,
                    Top = yPos,
                    Left = 10,
                    BorderStyle = BorderStyle.FixedSingle,
                    BackColor = Color.LightCyan
                };

                // Logo (si existe)
                if (!string.IsNullOrEmpty(plancha.LogoUrl) && File.Exists(plancha.LogoUrl))
                {
                    PictureBox pic = new PictureBox
                    {
                        Image = Image.FromFile(plancha.LogoUrl),
                        Width = 80,
                        Height = 80,
                        Top = 10,
                        Left = 10,
                        SizeMode = PictureBoxSizeMode.Zoom
                    };
                    card.Controls.Add(pic);
                }

                // Nombre de la plancha
                Label lblNombre = new Label
                {
                    Text = plancha.Nombre,
                    Font = new Font("Segoe UI", 12, FontStyle.Bold),
                    Top = 10,
                    Left = 100,
                    Width = 180
                };
                card.Controls.Add(lblNombre);

                // Candidatos
                var candidatos = db.Candidatos.Where(c => c.PlanchaId == plancha.Id).ToList();
                string textoCandidatos = string.Join("\n", candidatos.Select(c => $"{c.Puesto}: {c.Nombre} {c.Apellido}"));
                Label lblCandidatos = new Label
                {
                    Text = textoCandidatos,
                    Top = 40,
                    Left = 100,
                    Width = 180,
                    Height = 80
                };
                card.Controls.Add(lblCandidatos);

                // Botón para votar por esta plancha
                Button btnVotar = new Button
                {
                    Text = "Votar por esta plancha",
                    Top = 140,
                    Left = 80,
                    Width = 150,
                    Tag = plancha.Id
                };
                btnVotar.Click += (sender, e) => RegistrarVoto(plancha.Id);
                card.Controls.Add(btnVotar);

                yPos += 190;
                panelPlanchas.Controls.Add(card);
            }

            // Botón de voto nulo
            Button btnNulo = new Button
            {
                Text = "Voto Nulo",
                Top = yPos + 10,
                Left = 10,
                Width = 300,
                Height = 40,
                BackColor = Color.LightGray
            };
            btnNulo.Click += (sender, e) => RegistrarVoto(null);
            panelPlanchas.Controls.Add(btnNulo);
        }

        private void RegistrarVoto(int? planchaId)
        {
            // Verificar nuevamente que no haya votado (seguridad adicional)
            if (db.Votaciones.Any(v => v.UsuarioId == usuarioActual.Id))
            {
                MessageBox.Show("Ya ha votado.");
                return;
            }

            var voto = new Votacion
            {
                UsuarioId = usuarioActual.Id,
                PlanchaId = planchaId,
                EsNulo = planchaId == null,
                FechaHora = DateTime.Now
            };

            db.Votaciones.Add(voto);
            db.SaveChanges();

            MessageBox.Show("Su voto ha sido registrado con éxito.");
            this.Close();
        }
    }
}