using Es.Udc.DotNet.ModelUtil.IoC;
using Es.Udc.DotNet.PracticaMaD.Model.ECommerceServices.CommentService;
using Es.Udc.DotNet.PracticaMaD.Model.ECommerceServices.UserService;
using Es.Udc.DotNet.PracticaMaD.Web.HTTP.Session;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Es.Udc.DotNet.PracticaMaD.Web.Pages.Comment
{
    public partial class CommentProduct : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnCreateComment_Click(object sender, EventArgs e)
        {
            /* Get Product ID passed as parameter in the request from
             * the previous page
             */
            long productId = Convert.ToInt64(Request.Params.Get("productId"));
            long userId = SessionManager.GetUserSession(Context).UserProfileId;

            /* Get the Service */
            IIoCManager iocManager = (IIoCManager)HttpContext.Current.Application["managerIoC"];
            ICommentService commentService = iocManager.Resolve<ICommentService>();

            string body = txtBodyComment.Text;

            commentService.CreateComment(productId, userId, body, null);
            
        }
    }
}