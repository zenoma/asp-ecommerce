using Es.Udc.DotNet.ModelUtil.Dao;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Es.Udc.DotNet.PracticaMaD.Model.Model1Daos.TagDao
{
    public class TagDaoEntityFramework :
        GenericDaoEntityFramework<Tag, Int64>, ITagDao
    {
        public List<Tag> FindByCommentId(long commentId)
        {
            DbSet<Tag> tags = Context.Set<Tag>();

            var result =
                (from t in tags
                 where t.Comments.Any(c => c.commentId == commentId)
                 select t).ToList();

            return result;
        }
    }
}
