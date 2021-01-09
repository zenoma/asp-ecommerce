using Es.Udc.DotNet.ModelUtil.Dao;
using Es.Udc.DotNet.PracticaMaD.Model.ECommerceDaos.Util;
using System;
using System.Linq;

namespace Es.Udc.DotNet.PracticaMaD.Model.Model1Daos.CommentDao
{
    public class CommentDaoEntityFramework :
        GenericDaoEntityFramework<Comment, Int64>, ICommentDao
    {
        SearchCache<Comment> cache = new SearchCache<Comment>();
        public Block<Comment> FindByProductId(long productId, int page, int count)
        {
            Block<Comment> result = cache.getQueryFromCache<Comment>("findCommentByProductId=" + productId + "&page=" + page);
            using (var context = new ecommerceEntities())
            {
                if (result == null)
                {
                    var query = from c in context.Comment
                                where c.productId == productId
                                orderby c.commentDate descending
                                select c;

                    result = BlockList.GetPaged(query, page, count);
                    cache.setQueryOnCache("findCommentByProductId=" + productId + "&page=" + page, result);
                }
                return result;
            }
        }

        public Block<Comment> FindByTag(long tagId, int page, int count)
        {
            Block<Comment> result = cache.getQueryFromCache<Comment>("findCommentByTag=" + tagId + "&page=" + page);
            using (var context = new ecommerceEntities())
            {
                if (result == null)
                {
                    var query = from c in context.Comment
                                where c.Tag.Any(t => t.tagId == tagId)
                                orderby c.commentId
                                select c;

                    result = BlockList.GetPaged(query, page, count);
                    cache.setQueryOnCache("findCommentByTag=" + tagId + "&page=" + page, result);
                }
                return result;
            }
        }

        public Block<Comment> FindByUserId(long userId, int page, int count)
        {
            Block<Comment> result = cache.getQueryFromCache<Comment>("findCommentByUserId=" + userId + "&page=" + page);
            using (var context = new ecommerceEntities())
            {
                if (result == null)
                {
                    var query = from c in context.Comment
                                where c.userId == userId
                                orderby c.commentDate descending
                                select c;

                    result = BlockList.GetPaged(query, page, count);
                    cache.setQueryOnCache("findCommentByUserId=" + userId + "&page=" + page, result);
                }
                return result;
            }
        }
    }
}
