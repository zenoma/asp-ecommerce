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
        public string productName { get; set; }
        public string body { get; set; }
        public System.DateTime commentDate { get; set; }

        public CommentDetails(long commentId, string userLogin, string productName, string body, System.DateTime commentDate)
        {
            this.commentId = commentId;
            this.userLogin = userLogin;
            this.productName = productName;
            this.body = body;
            this.commentDate = commentDate;
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int multiplier = 31;
                int hash = GetType().GetHashCode();

                hash = hash * multiplier + (userLogin == null ? 0 : userLogin.GetHashCode());
                hash = hash * multiplier + (productName == null ? 0 : productName.GetHashCode());
                hash = hash * multiplier + (body == null ? 0 : body.GetHashCode());
                hash = hash * multiplier + commentDate.GetHashCode();

                return hash;
            }

        }

        public override bool Equals(object obj)
        {

            if (ReferenceEquals(null, obj)) return false;        // Is Null?
            if (ReferenceEquals(this, obj)) return true;         // Is same object?
            if (obj.GetType() != this.GetType()) return false;   // Is same type?

            CommentDetails target = obj as CommentDetails;

            return true
               && (this.commentId == target.commentId)
               && (this.userLogin == target.userLogin)
               && (this.productName == target.productName)
               && (this.body == target.body)
               && (this.commentDate == target.commentDate)
               ;

        }

        public override String ToString()
        {
            StringBuilder strComment = new StringBuilder();

            strComment.Append("[ ");
            strComment.Append(" commentId = " + commentId + " | ");
            strComment.Append(" userLogin = " + userLogin + " | ");
            strComment.Append(" productName = " + productName + " | ");
            strComment.Append(" body = " + body + " | ");
            strComment.Append(" commentDate = " + commentDate + " | ");
            strComment.Append("] ");

            return strComment.ToString();
        }
    }
}
