<%@ Page Title="" Language="C#" MasterPageFile="~/ECommerce.Master" AutoEventWireup="true" CodeBehind="ShowCartByLogin.aspx.cs" Inherits="Es.Udc.DotNet.PracticaMaD.Web.Pages.Cart.ShowCartByLogin" %>

<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder_BodyContent" runat="server">
    <form runat="server">
        <h1>
            <asp:Localize ID="titlePage" meta:resourcekey="titlePage" runat="server"></asp:Localize>
        </h1>
        <div class="containerErrors">
            <asp:Label ID="lblNoCartItems" runat="server" CssClass="errorMessage" meta:resourcekey="lblNoCartItems"></asp:Label>
            <asp:Label ID="lblIdentifierError" runat="server" CssClass="errorMessage" meta:resourcekey="lblIdentifierError" />
        </div>
        <asp:GridView ID="gvOrderItems" runat="server" AutoGenerateColumns="False" Width="505px">
            <Columns>
                <asp:HyperLinkField DataTextField="productId" HeaderText="Id" DataNavigateUrlFields="productId" DataNavigateUrlFormatString="~/Pages/Products/ShowProductDetails.aspx?productId={0}" />
                <asp:BoundField DataField="quantity" HeaderText="Quantity" />
                <asp:CheckBoxField DataField="toPresent" HeaderText="To Present" />
            </Columns>
        </asp:GridView>
        <asp:HyperLink Text="Buy Cart" CssClass="buyLink" NavigateUrl="~/Pages/Order/CreateOrder.aspx" runat="server" />
    </form>
    <br />
</asp:Content>
