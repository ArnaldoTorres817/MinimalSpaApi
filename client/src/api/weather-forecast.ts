import type { WeatherForecastDetails } from '@/types'

const apiUrl = 'http://localhost:5030/api/weatherforecast'

export async function getAllWeatherForecasts(): Promise<
  WeatherForecastDetails[]
> {
  const res = await fetch(apiUrl)
  const data = await res.json()
  return data as WeatherForecastDetails[]
}

export async function saveWeatherForecast(
  weatherForecast: WeatherForecastDetails
): Promise<WeatherForecastDetails> {
  const res = await fetch(apiUrl, {
    method: 'POST',
    headers: {
      'content-type': 'application/json',
    },
    body: JSON.stringify(weatherForecast),
  })
  const newWeatherForecast = await res.json()
  return newWeatherForecast as WeatherForecastDetails
}
