<%@ Page Title="" Language="C#" MasterPageFile="~/ECommerce.Master" AutoEventWireup="true" CodeBehind="AddToCart.aspx.cs" Inherits="Es.Udc.DotNet.PracticaMaD.Web.Pages.Cart.AddToCart" %>

<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder_BodyContent" runat="server">
    <asp:Label ID="lblIdentifierError" runat="server" CssClass="errorMessage" meta:resourcekey="lblIdentifierError" />
    <form id="RegisterForm" method="post" runat="server">
        <asp:Table ID="tbProductDetails" runat="server">
            <asp:TableRow runat="server">
                <%--Text="<%$ Resources:Common, prodName %>">--%>
                <asp:TableHeaderCell ID="cellCaptionProductName" runat="server" Text="Name"></asp:TableHeaderCell>
                <asp:TableCell ID="cellProductName" runat="server"></asp:TableCell>
            </asp:TableRow>

            <asp:TableRow runat="server">
                <%--Text="<%$ Resources:Common, prodName %>">--%>
                <asp:TableHeaderCell ID="cellCaptionUnitPrice" runat="server" Text="Unit price"></asp:TableHeaderCell>
                <asp:TableCell ID="cellUnitPrice" DataFormatString="{0:c}" runat="server"></asp:TableCell>
            </asp:TableRow>

            <asp:TableRow runat="server">
                <%--Text="<%$ Resources:Common, prodName %>">--%>
                <asp:TableHeaderCell ID="cellCaptionProductCategory" runat="server" Text="Category"></asp:TableHeaderCell>
                <asp:TableCell ID="cellProductCategory" runat="server"></asp:TableCell>
            </asp:TableRow>

            <asp:TableRow runat="server">
                <%--Text="<%$ Resources:Common, prodName %>">--%>
                <asp:TableHeaderCell ID="cellCaptionStockUnits" runat="server" Text="Stock units"></asp:TableHeaderCell>
                <asp:TableCell ID="cellStockUnits" runat="server"></asp:TableCell>
            </asp:TableRow>

            <asp:TableRow runat="server">
                <%--Text="<%$ Resources:Common, prodName %>">--%>
                <asp:TableHeaderCell ID="cellCaptionProductDate" runat="server" Text="Registration date"></asp:TableHeaderCell>
                <asp:TableCell ID="cellProductDate" runat="server"></asp:TableCell>
            </asp:TableRow>

            <%--<asp:TableRow runat="server"> <%--Text="<%$ Resources:Common, prodName %>">
            <asp:TableHeaderCell ID="cellCaptionProductType" runat="server" Text="Type"></asp:TableHeaderCell>
            <asp:TableCell ID="cellProductType" runat="server"></asp:TableCell>
        </asp:TableRow>--%>
        </asp:Table>
        <div class="field">
            <span class="label">
                <asp:Localize ID="lclQuantity" runat="server" meta:resourcekey="lclQuantity" />
            </span><span
                class="entry">
                <asp:TextBox ID="txtQuantity" runat="server" Width="100px" Columns="16"
                    meta:resourcekey="txtQuantity"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvQuantity" runat="server" ControlToValidate="txtQuantity"
                    Display="Dynamic" Text="<%$ Resources:Common, mandatoryField %>"
                    meta:resourcekey="rfvQuantity"></asp:RequiredFieldValidator>
                <asp:CompareValidator ID="rfvQuantityPositive" runat="server" ValueToCompare="0" ControlToValidate="txtQuantity"
                    Text="<%$ Resources:Common, positiveField %>" Operator="GreaterThan" Type="Integer"></asp:CompareValidator>
                <asp:Label ID="lblQuantityError" runat="server" ForeColor="Red" Style="position: relative"
                    Visible="False" meta:resourcekey="lblQuantityError"></asp:Label></span>
            <span class="label">
                <asp:CheckBox ID="ckToPresent" Text="To Present?" runat="server" />
            </span>
        </div>
        <div class="button">
            <asp:Button ID="btnAddToCart" runat="server" OnClick="BtnAddToCart" meta:resourcekey="btnAddToCart" />
        </div>
    </form>
</asp:Content>
