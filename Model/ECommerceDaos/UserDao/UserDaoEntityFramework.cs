using Es.Udc.DotNet.ModelUtil.Dao;
using Es.Udc.DotNet.ModelUtil.Exceptions;
using System;
using System.Data.Entity;
using System.Linq;

namespace Es.Udc.DotNet.PracticaMaD.Model.Model1Daos.UserDao
{
    public class UserDaoEntityFramework :
        GenericDaoEntityFramework<User, Int64>, IUserDao
    {
        /// <exception cref="InstanceNotFoundException"/>
        public User FindByLogin(string login)
        {
            User user = null;
            DbSet<User> users = Context.Set<User>();

            var result =
                (from u in users
                 where u.login == login
                 select u);

            user = result.FirstOrDefault();

            if (user == null)
                throw new InstanceNotFoundException(login,
                    typeof(User).FullName);

            return user;
        }
    }
}
