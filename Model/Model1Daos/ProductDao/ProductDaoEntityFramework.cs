using Es.Udc.DotNet.ModelUtil.Dao;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Es.Udc.DotNet.PracticaMaD.Model.Model1Daos.ProductDao
{
    class ProductDaoEntityFramework :
        GenericDaoEntityFramework<Product, Int64>, IProductDao
    {
        public List<Product> FindByProductId(long productId, int startIndex, int count)
        {
            DbSet<Product> products = Context.Set<Product>();

            var result =
                (from b in products
                 where b.productId == productId
                 orderby b.productId
                 select b).Skip(startIndex).Take(count).ToList();

            return result;
        }
    }
}
