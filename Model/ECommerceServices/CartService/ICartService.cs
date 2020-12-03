using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Es.Udc.DotNet.PracticaMaD.Model.ECommerceServices.CartService
{
    public interface ICartService
    {
        CartDto createCart();

        /// <exception cref="InstanceNotFoundException"/>
        /// <exception cref="OutOfStockProductException"/>
        CartDto addProductToCart(CartDto cart, long productId, int quantity);

        /// <exception cref="OutOfStockProductException"/>
        CartDto updateCart(CartDto cart, long productId, int quantity, bool isPresent);

        CartDto removeProductFromCart(CartDto cart, long productId);
    }
}
