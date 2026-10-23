using TallerMecanico.Api.Dominio;

//PRUEBA DE LA CLASE PERSONA

Persona persona1 = new Persona(1, "Juan", "Pérez", "123456789");
Console.WriteLine("Persona 1: " + persona1.NombreCompleto);

Persona luis = new Persona(2, "Luis", "Gómez", "987654321");
Console.WriteLine("Prueba 2: " + luis.NombreCompleto + " - Tel: " + luis.Telefono);

try
{
    Persona personaInvalida = new Persona(3, "", "López");
    Console.WriteLine("Persona inválida: , Error, no debio crearse");
}
catch (ArgumentException ex)
{
    Console.WriteLine("Error capturado: " + ex.Message);
}




    var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
