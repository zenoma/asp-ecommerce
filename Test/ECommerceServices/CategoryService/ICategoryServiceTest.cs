using Es.Udc.DotNet.PracticaMaD.Model;
using Es.Udc.DotNet.PracticaMaD.Model.ECommerceServices.CategoryService;
using Es.Udc.DotNet.PracticaMaD.Model.Model1Daos.CategoryDao;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ninject;
using System.Transactions;

namespace Es.Udc.DotNet.PracticaMaD.Test.ECommerceServices.CategoryService
{
    [TestClass()]
    public class ICategoryServiceTest
    {
        private static IKernel kernel;
        private static ICategoryDao categoryDao;
        private static ICategoryService categoryService;

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
            categoryService = kernel.Get<ICategoryService>();
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

        private void createCategoryTest(int size)
        {
            Category category = new Category();
            for (int i = 0; i < size; i++)
            {
                category.visualName = "Test " + i;
                categoryDao.Create(category);
            }
        }

        [TestMethod()]
        public void TestListAllCategories()
        {
            int numberCategories = 10;
            createCategoryTest(numberCategories);

            CategoryBlock list = categoryService.ListAllCategories();

            list.Categories.ForEach(category =>
            {
                Assert.IsTrue(category.visualName.Contains("Test"));
            });
        }
    }
}
