using Es.Udc.DotNet.ModelUtil.Dao;
using System;

namespace Es.Udc.DotNet.PracticaMaD.Model.Model1Daos.UserDao
{
    interface IUserDao : IGenericDao<User, Int64>
    {
        User FindByLogin(String login);
    }
}
