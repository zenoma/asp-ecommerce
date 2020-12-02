using Es.Udc.DotNet.PracticaMaD.Model.ECommerceServices.TagService;
using Es.Udc.DotNet.PracticaMaD.Model.Model1Daos.CategoryDao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Es.Udc.DotNet.ModelUtil.Transactions;
using Ninject;

namespace Es.Udc.DotNet.PracticaMaD.Model.ECommerceServices.CategoryService
{
    public class CategoryService : ICategoryService
    {
        [Inject]
        public ICategoryDao CategoryDao { private get; set; }

        [Transactional]
        public CategoryBlock ListAllCategories(int startIndex, int count)
        {
            /*
           * Find count+1 comments to determine if there exist more accounts above
           * the specified range.
           */
            List<Category> categories =
                CategoryDao.FindAllCategory();

            bool existMoreCategories = (categories.Count == count + 1);

            if (existMoreCategories)
                categories.RemoveAt(count);

            return new CategoryBlock(categories, existMoreCategories);
        }
    }
}
