using Es.Udc.DotNet.PracticaMaD.Model;
using Es.Udc.DotNet.PracticaMaD.Model.ECommerceDaos.RoleDao;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ninject;
using System;
using System.Transactions;

namespace Es.Udc.DotNet.PracticaMaD.Test.ECommerceDaos.RoleDao
{
    [TestClass()]
    public class IRoleDaoEntityFrameworkTests
    {
        private static IKernel kernel;
        private static IRoleDao roleDao;
        private static Role role;

        private const string name = "test";

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
            roleDao = kernel.Get<IRoleDao>();
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

            role = new Role();
            role.name = name;

            roleDao.Create(role);
        }

        //Use TestCleanup to run code after each test has run
        [TestCleanup()]
        public void MyTestCleanup()
        {
            transactionScope.Dispose();
        }

        #endregion Additional test attributes

        [TestMethod()]
        public void DAO_FindByNameTest()
        {
            try
            {
                Role actual = roleDao.FindByName(role.name);

                Assert.AreEqual(role.roleId, actual.roleId);
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }
    }
}
