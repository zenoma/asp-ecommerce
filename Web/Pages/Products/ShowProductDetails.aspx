<%@ Page Title="" Language="C#" MasterPageFile="~/ECommerce.Master" AutoEventWireup="true" CodeBehind="ShowProductDetails.aspx.cs" Inherits="Es.Udc.DotNet.PracticaMaD.Web.Pages.Products.ShowProductDetails" %>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder_BodyContent" runat="server">
    <asp:Table ID="tbProductDetails" runat="server">
        <asp:TableRow runat="server"> <%--Text="<%$ Resources:Common, prodName %>">--%>
            <asp:TableHeaderCell ID="cellCaptionProductName" runat="server" Text="Name"></asp:TableHeaderCell>
            <asp:TableCell ID="cellProductName" runat="server"></asp:TableCell>
        </asp:TableRow>

        <asp:TableRow runat="server"> <%--Text="<%$ Resources:Common, prodName %>">--%>
            <asp:TableHeaderCell ID="cellCaptionUnitPrice" runat="server" Text="Unit price"></asp:TableHeaderCell>
            <asp:TableCell ID="cellUnitPrice" runat="server"></asp:TableCell>
        </asp:TableRow>

        <asp:TableRow runat="server"> <%--Text="<%$ Resources:Common, prodName %>">--%>
            <asp:TableHeaderCell ID="cellCaptionStockUnits" runat="server" Text="Stock units"></asp:TableHeaderCell>
            <asp:TableCell ID="cellStockUnits" runat="server"></asp:TableCell>
        </asp:TableRow>

        <asp:TableRow runat="server"> <%--Text="<%$ Resources:Common, prodName %>">--%>
            <asp:TableHeaderCell ID="cellCaptionProductDate" runat="server" Text="Registration date"></asp:TableHeaderCell>
            <asp:TableCell ID="cellProductDate" runat="server"></asp:TableCell>
        </asp:TableRow>

        <asp:TableRow runat="server"> <%--Text="<%$ Resources:Common, prodName %>">--%>
            <asp:TableHeaderCell ID="cellCaptionProductCategory" runat="server" Text="Category"></asp:TableHeaderCell>
            <asp:TableCell ID="cellProductCategory" runat="server"></asp:TableCell>
        </asp:TableRow>

        <asp:TableRow runat="server"> <%--Text="<%$ Resources:Common, prodName %>">--%>
            <asp:TableHeaderCell ID="cellCaptionProductType" runat="server" Text="Type"></asp:TableHeaderCell>
            <asp:TableCell ID="cellProductType" runat="server"></asp:TableCell>
        </asp:TableRow>
    </asp:Table>
</asp:Content>
