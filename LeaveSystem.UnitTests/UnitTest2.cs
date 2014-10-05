using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Web.Mvc;

using System.Linq;
using Moq;
using LeaveSystem.Domain.Abstract;
using LeaveSystem.WebUI.Controllers;
using LeaveSystem.WebUI.Models;
using LeaveSystem.Domain.Entities;

namespace LeaveSystem.UnitTests
{
    [TestClass]
    public class UnitTest2
    {
        [TestMethod]
        public void Can_Add_To_Cart()
        {
            // Arrange - create the mock repository
            Mock<IProductRepository> mock = new Mock<IProductRepository>();
            mock.Setup(m => m.Products).Returns(new Product[] {
                new Product {ProductID = 1, Name = "P1", Category = "Apples"},
            }.AsQueryable());
            // Arrange - create a Cart
            Cart cart = new Cart();
            // Arrange - create the controller
            CartController target = new CartController(mock.Object);
            // Act - add a product to the cart
            target.AddToCart(cart, 1, null);
            // Assert
            Assert.AreEqual(cart.Lines.Count(), 1);
            Assert.AreEqual(cart.Lines.ToArray()[0].Product.ProductID, 1);
        }
    }
}
