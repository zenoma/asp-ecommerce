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
        List<Comment> FindByUserId(long userId, int startIndex, int count);

        List<Comment> FindByProductId(long productId, int startIndex, int count);

        List<Comment> FindByUserIdAndProductId(long userId, long productId, int startIndex, int count);

        List<Comment> FindByTag(long tagId, int startIndex, int count);
    }
}
