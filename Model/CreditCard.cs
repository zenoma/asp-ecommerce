//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Es.Udc.DotNet.PracticaMaD.Model
{
    using System;
    using System.Text;
    using System.Collections.Generic;
    
    public partial class CreditCard
    {
        public CreditCard()
        {
            this.Order = new HashSet<Order>();
        }
    
        public long creditCardId { get; set; }
        public long userId { get; set; }
        public string type { get; set; }
        public long number { get; set; }
        public short verifyCode { get; set; }
        public System.DateTime expDate { get; set; }
        public bool isFav { get; set; }
    
        
        /// <summary>
        /// Relationship Name (Foreign Key in ER-Model): FK_CreditCardUserId
        /// </summary>
        public virtual User User { get; set; }
        
        /// <summary>
        /// Relationship Name (Foreign Key in ER-Model): FK_OrderCreditCardId
        /// </summary>
        public virtual ICollection<Order> Order { get; set; }
    
    	/// <summary>
    	/// A hash code for this instance, suitable for use in hashing algorithms and data structures 
    	/// like a hash table. It uses the Josh Bloch implementation from "Effective Java"
        /// Primary key of entity is not included in the hash calculation to avoid errors
    	/// with Entity Framework creation of key values.
    	/// </summary>
    	/// <returns>
    	/// Returns a hash code for this instance.
    	/// </returns>
    	public override int GetHashCode()
    	{
    	    unchecked
    	    {
    			int multiplier = 31;
    			int hash = GetType().GetHashCode();
    
    			hash = hash * multiplier + userId.GetHashCode();
    			hash = hash * multiplier + (type == null ? 0 : type.GetHashCode());
    			hash = hash * multiplier + number.GetHashCode();
    			hash = hash * multiplier + verifyCode.GetHashCode();
    			hash = hash * multiplier + expDate.GetHashCode();
    			hash = hash * multiplier + isFav.GetHashCode();
    
    			return hash;
    	    }
    
    	}
        
        /// <summary>
        /// Compare this object against another instance using a value approach (field-by-field) 
        /// </summary>
        /// <remarks>See http://www.loganfranken.com/blog/687/overriding-equals-in-c-part-1/ for detailed info </remarks>
    	public override bool Equals(object obj)
    	{
    
            if (ReferenceEquals(null, obj)) return false;        // Is Null?
            if (ReferenceEquals(this, obj)) return true;         // Is same object?
            if (obj.GetType() != this.GetType()) return false;   // Is same type?
    	    
            CreditCard target = obj as CreditCard;
    
    		return true
               &&  (this.creditCardId == target.creditCardId )       
               &&  (this.userId == target.userId )       
               &&  (this.type == target.type )       
               &&  (this.number == target.number )       
               &&  (this.verifyCode == target.verifyCode )       
               &&  (this.expDate == target.expDate )       
               &&  (this.isFav == target.isFav )       
               ;
    
        }
    
    
    	public static bool operator ==(CreditCard  objA, CreditCard  objB)
        {
            // Check if the objets are the same CreditCard entity
            if(Object.ReferenceEquals(objA, objB))
                return true;
      
            return objA.Equals(objB);
    }
    
    
    	public static bool operator !=(CreditCard  objA, CreditCard  objB)
        {
            return !(objA == objB);
        }
    
    
        /// <summary>
        /// Returns a <see cref="T:System.String"></see> that represents the 
        /// current <see cref="T:System.Object"></see>.
        /// </summary>
        /// <returns>
        /// A <see cref="T:System.String"></see> that represents the current 
        /// <see cref="T:System.Object"></see>.
        /// </returns>
    	public override String ToString()
    	{
    	    StringBuilder strCreditCard = new StringBuilder();
    
    		strCreditCard.Append("[ ");
           strCreditCard.Append(" creditCardId = " + creditCardId + " | " );       
           strCreditCard.Append(" userId = " + userId + " | " );       
           strCreditCard.Append(" type = " + type + " | " );       
           strCreditCard.Append(" number = " + number + " | " );       
           strCreditCard.Append(" verifyCode = " + verifyCode + " | " );       
           strCreditCard.Append(" expDate = " + expDate + " | " );       
           strCreditCard.Append(" isFav = " + isFav + " | " );       
            strCreditCard.Append("] ");    
    
    		return strCreditCard.ToString();
        }
    
    
    }
}
