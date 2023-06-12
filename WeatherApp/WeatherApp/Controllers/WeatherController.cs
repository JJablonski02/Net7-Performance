using Microsoft.AspNetCore.Mvc;
using WeatherApp.Models;

namespace WeatherApp.Controllers
{
    public class WeatherController : Controller
    {

        List<CityWeather> cityWeathers = new List<CityWeather>()
            {
                new CityWeather{CityUniqueCode = "LDN", CityName = "London", DateAndTime = DateTime.Parse("2023-06-12 00:55"), TemperatureFahrenheit = 33},
                new CityWeather{CityUniqueCode = "NYC", CityName = "New York", DateAndTime = DateTime.Parse("2023-06-11 19:55"), TemperatureFahrenheit = 60},
                new CityWeather{CityUniqueCode = "PRS", CityName = "Paris", DateAndTime = DateTime.Parse("2023-06-12 01:55"), TemperatureFahrenheit = 82},
            };


        [Route("/")]
        public IActionResult Weather()
        {
            return View(cityWeathers);
        }

        [Route("weather/{cityCode}")]
        public IActionResult City(string? cityCode)
        {
            if (string.IsNullOrEmpty(cityCode))
            {
                return View();
            }

            CityWeather? city = cityWeathers.Where(temp => temp.CityUniqueCode == cityCode).FirstOrDefault();

            return View(city);
        }
    }
}
