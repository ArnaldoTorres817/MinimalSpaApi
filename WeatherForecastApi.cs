namespace MinimalWebApi.Apis;

public static class WeatherForecastApi
{
    private static readonly string ROUTE_NAME = "/weatherforecast";

    public static void RegisterWeatherForecastApi(this WebApplication app)
    {
        app.MapGet(ROUTE_NAME, GetAllWeatherForecasts);
        app.MapPost(ROUTE_NAME, SaveWeatherForecast);
    }

    private static IReadOnlyCollection<WeatherForecast> GetAllWeatherForecasts(IWeatherForecastStore wfStore)
    {
        return wfStore.Get();
    }

    private static IResult SaveWeatherForecast(WeatherForecast wf, IWeatherForecastStore wfStore)
    {
        wfStore.Save(wf);
        return Results.Created(Guid.NewGuid().ToString(), wf);
    }
}