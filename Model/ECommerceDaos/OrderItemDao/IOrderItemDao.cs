using Es.Udc.DotNet.ModelUtil.Dao;
using System;
using System.Collections.Generic;

namespace Es.Udc.DotNet.PracticaMaD.Model.Model1Daos.OrderItemDao
{
    public interface IOrderItemDao : IGenericDao<OrderItem, Int64>
    {
        List<OrderItem> FindByOrderId(long orderId);
    }
}
