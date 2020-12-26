﻿using Es.Udc.DotNet.ModelUtil.IoC;
using Es.Udc.DotNet.PracticaMaD.Model.ECommerceServices.CategoryService;
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
            /* Get the Service */
            IIoCManager iocManager = (IIoCManager)HttpContext.Current.Application["managerIoC"];
            ICategoryService categoryService = iocManager.Resolve<ICategoryService>();

            /* Get Accounts Info */
            CategoryBlock categoryBlock = categoryService.ListAllCategories();

            //if (productBlock.Products.Count == 0)
            //{
            //    //lblNoUserAccounts.Visible = true;
            //    return;
            //}

            this.drpdCategory.DataSource = categoryBlock.Categories;
            this.drpdCategory.DataValueField = "categoryId";
            this.drpdCategory.DataTextField = "visualName";
            this.drpdCategory.DataBind();
        }

        protected void BtnFindClick(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                /* Get data. */
                //String identifierType = this.ddlFindBy.SelectedValue;
                String keywords = this.txtKeywords.Text;
                long category = Convert.ToInt64(this.drpdCategory.SelectedValue);

                /* Do action. */
                String url = String.Format("./ShowProducts.aspx?keywords={0}&category={1}", keywords, category);
                Response.Redirect(Response.ApplyAppPathModifier(url));
            }
        }
    }
}