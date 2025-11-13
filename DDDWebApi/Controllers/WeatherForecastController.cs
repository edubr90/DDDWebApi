using Microsoft.AspNetCore.Mvc;
using DDDWebApi.Application.DTOs;
using DDDWebApi.Application.Services;
using DDDWebApi.Application.Validators;
using DDDWebApi.CrossCutting.Responses;

namespace DDDWebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly ILogger<WeatherForecastController> _logger;
        private readonly IWeatherForecastApplicationService _appService;
        private readonly IEntityValidator<WeatherForecastDto> _validator;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, IWeatherForecastApplicationService appService, IEntityValidator<WeatherForecastDto> validator)
        {
            _logger = logger;
            _appService = appService;
            _validator = validator;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public ActionResult<ApiResponse<IEnumerable<WeatherForecastDto>>> Get()
        {
            var data = _appService.GetDto(5);
            var errors = data.SelectMany(dto => _validator.Validate(dto)).ToArray();
            if (errors.Any())
            {
                return BadRequest(ApiResponse<IEnumerable<WeatherForecastDto>>.FailResponse(errors, "Validation failed",400));
            }

            return Ok(ApiResponse<IEnumerable<WeatherForecastDto>>.SuccessResponse(data));
        }
    }
}
