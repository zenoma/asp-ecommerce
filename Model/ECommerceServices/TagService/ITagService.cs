using Es.Udc.DotNet.ModelUtil.Transactions;
using Es.Udc.DotNet.PracticaMaD.Model.Model1Daos.CommentDao;
using Es.Udc.DotNet.PracticaMaD.Model.Model1Daos.TagDao;
using Ninject;
using System.Collections.Generic;

namespace Es.Udc.DotNet.PracticaMaD.Model.ECommerceServices.TagService
{
    public interface ITagService
    {
        [Inject]
        ICommentDao commentDao { set; }

        [Inject]
        ITagDao tagDao { set; }

        [Transactional]
        List<TagDetails> GetTopTags(int n);

        [Transactional]
        Tag CreateTag(string name, List<Comment> comments);

        [Transactional]
        List<Tag> ListAllTags();

        [Transactional]
        List<Tag> ListTagsByComment(long commentId);
    }
}
