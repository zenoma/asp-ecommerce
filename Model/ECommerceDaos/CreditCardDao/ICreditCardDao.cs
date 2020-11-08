using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Es.Udc.DotNet.PracticaMaD.Model.Model1Daos.CreditCardDao
{
    public interface ICreditCardDao : ModelUtil.Dao.IGenericDao<CreditCard, Int64>
    {
        List<CreditCard> FindAllByUserId(long userId);
        List<CreditCard> FindByUserId(long userId, int startIndex, int count);
        CreditCard FindFavByUserId(long userId);
    }
}
