<%@ Page Title="" Language="C#" MasterPageFile="~/ECommerce.Master" AutoEventWireup="true" CodeBehind="ShowOrderItemsByOrderId.aspx.cs" Inherits="Es.Udc.DotNet.PracticaMaD.Web.Pages.Cart.ShowOrdersItemsByOrderId" %>

<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder_BodyContent" runat="server">
    <br />
    <asp:Label ID="lblIdentifierError" runat="server" CssClass="errorMessage" meta:resourcekey="lblIdentifierError" />
    <form runat="server">
        <p>
            <asp:Label ID="lblNoOrderItems" meta:resourcekey="lblNoOrderItems" runat="server"></asp:Label>
        </p>
        <asp:GridView ID="gvOrderItems" runat="server" AutoGenerateColumns="False" Width="505px">
            <Columns>
                <asp:BoundField DataField="productName" HeaderText="Product name" />
                <asp:BoundField DataField="units" HeaderText="Quantity" />
                <asp:BoundField DataField="unitPrice" HeaderText="Product price" />
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
