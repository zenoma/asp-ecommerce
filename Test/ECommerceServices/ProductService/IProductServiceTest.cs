using Es.Udc.DotNet.PracticaMaD.Model;
using Es.Udc.DotNet.PracticaMaD.Model.ECommerceDaos.RoleDao;
using Es.Udc.DotNet.PracticaMaD.Model.ECommerceDaos.Util;
using Es.Udc.DotNet.PracticaMaD.Model.ECommerceServices.ProductService;
using Es.Udc.DotNet.PracticaMaD.Model.Model1Daos.CategoryDao;
using Es.Udc.DotNet.PracticaMaD.Model.Model1Daos.CommentDao;
using Es.Udc.DotNet.PracticaMaD.Model.Model1Daos.ProductDao;
using Es.Udc.DotNet.PracticaMaD.Model.Model1Daos.TagDao;
using Es.Udc.DotNet.PracticaMaD.Model.Model1Daos.UserDao;
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
        private static ITagDao tagDao;
        private static IRoleDao roleDao;
        private static IUserDao userDao;
        private static ICommentDao commentDao;

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
            commentDao = kernel.Get<ICommentDao>();
            roleDao = kernel.Get<IRoleDao>();
            userDao = kernel.Get<IUserDao>();
            tagDao = kernel.Get<ITagDao>();
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
            SearchCache<Product> cache = new SearchCache<Product>();
            cache.clearCache();
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
            for (int i = 0; i < size; i++)
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

            ProductBlock list = productService.FindProducts("Test", NON_EXISTENT_CATEGORY_ID, 1, numberProducts / 2);

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
            Music oldProduct = new Music();
            oldProduct.categoryId = category.categoryId;
            oldProduct.productDate = System.DateTime.Now;
            oldProduct.stockUnits = 100;
            oldProduct.unitPrice = 5;
            oldProduct.type = "Tipo";
            oldProduct.name = "Old Name";
            oldProduct.album = "Old Album";
            oldProduct.artist = "Old Artist";
            productDao.Create(oldProduct);

            using (var scope = new TransactionScope())
            {
                Product productFound = productDao.FindByName("Old Name", 1, 1).Results[0];
                ProductDetails newDetails = new ProductDetails(productFound.productId, category.categoryId, "New category", "New Name", 5, 10, "New Type", System.DateTime.Now, "New Album", "New Artist", null, default, null, 0, null);
                productService.UpdateProduct(productFound.productId, newDetails);

                var updatedProduct =
                    productService.FindProductDetails(productFound.productId);

                Assert.AreEqual(newDetails.name, updatedProduct.name);
            }

        }


        [TestMethod]
        public void FindByNameByTagTest()
        {

            int numberOfProducts = 5;

            List<Product> createdProducts = new List<Product>(numberOfProducts);
            string name = "Some Name";

            Category category = new Category();
            category.visualName = "Category";
            categoryDao.Create(category);
            Tag newTag = new Tag();
            newTag.name = "New";
            tagDao.Create(newTag);

            Tag oldTag = new Tag();
            oldTag.name = "Old";
            tagDao.Create(oldTag);


            Role role = new Role();
            role.name = "TEST";

            roleDao.Create(role);

            User user = new User();
            user.roleId = roleDao.FindByName(role.name).roleId;
            user.login = "login";
            user.password = "password";
            user.name = "name";
            user.surnames = "surnames";
            user.email = " email";
            user.postalAddress = "postalAddress";
            user.language = "es";
            user.country = "es";

            userDao.Create(user);
            user.userId = userDao.FindByLogin(user.login).userId;

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

                if (i == 1 || i == 3)
                {
                    for (int j = 0; j < 10; j++)
                    {
                        Comment comment = new Comment();
                        comment.commentDate = System.DateTime.Now;
                        comment.productId = product.productId;
                        comment.userId = user.userId;
                        comment.body = "test comment";
                        comment.Tag.Add(newTag);
                        commentDao.Create(comment);
                    }
                }
                else if (i == 2)
                {
                    for (int j = 0; j < 5; j++)
                    {
                        Comment comment = new Comment();
                        comment.commentDate = System.DateTime.Now;
                        comment.productId = product.productId;
                        comment.userId = user.userId;
                        comment.body = "test comment";
                        comment.Tag.Add(oldTag);
                        commentDao.Create(comment);
                    }
                }
            }


            ProductBlock retrievedNewProducts = productService.FindProductsByTagId(newTag.tagId, 1, 10);

            Assert.IsTrue(retrievedNewProducts.Products.Count == 2);

            ProductBlock retrievedOldProducts = productService.FindProductsByTagId(oldTag.tagId, 1, 10);

            Assert.IsTrue(retrievedOldProducts.Products.Count == 1);
        }



    }
}
