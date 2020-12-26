<%@ Page Title="" Language="C#" MasterPageFile="~/ECommerce.Master" AutoEventWireup="true" CodeBehind="ShowCartByLogin.aspx.cs" Inherits="Es.Udc.DotNet.PracticaMaD.Web.Pages.Cart.ShowCartByLogin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder_MenuWelcome" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder_MenuExplanation" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder_MenuLinks" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder_BodyContent" runat="server"><asp:Label ID="lblIdentifierError" runat="server" CssClass="errorMessage" meta:resourcekey="lblIdentifierError" />
    <form runat="server">
        <p>
            <asp:Label ID="lblNoCartItems" meta:resourcekey="lblNoCartItems" runat="server"></asp:Label>
        </p
        <asp:GridView ID="gvOrderItems" runat="server" CssClass="orderItems" GridLines="None"
            AutoGenerateColumns="False" HorizontalAlign="Center">
        </asp:GridView>
    </form>
    <br />
</asp:Content>
