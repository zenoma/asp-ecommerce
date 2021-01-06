using Es.Udc.DotNet.ModelUtil.Exceptions;
using Es.Udc.DotNet.ModelUtil.Transactions;
using Es.Udc.DotNet.PracticaMaD.Model.ECommerceDaos.Util;
using Es.Udc.DotNet.PracticaMaD.Model.ECommerceServices.ProductService;
using Es.Udc.DotNet.PracticaMaD.Model.Model1Daos.BookDao;
using Es.Udc.DotNet.PracticaMaD.Model.Model1Daos.CategoryDao;
using Es.Udc.DotNet.PracticaMaD.Model.Model1Daos.MovieDao;
using Es.Udc.DotNet.PracticaMaD.Model.Model1Daos.MusicDao;
using Es.Udc.DotNet.PracticaMaD.Model.Model1Daos.ProductDao;
using Ninject;
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
        public ProductBlock FindProductsByTagId(long tagId, int page, int count)
        {
            Block<Product> products = new Block<Product>();

            products = productDao.FindByTag(tagId, page, count);

            bool existMoreProducts = products.CurrentPage < products.PageCount;

            return new ProductBlock(toProductDetails(products.Results), existMoreProducts);
        }

        /// <exception cref="InstanceNotFoundException"/>
        [Transactional]
        public void UpdateProduct(long productId, ProductDetails productDetails)
        {
            Product product = productDao.Find(productId);

            if (typeof(Music).IsAssignableFrom(product.GetType()))
            {
                Music music = musicDao.Find(productId);

                music.name = productDetails.name;
                music.Category = categoryDao.Find(productDetails.categoryId);
                music.unitPrice = productDetails.unitPrice;
                music.stockUnits = productDetails.stockUnits;
                music.artist = productDetails.artist;
                music.album = productDetails.album;

                musicDao.Update(music);

                return;
            }

            if (typeof(Book).IsAssignableFrom(product.GetType()))
            {
                Book book = bookDao.Find(productId);

                book.name = productDetails.name;
                book.Category = categoryDao.Find(productDetails.categoryId);
                book.unitPrice = productDetails.unitPrice;
                book.stockUnits = productDetails.stockUnits;
                book.author = productDetails.author;
                book.isbn = productDetails.isbn;
                book.editionNumber = productDetails.editionNumber;

                bookDao.Update(book);

                return;
            }

            if (typeof(Movie).IsAssignableFrom(product.GetType()))
            {
                Movie movie = movieDao.Find(productId);

                movie.name = productDetails.name;
                movie.Category = categoryDao.Find(productDetails.categoryId);
                movie.unitPrice = productDetails.unitPrice;
                movie.stockUnits = productDetails.stockUnits;
                movie.director = productDetails.director;
                movie.movieDate = productDetails.movieDate;

                movieDao.Update(movie);

                return;
            }

            return;
        }

        /// <exception cref="InstanceNotFoundException"/>
        [Transactional]
        public ProductDetails FindProductDetails(long productId)
        {
            Product product = productDao.Find(productId);
            ProductDetails productDetails;

            if (typeof(Music).IsAssignableFrom(product.GetType()))
            {
                Music music = musicDao.Find(productId);

                productDetails = new ProductDetails(music.productId, music.Category.categoryId, music.Category.visualName,
                music.name, music.stockUnits, music.unitPrice, "Music", music.productDate,
                music.album, music.artist, null, default, null, 0, null);

                return productDetails;
            }

            if (typeof(Movie).IsAssignableFrom(product.GetType()))
            {
                Movie movie = movieDao.Find(productId);

                productDetails = new ProductDetails(movie.productId, movie.Category.categoryId, movie.Category.visualName,
                movie.name, movie.stockUnits, movie.unitPrice, "Movie", movie.productDate, null,
                null, movie.director, movie.movieDate, null, 0, null);

                return productDetails;
            }

            if (typeof(Book).IsAssignableFrom(product.GetType()))
            {
                Book book = bookDao.Find(productId);

                productDetails = new ProductDetails(book.productId, book.Category.categoryId, book.Category.visualName,
                book.name, book.stockUnits, book.unitPrice, "Book", book.productDate, null,
                null, null, default, book.isbn, book.editionNumber, book.author);

                return productDetails;
            }

            productDetails = new ProductDetails(product.productId, product.Category.categoryId, product.Category.visualName,
            product.name, product.stockUnits, product.unitPrice, "None", product.productDate, null,
            null, null, default, null, 0, null);

            return productDetails;
        }

        private List<ProductDetails> toProductDetails(List<Product> products)
        {
            List<ProductDetails> productsDetail = new List<ProductDetails>();
            Category category;
            products.ForEach(product =>
            {
                category = categoryDao.Find(product.categoryId.GetValueOrDefault());
                productsDetail.Add(new ProductDetails(product.productId, category.categoryId, category.visualName,
                    product.name, product.stockUnits, product.unitPrice,
                    product.type, product.productDate, null, null, null, default, null, 0, null));
            });

            return productsDetail;
        }
    }
}
