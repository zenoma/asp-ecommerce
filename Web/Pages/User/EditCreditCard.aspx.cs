using Es.Udc.DotNet.ModelUtil.IoC;
using Es.Udc.DotNet.PracticaMaD.Model.ECommerceServices.UserService;
using Es.Udc.DotNet.PracticaMaD.Model.Services.UserService;
using Es.Udc.DotNet.PracticaMaD.Web.HTTP.Session;
using System;
using System.Web;

namespace Es.Udc.DotNet.PracticaMaD.Web.Pages.User
{
    public partial class EditCreditCard : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                IIoCManager iocManager = (IIoCManager)HttpContext.Current.Application["managerIoC"];
                IUserService userService = iocManager.Resolve<IUserService>();

                CreditCardDto creditCard =
                    userService.FindCreditCardById(long.Parse(Request.Params.Get("CreditCardId")));

                txtType.Text = creditCard.type;
                txtNumber.Text = creditCard.number.ToString();
                txtVerifyCode.Text = creditCard.verifyCode.ToString();
                txtExpDate.Text = creditCard.expDate.ToString("yyyy-MM-dd");
                checkIsFav.Checked = creditCard.isFav;
            }
        }

        protected void BtnEditClick(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                CreditCardDto creditCard = new CreditCardDto(long.Parse(Request.Params.Get("CreditCardId")), 
                    this.txtType.Text, long.Parse(this.txtNumber.Text), short.Parse(this.txtVerifyCode.Text),
                    System.DateTime.Parse(this.txtExpDate.Text), this.checkIsFav.Checked);

                IIoCManager iocManager = (IIoCManager)HttpContext.Current.Application["managerIoC"];
                IUserService userService = iocManager.Resolve<IUserService>();

                userService.UpdateCreditCard(creditCard, SessionManager.GetUserSession(Context).UserProfileId);

                Response.Redirect(Response.
                    ApplyAppPathModifier("~/Pages/User/ListCreditCards.aspx"));
            }
        }
    }
}