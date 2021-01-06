using System;

namespace Es.Udc.DotNet.PracticaMaD.Model.ECommerceServices.UserService
{
    [Serializable()]
    public class UserRegisterDetailsDto
    {
        public UserRegisterDetailsDto(string name, string surnames,
            string email, string postalAddress, string language, string country)
        {
            this.name = name;
            this.surnames = surnames;
            this.email = email;
            this.postalAddress = postalAddress;
            this.language = language;
            this.country = country;
        }

        public string name { get; private set; }
        public string surnames { get; private set; }
        public string email { get; private set; }
        public string postalAddress { get; private set; }
        public string language { get; private set; }
        public string country { get; private set; }

        public override bool Equals(object obj)
        {

            UserRegisterDetailsDto target = (UserRegisterDetailsDto)obj;

            return (this.name == target.name)
                  && (this.surnames == target.surnames)
                  && (this.email == target.email)
                  && (this.postalAddress == target.postalAddress)
                  && (this.language == target.language)
                  && (this.country == target.country);
        }

        // The GetHashCode method is used in hashing algorithms and data 
        // structures such as a hash table. In order to ensure that it works 
        // properly, we suppose that the FirstName does not change.        
        public override int GetHashCode()
        {
            return this.name.GetHashCode();
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
            String strUserProfileDetails;

            strUserProfileDetails =
                "[ name = " + name + " | " +
                "surnames = " + surnames + " | " +
                "email = " + email + " | " +
                "postalAddress = " + postalAddress + " | " +
                "language = " + language + " | " +
                "country = " + country + " ]";


            return strUserProfileDetails;
        }
    }
}
