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
        public List<Tag> FindTopTags() // cuantas veces aparece un tag en la bbdd
        {
            DbSet<Tag> tags = Context.Set<Tag>();

            var result = (from t in tags
                          select t).OrderByDescending(t => t.Comment.Count).Take(5).ToList();
                          //select new Item
                          //{ 
                          //    id = t.tagId,
                          //    count = t.Comment.Count()
                          //}
                          //).OrderByDescending(o => o.count).Take(5).ToDictionary(item => item.id, item => item.count);

            return result;
        }

        //var query = tapesTable.GroupBy(x => x.Tape)
        //              .Select(x => x.OrderByDescending(t => t.Count)
        //                            .First());

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
