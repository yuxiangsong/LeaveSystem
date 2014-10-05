using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using LeaveSystem.Domain.Abstract;

namespace LeaveSystem.WebUI.Controllers
{
    public class NavController : Controller
    {
        private IProductRepository repository;

        public NavController(IProductRepository repo)
        {
            repository = repo;
        }

        public PartialViewResult Menu(string category = null)
        {
            ViewBag.SelectedCategory = category;

            IEnumerable<string> categories = repository.Products
                .Select(x => x.Category)
                .Distinct()
                .OrderBy(x => x);

            return PartialView(categories);
        }

        public PartialViewResult MenuMasthead(string selectedMenu = "Home")
        {
            ViewBag.SelectedMastheadMenu = selectedMenu;

            IEnumerable<string> menus = new string[]{"Home","About us","Contact"};

            return PartialView(menus);
        }
	}
}