using Es.Udc.DotNet.ModelUtil.Transactions;
using Es.Udc.DotNet.PracticaMaD.Model.Model1Daos.CommentDao;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Es.Udc.DotNet.PracticaMaD.Model.ECommerceServices.CommentService
{
    public class CommentService : ICommentService
    {
        [Inject]
        public ICommentDao commentDao { private get; set; }

        /// <exception cref="InstanceNotFoundException"/>
        [Transactional]
        public Comment CreateComment(long productId, long userId, string body, ICollection<Tag> tags)
        {
            Comment comment = new Comment();
            comment.productId = productId;
            comment.userId = userId;
            comment.body = body;
            comment.Tag = tags;
            comment.commentDate = System.DateTime.Now;

            commentDao.Create(comment);

            return comment;
        }

        /// <exception cref="InstanceNotFoundException"/>
        [Transactional]
        public void RemoveComment(long commentId)
        {
            commentDao.Remove(commentId);
        }

        [Transactional]
        public List<Comment> ShowCommentsOfProduct(long productId, int startIndex)
        {
            return commentDao.FindByProductId(productId, startIndex, 10);
        }

        /// <exception cref="InstanceNotFoundException"/>
        [Transactional]
        public void UpdateComment(long commentId, string body, ICollection<Tag> tags)
        {
            Comment comment = commentDao.Find(commentId);
            comment.body = body;
            comment.Tag = tags;

            commentDao.Update(comment);
        }
    }
}
