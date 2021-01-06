using Es.Udc.DotNet.ModelUtil.IoC;
using Es.Udc.DotNet.PracticaMaD.Model.Services.UserService;
using Es.Udc.DotNet.PracticaMaD.Web.HTTP.Session;
using System;
using System.Web;

namespace Es.Udc.DotNet.PracticaMaD.Web.Pages.User
{
    public partial class RemoveCreditCard : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            IIoCManager iocManager = (IIoCManager)HttpContext.Current.Application["managerIoC"];
            IUserService userService = iocManager.Resolve<IUserService>();

            userService.DeleteCreditCard(long.Parse(Request.Params.Get("CreditCardId")),
                SessionManager.GetUserSession(Context).UserProfileId);

            Response.Redirect(Response.
                    ApplyAppPathModifier("~/Pages/User/ListCreditCards.aspx"));
        }
    }
}