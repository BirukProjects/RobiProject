using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Web.Directory.Repository;
using WebDirectory.Data.Repository;
using Ninject;
using WebDirectory.Services;


namespace WebApplication1.Infrastructure
{
    public class NinjectDependencyResolver
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
            kernel.Bind<ICompanyCategoryService>().To<WebDirectory.Services.CompanyCategoryService>();
            kernel.Bind<IUserService>().To<UserService>();
            kernel.Bind<ICompanyMemberService>().To<CompanyMemberService>();
            kernel.Bind<ICompanyProductServiceService>().To<CompanyProductServiceService>();
            kernel.Bind<ICompanyService>().To<CompanyService>();
            kernel.Bind<ICompanyTranslationService>().To<CompanyTranslationService>();

        }
    }
}