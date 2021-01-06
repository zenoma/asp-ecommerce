using Es.Udc.DotNet.ModelUtil.Dao;
using Es.Udc.DotNet.ModelUtil.Exceptions;
using System;
using System.Linq;

namespace Es.Udc.DotNet.PracticaMaD.Model.ECommerceDaos.RoleDao
{
    public class RoleDaoEntityFramework : GenericDaoEntityFramework<Role, Int64>, IRoleDao
    {
        public Role FindByName(String name)
        {
            Role role = null;
            using (var context = new ecommerceEntities())
            {
                var query = from r in context.Role
                            where r.name.Contains(name)
                            orderby r.roleId
                            select r;

                role = query.FirstOrDefault();

                if (role == null)
                    throw new InstanceNotFoundException(name,
                        typeof(Role).FullName);

                return role;
            }
        }
    }
}
