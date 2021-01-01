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
    
    public partial class User
    {
        public User()
        {
            this.Comment = new HashSet<Comment>();
            this.CreditCard = new HashSet<CreditCard>();
            this.Order = new HashSet<Order>();
        }
    
        public long userId { get; set; }
        public string login { get; set; }
        public string password { get; set; }
        public string name { get; set; }
        public string surnames { get; set; }
        public string postalAddress { get; set; }
        public string email { get; set; }
        public string language { get; set; }
        public string country { get; set; }
        public long roleId { get; set; }
    
        
        /// <summary>
        /// Relationship Name (Foreign Key in ER-Model): FK_CommentUserId
        /// </summary>
        public virtual ICollection<Comment> Comment { get; set; }
        
        /// <summary>
        /// Relationship Name (Foreign Key in ER-Model): FK_CreditCardUserId
        /// </summary>
        public virtual ICollection<CreditCard> CreditCard { get; set; }
        
        /// <summary>
        /// Relationship Name (Foreign Key in ER-Model): FK_OrderUserId
        /// </summary>
        public virtual ICollection<Order> Order { get; set; }
        
        /// <summary>
        /// Relationship Name (Foreign Key in ER-Model): FK_UserRoleId
        /// </summary>
        public virtual Role Role { get; set; }
    
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
    
    			hash = hash * multiplier + (login == null ? 0 : login.GetHashCode());
    			hash = hash * multiplier + (password == null ? 0 : password.GetHashCode());
    			hash = hash * multiplier + (name == null ? 0 : name.GetHashCode());
    			hash = hash * multiplier + (surnames == null ? 0 : surnames.GetHashCode());
    			hash = hash * multiplier + (postalAddress == null ? 0 : postalAddress.GetHashCode());
    			hash = hash * multiplier + (email == null ? 0 : email.GetHashCode());
    			hash = hash * multiplier + (language == null ? 0 : language.GetHashCode());
    			hash = hash * multiplier + (country == null ? 0 : country.GetHashCode());
    			hash = hash * multiplier + roleId.GetHashCode();
    
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
    	    
            User target = obj as User;
    
    		return true
               &&  (this.userId == target.userId )       
               &&  (this.login == target.login )       
               &&  (this.password == target.password )       
               &&  (this.name == target.name )       
               &&  (this.surnames == target.surnames )       
               &&  (this.postalAddress == target.postalAddress )       
               &&  (this.email == target.email )       
               &&  (this.language == target.language )       
               &&  (this.country == target.country )       
               &&  (this.roleId == target.roleId )       
               ;
    
        }
    
    
    	public static bool operator ==(User  objA, User  objB)
        {
            // Check if the objets are the same User entity
            if(Object.ReferenceEquals(objA, objB))
                return true;
      
            return objA.Equals(objB);
    }
    
    
    	public static bool operator !=(User  objA, User  objB)
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
    	    StringBuilder strUser = new StringBuilder();
    
    		strUser.Append("[ ");
           strUser.Append(" userId = " + userId + " | " );       
           strUser.Append(" login = " + login + " | " );       
           strUser.Append(" password = " + password + " | " );       
           strUser.Append(" name = " + name + " | " );       
           strUser.Append(" surnames = " + surnames + " | " );       
           strUser.Append(" postalAddress = " + postalAddress + " | " );       
           strUser.Append(" email = " + email + " | " );       
           strUser.Append(" language = " + language + " | " );       
           strUser.Append(" country = " + country + " | " );       
           strUser.Append(" roleId = " + roleId + " | " );       
            strUser.Append("] ");    
    
    		return strUser.ToString();
        }
    
    
    }
}
