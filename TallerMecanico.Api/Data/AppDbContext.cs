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

        // Constructor vacío para pruebas rápidas por consola
        public AppDbContext()
        {
        }
        // Mapea la clase Persona (singular) con la tabla Personas (plural) en SQL Server
        // DbSet representa la tabla física. Permite hacer Consultas, Inserts, Updates y Deletes en la tabla "Personas" usando C#
        // Colección de entidades en memoria que interactúa directamente con la tabla 'Personas' en la BD LUFFY360
        public DbSet<Persona> Personas { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Configuración de respaldo para cuando se ejecute por consola
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=LUFFY360;Database=bd_TallerMecanico;Trusted_Connection=True;TrustServerCertificate=True;");
            }
        }
    }
}

        
        
