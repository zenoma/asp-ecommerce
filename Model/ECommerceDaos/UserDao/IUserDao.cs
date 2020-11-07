using Es.Udc.DotNet.ModelUtil.Dao;
using System;

namespace Es.Udc.DotNet.PracticaMaD.Model.Model1Daos.UserDao
{
    public interface IUserDao : IGenericDao<User, Int64>
    {
        /// <exception cref="InstanceNotFoundException"/>
        User FindByLogin(String login);
    }
}
