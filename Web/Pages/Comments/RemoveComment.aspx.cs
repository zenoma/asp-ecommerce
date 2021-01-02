using Es.Udc.DotNet.ModelUtil.IoC;
using Es.Udc.DotNet.PracticaMaD.Model.ECommerceServices.CommentService;
using Es.Udc.DotNet.PracticaMaD.Web.HTTP.Session;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Es.Udc.DotNet.PracticaMaD.Web.Pages.Comments
{
    public partial class RemoveComment : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            IIoCManager iocManager = (IIoCManager)HttpContext.Current.Application["managerIoC"];
            ICommentService commentService = iocManager.Resolve<ICommentService>();

            commentService.RemoveComment(SessionManager.GetUserSession(Context).UserProfileId, 
                long.Parse(Request.Params.Get("CommentId")));

            Response.Redirect(Response.
                    ApplyAppPathModifier("~/Pages/Comments/ShowCommentsByUserLogin.aspx"));
        }
    }
}