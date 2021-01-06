using Es.Udc.DotNet.ModelUtil.Exceptions;
using Es.Udc.DotNet.PracticaMaD.Model.Services.ProductService;
using Ninject;

namespace Es.Udc.DotNet.PracticaMaD.Model.ECommerceServices.CartService
{
    public interface ICartService
    {
        [Inject]
        IProductService ProductService { set; }

        CartDto CreateCart();

        /// <exception cref="InstanceNotFoundException"/>
        /// <exception cref="OutOfStockProductException"/>
        CartDto AddProductToCart(CartDto cart, long productId, int quantity, bool toPresent);

        /// <exception cref="OutOfStockProductException"/>
        CartDto UpdateCart(CartDto cart, long productId, int quantity, bool isPresent);

        CartDto RemoveProductFromCart(CartDto cart, long productId);
    }
}
