using Es.Udc.DotNet.PracticaMaD.Model;
using Es.Udc.DotNet.PracticaMaD.Model.Model1Daos.CategoryDao;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ninject;
using System.Transactions;

namespace Es.Udc.DotNet.PracticaMaD.Test.ECommerceDaos.CategoryDao
{
    class ICategoryDaoEntityFrameworkTests
    {
        private static IKernel kernel;
        private static ICategoryDao categoryDao;

        private static Category category;
        private static Category category2;

        private const string categoryName = "Category Name";

        private TransactionScope transactionScope;
        private TestContext testContextInstance;

        public TestContext TestContext
        {
            get { return testContextInstance; }
            set { testContextInstance = value; }
        }

        #region Additional test attributes

        //Use ClassInitialize to run code before running the first test in the class
        [ClassInitialize()]
        public static void MyClassInitialize(TestContext testContext)
        {
            kernel = TestManager.ConfigureNInjectKernel();
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

            category = new Category();
            category.visualName = categoryName;

            category2 = new Category();
            category2.visualName = "category2";

            categoryDao.Create(category);
            categoryDao.Create(category2);

        }

        //Use TestCleanup to run code after each test has run
        [TestCleanup()]
        public void MyTestCleanup()
        {
            transactionScope.Dispose();
        }

        #endregion Additional test attributes

        [TestMethod()]
        public void DAO_FindAllCategories()
        {
            Assert.AreEqual(true, categoryDao.FindAllCategory().Contains(category));
            Assert.AreEqual(true, categoryDao.FindAllCategory().Contains(category2));
            Assert.AreEqual(2, categoryDao.FindAllCategory().Count);
        }
    }
}
