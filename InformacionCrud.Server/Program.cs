using InformacionCrud.Server;
using InformacionCrud.Server.Models;
using InformacionCrud.Server.Repositorio.Implementacion;
using InformacionCrud.Server.Repositorio.Interface;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Microsoft.EntityFrameworkCore.ServerVersion.Parse("9.0.1-mysql")

//_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-|

builder.Services.AddDbContext<InformacionpublicaContext>(options =>
        options.UseMySql(builder.Configuration.GetConnectionString("QueryMySql"),
        new MySqlServerVersion(new Version(9, 0, 1))));

//_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-|

builder.Services.AddAutoMapper(typeof(MappingConfig));

//_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-|

builder.Services.AddScoped<IMetodoCiudadano, MetodoCiudadano>();
builder.Services.AddScoped<IMetodoTipoCiudadano, MetodoTipoCiudadano>();
builder.Services.AddScoped<IMetodoTipoDocumento, MetodoTipoDocumento>();
builder.Services.AddScoped<IMetodoBienes, MetodoBienes>();
builder.Services.AddScoped<IMetodoNacionalidad, MetodoNacionalidad>();


builder.Services.AddScoped<IMetodoDenuncia, MetodoDenuncia>();

builder.Services.AddScoped<IMetodoTiposDelito, MetodoTiposDelito>();

builder.Services.AddScoped<IMetodoDelitos, MetodoDelitos>();

builder.Services.AddScoped<IMetodoDetenciones, MetodoDetenciones>();

builder.Services.AddScoped<IMetodoPenaImpuesta, MetodoPenaImpuesta>();

builder.Services.AddScoped<IMetodoAntecedenteCiudadano, MetodoAntecedenteCiudadano>();

builder.Services.AddScoped<IMetodoInfracciones, MetodoInfracciones>();

builder.Services.AddScoped<IMetodoInfraccionesCiudadano, MetodoInfraccionesCiudadano>();

//_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-|
//activacion de cores

builder.Services.AddCors(opciones =>
{
    opciones.AddPolicy("nuevaPolitica", app =>
    {
        app.AllowAnyOrigin()
           .AllowAnyHeader()
           .AllowAnyMethod();
    });
});

//_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-|

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-|
//espacio de activacion de servicios

app.UseCors("nuevaPolitica");

//_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-|

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
