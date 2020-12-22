using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Es.Udc.DotNet.PracticaMaD.Web.Pages.Products
{
    public partial class FindProducts : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void BtnFindClick(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                /* Get data. */
                //String identifierType = this.ddlFindBy.SelectedValue;
                String keywords = this.txtKeywords.Text;

                /* Do action. */
                    String url = String.Format("./ShowProducts.aspx?keywords={0}", keywords);
                    Response.Redirect(Response.ApplyAppPathModifier(url));
            }
        }
    }
}