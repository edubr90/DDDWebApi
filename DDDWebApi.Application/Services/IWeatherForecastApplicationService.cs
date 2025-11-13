using System.Collections.Generic;
using DDDWebApi.Application.DTOs;

namespace DDDWebApi.Application.Services
{
 public interface IWeatherForecastApplicationService
 {
 IEnumerable<WeatherForecastDto> GetDto(int days);
 }
}