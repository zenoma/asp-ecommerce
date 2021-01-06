using System;
using System.Collections.Generic;

namespace Es.Udc.DotNet.PracticaMaD.Model.Model1Daos.CategoryDao
{
    public interface ICategoryDao : ModelUtil.Dao.IGenericDao<Category, Int64>
    {
        List<Category> FindAllCategory();
    }
}
