using System.Collections.Generic;
using DDDWebApi.Domain.Entities;

namespace DDDWebApi.Domain.Specifications
{
    public class WeatherForecastMustHaveReasonableTemperature : ISpecification<WeatherForecast>
    {
        public IEnumerable<string> Validate(WeatherForecast candidate)
        {
            if (candidate.TemperatureC < -100 || candidate.TemperatureC > 100)
            {
                yield return $"TemperatureC {candidate.TemperatureC} is out of allowed range.";
            }
        }
    }

    public class WeatherForecastMustHaveDateInFuture : ISpecification<WeatherForecast>
    {
        public IEnumerable<string> Validate(WeatherForecast candidate)
        {
            if (candidate.Date < DateOnly.FromDateTime(System.DateTime.UtcNow.Date))
            {
                yield return "Date must be in the future.";
            }
        }
    }
}