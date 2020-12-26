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
            if(Context.Session["userCart"] == null) 
            { 
                lblNoCartItems.Visible = true; 
            }
           
        }
    }
}