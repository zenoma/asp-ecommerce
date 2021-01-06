using Es.Udc.DotNet.ModelUtil.IoC;
using Es.Udc.DotNet.PracticaMaD.Model.ECommerceServices.TagService;
using Es.Udc.DotNet.PracticaMaD.Web.HTTP.Session;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Es.Udc.DotNet.PracticaMaD.Web
{
    public partial class ECommerce : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
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
        }

        protected void LoadTags()
        {
            int numberOfComments = 5;

            IIoCManager iocManager = (IIoCManager)HttpContext.Current.Application["managerIoC"];
            ITagService tagService = iocManager.Resolve<ITagService>();
            List<TagDetails> topTags = tagService.GetTopTags(numberOfComments);
            foreach (var tag in topTags.Select((value, i) => new { i, value }))
            {
                if (tag.value.count != 0)
                {
                    string url = Response.ApplyAppPathModifier("~/Pages/Products/ShowProducts.aspx?tag=" + tag.value.tagId);
                    tagCloud.InnerHtml += "<a class='tag' style='font-size: " + size(numberOfComments, tag.i, tag.value.count) +
                        "px;' href='" + url + "'>" + tag.value.visualName + " </a>";
                }
            }
        }

        private int size(int numberOfComments, int index, int comments)
        {
            int maxSize = 30 + numberOfComments;
            int minSize = 10 + numberOfComments;
            IIoCManager iocManager = (IIoCManager)HttpContext.Current.Application["managerIoC"];
            ITagService tagService = iocManager.Resolve<ITagService>();
            int maxComments = tagService.GetTopTags(1)[0].count;
            int result = (int)(maxSize * comments / maxComments);

            return result < minSize ? minSize - index : result;


        }
    }
}