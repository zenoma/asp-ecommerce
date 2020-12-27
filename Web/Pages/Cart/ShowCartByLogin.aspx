<%@ Page Title="" Language="C#" MasterPageFile="~/ECommerce.Master" AutoEventWireup="true" CodeBehind="ShowCartByLogin.aspx.cs" Inherits="Es.Udc.DotNet.PracticaMaD.Web.Pages.Cart.ShowCartByLogin" %>

<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder_BodyContent" runat="server">
    <asp:Label ID="lblIdentifierError" runat="server" CssClass="errorMessage" meta:resourcekey="lblIdentifierError" />
    <form runat="server">
        <p>
            <asp:Label ID="lblNoCartItems" meta:resourcekey="lblNoCartItems" runat="server"></asp:Label>
        </p>
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
