using Es.Udc.DotNet.ModelUtil.Dao;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Es.Udc.DotNet.PracticaMaD.Model.Model1Daos.CreditCardDao
{
    public class CreditCardDaoEntityFramework :
        GenericDaoEntityFramework<CreditCard, Int64>, ICreditCardDao
    {
        public List<CreditCard> FindAllByUserId(long userId)
        {
            using (var context = new ecommerceEntities())
            {
                List<CreditCard> result = (from c in context.CreditCard
                                           where c.userId == userId
                                           orderby c.creditCardId
                                           select c).ToList();

                return result;
            }
        }

        public CreditCard FindFavByUserId(long userId)
        {
            using (var context = new ecommerceEntities())
            {
                var result = (from c in context.CreditCard
                              where c.userId == userId && c.isFav
                              select c).FirstOrDefault();

                return result;
            }
        }
    }
}
