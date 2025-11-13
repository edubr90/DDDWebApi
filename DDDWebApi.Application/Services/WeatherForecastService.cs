using System.Collections.Generic;
using AutoMapper;
using DDDWebApi.Application.DTOs;
using DDDWebApi.Domain.Entities;
using DDDWebApi.Domain.Repositories;
using DDDWebApi.Domain.Services;

namespace DDDWebApi.Application.Services
{
    public class WeatherForecastService : IWeatherForecastService, IWeatherForecastApplicationService
    {
        private readonly IWeatherForecastRepository _repository;
        private readonly IMapper _mapper;
        public WeatherForecastService(IWeatherForecastRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public IEnumerable<WeatherForecast> Get(int days) => _repository.GetForecasts(days);

        public IEnumerable<WeatherForecastDto> GetDto(int days)
        {
            var entities = Get(days);
            return _mapper.Map<IEnumerable<WeatherForecastDto>>(entities);
        }
    }
}
