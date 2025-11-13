using DDDWebApi.Application.Services;
using DDDWebApi.Domain.Repositories;
using DDDWebApi.Domain.Services;
using DDDWebApi.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;
using DDDWebApi.Domain.Entities;
using DDDWebApi.Domain.Specifications;
using DDDWebApi.Application.Validators;
using DDDWebApi.Application.DTOs;
using DDDWebApi.Application.Mappings;


namespace DDDWebApi.IoC
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddApplicationIoC(this IServiceCollection services)
        {
            // Application services
            services.AddScoped<IWeatherForecastService, WeatherForecastService>();
            services.AddScoped<IWeatherForecastApplicationService, WeatherForecastService>();

            // Repositories
            services.AddScoped<IWeatherForecastRepository, WeatherForecastRepository>();

            // Domain specifications
            services.AddScoped<ISpecification<WeatherForecast>, WeatherForecastMustHaveReasonableTemperature>();
            services.AddScoped<ISpecification<WeatherForecast>, WeatherForecastMustHaveDateInFuture>();

            // Application validators
            services.AddScoped<IEntityValidator<WeatherForecastDto>, WeatherForecastValidator>();

            // AutoMapper
            services.AddAutoMapper(cfg => {
                cfg.AddProfile<WeatherForecastProfile>();
            });

            return services;
        }
    }
}