using Es.Udc.DotNet.PracticaMaD.Model;
using Es.Udc.DotNet.PracticaMaD.Model.ECommerceDaos.RoleDao;
using Es.Udc.DotNet.PracticaMaD.Model.ECommerceDaos.Util;
using Es.Udc.DotNet.PracticaMaD.Model.Model1Daos.CreditCardDao;
using Es.Udc.DotNet.PracticaMaD.Model.Model1Daos.OrderDao;
using Es.Udc.DotNet.PracticaMaD.Model.Model1Daos.UserDao;
using Es.Udc.DotNet.PracticaMaD.Model.Services.Util;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ninject;
using System.Collections.Generic;
using System.Transactions;

namespace Es.Udc.DotNet.PracticaMaD.Test.ECommerceDaos.OrderDao
{
    [TestClass()]
    public class IOrderDaoEntityFrameworkTests
    {
        private static IKernel kernel;
        private static IRoleDao roleDao;
        private static IUserDao userDao;
        private static IOrderDao orderDao;
        private static ICreditCardDao creditCardDao;
        private static Role role;
        private static User user;
        private static CreditCard creditCard;

        private const long NON_EXISTENT_USER_ID = -1;

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
            userDao = kernel.Get<IUserDao>();
            orderDao = kernel.Get<IOrderDao>();
            creditCardDao = kernel.Get<ICreditCardDao>();
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
            role.name = "TEST";

            roleDao.Create(role);

            user = new User();
            user.roleId = roleDao.FindByName(role.name).roleId;
            user.login = "loginTest";
            user.password = PasswordEncrypter.Crypt("password");
            user.name = "name";
            user.surnames = "surname1 surname2";
            user.email = "email@email.es";
            user.postalAddress = "address";
            user.language = "es";
            user.country = "es";

            userDao.Create(user);

            creditCard = new CreditCard();
            creditCard.userId = user.userId;
            creditCard.type = "Visa";
            creditCard.verifyCode = 303;
            creditCard.expDate = System.DateTime.Now.AddDays(20);
            creditCard.isFav = true;

            creditCardDao.Create(creditCard);

        }

        //Use TestCleanup to run code after each test has run
        [TestCleanup()]
        public void MyTestCleanup()
        {
            transactionScope.Dispose();
        }

        #endregion Additional test attributes

        [TestMethod()]
        public void FindByUserIdTest()
        {
            int numberOfOrders = 10;

            List<Order> createdOrders = new List<Order>(numberOfOrders);

            for (int i = 0; i < numberOfOrders; i++)
            {
                Order order = new Order();
                order.userId = user.userId;
                order.orderDate = System.DateTime.Now;
                order.address = user.postalAddress;
                order.orderAlias = "test";
                order.creditCardNumber = creditCard.number;

                orderDao.Create(order);
                createdOrders.Add(order);

            }

            int count = 10;
            int page = 1;

            Block<Order> listOrders;
            List<Order> totalRetrievedOrders = new List<Order>(numberOfOrders);
            do
            {
                listOrders = orderDao.findByUserId(user.userId, page, count);
                totalRetrievedOrders.AddRange(listOrders.Results);

                Assert.IsTrue(listOrders.Results.Count <= count);
                page += count;
            } while (page < numberOfOrders);


            Assert.AreEqual(numberOfOrders, totalRetrievedOrders.Count);

            for (int i = 0; i < numberOfOrders; i++)
            {
                Assert.AreEqual(totalRetrievedOrders[i].orderId, createdOrders[i].orderId);
            }
        }

        [TestMethod()]
        public void FindByUserIdWithoutOrdersTest()
        {
            int count = 10;
            int page = 10;

            Block<Order> retrievedOrders = orderDao.findByUserId(user.userId, page, count);

            Assert.IsTrue(retrievedOrders.Results.Count == 0);
        }
    }
}
