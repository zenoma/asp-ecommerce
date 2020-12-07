using Es.Udc.DotNet.ModelUtil.Transactions;
using Es.Udc.DotNet.PracticaMaD.Model.Model1Daos.CreditCardDao;
using Es.Udc.DotNet.PracticaMaD.Model.Model1Daos.OrderDao;
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
        IUserDao userDao { set; }

        [Inject]
        ICreditCardDao creditCardDao { set; }

        [Transactional]
        Order CreateOrder(string login, List<OrderItem> orderItems, long creditCardId, string address);

        [Transactional]
        OrderBlock FindByUserLogin(string login, int page, int count);

        [Transactional]
        Order FindByOrderId(long orderId);

    }
}
