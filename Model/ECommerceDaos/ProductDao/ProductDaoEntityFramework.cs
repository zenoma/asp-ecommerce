using Es.Udc.DotNet.ModelUtil.Dao;
using Es.Udc.DotNet.PracticaMaD.Model.ECommerceDaos.Util;
using System;
using System.Linq;

namespace Es.Udc.DotNet.PracticaMaD.Model.Model1Daos.ProductDao
{
    public class ProductDaoEntityFramework :
        GenericDaoEntityFramework<Product, Int64>, IProductDao
    {
        public Block<Product> FindByName(String name, int page, int count)
        {
            using (var context = new ecommerceEntities())
            {
                var query = from b in context.Product
                            where b.name.Contains(name)
                            orderby b.productId
                            select b;

                Block<Product> result = BlockList.GetPaged(query, page, count);

                return result;
            }
        }

        public Block<Product> FindByNameAndCategory(string name, long categoryId, int page, int count)
        {
            using (var context = new ecommerceEntities())
            {
                var query = (from b in context.Product
                             where b.name.Contains(name) && b.categoryId == categoryId
                             orderby b.productId
                             select b);

                Block<Product> result = BlockList.GetPaged(query, page, count);

                return result;
            }
        }

        public Block<Product> FindByTag(long tagId, int page, int count)
        {
            using (var context = new ecommerceEntities())
            {
                var tagQuery = from t in context.Tag
                               where t.tagId == tagId
                               select t;


                var commentQuery = from c in context.Comment
                                   where c.Tag.Contains(tagQuery.FirstOrDefault())
                                   group c by c.productId into grp
                                   select grp.Key;


                var productQuery = from p in context.Product
                                   where commentQuery.Contains(p.productId)
                                   orderby p.productId
                                   select p;

                Block<Product> result = BlockList.GetPaged(productQuery, page, count);

                return result;
            }
        }
    }
}
