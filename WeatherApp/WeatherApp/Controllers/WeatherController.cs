using Microsoft.AspNetCore.Mvc;
using WeatherApp.Models;

namespace WeatherApp.Controllers
{
    public class WeatherController : Controller
    {
        [Route("/")]
        public IActionResult Weather()
        {
            List<CityWeather> cityWeathers = new List<CityWeather>()
            {
                new CityWeather{CityUniqueCode = "LDN", CityName = "London", DateAndTime = DateTime.Parse("2023-06-12 00:55")},
                new CityWeather{CityUniqueCode = "NYC", CityName = "New York", DateAndTime = DateTime.Parse("2023-06-11 19:55")},
                new CityWeather{CityUniqueCode = "PRS", CityName = "Paris", DateAndTime = DateTime.Parse("2023-06-12 01:55")},
            };

            ViewBag.cityWeathers = cityWeathers;
            return View(cityWeathers);
        }
    }
}
