using System;

namespace Es.Udc.DotNet.PracticaMaD.Model.ECommerceServices.CartService
{
    public class CartLineDto
    {
        #region Properties Region

        public long productId { get; private set; }
        public string productName { get; private set; }

        public double unitPrice { get; private set; }
        public int quantity { get; set; }
        public bool toPresent { get; set; }

        #endregion

        public CartLineDto(long productId, string productName, int quantity, double unitPrice, bool toPresent)
        {
            this.productId = productId;
            this.productName = productName;
            this.quantity = quantity;
            this.unitPrice = unitPrice;
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
