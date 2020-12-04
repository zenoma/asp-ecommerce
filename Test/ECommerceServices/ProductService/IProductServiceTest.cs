using Es.Udc.DotNet.PracticaMaD.Model;
using Es.Udc.DotNet.PracticaMaD.Model.Model1Daos.CategoryDao;
using Es.Udc.DotNet.PracticaMaD.Model.Model1Daos.ProductDao;
using Es.Udc.DotNet.PracticaMaD.Model.Services.ProductService;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ninject;
using System.Collections.Generic;
using System.Transactions;

namespace Es.Udc.DotNet.PracticaMaD.Test.ECommerceServices.ProductService
{
    [TestClass()]
    public class IProductServiceTest
    {
        private static IKernel kernel;
        private static IProductService productService;
        private static IProductDao productDao;
        private static ICategoryDao categoryDao;

        // Variables used in several tests are initialized 
        private Category category = new Category();
        private Product product = new Product();

        private const long NON_EXISTENT_PRODUCT_ID = -1;
        private const long NON_EXISTENT_CATEGORY_ID = -1;

        //Due to the limited precision of floating point numbers, the equality
        //operator may provide unexpected results if two numbers are close to
        //each other (e.g. 25 and 25.00000000001). In order to solve this
        //issue, a small margin of error (delta) can be allowed.
        private const double delta = 0.00001;

        private TransactionScope transactionScope;

        private TestContext testContextInstance;

        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes

        //Use ClassInitialize to run code before running the first test in the class
        [ClassInitialize()]
        public static void MyClassInitialize(TestContext testContext)
        {
            kernel = TestManager.ConfigureNInjectKernel();
            productService = kernel.Get<IProductService>();
            productDao = kernel.Get<IProductDao>();
            categoryDao = kernel.Get<ICategoryDao>();
        }

        //Use ClassCleanup to run code after all tests in a class have run
        [ClassCleanup()]
        public static void MyClassCleanup()
        {
            TestManager.ClearNInjectKernel(kernel);
        }

        //Use TestInitialize to run code before running each test
        [TestInitialize()]
        public void MyTestInitialize()
        {
            transactionScope = new TransactionScope();

            category.visualName = "Category";
            categoryDao.Create(category);

            product.categoryId = category.categoryId;
            product.name = "Some name";
            product.productDate = System.DateTime.Now;
            product.stockUnits = 100;
            product.unitPrice = 5;
            product.type = "Tipo";
            productDao.Create(product);
        }

        //Use TestCleanup to run code after each test has run
        [TestCleanup()]
        public void MyTestCleanup()
        {
            transactionScope.Dispose();
        }

        #endregion Additional test attributes

        [TestMethod()]
        public void FindProductsWithNameTest()
        {
            List<Product> expectedProducts = productDao.FindByName(product.name, 0, 10);

            List<ProductDetails> actualProducts = productService.FindProducts(product.name, NON_EXISTENT_CATEGORY_ID, 0, 10).Products;

            Assert.AreEqual(expectedProducts.Count, actualProducts.Count);

        }

        [TestMethod()]
        public void FindProductsWithNameAndCategoryTest()
        {
            List<Product> expectedProducts = productDao.FindByName(product.name, 0, 10);

            List<ProductDetails> actualProducts = productService.FindProducts(product.name, category.categoryId, 0, 10).Products;

            Assert.AreEqual(expectedProducts.Count, actualProducts.Count);

        }

        [TestMethod()]
        public void FindProductsWithNameWithoutProductsTest()
        {
            productDao.Remove(product.productId);

            List<ProductDetails> actualProducts = productService.FindProducts(product.name, category.categoryId, 0, 10).Products;

            Assert.AreEqual(0, actualProducts.Count);

        }

        [TestMethod()]
        public void UpdateProductTest()
        {
            using (var scope = new TransactionScope())
            {
                var expected = new ProductDetails(category.visualName, "New name", 1, 1, "Type", product.productDate);
                productService.UpdateProduct(product.productId, expected);

                var obtained =
                    productService.FindProductDetails(product.productId);

                // Check changes
                Assert.AreEqual(expected, obtained);

                // transaction.Complete() is not called, so Rollback is executed.
            }

        }


    }
}
