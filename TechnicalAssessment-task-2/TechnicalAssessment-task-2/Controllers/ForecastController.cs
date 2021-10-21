using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TechnicalAssessment_task_2.Services;

namespace TechnicalAssessment_task_2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ForecastController : ControllerBase
    {
        private WeatherService _weatherService;

        public ForecastController()
        {
            _weatherService = new WeatherService();
        }

        [HttpGet]
        public string GetForecast(string location)
        {
           return _weatherService.GetWeatherForecast(location);
        }
    }
}
