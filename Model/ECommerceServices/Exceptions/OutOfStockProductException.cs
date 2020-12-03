using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Es.Udc.DotNet.PracticaMaD.Model.ECommerceServices.Exceptions
{
    [Serializable]
    public class OutOfStockProductException : Exception
    {
        public String productName { get; private set; }

        public OutOfStockProductException(String productName)
             : base("Out of stock product exception => product = " + productName)
        {
            this.productName = productName;
        }
    }
}
