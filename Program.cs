using MinimalWebApi;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<IWeatherForecastStore, InMemoryWeatherForecastStore>();

var app = builder.Build();

app.MapGet("/weatherforecast", (IWeatherForecastStore wfStore) =>
{
    return wfStore.Get();
});

app.MapPost("/weatherforecast", (WeatherForecast wf, IWeatherForecastStore wfStore) =>
{
    wfStore.Save(wf);
    return Results.Created(Guid.NewGuid().ToString(), wf);
});

app.UseDefaultFiles();
app.UseStaticFiles();

app.Run();
