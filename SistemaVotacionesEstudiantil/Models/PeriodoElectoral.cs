using System;

namespace SistemaVotacionesEstudiantil.Models
{
    public class PeriodoElectoral
    {
        public int Id { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
        public bool Activo { get; set; } = true;
    }
}