using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using LeaveSystem.Domain.Entities;
using LeaveSystem.Domain.Abstract;

namespace LeaveSystem.WebUI.Controllers
{
    
    public class AccountController : Controller
    {
        
        IUserRepository userRepository;

        public AccountController(IUserRepository repo)
        {
            userRepository = repo;
        }
        
        public ActionResult Index()
        {
            return View();
        }

        //[ActionName("register-page")]
        public ActionResult Register()
        {
            //if(User.Identity.IsAuthenticated)
            return View();
        }

        [HttpPost]
        public ActionResult Register(User user)
        {
            //string testvalue = user.HomeAddress.City;
            //User test = user;

            if (ModelState.IsValid)
            {
                userRepository.SaveUser(user);
                TempData["userMessage"] = string.Format("Welcome {0}! Your account is created. ", user.Username);

                return RedirectToAction("Index");
            }
            else
            {
                return View(user);
            }
        }

        [HttpGet]
        //[ActionName("logging")]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(string Username, string Password, string returnUrl)
        {
            User user = new User { Username = Username, Password = Password };
            //if (ModelState.IsValid)
            if (ModelState.IsValid)
            {
                if (user.IsValidUser(user.Username, user.Password))
                {
                    FormsAuthentication.SetAuthCookie(user.Username, true);
                    //return RedirectToAction("Index", "Admin");

                    //returnUrl = Request.QueryString("ReturnUrl");
                    return Redirect(returnUrl);
                }
                else
                {
                    ModelState.AddModelError("", "Login data is incorrect!");
                }
            }
            return View(user);
        }
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Admin");
        }

        //create dropdown list for gender
        private void PopulateGenderDropDownList(object selectedGender = null)
        {
            /*
             * 
            var genderQuery = from d in userRepository
                              orderby d.Name
                              select d;
            ViewBag.DepartmentID = new SelectList(genderQuery, "DepartmentID", "Name", selectedGender);
             * */
        }

        //[HttpGet]
        public JsonResult ValidateUsername(string Username)
        {
            /*
            //Product dbEntry = context.Products.Find(product.ProductID);
            User userEntry = userRepository.Users.FirstOrDefault(u => u.Username == Username);

            if (Username.Contains(" "))
            {
                return Json("Username should not contain white spaces", JsonRequestBehavior.AllowGet);
            }else if(userEntry != null){
                return Json("Username has been existing",JsonRequestBehavior.AllowGet);
            }else{
                return Json(true,JsonRequestBehavior.AllowGet);
            }
            */
            
            return Json("Username has been existing", JsonRequestBehavior.AllowGet);
        }//JsonResult

       
	}
}