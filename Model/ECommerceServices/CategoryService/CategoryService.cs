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
        public List<Category> ListAllCategories()
        {
            return CategoryDao.FindAllCategory();
        }
    }
}
