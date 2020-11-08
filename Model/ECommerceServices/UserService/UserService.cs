using Es.Udc.DotNet.ModelUtil.Exceptions;
using Es.Udc.DotNet.ModelUtil.Transactions;
using Es.Udc.DotNet.PracticaMaD.Model.Model1Daos.CreditCardDao;
using Es.Udc.DotNet.PracticaMaD.Model.Model1Daos.UserDao;
using Es.Udc.DotNet.PracticaMaD.Model.Services.Exceptions;
using Es.Udc.DotNet.PracticaMaD.Model.Services.Util;
using Ninject;
using System.Collections.Generic;

namespace Es.Udc.DotNet.PracticaMaD.Model.Services.UserService
{
    public class UserService : IUserService
    {
        public UserService()
        {

        }

        [Inject]
        public IUserDao UserDao { set; get; }

        [Inject]
        public ICreditCardDao CreditCardDao { set; get; }

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

        /// <exception cref="DuplicateInstanceException"/>
        [Transactional]
        public long CreateCreditCard(CreditCard creditCard)
        {
            List<CreditCard> creditCards = CreditCardDao.FindAllByUserId(creditCard.userId);

            if (creditCards.Contains(creditCard))
            {
                throw new DuplicateInstanceException(creditCard, "CreditCard");
            }

            CreditCardDao.Create(creditCard);

            return creditCard.creditCardId;
        }

        /// <exception cref="InstanceNotFoundException"/>
        [Transactional]
        public void UpdateCreditCard(CreditCard creditCard)
        {
            CreditCard creditCardFound = CreditCardDao.Find(creditCard.creditCardId);

            if (creditCardFound.Equals(null))
            {
                throw new InstanceNotFoundException(creditCard, "CreditCard");
            }

            CreditCardDao.Update(creditCard);
        }

        /// <exception cref="InstanceNotFoundException"/>
        [Transactional]
        public List<CreditCard> FindCreditCardsByUserId(long userId, int startPage)
        {
            User userFound = UserDao.Find(userId);

            if (userFound.Equals(null))
            {
                throw new InstanceNotFoundException(userId, "User");
            }

            return CreditCardDao.FindByUserId(userId, startPage, 10);
        }

        /// <exception cref="InstanceNotFoundException"/>
        [Transactional]
        public CreditCard FindFavCreditCardByUserId(long userId)
        {
            User userFound = UserDao.Find(userId);

            if (userFound.Equals(null))
            {
                throw new InstanceNotFoundException(userId, "User");
            }

            return CreditCardDao.FindFavByUserId(userId);
        }

        /// <exception cref="InstanceNotFoundException"/>
        [Transactional]
        public void DeleteCreditCard(long creditCardId)
        {
            CreditCard creditCardFound = CreditCardDao.Find(creditCardId);

            if (creditCardFound.Equals(null))
            {
                throw new InstanceNotFoundException(creditCardId, "CreditCard");
            }

            CreditCardDao.Remove(creditCardId);
        }
    }
}
