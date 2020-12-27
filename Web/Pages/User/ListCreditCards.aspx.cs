using Es.Udc.DotNet.ModelUtil.IoC;
using Es.Udc.DotNet.PracticaMaD.Model.ECommerceServices.UserService;
using Es.Udc.DotNet.PracticaMaD.Model.Services.UserService;
using Es.Udc.DotNet.PracticaMaD.Web.HTTP.Session;
using System;
using System.Collections.Generic;
using System.Web;

namespace Es.Udc.DotNet.PracticaMaD.Web.Pages.User
{
    public partial class ListCreditCards : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            long userID = 0;

            lblNoCreditCards.Visible = false;

            if (SessionManager.GetUserSession(Context) != null)
            {
                userID = SessionManager.GetUserSession(Context).UserProfileId;
            }
            else
            {
                Response.Redirect(
                    Response.ApplyAppPathModifier("~/Pages/User/Authentication.aspx"));
            }

            IIoCManager iocManager = (IIoCManager)HttpContext.Current.Application["managerIoC"];
            IUserService userService = iocManager.Resolve<IUserService>();

            List<CreditCardDto> creditCards =
                userService.FindCreditCardsByUserId(userID);

            if (creditCards.Count == 0)
            {
                lblNoCreditCards.Visible = true;
                return;
            }

            this.gvCreditCards.DataSource = creditCards;
            this.gvCreditCards.DataBind();
        }
    }
}