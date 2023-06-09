using Microsoft.AspNetCore.Mvc;

namespace OrderSolution.Controllers
{
    public class OrderController : Controller
    {
        [Route("/order")]
        public IActionResult Index()
        {
            Random random = new Random();
            int randomOrderNumber = random.Next(0, 1000);

            return Json(new {orderNumber = randomOrderNumber });
        }
    }
}
