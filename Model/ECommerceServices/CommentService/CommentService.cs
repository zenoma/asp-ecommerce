using Es.Udc.DotNet.ModelUtil.Transactions;
using Es.Udc.DotNet.ModelUtil.Exceptions;
using Es.Udc.DotNet.PracticaMaD.Model.Model1Daos.CommentDao;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Es.Udc.DotNet.PracticaMaD.Model.Model1Daos.TagDao;
using Es.Udc.DotNet.PracticaMaD.Model.ECommerceDaos.Util;
using Es.Udc.DotNet.PracticaMaD.Model.Model1Daos.UserDao;
using Es.Udc.DotNet.PracticaMaD.Model.Model1Daos.ProductDao;

namespace Es.Udc.DotNet.PracticaMaD.Model.ECommerceServices.CommentService
{
    public class CommentService : ICommentService
    {
        [Inject]
        public IUserDao userDao { private get; set; }

        [Inject]
        public IProductDao productDao { private get; set; }

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
                    if (tagDao.FindByVisualName(item.ToLower()) != null)
                    {
                        tag = tagDao.FindByVisualName(item.ToLower());
                        comment.Tag.Add(tag);
                    }
                    else
                    {
                        tag.name = item.ToLower();
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
        public void RemoveComment(long userId, long commentId)
        {
            Comment comment = commentDao.Find(commentId);

            if (comment.User.userId != userId)
            {
                throw new ArgumentException("Invalid user");
            }

            commentDao.Remove(commentId);
        }

        [Transactional]
        public CommentBlock ShowCommentsOfProduct(long productId, int startIndex, int count)
        {
           /*
           * Find count+1 comments to determine if there exist more accounts above
           * the specified range.
           */
            Block<Comment> comments =
                commentDao.FindByProductId(productId, startIndex, count + 1);            

            bool existMoreComments = comments.CurrentPage < comments.PageCount;

            return new CommentBlock(toCommentDetails(comments.Results), existMoreComments);
        }

        [Transactional]
        public CommentDetails FindCommentById(long commentId)
        {
            /*
            * Find count+1 comments to determine if there exist more accounts above
            * the specified range.
            */
            Comment comment =
                commentDao.Find(commentId);
            User user = userDao.Find(comment.userId);
            Product product = productDao.Find(comment.productId);

            return new CommentDetails(comment.commentId, user.login, product.name, 
                comment.body, comment.commentDate);
        }

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

        public CommentBlock ListCommentsByTag(long tagId, int startIndex, int count)
        {
            /*
           * Find count+1 comments to determine if there exist more accounts above
           * the specified range.
           */
            Block<Comment> comments =
                commentDao.FindByTag(tagId, startIndex, count + 1);

            bool existMoreComments = comments.CurrentPage < comments.PageCount;

            return new CommentBlock(toCommentDetails(comments.Results), existMoreComments);
        }

        public CommentBlock ListCommentsByUserId(long userId, int startIndex, int count)
        {
            /*
           * Find count+1 comments to determine if there exist more accounts above
           * the specified range.
           */
            Block<Comment> comments =
                commentDao.FindByUserId(userId, startIndex, count + 1);

            bool existMoreComments = comments.CurrentPage < comments.PageCount;

            return new CommentBlock(toCommentDetails(comments.Results), existMoreComments);
        }

        private List<CommentDetails> toCommentDetails(List<Comment> comments)
        {
            List<CommentDetails> commentDetails = new List<CommentDetails>();
            User user;
            Product product;
            comments.ForEach(comment =>
            {
                user = userDao.Find(comment.userId);
                product = productDao.Find(comment.productId);
                commentDetails.Add(new CommentDetails(comment.commentId, user.login, product.name, comment.body, comment.commentDate));
            });

            return commentDetails;
        }
    }
}
