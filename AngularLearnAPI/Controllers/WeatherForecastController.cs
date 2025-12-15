using Microsoft.AspNetCore.Mvc;
using System.Globalization;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace AngularLearnAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {

        private static string GetSummaryByTemperature(int temperatureC)
        {
            return temperatureC switch
            {
                <= -10 => "Freezing",
                <= 0 => "Bracing",
                <= 10 => "Chilly",
                <= 18 => "Cool",
                <= 25 => "Mild",
                <= 30 => "Warm",
                <= 35 => "Hot",
                _ => "Scorching"
            };
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<WeatherForecast> Get()
        {
            return Enumerable.Range(1, 7)
                .Select(index =>
                {
                    var temperatureC = Random.Shared.Next(-20, 45);
                    var date = DateTime.Now.AddDays(index);
                    return new WeatherForecast
                    {
                        Date = date.ToString("dd.MM.yyyy", CultureInfo.InvariantCulture),
                        TemperatureC = temperatureC,
                        Summary = GetSummaryByTemperature(temperatureC)
                    };
                })
                .ToArray();
        }

        
    }
}
