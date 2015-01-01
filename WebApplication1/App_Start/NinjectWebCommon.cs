[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(WebApplication1.App_Start.NinjectWebCommon), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(WebApplication1.App_Start.NinjectWebCommon), "Stop")]

namespace WebApplication1.App_Start
{
    using System;
    using System.Web;

    using Microsoft.Web.Infrastructure.DynamicModuleHelper;
    using WebDirectory.Data.Repository;
  
    using WebDirectory.Services;
    using Ninject;
    using Ninject.Web.Common;


    using Web.Directory.Repository;

    public static class NinjectWebCommon 
    {
        private static readonly Bootstrapper bootstrapper = new Bootstrapper();

        /// <summary>
        /// Starts the application
        /// </summary>
        public static void Start() 
        {
            DynamicModuleUtility.RegisterModule(typeof(OnePerRequestHttpModule));
            DynamicModuleUtility.RegisterModule(typeof(NinjectHttpModule));
            bootstrapper.Initialize(CreateKernel);
        }
        
        /// <summary>
        /// Stops the application.
        /// </summary>
        public static void Stop()
        {
            bootstrapper.ShutDown();
        }
        
        /// <summary>
        /// Creates the kernel that will manage your application.
        /// </summary>
        /// <returns>The created kernel.</returns>
        private static IKernel CreateKernel()
        {
            var kernel = new StandardKernel();
            try
            {
                kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
                kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();

                RegisterServices(kernel);

                System.Web.Http.GlobalConfiguration.Configuration.DependencyResolver = new NinjectResolver(kernel);
                //System.Web.Http.GlobalConfiguration.Configuration.DependencyResolver = new Ninject.Web.WebApi.NinjectDependencyResolver(kernel);

                return kernel;
            }
            catch
            {
                kernel.Dispose();
                throw;
            }
        }

        /// <summary>
        /// Load your modules or register your services here!
        /// </summary>
        /// <param name="kernel">The kernel.</param>
        private static void RegisterServices(IKernel kernel)
        {
            kernel.Bind<IUnitOfWork>().To<UnitOfWork>();
            kernel.Bind<ICompanyCategoryService>().To<CompanyCategoryService>();
            kernel.Bind<IUserService>().To<UserService>();
            kernel.Bind<ICompanyMemberService>().To<CompanyMemberService>();
            kernel.Bind<ICompanyProductServiceService>().To<CompanyProductServiceService>();
            kernel.Bind<ICompanyService>().To<CompanyService>();
            kernel.Bind<ICompanyTranslationService>().To<CompanyTranslationService>();
            kernel.Bind<ICompanyTypeService>().To<CompanyTypeService>();
            kernel.Bind<ICategoryAreaService>().To<CategoryAreaService>();
            kernel.Bind<ICategoryService>().To<CategoryService>();
            kernel.Bind<IPackageService>().To<PackageService>();
            kernel.Bind<IProductCategoryService>().To<ProductCategoryService>();
            kernel.Bind<IAspNetUserService>().To<AspNetUserService>();
            kernel.Bind<ICompaniesCategoryService>().To<CompaniesCategoryService>();
        }        
    }
}
