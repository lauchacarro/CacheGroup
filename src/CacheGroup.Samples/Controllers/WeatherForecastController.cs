using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CacheGroup.Samples.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;
        private readonly ICacheManager _cacheManager;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, ICacheManager cacheManager)
        {
            _logger = logger;
            _cacheManager = cacheManager;
        }

        [HttpGet]
        public IActionResult Get()
        {

            var result = _cacheManager.GetOrSet(new(nameof(Get), string.Empty, nameof(WeatherForecast)),
                () =>
                {
                    var rng = new Random();
                    return Enumerable.Range(1, 5).Select(index => new WeatherForecast
                    {
                        Date = DateTime.Now.AddDays(index),
                        TemperatureC = rng.Next(-20, 55),
                        Summary = Summaries[rng.Next(Summaries.Length)]
                    })
                    .ToArray();
                });

            return Ok(result);
        }
    }
}
