using Es.Udc.DotNet.ModelUtil.IoC;
using Es.Udc.DotNet.PracticaMaD.Model.ECommerceServices.CategoryService;
using Es.Udc.DotNet.PracticaMaD.Model.Model1Daos.BookDao;
using Es.Udc.DotNet.PracticaMaD.Model.Model1Daos.CategoryDao;
using Es.Udc.DotNet.PracticaMaD.Model.Model1Daos.CreditCardDao;
using Es.Udc.DotNet.PracticaMaD.Model.Model1Daos.MovieDao;
using Es.Udc.DotNet.PracticaMaD.Model.Model1Daos.MusicDao;
using Es.Udc.DotNet.PracticaMaD.Model.Model1Daos.ProductDao;
using Es.Udc.DotNet.PracticaMaD.Model.Model1Daos.UserDao;
using Es.Udc.DotNet.PracticaMaD.Model.Services.ProductService;
using Es.Udc.DotNet.PracticaMaD.Model.Services.UserService;
using Ninject;
using System.Configuration;
using System.Data.Entity;

namespace Es.Udc.DotNet.PracticaMaD.Web.HTTP.Util.IoC
{
    internal class IoCManagerNinject : IIoCManager
    {
        private static IKernel kernel;
        private static NinjectSettings settings;

        public void Configure()
        {
            settings = new NinjectSettings() { LoadExtensions = true };
            kernel = new StandardKernel(settings);

            /* UserProfileDao */
            kernel.Bind<IUserDao>().
                To<UserDaoEntityFramework>(); 
            
            kernel.Bind<ICreditCardDao>().
                 To<CreditCardDaoEntityFramework>();

            /* UserService */
            kernel.Bind<IUserService>().
                To<UserService>();

            /* ProductService */
            kernel.Bind<IProductService>().
                To<ProductService>();

            /* ProductDao */
            kernel.Bind<IProductDao>().
                To<ProductDaoEntityFramework>();

            /* MusicDao */
            kernel.Bind<IMusicDao>().
                To<MusicDaoEntityFramework>();

            /* MovieDao */
            kernel.Bind<IMovieDao>().
                To<MovieDaoEntityFramework>();

            /* BookDao */
            kernel.Bind<IBookDao>().
                To<BookDaoEntityFramework>();

            /* CategoryService */
            kernel.Bind<ICategoryService>().
                To<CategoryService>();

            /* CategoryDao */
            kernel.Bind<ICategoryDao>().
                To<CategoryDaoEntityFramework>();

            /* DbContext */
            string connectionString =
                ConfigurationManager.ConnectionStrings["ecommerceEntities"].ConnectionString;

            kernel.Bind<DbContext>().
                ToSelf().
                InSingletonScope().
                WithConstructorArgument("nameOrConnectionString", connectionString);
        }

        public T Resolve<T>()
        {
            return kernel.Get<T>();
        }
    }
}