﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using Es.Udc.DotNet.ModelUtil.Exceptions;
using Es.Udc.DotNet.PracticaMaD.Model;
using Es.Udc.DotNet.PracticaMaD.Model.ECommerceDaos.RoleDao;
using Es.Udc.DotNet.PracticaMaD.Model.ECommerceServices.CommentService;
using Es.Udc.DotNet.PracticaMaD.Model.Model1Daos.CategoryDao;
using Es.Udc.DotNet.PracticaMaD.Model.Model1Daos.CommentDao;
using Es.Udc.DotNet.PracticaMaD.Model.Model1Daos.ProductDao;
using Es.Udc.DotNet.PracticaMaD.Model.Model1Daos.TagDao;
using Es.Udc.DotNet.PracticaMaD.Model.Model1Daos.UserDao;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ninject;

namespace Es.Udc.DotNet.PracticaMaD.Test.ECommerceServices.CommentService
{
    [TestClass()]
    public class ICommentServiceTest
    {
        private static IKernel kernel;
        private static ICommentService commentService;
        private static IProductDao productDao;
        private static ICommentDao commentDao;
        private static IRoleDao roleDao;
        private static IUserDao userDao;
        private static ICategoryDao categoryDao;
        private static ITagDao tagDao;

        // Variables used in several tests are initialized 
        private Role role = new Role();
        private User user = new User();
        private Product product = new Product();
        private Comment comment = new Comment();
        private Category category = new Category();
        private Tag tag = new Tag();
        private List<string> tagList = new List<string>();

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
            commentService = kernel.Get<ICommentService>();
            productDao = kernel.Get<IProductDao>();
            commentDao = kernel.Get<ICommentDao>();
            categoryDao = kernel.Get<ICategoryDao>();
            roleDao = kernel.Get<IRoleDao>();
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
            role.name = "ADMIN";
            roleDao.Create(role);

            role.name = "USER";
            roleDao.Create(role);

            transactionScope = new TransactionScope();
            user.roleId = roleDao.FindByName("USER").roleId;
            user.login = "login";
            user.password = "password";
            user.email = "email";
            user.postalAddress = "postal adress";
            user.name = "name";
            user.surnames = "surnames";
            user.language = "es";
            user.country = "es";
            userDao.Create(user);

            category.visualName = "Category";
            categoryDao.Create(category);

            product.categoryId = category.categoryId;
            product.name = "Some name";
            product.productDate = System.DateTime.Now;
            product.stockUnits = 100;
            product.unitPrice = 5;
            product.type = "Tipo";
            productDao.Create(product);

            tag.name = "tag";
            tagDao.Create(tag);
        }

        //Use TestCleanup to run code after each test has run
        [TestCleanup()]
        public void MyTestCleanup()
        {
            transactionScope.Dispose();
        }

        #endregion Additional test attributes

        [TestMethod()]
        public void TestCommentExistingProduct()
        {
            comment = commentService.CreateComment(product.productId, user.userId, "Comment", null);

            Assert.AreEqual(commentDao.Find(comment.commentId), comment);
        }

        [TestMethod()]
        [ExpectedException(typeof(InstanceNotFoundException))]
        public void TestCommentExistingProductAndRemove()
        {
            comment = commentService.CreateComment(product.productId, user.userId, "Comment", null);
            commentService.RemoveComment(user.userId, comment.commentId);

            Assert.AreEqual(commentDao.Find(comment.commentId), comment);

            commentDao.Find(comment.commentId);

        }

        [TestMethod()]
        public void TestShowCommentsOfProduct()
        {
            comment = commentService.CreateComment(product.productId, user.userId, "Comment1", null);
            comment = commentService.CreateComment(product.productId, user.userId, "Comment2", null);
            comment = commentService.CreateComment(product.productId, user.userId, "Comment3", null);

            int count = 10;
            int page = 1;
            CommentBlock commentBlock;

            do
            {
                commentBlock = commentService.ShowCommentsOfProduct(product.productId, page, count);

                Assert.IsTrue(commentBlock.Comments.Count <= count);

                page += count;

            } while (commentBlock.ExistMoreComments);
        }

        [TestMethod()]
        public void TestTagComment()
        {
            tagList.AddRange(new List<String>() { "tag", "tag2" });

            comment = commentService.CreateComment(product.productId, user.userId, "Body of Comment1", tagList);
            Comment commentFound = commentDao.Find(comment.commentId);

            Assert.IsTrue(commentFound.Tag.Contains(tag));
            Assert.AreEqual(tagList.Count, commentDao.Find(comment.commentId).Tag.Count);
        }

        [TestMethod()]
        public void TestListCommentsByTag()
        {

            int count = 10;
            int page = 1;
            CommentBlock commentBlock;

            tagList.Add("tag");
            comment = commentService.CreateComment(product.productId, user.userId, "Comment1", tagList);

            do
            {
                commentBlock = commentService.ListCommentsByTag(tag.tagId, page, count);

                Assert.IsTrue(commentBlock.Comments.Count <= count);

                page += count;

            } while (commentBlock.ExistMoreComments);
        }

        [TestMethod()]
        public void TestUpdateComment()
        {
            
            comment = commentService.CreateComment(product.productId, user.userId, "Comment1", null);

            Assert.AreEqual(0, commentDao.Find(comment.commentId).Tag.Count);

            tagList.Add("tag3");

            commentService.UpdateComment(comment.commentId, "new comment body", tagList);

            Assert.AreEqual(1, commentDao.Find(comment.commentId).Tag.Count);
            Assert.AreEqual("tag3", tagDao.FindByVisualName("tag3").name);
        }

        [TestMethod()]
        public void TestListCommentsByUserId()
        {

            int count = 10;
            int page = 1;
            CommentBlock commentBlock;

            tagList.Add("tag");
            comment = commentService.CreateComment(product.productId, user.userId, "Comment1", tagList);

            do
            {
                commentBlock = commentService.ListCommentsByUserId(user.userId, page, count);

                Assert.IsTrue(commentBlock.Comments.Count <= count);

                page += count;

            } while (commentBlock.ExistMoreComments);
        }

        [TestMethod()]
        public void TestFindCommentById()
        {
            CommentDetails commentDetails;

            tagList.Add("tag");
            comment = commentService.CreateComment(product.productId, user.userId, "Comment1", tagList);

            commentDetails = commentService.FindCommentById(comment.commentId);

            User userFound = userDao.Find(comment.userId);
            Product productFound = productDao.Find(comment.productId);

            Assert.AreEqual(comment.commentId, commentDetails.commentId);
            Assert.AreEqual(userFound.login, commentDetails.userLogin);
            Assert.AreEqual(productFound.name, commentDetails.productName);
            Assert.AreEqual(comment.body, commentDetails.body);
            Assert.AreEqual(comment.commentDate, commentDetails.commentDate);
        }
    }
}