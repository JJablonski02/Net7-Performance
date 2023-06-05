using Controllers.Models;
using Microsoft.AspNetCore.Mvc;

namespace Controllers.Controllers
{
    public class HomeController : Controller
    {
        
        [Route("/home")]
        [Route("/")]

        public ContentResult IndexOne()
        {
            return new ContentResult()
            {
                Content =
            "Hello from IndexOne",
                ContentType = "text/plain"
            };

            return Content("Hello from IndexOne", "text/plain");

            return Content("<h1>Welcome</h1> <h2>Hello from IndexOne</h2>", "text/html");
        }

        [Route("person")]
        public JsonResult Person()
        {
            Person person = new Person()
            {
                Id = Guid.NewGuid(),
                Name = "Jacob",
                Age = 30,
                Description = "my name's Jacob"
            };
            //return new JsonResult(person);
            return Json(person);
        }

        [Route("contact-us/{mobile:regex(^\\d{{10}}$)}")]

        public int Contact()
        {
            return 0;
        }

        [Route("file-download")]
        public VirtualFileResult FileDownload()
        {
            return File("/sample.jpg", "application/jpg");
        }

        [Route("file-download2")]
        public PhysicalFileResult FileDownload2()
        {
            return new PhysicalFileResult(fileName: "{full_path_of_jpg_on_your_device}", contentType: "application/jpg");
        }

        [Route("file-download3")]
        public FileResult fileDownload3()
        {
            byte[] bytes = System.IO.File.ReadAllBytes(@"{full_path_of_jpg_on_your_device}");
            return File(bytes, "application/jpg");
        }

        [Route("book")]
        public IActionResult IndexTwo()
        {
            if (!Request.Query.ContainsKey("bookid"))
            {
                Response.StatusCode = 400;
                return Content("Book id is not supplied");
            }
            if (string.IsNullOrEmpty(Convert.ToString(Request.Query["bookid"])))
            {
                Response.StatusCode = 400;
                return Content("Book id can not be null or empty");
            }

            int bookdid = Convert.ToInt16(ControllerContext.HttpContext.Request.Query["bookid"]);
            if (bookdid <= 0)
            {
                Response.StatusCode = 400;
                return Content("Book id can not be less or equal to zero");
            }
            if (bookdid > 1000)
            {
                Response.StatusCode = 400;
                return Content("Book id can not be greater than 1000");
            }
            if (Convert.ToBoolean(Request.Query["isloggedin"] == false))
            {
                Response.StatusCode = 401;
                return Content("Isloggedid is not true. User must be authenticated");
            }
            return File("/sample.jpg", "application/jpg");
        }
    }
}
