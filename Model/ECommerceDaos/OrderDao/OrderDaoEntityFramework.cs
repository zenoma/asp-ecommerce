﻿using Es.Udc.DotNet.ModelUtil.Dao;
using Es.Udc.DotNet.PracticaMaD.Model.ECommerceDaos.Util;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Es.Udc.DotNet.PracticaMaD.Model.Model1Daos.OrderDao
{
    public class OrderDaoEntityFramework : GenericDaoEntityFramework<Order, Int64>, IOrderDao
    {
        public Block<Order> findByUserId(long userId, int page, int count)
        {
            DbSet<Order> orders = Context.Set<Order>();

            var query = (from o in orders
                         where o.userId == userId
                         orderby o.userId
                         select o);

            Block<Order> result = BlockList.GetPaged(query, page, count);

            return result;
        }
    }
}
