using AutoMapper;
using DDDWebApi.Application.DTOs;
using DDDWebApi.Domain.Entities;

namespace DDDWebApi.Application.Mappings
{
 public class WeatherForecastProfile : Profile
 {
 public WeatherForecastProfile()
 {
 CreateMap<WeatherForecast, WeatherForecastDto>()
 .ForMember(dest => dest.TemperatureF, opt => opt.MapFrom(src => src.TemperatureF));
 }
 }
}