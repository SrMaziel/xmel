using InformacionCrud.Client;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

using InformacionCrud.Client.Services;
using CurrieTechnologies.Razor.SweetAlert2;
using Blazored.Modal;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://localhost:7034") });

builder.Services.AddScoped<ICiudadanoService, CiudadanoService>();
builder.Services.AddScoped<ITipoCiudadanoService, TipoCiudadanoService>();
builder.Services.AddScoped<ITipoDocumentoService, TipoDocumentoService>();
builder.Services.AddScoped<INacionalidadService, NacionalidadService>();
builder.Services.AddScoped<IBienesService, BienesService>();
builder.Services.AddScoped<IDenunciaService, DenunciaService>();

builder.Services.AddScoped<IAntecedenteCiudadanoService, AntecedenteCiudadanoService>();


builder.Services.AddScoped<IDetencionService, DetencionService>();

builder.Services.AddScoped<ITiposDelitoService, TiposDelitoService>();

builder.Services.AddScoped<IPenaImpuestaService, PenaImpuestaService>();


builder.Services.AddScoped<IDelitosService, DelitosService>();


builder.Services.AddScoped<IInfraccionesService, InfraccionesService>();

builder.Services.AddScoped<IInfraccionesCiudadanoService, InfraccionesCiudadanoService>();


//_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-|

builder.Services.AddBlazoredModal();
builder.Services.AddSweetAlert2();

//_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-|

await builder.Build().RunAsync();
