using Es.Udc.DotNet.ModelUtil.Dao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Es.Udc.DotNet.PracticaMaD.Model.Model1Daos.OrderDao
{
    public interface IOrderDao : IGenericDao<Order, Int64>
    {
        List<Order> findByUserId(long userId, int startIndex, int count);
    }
}
