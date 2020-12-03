using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Es.Udc.DotNet.PracticaMaD.Model.ECommerceServices.CartService
{
    public class CartLineDto
    {
        #region Properties Region

        public long productId { get; private set; }
        public int quantity { get; set; }
        public bool toPresent { get; set; }

        #endregion

        public CartLineDto(long productId, int quantity, bool toPresent)
        {
            this.productId = productId;
            this.quantity = quantity;
            this.toPresent = toPresent;
        }

        public override bool Equals(object obj)
        {
            return obj is CartLineDto dto &&
                   productId == dto.productId;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(productId);
        }
    }
}
