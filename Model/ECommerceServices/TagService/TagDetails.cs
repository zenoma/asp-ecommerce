﻿using System;

namespace Es.Udc.DotNet.PracticaMaD.Model.ECommerceServices.TagService
{
    public class TagDetails
    {
        #region Properties Region

        public long tagId { get; set; }
        public string visualName { get; set; }
        public int count { get; set; }
        //public List<Comment> Comments { get; set; }

        #endregion

        public TagDetails(long tagId, string visualName, int count)
        {
            this.tagId = tagId;
            this.visualName = visualName;
            this.count = count;
            //this.Comments = comments;

        }

        public override bool Equals(object obj)
        {
            return obj is TagDetails details &&
                   tagId == details.tagId &&
                   visualName == details.visualName &&
                   count == details.count;
            //EqualityComparer<List<Comment>>.Default.Equals(Comments, details.Comments);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(tagId, visualName, count);
        }
    }
}
