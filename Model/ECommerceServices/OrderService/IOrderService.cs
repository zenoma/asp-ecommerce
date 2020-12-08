using Es.Udc.DotNet.ModelUtil.Transactions;
using Es.Udc.DotNet.PracticaMaD.Model.ECommerceServices.CartService;
using Es.Udc.DotNet.PracticaMaD.Model.Model1Daos.CreditCardDao;
using Es.Udc.DotNet.PracticaMaD.Model.Model1Daos.OrderDao;
using Es.Udc.DotNet.PracticaMaD.Model.Model1Daos.OrderItemDao;
using Es.Udc.DotNet.PracticaMaD.Model.Model1Daos.ProductDao;
using Es.Udc.DotNet.PracticaMaD.Model.Model1Daos.UserDao;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Es.Udc.DotNet.PracticaMaD.Model.ECommerceServices.OrderService
{
    public interface IOrderService
    {

        [Inject]
        IOrderDao orderDao { set; }

        [Inject]
        IOrderItemDao orderItemDao { set; }

        [Inject]
        IUserDao userDao { set; }

        [Inject]
        IProductDao productDao { set; }

        [Inject]
        ICreditCardDao creditCardDao { set; }

        [Transactional]
        OrderDto CreateOrder(string login, CartDto cart, long creditCardId, string address);

        [Transactional]
        OrderBlock FindByUserLogin(string login, int page, int count);

        [Transactional]
        OrderDto FindByOrderId(long orderId);

    }
}
