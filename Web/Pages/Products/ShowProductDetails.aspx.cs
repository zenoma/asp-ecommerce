using Es.Udc.DotNet.ModelUtil.IoC;
using Es.Udc.DotNet.PracticaMaD.Model.Services.ProductService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Es.Udc.DotNet.PracticaMaD.Web.Pages.Products
{
    public partial class ShowProductDetails : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            /* Get Keyword passed as parameter in the request from
             * the previous page
             */

            long productId = Convert.ToInt64(Request.Params.Get("productId"));

            /* Get the Service */
            IIoCManager iocManager = (IIoCManager)HttpContext.Current.Application["managerIoC"];
            IProductService productService = iocManager.Resolve<IProductService>();

            /* Get Accounts Info */
            ProductDetails productDetails = productService.FindProductDetails(productId);

            cellProductName.Text = productDetails.name;
            cellUnitPrice.Text = productDetails.unitPrice.ToString();
            cellStockUnits.Text = productDetails.stockUnits.ToString();
            cellProductDate.Text = productDetails.productDate.ToString();
            cellProductCategory.Text = productDetails.category;
            cellProductType.Text = productDetails.type;
        }
    }
}