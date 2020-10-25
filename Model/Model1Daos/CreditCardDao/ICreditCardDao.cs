using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Es.Udc.DotNet.PracticaMaD.Model.Model1Daos.CreditCardDao
{
    interface ICreditCardDao : ModelUtil.Dao.IGenericDao<CreditCard, Int64>
    {
        List<CreditCard> FindByUserId(long userId, int startIndex, int count);

        CreditCard FindFavByUserId(long userId);

        CreditCard FindByUserIdAndNumber(long userId, Int64 number);
    }
}
