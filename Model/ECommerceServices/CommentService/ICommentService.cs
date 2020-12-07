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
    public interface ICommentService
    {

        [Inject]
        ICommentDao commentDao { set; }

        [Transactional]
        Comment CreateComment(long productId, long userId, string body, ICollection<string> tags);

        [Transactional]
        void UpdateComment(long commentId, string body, ICollection<string> tags);

        [Transactional]
        void RemoveComment(long userId, long commentId);

        [Transactional]
        CommentBlock ShowCommentsOfProduct(long productId, int page, int count);

        [Transactional]
        CommentBlock ListCommentsByTag(long tagId, int page, int count);
    }
}
