using System;
using System.Linq;
using System.Windows.Forms;
using SistemaVotacionesEstudiantil.Data;
using SistemaVotacionesEstudiantil.Models;

namespace SistemaVotacionesEstudiantil
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            // Inicializar base de datos y semilla
            using (var ctx = new AppDbContext())
            {
                if (!ctx.PadronesElectorales.Any())
                {
                    ctx.PadronesElectorales.Add(new PadronElectoral
                    {
                        Nombre = "Estudiantes 2026",
                        Descripcion = "Padrón por defecto"
                    });
                    ctx.SaveChanges();
                }

                if (!ctx.Usuarios.Any())
                {
                    var padron = ctx.PadronesElectorales.First();
                    ctx.Usuarios.Add(new Usuario
                    {
                        Matricula = "admin",
                        Nombre = "Admin",
                        Apellido = "Principal",
                        Rol = "Admin",
                        PadronElectoralId = padron.Id,
                        PasswordHash = BCrypt.Net.BCrypt.HashPassword("12345")
                    });
                    ctx.SaveChanges();
                }
            }

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new LoginForm());
        }
    }
}