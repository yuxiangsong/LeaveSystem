using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Web;
using System.Web.Mvc;

using System.Linq;
using Moq;
using LeaveSystem.Domain.Abstract;
using LeaveSystem.Domain.Entities;
using LeaveSystem.WebUI.Controllers;
using LeaveSystem.WebUI.Models;
using LeaveSystem.WebUI.HtmlHelpers;

namespace LeaveSystem.UnitTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Indicates_Selected_Category()
        {
            // Arrange
            // - create the mock repository
            Mock<IProductRepository> mock = new Mock<IProductRepository>();
            mock.Setup(m => m.Products).Returns(new Product[] {
                new Product {ProductID = 1, Name = "P1", Category = "Apples"},
                new Product {ProductID = 4, Name = "P2", Category = "Oranges"},
            });

            // Arrange - create the controller
            NavController target = new NavController(mock.Object);
            // Arrange - define the category to selected
            string categoryToSelect = "Apples";

            // Action
            string result = target.Menu(categoryToSelect).ViewBag.SelectedCategory;

            // Assert
            Assert.AreEqual(categoryToSelect, result);
        }

        [TestMethod]
        public void Can_Paginate()
        {
            //arrange
            Mock<IProductRepository> mock = new Mock<IProductRepository>();

            mock.Setup(m => m.Products).Returns(new Product[]{
                new Product{ProductID=1,Name="P1"},
                new Product{ProductID=2,Name="P2"},
                new Product{ProductID=3,Name="P3"},
                new Product{ProductID=4,Name="P4"},
                new Product{ProductID=5,Name="P5"},
            });

            var controller = new ProductController(mock.Object);
            controller.PageSize = 3;

            //act
            //IEnumerable<Product> result = (IEnumerable<Product>)controller.List(2);
            //var products = ((ViewResult)result).ViewData.Model as IEnumerable<Product>;
            ProductsListViewModel result = (ProductsListViewModel)controller.List(null, 2).Model;

            //assert
            //Product[] prodArray = result.ToArray();
            Product[] prodArray = result.Products.ToArray();

            Assert.IsTrue(prodArray.Length == 2);
            Assert.AreEqual(prodArray[0].Name, "P4");
            Assert.AreEqual(prodArray[1].Name, "P5");
        }

        [TestMethod]
        public void Can_Send_Pagination_View_Model()
        {
            //arrange
            Mock<IProductRepository> mock = new Mock<IProductRepository>();

            mock.Setup(m => m.Products).Returns(new Product[]{
                new Product{ProductID=1,Name="P1"},
                new Product{ProductID=2,Name="P2"},
                new Product{ProductID=3,Name="P3"},
                new Product{ProductID=4,Name="P4"},
                new Product{ProductID=5,Name="P5"},
            });

            var controller = new ProductController(mock.Object);

            controller.PageSize = 3;

            //act
            ProductsListViewModel result = (ProductsListViewModel)controller.List(null, 2).Model;

            PagingInfo pageinfo = result.PagingInfo;
            Assert.AreEqual(pageinfo.CurrentPage, 2);
            Assert.AreEqual(pageinfo.ItemsPerPage, 3);
            Assert.AreEqual(pageinfo.TotalItems, 5);
            Assert.AreEqual(pageinfo.TotalPages, 2);
        }

        [TestMethod]
        public void Can_Generate_Page_Links()
        {
            //arrange
            HtmlHelper myHelper = null;

            PagingInfo pagingInfo = new PagingInfo
            {
                CurrentPage = 2,
                TotalItems = 28,
                ItemsPerPage = 10
            };

            Func<int, string> pageUrlDelegage = i => "Page" + i;

            //act
            MvcHtmlString result = myHelper.PageLinks(pagingInfo, pageUrlDelegage);

            //assert
            Assert.AreEqual(@"<a class=""btn btn-default"" href=""Page1"">1</a>"
                            + @"<a class=""btn btn-default btn-primary selected"" href=""Page2"">2</a>"
                            + @"<a class=""btn btn-default"" href=""Page3"">3</a>",
                            result.ToString()
                            );
        }

        [TestMethod]
        public void Can_Filter_Products()
        {
            // Arrange
            // - create the mock repository
            Mock<IProductRepository> mock = new Mock<IProductRepository>();
            mock.Setup(m => m.Products).Returns(new Product[] {
                new Product {ProductID = 1, Name = "P1", Category = "Cat1"},
                new Product {ProductID = 2, Name = "P2", Category = "Cat2"},
                new Product {ProductID = 3, Name = "P3", Category = "Cat1"},
                new Product {ProductID = 4, Name = "P4", Category = "Cat2"},
                new Product {ProductID = 5, Name = "P5", Category = "Cat3"}
            });
            // Arrange - create a controller and make the page size 3 items
            ProductController controller = new ProductController(mock.Object);
            controller.PageSize = 3;
            // Action
            Product[] result = ((ProductsListViewModel)controller.List("Cat2", 1).Model).Products.ToArray();
            // Assert
            Assert.AreEqual(result.Length, 2);
            Assert.IsTrue(result[0].Name == "P2" && result[0].Category == "Cat2");
            Assert.IsTrue(result[1].Name == "P4" && result[1].Category == "Cat2");
        }

        [TestMethod]
        public void Can_Create_Categories()
        {
            // Arrange
            // - create the mock repository
            Mock<IProductRepository> mock = new Mock<IProductRepository>();
            mock.Setup(m => m.Products).Returns(new Product[] {
                new Product {ProductID = 1, Name = "P1", Category = "Apples"},
                new Product {ProductID = 2, Name = "P2", Category = "Apples"},
                new Product {ProductID = 3, Name = "P3", Category = "Plums"},
                new Product {ProductID = 4, Name = "P4", Category = "Oranges"},
            });
            // Arrange - create the controller
            NavController target = new NavController(mock.Object);
            // Act = get the set of categories
            string[] results = ((IEnumerable<string>)target.Menu().Model).ToArray();
            // Assert
            Assert.AreEqual(results.Length, 3);
            Assert.AreEqual(results[0], "Apples");
            Assert.AreEqual(results[1], "Oranges");
            Assert.AreEqual(results[2], "Plums");
        }
    }
}
