using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
