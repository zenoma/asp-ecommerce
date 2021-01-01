using Es.Udc.DotNet.ModelUtil.IoC;
using Es.Udc.DotNet.PracticaMaD.Model;
using Es.Udc.DotNet.PracticaMaD.Model.ECommerceServices.CategoryService;
using Es.Udc.DotNet.PracticaMaD.Model.Services.ProductService;
using Es.Udc.DotNet.PracticaMaD.Web.HTTP.Session;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Es.Udc.DotNet.PracticaMaD.Web.Pages.Products
{
    public partial class UpdateProductDetails : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                /* Get Product ID passed as parameter in the request from
                 * the previous page
                 */
                long productId = Convert.ToInt64(Request.Params.Get("productId"));


                if (SessionManager.GetUserSession(Context).Role != "ADMIN")
                {
                    String url = String.Format("./ShowProductDetails.aspx?productID={0}", productId);
                    Response.Redirect(Response.ApplyAppPathModifier(url));
                }

                /* Get the Service */
                IIoCManager iocManager = (IIoCManager)HttpContext.Current.Application["managerIoC"];
                IProductService productService = iocManager.Resolve<IProductService>();

                /* Get the Category Service */
                ICategoryService categoryService = iocManager.Resolve<ICategoryService>();

                /* Get Product Info */
                ProductDetails productDetails = productService.FindProductDetails(productId);

                txtName.Text = productDetails.name;
                txtUnitPrice.Text = productDetails.unitPrice.ToString();
                txtStockUnits.Text = productDetails.stockUnits.ToString();

                /* Get Categories */
                CategoryBlock categoryBlock = categoryService.ListAllCategories();

                this.drpdCategory.DataSource = categoryBlock.Categories;
                this.drpdCategory.DataValueField = "categoryId";
                this.drpdCategory.DataTextField = "visualName";
                this.drpdCategory.DataBind();
                //Seleccionas en el dropdown la categoria del producto
                this.drpdCategory.Items.FindByText(productDetails.category).Selected = true;

                // Movie fields
                txtDirector.Text = productDetails.director;
                txtPremiereDate.Text = productDetails.movieDate.ToString("yyyy-MM-dd");

                // Ocultamos los div y desactivamos validadores
                // de los campos que no necesitamos
                if (productDetails.director == null)
                {
                    txtDirector.Visible = false;
                    lclDirector.Visible = false;
                    rfvDirector.Enabled = false;
                    director.Visible = false;

                    txtPremiereDate.Visible = false;
                    lclPremiereDate.Visible = false;
                    rfvPremiereDate.Enabled = false;
                    premiereDate.Visible = false;
                }

                // Music fields
                txtArtist.Text = productDetails.artist;
                txtAlbum.Text = productDetails.album;

                // Ocultamos los div y desactivamos validadores
                // de los campos que no necesitamos
                if (productDetails.artist == null)
                {
                    txtArtist.Visible = false;
                    lclArtist.Visible = false;
                    rfvArtist.Enabled = false;
                    artist.Visible = false;

                    txtAlbum.Visible = false;
                    lclAlbum.Visible = false;
                    rfvAlbum.Enabled = false;
                    album.Visible = false;
                }

                // Book fields
                txtAuthor.Text = productDetails.author;
                txtEditionNumber.Text = productDetails.editionNumber.ToString();
                txtIsbn.Text = productDetails.isbn;

                // Ocultamos los div y desactivamos validadores
                // de los campos que no necesitamos
                if (productDetails.author == null)
                {
                    txtAuthor.Visible = false;
                    lclAuthor.Visible = false;
                    rfvAuthor.Enabled = false;
                    author.Visible = false;

                    txtEditionNumber.Visible = false;
                    lclEditionNumber.Visible = false;
                    rfvEditionNumber.Enabled = false;
                    editionNumber.Visible = false;

                    txtIsbn.Visible = false;
                    lclIsbn.Visible = false;
                    rfvIsbn.Enabled = false;
                    isbn.Visible = false;
                }
            }
        }

        // SOLO ROL ADMIN
        protected void BtnUpdateProductClick(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                /* Get the Service */
                IIoCManager iocManager = (IIoCManager)HttpContext.Current.Application["managerIoC"];
                IProductService productService = iocManager.Resolve<IProductService>();

                /* Get data. */
                long productId = Convert.ToInt64(Request.Params.Get("productId"));

                //ProductDetails productDetails = productService.FindProductDetails(productId);

                String name = this.txtName.Text; ;
                long categoryId = Convert.ToInt64(this.drpdCategory.SelectedValue);
                double unitPrice = Convert.ToDouble(this.txtUnitPrice.Text);
                int stockUnits = int.Parse(this.txtStockUnits.Text);
                string album = this.txtAlbum.Text;
                string artist = this.txtArtist.Text;
                string director = this.txtDirector.Text;
                System.DateTime movieDate = DateTime.Parse(this.txtPremiereDate.Text);
                string isbn = this.txtIsbn.Text;
                int editionNumber = int.Parse(this.txtEditionNumber.Text);
                string author = this.txtAuthor.Text;

                productService.UpdateProduct(productId, new ProductDetails(productId, categoryId,
                    null, name, stockUnits, unitPrice, null, default, album, artist, director,
                    movieDate, isbn, editionNumber, author));

                /* Do action. */
                String url = String.Format("./ShowProductDetails.aspx?productID={0}", productId);
                Response.Redirect(Response.ApplyAppPathModifier(url));

                //Redirigir a SuccesfulOperation.aspx
            }
        }
    }
}