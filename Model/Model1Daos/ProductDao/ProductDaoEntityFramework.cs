using Es.Udc.DotNet.ModelUtil.Dao;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Es.Udc.DotNet.PracticaMaD.Model.Model1Daos.ProductDao
{
    public class ProductDaoEntityFramework :
        GenericDaoEntityFramework<Product, Int64>, IProductDao
    {
        public List<Product> FindByName(String name, int startIndex, int count)
        {
            DbSet<Product> products = Context.Set<Product>();

            List<Product> result =
                (from b in products
                 where b.name.Contains(name)
                 orderby b.productId
                 select b).Skip(startIndex).Take(count).ToList();

            return result;
        }

        public List<Product> FindByNameAndCategory(string name, long categoryId, int startIndex, int count)
        {
            DbSet<Product> products = Context.Set<Product>();

            List<Product> result =
                (from b in products
                 where b.name.Contains(name) && b.categoryId == categoryId
                 orderby b.productId
                 select b).Skip(startIndex).Take(count).ToList();

            return result;
        }
    }
}
