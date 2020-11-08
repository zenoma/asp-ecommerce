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
        public double unitPrice { get; set; }
        public DateTime productDate { get; set; }
        public int stockUnits { get; set; }
        public string type { get; set; }

        #endregion
        public ProductDetails(long categoryId, string name, int stockUnits, double unitPrice, string type, DateTime productDate)
        {
            this.categoryId = categoryId;
            this.name = name;
            this.stockUnits = stockUnits;
            this.unitPrice = unitPrice;
            this.type = type;
            this.productDate = productDate;

        }
        public override bool Equals(object obj)
        {
            return obj is ProductDetails details &&
                   categoryId == details.categoryId &&
                   name == details.name &&
                   stockUnits == details.stockUnits &&
                   unitPrice == details.unitPrice &&
                   type == details.type && productDate == details.productDate;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(categoryId, name, stockUnits, unitPrice, type, productDate);
        }

    }
}
