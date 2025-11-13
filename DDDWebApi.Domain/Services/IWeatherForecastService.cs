using DDDWebApi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDDWebApi.Domain.Services
{
    public interface IWeatherForecastService
    {
        IEnumerable<WeatherForecast> Get(int days);
    }
}
