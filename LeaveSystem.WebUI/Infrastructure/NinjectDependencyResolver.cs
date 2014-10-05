using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using Ninject;
using System.Web.Mvc;

using Moq;
using LeaveSystem.Domain.Abstract;
using LeaveSystem.Domain.Entities;
using LeaveSystem.Domain.Concrete;

namespace LeaveSystem.WebUI.Infrastructure
{
    public class NinjectDependencyResolver:IDependencyResolver
    {
        private IKernel kernel;
        public NinjectDependencyResolver()
        {
            kernel = new StandardKernel();
            AddBindings();
        }
        public object GetService(Type serviceType)
        {
            return kernel.TryGet(serviceType);
        }
        public IEnumerable<object> GetServices(Type serviceType)
        {
            return kernel.GetAll(serviceType);
        }
        private void AddBindings()
        {
            //kernel.Bind<IProductRepository>().To<EFProductRepository>();
            //kernel.Bind<IAuthProvider>().To<FormsAuthProvider>();

            /*
            Mock<IProductRepository> mock = new Mock<IProductRepository>();

            mock.Setup(m => m.Products).Returns(new List<Product>{
                new Product{Name="Football",Price=25},
                new Product{Name="Surf board",Price=179},
                new Product{Name="Running shoes",Price=95}
            });

            kernel.Bind<IProductRepository>().ToConstant(mock.Object);
             * */
            kernel.Bind<IProductRepository>().To<EFProductRepository>();
            kernel.Bind<IUserRepository>().To<EFUserRepository>();
        }
    }
}