using System.Collections.Generic;

namespace Es.Udc.DotNet.PracticaMaD.Model.ECommerceServices.CartService
{
    public class CartDto
    {
        public List<CartLineDto> cartLines { get; private set; }

        public CartDto(List<CartLineDto> cartLines)
        {
            this.cartLines = cartLines;
        }

        public CartDto()
        {
            cartLines = new List<CartLineDto>();
        }
    }
}
