using Es.Udc.DotNet.ModelUtil.Exceptions;
using Es.Udc.DotNet.PracticaMaD.Model;
using Es.Udc.DotNet.PracticaMaD.Model.Model1Daos.CreditCardDao;
using Es.Udc.DotNet.PracticaMaD.Model.Model1Daos.UserDao;
using Es.Udc.DotNet.PracticaMaD.Model.Services.Exceptions;
using Es.Udc.DotNet.PracticaMaD.Model.Services.UserService;
using Es.Udc.DotNet.PracticaMaD.Model.Services.Util;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ninject;
using System.Collections.Generic;
using System.Transactions;

namespace Es.Udc.DotNet.PracticaMaD.Test.ECommerceServices.UserService
{
    [TestClass()]
    public class IUserServiceTest
    {
        private static IKernel kernel;
        private static IUserService userService;
        private static IUserDao userDao;
        private static ICreditCardDao creditCardDao;
        private static User user;
        private static CreditCard creditCard;

        private const string login = "loginTest";

        private const string clearPassword = "password";
        private const string name = "name";
        private const string surnames = "surname1 surname2";
        private const string email = "email@email.es";
        private const string postalAddress = "address";

        private const string tipo = "VISA";
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
            userDao = kernel.Get<IUserDao>();
            creditCardDao = kernel.Get<ICreditCardDao>();
            userService = kernel.Get<IUserService>();
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
            user.password = PasswordEncrypter.Crypt(clearPassword);
            user.name = name;
            user.surnames = surnames;
            user.email = email;
            user.postalAddress = postalAddress;

            creditCard = new CreditCard();

            creditCard.tipo = tipo;
            creditCard.number = number;
            creditCard.verifyCode = verifyCode;
            creditCard.expDate = expDate;
            creditCard.isFav = false;
        }

        //Use TestCleanup to run code after each test has run
        [TestCleanup()]
        public void MyTestCleanup()
        {
            transactionScope.Dispose();
        }

        #endregion Additional test attributes

        [TestMethod]
        public void SignUpTest()
        {
            var userId = userService.SignUp(user);

            var userFound = userDao.Find(userId);

            Assert.AreEqual(userId, userFound.userId);
            Assert.AreEqual(login, userFound.login);
            Assert.AreEqual(PasswordEncrypter.Crypt(clearPassword), userFound.password);
            Assert.AreEqual(name, userFound.name);
            Assert.AreEqual(surnames, userFound.surnames);
            Assert.AreEqual(email, userFound.email);
            Assert.AreEqual(postalAddress, userFound.postalAddress);
        }

        [TestMethod]
        [ExpectedException(typeof(DuplicateInstanceException))]
        public void SignUpDuplicatedTest()
        {
            userService.SignUp(user);

            userService.SignUp(user);
        }

        [TestMethod]
        public void LoginClearPasswordTest()
        {
            var userId = userService.SignUp(user);

            var expected = new LoginUser(userId, name, surnames, postalAddress, email);

            var actual =
                userService.Login(login,
                    clearPassword, false);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void LoginEncryptedPasswordTest()
        {
            var userId = userService.SignUp(user);

            var expected = new LoginUser(userId, name, surnames, postalAddress, email);

            var obtained =
                userService.Login(login,
                    PasswordEncrypter.Crypt(clearPassword), true);

            Assert.AreEqual(expected, obtained);
        }

        [TestMethod]
        [ExpectedException(typeof(IncorrectPasswordException))]
        public void LoginIncorrectPasswordTest()
        {
            var userId = userService.SignUp(user);

            var actual =
                userService.Login(login, clearPassword + "X", false);
        }

        [TestMethod]
        [ExpectedException(typeof(InstanceNotFoundException))]
        public void LoginNonExistingUserTest()
        {

            var actual = userService.Login(login, clearPassword, false);
        }

        [TestMethod]
        public void CreateCreditCardTest()
        {
            var userId = userService.SignUp(user);
            creditCard.userId = userId;
            var creditCardId = userService.CreateCreditCard(creditCard);

            var creditCardFound = creditCardDao.Find(creditCardId);

            Assert.AreEqual(creditCardId, creditCardFound.creditCardId);
            Assert.AreEqual(userId, creditCardFound.userId);
            Assert.AreEqual(tipo, creditCardFound.tipo);
            Assert.AreEqual(number, creditCardFound.number);
            Assert.AreEqual(verifyCode, creditCardFound.verifyCode);
            Assert.AreEqual(expDate, creditCardFound.expDate);
            Assert.AreEqual(false, creditCardFound.isFav);
        }

        [TestMethod]
        [ExpectedException(typeof(DuplicateInstanceException))]
        public void CreateDuplicateCreditCardTest()
        {
            var userId = userService.SignUp(user);
            creditCard.userId = userId;
            
            userService.CreateCreditCard(creditCard);
            userService.CreateCreditCard(creditCard);
        }

        [TestMethod]
        public void UpdateCreditCardTest()
        {
            var userId = userService.SignUp(user);
            creditCard.userId = userId;
            var creditCardId = userService.CreateCreditCard(creditCard);

            var creditCardFound = creditCardDao.Find(creditCardId);

            creditCard.isFav = true;

            creditCardDao.Update(creditCard);

            Assert.AreEqual(creditCardId, creditCardFound.creditCardId);
            Assert.AreEqual(userId, creditCardFound.userId);
            Assert.AreEqual(tipo, creditCardFound.tipo);
            Assert.AreEqual(number, creditCardFound.number);
            Assert.AreEqual(verifyCode, creditCardFound.verifyCode);
            Assert.AreEqual(expDate, creditCardFound.expDate);
            Assert.AreEqual(true, creditCardFound.isFav);
        }

        [TestMethod]
        public void FindCreditCardsByUserIdTest()
        {
            var userId = userService.SignUp(user);
            creditCard.userId = userId;
            var creditCardId = userService.CreateCreditCard(creditCard);

            creditCard.creditCardId = creditCardId;

            List<CreditCard> creditCardsFound = userService.FindCreditCardsByUserId(userId, 0);

            Assert.IsTrue(creditCardsFound.Contains(creditCard));
        }

        [TestMethod]
        [ExpectedException(typeof(InstanceNotFoundException))]
        public void FindCreditCardsByUserIdInstanceNotFoundExceptionTest()
        {
            userService.FindCreditCardsByUserId(1L, 0);
        }

        [TestMethod]
        public void FindFavCreditCardByUserIdTest()
        {
            var userId = userService.SignUp(user);
            creditCard.userId = userId;
            creditCard.isFav = true;
            var creditCardId = userService.CreateCreditCard(creditCard);

            creditCard.creditCardId = creditCardId;

            CreditCard creditCardFavFound = userService.FindFavCreditCardByUserId(userId);

            Assert.AreEqual(creditCard, creditCardFavFound);
        }

        [TestMethod]
        [ExpectedException(typeof(InstanceNotFoundException))]
        public void FindFavCreditCardByUserIdInstanceNotFoundExceptionTest()
        {
            userService.FindFavCreditCardByUserId(1L);
        }

        [TestMethod]
        [ExpectedException(typeof(InstanceNotFoundException))]
        public void DeleteCreditCardTest()
        {
            var userId = userService.SignUp(user);
            creditCard.userId = userId;
            var creditCardId = userService.CreateCreditCard(creditCard);

            userService.DeleteCreditCard(creditCardId);

            creditCardDao.Find(creditCardId);
        }

        [TestMethod]
        [ExpectedException(typeof(InstanceNotFoundException))]
        public void DeleteCreditCardInstanceNotFoundExceptionTest()
        {
            userService.DeleteCreditCard(-1L);
        }
    }
}
