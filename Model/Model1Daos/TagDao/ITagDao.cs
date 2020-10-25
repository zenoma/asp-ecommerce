using Es.Udc.DotNet.ModelUtil.Dao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Es.Udc.DotNet.PracticaMaD.Model.Model1Daos.TagDao
{
    interface ITagDao : IGenericDao<Tag, Int64>
    {
        List<Tag> FindByCommentId(long commentId);
    }
}
