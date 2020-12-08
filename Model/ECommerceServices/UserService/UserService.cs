using Es.Udc.DotNet.ModelUtil.Exceptions;
using Es.Udc.DotNet.ModelUtil.Transactions;
using Es.Udc.DotNet.PracticaMaD.Model.ECommerceServices.Exceptions;
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
        /// <exception cref="InstanceNotFoundException"/>
        [Transactional]
        public long CreateCreditCard(CreditCard creditCard, long userId)
        {
            User user = UserDao.Find(userId);

            if (user.Equals(null))
            {
                throw new InstanceNotFoundException(userId, "User");
            }

            List<CreditCard> creditCards = CreditCardDao.FindAllByUserId(userId);

            if (creditCards.Contains(creditCard))
            {
                throw new DuplicateInstanceException(creditCard, "CreditCard");
            }

            creditCard.userId = userId;

            CreditCardDao.Create(creditCard);

            return creditCard.creditCardId;
        }

        /// <exception cref="InstanceNotFoundException"/>
        /// <exception cref="ForbiddenException"/>
        [Transactional]
        public void UpdateCreditCard(CreditCard creditCard, long userId)
        {
            CreditCard creditCardFound = CreditCardDao.Find(creditCard.creditCardId);

            if (creditCardFound.Equals(null))
            {
                throw new InstanceNotFoundException(creditCard, "CreditCard");
            }

            if (userId != creditCardFound.userId)
            {
                throw new ForbiddenException(userId);
            }

            creditCard.userId = userId;

            CreditCardDao.Update(creditCard);
        }

        /// <exception cref="InstanceNotFoundException"/>
        [Transactional]
        public List<CreditCard> FindCreditCardsByUserId(long userId)
        {
            User userFound = UserDao.Find(userId);

            if (userFound.Equals(null))
            {
                throw new InstanceNotFoundException(userId, "User");
            }

            return CreditCardDao.FindAllByUserId(userId);
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
        /// <exception cref="ForbiddenException"/>
        [Transactional]
        public void DeleteCreditCard(long creditCardId, long userId)
        {
            CreditCard creditCardFound = CreditCardDao.Find(creditCardId);

            if (creditCardFound.Equals(null))
            {
                throw new InstanceNotFoundException(creditCardId, "CreditCard");
            }

            if (userId != creditCardFound.userId)
            {
                throw new ForbiddenException(userId);
            }

            CreditCardDao.Remove(creditCardId);
        }
    }
}
