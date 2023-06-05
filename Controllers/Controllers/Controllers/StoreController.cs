using Microsoft.AspNetCore.Mvc;

namespace Controllers.Controllers
{
    public class StoreController : Controller
    {
        [Route("store/books")]
        public IActionResult Books()
        {
            return View();
        }
    }
}
