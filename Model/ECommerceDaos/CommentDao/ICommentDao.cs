using Es.Udc.DotNet.PracticaMaD.Model.ECommerceDaos.Util;
using System;

namespace Es.Udc.DotNet.PracticaMaD.Model.Model1Daos.CommentDao
{
    public interface ICommentDao : ModelUtil.Dao.IGenericDao<Comment, Int64>
    {
        Block<Comment> FindByUserId(long userId, int page, int count);

        Block<Comment> FindByProductId(long productId, int page, int count);

        Block<Comment> FindByTag(long tagId, int page, int count);
    }
}
