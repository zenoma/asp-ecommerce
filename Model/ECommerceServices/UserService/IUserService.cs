using Es.Udc.DotNet.PracticaMaD.Model.Model1Daos.UserDao;
using Es.Udc.DotNet.ModelUtil.Transactions;
using Ninject;
using Es.Udc.DotNet.PracticaMaD.Model.Model1Daos.CreditCardDao;
using System.Collections.Generic;

namespace Es.Udc.DotNet.PracticaMaD.Model.Services.UserService
{
    public interface IUserService
    {
        [Inject]
        IUserDao UserDao { set; }
        [Inject]
        ICreditCardDao CreditCardDao { set; }

        /// <exception cref="DuplicateInstanceException"/>
        [Transactional]
        long SignUp(User user);

        /// <exception cref="InstanceNotFoundException"/>
        /// <exception cref="IncorrectPasswordException"/>
        [Transactional]
        LoginUser Login(string login, string password, bool passwordIsEncrypted);

        /// <exception cref="DuplicateInstanceException"/>
        [Transactional]
        long CreateCreditCard(CreditCard creditCard, long userId);

        /// <exception cref="InstanceNotFoundException"/>
        /// <exception cref="ForbiddenException"/>
        [Transactional]
        void UpdateCreditCard(CreditCard creditCard, long userId);

        /// <exception cref="InstanceNotFoundException"/>
        [Transactional]
        List<CreditCard> FindCreditCardsByUserId(long userId);

        /// <exception cref="InstanceNotFoundException"/>
        [Transactional]
        CreditCard FindFavCreditCardByUserId(long userId);

        /// <exception cref="InstanceNotFoundException"/>
        /// <exception cref="ForbiddenException"/>
        [Transactional]
        void DeleteCreditCard(long creditCardId, long userId);
    }
}
