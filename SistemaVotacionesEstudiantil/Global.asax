using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using SistemaVotacionesEstudiantil.Data;
using SistemaVotacionesEstudiantil.Models;
using System.Data.Entity;
using System.Linq;

namespace SistemaVotacionesEstudiantil
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            // Inicializar base de datos y semilla
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<AppDbContext, Migrations.Configuration>());
            using (var ctx = new AppDbContext())
            {
                // Crear padrón por defecto si no existe
                if (!ctx.PadronesElectorales.Any())
                {
                    ctx.PadronesElectorales.Add(new PadronElectoral
                    {
                        Nombre = "Estudiantes 2026",
                        Descripcion = "Padrón escolar por defecto"
                    });
                    ctx.SaveChanges();
                }

                // Crear usuario admin si no existe
                if (!ctx.Usuarios.Any())
                {
                    var padron = ctx.PadronesElectorales.First();
                    ctx.Usuarios.Add(new Usuario
                    {
                        Matricula = "admin",
                        Nombre = "Admin",
                        Apellido = "Principal",
                        Curso = "N/A",
                        Seccion = "N/A",
                        Rol = "Admin",
                        PadronElectoralId = padron.Id,
                        PasswordHash = BCrypt.Net.BCrypt.HashPassword("12345")
                    });
                    ctx.SaveChanges();
                }
            }
        }
    }
}