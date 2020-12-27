using Es.Udc.DotNet.PracticaMaD.Model;
using Es.Udc.DotNet.PracticaMaD.Model.ECommerceDaos.Util;
using Es.Udc.DotNet.PracticaMaD.Model.ECommerceServices.ProductService;
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
            product.productDate = System.DateTime.Now;
            product.stockUnits = 100;
            product.unitPrice = 5;
            product.type = "Tipo";
        }

        //Use TestCleanup to run code after each test has run
        [TestCleanup()]
        public void MyTestCleanup()
        {
            transactionScope.Dispose();
        }

        #endregion Additional test attributes

        private void createProductsTest(int size)
        {
            for(int i = 0; i<size; i++)
            {
                product.name = "Test " + i;
                productDao.Create(product);
            }
        }

        [TestMethod()]
        public void FindProductsWithNameTest()
        {
            int numberProducts = 10;
            createProductsTest(numberProducts);

            ProductBlock list = productService.FindProducts("Test", NON_EXISTENT_CATEGORY_ID, 1, numberProducts/2);

            Assert.IsTrue(list.Products.Count <= numberProducts / 2);
            Assert.IsTrue(list.ExistMoreProducts);

            list.Products.ForEach(product =>
            {
                Assert.IsTrue(product.name.Contains("Test"));
            });
        }

        [TestMethod()]
        public void FindProductsWithNameAndCategoryTest()
        {
            int numberProducts = 10;
            createProductsTest(numberProducts);

            ProductBlock list = productService.FindProducts("Test", category.categoryId, 1, numberProducts / 2);

            Assert.IsTrue(list.Products.Count <= numberProducts / 2);
            Assert.IsTrue(list.ExistMoreProducts);

            list.Products.ForEach(product =>
            {
                Assert.AreEqual(product.category, category.visualName);
            });
        }

        [TestMethod()]
        public void FindProductsWithNameWithoutProductsTest()
        {
            ProductBlock list = productService.FindProducts(product.name, category.categoryId, 1, 10);

            Assert.AreEqual(0, list.Products.Count);

        }

        [TestMethod()]
        public void UpdateProductTest()
        {
            int numberProducts = 10;
            createProductsTest(numberProducts);

            using (var scope = new TransactionScope())
            {
                Block<Product> list = productDao.FindByName("Test", 1, 1);
                Product productFound = list.Results.Find(p => p.name.Contains("Test"));
                ProductDetails product = new ProductDetails(productFound.productId, category.visualName, "proba", 100, 500, "test", System.DateTime.Now, null, null, null, default, null, 0, null);
                productService.UpdateProduct(productFound.productId, product);

                var obtained =
                    productService.FindProductDetails(productFound.productId);

                Assert.AreEqual(product.name, obtained.name);
            }

        }


    }
}
