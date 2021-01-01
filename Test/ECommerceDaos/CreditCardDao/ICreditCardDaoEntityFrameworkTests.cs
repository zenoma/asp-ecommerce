using Es.Udc.DotNet.PracticaMaD.Model;
using Es.Udc.DotNet.PracticaMaD.Model.ECommerceDaos.RoleDao;
using Es.Udc.DotNet.PracticaMaD.Model.Model1Daos.CreditCardDao;
using Es.Udc.DotNet.PracticaMaD.Model.Model1Daos.UserDao;
using Es.Udc.DotNet.PracticaMaD.Model.Services.Util;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace Es.Udc.DotNet.PracticaMaD.Test.ECommerceDaos.CreditCardDao
{
    [TestClass()]
    public class ICreditCardDaoEntityFrameworkTests
    {
        private static IKernel kernel;
        private static ICreditCardDao creditCardDao;
        private static IRoleDao roleDao;
        private static IUserDao userDao;
        private static CreditCard creditCard;
        private static Role role;
        private static User user;

        private const string login = "loginTest";
        private const string password = "password";
        private const string name = "name";
        private const string surnames = "surname1 surname2";
        private const string email = "email@email.es";
        private const string postalAddress = "address";
        private const string language = "es";
        private const string country = "es";

        private const string type = "VISA";
        private const long number = 1234123412341234L;
        private const short verifyCode = 123;
        private System.DateTime expDate = System.DateTime.Now;

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
            user.login = login;
            user.password = PasswordEncrypter.Crypt(password);
            user.name = name;
            user.surnames = surnames;
            user.email = email;
            user.postalAddress = postalAddress;
            user.language = language;
            user.country = country;

            userDao.Create(user);

            creditCard = new CreditCard();

            creditCard.userId = user.userId;
            creditCard.type = type;
            creditCard.number = number;
            creditCard.verifyCode = verifyCode;
            creditCard.expDate = expDate;
            creditCard.isFav = false;

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
        public void DAO_FindAllByUserIdTest()
        {
            try
            {
                List<CreditCard> actual = creditCardDao.FindAllByUserId(user.userId);

                actual.ForEach(cc =>
                {
                    Assert.AreEqual(cc.type, creditCard.type);
                    Assert.AreEqual(cc.userId, creditCard.userId);
                });
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }

        [TestMethod()]
        public void DAO_FindFavByUserIdTest()
        {
            creditCard.isFav = true;
            creditCardDao.Update(creditCard);
            try
            {
                CreditCard actual = creditCardDao.FindFavByUserId(user.userId);

                Assert.AreEqual(actual.type, creditCard.type);
                Assert.AreEqual(actual.userId, creditCard.userId);
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }

        [TestMethod()]
        public void DAO_FindFavByUserIdErrorTest()
        {
            CreditCard actual = creditCardDao.FindFavByUserId(user.userId);

            Assert.AreEqual(null, actual);
        }
    }
}
