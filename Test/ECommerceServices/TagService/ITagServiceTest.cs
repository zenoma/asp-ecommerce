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
using System.Collections.ObjectModel;
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
            product.stockUnits = stockUnits;
            product.unitPrice = unitPrice;
            product.type = type;
            product.categoryId = category.categoryId;

            productDao.Create(product);

            comment = new Comment();
            comment.commentDate = System.DateTime.Now;
            comment.productId = product.productId;
            comment.userId = user.userId;
            comment.body = body;

            commentDao.Create(comment);

            comment2 = new Comment();
            comment2.commentDate = System.DateTime.Now;
            comment2.productId = product.productId;
            comment2.userId = user.userId;
            comment2.body = body;

            commentDao.Create(comment2);
        }

        //Use TestCleanup to run code after each test has run
        [TestCleanup()]
        public void MyTestCleanup()
        {
            transactionScope.Dispose();
        }

        #endregion Additional test attributes

        private List<long> createTestTags(int size)
        {
            List<long> idTags = new List<long>();
            Tag t;
            for (int i = 0; i < size; i++)
            {
                t = tagService.CreateTag("Test " + i, new List<Comment>() { comment });
                idTags.Add(t.tagId);
            }
            return idTags;
        }

        [TestMethod()]
        public void TestCreateTag()
        {
            ICollection<Comment> comments = new Collection<Comment>();
            Tag tagExpected = new Tag();
            tagExpected.name = "test";
            comments.Add(comment);
            tagExpected.Comment = comments;

            Tag tag = tagService.CreateTag("test", new List<Comment>() { comment });

            Assert.AreEqual(tag.name, tagExpected.name);
        }

        [TestMethod()]
        public void TestGetTopFiveTags()
        {
            int numberTags = 5;
            List<long> idTags = createTestTags(numberTags);

            List<TagDetails> listTags = tagService.GetTopTags(numberTags);

            Assert.AreEqual(numberTags, listTags.Count);

            listTags.ForEach(tag =>
            {
                Assert.IsTrue(idTags.Contains(tag.tagId));
            });
        }

        [TestMethod()]
        public void TestFindAllTags()
        {
            int numberTags = 20;
            List<long> idTags = createTestTags(numberTags);

            List<Tag> listTags = tagService.ListAllTags();

            Assert.AreEqual(numberTags, listTags.Count);
        }

        [TestMethod()]
        public void TesListTagsByCommentId()
        {
            int numberTags = 20;
            List<long> idTags = createTestTags(numberTags);

            List<Tag> listTags = tagService.ListTagsByComment(comment.commentId);

            Assert.AreEqual(numberTags, listTags.Count);

            Comment commentFound = commentDao.Find(comment.commentId);

            listTags.ForEach(tag =>
            {
                Assert.IsTrue(idTags.Contains(tag.tagId));
                Assert.IsTrue(tag.Comment.Contains(commentFound));
            });
        }
    }
}
