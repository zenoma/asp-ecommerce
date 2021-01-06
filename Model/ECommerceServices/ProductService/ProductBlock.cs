﻿using Es.Udc.DotNet.PracticaMaD.Model.Services.ProductService;
using System.Collections.Generic;

namespace Es.Udc.DotNet.PracticaMaD.Model.ECommerceServices.ProductService
{
    public class ProductBlock
    {

        public List<ProductDetails> Products { get; private set; }
        public bool ExistMoreProducts { get; private set; }

        public ProductBlock(List<ProductDetails> products, bool existMoreProducts)
        {
            this.Products = products;
            this.ExistMoreProducts = existMoreProducts;
        }
    }
}
