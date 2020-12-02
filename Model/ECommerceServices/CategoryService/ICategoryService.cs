using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Es.Udc.DotNet.ModelUtil.Transactions;
using Es.Udc.DotNet.PracticaMaD.Model.ECommerceServices.TagService;
using Es.Udc.DotNet.PracticaMaD.Model.Model1Daos.CategoryDao;
using Ninject;

namespace Es.Udc.DotNet.PracticaMaD.Model.ECommerceServices.CategoryService
{
    public interface ICategoryService
    {
        [Inject]
        ICategoryDao CategoryDao { set; }

        [Transactional]
        CategoryBlock ListAllCategories(int startIndex, int count);
    }
}
