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

        public CartDto AddProductToCart(CartDto cart, long productId, int quantity)
        {
            ProductDetails product = ProductService.FindProductDetails(productId);
            CartLineDto line = new CartLineDto(productId, quantity, false);

            if (cart.cartLines.Contains(line))
            {
                return this.UpdateCart(cart, productId, quantity, false);
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
            if(cart.cartLines.Count > 0)
            {
                foreach (CartLineDto cartLine in cart.cartLines) {
                    if (cartLine.productId == productId)
                    {
                        ProductDetails product = ProductService.FindProductDetails(productId);
                        if(quantity != 0)
                        {
                            quantity += cartLine.quantity;
                            if (product.stockUnits < quantity || quantity <=0)
                            {
                                throw new OutOfStockProductException(product.name);
                            }
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
                foreach(CartLineDto cartLine in cart.cartLines){
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
