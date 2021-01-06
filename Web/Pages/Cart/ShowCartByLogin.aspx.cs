using Es.Udc.DotNet.PracticaMaD.Model.ECommerceServices.CartService;
using System;

namespace Es.Udc.DotNet.PracticaMaD.Web.Pages.Cart
{
    public partial class ShowCartByLogin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lblNoCartItems.Visible = false;
            lnkBuyCart.Visible = true;

            CartDto cartDto = (CartDto)Context.Session["userCart"];
            if (cartDto.cartLines.Count != 0)
            {
                this.gvOrderItems.DataSource = cartDto.cartLines;
                this.gvOrderItems.DataBind();
            }
            else
            {
                lblNoCartItems.Visible = true;
                lnkBuyCart.Visible = false;
            }

        }
    }
}