using Es.Udc.DotNet.ModelUtil.Dao;
using System;
using System.Collections.Generic;

namespace Es.Udc.DotNet.PracticaMaD.Model.Model1Daos.TagDao
{
    public interface ITagDao : IGenericDao<Tag, Int64>
    {
        List<Tag> FindByCommentId(long commentId);

        int CountTag(long tagId);

        //List<Tag> FindTop5MoreUsedTags();
    }
}
