using Es.Udc.DotNet.ModelUtil.Exceptions;
using Es.Udc.DotNet.ModelUtil.IoC;
using Es.Udc.DotNet.PracticaMaD.Model.ECommerceServices.CartService;
using Es.Udc.DotNet.PracticaMaD.Model.ECommerceServices.Exceptions;
using Es.Udc.DotNet.PracticaMaD.Web.HTTP.Session;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Es.Udc.DotNet.PracticaMaD.Web.Pages.Cart
{
    public partial class AddToCart : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void BtnAddToCart(object sender, EventArgs e)
        {
            int productId = Int32.Parse(Request.Params.Get("productID"));
            int quantity = Int32.Parse(txtQuantity.Text);
            try
            {
                SessionManager.AddProductToCart(Context, productId, quantity);

                Response.Redirect("~/Pages/Cart/ShowCartByLogin.aspx");

            }
            catch (InstanceNotFoundException)
            {
                lblIdentifierError.Visible = true;
                lblIdentifierError.Text = GetLocalResourceObject("InstanceNotFound.Text").ToString();
            }
            catch (OutOfStockProductException)
            {
                lblIdentifierError.Visible = true;
                lblIdentifierError.Text = GetLocalResourceObject("OutOfStockProductException.Text").ToString();
            }
        }
    }
}