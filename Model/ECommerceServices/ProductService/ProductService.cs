﻿using Es.Udc.DotNet.ModelUtil.Transactions;
using Es.Udc.DotNet.PracticaMaD.Model.ECommerceServices.ProductService;
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
        public ProductBlock FindProducts(string name, long categoryId, int startIndex, int count)
        {
            List<Product> products = new List<Product>();

            /*
           * Find count+1 comments to determine if there exist more accounts above
           * the specified range.
           */
            if (categoryId > 0)
            {
                products = productDao.FindByNameAndCategory(name, categoryId, startIndex, count + 1);
            }
            else
            {
                products = productDao.FindByName(name, startIndex, count + 1);
            }

            bool existMoreProducts = (products.Count == count + 1);

            if (existMoreProducts)
                products.RemoveAt(count);

            return new ProductBlock(products, existMoreProducts);
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
