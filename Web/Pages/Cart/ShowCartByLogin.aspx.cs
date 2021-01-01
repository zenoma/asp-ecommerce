using Es.Udc.DotNet.PracticaMaD.Model.ECommerceServices.CartService;
using Es.Udc.DotNet.PracticaMaD.Web.HTTP.Session;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

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
                //TODO Sacar nombre del producto
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