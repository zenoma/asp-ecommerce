using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Es.Udc.DotNet.PracticaMaD.Model.ECommerceServices.CommentService
{
    public class CommentBlock
    {
        public List<CommentDetails> Comments { get; private set; }
        public bool ExistMoreComments { get; private set; }

        public CommentBlock(List<CommentDetails> comments, bool existMoreComments)
        {
            this.Comments = comments;
            this.ExistMoreComments = existMoreComments;
        }
    }
}
