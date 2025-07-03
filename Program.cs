using AgendaApi.Data;
using Microsoft.EntityFrameworkCore;
using NSwag.Generation.Processors.Security;


var builder = WebApplication.CreateBuilder(args);

// ?? Registrar ApplicationDbContext y los controladores
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("AgendaDB")));

builder.Services.AddControllers();

// ?? Configurar OpenAPI (Swagger)
builder.Services.AddOpenApiDocument(config =>
{
    config.Title = "API de Reuniones";
    config.Description = "Documentación interactiva para gestionar reuniones.";
});

var app = builder.Build();

// ?? Middleware para Swagger en desarrollo
if (app.Environment.IsDevelopment())
{
    app.UseOpenApi();       // Genera el documento JSON
    app.UseSwaggerUi();     // Interfaz visual de Swagger
}

app.UseHttpsRedirection();
app.UseAuthorization();

// ?? Mapeo de controladores
app.MapControllers();

app.Run();
