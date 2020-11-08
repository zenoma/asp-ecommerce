using Es.Udc.DotNet.ModelUtil.Transactions;
using Es.Udc.DotNet.PracticaMaD.Model.Model1Daos.ProductDao;
using Ninject;
using System;
using System.Collections.Generic;

namespace Es.Udc.DotNet.PracticaMaD.Model.Services.ProductService
{
    public class ProductService : IProductService
    {
        [Inject]
        public IProductDao productDao { private get; set; }

        [Transactional]
        public List<Product> FindProducts(string name, long categoryId, int startIndex)
        {
            if(categoryId > 0)
            {
                return productDao.FindByNameAndCategory(name, categoryId, startIndex, 10);
            }
            else
            { 
                return productDao.FindByName(name, 0, 10);
            }
        }

        /// <exception cref="InstanceNotFoundException"/>
        [Transactional]
        public void UpdateProduct(long productId, ProductDetails productDetails)
        {
            Product product = productDao.Find(productId);
            product.categoryId = productDetails.categoryId;
            product.name = productDetails.name;
            product.stockUnits = productDetails.stockUnits;
            product.unitPrice = productDetails.unitPrice;
            product.type = productDetails.type;

            productDao.Update(product);
        }

        /// <exception cref="InstanceNotFoundException"/>
        [Transactional]
        public ProductDetails FindProductDetails(long productId)
        {
            Product product = productDao.Find(productId);

            ProductDetails productDetails = new ProductDetails(product.categoryId, product.name, product.stockUnits, product.unitPrice, product.type, product.productDate);

            return productDetails;
        }
    }
}
