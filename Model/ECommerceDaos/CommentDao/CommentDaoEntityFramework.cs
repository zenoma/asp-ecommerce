using Es.Udc.DotNet.ModelUtil.Dao;
using Es.Udc.DotNet.PracticaMaD.Model.ECommerceDaos.Util;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Es.Udc.DotNet.PracticaMaD.Model.Model1Daos.CommentDao
{
    public class CommentDaoEntityFramework :
        GenericDaoEntityFramework<Comment, Int64>, ICommentDao
    {
        public Block<Comment> FindByProductId(long productId, int page, int count)
        {
            using (var context = new ecommerceEntities())
            {
                var query = from c in context.Comment
                            where c.productId == productId
                            orderby c.commentDate descending
                            select c;

                Block<Comment> result = BlockList.GetPaged(query, page, count);

                return result;
            }
        }

        public Block<Comment> FindByTag(long tagId, int page, int count)
        {
            using (var context = new ecommerceEntities())
            {
                var query = from c in context.Comment
                            where c.Tag.Any(t => t.tagId == tagId)
                            orderby c.commentId
                            select c;

                Block<Comment> result = BlockList.GetPaged(query, page, count);

                return result;
            }
        }

        public Block<Comment> FindByUserId(long userId, int page, int count)
        {
            using (var context = new ecommerceEntities())
            {
                var query = from c in context.Comment
                            where c.userId == userId
                            orderby c.commentDate descending
                            select c;

                Block<Comment> result = BlockList.GetPaged(query, page, count);

                return result;
            }
        }
    }
}
