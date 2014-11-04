using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using LeaveSystem.Domain.Entities;
using LeaveSystem.Domain.Abstract;
using LeaveSystem.WebUI.Models;

namespace LeaveSystem.WebUI.Controllers
{
    public class HomeController : Controller
    {
        /*
        private IProductRepository repository;


        public HomeController(IProductRepository productRepository)
        {
            this.repository = productRepository;
        }
         * */

        private IUserRepository repo;

        public HomeController(IUserRepository userRepository)
        {
            this.repo = userRepository;
        }

        private Person[] personData = {
            new Person {FirstName = "Adam", LastName = "Freeman", Role = Role.Admin},
            new Person {FirstName = "Jacqui", LastName = "Griffyth", Role = Role.User},
            new Person {FirstName = "John", LastName = "Smith",  Role = Role.User},
            new Person {FirstName = "Anne", LastName = "Jones",  Role = Role.Guest}
        };

        public ActionResult Index()
        {

            ViewBag.Fruits = new string[] { "Apple", "Orange", "Pear" };
            ViewBag.Cities = new string[] { "New York", "London", "Paris" };

            string message = "This is an HTML element: <input>";

            return View((object)message);
        }

        public ActionResult CreatePerson()
        {
            return View(new Person());
        }

        [HttpPost]
        public ActionResult CreatePerson(Person person)
        {
            return View("DisplayPerson", person);
        }

        private IEnumerable<Person> GetData(string selectedRole)
        {
            IEnumerable<Person> data = personData;
            if (selectedRole != "All")
            {
                Role selected = (Role)Enum.Parse(typeof(Role),selectedRole);
                data = personData.Where(p => p.Role == selected);
            }
            return data;
        }

        public JsonResult GetPeopleDataJson(string selectedRole = "All")
        {
            var data = GetData(selectedRole).Select(p => new
            {
                FirstName = p.FirstName,
                LastName = p.LastName,
                Role = Enum.GetName(typeof(Role), p.Role)
            });

            return Json(data, JsonRequestBehavior.AllowGet);
        }

        public PartialViewResult GetPeopleData(string selectedRole = "All")
        {
            return PartialView(GetData(selectedRole));
        }

        public ActionResult GetPeople(string selectedRole = "All")
        {
            return View((object)selectedRole);
        }


        public ActionResult GetUser(string selectedGender = "All")
        {
            if (User.Identity.IsAuthenticated)
            {
                ViewBag.IsAuthenticated = "authorised";
                ViewBag.Username = User.Identity.Name;
            }
            return View((object)selectedGender);
        }

        private IEnumerable<User> ToGetData(string selectedGender)
        {
            IEnumerable<User> userData = repo.Users;
            if (selectedGender != "All")
            {
                Gender selected = (Gender)Enum.Parse(typeof(Gender), selectedGender);
                userData = userData.Where(u => u.Gender == selected);
            }
            return userData;
        }

        public PartialViewResult ToGetUserData(string selectedGender = "All")
        {
            return PartialView(ToGetData(selectedGender));
        }
	}
}