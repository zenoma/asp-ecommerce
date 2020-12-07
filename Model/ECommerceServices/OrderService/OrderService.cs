using Castle.Core.Internal;
using Es.Udc.DotNet.PracticaMaD.Model.ECommerceDaos.Util;
using Es.Udc.DotNet.PracticaMaD.Model.ECommerceServices.Exceptions;
using Es.Udc.DotNet.PracticaMaD.Model.Model1Daos.CreditCardDao;
using Es.Udc.DotNet.PracticaMaD.Model.Model1Daos.OrderDao;
using Es.Udc.DotNet.PracticaMaD.Model.Model1Daos.OrderItemDao;
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



        /// <exception cref="EmptyOrderItemListException"/>
        public Order CreateOrder(string login, List<OrderItem> orderItems, long creditCardId, string address)
        {
            if (orderItems.IsNullOrEmpty())
            {
                throw new EmptyOrderItemListException(login);
            }
            else
            {
                Order order = new Order();
                User user = userDao.FindByLogin(login);
                order.userId = user.userId;
                order.creditCardId = creditCardId;
                order.address = address;
                order.orderDate = DateTime.Now;
                orderDao.Create(order);

                foreach (var item in orderItems)
                {
                    OrderItem orderItem = new OrderItem();
                    orderItem.orderId = order.orderId;
                    orderItem.productId = item.productId;
                    orderItem.units = item.units;
                    orderItem.unitPrice = item.unitPrice;
                    orderItemDao.Create(orderItem);
                }

                return order;
            }
        }

        public Order FindByOrderId(long orderId)
        {
            return orderDao.Find(orderId);
        }

        public OrderBlock FindByUserLogin(string login, int page, int count)
        {
            User user = userDao.FindByLogin(login);

            Block<Order> orders =
                orderDao.findByUserId(user.userId, page, count);

            bool existMoreOrders = orders.CurrentPage < orders.PageCount;

            return new OrderBlock(orders.Results, existMoreOrders);
        }
    }
}
