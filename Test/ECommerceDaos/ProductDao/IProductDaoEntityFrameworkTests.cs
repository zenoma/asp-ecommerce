using Es.Udc.DotNet.PracticaMaD.Model;
using Es.Udc.DotNet.PracticaMaD.Model.ECommerceDaos.Util;
using Es.Udc.DotNet.PracticaMaD.Model.Model1Daos.CategoryDao;
using Es.Udc.DotNet.PracticaMaD.Model.Model1Daos.ProductDao;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ninject;
using System.Collections.Generic;
using System.Transactions;

namespace Es.Udc.DotNet.PracticaMaD.Test.Model1Daos.ProductDao
{
    [TestClass()]
    public class IProductDaoEntityFrameworkTests
    {
        private static IKernel kernel;
        private static IProductDao productDao;
        private static ICategoryDao categoryDao;

        private const long NON_EXISTENT_PRODUCT_ID = -1;

        private TransactionScope transactionScope;

        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
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
        }

        //Use TestCleanup to run code after each test has run
        [TestCleanup()]
        public void MyTestCleanup()
        {
            transactionScope.Dispose();
        }

        #endregion Additional test attributes


        [TestMethod()]
        public void FindByNameTest()
        {
            int numberOfProducts = 10;

            List<Product> createdProducts = new List<Product>(numberOfProducts);
            string name = "Some Name";

            Category category = new Category();
            category.visualName = "Category";
            categoryDao.Create(category);

            /*Create numberOfProducts products*/
            for (int i = 0; i < numberOfProducts; i++)
            {
                Product product = new Product();
                product.categoryId = category.categoryId;
                product.name = name;
                product.productDate = System.DateTime.Now;
                product.stockUnits = 100;
                product.unitPrice = 5;
                product.type = "Tipo";
                productDao.Create(product);
                createdProducts.Add(product);
            }

            int count = 10;
            int page = 1;

            Block<Product> listProducts;
            List<Product> totalRetrievedProducts = new List<Product>(numberOfProducts);

            do
            {
                listProducts = productDao.FindByName(name, page, count);
                totalRetrievedProducts.AddRange(listProducts.Results);

                Assert.IsTrue(listProducts.Results.Count <= count);
                page += count;
            } while (page < numberOfProducts);


            Assert.AreEqual(numberOfProducts, totalRetrievedProducts.Count);

            // are the accounts retrieved the same than the originals?
            for (int i = 0; i < numberOfProducts; i++)
            {
                Assert.AreEqual(totalRetrievedProducts[i], createdProducts[i]);
            }
        }

        [TestMethod]
        public void FindByNameWithoutProductsTest()
        {
            string name = "";

            int count = 10;
            int startIndex = 10;

            Block<Product> retrievedProducts = productDao.FindByName(name, startIndex, count);

            Assert.IsTrue(retrievedProducts.Results.Count == 0);
        }


        [TestMethod()]
        public void FindByNameAndCategoryTest()
        {
            int numberOfProducts = 10;

            List<Product> createdProducts = new List<Product>(numberOfProducts);
            string name = "Some Name";

            Category category = new Category();
            category.visualName = "Category";
            categoryDao.Create(category);

            /*Create numberOfProducts products*/
            for (int i = 0; i < numberOfProducts; i++)
            {
                Product product = new Product();
                product.categoryId = category.categoryId;
                product.name = name;
                product.productDate = System.DateTime.Now;
                product.stockUnits = 100;
                product.unitPrice = 5;
                product.type = "Tipo";
                productDao.Create(product);
                createdProducts.Add(product);
            }

            int count = 10;
            int page = 1;

            Block<Product> listProducts;
            List<Product> totalRetrievedProducts = new List<Product>(numberOfProducts);

            do
            {
                listProducts = productDao.FindByNameAndCategory(name, category.categoryId, page, count);
                totalRetrievedProducts.AddRange(listProducts.Results);

                Assert.IsTrue(listProducts.Results.Count <= count);
                page += count;
            } while (page < numberOfProducts);


            Assert.AreEqual(numberOfProducts, totalRetrievedProducts.Count);

            // are the accounts retrieved the same than the originals?
            for (int i = 0; i < numberOfProducts; i++)
            {
                Assert.AreEqual(totalRetrievedProducts[i], createdProducts[i]);
            }
        }



        [TestMethod]
        public void FindByNameAndCategoryWithoutProductsTest()
        {
            string name = "";

            Category category = new Category();
            category.visualName = "Category";
            categoryDao.Create(category);

            int count = 10;
            int startIndex = 10;

            Block<Product> retrievedProducts = productDao.FindByNameAndCategory(name, category.categoryId, startIndex, count);

            Assert.IsTrue(retrievedProducts.Results.Count == 0);
        }

    }
}
