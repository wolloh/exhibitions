using exhibition.Api;
using exhibition.Api.Configuration;
using exhibition.Services.Settings;
using exhibition.Settings;
using exhibitions.Context;
using exhibitions.Context.Setup;

var builder = WebApplication.CreateBuilder(args);

var swaggerSettings = Settings.Load<SwaggerSettings>("Swagger");
// Add services to the container.
builder.AddAppLogger();
builder.Services.AddControllers();
builder.Services.AddHttpContextAccessor();
builder.Services.AddAppCors();
builder.Services.AddAppController();
builder.Services.RegisterAppServices();
builder.Services.AddAppDbContext();
builder.Services.AddAppSwagger(swaggerSettings);
var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();
app.UseAppSwagger();
app.UseAuthorization();
app.UseAppCors();
DbInitializer.Execute(app.Services);
DbSeeder.Execute(app.Services, true, true);
app.MapControllers();

app.Run();
