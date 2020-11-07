using Es.Udc.DotNet.ModelUtil.Dao;
using System;
using System.Collections.Generic;

namespace Es.Udc.DotNet.PracticaMaD.Model.Model1Daos.ProductDao
{
    public interface IProductDao : IGenericDao<Product, Int64>
    {
        List<Product> FindByName(string name, int startIndex, int count);

        List<Product> FindByNameAndCategory(string name, long categoryId, int startIndex, int count);
    }
}
