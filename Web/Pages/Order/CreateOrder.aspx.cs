using Es.Udc.DotNet.ModelUtil.IoC;
using Es.Udc.DotNet.PracticaMaD.Model.ECommerceServices.CartService;
using Es.Udc.DotNet.PracticaMaD.Model.ECommerceServices.OrderService;
using Es.Udc.DotNet.PracticaMaD.Model.ECommerceServices.UserService;
using Es.Udc.DotNet.PracticaMaD.Model.Services.UserService;
using Es.Udc.DotNet.PracticaMaD.Web.HTTP.Session;
using Es.Udc.DotNet.PracticaMaD.Web.HTTP.Util.IoC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Es.Udc.DotNet.PracticaMaD.Web.Pages.Order
{
    public partial class CreateOrder : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                IIoCManager iocManager =
                   (IIoCManager)HttpContext.Current.Application["managerIoC"];

                IUserService userService = iocManager.Resolve<IUserService>();

                lblIdentifierError.Visible = false;
                //TODO Combobox(con fav selecionada) tarjeta favorita (añadir otra), poner input (copiar de update), boton de realizar pedido

                try
                {
                    UserRegisterDetailsDto userDto =
                        SessionManager.FindUserProfileDetails(Context);

                    txtPostalAddress.Text = userDto.postalAddress;

                    long userId = SessionManager.GetUserSession(Context).UserProfileId;

                    List<CreditCardDto> creditCards = userService.FindCreditCardsByUserId(userId);
                    CreditCardDto creditCardFav = userService.FindFavCreditCardByUserId(userId);

                    /* Combo box initialization */
                    UpdateComboCreditCard(creditCards, creditCardFav);
                }
                catch (Exception)
                {

                }
            }

        }
        private void UpdateComboCreditCard(List<CreditCardDto> creditCards, CreditCardDto creditCardFav)
        {
            comboCreditCard.DataSource = creditCards;
            comboCreditCard.DataTextField = "number";
            comboCreditCard.DataValueField = "creditCardId";
            comboCreditCard.DataBind();
            comboCreditCard.SelectedValue = creditCardFav.creditCardId.ToString();
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
                    Response.ApplyAppPathModifier("~/Pages/MainPage.aspx"));
            }
            catch (InvalidOperationException ex)
            {

                lblIdentifierError.Visible = true;
                lblIdentifierError.Text = ex.Message.ToString();
            }

        }

    }
}