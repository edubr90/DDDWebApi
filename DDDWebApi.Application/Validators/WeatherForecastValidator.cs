using System.Collections.Generic;
using DDDWebApi.Application.DTOs;
using DDDWebApi.Domain.Specifications;
using DDDWebApi.Domain.Entities;
using System.Linq;

namespace DDDWebApi.Application.Validators
{
 public class WeatherForecastValidator : IEntityValidator<WeatherForecastDto>
 {
 private readonly IEnumerable<ISpecification<WeatherForecast>> _specs;
 public WeatherForecastValidator(IEnumerable<ISpecification<WeatherForecast>> specs)
 {
 _specs = specs;
 }

 public IEnumerable<string> Validate(WeatherForecastDto dto)
 {
 // Map DTO to domain for validation purposes
 var domain = new WeatherForecast
 {
 Date = dto.Date,
 TemperatureC = dto.TemperatureC,
 Summary = dto.Summary
 };

 var errors = _specs.SelectMany(s => s.Validate(domain));
 return errors.Where(e => !string.IsNullOrWhiteSpace(e));
 }
 }
}