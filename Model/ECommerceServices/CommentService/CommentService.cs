using Es.Udc.DotNet.ModelUtil.Transactions;
using Es.Udc.DotNet.PracticaMaD.Model.Model1Daos.CommentDao;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Es.Udc.DotNet.PracticaMaD.Model.Model1Daos.TagDao;

namespace Es.Udc.DotNet.PracticaMaD.Model.ECommerceServices.CommentService
{
    public class CommentService : ICommentService
    {
        [Inject]
        public ICommentDao commentDao { private get; set; }

        [Inject]
        public ITagDao tagDao { private get; set; }

        /// <exception cref="InstanceNotFoundException"/>
        [Transactional]
        public Comment CreateComment(long productId, long userId, string body, ICollection<string> tags)
        {
            Comment comment = new Comment();
            comment.productId = productId;
            comment.userId = userId;
            comment.body = body;
            comment.commentDate = System.DateTime.Now;

            if (tags != null)
            {
                foreach (var item in tags)
                {
                    Tag tag = new Tag();
                    if (tagDao.FindByVisualName(item) != null)
                    {
                        tag = tagDao.FindByVisualName(item);
                        comment.Tag.Add(tag);
                    }
                    else
                    {
                        tag.name = item;
                        tagDao.Create(tag);
                        comment.Tag.Add(tag);
                    }
                }
            }

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
        public void UpdateComment(long commentId, string body, ICollection<string> tags)
        {
            Comment comment = commentDao.Find(commentId);
            comment.body = body;

            if (tags != null)
            {
                foreach (var item in tags)
                {
                    Tag tag = new Tag();
                    if (tagDao.FindByVisualName(item) != null)
                    {
                        tag = tagDao.FindByVisualName(item);
                        comment.Tag.Add(tag);
                    }
                    else
                    {
                        tag.name = item;
                        tagDao.Create(tag);
                        comment.Tag.Add(tag);
                    }
                }
            }

            commentDao.Update(comment);
        }

        public List<Comment> ListCommentsByTag(long tagId, int startIndex)
        {
            return commentDao.FindByTag(tagId, startIndex, 10);
        }
    }
}
