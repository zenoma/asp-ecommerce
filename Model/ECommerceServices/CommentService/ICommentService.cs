using Es.Udc.DotNet.ModelUtil.Transactions;
using Es.Udc.DotNet.PracticaMaD.Model.Model1Daos.CommentDao;
using Ninject;
using System.Collections.Generic;

namespace Es.Udc.DotNet.PracticaMaD.Model.ECommerceServices.CommentService
{
    public interface ICommentService
    {

        [Inject]
        ICommentDao commentDao { set; }

        [Transactional]
        Comment CreateComment(long productId, long userId, string body, ICollection<string> tags);

        [Transactional]
        CommentDetails FindCommentById(long commentId);

        [Transactional]
        void UpdateComment(long userId, long commentId, string body, ICollection<string> tags);

        [Transactional]
        void RemoveComment(long userId, long commentId);

        [Transactional]
        CommentBlock ShowCommentsOfProduct(long productId, int page, int count);

        [Transactional]
        CommentBlock ListCommentsByTag(long tagId, int page, int count);

        [Transactional]
        CommentBlock ListCommentsByUserId(long userId, int page, int count);
    }
}
