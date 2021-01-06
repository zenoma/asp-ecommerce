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
    public partial class ShowComments : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            long productId = long.Parse(Request.Params.Get("productId"));
            int startIndex, count;

            lnkPrevious.Visible = false;
            lnkNext.Visible = false;

            lblNoComments.Visible = false;
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
                commentService.ShowCommentsOfProduct(productId, startIndex, count);

            if (commentBlock.Comments.Count == 0)
            {
                lblNoComments.Visible = true;
                return;
            }

            this.gvComments.DataSource = commentBlock.Comments;
            this.gvComments.DataBind();

            // Ocultamos botones de borrar y editar
            // comentarios si usuario no esta logeado
            if (SessionManager.GetUserSession(Context) == null)
            {
                gvComments.Columns[4].Visible = false;
                gvComments.Columns[5].Visible = false;
            }
            else
            {
                for (int i = 0; i < gvComments.Rows.Count; i++)
                {
                    if (commentBlock.Comments[i].userId != SessionManager.GetUserSession(Context).UserProfileId)
                    {
                        gvComments.Rows[i].Cells[4].Visible = false;
                        gvComments.Rows[i].Cells[5].Visible = false;
                    }
                }
            }

            /* "Previous" link */
            if ((startIndex - 1) > 0)
            {
                String url = Settings.Default.ECommerce_applicationURL +
                    "~/Pages/Comments/ShowCommentsByProductId.aspx" +
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
                    "~/Pages/Comments/ShowCommentsByProductId.aspx" +
                    "?startIndex=" + (startIndex + 1) + "&count=" +
                    count;

                this.lnkNext.NavigateUrl =
                    Response.ApplyAppPathModifier(url);
                this.lnkNext.Visible = true;
            }
        }
    }
}