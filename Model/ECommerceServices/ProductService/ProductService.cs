using Es.Udc.DotNet.ModelUtil.Transactions;
using Es.Udc.DotNet.PracticaMaD.Model.ECommerceDaos.Util;
using Es.Udc.DotNet.PracticaMaD.Model.ECommerceServices.ProductService;
using Es.Udc.DotNet.PracticaMaD.Model.Model1Daos.BookDao;
using Es.Udc.DotNet.PracticaMaD.Model.Model1Daos.CategoryDao;
using Es.Udc.DotNet.PracticaMaD.Model.Model1Daos.MovieDao;
using Es.Udc.DotNet.PracticaMaD.Model.Model1Daos.MusicDao;
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

        [Inject]
        public IMusicDao musicDao { private get; set; }

        [Inject]
        public IBookDao bookDao { private get; set; }

        [Inject]
        public IMovieDao movieDao { private get; set; }

        [Inject]
        public ICategoryDao categoryDao { private get; set; }

        [Transactional]
        public ProductBlock FindProducts(string name, long categoryId, int page, int count)
        {
            Block<Product> products = new Block<Product>();

            if (categoryId > 0)
            {
                products = productDao.FindByNameAndCategory(name, categoryId, page, count);
            }
            else
            {
                products = productDao.FindByName(name, page, count);
            }

            bool existMoreProducts = products.CurrentPage < products.PageCount;

            return new ProductBlock(toProductDetails(products.Results), existMoreProducts);
        }

        /// <exception cref="InstanceNotFoundException"/>
        [Transactional]
        public void UpdateProduct(long productId, ProductDetails productDetails)
        {
            Product product = productDao.Find(productId);
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
            Category category = categoryDao.Find(product.categoryId.GetValueOrDefault());
            ProductDetails productDetails;

            if (product.type == "Music")
            {
                Music music = musicDao.Find(productId);

                productDetails = new ProductDetails(product.productId, category.visualName,
                product.name, product.stockUnits, product.unitPrice, product.type, product.productDate,
                music.album, music.artist, null, default, null, 0, null);

            } else if (product.type == "Movie")
            {
                Movie movie = movieDao.Find(productId);

                productDetails = new ProductDetails(product.productId, category.visualName,
                product.name, product.stockUnits, product.unitPrice, product.type, product.productDate, null,
                null, movie.director, movie.movieDate, null, 0, null);
            } else
            {
                Book book = bookDao.Find(productId);

                productDetails = new ProductDetails(product.productId, category.visualName,
                product.name, product.stockUnits, product.unitPrice, product.type, product.productDate, null,
                null, null, default, book.isbn, book.editionNumber, book.author);

            }            

            return productDetails;
        }

        private List<ProductDetails> toProductDetails(List<Product> products)
        {
            List<ProductDetails> productsDetail = new List<ProductDetails>();
            Category category;
            products.ForEach(product =>
            {
                category = categoryDao.Find(product.categoryId.GetValueOrDefault());
                productsDetail.Add(new ProductDetails(product.productId, category.visualName,
                    product.name, product.stockUnits, product.unitPrice,
                    product.type, product.productDate, null, null, null, default, null, 0, null));
            });

            return productsDetail;
        }
    }
}
