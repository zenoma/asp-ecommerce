using Es.Udc.DotNet.ModelUtil.Dao;
using System;

namespace Es.Udc.DotNet.PracticaMaD.Model.ECommerceDaos.RoleDao
{
    public interface IRoleDao : IGenericDao<Role, Int64>
    {
        Role FindByName(String name);
    }
}
