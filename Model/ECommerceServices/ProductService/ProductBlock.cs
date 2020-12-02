using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Es.Udc.DotNet.PracticaMaD.Model.ECommerceServices.ProductService
{
    public class ProductBlock
    {

        public List<Product> Products { get; private set; }
        public bool ExistMoreProducts { get; private set; }

        public ProductBlock(List<Product> products, bool existMoreProducts)
        {
            this.Products = products;
            this.ExistMoreProducts = existMoreProducts;
        }
    }
}
