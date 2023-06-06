using Microsoft.AspNetCore.Mvc;

namespace BankSolution.Controllers
{
    public class BankController : Controller
    {
        [Route("/")]
        public IActionResult Index()
        {
            return Content("Welcome to the Best Bank");
        }
        [Route("/account-details")]
        public IActionResult AccountDetails()
        {
            var bankAccount = new { accountNumber = 1001, accountHolderName = "Example Name", currentBalance = 5000 };
            return Json(bankAccount);
        }

        [Route("/account-statement")]
        public IActionResult AccountStatement()
        {
            return File("~/statement.pdf", "application/pdf");
        }

        [Route("/get-current-balance/{accountNumber:int?}")]
        public IActionResult GetCurrentBalance(int? accountNumber)
        { 
            var bankAccount = new { accountNumber = 1001, accountHolderName = "Example Name", currentBalance = 5000 };
     
            if (accountNumber == null)
                return NotFound("Account Number should be supplied");

            if (accountNumber == 1001)
          
                return Content(bankAccount.currentBalance.ToString());
            else
 
                return BadRequest("Account Number should be 1001");
        }
    }
}
