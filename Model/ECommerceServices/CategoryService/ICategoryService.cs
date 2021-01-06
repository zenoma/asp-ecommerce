using Es.Udc.DotNet.ModelUtil.Transactions;
using Es.Udc.DotNet.PracticaMaD.Model.Model1Daos.CategoryDao;
using Ninject;

namespace Es.Udc.DotNet.PracticaMaD.Model.ECommerceServices.CategoryService
{
    public interface ICategoryService
    {
        [Inject]
        ICategoryDao CategoryDao { set; }

        [Transactional]
        CategoryBlock ListAllCategories();
    }
}
