using Es.Udc.DotNet.ModelUtil.Dao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Es.Udc.DotNet.PracticaMaD.Model.Model1Daos.OrderItemDao
{
    public interface IOrderItemDao : IGenericDao<OrderItem, Int64>
    {
        List<OrderItem> findByOrderId(long orderId, int startIndex, int count);
    }
}
