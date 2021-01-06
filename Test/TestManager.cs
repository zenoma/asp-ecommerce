using Es.Udc.DotNet.PracticaMaD.Model.ECommerceDaos.RoleDao;
using Es.Udc.DotNet.PracticaMaD.Model.ECommerceServices.CartService;
using Es.Udc.DotNet.PracticaMaD.Model.ECommerceServices.CategoryService;
using Es.Udc.DotNet.PracticaMaD.Model.ECommerceServices.CommentService;
using Es.Udc.DotNet.PracticaMaD.Model.ECommerceServices.OrderService;
using Es.Udc.DotNet.PracticaMaD.Model.ECommerceServices.TagService;
using Es.Udc.DotNet.PracticaMaD.Model.Model1Daos.BookDao;
using Es.Udc.DotNet.PracticaMaD.Model.Model1Daos.CategoryDao;
using Es.Udc.DotNet.PracticaMaD.Model.Model1Daos.CommentDao;
using Es.Udc.DotNet.PracticaMaD.Model.Model1Daos.CreditCardDao;
using Es.Udc.DotNet.PracticaMaD.Model.Model1Daos.MovieDao;
using Es.Udc.DotNet.PracticaMaD.Model.Model1Daos.MusicDao;
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

            // DAOS
            kernel.Bind<IProductDao>().To<ProductDaoEntityFramework>();

            kernel.Bind<ICategoryDao>().To<CategoryDaoEntityFramework>();

            kernel.Bind<ITagDao>().To<TagDaoEntityFramework>();

            kernel.Bind<IOrderDao>().To<OrderDaoEntityFramework>();

            kernel.Bind<IOrderItemDao>().To<OrderItemDaoEntityFramework>();

            kernel.Bind<IUserDao>().To<UserDaoEntityFramework>();

            kernel.Bind<ICreditCardDao>().To<CreditCardDaoEntityFramework>();

            kernel.Bind<ICommentDao>().To<CommentDaoEntityFramework>();

            kernel.Bind<IMusicDao>().To<MusicDaoEntityFramework>();

            kernel.Bind<IMovieDao>().To<MovieDaoEntityFramework>();

            kernel.Bind<IBookDao>().To<BookDaoEntityFramework>();

            kernel.Bind<IRoleDao>().To<RoleDaoEntityFramework>();

            // SERVICES
            kernel.Bind<IProductService>().To<ProductService>();

            kernel.Bind<IUserService>().To<UserService>();

            kernel.Bind<IOrderService>().To<OrderService>();

            kernel.Bind<ICommentService>().To<CommentService>();

            kernel.Bind<ITagService>().To<TagService>();

            kernel.Bind<ICategoryService>().To<CategoryService>();

            kernel.Bind<ICartService>().To<CartService>();

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