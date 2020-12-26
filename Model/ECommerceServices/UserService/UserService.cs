using Es.Udc.DotNet.ModelUtil.Exceptions;
using Es.Udc.DotNet.ModelUtil.Transactions;
using Es.Udc.DotNet.PracticaMaD.Model.ECommerceServices.Exceptions;
using Es.Udc.DotNet.PracticaMaD.Model.ECommerceServices.UserService;
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
        public long SignUp(string login, string password, UserRegisterDetailsDto userDetails)
        {
            try
            {
                User alreadyExists = UserDao.FindByLogin(login);

                throw new DuplicateInstanceException(alreadyExists, "User");
            }
            catch (InstanceNotFoundException)
            {
                User user = new User();
                user.login = login;
                user.password = PasswordEncrypter.Crypt(password);
                user.name = userDetails.name;
                user.surnames = userDetails.surnames;
                user.email = userDetails.email;
                user.postalAddress = userDetails.postalAddress;
                user.language = userDetails.language;
                user.country = userDetails.country;

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

            return new LoginUser(user.userId, user.password, user.name, user.language,
                user.country);
        }

        /// <exception cref="InstanceNotFoundException"/>
        [Transactional]
        public UserRegisterDetailsDto FindUserDetails(long userId)
        {
            User user = UserDao.Find(userId);

            return new UserRegisterDetailsDto(user.name, user.surnames, user.email, 
                user.postalAddress, user.language, user.country);
        }

        /// <exception cref="InstanceNotFoundException"/>
        [Transactional]
        public void UpdateUserDetails(long userId, UserRegisterDetailsDto userDetails)
        {
            User user = UserDao.Find(userId);

            user.name = userDetails.name;
            user.surnames = userDetails.surnames;
            user.email = userDetails.email;
            user.postalAddress = userDetails.postalAddress;
            user.language = userDetails.language;
            user.country = userDetails.country;

            UserDao.Update(user);
        }

        /// <exception cref="InstanceNotFoundException"/>
        /// <exception cref="IncorrectPasswordException"/>
        [Transactional]
        public void ChangePassword(long userId, string oldPassword, string newPassword)
        {
            User user = UserDao.Find(userId);

            if (!PasswordEncrypter.IsClearPasswordCorrect(oldPassword,
                 user.password))
            {
                throw new IncorrectPasswordException(user.login);
            }

            user.password = PasswordEncrypter.Crypt(newPassword);

            UserDao.Update(user);
        }

        /// <exception cref="DuplicateInstanceException"/>
        /// <exception cref="InstanceNotFoundException"/>
        [Transactional]
        public long CreateCreditCard(CreditCardDto creditCard, long userId)
        {
            User user = UserDao.Find(userId);
            CreditCard creditCardModel = new CreditCard();

            creditCardModel.type = creditCard.type;
            creditCardModel.number = creditCard.number;
            creditCardModel.verifyCode = creditCard.verifyCode;
            creditCardModel.expDate = creditCard.expDate;
            creditCardModel.isFav = creditCard.isFav;

            if (user.Equals(null))
            {
                throw new InstanceNotFoundException(userId, "User");
            }

            creditCardModel.userId = userId;

            List<CreditCard> creditCards = CreditCardDao.FindAllByUserId(userId);

            if (creditCards.Contains(creditCardModel))
            {
                throw new DuplicateInstanceException(creditCard, "CreditCard");
            }

            CreditCardDao.Create(creditCardModel);

            return creditCardModel.creditCardId;
        }

        /// <exception cref="InstanceNotFoundException"/>
        /// <exception cref="ForbiddenException"/>
        [Transactional]
        public void UpdateCreditCard(CreditCardDto creditCard, long userId)
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

            creditCardFound.type = creditCard.type;
            creditCardFound.number = creditCard.number;
            creditCardFound.verifyCode = creditCard.verifyCode;
            creditCardFound.expDate = creditCard.expDate;
            creditCardFound.isFav = creditCard.isFav;
            creditCardFound.userId = userId;

            CreditCardDao.Update(creditCardFound);
        }

        /// <exception cref="InstanceNotFoundException"/>
        [Transactional]
        public List<CreditCardDto> FindCreditCardsByUserId(long userId)
        {
            User userFound = UserDao.Find(userId);

            if (userFound.Equals(null))
            {
                throw new InstanceNotFoundException(userId, "User");
            }

            List<CreditCard> listCreditCards = CreditCardDao.FindAllByUserId(userId);
            List<CreditCardDto> listCreditCardsDto = new List<CreditCardDto>();

            foreach (var creditCard in listCreditCards)
            {
                listCreditCardsDto.Add(new CreditCardDto(creditCard.creditCardId, creditCard.type, 
                    creditCard.number, creditCard.verifyCode, creditCard.expDate, creditCard.isFav));
            }

            return listCreditCardsDto;
        }

        /// <exception cref="InstanceNotFoundException"/>
        [Transactional]
        public CreditCardDto FindCreditCardById(long creditCardId)
        {
            CreditCard creditCard = CreditCardDao.Find(creditCardId);

            if (creditCard.Equals(null))
            {
                throw new InstanceNotFoundException(creditCardId, "Credit Card");
            }

            return new CreditCardDto(creditCard.creditCardId, creditCard.type, creditCard.number, 
                creditCard.verifyCode, creditCard.expDate, creditCard.isFav);
        }

        /// <exception cref="InstanceNotFoundException"/>
        [Transactional]
        public CreditCardDto FindFavCreditCardByUserId(long userId)
        {
            User userFound = UserDao.Find(userId);

            if (userFound.Equals(null))
            {
                throw new InstanceNotFoundException(userId, "User");
            }

            CreditCard creditCard = CreditCardDao.FindFavByUserId(userId);

            return new CreditCardDto(creditCard.creditCardId, creditCard.type, creditCard.number,
                creditCard.verifyCode, creditCard.expDate, creditCard.isFav);
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
