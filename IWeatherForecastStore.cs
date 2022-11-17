namespace MinimalWebApi;

interface IWeatherForecastStore
{
    public void Save(WeatherForecast wf);
    public IReadOnlyCollection<WeatherForecast> Get();
}