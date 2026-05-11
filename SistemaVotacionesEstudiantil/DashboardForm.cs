using System;
using System.Linq;
using System.Windows.Forms;
using SistemaVotacionesEstudiantil.Data;

namespace SistemaVotacionesEstudiantil
{
    public partial class DashboardForm : Form
    {
        private AppDbContext db = new AppDbContext();

        public DashboardForm()
        {
            InitializeComponent();
        }

        private void DashboardForm_Load(object sender, EventArgs e)
        {
            if (Sesion.UsuarioActual == null)
            {
                MessageBox.Show("Debe iniciar sesión.");
                Close();
                return;
            }
            CargarDatos();
        }

        private void CargarDatos()
        {
            // Período activo
            var periodoActivo = db.PeriodosElectorales.FirstOrDefault(p => p.Activo && DateTime.Now >= p.FechaInicio && DateTime.Now <= p.FechaFin);
            if (periodoActivo != null)
            {
                lblPeriodo.Text = $"Período activo: {periodoActivo.FechaInicio:dd/MM/yyyy HH:mm} - {periodoActivo.FechaFin:dd/MM/yyyy HH:mm}";
                TimeSpan restante = periodoActivo.FechaFin - DateTime.Now;
                lblTiempoRestante.Text = restante.TotalSeconds > 0 ? $"Tiempo restante: {restante.Days}d {restante.Hours}h {restante.Minutes}m" : "Período finalizado";
            }
            else
            {
                lblPeriodo.Text = "No hay período electoral activo.";
                lblTiempoRestante.Text = "";
            }

            // Totales generales
            int totalPadron = db.Usuarios.Count();
            int votosEmitidos = db.Votaciones.Count();
            int votosNulos = db.Votaciones.Count(v => v.EsNulo);
            double participacion = totalPadron > 0 ? (double)votosEmitidos / totalPadron * 100.0 : 0.0;

            lblVotantesRegistrados.Text = $"Votantes registrados: {totalPadron}";
            lblVotosEmitidos.Text = $"Votos emitidos: {votosEmitidos}";
            lblVotosNulos.Text = $"Votos nulos: {votosNulos}";
            lblParticipacion.Text = $"Participación: {participacion:F2}%";

            // Resultados por plancha
            var planchas = db.Planchas.ToList();
            dgvResultados.DataSource = planchas.Select(p => new
            {
                Plancha = p.Nombre,
                Votos = db.Votaciones.Count(v => v.PlanchaId == p.Id),
                Porcentaje = votosEmitidos > 0 ? (double)db.Votaciones.Count(v => v.PlanchaId == p.Id) / votosEmitidos * 100.0 : 0.0
            }).OrderByDescending(x => x.Votos).ToList();

            // Formato de porcentaje en la columna (opcional)
            if (dgvResultados.Columns.Contains("Porcentaje"))
                dgvResultados.Columns["Porcentaje"].DefaultCellStyle.Format = "F2";

            // Colores para la fila ganadora (la primera después de ordenar)
            if (dgvResultados.Rows.Count > 0)
            {
                dgvResultados.Rows[0].DefaultCellStyle.BackColor = System.Drawing.Color.LightGreen;
                dgvResultados.Rows[0].DefaultCellStyle.Font = new System.Drawing.Font(dgvResultados.Font, System.Drawing.FontStyle.Bold);
            }
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            CargarDatos();
        }
    }
}