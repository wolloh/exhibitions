using exhibition.Api;
using exhibition.Api.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.AddAppLogger();
builder.Services.AddControllers();
builder.Services.AddHttpContextAccessor();
builder.Services.AddAppCors();
builder.Services.AddAppController();
builder.Services.RegisterAppServices();
var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();
app.UseAppCors();
app.MapControllers();

app.Run();
