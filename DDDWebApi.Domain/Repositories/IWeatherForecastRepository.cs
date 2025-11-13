using System.Collections.Generic;
using DDDWebApi.Domain.Entities;

namespace DDDWebApi.Domain.Repositories
{
 public interface IWeatherForecastRepository
 {
 IEnumerable<WeatherForecast> GetForecasts(int days);
 }
}