using System.Collections.Generic;
using DDDWebApi.Domain.Entities;
using DDDWebApi.Domain.Repositories;
using DDDWebApi.Domain.Services;

namespace DDDWebApi.Application.Services
{
    public class WeatherForecastService : IWeatherForecastService
    {
        private readonly IWeatherForecastRepository _repository;
        public WeatherForecastService(IWeatherForecastRepository repository)
        {
            _repository = repository;
        }
        public IEnumerable<WeatherForecast> Get(int days) => _repository.GetForecasts(days);
    }
}

    
