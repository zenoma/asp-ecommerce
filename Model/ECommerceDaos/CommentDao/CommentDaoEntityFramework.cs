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
            DbSet<Comment> comments = Context.Set<Comment>();

            var query = (from c in comments
                         where c.productId == productId
                         orderby c.commentId
                         select c);

            Block<Comment> result = BlockList.GetPaged(query, page, count);

            return result;
        }

        public Block<Comment> FindByTag(long tagId, int page, int count)
        {
            DbSet<Comment> comments = Context.Set<Comment>();

            var query = (from c in comments
                         where c.Tag.Any(t => t.tagId == tagId)
                         orderby c.commentId
                         select c);

            Block<Comment> result = BlockList.GetPaged(query, page, count);

            return result;
        }
    }
}
