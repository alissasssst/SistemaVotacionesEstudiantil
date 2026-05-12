using System.Data.Entity;
using SistemaVotacionesEstudiantil.Models;

namespace SistemaVotacionesEstudiantil.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext() : base("DefaultConnection") { }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<PadronElectoral> PadronesElectorales { get; set; }
        public DbSet<Plancha> Planchas { get; set; }
        public DbSet<Candidato> Candidatos { get; set; }
        public DbSet<Votacion> Votaciones { get; set; }
        public DbSet<PeriodoElectoral> PeriodosElectorales { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Usuario>().ToTable("Usuarios");
            modelBuilder.Entity<PadronElectoral>().ToTable("PadronesElectorales");
            modelBuilder.Entity<Plancha>().ToTable("Planchas");
            modelBuilder.Entity<Candidato>().ToTable("Candidatos");
            modelBuilder.Entity<Votacion>().ToTable("Votaciones");
            modelBuilder.Entity<PeriodoElectoral>().ToTable("PeriodosElectorales");

            modelBuilder.Entity<Usuario>()
                .HasOptional(u => u.Votacion)
                .WithRequired(v => v.Usuario);

            modelBuilder.Entity<Usuario>()
                .HasOptional(u => u.PadronElectoral)
                .WithMany(p => p.Usuarios)
                .HasForeignKey(u => u.PadronElectoralId);

            base.OnModelCreating(modelBuilder);
        }
    }
}