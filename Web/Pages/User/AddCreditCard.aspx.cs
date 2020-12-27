using Es.Udc.DotNet.ModelUtil.Exceptions;
using Es.Udc.DotNet.ModelUtil.IoC;
using Es.Udc.DotNet.PracticaMaD.Model;
using Es.Udc.DotNet.PracticaMaD.Model.ECommerceServices.UserService;
using Es.Udc.DotNet.PracticaMaD.Model.Services.UserService;
using Es.Udc.DotNet.PracticaMaD.Web.HTTP.Session;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Es.Udc.DotNet.PracticaMaD.Web.Pages.User
{
    public partial class AddCreditCard : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void BtnAddClick(object sender, EventArgs e)
        {
            string returnUrl = Request["ReturnUrl"];
            if (Page.IsValid)
            {
                try
                {
                    CreditCardDto creditCard = new CreditCardDto(0, this.txtType.Text, 
                        long.Parse(this.txtNumber.Text), short.Parse(this.txtVerifyCode.Text), 
                        System.DateTime.Parse(this.txtExpDate.Text), this.checkIsFav.Checked);

                    IIoCManager iocManager = (IIoCManager)HttpContext.Current.Application["managerIoC"];
                    IUserService userService = iocManager.Resolve<IUserService>();

                    long creditCardId = userService.CreateCreditCard(creditCard, 
                        SessionManager.GetUserSession(Context).UserProfileId);

                    if (creditCardId > 0)
                    {
                        if (returnUrl != null)
                        {
                            Response.Redirect(Response.
                                ApplyAppPathModifier(returnUrl));
                        }
                        else
                        {
                            Response.Redirect(Response.
                                ApplyAppPathModifier("~/Pages/User/ListCreditCards.aspx"));
                        }
                    }
                    else
                    {
                        lblAddError.Visible = true;
                    }
                }
                catch (DuplicateInstanceException)
                {
                    lblAddError.Visible = true;
                }
            }
        }
    }
}