using System.Collections.Generic;

namespace SistemaVotacionesEstudiantil.Models
{
    public class Plancha
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string LogoUrl { get; set; }
        public bool Activa { get; set; } = true;
        public virtual ICollection<Candidato> Candidatos { get; set; } = new List<Candidato>();
    }
}