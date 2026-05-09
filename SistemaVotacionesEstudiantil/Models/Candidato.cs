namespace SistemaVotacionesEstudiantil.Models
{
    public class Candidato
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Puesto { get; set; }          // Presidente, Vicepresidente, etc.
        public int PlanchaId { get; set; }
        public virtual Plancha Plancha { get; set; }
    }
}