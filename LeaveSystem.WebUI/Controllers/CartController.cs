using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using LeaveSystem.Domain.Abstract;
using LeaveSystem.Domain.Entities;
using LeaveSystem.WebUI.Models;

namespace LeaveSystem.WebUI.Controllers
{
    public class CartController : Controller
    {
        private IProductRepository repository;

        public CartController(IProductRepository repo)
        {
            repository = repo;
        }

        public RedirectToRouteResult AddToCart(Cart cart, int ProductId, string returnUrl)
        {
            Product product = repository.Products
                .FirstOrDefault(p => p.ProductID == ProductId);

            if (product != null)
            {
                //GetCart().AddItem(product, 1);
                cart.AddItem(product, 1);
            }

            return RedirectToAction("Index", new { returnUrl });
        }

        public RedirectToRouteResult RemoveFromCart(Cart cart, int ProductId, string returnUrl)
        {
            Product product = repository.Products
                .FirstOrDefault(p => p.ProductID == ProductId);

            if (product != null)
            {
                //GetCart().RemoveLine(product);
                cart.RemoveLine(product);
            }

            return RedirectToAction("Index", new { returnUrl });
        }

        /*
         * It will leverage the Model Binder
         * 
        private Cart GetCart()
        {
            Cart cart = (Cart)Session["Cart"];

            if (cart == null)
            {
                cart = new Cart();
                Session["Cart"] = cart;
            }

            return cart;
        }
         * */
        

        public ViewResult Index(Cart cart, string returnUrl)
        {
            return View(new CartIndexViewModel{
                //Cart = GetCart(),
                Cart = cart,
                ReturnUrl = returnUrl});
        }

        public PartialViewResult Summary(Cart cart)
        {
            return PartialView(cart);
        }

        public ViewResult Checkout()
        {
            return View(new ShippingDetails());
        }

        [HttpPost]
        public ViewResult Checkout(Cart cart, ShippingDetails shippingDetails)
        {
            if (cart.Lines.Count() == 0)
            {
                ModelState.AddModelError("", "Sorry, your cart is empty");
            }

            if (ModelState.IsValid)
            {
                return View("Completed");
            }
            else
            {
                return View(shippingDetails);
            }
        }
	}//class
}//namespace