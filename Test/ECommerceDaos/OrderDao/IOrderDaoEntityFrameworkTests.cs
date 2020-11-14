using Es.Udc.DotNet.PracticaMaD.Model;
using Es.Udc.DotNet.PracticaMaD.Model.Model1Daos.CreditCardDao;
using Es.Udc.DotNet.PracticaMaD.Model.Model1Daos.OrderDao;
using Es.Udc.DotNet.PracticaMaD.Model.Model1Daos.UserDao;
using Es.Udc.DotNet.PracticaMaD.Model.Services.Util;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ninject;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Transactions;

namespace Es.Udc.DotNet.PracticaMaD.Test.ECommerceDaos.OrderDao
{
    [TestClass()]
    public class IOrderDaoEntityFrameworkTests
    {
        private static IKernel kernel;
        private static IUserDao userDao;
        private static IOrderDao orderDao;
        private static ICreditCardDao creditCardDao;
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

            user = new User();
            user.login = "loginTest";
            user.password = PasswordEncrypter.Crypt("password");
            user.name = "name";
            user.surnames = "surname1 surname2";
            user.email = "email@email.es";
            user.postalAddress = "address";

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
                order.creditCardId = creditCard.creditCardId;

                orderDao.Create(order);
                createdOrders.Add(order);

            }

            int count = 10;
            int startIndex = 0;

            List<Order> listOrders;
            List<Order> totalRetrievedOrders = new List<Order>(numberOfOrders);
            do
            {
                listOrders = orderDao.findByUserId(user.userId, startIndex, count);
                totalRetrievedOrders.AddRange(listOrders);

                Assert.IsTrue(listOrders.Count <= count);
                startIndex += count;
            } while (startIndex < numberOfOrders);


            Assert.AreEqual(numberOfOrders, totalRetrievedOrders.Count);

            // are the accounts retrieved the same than the originals?
            for (int i = 0; i < numberOfOrders; i++)
            {
                Assert.AreEqual(totalRetrievedOrders[i], createdOrders[i]);
            }
        }

        [TestMethod()]
        public void FindByUserIdWithoutOrdersTest()
        {
            int count = 10;
            int startIndex = 10;

            List<Order> retrievedOrders = orderDao.findByUserId(user.userId, startIndex, count);

            Assert.IsTrue(retrievedOrders.Count == 0);
        }
    }
}
