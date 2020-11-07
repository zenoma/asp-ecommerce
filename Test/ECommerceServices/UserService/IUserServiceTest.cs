using Es.Udc.DotNet.ModelUtil.Exceptions;
using Es.Udc.DotNet.PracticaMaD.Model;
using Es.Udc.DotNet.PracticaMaD.Model.Model1Daos.UserDao;
using Es.Udc.DotNet.PracticaMaD.Model.Services.Exceptions;
using Es.Udc.DotNet.PracticaMaD.Model.Services.UserService;
using Es.Udc.DotNet.PracticaMaD.Model.Services.Util;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ninject;
using System.Transactions;

namespace Es.Udc.DotNet.PracticaMaD.Test.ECommerceServices.UserService
{
    [TestClass()]
    public class IUserServiceTest
    {
        private static IKernel kernel;
        private static IUserService userService;
        private static IUserDao userDao;
        private static User user;

        private const string login = "loginTest";

        private const string clearPassword = "password";
        private const string name = "name";
        private const string surnames = "surname1 surname2";
        private const string email = "email@email.es";
        private const string postalAddress = "address";

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
    }
}
