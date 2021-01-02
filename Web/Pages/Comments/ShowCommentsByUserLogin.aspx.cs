using Es.Udc.DotNet.ModelUtil.IoC;
using Es.Udc.DotNet.PracticaMaD.Model.ECommerceServices.CommentService;
using Es.Udc.DotNet.PracticaMaD.Web.HTTP.Session;
using Es.Udc.DotNet.PracticaMaD.Web.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Es.Udc.DotNet.PracticaMaD.Web.Pages.Comments
{
    public partial class ShowCommentsByUserLogin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            long userID = 0;
            int startIndex, count;

            lnkPrevious.Visible = false;
            lnkNext.Visible = false;

            lblNoComments.Visible = false;

            if (SessionManager.GetUserSession(Context) != null)
            {
                userID = SessionManager.GetUserSession(Context).UserProfileId;
            }
            else
            {
                Response.Redirect(
                    Response.ApplyAppPathModifier("~/Pages/User/Authentication.aspx"));
            }

            try
            {
                startIndex = Int32.Parse(Request.Params.Get("startIndex"));
            }
            catch (ArgumentNullException)
            {
                startIndex = 1;
            }

            try
            {
                count = Int32.Parse(Request.Params.Get("count"));
            }
            catch (ArgumentNullException)
            {
                count = Settings.Default.ECommerce_defaultCount;
            }

            IIoCManager iocManager = (IIoCManager)HttpContext.Current.Application["managerIoC"];
            ICommentService commentService = iocManager.Resolve<ICommentService>();

            CommentBlock commentBlock =
                commentService.ListCommentsByUserId(userID, startIndex, count);

            if (commentBlock.Comments.Count == 0)
            {
                lblNoComments.Visible = true;
                return;
            }

            this.gvComments.DataSource = commentBlock.Comments;
            this.gvComments.DataBind();

            /* "Previous" link */
            if ((startIndex - 1) > 0)
            {
                String url = Settings.Default.ECommerce_applicationURL +
                    "Pages/Comments/ShowCommentsByUserLogin.aspx" +
                    "?startIndex=" + (startIndex - 1) + "&count=" +
                    count;

                this.lnkPrevious.NavigateUrl =
                    Response.ApplyAppPathModifier(url);
                this.lnkPrevious.Visible = true;
            }

            /* "Next" link */
            if (commentBlock.ExistMoreComments)
            {
                String url = Settings.Default.ECommerce_applicationURL +
                    "Pages/Comments/ShowCommentsByUserLogin.aspx" +
                    "?startIndex=" + (startIndex + 1) + "&count=" +
                    count;

                this.lnkNext.NavigateUrl =
                    Response.ApplyAppPathModifier(url);
                this.lnkNext.Visible = true;
            }
        }
    }
}