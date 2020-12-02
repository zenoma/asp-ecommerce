﻿using Es.Udc.DotNet.PracticaMaD.Model.Model1Daos.ProductDao;
using Es.Udc.DotNet.ModelUtil.Transactions;
using Ninject;
using System.Collections.Generic;
using Es.Udc.DotNet.PracticaMaD.Model.ECommerceServices.ProductService;

namespace Es.Udc.DotNet.PracticaMaD.Model.Services.ProductService
{
    public interface IProductService
    {

        [Inject]
        IProductDao productDao { set; }

        [Transactional]
        ProductBlock FindProducts(string name, long categoryId, int startIndex, int count);

        /// <exception cref="InstanceNotFoundException"/>
        [Transactional]
        void UpdateProduct(long productId, ProductDetails  productDetails);

        /// <exception cref="InstanceNotFoundException"/>
        [Transactional]
        ProductDetails FindProductDetails(long productId);
 
    }
}
