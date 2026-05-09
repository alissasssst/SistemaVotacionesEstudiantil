using System.Collections.Generic;

namespace SistemaVotacionesEstudiantil.Models
{
    public class PadronElectoral
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public virtual ICollection<Usuario> Usuarios { get; set; } = new List<Usuario>();
    }
}