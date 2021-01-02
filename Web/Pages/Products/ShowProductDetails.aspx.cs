using Es.Udc.DotNet.ModelUtil.IoC;
using Es.Udc.DotNet.PracticaMaD.Model.Services.ProductService;
using Es.Udc.DotNet.PracticaMaD.Web.HTTP.Session;
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
            UserSession user = SessionManager.GetUserSession(Context);
            if (user!=null && user.Role == "ADMIN")
            {
                btnUpdateProduct.Visible = true;
            }

            /* Get Product ID passed as parameter in the request from
             * the previous page
             */
            long productId = Convert.ToInt64(Request.Params.Get("productId"));

            /* Get the Service */
            IIoCManager iocManager = (IIoCManager)HttpContext.Current.Application["managerIoC"];
            IProductService productService = iocManager.Resolve<IProductService>();

            /* Get Product Info */
            ProductDetails productDetails = productService.FindProductDetails(productId);

            cellProductName.Text = productDetails.name;
            cellUnitPrice.Text = productDetails.unitPrice.ToString("C");
            cellProductCategory.Text = productDetails.category;
            cellStockUnits.Text = productDetails.stockUnits.ToString();
            cellProductDate.Text = productDetails.productDate.ToString("dd/MM/yyyy");

            if (productDetails.type == "Music")
            {
                // Fila de Artist
                TableRow rowArtist = new TableRow();
                TableHeaderCell cellCaptionArtist = new TableHeaderCell();
                cellCaptionArtist.Text = GetGlobalResourceObject("Common", "prodArtist_Text").ToString();

                TableCell cellArtist = new TableCell();
                cellArtist.Text = productDetails.artist;

                rowArtist.Cells.Add(cellCaptionArtist);
                rowArtist.Cells.Add(cellArtist);

                tbProductDetails.Rows.AddAt(1, rowArtist);

                tbProductDetails.DataBind();

                // Fila de Album
                TableRow rowAlbum = new TableRow();
                TableHeaderCell cellCaptionAlbum = new TableHeaderCell();
                cellCaptionAlbum.Text = GetGlobalResourceObject("Common", "prodAlbum_Text").ToString();

                TableCell cellAlbum = new TableCell();
                cellAlbum.Text = productDetails.album;

                rowAlbum.Cells.Add(cellCaptionAlbum);
                rowAlbum.Cells.Add(cellAlbum);                

                tbProductDetails.Rows.AddAt(2, rowAlbum);

                tbProductDetails.DataBind();

            }
            
            if (productDetails.type == "Movie")
            {
                // Fila de Director
                TableRow rowDirector = new TableRow();
                TableHeaderCell cellCaptionDirector = new TableHeaderCell();
                cellCaptionDirector.Text = GetGlobalResourceObject("Common", "prodDirector_Text").ToString();

                TableCell cellDirector = new TableCell();
                cellDirector.Text = productDetails.director;

                rowDirector.Cells.Add(cellCaptionDirector);
                rowDirector.Cells.Add(cellDirector);

                tbProductDetails.Rows.AddAt(1, rowDirector);

                tbProductDetails.DataBind();

                // Fila de MovieDate
                TableRow rowMovieDate = new TableRow();
                TableHeaderCell cellCaptionMovieDate = new TableHeaderCell();
                cellCaptionMovieDate.Text = GetGlobalResourceObject("Common", "prodPremiereDate_Text").ToString();

                TableCell cellMovieDate = new TableCell();
                cellMovieDate.Text = productDetails.movieDate.Date.ToString("yyyy");

                rowMovieDate.Cells.Add(cellCaptionMovieDate);
                rowMovieDate.Cells.Add(cellMovieDate);

                tbProductDetails.Rows.AddAt(2, rowMovieDate);

                tbProductDetails.DataBind();
            }

            if (productDetails.type == "Book")
            {
                // Fila de Author
                TableRow rowAuthor = new TableRow();
                TableHeaderCell cellCaptionAuthor = new TableHeaderCell();
                cellCaptionAuthor.Text = GetGlobalResourceObject("Common", "prodAuthor_Text").ToString();

                TableCell cellAuthor = new TableCell();
                cellAuthor.Text = productDetails.author;

                rowAuthor.Cells.Add(cellCaptionAuthor);
                rowAuthor.Cells.Add(cellAuthor);

                tbProductDetails.Rows.AddAt(1, rowAuthor);

                tbProductDetails.DataBind();

                // Fila de EditionNumber
                TableRow rowEditionNumber = new TableRow();
                TableHeaderCell cellCaptionEditionNumber = new TableHeaderCell();
                cellCaptionEditionNumber.Text = GetGlobalResourceObject("Common", "prodEditionNumber_Text").ToString();

                TableCell cellEditionNumber = new TableCell();
                cellEditionNumber.Text = productDetails.editionNumber.ToString();

                rowEditionNumber.Cells.Add(cellCaptionEditionNumber);
                rowEditionNumber.Cells.Add(cellEditionNumber);

                tbProductDetails.Rows.AddAt(2, rowEditionNumber);

                tbProductDetails.DataBind();

                // Fila de Isbn
                TableRow rowIsbn = new TableRow();
                TableHeaderCell cellCaptionIsbn = new TableHeaderCell();
                cellCaptionIsbn.Text = GetGlobalResourceObject("Common", "prodIsbn_Text").ToString();

                TableCell cellIsbn = new TableCell();
                cellIsbn.Text = productDetails.isbn.ToString();

                rowIsbn.Cells.Add(cellCaptionIsbn);
                rowIsbn.Cells.Add(cellIsbn);

                tbProductDetails.Rows.AddAt(3, rowIsbn);

                tbProductDetails.DataBind();
            }
        }

        //SOLO PUEDE EJECUTAR ESTE BOTON ROL ADMIN
        protected void btnUpdateProduct_Click(object sender, EventArgs e)
        {
            /* Get Product ID passed as parameter in the request from
             * the previous page
             */
            long productId = Convert.ToInt64(Request.Params.Get("productId"));

            /* Do action. */
            String url = String.Format("./UpdateProductDetails.aspx?productId={0}", productId);
            Response.Redirect(Response.ApplyAppPathModifier(url));
        }

        protected void btnCommentProduct_Click(object sender, EventArgs e)
        {

            /* Get Product ID passed as parameter in the request from
             * the previous page
             */
            long productId = Convert.ToInt64(Request.Params.Get("productId"));

            /* Do action. */
            String url = String.Format("~/Pages/Comment/CommentProduct.aspx?productId={0}", productId);
            Response.Redirect(Response.ApplyAppPathModifier(url));
        }
    }
}