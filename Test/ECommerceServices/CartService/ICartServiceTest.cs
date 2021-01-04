using Es.Udc.DotNet.ModelUtil.Exceptions;
using Es.Udc.DotNet.PracticaMaD.Model;
using Es.Udc.DotNet.PracticaMaD.Model.ECommerceServices.CartService;
using Es.Udc.DotNet.PracticaMaD.Model.ECommerceServices.Exceptions;
using Es.Udc.DotNet.PracticaMaD.Model.Model1Daos.CategoryDao;
using Es.Udc.DotNet.PracticaMaD.Model.Model1Daos.ProductDao;
using Es.Udc.DotNet.PracticaMaD.Model.Services.ProductService;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace Es.Udc.DotNet.PracticaMaD.Test.ECommerceServices.CartService
{
    [TestClass()]
    public class ICartServiceTest
    {
        private static IKernel kernel;
        private static ICategoryDao categoryDao;
        private static IProductDao productDao;
        private static ICartService cartService;

        private CartDto cart;

        private Category category = new Category();
        private Product product1 = new Product();
        private Product product2 = new Product();

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
            cartService = kernel.Get<ICartService>();
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

            product1.categoryId = category.categoryId;
            product1.name = "Some name";
            product1.productDate = System.DateTime.Now;
            product1.stockUnits = 100;
            product1.unitPrice = 5;
            product1.type = "Tipo";
            productDao.Create(product1);

            product2.categoryId = category.categoryId;
            product2.name = "Some name 2";
            product2.productDate = System.DateTime.Now;
            product2.stockUnits = 2;
            product2.unitPrice = 5;
            product2.type = "Tipo";
            productDao.Create(product2);
        }

        //Use TestCleanup to run code after each test has run
        [TestCleanup()]
        public void MyTestCleanup()
        {
            transactionScope.Dispose();
        }

        #endregion Additional test attributes

        [TestMethod()]
        public void TestCreateCart()
        {
            cart = cartService.CreateCart();

            Assert.IsNotNull(cart);
        }

        [TestMethod()]
        public void TestAddProductToCart()
        {
            cart = cartService.CreateCart();

            Assert.IsFalse(cart.cartLines.Count > 0);

            cart = cartService.AddProductToCart(cart, product1.productId, 1, false);

            Assert.IsTrue(cart.cartLines.Count > 0);
        }

        [TestMethod()]
        [ExpectedException(typeof(OutOfStockProductException))]
        public void TestAddProductOutOfStockToCart()
        {
            cart = cartService.CreateCart();

            Assert.IsFalse(cart.cartLines.Count > 0);

            cart = cartService.AddProductToCart(cart, product2.productId, 100, false);
        }

        [TestMethod()]
        [ExpectedException(typeof(InstanceNotFoundException))]
        public void TestAddProductNotFoundToCart()
        {
            cart = cartService.CreateCart();

            Assert.IsFalse(cart.cartLines.Count > 0);

            cart = cartService.AddProductToCart(cart, -1L, 1, false);
        }

        [TestMethod()]
        public void TestUpdateCart()
        {
            cart = cartService.CreateCart();
            cart = cartService.AddProductToCart(cart, product1.productId, 1, false);

            cart = cartService.UpdateCart(cart, product1.productId, 9, true);

            Assert.AreEqual(9, cart.cartLines.ElementAt(0).quantity);
            Assert.AreEqual(true, cart.cartLines.ElementAt(0).toPresent);
        }

        [TestMethod()]
        [ExpectedException(typeof(OutOfStockProductException))]
        public void TestOutOfStockUpdateCart()
        {
            cart = cartService.CreateCart();

            cart = cartService.AddProductToCart(cart, product2.productId, 1, false);

            cart = cartService.UpdateCart(cart, product2.productId, 100, false);
        }

        [TestMethod()]
        public void TestAddProductAlreadyExistsToCart()
        {
            cart = cartService.CreateCart();

            Assert.IsFalse(cart.cartLines.Count > 0);

            cart = cartService.AddProductToCart(cart, product1.productId, 1, false);

            Assert.IsTrue(cart.cartLines.Count > 0);
            int cartSize = cart.cartLines.Count;

            cart = cartService.AddProductToCart(cart, product1.productId, 1, false);

            Assert.AreEqual(cartSize, cart.cartLines.Count);
            Assert.AreEqual(1, cart.cartLines.ElementAt(0).quantity);
        }

        [TestMethod()]
        public void TestRemoveCart()
        {
            cart = cartService.CreateCart();

            cart = cartService.AddProductToCart(cart, product1.productId, 1, false);

            CartLineDto line = cart.cartLines.ElementAt(0);

            cart = cartService.RemoveProductFromCart(cart, product1.productId);

            Assert.IsFalse(cart.cartLines.Contains(line));
        }
    }
}
