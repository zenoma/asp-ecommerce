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
        public List<TagDetails> GetTopTags(int n)
        {
            List<Tag> topTags = tagDao.FindTopTags(n);
            List<TagDetails> listTagDetails = new List<TagDetails>();

            foreach (Tag tag in topTags)
            {
                TagDetails tagDetails = new TagDetails(tag.tagId, tag.name, tag.Comment.Count);
                listTagDetails.Add(tagDetails);
            }

            return listTagDetails;
        }
        
        [Transactional]
        public Tag CreateTag(string name, List<Comment> comments)
        {
            Tag tag = new Tag();
            tag.name = name.ToLower();

            comments.ForEach(comment =>
            {
                tag.Comment.Add(comment);
            });
            
            tagDao.Create(tag);

            return tag;
        }

        [Transactional]
        public List<Tag> ListAllTags()
        {
            return tagDao.FindAllTags();
        }

        [Transactional]
        public List<Tag> ListTagsByComment(long commentId)
        {
            return tagDao.FindByCommentId(commentId);
        }
    }
}
