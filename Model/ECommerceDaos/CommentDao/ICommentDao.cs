using Es.Udc.DotNet.PracticaMaD.Model.ECommerceDaos.Util;
using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Es.Udc.DotNet.PracticaMaD.Model.Model1Daos.CommentDao
{
    public interface ICommentDao : ModelUtil.Dao.IGenericDao<Comment, Int64>
    {
        Block<Comment> FindByProductId(long productId, int page, int count);

        Block<Comment> FindByTag(long tagId, int page, int count);
    }
}
