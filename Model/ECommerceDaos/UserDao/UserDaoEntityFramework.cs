using Es.Udc.DotNet.ModelUtil.Dao;
using Es.Udc.DotNet.ModelUtil.Exceptions;
using System;
using System.Linq;

namespace Es.Udc.DotNet.PracticaMaD.Model.Model1Daos.UserDao
{
    public class UserDaoEntityFramework :
        GenericDaoEntityFramework<User, Int64>, IUserDao
    {
        /// <exception cref="InstanceNotFoundException"/>
        public User FindByLogin(string login)
        {
            using (var context = new ecommerceEntities())
            {
                User user = null;
                var query = from u in context.User
                            where u.login == login
                            select u;

                user = query.FirstOrDefault();

                if (user == null)
                    throw new InstanceNotFoundException(login,
                        typeof(User).FullName);

                return user;
            }
        }
    }
}
