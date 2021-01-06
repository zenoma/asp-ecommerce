using System;

namespace Es.Udc.DotNet.PracticaMaD.Model.ECommerceServices.Exceptions
{
    [Serializable]
    public class EmptyOrderItemListException : Exception
    {
        public string login { get; private set; }

        public EmptyOrderItemListException(string login)
            : base("Empty Order Item List Exception => login = " + login)
        {
            this.login = login;
        }
    }
}
