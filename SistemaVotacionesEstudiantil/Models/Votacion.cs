using System;

namespace SistemaVotacionesEstudiantil.Models
{
    public class Votacion
    {
        public int Id { get; set; }
        public int UsuarioId { get; set; }
        public virtual Usuario Usuario { get; set; }
        public int? PlanchaId { get; set; }
        public virtual Plancha Plancha { get; set; }
        public bool EsNulo { get; set; }
        public DateTime FechaHora { get; set; } = DateTime.Now;
    }
}