using Es.Udc.DotNet.ModelUtil.Dao;
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
        public List<Comment> FindByUserId(long userId, int startIndex, int count)
        {
            DbSet<Comment> comments = Context.Set<Comment>();

            List<Comment> result = (from c in comments
                                    where c.userId == userId
                                    orderby c.commentId
                                    select c).Skip(startIndex).Take(count).ToList();

            return result;
        }

        public List<Comment> FindByProductId(long productId, int startIndex, int count)
        {
            DbSet<Comment> comments = Context.Set<Comment>();

            List<Comment> result = (from c in comments
                                       where c.productId == productId
                                       orderby c.commentId
                                       select c).Skip(startIndex).Take(count).ToList();

            return result;
        }

        public List<Comment> FindByUserIdAndProductId(long userId, long productId, int startIndex, int count)
        {
            DbSet<Comment> comments = Context.Set<Comment>();

            List<Comment> result = (from c in comments
                                    where c.productId == productId && c.userId == userId
                                    orderby c.commentId
                                    select c).Skip(startIndex).Take(count).ToList();

            return result;
        }

        public List<Comment> FindByTag(long tagId, int startIndex, int count)
        {
            DbSet<Comment> comments = Context.Set<Comment>();

            List<Comment> result = (from c in comments
                                    where c.Tag.Any(t => t.tagId == tagId)
                                    orderby c.commentId
                                    select c).Skip(startIndex).Take(count).ToList();

            return result;
        }
    }
}
