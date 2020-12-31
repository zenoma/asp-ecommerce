<%@ Page Title="" Language="C#" MasterPageFile="~/ECommerce.Master" AutoEventWireup="true" CodeBehind="ShowOrderItemsByOrderId.aspx.cs" Inherits="Es.Udc.DotNet.PracticaMaD.Web.Pages.Cart.ShowOrdersItemsByOrderId" %>

<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder_BodyContent" runat="server">
    
    <form id="form" runat="server">
        <h1>
            <asp:Localize ID="titlePage" meta:resourcekey="titlePage" runat="server"></asp:Localize>
        </h1>
        <div class="containerErrors">
            <asp:Label ID="lblIdentifierError" runat="server" CssClass="errorMessage" meta:resourcekey="lblIdentifierError" />
            <asp:Label ID="lblNoOrderItems" runat="server" CssClass="errorMessage" meta:resourcekey="lblNoOrderItems"></asp:Label>
        </div>
        <asp:GridView ID="gvOrderItems" runat="server" AutoGenerateColumns="False" Width="505px">
            <Columns>
                <asp:BoundField DataField="productName" HeaderText="Product name" />
                <asp:BoundField DataField="units" HeaderText="Quantity" />
                <asp:BoundField DataField="unitPrice" HeaderText="Product price" />
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
    </form>
</asp:Content>
