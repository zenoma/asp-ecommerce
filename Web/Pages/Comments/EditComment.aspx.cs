using Es.Udc.DotNet.ModelUtil.IoC;
using Es.Udc.DotNet.PracticaMaD.Model;
using Es.Udc.DotNet.PracticaMaD.Model.ECommerceServices.CommentService;
using Es.Udc.DotNet.PracticaMaD.Model.ECommerceServices.TagService;
using Es.Udc.DotNet.PracticaMaD.Web.HTTP.Session;
using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Es.Udc.DotNet.PracticaMaD.Web.Pages.Comments
{
    public partial class EditComment : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                IIoCManager iocManager = (IIoCManager)HttpContext.Current.Application["managerIoC"];
                ICommentService commentService = iocManager.Resolve<ICommentService>();
                ITagService tagService = iocManager.Resolve<ITagService>();

                CommentDetails comment =
                    commentService.FindCommentById(long.Parse(Request.Params.Get("CommentId")));

                List<Tag> tagsFound = tagService.ListAllTags();

                txtBody.Text = comment.body;

                tagsFound.ForEach(tag =>
                {
                    ListItem liTag = new ListItem();
                    liTag.Value = tag.tagId.ToString();
                    liTag.Text = tag.name;
                    if (comment.tags.Contains(tag.name))
                    {
                        liTag.Selected = true;
                    }
                    lbTags.Items.Add(liTag);
                });
            }
        }

        protected void BtnEditClick(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                IIoCManager iocManager = (IIoCManager)HttpContext.Current.Application["managerIoC"];
                ICommentService commentService = iocManager.Resolve<ICommentService>();

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

                commentService.UpdateComment(SessionManager.GetUserSession(Context).UserProfileId, long.Parse(Request.Params.Get("CommentId")), txtBody.Text, commentTags);

                Response.Redirect(Response.
                    ApplyAppPathModifier("~/Pages/Comments/ShowCommentsByUserLogin.aspx"));
            }
        }
    }
}