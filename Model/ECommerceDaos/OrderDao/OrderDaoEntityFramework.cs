using Es.Udc.DotNet.ModelUtil.Dao;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Es.Udc.DotNet.PracticaMaD.Model.Model1Daos.OrderDao
{
    public class OrderDaoEntityFramework : GenericDaoEntityFramework<Order, Int64>, IOrderDao
    {
        public List<Order> findByUserId(long userId, int startIndex, int count)
        {
            DbSet<Order> orders = Context.Set<Order>();

            List<Order> result = (from o in orders
                                  where o.userId == userId
                                  orderby o.userId
                                  select o).Skip(startIndex).Take(count).ToList();

            return result;
        }
    }
}
