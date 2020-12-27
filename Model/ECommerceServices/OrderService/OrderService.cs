using Castle.Core.Internal;
using Es.Udc.DotNet.PracticaMaD.Model.ECommerceDaos.Util;
using Es.Udc.DotNet.PracticaMaD.Model.ECommerceServices.CartService;
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
        public OrderDto CreateOrder(string login, CartDto cart, long creditCardId, string address)
        {

            if (cart.cartLines.IsNullOrEmpty())
            {
                throw new EmptyOrderItemListException(login);
            }
            else
            {
                Order order = new Order();
                Product product;
                double price = 0;
                User user = userDao.FindByLogin(login);

                order.userId = user.userId;
                order.creditCardId = creditCardId;
                order.address = address;
                order.orderDate = DateTime.Now;
                orderDao.Create(order);

                foreach (var cartLine in cart.cartLines)
                {
                    product = productDao.Find(cartLine.productId);
                    if (isSalable(product, cartLine.quantity))
                    {
                        OrderItem orderItem = new OrderItem();
                        orderItem.orderId = order.orderId;
                        orderItem.productId = cartLine.productId;
                        orderItem.units = cartLine.quantity;
                        orderItem.unitPrice = product.unitPrice;
                        orderItemDao.Create(orderItem);
                        price += cartLine.quantity * product.unitPrice;
                        product.stockUnits -= cartLine.quantity;
                        productDao.Update(product);
                    }
                    else
                    {
                        throw new OutOfStockProductException(product.name);
                    }
                }
                order.price = price;
                orderDao.Update(order);
                return toOrderDto(order);
            }
        }

        public OrderDto FindByOrderId(long orderId)
        {
            return toOrderDto(orderDao.Find(orderId));
        }

        public OrderBlock FindByUserLogin(string login, int page, int count)
        {
            User user = userDao.FindByLogin(login);

            Block<Order> orders =
                orderDao.findByUserId(user.userId, page, count);

            bool existMoreOrders = orders.CurrentPage < orders.PageCount;

            return new OrderBlock(toOrdersDto(orders.Results), existMoreOrders);
        }


        private OrderDto toOrderDto(Order order)
        {
            OrderDto orderDTO = new OrderDto(order.orderId, order.creditCardId, order.address, order.orderDate, order.price);
            List<OrderItem> orderItems = orderItemDao.FindByOrderId(order.orderId);
            foreach (var orderItem in orderItems)
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

        private bool isSalable(Product product, int quantity)
        {

            if (product.stockUnits < quantity)
            {
                throw new OutOfStockProductException(product.name);
            }
            return true;

        }
    }
}
