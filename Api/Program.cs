using Aplicacion.Interfaces;
using Aplicacion.Main;
using Repositorio.Data;
using Repositorio.Interfaces;
using Repositorio.Repositorio;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo { Title = "Api", Version = "v1" });
});


// Obtener la configuración
var configuration = builder.Configuration;


// Configurar DbContext
builder.Services.AddDbContext<DataContext>(options =>
    options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

// Registrar servicios
builder.Services.AddScoped<ILoginAplication, LoginAplication>();
builder.Services.AddScoped<ILoginRepository, LoginRepository>();
builder.Services.AddScoped<IUsersAplication, UserAplication>();
builder.Services.AddScoped<IUsersRepository, UsersRepository>();
builder.Services.AddScoped<IDataAplication, DataAplication>();
builder.Services.AddScoped<IDataRepository, DataRepository>();
builder.Services.AddScoped<ISupportAplication, SupportAplication>();
builder.Services.AddScoped<ISupportRepository, SupportRepository>();
builder.Services.AddScoped<IDocumentsAplication, DocumentsAplication>();
builder.Services.AddScoped<IDocumentsRepository, DocumentsRepository>();

var app = builder.Build();

// Configure CORS
app.UseCors(policy => policy
    .AllowAnyOrigin() // Permitir solicitudes desde cualquier origen
    .AllowAnyMethod() // Permitir cualquier método HTTP (GET, POST, etc.)
    .AllowAnyHeader()); // Permitir cualquier encabezado HTTP

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
