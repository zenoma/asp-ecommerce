using Es.Udc.DotNet.PracticaMaD.Model;
using Es.Udc.DotNet.PracticaMaD.Model.ECommerceServices.CommentService;
using Es.Udc.DotNet.PracticaMaD.Model.ECommerceServices.TagService;
using Es.Udc.DotNet.PracticaMaD.Model.Model1Daos.CategoryDao;
using Es.Udc.DotNet.PracticaMaD.Model.Model1Daos.CommentDao;
using Es.Udc.DotNet.PracticaMaD.Model.Model1Daos.ProductDao;
using Es.Udc.DotNet.PracticaMaD.Model.Model1Daos.TagDao;
using Es.Udc.DotNet.PracticaMaD.Model.Model1Daos.UserDao;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace Es.Udc.DotNet.PracticaMaD.Test.ECommerceServices.TagService
{
    [TestClass()]
    public class ITagServiceTest
    {
        private static IKernel kernel;
        private static ITagService tagService;
        private static IProductDao productDao;
        private static ICommentDao commentDao;
        private static IUserDao userDao;
        private static ICategoryDao categoryDao;
        private static ITagDao tagDao;

        // Variables used in several tests are initialized 
        private User user = new User();
        private Product product = new Product();
        private Comment comment = new Comment();
        private Comment comment2 = new Comment();
        private Category category = new Category();
        private Tag tag = new Tag();
        private Tag tag2 = new Tag();
        private List<Tag> tagList = new List<Tag>();

        private const string login = "loginTest";
        private const string password = "password";
        private const string name = "name";
        private const string surnames = "surname1 surname2";
        private const string email = "email@email.es";
        private const string postalAddress = "address";

        private const string productName = "Some name";
        private DateTime productDate = System.DateTime.Now;
        private const int stockUnits = 100;
        private const int unitPrice = 5;
        private const string type = "Tipo";

        private const string body = "body";

        private const string tagName = "Tag Name";

        private const string categoryName = "Category Name";

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
            tagService = kernel.Get<ITagService>();
            productDao = kernel.Get<IProductDao>();
            commentDao = kernel.Get<ICommentDao>();
            categoryDao = kernel.Get<ICategoryDao>();
            userDao = kernel.Get<IUserDao>();
            tagDao = kernel.Get<ITagDao>();
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
            user.login = login;
            user.password = password;
            user.name = name;
            user.surnames = surnames;
            user.email = email;
            user.postalAddress = postalAddress;

            userDao.Create(user);

            category = new Category();
            category.visualName = categoryName;

            categoryDao.Create(category);

            product = new Product();
            product.name = productName;
            product.productDate = productDate;
            product.stockUnits = 100;
            product.unitPrice = 5;
            product.type = "Tipo";
            product.categoryId = category.categoryId;

            productDao.Create(product);

            comment = new Comment();
            comment.commentDate = System.DateTime.Now;
            comment.productId = product.productId;
            comment.userId = user.userId;
            comment.body = body;

            comment2 = new Comment();
            comment2.commentDate = System.DateTime.Now;
            comment2.productId = product.productId;
            comment2.userId = user.userId;
            comment2.body = body;

            tag = new Tag();
            tag.name = "Tag Name";

            tag2 = new Tag();
            tag2.name = "Tag Name";
            //tag.Comment.Add(comment);

            tagDao.Create(tag);
            tagDao.Create(tag2);

            comment.Tag.Add(tag);

            commentDao.Create(comment);
            commentDao.Create(comment2);
        }

        //Use TestCleanup to run code after each test has run
        [TestCleanup()]
        public void MyTestCleanup()
        {
            transactionScope.Dispose();
        }

        #endregion Additional test attributes

        [TestMethod()]
        public void TestGetTopFiveTags()
        {
            List<TagDetails> listTags = tagService.GetTopTags(5);

            Assert.AreEqual(2, listTags.Count);
            Assert.AreEqual(1, listTags.First().count);
            Assert.AreEqual(true, listTags.Contains(new TagDetails(tag.tagId, tag.name, tag.Comment.Count)));
            Assert.AreEqual(true, listTags.Contains(new TagDetails(tag2.tagId, tag2.name, tag2.Comment.Count)));
        }

        [TestMethod()]
        public void TestFindAllTags()
        {
            List<Tag> listTags = tagService.ListAllTags();

            Assert.AreEqual(2, listTags.Count);
        }
    }
}
