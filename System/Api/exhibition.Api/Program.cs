using Api.Configuration;
using exhibition.Api;
using exhibition.Api.Configuration;
using exhibition.Services.Settings;
using exhibition.Settings;
using exhibitions.Context;
using exhibitions.Context.Setup;
using exhibiton.Services.Settings;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

var swaggerSettings = Settings.Load<SwaggerSettings>("Swagger");
var identitySettings = Settings.Load<IdentitySettings>("Identity");
// Add services to the container.
//builder.AddAppLogger();
//builder.Services.AddControllers();
//builder.Services.AddHttpContextAccessor();
//builder.Services.AddAppCors();
//builder.Services.AddAppController();
//builder.Services.AddAppVersioning();
//builder.Services.RegisterAppServices();
//builder.Services.AddAppDbContext();
//builder.Services.AddMvc();
//builder.Services.AddAppSwagger(identitySettings,swaggerSettings);


builder.AddAppLogger();
builder.Services.AddAppHealthChecks();
builder.Services.AddControllers();
builder.Services.AddAppCors();
builder.Services.AddAppDbContext();
//builder.Services.AddAppAuth(identitySettings);
builder.Services.AddAppVersioning();
builder.Services.AddAppSwagger(identitySettings, swaggerSettings);
builder.Services.AddAppAutoMappers();
builder.Services.AddAppController();
builder.Services.RegisterAppServices();

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseAppController();
app.UseHttpsRedirection();
app.UseAppHealthChecks();
app.UseAppSwagger();
//app.UseAppAuth();
app.UseAuthorization();
app.MapControllers();
app.UseAppMiddlewares();
app.UseAppCors();
DbInitializer.Execute(app.Services);
DbSeeder.Execute(app.Services, true, true);

app.Run();
