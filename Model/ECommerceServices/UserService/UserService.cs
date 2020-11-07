using Es.Udc.DotNet.ModelUtil.Exceptions;
using Es.Udc.DotNet.ModelUtil.Transactions;
using Es.Udc.DotNet.PracticaMaD.Model.Model1Daos.UserDao;
using Es.Udc.DotNet.PracticaMaD.Model.Services.Exceptions;
using Es.Udc.DotNet.PracticaMaD.Model.Services.Util;
using Ninject;

namespace Es.Udc.DotNet.PracticaMaD.Model.Services.UserService
{
    public class UserService : IUserService
    {
        public UserService()
        {

        }

        [Inject]
        public IUserDao UserDao { set; get; }

        /// <exception cref="DuplicateInstanceException"/>
        [Transactional]
        public long SignUp(User user)
        {
            try
            {
                User alreadyExists = UserDao.FindByLogin(user.login);

                throw new DuplicateInstanceException(alreadyExists, "User");
            }
            catch (InstanceNotFoundException)
            {
                UserDao.Create(user);

                return user.userId;
            }
        }

        /// <exception cref="InstanceNotFoundException"/>
        /// <exception cref="IncorrectPasswordException"/>
        [Transactional]
        public LoginUser Login(string login, string password, bool passwordIsEncrypted)
        {
            User user = UserDao.FindByLogin(login);

            string storedPassword = user.password;

            if (passwordIsEncrypted)
            {
                if (!password.Equals(storedPassword))
                {
                    throw new IncorrectPasswordException(login);
                }
            }
            else
            {
                if (!PasswordEncrypter.IsClearPasswordCorrect(password,
                        storedPassword))
                {
                    throw new IncorrectPasswordException(login);
                }
            }

            return new LoginUser(user.userId, user.name, user.surnames,
                user.postalAddress, user.email);
        }
    }
}
