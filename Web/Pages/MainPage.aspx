<%@ Page Title="" Language="C#" MasterPageFile="~/ECommerce.Master" AutoEventWireup="true" CodeBehind="MainPage.aspx.cs" Inherits="Es.Udc.DotNet.PracticaMaD.Web.Pages.MainPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder_BodyContent"
    runat="server">
    <asp:Localize ID="lclContent" runat="server" meta:resourcekey="lclContent" />
    <div id="sidebar">
        <ul>
            <li>
                <asp:HyperLink ID="lnkHome" runat="server"
                    meta:resourcekey="lnkHome" NavigateUrl="~/Pages/MainPage.aspx" /></li>
            <li>
                <asp:HyperLink ID="lnkShowOrdersByLogin" runat="server"
                    meta:resourcekey="lnkShowOrdersByLogin" NavigateUrl="~/Pages/Cart/ShowOrdersByLogin.aspx" /></li>
            <li>
                <asp:HyperLink ID="lnkShowOrderItemsByOrderId" runat="server"
                    meta:resourcekey="lnkShowOrderItemsByOrderId" NavigateUrl="~/Pages/Cart/ShowOrderItemsByOrderId.aspx" /></li>
        </ul>
    </div>
</asp:Content>
