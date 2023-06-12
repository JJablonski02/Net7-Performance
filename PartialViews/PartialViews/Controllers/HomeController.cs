using Microsoft.AspNetCore.Mvc;
using PartialViews.Models;

namespace PartialViews.Controllers
{
    public class HomeController : Controller
    {
        [Route("/")]
        public IActionResult Index()
        {
            ViewData["ListTitle"] = "Cities";
            ViewData["ListItems"] = new List<string>()
            {
                "Paris",
                "New York",
                "New Mumbai",
                "Rome"
            };
            return View();
        }

        [Route("about")]
        public IActionResult About()
        {
            return View();
        }

        [Route("programming-languages")]
        public IActionResult ProgrammingLanguage()
        {
            ListModel listmodel = new ListModel()
            {
                ListTitle = "Programming Language List",
                ListItems = new List<string>()
                {
                    "Python",
                    "C#",
                    "Go",
                    "JS",
                    "React"
                }
            };
            return PartialView("_LKistPartialView", listmodel);
        }
    }
}
