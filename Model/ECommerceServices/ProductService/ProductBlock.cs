using Es.Udc.DotNet.PracticaMaD.Model.Model1Daos.CategoryDao;
using Es.Udc.DotNet.PracticaMaD.Model.Model1Daos.ProductDao;
using Es.Udc.DotNet.PracticaMaD.Model.Services.ProductService;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
