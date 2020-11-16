using Es.Udc.DotNet.ModelUtil.Transactions;
using Es.Udc.DotNet.PracticaMaD.Model.Model1Daos.CommentDao;
using Es.Udc.DotNet.PracticaMaD.Model.Model1Daos.TagDao;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;

namespace Es.Udc.DotNet.PracticaMaD.Model.ECommerceServices.TagService
{
    public class TagService : ITagService
    {
        [Inject]
        public ICommentDao commentDao { private get; set; }

        [Inject]
        public ITagDao tagDao { private get; set; }

        [Transactional]
        public List<TagDetails> GetTopFiveTags()
        {
            List<Tag> topFiveTags = tagDao.FindTopTags();
            List<TagDetails> listTagDetails = new List<TagDetails>();

            foreach (Tag tag in topFiveTags)
            {
                TagDetails tagDetails = new TagDetails(tag.tagId, tag.name, tag.Comment.Count);
                listTagDetails.Add(tagDetails);
            }

            return listTagDetails;
        }
        
        [Transactional]
        public Tag CreateTag(string name)
        {
            Tag tag = new Tag();
            tag.name = name;
            tagDao.Create(tag);

            return tag;
        }

        public List<Tag> ListAllTags()
        {
            return tagDao.FindAllTags();
        }
    }
}
