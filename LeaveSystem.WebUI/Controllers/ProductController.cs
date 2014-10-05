using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using System.Web.Routing;

using LeaveSystem.Domain.Entities;
using LeaveSystem.Domain.Abstract;
using LeaveSystem.WebUI.Models;

namespace LeaveSystem.WebUI.Controllers
{
    public class ProductController : Controller
    {
        private IProductRepository repository;
        public int PageSize = 4;

        public ProductController(IProductRepository productRepository)
        {
            this.repository = productRepository;
        }

        public ViewResult List(string category, int page = 1)
        {
            //return View(repository.Products);

            /*
            return View(repository.Products
                .OrderBy(p => p.ProductID)
                .Skip((page - 1) * PageSize)
                .Take(PageSize));
            */

           ProductsListViewModel model = new ProductsListViewModel{
               Products=repository.Products
                   .Where(p => category == null || category == p.Category)
                   .OrderBy(p => p.ProductID)
                   .Skip((page - 1) * PageSize)
                   .Take(PageSize),
                   PagingInfo = new PagingInfo{
                       CurrentPage=page,
                       ItemsPerPage=PageSize,
                       TotalItems= (category == null) ? repository.Products.Count() : repository.Products.Where(e=>e.Category==category).Count()
                   },
                   CurrentCategory = category
           };

           //ViewBag.Page = RouteData.Values["page"];

           return View(model);
           
        }
	}
}