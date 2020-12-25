using Es.Udc.DotNet.ModelUtil.Exceptions;
using Es.Udc.DotNet.ModelUtil.IoC;
using Es.Udc.DotNet.PracticaMaD.Model.ECommerceServices.OrderService;
using Es.Udc.DotNet.PracticaMaD.Web.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Es.Udc.DotNet.PracticaMaD.Web.Pages.Cart
{
    public partial class ShowOrdersByLogin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int startIndex, count;

            lnkPrevious.Visible = false;
            lnkNext.Visible = false;
            lblNoUserOrders.Visible = false;

            /* Get User Identifier passed as parameter in the request from
             * the previous page
             */
            string login = Request.Params.Get("login");

            /* Get Start Index */
            try
            {
                startIndex = Int32.Parse(Request.Params.Get("startIndex"));
            }
            catch (ArgumentNullException)
            {
                startIndex = 0;
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
            IOrderService orderService = iocManager.Resolve<IOrderService>();

            /* Get Accounts Info */
            try
            {
                OrderBlock orderBlock = orderService.FindByUserLogin(login,count,startIndex);
                if (orderBlock.Orders.Count == 0)
                {
                    lblNoUserOrders.Visible = true;
                    return;
                }

                this.gvUserOrders.DataSource = orderBlock.Orders;
                this.gvUserOrders.DataBind();

                /* "Previous" link */
                if ((startIndex - count) >= 0)
                {
                    String url =
                        Settings.Default.ECommerce_applicationURL +
                        "/Pages/ShowAccountsByUserID.aspx" + "?login=" + login +
                        "&startIndex=" + (startIndex - count) + "&count=" +
                        count;

                    this.lnkPrevious.NavigateUrl =
                        Response.ApplyAppPathModifier(url);
                    this.lnkPrevious.Visible = true;
                }

                /* "Next" link */
                if (orderBlock.existMoreOrders)
                {
                    String url =
                        Settings.Default.ECommerce_applicationURL +
                        "/Pages/ShowAccountsByUserID.aspx" + "?login=" + login +
                        "&startIndex=" + (startIndex + count) + "&count=" +
                        count;

                    this.lnkNext.NavigateUrl =
                        Response.ApplyAppPathModifier(url);
                    this.lnkNext.Visible = true;
                }
            }
            catch (InstanceNotFoundException)
            { 
                lblIdentifierError.Visible = true;
                lblIdentifierError.Text = GetLocalResourceObject("InstanceNotFound.Text").ToString();
            }

            
        }
    }
}