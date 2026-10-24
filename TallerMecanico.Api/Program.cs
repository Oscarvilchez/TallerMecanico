using Microsoft.Data.SqlClient;

var builder = WebApplication.CreateBuilder(args);

// --- CONFIGURACIÓN DE BASE DE DATOS PARA LA WEB ---
var cadenaConexion = builder.Configuration.GetConnectionString("CadenaSql");
builder.Services.AddScoped<SqlConnection>(sp => new SqlConnection(cadenaConexion));

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
