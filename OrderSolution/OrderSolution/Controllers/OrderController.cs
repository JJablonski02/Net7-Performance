using Microsoft.AspNetCore.Mvc;
using OrderSolution.Models;

namespace OrderSolution.Controllers
{
    public class OrderController : Controller
    {
        [Route("/order")]
        public IActionResult Index([Bind(nameof(Order.OrderDate), nameof(Order.InvoicePrice), nameof(Order.Products))]Order order)
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