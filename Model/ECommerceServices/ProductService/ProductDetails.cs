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

        public string category { get; set; }
        public string name { get; set; }
        public double unitPrice { get; set; }
        public DateTime productDate { get; set; }
        public int stockUnits { get; set; }
        public string type { get; set; }

        #endregion
        public ProductDetails(string category, string name, int stockUnits, double unitPrice, string type, DateTime productDate)
        {
            this.category = category;
            this.name = name;
            this.stockUnits = stockUnits;
            this.unitPrice = unitPrice;
            this.type = type;
            this.productDate = productDate;

        }
        public override bool Equals(object obj)
        {
            return obj is ProductDetails details &&
                   category == details.category &&
                   name == details.name &&
                   stockUnits == details.stockUnits &&
                   unitPrice == details.unitPrice &&
                   type == details.type && productDate == details.productDate;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(category, name, stockUnits, unitPrice, type, productDate);
        }

    }
}
