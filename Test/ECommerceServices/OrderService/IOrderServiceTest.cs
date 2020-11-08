﻿using Es.Udc.DotNet.PracticaMaD.Model;
using Es.Udc.DotNet.PracticaMaD.Model.ECommerceServices.OrderService;
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
using System.Transactions;

namespace Es.Udc.DotNet.PracticaMaD.Test.ECommerceServices.OrderService
{
    [TestClass()]
    public class IOrderServiceTest
    {
        private static IKernel kernel;
        private static IOrderService orderService;
        private static IUserDao userDao;
        private static ICreditCardDao creditCardDao;
        private static IProductDao productDao;
        private static ICategoryDao categoryDao;

        // Variables used in several tests are initialized 
        private static Category category;
        private static Product productA;
        private static Product productB;

        private static User user;
        private static CreditCard creditCard;

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
            orderService = kernel.Get<IOrderService>();
            creditCardDao = kernel.Get<ICreditCardDao>();
            productDao = kernel.Get<IProductDao>();
            categoryDao = kernel.Get<ICategoryDao>();
            userDao = kernel.Get<IUserDao>();
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
            creditCard.tipo = "VISA";
            creditCard.number = 1234123412341234L;
            creditCard.verifyCode = 123;
            creditCard.expDate = DateTime.Now;
            creditCard.isFav = false;

            creditCardDao.Create(creditCard);

            category = new Category();
            category.visualName = "Category";

            categoryDao.Create(category);

            productA = new Product();
            productA.categoryId = category.categoryId;
            productA.name = "Some name";
            productA.productDate = DateTime.Now;
            productA.stockUnits = 100;
            productA.unitPrice = 5;
            productA.type = "Tipo";
            productDao.Create(productA);

            productB = new Product();
            productB.categoryId = category.categoryId;
            productB.name = "Other name";
            productB.productDate = DateTime.Now.AddDays(-3);
            productB.stockUnits = 50;
            productB.unitPrice = 10;
            productB.type = "Tipo 2";
            productDao.Create(productB);
        }

        //Use TestCleanup to run code after each test has run
        [TestCleanup()]
        public void MyTestCleanup()
        {
            transactionScope.Dispose();
        }

        #endregion Additional test attributes

        [TestMethod]
        public void CreateOrderTest()
        { 
            List<OrderItem> orderItems = new List<OrderItem>();

            OrderItem orderA = new OrderItem();
            orderA.productId = productA.productId;
            orderA.orderId = -1;
            orderA.units = 5;
            orderA.unitPrice = productA.unitPrice;
            orderItems.Add(orderA);

            OrderItem orderB = new OrderItem();
            orderB.productId = productB.productId;
            orderB.orderId = -1;
            orderB.units = 5;
            orderB.unitPrice = productB.unitPrice;
            orderItems.Add(orderB);

            Order actual = orderService.CreateOrder(user.login,orderItems,creditCard.creditCardId, "New address");

            Order expected = orderService.FindByOrderId(actual.orderId);

            Assert.AreEqual(expected, actual);
            
        }

        [TestMethod]
        public void FindByUserIdTest()
        {
            List<Order> orders;

            orders = orderService.FindByUserLogin(user.login, 0);

            Assert.AreEqual(orders.Count, 0);

        }
    }
}