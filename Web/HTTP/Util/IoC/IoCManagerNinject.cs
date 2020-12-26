using Es.Udc.DotNet.ModelUtil.IoC;
using Es.Udc.DotNet.PracticaMaD.Model.ECommerceServices.CartService;
using Es.Udc.DotNet.PracticaMaD.Model.ECommerceServices.OrderService;
using Es.Udc.DotNet.PracticaMaD.Model.Model1Daos.CategoryDao;
using Es.Udc.DotNet.PracticaMaD.Model.Model1Daos.CreditCardDao;
using Es.Udc.DotNet.PracticaMaD.Model.Model1Daos.OrderDao;
using Es.Udc.DotNet.PracticaMaD.Model.Model1Daos.OrderItemDao;
using Es.Udc.DotNet.PracticaMaD.Model.Model1Daos.ProductDao;
using Es.Udc.DotNet.PracticaMaD.Model.Model1Daos.UserDao;
using Es.Udc.DotNet.PracticaMaD.Model.ECommerceServices.CategoryService;
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

            /* ICreditCardDao  */
            kernel.Bind<ICreditCardDao>().
                 To<CreditCardDaoEntityFramework>();

            /* UserService */
            kernel.Bind<IUserService>().
                To<UserService>();

            /* ICategoryDao  */
            kernel.Bind<ICategoryDao>().
                To<CategoryDaoEntityFramework>();

            /* CategoryService */
            kernel.Bind<ICategoryService>().
                To<CategoryService>();
                
            /* IProductDao  */
            kernel.Bind<IProductDao>().
                To<ProductDaoEntityFramework>();

            /* IProductService  */
            kernel.Bind<IProductService>().
                To<ProductService>();

            /* OrderItemDao */
            kernel.Bind<IOrderItemDao>().
                To<OrderItemDaoEntityFramework>();

            /* OrderDao */
            kernel.Bind<IOrderDao>().
                To<OrderDaoEntityFramework>();

            /* OrderService */
            kernel.Bind<IOrderService>().
                To<OrderService>();
            
            /* CartService */
            kernel.Bind<ICartService>().
                To<CartService>();

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