using MinimalWebApi;
using MinimalWebApi.Apis;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<IWeatherForecastStore, InMemoryWeatherForecastStore>();
builder.Services.AddCors();

var app = builder.Build();

var basePath = "/api";

app.UseCors(options =>
{
    options.AllowAnyOrigin();
});

app.UsePathBase(new PathString(basePath));

app.RegisterWeatherForecastApi();

app.UseDefaultFiles();
app.UseStaticFiles();

app.Run();
