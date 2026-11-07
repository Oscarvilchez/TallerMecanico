using Microsoft.EntityFrameworkCore;
using TallerMecanico.Api.Dominio;

namespace TallerMecanico.Api.Data
{
    public class AppDbContext : DbContext
    {
        // El constructor permite que Program.cs le inyecte la conexión segura
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        // 2. TU TABLA EN LA BASE DE DATOS:
        // Representa la tabla física "Personas". Mapea tu clase C# con SQL Server.
        public DbSet<Persona> Personas { get; set; }
                
    }
}

        


