using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Es.Udc.DotNet.PracticaMaD.Model.ECommerceServices.Exceptions
{
    [Serializable]
    public class ForbiddenException : Exception
    {
        public long userId { get; private set; }

        public ForbiddenException(long userId)
            : base("Forbidden Exception => userId = " + userId)
        {
            this.userId = userId;
        }
    }
}
