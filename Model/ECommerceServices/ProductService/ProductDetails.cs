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

        public long productId { get; set; }
        public string category { get; set; }
        public string name { get; set; }
        public double unitPrice { get; set; }
        public DateTime productDate { get; set; }
        public int stockUnits { get; set; }
        public string type { get; set; }
        //Music Fields
        public string album { get; set; }
        public string artist { get; set; }
        //Movie Fields
        public string director { get; set; }
        public System.DateTime movieDate { get; set; }
        //Book Fields
        public string isbn { get; set; }
        public int editionNumber { get; set; }
        public string author { get; set; }

        #endregion

        public ProductDetails(long productId, string category, string name, int stockUnits,
            double unitPrice, string type, DateTime productDate, string album, string artist,
            string director, System.DateTime movieDate, string isbn, int editionNumber, string author)
        {
            this.productId = productId;
            this.category = category;
            this.name = name;
            this.stockUnits = stockUnits;
            this.unitPrice = unitPrice;
            this.type = type;
            this.productDate = productDate;
            this.album = album;
            this.artist = artist;
            this.director = director;
            this.movieDate = movieDate;
            this.isbn = isbn;
            this.editionNumber = editionNumber;
            this.author = author;

        }

        public override bool Equals(object obj)
        {
            return obj is ProductDetails details &&
                   productId == details.productId &&
                   category == details.category &&
                   name == details.name &&
                   unitPrice == details.unitPrice &&
                   productDate == details.productDate &&
                   stockUnits == details.stockUnits &&
                   type == details.type &&
                   album == details.album &&
                   artist == details.artist &&
                   director == details.director &&
                   movieDate == details.movieDate &&
                   isbn == details.isbn &&
                   editionNumber == details.editionNumber &&
                   author == details.author;
        }

        public override int GetHashCode()
        {
            HashCode hash = new HashCode();
            hash.Add(productId);
            hash.Add(category);
            hash.Add(name);
            hash.Add(unitPrice);
            hash.Add(productDate);
            hash.Add(stockUnits);
            hash.Add(type);
            hash.Add(album);
            hash.Add(artist);
            hash.Add(director);
            hash.Add(movieDate);
            hash.Add(isbn);
            hash.Add(editionNumber);
            hash.Add(author);
            return hash.ToHashCode();
        }
    }
}
