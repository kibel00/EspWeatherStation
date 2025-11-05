using EspWeatherStation.Shared;
using Microsoft.AspNetCore.Mvc;

namespace EspWeatherStation.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WeatherStationController : ControllerBase
    {
        private readonly ILogger<WeatherStationController> _logger;

        public WeatherStationController(ILogger<WeatherStationController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<WeatherStation> Get()
        {
            return Enumerable.Range(1, 5).Select(index => new WeatherStation
            {
                Id = index,
                Sensor = $"Sensor {index}",
                Location = $"Location {index}",
                Value1 = Random.Shared.Next(-20, 55).ToString(),
                Value2 = Random.Shared.Next(0, 100).ToString(),
                Value3 = Random.Shared.Next(900, 1100).ToString(),
                ReadingTime = DateTime.Now.AddMinutes(-index * 5)
            });
        }
    }
}
