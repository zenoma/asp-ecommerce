using Es.Udc.DotNet.ModelUtil.Dao;
using Es.Udc.DotNet.PracticaMaD.Model.ECommerceDaos.Util;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Es.Udc.DotNet.PracticaMaD.Model.Model1Daos.ProductDao
{
    public class ProductDaoEntityFramework :
        GenericDaoEntityFramework<Product, Int64>, IProductDao
    {
        public Block<Product> FindByName(String name, int page, int count)
        {
            DbSet<Product> products = Context.Set<Product>();

            var query = (from b in products
                         where b.name.Contains(name)
                         orderby b.productId
                         select b);

            Block<Product> result = BlockList.GetPaged(query, page, count);

            return result;
        }

        public Block<Product> FindByNameAndCategory(string name, long categoryId, int page, int count)
        {
            DbSet<Product> products = Context.Set<Product>();

            var query = (from b in products
                 where b.name.Contains(name) && b.categoryId == categoryId
                 orderby b.productId
                 select b);

            Block<Product> result = BlockList.GetPaged(query, page, count);

            return result;
        }
    }
}
