using Microsoft.AspNetCore.Mvc;
using ModelValidations.Models;
namespace ModelValidations.Controllers
{
    public class HomeController : Controller
    {
        [Route("register")]
        //public IActionResult Index([Bind(nameof(Person.PersonName), nameof(Person.Email), 
        //    nameof(Person.Password), nameof(Person.ConfirmPassword))]Person person)
        public IActionResult Index([FromBody]Person person) 
         {
            List<string> errorsList = new List<string>();
            if (!ModelState.IsValid)
            {
                string errors = string.Join("\n",
                    ModelState.Values.SelectMany(value => value.Errors).Select
                    (err => err.ErrorMessage));
               return BadRequest(errors);
            }
            return Content($"{person}");
        }
    }
}
