using Es.Udc.DotNet.ModelUtil.Dao;
using Es.Udc.DotNet.PracticaMaD.Model.ECommerceDaos.Util;
using System;
using System.Linq;

namespace Es.Udc.DotNet.PracticaMaD.Model.Model1Daos.OrderDao
{
    public class OrderDaoEntityFramework : GenericDaoEntityFramework<Order, Int64>, IOrderDao
    {

        SearchCache<Order> cache = new SearchCache<Order>();
        public Block<Order> findByUserId(long userId, int page, int count)
        {

            Block<Order> result = cache.getQueryFromCache<Order>("findOrderByUserId=" + userId + "&page=" + page);
            using (var context = new ecommerceEntities())
            {
                if (result == null)
                {
                    var query = from o in context.Order
                                where o.userId == userId
                                orderby o.userId
                                select o;

                    result = BlockList.GetPaged(query, page, count);
                    cache.setQueryOnCache("findOrderByUserId=" + userId + "&page=" + page, result);
                }
                return result;
            }
        }
    }
}
