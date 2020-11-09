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
        public Dictionary<long, int> FindTopTags(long tagId) // cuantas veces aparece un tag en la bbdd
        {
            DbSet<Tag> tags = Context.Set<Tag>();

            var result = (from t in tags
                          select new Item
                          { 
                              id = t.tagId,
                              count = t.Comment.Count()
                          }
                          ).OrderByDescending(o => o.count).Take(5).ToDictionary(item => item.id, item => item.count);

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
    }
}
