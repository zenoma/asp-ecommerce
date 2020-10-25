using Es.Udc.DotNet.ModelUtil.Dao;
using System;
using System.Collections.Generic;

namespace Es.Udc.DotNet.PracticaMaD.Model.Model1Daos.ProductDao
{
    interface IProductDao : IGenericDao<Product, Int64>
    {
        List<Product> FindByProductId(long productId, int startIndex, int count);
    }
}
