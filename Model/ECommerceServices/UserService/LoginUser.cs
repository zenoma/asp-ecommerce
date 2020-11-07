using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Es.Udc.DotNet.PracticaMaD.Model.Services.UserService
{
    [Serializable()]
    public class LoginUser
    {
        public LoginUser(long userId, string name, string surnames,
            string postalAddress, string email)
        {
            this.userId = userId;
            this.name = name;
            this.surnames = surnames;
            this.postalAddress = postalAddress;
            this.email = email;
        }

        public long userId { get; set; }
        public string name { get; set; }
        public string surnames { get; set; }
        public string postalAddress { get; set; }
        public string email { get; set; }

        public override int GetHashCode()
        {
            unchecked
            {
                int multiplier = 31;
                int hash = GetType().GetHashCode();

                hash = hash * multiplier + (name == null ? 0 : name.GetHashCode());
                hash = hash * multiplier + (surnames == null ? 0 : surnames.GetHashCode());
                hash = hash * multiplier + (postalAddress == null ? 0 : postalAddress.GetHashCode());
                hash = hash * multiplier + (email == null ? 0 : email.GetHashCode());

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
               && (this.userId == target.userId)
               && (this.name == target.name)
               && (this.surnames == target.surnames)
               && (this.postalAddress == target.postalAddress)
               && (this.email == target.email)
               ;

        }

        public override String ToString()
        {
            StringBuilder strUser = new StringBuilder();

            strUser.Append("[ ");
            strUser.Append(" userId = " + userId + " | ");
            strUser.Append(" name = " + name + " | ");
            strUser.Append(" surnames = " + surnames + " | ");
            strUser.Append(" postalAddress = " + postalAddress + " | ");
            strUser.Append(" email = " + email + " | ");
            strUser.Append("] ");

            return strUser.ToString();
        }
    }
}
