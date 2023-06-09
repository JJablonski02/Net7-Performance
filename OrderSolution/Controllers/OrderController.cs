using Microsoft.AspNetCore.Mvc;

namespace OrderSolution.Controllers
{
    public class OrderController : Controller
    {
        [Route("/order")]
        public IActionResult Index()
        {
            if (!ModelState.IsValid)
            {
                string messages = string.Join("\n", ModelState.Values.SelectMany(x=>x.Errors).Select(e=>e.ErrorMessage));

                return BadRequest(messages);
            }

            Random random = new Random();
            int randomOrderNumber = random.Next(0, 1000);

            return Json(new {orderNumbers = randomOrderNumber });
        }
    }
}