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
        public List<CreditCard> FindByUserId(long userId, int startIndex, int count)
        {
            DbSet<CreditCard> creditCards = Context.Set<CreditCard>();

            List<CreditCard> result = (from c in creditCards
                                       where c.userId == userId
                                       orderby c.creditCardId
                                       select c).Skip(startIndex).Take(count).ToList();

            return result;
        }

        public CreditCard FindFavByUserId(long userId)
        {
            DbSet<CreditCard> creditCards = Context.Set<CreditCard>();

            CreditCard result = (from c in creditCards
                                 where c.userId == userId && c.isFav
                                 select c).Single();

            return result;
        }

        public CreditCard FindByUserIdAndNumber(long userId, Int64 number)
        {
            DbSet<CreditCard> creditCards = Context.Set<CreditCard>();

            CreditCard result = (from c in creditCards
                                 where c.userId == userId && c.number == number
                                 select c).Single();

            return result;
        }
    }
}
