using Es.Udc.DotNet.ModelUtil.Dao;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics.Eventing.Reader;
using System.Linq;

namespace Es.Udc.DotNet.PracticaMaD.Model.Model1Daos.TagDao
{

    public class Item {
        public long id { get; set; }
        public int count { get; set; }
    }

    public class TagDaoEntityFramework :
        GenericDaoEntityFramework<Tag, Int64>, ITagDao
    {
        public List<Tag> FindTopTags(int n) // cuantas veces aparece un tag en la bbdd
        {
            DbSet<Tag> tags = Context.Set<Tag>();

            var result = (from t in tags
                             select t).OrderByDescending(t => t.Comment.Count).Take(n).ToList();

            return result;
        }

        public List<Tag> FindAllTags()
        {
            using (var context = new ecommerceEntities())
            {
                var result = (from t in context.Tag
                              select t).ToList();

                return result;
            }
        }

        public Tag FindByVisualName(string visualName)
        {
            DbSet<Tag> tags = Context.Set<Tag>();

            var result = (from t in tags
                              where t.name == visualName
                              select t).SingleOrDefault();

            return result;
        }

        public List<Tag> FindByCommentId(long commentId)
        {
            using (var context = new ecommerceEntities())
            {
                var result = (from t in context.Tag
                              where t.Comment.Any(c => c.commentId == commentId)
                              select t).ToList();

                return result;
            }
        }
    }
}
