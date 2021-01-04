using Es.Udc.DotNet.PracticaMaD.Model.ECommerceServices.Exceptions;
using Es.Udc.DotNet.PracticaMaD.Model.Services.ProductService;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Es.Udc.DotNet.PracticaMaD.Model.ECommerceServices.CartService
{
    public class CartService : ICartService
    {
        [Inject]
        public IProductService ProductService { private get; set; }

        public CartDto CreateCart()
        {
            return new CartDto();
        }

        public CartDto AddProductToCart(CartDto cart, long productId, int quantity, bool toPresent)
        {
            ProductDetails product = ProductService.FindProductDetails(productId);
            CartLineDto line = new CartLineDto(productId, product.name, quantity, product.unitPrice, toPresent);

            if (cart.cartLines.Contains(line))
            {
                return UpdateCart(cart, productId, quantity, toPresent);
            }

            if (product.stockUnits < quantity)
            {
                throw new OutOfStockProductException(product.name);
            }

            cart.cartLines.Add(line);

            return cart;
        }

        public CartDto UpdateCart(CartDto cart, long productId, int quantity, bool toPresent)
        {
            if (cart.cartLines.Count > 0)
            {
                foreach (CartLineDto cartLine in cart.cartLines)
                {
                    if (cartLine.productId == productId)
                    {
                        ProductDetails product = ProductService.FindProductDetails(productId);
                        if (product.stockUnits < quantity)
                        {
                            throw new OutOfStockProductException(product.name);
                        }

                        if (quantity != 0)
                        {
                            cartLine.quantity = quantity;
                        }
                        cartLine.toPresent = toPresent;
                        break;
                    }
                };
            }

            return cart;
        }

        public CartDto RemoveProductFromCart(CartDto cart, long productId)
        {
            if (cart.cartLines.Count > 0)
            {
                foreach (CartLineDto cartLine in cart.cartLines)
                {
                    if (cartLine.productId == productId)
                    {
                        cart.cartLines.Remove(cartLine);
                        break;
                    }
                }
            }

            return cart;
        }
    }
}
