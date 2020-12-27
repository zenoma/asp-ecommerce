﻿<%@ Page Title="" Language="C#" MasterPageFile="~/ECommerce.Master" AutoEventWireup="true" CodeBehind="ShowOrdersByLogin.aspx.cs" Inherits="Es.Udc.DotNet.PracticaMaD.Web.Pages.Cart.ShowOrdersByLogin" %>

<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder_BodyContent" runat="server">
    <asp:Label ID="lblIdentifierError" runat="server" CssClass="errorMessage" meta:resourcekey="lblIdentifierError" />

    <br />
    <form runat="server">
        <p>
            <asp:Label ID="lblNoUserOrders" meta:resourcekey="lblNoUserOrders" runat="server"></asp:Label>
        </p>
        <asp:GridView ID="gvUserOrders" runat="server" AutoGenerateColumns="False" Width="505px">
            <Columns>
                <asp:HyperLinkField DataTextField="orderId" HeaderText="Id" DataNavigateUrlFields="orderId" DataNavigateUrlFormatString="./ShowOrderItemsByOrderId.aspx?orderId={0}" />
                <asp:BoundField DataField="orderAlias" HeaderText="Order Alias" />
                <asp:BoundField DataField="address" HeaderText="Sended address" />
                <asp:BoundField DataField="orderDate" HeaderText="Order Date" />
                <asp:BoundField DataField="orderItems.Count" HeaderText="Total Items" />
                <asp:BoundField DataField="price" HeaderText="Total Price" />
                <asp:BoundField DataField="creditCardNumber" HeaderText="Payed with" />
            </Columns>
        </asp:GridView>
    </form>
    <br />
    <!-- "Previous" and "Next" links. -->
    <div class="previousNextLinks">
        <span class="previousLink">
            <asp:HyperLink ID="lnkPrevious" Text="<%$ Resources:Common, Previous %>" runat="server"
                Visible="False"></asp:HyperLink>
        </span><span class="nextLink">
            <asp:HyperLink ID="lnkNext" Text="<%$ Resources:Common, Next %>" runat="server" Visible="False"></asp:HyperLink>
        </span>
    </div>
    <br />
    <br />
</asp:Content>
