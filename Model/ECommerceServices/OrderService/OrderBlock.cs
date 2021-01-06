using System.Collections.Generic;

namespace Es.Udc.DotNet.PracticaMaD.Model.ECommerceServices.OrderService
{
    public class OrderBlock
    {
        public List<OrderDto> Orders { get; private set; }
        public bool existMoreOrders { get; private set; }

        public OrderBlock(List<OrderDto> orders, bool existMoreOrders)
        {
            this.Orders = orders;
            this.existMoreOrders = existMoreOrders;
        }
    }
}
