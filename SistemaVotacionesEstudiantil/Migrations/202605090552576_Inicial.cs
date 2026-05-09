namespace SistemaVotacionesEstudiantil.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Inicial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Candidatoes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nombre = c.String(),
                        Apellido = c.String(),
                        Puesto = c.String(),
                        PlanchaId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Planchas", t => t.PlanchaId, cascadeDelete: true)
                .Index(t => t.PlanchaId);
            
            CreateTable(
                "dbo.Planchas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nombre = c.String(),
                        LogoUrl = c.String(),
                        Activa = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.PadronElectorals",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nombre = c.String(),
                        Descripcion = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Usuarios",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Matricula = c.String(),
                        Nombre = c.String(),
                        Apellido = c.String(),
                        Curso = c.String(),
                        Seccion = c.String(),
                        Rol = c.String(),
                        PasswordHash = c.String(),
                        PadronElectoralId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.PadronElectorals", t => t.PadronElectoralId)
                .Index(t => t.PadronElectoralId);
            
            CreateTable(
                "dbo.Votacions",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        UsuarioId = c.Int(nullable: false),
                        PlanchaId = c.Int(),
                        EsNulo = c.Boolean(nullable: false),
                        FechaHora = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Planchas", t => t.PlanchaId)
                .ForeignKey("dbo.Usuarios", t => t.Id)
                .Index(t => t.Id)
                .Index(t => t.PlanchaId);
            
            CreateTable(
                "dbo.PeriodoElectorals",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FechaInicio = c.DateTime(nullable: false),
                        FechaFin = c.DateTime(nullable: false),
                        Activo = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Votacions", "Id", "dbo.Usuarios");
            DropForeignKey("dbo.Votacions", "PlanchaId", "dbo.Planchas");
            DropForeignKey("dbo.Usuarios", "PadronElectoralId", "dbo.PadronElectorals");
            DropForeignKey("dbo.Candidatoes", "PlanchaId", "dbo.Planchas");
            DropIndex("dbo.Votacions", new[] { "PlanchaId" });
            DropIndex("dbo.Votacions", new[] { "Id" });
            DropIndex("dbo.Usuarios", new[] { "PadronElectoralId" });
            DropIndex("dbo.Candidatoes", new[] { "PlanchaId" });
            DropTable("dbo.PeriodoElectorals");
            DropTable("dbo.Votacions");
            DropTable("dbo.Usuarios");
            DropTable("dbo.PadronElectorals");
            DropTable("dbo.Planchas");
            DropTable("dbo.Candidatoes");
        }
    }
}
