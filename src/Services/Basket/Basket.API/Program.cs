var builder = WebApplication.CreateBuilder(args);

builder.Host.UseSerilog();

builder.Services.AddApiServices(builder.Configuration);

var app = builder.Build();

app.UseApiServices();

app.Run();
