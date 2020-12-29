using Es.Udc.DotNet.ModelUtil.IoC;
using Es.Udc.DotNet.PracticaMaD.Model.ECommerceServices.ProductService;
using Es.Udc.DotNet.PracticaMaD.Model.Services.ProductService;
using Es.Udc.DotNet.PracticaMaD.Web.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Es.Udc.DotNet.PracticaMaD.Web.Pages.Products
{
    public partial class ShowProducts : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int startIndex, count;

            lnkPrevious.Visible = false;
            lnkNext.Visible = false;
            lblNoProductFound.Visible = false;

            /* Get Keyword passed as parameter in the request from
             * the previous page
             */
            String keywords = Request.Params.Get("keywords");
            long category = Convert.ToInt64(Request.Params.Get("category"));

            /* Get Start Index */
            try
            {
                startIndex = Int32.Parse(Request.Params.Get("startIndex"));
            }
            catch (ArgumentNullException)
            {
                startIndex = 1;
            }

            /* Get Count */
            try
            {
                count = Int32.Parse(Request.Params.Get("count"));
            }
            catch (ArgumentNullException)
            {
                count = Settings.Default.ECommerce_defaultCount;
            }

            /* Get the Service */
            IIoCManager iocManager = (IIoCManager)HttpContext.Current.Application["managerIoC"];
            IProductService productService = iocManager.Resolve<IProductService>();

            /* Get Accounts Info */
            ProductBlock productBlock =
                productService.FindProducts(keywords, category, startIndex, count);

            if (productBlock.Products.Count == 0)
            {
                lblNoProductFound.Visible = true;
                return;
            }

            this.gvProducts.DataSource = productBlock.Products;
            this.gvProducts.DataBind();

            /* "Previous" link */
            if ((startIndex - 1) > 0)
            {
                String url = /*Settings.Default.MiniBank_applicationURL +*/
                    "/Pages/Products/ShowProducts.aspx" + "?keywords=" + keywords + "&category=" + category +
                    "&startIndex=" + (startIndex - 1) + "&count=" +
                    count;

                this.lnkPrevious.NavigateUrl =
                    Response.ApplyAppPathModifier(url);
                this.lnkPrevious.Visible = true;
            }

            /* "Next" link */
            if (productBlock.ExistMoreProducts)
            {
                String url = /*Settings.Default.MiniBank_applicationURL +*/
                    "/Pages/Products/ShowProducts.aspx" + "?keywords=" + keywords + "&category=" + category +
                    "&startIndex=" + (startIndex + 1) + "&count=" +
                    count;

                this.lnkNext.NavigateUrl =
                    Response.ApplyAppPathModifier(url);
                this.lnkNext.Visible = true;
            }
        }
        protected void BtnAddToCartClick(object sender, EventArgs e)
        {
        }
    }
}