using Infraestructure_login.Data;
using Microsoft.EntityFrameworkCore;
using Infraestructure_login.Repositories;
using Infraestructure_login.Data.Infraestructure_login.Data;
using Infraestructure_login.UseCases;
using Infraestructure_login.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// ===============================
// 🔌 Servicios
// ===============================

// Controllers
builder.Services.AddControllers();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll",
        policy => policy
            .AllowAnyOrigin()
            .AllowAnyHeader()
            .AllowAnyMethod());
});

// Swagger / OpenAPI
builder.Services.AddOpenApi();

// DbContext (SQL Server)
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection")
    )
);

// Repositorios (Infrastructure)
builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();
builder.Services.AddScoped<IAuditoriaRepository, AuditoriaRepository>();

// Casos de uso (Application)
builder.Services.AddScoped<LoginUsuario>();

// ===============================
// 🚀 Build
// ===============================

var app = builder.Build();

// ===============================
// ⚙️ Middleware
// ===============================

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();
app.UseCors("AllowAll");

app.UseAuthorization();

app.MapControllers();

app.Run();