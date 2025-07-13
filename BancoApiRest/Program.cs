using BancoApiRest.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

// Registrar servicios para inyección de dependencias
// Usamos Singleton para que los datos en memoria persistan durante el ciclo de vida de la app
builder.Services.AddSingleton<IClienteService, ClienteService>();
builder.Services.AddSingleton<IPagoService, PagoService>();
builder.Services.AddSingleton<IBitacoraService, BitacoraService>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
{{ ... }}
