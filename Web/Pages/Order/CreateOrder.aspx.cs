using Es.Udc.DotNet.PracticaMaD.Model.ECommerceServices.UserService;
using Es.Udc.DotNet.PracticaMaD.Web.HTTP.Session;
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
            lblIdentifierError.Visible = false;
            //TODO Combobox(con fav selecionada) tarjeta favorita (añadir otra), poner input (copiar de update), boton de realizar pedido

            try
            {
                UserRegisterDetailsDto userDto =
                    SessionManager.FindUserProfileDetails(Context);

                txtPostalAddress.Text = userDto.postalAddress;

                List<CreditCardDto> creditCards = SessionManager.FindCreditCardsByUserId(Context);
                CreditCardDto creditCardFav = SessionManager.FindFavCreditCardByUserId(Context);

                this.comboCreditCard.SelectedValue = creditCardFav.creditCardId.ToString();
                /* Combo box initialization */
                UpdateComboCreditCard(creditCards);
            }
            catch (Exception)
            {

            }

        }
        private void UpdateComboCreditCard(List<CreditCardDto> creditCards)
        {
            this.comboCreditCard.DataSource = creditCards;
            this.comboCreditCard.DataTextField = "creditCardId";
            this.comboCreditCard.DataValueField = "creditCardId";
            this.comboCreditCard.DataBind();
        }

        protected void BtnCreateOrder(object sender, EventArgs e)
        {

            if (Page.IsValid)
            {
                try
                {
                    SessionManager.CreateOrder(Context, Int64.Parse(comboCreditCard.Text), lclPostalAddress.Text);
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
}