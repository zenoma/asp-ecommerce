using Es.Udc.DotNet.ModelUtil.IoC;
using Es.Udc.DotNet.PracticaMaD.Model;
using Es.Udc.DotNet.PracticaMaD.Model.ECommerceServices.CommentService;
using Es.Udc.DotNet.PracticaMaD.Model.ECommerceServices.TagService;
using Es.Udc.DotNet.PracticaMaD.Web.HTTP.Session;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Es.Udc.DotNet.PracticaMaD.Web.Pages.Comments
{
    public partial class AddComment : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                IIoCManager iocManager = (IIoCManager)HttpContext.Current.Application["managerIoC"];
                ITagService tagService = iocManager.Resolve<ITagService>();

                List<Tag> tagsFound = tagService.ListAllTags();

                tagsFound.ForEach(tag =>
                {
                    ListItem liTag = new ListItem();
                    liTag.Value = tag.tagId.ToString();
                    liTag.Text = tag.name;
                    lbTags.Items.Add(liTag);
                });
            }
        }

        protected void btnAddComment_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                IIoCManager iocManager = (IIoCManager)HttpContext.Current.Application["managerIoC"];
                ICommentService commentService = iocManager.Resolve<ICommentService>();

                long userId = SessionManager.GetUserSession(Context).UserProfileId;

                List<String> commentTags = new List<String>();

                foreach (ListItem tagItem in lbTags.Items)
                {
                    if (tagItem.Selected)
                    {
                        commentTags.Add(tagItem.Text);
                    }
                }

                String[] newTags = txtNewTags.Text.Split(',');

                for (int i = 0; i < newTags.Length; i++)
                {
                    if (newTags[i].Trim() != "")
                    {
                        commentTags.Add(newTags[i].Trim());
                    }
                }

                commentService.CreateComment(long.Parse(Request.Params.Get("productId")), userId, txtBodyAddComment.Text, commentTags);

                /* Do action. */
                String url = String.Format("~/Pages/Comments/ShowCommentsByProductId.aspx?productId={0}", long.Parse(Request.Params.Get("productId")));
                Response.Redirect(Response.ApplyAppPathModifier(url));
            }
        }
    }
}