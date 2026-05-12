namespace SistemaVotacionesEstudiantil.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<SistemaVotacionesEstudiantil.Data.AppDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            ContextKey = "SistemaVotacionesEstudiantil.Data.AppDbContext";
        }

        protected override void Seed(SistemaVotacionesEstudiantil.Data.AppDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.
        }
    }
}
