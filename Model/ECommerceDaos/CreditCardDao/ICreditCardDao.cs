using System;
using System.Collections.Generic;

namespace Es.Udc.DotNet.PracticaMaD.Model.Model1Daos.CreditCardDao
{
    public interface ICreditCardDao : ModelUtil.Dao.IGenericDao<CreditCard, Int64>
    {
        List<CreditCard> FindAllByUserId(long userId);
        CreditCard FindFavByUserId(long userId);
    }
}
