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
    
    public partial class Book : Product
    {
        public string isbn { get; set; }
        public int editionNumber { get; set; }
        public string author { get; set; }
    
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
    
    			hash = hash * multiplier + (isbn == null ? 0 : isbn.GetHashCode());
    			hash = hash * multiplier + editionNumber.GetHashCode();
    			hash = hash * multiplier + (author == null ? 0 : author.GetHashCode());
    
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
    
            Book target = obj as Book;
    
    		return true
               &&  (this.isbn == target.isbn )       
               &&  (this.editionNumber == target.editionNumber )       
               &&  (this.author == target.author )       
               ;
    
        }
    
    
    	public static bool operator ==(Book  objA, Book  objB)
        {
            // Check if the objets are the same Book entity
            if(Object.ReferenceEquals(objA, objB))
                return true;
      
            return objA.Equals(objB);
    }
    
    
    	public static bool operator !=(Book  objA, Book  objB)
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
    	    StringBuilder strBook = new StringBuilder();
    
    		strBook.Append("[ ");
           strBook.Append(" isbn = " + isbn + " | " );       
           strBook.Append(" editionNumber = " + editionNumber + " | " );       
           strBook.Append(" author = " + author + " | " );       
            strBook.Append("] ");    
    
    		return strBook.ToString();
        }
    
    
    }
}
