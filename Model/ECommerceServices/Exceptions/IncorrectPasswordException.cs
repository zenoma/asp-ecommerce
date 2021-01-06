using System;

namespace Es.Udc.DotNet.PracticaMaD.Model.Services.Exceptions
{
    [Serializable]
    public class IncorrectPasswordException : Exception
    {
        public String Login { get; private set; }

        public IncorrectPasswordException(String login)
            : base("Incorrect password exception => login = " + login)
        {
            this.Login = login;
        }
    }
}
