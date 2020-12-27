using Es.Udc.DotNet.ModelUtil.Dao;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Es.Udc.DotNet.PracticaMaD.Model.Model1Daos.OrderItemDao
{
    public class OrderItemDaoEntityFramework : GenericDaoEntityFramework<OrderItem, Int64>, IOrderItemDao
    {
        public List<OrderItem> FindByOrderId(long orderId)
        {
            using (var context = new ecommerceEntities())
            {
                var result = (from oi in context.OrderItem
                              where oi.orderId == orderId
                              orderby oi.orderId
                              select oi).ToList();

                return result;
            }
        }
    }
}
