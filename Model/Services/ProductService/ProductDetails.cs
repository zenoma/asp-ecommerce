using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Es.Udc.DotNet.PracticaMaD.Model.Services.ProductService
{
    [Serializable()]
    public class ProductDetails
    {
        #region Properties Region

        public long categoryId { get; set; }
        public string name { get; set; }
        public double price { get; set; }
        public int stockUnits { get; set; }
        public double unitPrice { get; set; }
        public string subtype { get; set; }

        #endregion
        public ProductDetails(long categoryId, string name, double price, int stockUnits, double unitPrice, string subtype)
        {
            this.categoryId = categoryId;
            this.name = name;
            this.price = price;
            this.stockUnits = stockUnits;
            this.unitPrice = unitPrice;
            this.subtype = subtype;
        }
        public override bool Equals(object obj)
        {
            return obj is ProductDetails details &&
                   categoryId == details.categoryId &&
                   name == details.name &&
                   price == details.price &&
                   stockUnits == details.stockUnits &&
                   unitPrice == details.unitPrice &&
                   subtype == details.subtype;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(categoryId, name, price, stockUnits, unitPrice, subtype);
        }

    }
}
