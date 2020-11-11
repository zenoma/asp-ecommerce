using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Es.Udc.DotNet.PracticaMaD.Model.ECommerceServices.TagService
{
    public class TagDetails
    {
        #region Properties Region

        public long tagId { get; set; }
        public string visualName { get; set; }
        public int count { get; set; }

        #endregion


        public TagDetails(long tagId, string visualName, int count)
        {
            this.tagId = tagId;
            this.visualName = visualName;
            this.count = count;
    
    }
        public override bool Equals(object obj)
        {
            return obj is TagDetails details &&
                   tagId == details.tagId &&
                   visualName == details.visualName &&
                   count == details.count;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(tagId, visualName, count);
        }
    }
}
