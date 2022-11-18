using System.Text.Json;

namespace MinimalWebApi;

class InMemoryWeatherForecastStore : IWeatherForecastStore
{
    private ICollection<WeatherForecast> _wfStore;
    private readonly ILogger<InMemoryWeatherForecastStore> _logger;

    public InMemoryWeatherForecastStore(ILogger<InMemoryWeatherForecastStore> logger)
    {
        _logger = logger;
        _wfStore = LoadData();
    }

    private ICollection<WeatherForecast> LoadData()
    {
        try
        {
            string contents = File.ReadAllText("data.json");
            var data = JsonSerializer.Deserialize<WeatherForecast[]>(contents, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });
            if (data is null || !data.Any())
                throw new Exception();
            return new LinkedList<WeatherForecast>(data!);
        }
        catch (Exception)
        {
            return new LinkedList<WeatherForecast>();
        }
    }

    public void Save(WeatherForecast wf)
    {
        _logger.LogInformation("Saved WeatherForecast: {0} {1} {2}", wf.Date, wf.TemperatureF, wf.TemperatureC);
        _wfStore.Add(wf);
    }

    public IReadOnlyCollection<WeatherForecast> Get()
    {
        _logger.LogInformation("WeatherForecast was queried: {0}", DateTime.Now);
        return _wfStore.ToArray().AsReadOnly();
    }
}