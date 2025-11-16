using Microsoft.EntityFrameworkCore;
using P3.Abstracciones.AccesoDatos.Vehiculo;
using P3.Abstracciones.LogicaNegocio.Vehiculo;
using P3.AccesoDatos;
using P3.AccesoDatos.Vehiculo;
using P3.LogicaNegocio.Mapper;
using P3.LogicaNegocio.Vehiculo;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddAutoMapper(cfg => { }, typeof(MapeoClases));
//Inyeccion de dependencias 
builder.Services.AddTransient<IVehiculoAD, VehiculoRepositorioAD>();
builder.Services.AddTransient<IVehiculoLN, VehiculoLN>();

var connectionString = builder.Configuration.GetConnectionString("ContextConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
builder.Services.AddDbContext<Context>(options =>
    options.UseSqlServer(connectionString));
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

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
