using exhibition.Identity;
using exhibitions.Context;
using exhibitions.Identity.Configuration;

var builder = WebApplication.CreateBuilder(args);

builder.AddAppLogger();

var services = builder.Services;

services.AddAppCors();

services.AddHttpContextAccessor();

services.AddAppDbContext(builder.Configuration);

services.AddAppHealthChecks();

services.RegisterAppServices();
services.AddIS4();
var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseAppHealthChecks();
app.UseIS4();
app.Run();

