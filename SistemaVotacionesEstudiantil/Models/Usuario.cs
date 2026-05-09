namespace SistemaVotacionesEstudiantil.Models
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Matricula { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Curso { get; set; }
        public string Seccion { get; set; }
        public string Rol { get; set; } = "Votante";   // Admin, Votante, Partido
        public string PasswordHash { get; set; }
        public int? PadronElectoralId { get; set; }
        public virtual PadronElectoral PadronElectoral { get; set; }
        public virtual Votacion Votacion { get; set; }
    }
}