using Es.Udc.DotNet.PracticaMaD.Web.HTTP.Session;
using System;

namespace Es.Udc.DotNet.PracticaMaD.Web.Pages.Cart
{
    public partial class DeleteFromCart : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int productId = Int32.Parse(Request.Params.Get("productID"));

            SessionManager.RemoveProductFromCart(Context, productId);
            Response.Redirect("~/Pages/Cart/ShowCartByLogin.aspx");
        }
    }
}