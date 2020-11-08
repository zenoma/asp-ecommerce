using Es.Udc.DotNet.PracticaMaD.Model.Model1Daos.ProductDao;
using Es.Udc.DotNet.ModelUtil.Transactions;
using Ninject;
using System.Collections.Generic;

namespace Es.Udc.DotNet.PracticaMaD.Model.Services.ProductService
{
    public interface IProductService
    {

        [Inject]
        IProductDao ProductDao { set; }

        [Transactional]
        List<Product> FindProducts(string name, long categoryId);

        /// <exception cref="InstanceNotFoundException"/>
        [Transactional]
        void UpdateProduct(long productId, ProductDetails  productDetails);

        /// <exception cref="InstanceNotFoundException"/>
        [Transactional]
        ProductDetails FindProductDetails(long productId);
 
    }
}
