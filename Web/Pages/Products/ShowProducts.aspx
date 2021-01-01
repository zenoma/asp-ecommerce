﻿<%@ Page Title="" Language="C#" MasterPageFile="~/ECommerce.Master" AutoEventWireup="true" CodeBehind="ShowProducts.aspx.cs" Inherits="Es.Udc.DotNet.PracticaMaD.Web.Pages.Products.ShowProducts" %>

<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder_BodyContent" runat="server">
    <form id="formShowProductsSearch" runat="server">
        <h1>
            <asp:Localize ID="titlePage" meta:resourcekey="titlePage" runat="server"></asp:Localize>
        </h1>
        <div class="containerErrors">
            <asp:Label ID="lblNoProductFound" runat="server" CssClass="errorMessage" Text="<%$ Resources:Common, lblNoProductFound %>"></asp:Label>
        </div>
        <asp:GridView ID="gvProducts" runat="server" AutoGenerateColumns="False" Width="505px">
            <Columns>
                <asp:HyperLinkField DataTextField="name" HeaderText="<%$ Resources:Common, prodName_Text %>" DataNavigateUrlFields="productId" DataNavigateUrlFormatString="./ShowProductDetails.aspx?productID={0}" />
                <asp:BoundField DataField="category" HeaderText="<%$ Resources:Common, prodCategory_Text %>" />
                <asp:BoundField DataField="productDate" HeaderText="<%$ Resources:Common, prodDate_Text %>" DataFormatString="{0:dd/MM/yyyy}" />
                <asp:BoundField DataField="unitPrice" HeaderText="<%$ Resources:Common, prodUnitPrice_Text %>" DataFormatString="{0:C}" />
                <asp:BoundField DataField="stockUnits" HeaderText="<%$ Resources:Common, prodStockUnits_Text %>" />
                <asp:HyperLinkField Text="<%$ Resources:Common, addLink %>" DataNavigateUrlFields="productId" DataNavigateUrlFormatString="~/Pages/Cart/AddToCart.aspx?productId={0}" />                
            </Columns>
        </asp:GridView>
        <div class="previousNextLinks">
        <span class="previousLink"><%--Text="<%$ Resources:Common, Previous %>"--%>
            <asp:HyperLink ID="lnkPrevious" runat="server" Text="<%$ Resources:Common, Previous %>"
                Visible="False"></asp:HyperLink>
        </span><span class="nextLink"><%--Text="<%$ Resources:Common, Next %>"--%>
            <asp:HyperLink ID="lnkNext" runat="server" Visible="False" Text="<%$ Resources:Common, Next %>"></asp:HyperLink>
        </span>
    </div>
    </form>
</asp:Content>
