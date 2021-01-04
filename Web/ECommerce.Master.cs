using Es.Udc.DotNet.ModelUtil.IoC;
using Es.Udc.DotNet.PracticaMaD.Model.ECommerceServices.TagService;
using Es.Udc.DotNet.PracticaMaD.Web.HTTP.Session;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Es.Udc.DotNet.PracticaMaD.Web
{
    public partial class ECommerce : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            LoadTags();
            SessionManager.InitializeCart(Context);
            if (!SessionManager.IsUserAuthenticated(Context))
            {

                if (lblDash2 != null)
                    lblDash2.Visible = false;
                if (lnkUpdate != null)
                    lnkUpdate.Visible = false;
                if (lblDash3 != null)
                    lblDash3.Visible = false;
                if (lnkCreditCard != null)
                    lnkCreditCard.Visible = false;
                if (lblDash4 != null)
                    lblDash3.Visible = false;
                if (lnkMyComments != null)
                    lnkMyComments.Visible = false;
                if (lblDash5 != null)
                    lblDash4.Visible = false;
                if (lnkLogout != null)
                    lnkLogout.Visible = false;

            }
            else
            {
                if (lblWelcome != null)
                    lblWelcome.Text =
                        GetLocalResourceObject("lblWelcome.Hello.Text").ToString()
                        + " " + SessionManager.GetUserSession(Context).FirstName;
                if (lblDash1 != null)
                    lblDash1.Visible = false;
                if (lnkAuthenticate != null)
                    lnkAuthenticate.Visible = false;
            }
        }

        protected void LoadTags()
        {
            IIoCManager iocManager = (IIoCManager)HttpContext.Current.Application["managerIoC"];
            ITagService tagService = iocManager.Resolve<ITagService>();
            foreach (TagDetails tag in tagService.GetTopTags(5))
            {
                tagCloud.InnerHtml += "<span class='tag' style='font-size: "+ size(tag.count) +"px;'> " + tag.visualName + " </span>";
            }
        }

        private int size(int count)
        {
            IIoCManager iocManager = (IIoCManager)HttpContext.Current.Application["managerIoC"];
            ITagService tagService = iocManager.Resolve<ITagService>();
            int maxComments = tagService.GetTopTags(1)[0].count;

            int size = 20 * count / maxComments;
            return size < 10 ? 10 : size ;
            
        }
    }
}