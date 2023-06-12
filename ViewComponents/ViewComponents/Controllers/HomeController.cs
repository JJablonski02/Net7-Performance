using Microsoft.AspNetCore.Mvc;
using ViewComponents.Models;

namespace ViewComponents.Controllers
{
    public class HomeController : Controller
    {
        [Route("/")]
        public IActionResult Index()
        {
            return View();
        }

        [Route("/about")]
        public IActionResult About()
        {
            return View();
        }

        [Route("friends-list")]
        public IActionResult LoadFriendList()
        {
                PersonGridModel personGridModel = new PersonGridModel()
                {
                    GridTitle = "Friends",
                    Persons = new List<Person>()
                    {
                        new Person() {PersonName = "Mia", JobTitle ="UI designer"},
                        new Person() {PersonName = "Lee", JobTitle ="UX designer"},
                        new Person() {PersonName = "William", JobTitle ="QA"},
                    }
                };
            return ViewComponent("Grid", new {grid = personGridModel});
        }
    }
}
