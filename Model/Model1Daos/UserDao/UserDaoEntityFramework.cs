using Es.Udc.DotNet.ModelUtil.Dao;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Es.Udc.DotNet.PracticaMaD.Model.Model1Daos.UserDao
{
    class UserDaoEntityFramework :
        GenericDaoEntityFramework<User, Int64>, IUserDao
    {

        public User FindByLogin(string login)
        {
            DbSet<User> users = Context.Set<User>();

            var result =
                (from u in users
                 where u.login.Equals(login)
                 select u);

            return result.Single();
        }
    }
}
