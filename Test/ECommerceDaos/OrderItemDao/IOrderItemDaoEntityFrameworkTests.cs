using Es.Udc.DotNet.PracticaMaD.Model;
using Es.Udc.DotNet.PracticaMaD.Model.Model1Daos.CategoryDao;
using Es.Udc.DotNet.PracticaMaD.Model.Model1Daos.CreditCardDao;
using Es.Udc.DotNet.PracticaMaD.Model.Model1Daos.OrderDao;
using Es.Udc.DotNet.PracticaMaD.Model.Model1Daos.OrderItemDao;
using Es.Udc.DotNet.PracticaMaD.Model.Model1Daos.ProductDao;
using Es.Udc.DotNet.PracticaMaD.Model.Model1Daos.UserDao;
using Es.Udc.DotNet.PracticaMaD.Model.Services.Util;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ninject;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Transactions;

namespace Es.Udc.DotNet.PracticaMaD.Test.ECommerceDaos.OrderItemDao
{
    [TestClass()]
    public class IOrderItemDaoEntityFrameworkTests
    {
        private static IKernel kernel;
        private static IUserDao userDao;
        private static IOrderDao orderDao;
        private static IOrderItemDao orderItemDao;
        private static ICreditCardDao creditCardDao;
        private static IProductDao productDao;
        private static ICategoryDao categoryDao;
        private static User user;
        private static CreditCard creditCard;
        private static Order order;
        private static Product product;
        private static Category category;

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
            orderItemDao = kernel.Get<IOrderItemDao>();
            creditCardDao = kernel.Get<ICreditCardDao>();
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

            user = new User();
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

            order = new Order();
            order.userId = user.userId;
            order.orderDate = System.DateTime.Now;
            order.address = user.postalAddress;
            order.orderAlias = "test";
            order.creditCardNumber = creditCard.number;

            orderDao.Create(order);

            category = new Category();
            category.visualName = "Category";
            categoryDao.Create(category);

            product = new Product();
            product.name = "Some Name";
            product.productDate = System.DateTime.Now.AddDays(-5);
            product.stockUnits = 100;
            product.unitPrice = 5;
            product.type = "Tipo";
            product.categoryId = category.categoryId;
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
        public void FindByOrderIdTest()
        {
            int numberOfOrderItems= 10;

            List<OrderItem> createdOrderItems = new List<OrderItem>(numberOfOrderItems);

            for (int i = 0; i < numberOfOrderItems; i++)
            {
                OrderItem orderItem = new OrderItem();
                orderItem.productId = product.productId;
                orderItem.orderId = order.orderId;
                orderItem.units = 2;
                orderItem.unitPrice = product.unitPrice;
                orderItemDao.Create(orderItem);
                createdOrderItems.Add(orderItem);
            }

            int count = 10;
            int startIndex = 0;

            List<OrderItem> listOrdersItems;
            List<OrderItem> totalRetrievedOrderItems = new List<OrderItem>(numberOfOrderItems);
            do
            {
                listOrdersItems = orderItemDao.FindByOrderId(order.orderId);
                totalRetrievedOrderItems.AddRange(listOrdersItems);

                Assert.IsTrue(listOrdersItems.Count <= count);
                startIndex += count;
            } while (startIndex < numberOfOrderItems);


            Assert.AreEqual(numberOfOrderItems, totalRetrievedOrderItems.Count);

            // are the accounts retrieved the same than the originals?
            for (int i = 0; i < numberOfOrderItems; i++)
            {
                Assert.AreEqual(totalRetrievedOrderItems[i].orderItemId, createdOrderItems[i].orderItemId);
            }
        }

        [TestMethod()]
        public void FindByOrderIdWithoutOrdersTest()
        {
            List<OrderItem> retrievedOrderItems = orderItemDao.FindByOrderId(order.orderId);

            Assert.IsTrue(retrievedOrderItems.Count == 0);
        }
    }
}
