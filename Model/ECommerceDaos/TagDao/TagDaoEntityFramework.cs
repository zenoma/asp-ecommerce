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
        public int CountTag(long tagId) //cuantas veces aparece un tag en la bbdd
        {
            DbSet<Tag> tags = Context.Set<Tag>();

            int result = (from t in tags
                          where t.tagId == tagId
                          select t).Count();

            return result;
        }

        public List<Tag> FindByCommentId(long commentId)
        {
            DbSet<Tag> tags = Context.Set<Tag>();

            var result =
                (from t in tags
                 where t.Comment.Any(c => c.commentId == commentId)
                 select t).ToList();

            return result;
        }

        //public List<Tag> FindTop5MoreUsedTags()
        //{
        //    DbSet<Tag> tags = Context.Set<Tag>();

        //    var result = tags.GroupBy(t => t.tagId).OrderByDescending(gt => gt.Count()).Take(5).Select(t => t.Key).ToList();

        //    return result;
        //}
    }
}
