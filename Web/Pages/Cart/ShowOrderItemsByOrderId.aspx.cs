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
    public partial class ShowOrdersItemsByOrderId : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int orderId;

            lnkPrevious.Visible = false;
            lnkNext.Visible = false;
            lblNoOrderItems.Visible = false;


            /* Get OrderId*/
            orderId = Int32.Parse(Request.Params.Get("orderId"));


            /* Get the Service */
            IIoCManager iocManager = (IIoCManager)HttpContext.Current.Application["managerIoC"];
            IOrderService orderService = iocManager.Resolve<IOrderService>();

            /* Get Accounts Info */
            try
            { 
                OrderDto orderDto = orderService.FindByOrderId(orderId);

                this.gvOrderItems.DataSource = orderDto.orderItems;
                this.gvOrderItems.DataBind();
            }
            catch (InstanceNotFoundException)
            {
                lblIdentifierError.Visible = true;
                lblIdentifierError.Text = GetLocalResourceObject("InstanceNotFound.Text").ToString();
            }
        }
    }
}