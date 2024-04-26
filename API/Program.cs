using Gemu.Data;
using Gemu.Business;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<IUsuarioServices, UsuarioServices>();
builder.Services.AddScoped<IJuegoServices, JuegoServices>();
builder.Services.AddScoped<IProductoServices, ProductoServices>();
builder.Services.AddScoped<IAnuncioServices, AnuncioServices>();
builder.Services.AddScoped<ITransaccionServices, TransaccionServices>();
builder.Services.AddScoped<IReseñaServices, ReseñaServices>();
builder.Services.AddScoped<IBibliotecaServices, BibliotecaServices>();
builder.Services.AddScoped<ICarritoServices, CarritoServices>();

// Add services to the container.
var configuration = builder.Configuration;
var environment = configuration["Environment"];

var connectionString = environment == "Docker" ?
    configuration.GetConnectionString("GemuDBDocker") :
    configuration.GetConnectionString("GemuDBLocal");
    
// Configuración de la base de datos
builder.Services.AddDbContext<GemuContext>(options =>
    options.UseSqlServer(connectionString));

// Repositorios
builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();
builder.Services.AddScoped<IJuegoRepository, JuegoRepository>();
builder.Services.AddScoped<IProductoRepository, ProductoRepository>();
builder.Services.AddScoped<ITransaccionRepository, TransaccionRepository>();
builder.Services.AddScoped<IReseñaRepository, ReseñaRepository>();
builder.Services.AddScoped<IAnuncioRepository, AnuncioRepository>();
builder.Services.AddScoped<ICarritoRepository, CarritoRepository>();
builder.Services.AddScoped<IBibliotecaRepository, BibliotecaRepository>();


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseSwagger();
app.UseSwaggerUI();

//Permitir cualquier red
app.UseCors(builder => builder
    .AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader());

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

using (var scope = app.Services.CreateScope())
{
  var services = scope.ServiceProvider;
  try
  {
    var context = services.GetRequiredService<GemuContext>();
    context.Database.Migrate();
  }
  catch (Exception ex)
  {
    throw new Exception("Error durante la migración de la base de datos.", ex);
  }
}

app.Run();
