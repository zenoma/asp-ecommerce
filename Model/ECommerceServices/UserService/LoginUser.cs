using System;
using System.Text;

namespace Es.Udc.DotNet.PracticaMaD.Model.Services.UserService
{
    [Serializable()]
    public class LoginUser
    {
        public LoginUser(long userId, string role, string encryptedPassword, string name, string language,
            string country)
        {
            this.userId = userId;
            this.role = role;
            this.encryptedPassword = encryptedPassword;
            this.name = name;
            this.language = language;
            this.country = country;
        }

        public long userId { get; set; }
        public string role { get; set; }
        public string encryptedPassword { get; set; }
        public string name { get; set; }
        public string language { get; set; }
        public string country { get; set; }

        public override int GetHashCode()
        {
            unchecked
            {
                int multiplier = 31;
                int hash = GetType().GetHashCode();

                hash = hash * multiplier + (role == null ? 0 : role.GetHashCode());
                hash = hash * multiplier + (encryptedPassword == null ? 0 : encryptedPassword.GetHashCode());
                hash = hash * multiplier + (name == null ? 0 : name.GetHashCode());
                hash = hash * multiplier + (language == null ? 0 : language.GetHashCode());
                hash = hash * multiplier + (country == null ? 0 : country.GetHashCode());

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

            LoginUser target = obj as LoginUser;

            return true
               && (this.role == target.role)
               && (this.encryptedPassword == target.encryptedPassword)
               && (this.name == target.name)
               && (this.language == target.language)
               && (this.country == target.country)
               ;

        }

        public override String ToString()
        {
            StringBuilder strUser = new StringBuilder();

            strUser.Append("[ ");
            strUser.Append(" userId = " + userId + " | ");
            strUser.Append(" role = " + role + " | ");
            strUser.Append(" encryptedPassword = " + encryptedPassword + " | ");
            strUser.Append(" name = " + name + " | ");
            strUser.Append(" language = " + language + " | ");
            strUser.Append(" country = " + country + " | ");
            strUser.Append("] ");

            return strUser.ToString();
        }
    }
}
