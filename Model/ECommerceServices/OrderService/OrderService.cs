using Castle.Core.Internal;
using Es.Udc.DotNet.PracticaMaD.Model.ECommerceServices.Exceptions;
using Es.Udc.DotNet.PracticaMaD.Model.Model1Daos.CreditCardDao;
using Es.Udc.DotNet.PracticaMaD.Model.Model1Daos.OrderDao;
using Es.Udc.DotNet.PracticaMaD.Model.Model1Daos.OrderItemDao;
using Es.Udc.DotNet.PracticaMaD.Model.Model1Daos.ProductDao;
using Es.Udc.DotNet.PracticaMaD.Model.Model1Daos.UserDao;
using Es.Udc.DotNet.PracticaMaD.Model.Services.Exceptions;
using Ninject;
using System;
using System.Collections.Generic;

namespace Es.Udc.DotNet.PracticaMaD.Model.ECommerceServices.OrderService
{
    public class OrderService : IOrderService
    {
        [Inject]
        public IOrderDao orderDao { private get; set; }

        [Inject]
        public IUserDao userDao { private get; set; }

        [Inject]
        public ICreditCardDao creditCardDao { private get; set; }

        [Inject]
        public IOrderItemDao orderItemDao { private get; set; }

        [Inject]
        public IProductDao productDao { private get; set; }



        /// <exception cref="EmptyOrderItemListException"/>
        public OrderDto CreateOrder(string login, List<OrderItem> orderItems, long creditCardId, string address)
        {
            
            if (orderItems.IsNullOrEmpty())
            {
                throw new EmptyOrderItemListException(login);
            }
            else
            {
                Order order = new Order();
                double price = 0;
                User user = userDao.FindByLogin(login);
                order.userId = user.userId;
                order.creditCardId = creditCardId;
                order.address = address;
                order.orderDate = DateTime.Now;
                orderDao.Create(order);

                foreach (var item in orderItems)
                {
                    if (isSalable(item)) {
                        OrderItem orderItem = new OrderItem();
                        orderItem.orderId = order.orderId;
                        orderItem.productId = item.productId;
                        orderItem.units = item.units;
                        orderItem.unitPrice = item.unitPrice;
                        orderItemDao.Create(orderItem);
                        price += item.units * item.unitPrice;
                    }
                    
                }
                order.price = price;
                return toOrderDto(order);
            }
        }

        public OrderDto FindByOrderId(long orderId)
        {
            return toOrderDto(orderDao.Find(orderId));
        }

        public OrderBlock FindByUserLogin(string login, int startIndex, int count)
        {
            User user = userDao.FindByLogin(login);

            /*
           * Find count+1 comments to determine if there exist more accounts above
           * the specified range.
           */
            List<Order> orders =
                orderDao.findByUserId(user.userId, startIndex, count + 1);

            bool existMoreOrders = (orders.Count == count + 1);

            if (existMoreOrders)
                orders.RemoveAt(count);

            return new OrderBlock(toOrdersDto(orders), existMoreOrders);
        }
        private OrderDto toOrderDto(Order order)
        {
            OrderDto orderDTO = new OrderDto(order.orderId, order.creditCardId, order.address, order.orderDate, order.price);
            foreach (var orderItem in order.OrderItem)
            {
                orderDTO.orderItems.Add(toOrderItemDto(orderItem));
            }
            
            return orderDTO;
        }


        private OrderItemDto toOrderItemDto(OrderItem orderItem)
        {
            string product = productDao.Find(orderItem.productId).name;
            OrderItemDto orderItemDTO = new OrderItemDto(product, orderItem.units, orderItem.unitPrice);
            return orderItemDTO;
        }

        private List<OrderDto> toOrdersDto(List<Order> orders)
        {
            List<OrderDto> ordersDTO = new List<OrderDto>();
            orders.ForEach(order =>
            {
                ordersDTO.Add(toOrderDto(order));
            });
            return ordersDTO;
        }

        private bool isSalable(OrderItem order)
        {
            Product product = productDao.Find(order.productId);
            if (product.stockUnits < order.units)
            {
                throw new OutOfStockProductException(product.name);
            }
            return true;
            
        }


    }
}
