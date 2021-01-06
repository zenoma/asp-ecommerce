using Es.Udc.DotNet.ModelUtil.Exceptions;
using Es.Udc.DotNet.ModelUtil.IoC;
using Es.Udc.DotNet.PracticaMaD.Model.ECommerceServices.CartService;
using Es.Udc.DotNet.PracticaMaD.Model.ECommerceServices.OrderService;
using Es.Udc.DotNet.PracticaMaD.Model.ECommerceServices.UserService;
using Es.Udc.DotNet.PracticaMaD.Model.Services.UserService;
using Es.Udc.DotNet.PracticaMaD.Web.HTTP.Session;
using Es.Udc.DotNet.PracticaMaD.Web.HTTP.Util.IoC;
using System;
using System.Collections.Generic;
using System.Web;

namespace Es.Udc.DotNet.PracticaMaD.Web.Pages.Order
{
    public partial class CreateOrder : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            comboCreditCard.Visible = false;
            lblIdentifierError.Visible = false;
            if (!IsPostBack)
            {
                IIoCManager iocManager =
                   (IIoCManager)HttpContext.Current.Application["managerIoC"];

                IUserService userService = iocManager.Resolve<IUserService>();

                UserRegisterDetailsDto userDto =
                    SessionManager.FindUserProfileDetails(Context);

                txtPostalAddress.Text = userDto.postalAddress;

                long userId = SessionManager.GetUserSession(Context).UserProfileId;

                List<CreditCardDto> creditCards;
                try
                {
                    creditCards = userService.FindCreditCardsByUserId(userId);
                    /* Combo box initialization */
                    UpdateComboCreditCard(creditCards);
                }
                catch (InstanceNotFoundException)
                {
                }

            }

        }
        private void UpdateComboCreditCard(List<CreditCardDto> creditCards)
        {
            if (creditCards.Count != 0)
            {

                comboCreditCard.Visible = true;
                comboCreditCard.DataSource = creditCards;
                comboCreditCard.DataTextField = "number";
                comboCreditCard.DataValueField = "number";
                comboCreditCard.DataBind();
                CreditCardDto creditCardFav;
                try
                {
                    IIoCManager iocManager =
                          (IIoCManager)HttpContext.Current.Application["managerIoC"];

                    IUserService userService = iocManager.Resolve<IUserService>();
                    long userId = SessionManager.GetUserSession(Context).UserProfileId;
                    creditCardFav = userService.FindFavCreditCardByUserId(userId);
                    comboCreditCard.SelectedValue = creditCardFav.number.ToString();
                }
                catch (InstanceNotFoundException)
                { }
            }


        }

        protected void BtnCreateOrder(object sender, EventArgs e)
        {

            IIoCManager iocManager =
                   (IIoCManager)HttpContext.Current.Application["managerIoC"];
            IOrderService orderService = iocManager.Resolve<IOrderService>();

            try
            {
                string login = CookiesManager.GetLoginName(Context);
                CartDto cartDto = (CartDto)Context.Session["userCart"];
                orderService.CreateOrder(login, cartDto, long.Parse(comboCreditCard.SelectedValue), txtPostalAddress.Text, txtName.Text);
                SessionManager.RemoveCart(Context);
                Response.Redirect(
                    Response.ApplyAppPathModifier("~/Pages/Order/ShowOrdersByLogin.aspx"));
            }
            catch (InvalidOperationException ex)
            {

                lblIdentifierError.Visible = true;
                lblIdentifierError.Text = ex.Message.ToString();
            }

        }

    }
}