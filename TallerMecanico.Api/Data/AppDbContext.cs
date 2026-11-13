using Microsoft.EntityFrameworkCore;
using TallerMecanico.Api.Dominio;

namespace TallerMecanico.Api.Data
{
    public class AppDbContext : DbContext
    {        
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        // 2. TU TABLA EN LA BASE DE DATOS:
        //Estrategia THP Persona y Cliente comparten la misma tabla fisica, ya que Cliente hereda de Persona.
        //Es elegida esta estrategia por que aprovecha la herencia y permite consultas más simple.
        public DbSet<Persona> Personas { get; set; }
        public DbSet<Cliente> Clientes { get; set; }  
        public DbSet<Vehiculo> Vehiculos { get; set; }

    }
}

        


