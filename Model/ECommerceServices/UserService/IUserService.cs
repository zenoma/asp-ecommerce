using Es.Udc.DotNet.PracticaMaD.Model.Model1Daos.UserDao;
using Es.Udc.DotNet.ModelUtil.Transactions;
using Ninject;

namespace Es.Udc.DotNet.PracticaMaD.Model.Services.UserService
{
    public interface IUserService
    {
        [Inject]
        IUserDao UserDao { set; }

        /// <exception cref="DuplicateInstanceException"/>
        [Transactional]
        long SignUp(User user);

        /// <exception cref="InstanceNotFoundException"/>
        /// <exception cref="IncorrectPasswordException"/>
        [Transactional]
        LoginUser Login(string login, string password, bool passwordIsEncrypted);

    }
}
