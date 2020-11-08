using Es.Udc.DotNet.PracticaMaD.Model.Model1Daos.CategoryDao;
using Es.Udc.DotNet.PracticaMaD.Model.Model1Daos.CreditCardDao;
using Es.Udc.DotNet.PracticaMaD.Model.Model1Daos.OrderDao;
using Es.Udc.DotNet.PracticaMaD.Model.Model1Daos.OrderItemDao;
using Es.Udc.DotNet.PracticaMaD.Model.Model1Daos.ProductDao;
using Es.Udc.DotNet.PracticaMaD.Model.Model1Daos.TagDao;
using Es.Udc.DotNet.PracticaMaD.Model.Model1Daos.UserDao;
using Es.Udc.DotNet.PracticaMaD.Model.Services.ProductService;
using Es.Udc.DotNet.PracticaMaD.Model.Services.UserService;
using Ninject;
using System.Configuration;
using System.Data.Entity;

namespace Es.Udc.DotNet.PracticaMaD.Test
{
    public class TestManager
    {
        /// <summary>
        /// Configures and populates the Ninject kernel
        /// </summary>
        /// <returns>The NInject kernel</returns>
        public static IKernel ConfigureNInjectKernel()
        {

            #region configuration via sourcecode

            IKernel kernel = new StandardKernel();

            kernel.Bind<IProductService>().To<ProductService>();

            kernel.Bind<IProductDao>().
                To<ProductDaoEntityFramework>();

            kernel.Bind<ICategoryDao>().To<CategoryDaoEntityFramework>();

            kernel.Bind<ITagDao>().To<TagDaoEntityFramework>();

            kernel.Bind<IOrderDao>().To<OrderDaoEntityFramework>();

            kernel.Bind<IOrderItemDao>().To<OrderItemDaoEntityFramework>();

            kernel.Bind<IUserService>().To<UserService>();

            kernel.Bind<IUserDao>().
                To<UserDaoEntityFramework>();

            kernel.Bind<ICreditCardDao>().
                To<CreditCardDaoEntityFramework>();


            string connectionString =
                ConfigurationManager.ConnectionStrings["ecommerceEntities"].ConnectionString;

            kernel.Bind<DbContext>().
                ToSelf().
                InSingletonScope().
                WithConstructorArgument("nameOrConnectionString", connectionString);

            #endregion  configuration via sourcecode

            return kernel;
        }

        /// <summary>
        /// Configures the Ninject kernel from an external module file.
        /// </summary>
        /// <param name="moduleFilename">The module filename.</param>
        /// <returns>The NInject kernel</returns>
        public static IKernel ConfigureNInjectKernel(string moduleFilename)
        {
            IKernel kernel = new StandardKernel();
            kernel.Load(moduleFilename);

            return kernel;
        }

        public static void ClearNInjectKernel(IKernel kernel)
        {
            kernel.Dispose();
        }
    }
}