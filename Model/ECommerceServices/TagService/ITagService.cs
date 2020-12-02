using Es.Udc.DotNet.ModelUtil.Transactions;
using Es.Udc.DotNet.PracticaMaD.Model.Model1Daos.CommentDao;
using Es.Udc.DotNet.PracticaMaD.Model.Model1Daos.TagDao;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        Tag CreateTag(string name);

        [Transactional]
        List<Tag> ListAllTags();
    }
}
