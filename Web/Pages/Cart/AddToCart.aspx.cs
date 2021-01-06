using Es.Udc.DotNet.ModelUtil.Exceptions;
using Es.Udc.DotNet.ModelUtil.IoC;
using Es.Udc.DotNet.PracticaMaD.Model.ECommerceServices.Exceptions;
using Es.Udc.DotNet.PracticaMaD.Model.Services.ProductService;
using Es.Udc.DotNet.PracticaMaD.Web.HTTP.Session;
using System;
using System.Web;

namespace Es.Udc.DotNet.PracticaMaD.Web.Pages.Cart
{
    public partial class AddToCart : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            IIoCManager iocManager = (IIoCManager)HttpContext.Current.Application["managerIoC"];
            IProductService productService = iocManager.Resolve<IProductService>();

            /* Get Product Info */
            int productId = Int32.Parse(Request.Params.Get("productID"));
            ProductDetails productDetails = productService.FindProductDetails(productId);

            cellProductName.Text = productDetails.name;
            cellUnitPrice.Text = productDetails.unitPrice.ToString("C");
            cellProductCategory.Text = productDetails.category;
            cellStockUnits.Text = productDetails.stockUnits.ToString();
            cellProductDate.Text = productDetails.productDate.ToString("dd/MM/yyyy");
        }

        protected void BtnAddToCart(object sender, EventArgs e)
        {
            int productId = Int32.Parse(Request.Params.Get("productID"));
            int quantity = Int32.Parse(txtQuantity.Text);
            bool toPresent = ckToPresent.Checked;
            try
            {
                SessionManager.AddProductToCart(Context, productId, quantity, toPresent);

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