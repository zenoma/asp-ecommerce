using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Es.Udc.DotNet.PracticaMaD.Model.ECommerceServices.OrderService
{
    public class OrderBlock
    {
        public List<Order> Orders { get; private set; }
        public bool existMoreOrders { get; private set; }

        public OrderBlock(List<Order> orders, bool existMoreOrders)
        {
            this.Orders = orders;
            this.existMoreOrders = existMoreOrders;
        }
    }
}
