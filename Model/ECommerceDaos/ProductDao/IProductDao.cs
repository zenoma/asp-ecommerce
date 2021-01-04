using Es.Udc.DotNet.ModelUtil.Dao;
using Es.Udc.DotNet.PracticaMaD.Model.ECommerceDaos.Util;
using System;
using System.Collections.Generic;

namespace Es.Udc.DotNet.PracticaMaD.Model.Model1Daos.ProductDao
{
    public interface IProductDao : IGenericDao<Product, Int64>
    {
        Block<Product> FindByName(string name, int page, int count);

        Block<Product> FindByNameAndCategory(string name, long categoryId, int page, int count);

        Block<Product> FindByTag(long tagId, int page, int count);
    }
}
