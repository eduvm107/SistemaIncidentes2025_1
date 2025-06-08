using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SistemaIncidentes2025.CORE.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using SistemaIncidentes2025.CORE.Infrastructure.Repositories;
using SistemaIncidentes2025.CORE.Core.Services;
using SistemaIncidentes2025.CORE.Core.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// Add DbContext
builder.Services.AddDbContext<SistemaIncidentesContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection") ??
        "Server=DESKTOP-F898MU7;Database=SistemaIncidentes;Integrated Security=True;TrustServerCertificate=True"));

// Dependency Injection
builder.Services.AddScoped<IIncidenteRepository, IncidenteRepository>();
builder.Services.AddScoped<ITipoIncidenteRepository, TipoIncidenteRepository>();
builder.Services.AddScoped<IIncidenteService, IncidenteService>();
builder.Services.AddScoped<ITipoIncidenteService, TipoIncidenteService>();
builder.Services.AddScoped<IContactoEmergenciaRepository, ContactoEmergenciaRepository>();
builder.Services.AddScoped<IContactoEmergenciaService, ContactoEmergenciaService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
