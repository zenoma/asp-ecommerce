<%@ Page Title="" Language="C#" MasterPageFile="~/ECommerce.Master" AutoEventWireup="true" CodeBehind="ShowOrdersByLogin.aspx.cs" Inherits="Es.Udc.DotNet.PracticaMaD.Web.Pages.Cart.ShowOrdersByLogin" %>

<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder_BodyContent" runat="server">
        <h1>
            <asp:Localize ID="titlePage" meta:resourcekey="titlePage" runat="server"></asp:Localize>
        </h1>
        <div class="containerErrors">
            <asp:Label ID="lblIdentifierError" runat="server" CssClass="errorMessage" meta:resourcekey="lblIdentifierError" />
            <asp:Label ID="lblNoUserOrders" runat="server" CssClass="errorMessage" meta:resourcekey="lblNoUserOrders"></asp:Label>
        </div>
        <asp:GridView ID="gvUserOrders" runat="server" CssClass="table-allwidth" AutoGenerateColumns="False" GridLines="None">
            <Columns>
                <asp:BOundField DataField="orderId" HeaderText="<%$ Resources:Common, orderId %>" />
                <asp:HyperLinkField DataTextField="orderAlias" HeaderText="<%$ Resources:Common, orderAlias %>" DataNavigateUrlFields="orderId" DataNavigateUrlFormatString="./ShowOrderItemsByOrderId.aspx?orderId={0}" />
                <asp:BoundField DataField="address" HeaderText="<%$ Resources:Common, address %>" />
                <asp:BoundField DataField="orderDate" HeaderText="<%$ Resources:Common, orderDate %>" />
                <asp:BoundField DataField="orderItems.Count" HeaderText="<%$ Resources:Common, quantity %>" />
                <asp:BoundField DataField="price" HeaderText="<%$ Resources:Common, totalPrice %>" />
                <asp:BoundField DataField="creditCardNumber" HeaderText="<%$ Resources:Common, payedWith %>" />
            </Columns>
        </asp:GridView>
        <div class="previousNextLinks">
            <span class="previousLink">
                <asp:HyperLink ID="lnkPrevious" Text="<%$ Resources:Common, Previous %>" runat="server"
                    Visible="False"></asp:HyperLink>
            </span><span class="nextLink">
                <asp:HyperLink ID="lnkNext" Text="<%$ Resources:Common, Next %>" runat="server" Visible="False"></asp:HyperLink>
            </span>
        </div>
</asp:Content>
