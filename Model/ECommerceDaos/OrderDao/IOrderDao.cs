using Es.Udc.DotNet.ModelUtil.Dao;
using Es.Udc.DotNet.PracticaMaD.Model.ECommerceDaos.Util;
using System;

namespace Es.Udc.DotNet.PracticaMaD.Model.Model1Daos.OrderDao
{
    public interface IOrderDao : IGenericDao<Order, Int64>
    {
        Block<Order> findByUserId(long userId, int page, int count);
    }
}
