<%@ Page Title="" Language="C#" MasterPageFile="~/ECommerce.Master" AutoEventWireup="true" CodeBehind="ShowCartByLogin.aspx.cs" Inherits="Es.Udc.DotNet.PracticaMaD.Web.Pages.Cart.ShowCartByLogin" %>

<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder_BodyContent" runat="server">
        <h1>
            <asp:Localize ID="titlePage" meta:resourcekey="titlePage" runat="server"></asp:Localize>
        </h1>
        <div class="containerErrors">
            <asp:Label ID="lblNoCartItems" runat="server" CssClass="errorMessage" meta:resourcekey="lblNoCartItems"></asp:Label>
            <asp:Label ID="lblIdentifierError" runat="server" CssClass="errorMessage" meta:resourcekey="lblIdentifierError" />
        </div>
        <asp:GridView ID="gvOrderItems" runat="server" CssClass="table-allwidth" AutoGenerateColumns="False" GridLines="None">
            <Columns>
                <asp:HyperLinkField DataTextField="productId" HeaderText="Id" DataNavigateUrlFields="productId" DataNavigateUrlFormatString="~/Pages/Products/ShowProductDetails.aspx?productId={0}" />
                <asp:BoundField DataField="productName" HeaderText="Product Name" />
                <asp:BoundField DataField="quantity" HeaderText="Quantity" />
                <asp:BoundField DataField="unitPrice" HeaderText="Unit Price" />
                <asp:CheckBoxField DataField="toPresent" HeaderText="To Present" />
                <asp:HyperLinkField Text="Edit Item" DataNavigateUrlFields="productId" DataNavigateUrlFormatString="~/Pages/Cart/AddToCart.aspx?productId={0}" />
                <asp:HyperLinkField Text="Delete Item" DataNavigateUrlFields="productId" DataNavigateUrlFormatString="~/Pages/Cart/DeleteFromCart.aspx?productId={0}" />
            </Columns>
        </asp:GridView>
        <asp:HyperLink ID="lnkBuyCart" Text="Buy Cart" CssClass="buyLink" NavigateUrl="~/Pages/Order/CreateOrder.aspx" runat="server" />
    <br />
</asp:Content>
