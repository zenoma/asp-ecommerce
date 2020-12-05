using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Es.Udc.DotNet.PracticaMaD.Model.ECommerceServices.OrderService
{
    public class OrderItemDto
    {
        #region Properties Region

        public string productName { get; set; }

        public int units { get; set; }
        public double unitPrice { get; set; }

        #endregion Properties Region

        public OrderItemDto( string productName, int units, double unitPrice)
        {
            this.productName = productName;
            this.units = units;
            this.unitPrice = unitPrice;
        }

        public override bool Equals(object obj)
        {
            return obj is OrderItemDto dto &&
                   productName == dto.productName;
        }
        public override int GetHashCode()
        {
            return HashCode.Combine(productName);
        }

    }
}
