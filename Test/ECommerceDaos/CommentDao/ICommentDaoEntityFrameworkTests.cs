﻿using Es.Udc.DotNet.PracticaMaD.Model;
using Es.Udc.DotNet.PracticaMaD.Model.ECommerceDaos.RoleDao;
using Es.Udc.DotNet.PracticaMaD.Model.ECommerceDaos.Util;
using Es.Udc.DotNet.PracticaMaD.Model.Model1Daos.CategoryDao;
using Es.Udc.DotNet.PracticaMaD.Model.Model1Daos.CommentDao;
using Es.Udc.DotNet.PracticaMaD.Model.Model1Daos.ProductDao;
using Es.Udc.DotNet.PracticaMaD.Model.Model1Daos.TagDao;
using Es.Udc.DotNet.PracticaMaD.Model.Model1Daos.UserDao;
using Es.Udc.DotNet.PracticaMaD.Model.Services.Util;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace Es.Udc.DotNet.PracticaMaD.Test.ECommerceDaos.CommentDao
{
    [TestClass()]
    public class ICommentDaoEntityFrameworkTests
    {
        private static IKernel kernel;
        private static ICommentDao commentDao;
        private static IProductDao productDao;
        private static ITagDao tagDao;
        private static IRoleDao roleDao;
        private static IUserDao userDao;
        private static ICategoryDao categoryDao;
        private static Role role;
        private static User user;
        private static Product product;
        private static Comment comment;
        private static Category category;
        private static Tag tag;

        private const string login = "loginTest";
        private const string password = "password";
        private const string name = "name";
        private const string surnames = "surname1 surname2";
        private const string email = "email@email.es";
        private const string postalAddress = "address";
        private const string language = "es";
        private const string country = "es";

        private const string commentName = "Some name";
        private  DateTime productDate = System.DateTime.Now;
        private const int stockUnits = 100;
        private const int unitPrice = 5;
        private const string type = "Tipo";

        private const string body = "body";

        private const string tagName = "Tag Name";

        private const string categoryName = "Category Name";

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
            productDao = kernel.Get<IProductDao>();
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

            role = new Role();
            role.name = "TEST";

            roleDao.Create(role);

            user = new User();
            user.roleId = roleDao.FindByName(role.name).roleId;
            user.login = login;
            user.password = PasswordEncrypter.Crypt(password);
            user.name = name;
            user.surnames = surnames;
            user.email = email;
            user.postalAddress = postalAddress;
            user.language = language;
            user.country = country;

            userDao.Create(user);

            category = new Category();
            category.visualName = categoryName;

            categoryDao.Create(category);

            product = new Product();
            product.name = "Some name";
            product.productDate = System.DateTime.Now;
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
        public void DAO_FindAllByProductIdTest()
        {
            try
            {
                comment = new Comment();
                comment.productId = product.productId;
                comment.userId = user.userId;
                comment.body = body;
                comment.commentDate = System.DateTime.Now;

                commentDao.Create(comment);

                Block<Comment> actual = commentDao.FindByProductId(product.productId, 1, 10);

                actual.Results.ForEach(com =>
                {
                    Assert.AreEqual(com.body, comment.body);
                });
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }

        [TestMethod()]
        public void DAO_FindAllByTagId()
        {
            try
            {
                comment = new Comment();
                comment.productId = product.productId;
                comment.userId = user.userId;
                comment.body = body;
                comment.commentDate = System.DateTime.Now;

                tag = new Tag();
                tag.name = "Tag Name";

                tagDao.Create(tag);

                comment.Tag.Add(tag);

                commentDao.Create(comment);

                Block<Comment> actual = commentDao.FindByTag(tag.tagId, 1, 10);

                actual.Results.ForEach(com =>
                {
                    Assert.AreEqual(com.body, comment.body);
                });
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }

        [TestMethod()]
        public void DAO_FindAllByUserIdTest()
        {
            try
            {
                comment = new Comment();
                comment.productId = product.productId;
                comment.userId = user.userId;
                comment.body = body;
                comment.commentDate = System.DateTime.Now;

                commentDao.Create(comment);

                Block<Comment> actual = commentDao.FindByUserId(user.userId, 1, 10);

                actual.Results.ForEach(com =>
                {
                    Assert.AreEqual(com.body, comment.body);
                });
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }
    }
}
