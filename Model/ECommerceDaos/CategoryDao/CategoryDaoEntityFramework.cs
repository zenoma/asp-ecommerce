using Es.Udc.DotNet.ModelUtil.Dao;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Es.Udc.DotNet.PracticaMaD.Model.Model1Daos.CategoryDao
{
    public class CategoryDaoEntityFramework :
        GenericDaoEntityFramework<Category, Int64>, ICategoryDao
    {
        public List<Category> FindAllCategory()
        {
            using (var context = new ecommerceEntities())
            {
                var result = (from c in context.Category
                             select c).ToList();

                return result;
            }
        }
    }
}
