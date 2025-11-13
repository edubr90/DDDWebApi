using DDDWebApi.Application.Services;
using DDDWebApi.Domain.Repositories;
using DDDWebApi.Domain.Services;
using DDDWebApi.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace DDDWebApi.IoC
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddApplicationIoC(this IServiceCollection services)
        {
            services.AddScoped<IWeatherForecastService, WeatherForecastService>();
            services.AddScoped<IWeatherForecastRepository, WeatherForecastRepository>();
            return services;
        }
    }
}