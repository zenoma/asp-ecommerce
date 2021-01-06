using System;
using System.Text;

namespace Es.Udc.DotNet.PracticaMaD.Model.ECommerceServices.UserService
{
    public class CreditCardDto
    {
        public CreditCardDto(long creditCardId, string type, long number, short verifyCode, System.DateTime expDate, bool isFav)
        {
            this.creditCardId = creditCardId;
            this.type = type;
            this.number = number;
            this.verifyCode = verifyCode;
            this.expDate = expDate;
            this.isFav = isFav;
        }

        public long creditCardId { get; set; }
        public string type { get; set; }
        public long number { get; set; }
        public short verifyCode { get; set; }
        public System.DateTime expDate { get; set; }
        public bool isFav { get; set; }

        public override int GetHashCode()
        {
            unchecked
            {
                int multiplier = 31;
                int hash = GetType().GetHashCode();

                hash = hash * multiplier + (type == null ? 0 : type.GetHashCode());
                hash = hash * multiplier + number.GetHashCode();
                hash = hash * multiplier + verifyCode.GetHashCode();
                hash = hash * multiplier + expDate.GetHashCode();
                hash = hash * multiplier + isFav.GetHashCode();

                return hash;
            }

        }

        public override bool Equals(object obj)
        {

            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;

            CreditCard target = obj as CreditCard;

            return true
               && (this.type == target.type)
               && (this.number == target.number)
               && (this.verifyCode == target.verifyCode)
               && (this.expDate == target.expDate)
               && (this.isFav == target.isFav)
               ;

        }

        public override String ToString()
        {
            StringBuilder strCreditCard = new StringBuilder();

            strCreditCard.Append("[ ");
            strCreditCard.Append(" creditCardId = " + creditCardId + " | ");
            strCreditCard.Append(" type = " + type + " | ");
            strCreditCard.Append(" number = " + number + " | ");
            strCreditCard.Append(" verifyCode = " + verifyCode + " | ");
            strCreditCard.Append(" expDate = " + expDate + " | ");
            strCreditCard.Append(" isFav = " + isFav + " | ");
            strCreditCard.Append("] ");

            return strCreditCard.ToString();
        }
    }
}
