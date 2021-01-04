using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Es.Udc.DotNet.PracticaMaD.Model.ECommerceServices.CommentService
{
    public class CommentDetails
    {
        public long commentId { get; set; }
        public string userLogin { get; set; }
        public long userId { get; set; }
        public string productName { get; set; }
        public string body { get; set; }
        public System.DateTime commentDate { get; set; }
        
        public List<String> tags { get; set; }

        public CommentDetails(long commentId, long userId, string userLogin, string productName, string body, System.DateTime commentDate, List<String> tags)
        {
            this.commentId = commentId;
            this.userLogin = userLogin;
            this.userId = userId;
            this.productName = productName;
            this.body = body;
            this.commentDate = commentDate;
            this.tags = tags;
        }

        public override bool Equals(object obj)
        {
            return obj is CommentDetails details &&
                   userLogin == details.userLogin &&
                   userId == details.userId &&
                   productName == details.productName &&
                   body == details.body &&
                   commentDate == details.commentDate &&
                   EqualityComparer<List<string>>.Default.Equals(tags, details.tags);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(userLogin, userId, productName, body, commentDate, tags);
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
