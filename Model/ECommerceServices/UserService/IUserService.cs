using Es.Udc.DotNet.PracticaMaD.Model.Model1Daos.UserDao;
using Es.Udc.DotNet.ModelUtil.Transactions;
using Ninject;
using Es.Udc.DotNet.PracticaMaD.Model.Model1Daos.CreditCardDao;
using System.Collections.Generic;
using Es.Udc.DotNet.PracticaMaD.Model.ECommerceServices.UserService;
using Es.Udc.DotNet.PracticaMaD.Model.ECommerceDaos.RoleDao;

namespace Es.Udc.DotNet.PracticaMaD.Model.Services.UserService
{
    public interface IUserService
    {
        [Inject]
        IUserDao UserDao { set; }

        [Inject]
        IRoleDao RoleDao { set; get; }

        [Inject]
        ICreditCardDao CreditCardDao { set; }

        /// <exception cref="DuplicateInstanceException"/>
        [Transactional]
        long SignUp(string login, string password, UserRegisterDetailsDto userDetails);

        /// <exception cref="InstanceNotFoundException"/>
        /// <exception cref="IncorrectPasswordException"/>
        [Transactional]
        LoginUser Login(string login, string password, bool passwordIsEncrypted);

        /// <exception cref="InstanceNotFoundException"/>
        [Transactional]
        UserRegisterDetailsDto FindUserDetails(long userId);

        /// <exception cref="InstanceNotFoundException"/>
        [Transactional]
        void UpdateUserDetails(long userId, UserRegisterDetailsDto userDetails);

        /// <exception cref="InstanceNotFoundException"/>
        [Transactional]
        void ChangePassword(long userId, string oldPassword, string newPassword);

        /// <exception cref="DuplicateInstanceException"/>
        [Transactional]
        long CreateCreditCard(CreditCardDto creditCard, long userId);

        /// <exception cref="InstanceNotFoundException"/>
        /// <exception cref="ForbiddenException"/>
        [Transactional]
        void UpdateCreditCard(CreditCardDto creditCard, long userId);

        /// <exception cref="InstanceNotFoundException"/>
        [Transactional]
        List<CreditCardDto> FindCreditCardsByUserId(long userId);

        /// <exception cref="InstanceNotFoundException"/>
        [Transactional]
        CreditCardDto FindFavCreditCardByUserId(long userId);

        /// <exception cref="InstanceNotFoundException"/>
        [Transactional]
        CreditCardDto FindCreditCardById(long creditCardId);

        /// <exception cref="InstanceNotFoundException"/>
        /// <exception cref="ForbiddenException"/>
        [Transactional]
        void DeleteCreditCard(long creditCardId, long userId);
    }
}
