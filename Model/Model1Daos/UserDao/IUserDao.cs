using Es.Udc.DotNet.ModelUtil.Dao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Es.Udc.DotNet.PracticaMaD.Model.Model1Daos.UserDao
{
    interface IUserDao : IGenericDao<User, Int64>
    {
        User FindByLogin(String login);
    }
}
