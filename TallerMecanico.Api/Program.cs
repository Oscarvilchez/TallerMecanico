using Microsoft.EntityFrameworkCore;
using TallerMecanico.Api.Data;
using Microsoft.AspNetCore.Builder;

namespace TallerMecanico.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // 1. REGISTRO DE SERVICIOS
            builder.Services.AddControllers();

            // Configuración clásica de Swagger (Inmune a los fallos de enrutamiento de .NET 9)
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            // CONEXIÓN A LA BASE DE DATOS
            var cadenaConexion = builder.Configuration.GetConnectionString("CadenaSql");
            builder.Services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(cadenaConexion));

            // REGISTRAR TU REPOSITORIO
            builder.Services.AddScoped<PersonaRepository>();

            var app = builder.Build();

            // 2. CONFIGURACIÓN DEL PIPELINE
            if (app.Environment.IsDevelopment())
            {
                // Estos dos métodos trabajan juntos en armonía y configuran sus propias rutas automáticamente
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}
