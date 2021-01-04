using Es.Udc.DotNet.PracticaMaD.Model.Model1Daos.ProductDao;
using Es.Udc.DotNet.ModelUtil.Transactions;
using Ninject;
using Es.Udc.DotNet.ModelUtil.Exceptions;
using System.Collections.Generic;
using Es.Udc.DotNet.PracticaMaD.Model.ECommerceServices.ProductService;
using Es.Udc.DotNet.PracticaMaD.Model.Model1Daos.CategoryDao;

namespace Es.Udc.DotNet.PracticaMaD.Model.Services.ProductService
{
    public interface IProductService
    {

        [Inject]
        IProductDao productDao { set; }

        [Inject]
        ICategoryDao categoryDao { set; }

        [Transactional]
        ProductBlock FindProducts(string name, long categoryId, int page, int count);

        /// <exception cref="InstanceNotFoundException"/>
        [Transactional]
        ProductBlock FindProductsByTagId(long tagId, int page, int count);

        /// <exception cref="InstanceNotFoundException"/>
        [Transactional]
        void UpdateProduct(long productId, ProductDetails  productDetails);

        /// <exception cref="InstanceNotFoundException"/>
        [Transactional]
        ProductDetails FindProductDetails(long productId);
 
    }
}
