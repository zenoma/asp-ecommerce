using Es.Udc.DotNet.PracticaMaD.Model.Model1Daos.CategoryDao;
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
        [Inject]
        public ICategoryDao categoryDao { private get; set; }

        public List<ProductDetails> Products { get; private set; }
        public bool ExistMoreProducts { get; private set; }

        public ProductBlock(List<Product> products, bool existMoreProducts)
        {
            this.Products = toProductDetails(products);
            this.ExistMoreProducts = existMoreProducts;
        }

        private List<ProductDetails> toProductDetails(List<Product> products)
        {
            List<ProductDetails> productsDetail = new List<ProductDetails>();
            Category category;
            products.ForEach(product =>
            {
                category = categoryDao.Find(product.categoryId);
                productsDetail.Add(new ProductDetails(category.visualName, 
                    product.name, product.stockUnits, product.unitPrice, 
                    product.type, product.productDate));
            });

            return productsDetail;
        }
    }
}
