using System;
using System.Collections.Generic;

namespace Es.Udc.DotNet.PracticaMaD.Model.ECommerceServices.OrderService
{
    public class OrderDto
    {
        #region Properties Region 
        public long orderId { get; set; }
        public List<OrderItemDto> orderItems { get; private set; }
        public long creditCardNumber { get; set; }
        public string address { get; set; }
        public double price { get; set; }
        public System.DateTime orderDate { get; set; }
        #endregion Properties Region
        public OrderDto(long orderId, long creditCardNumber, string address, DateTime orderDate, double price)
        {
            orderItems = new List<OrderItemDto>();
            this.orderId = orderId;
            this.creditCardNumber = creditCardNumber;
            this.address = address;
            this.orderDate = orderDate;
            this.price = price;
        }

    }
}
