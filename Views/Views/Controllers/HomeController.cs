using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography.X509Certificates;
using Views.Models;

namespace Views.Controllers
{
    public class HomeController : Controller
    {
        [Route("/home")]
        [Route("/")]
        public IActionResult Index()
        {
            ViewData["pageTitle"] = "Asp.Net Core Demo App";

            List<Person> people = new List<Person>()
            {
        new Person() {Name = "Jakub", DateOfBirth = DateTime.Parse("2002-05-28"), PersonGender = Gender.Male},
        new Person() {Name = "Bella", DateOfBirth = DateTime.Parse("2002-03-22"), PersonGender = Gender.Female},
        new Person() {Name = "Jake", DateOfBirth = DateTime.Parse("2002-12-25"), PersonGender = Gender.Other}
            };
            //ViewData["people"] = people;
            //ViewBag.people = people;

            return View("Index", people); //view/home/Index.cshtml defaultly
            //return View("abc"); //abc.cshtml view
            //return new ViewResult() { ViewName= "Home" };
        }
        [Route("/person-details/{name}")]
        public IActionResult Details(string? name)
        {
            if (name == null)
            {
                return Content("Person name cannot be null");
            }
            else
            {
                List<Person> people = new List<Person>()
            {
                new Person() {Name = "Jakub", DateOfBirth = DateTime.Parse("2002-05-28"), PersonGender = Gender.Male},
                new Person() {Name = "Bella", DateOfBirth = DateTime.Parse("2002-03-22"), PersonGender = Gender.Female},
                new Person() {Name = "Jake", DateOfBirth = DateTime.Parse("2002-12-25"), PersonGender = Gender.Other}
            };
                Person? matchingPerson = people.Where(temp => temp.Name == name).FirstOrDefault();
                return View(matchingPerson); //Views/home/details.cshtml
            }
        }
        [Route("person-with-product")]
        public IActionResult PersonWithProduct()
        {
            Person person = new Person()
            {
                Name = "Sara",
                PersonGender = Gender.Female,
                DateOfBirth = Convert.ToDateTime("2004-05-15")
            };

            Product product = new Product()
            {
                ProductId = 1,
                ProductName = "Shelf"
            };

            PersonWithProductWrapperModel personWithductWrapperModel = new PersonWithProductWrapperModel()
            {
                PersonData = person,
                ProductData = product
            };
            return View(personWithductWrapperModel);
        }

        [Route("products/all")]
        public IActionResult All()
        {
            return View();
        }
    }
}
