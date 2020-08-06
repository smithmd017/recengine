using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace RecEngineApi.Controllers
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

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();
        }
    }
}
/*
 * https://www.ikea.com/gb/en/p/malm-chest-of-3-drawers-grey-stained-10482512/
 * https://www.ikea.com/gb/en/p/bryggja-chest-of-9-drawers-beige-30469307/
 * https://www.ikea.com/gb/en/p/kullen-chest-of-5-drawers-white-20393662/
 *https://www.ikea.com/gb/en/p/hemnes-chest-of-3-drawers-white-90374274/
 * https://www.ikea.com/gb/en/p/askvoll-chest-of-3-drawers-white-stained-oak-effect-white-20270802/
 *https://www.ikea.com/gb/en/p/brimnes-chest-of-4-drawers-white-frosted-glass-90392046/
 *https://www.ikea.com/gb/en/p/nordmela-chest-of-drawers-with-clothes-rail-black-blue-00421656/
 * https://www.ikea.com/gb/en/p/songesand-chest-of-6-drawers-white-90366783/
 * https://www.ikea.com/gb/en/p/nordli-chest-of-6-drawers-white-s09239498/
 * https://www.ikea.com/gb/en/p/lote-chest-of-3-drawers-white-50293722/
 * */
