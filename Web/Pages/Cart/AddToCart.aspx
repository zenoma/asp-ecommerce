<%@ Page Title="" Language="C#" MasterPageFile="~/ECommerce.Master" AutoEventWireup="true" CodeBehind="AddToCart.aspx.cs" Inherits="Es.Udc.DotNet.PracticaMaD.Web.Pages.Cart.AddToCart" %>

<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder_BodyContent" runat="server">
        <h1>
            <asp:Localize ID="titlePage" meta:resourcekey="titlePage" runat="server"></asp:Localize>
        </h1>
        <div class="containerErrors">
            <asp:Label ID="lblIdentifierError" runat="server" CssClass="errorMessage" meta:resourcekey="lblIdentifierError" />
        </div>
        <asp:Table ID="tbProductDetails" CssClass="productDetails" runat="server">
            <asp:TableRow runat="server">
                <asp:TableHeaderCell ID="cellCaptionProductName" runat="server" Text="<%$ Resources:Common, prodName_Text %>"></asp:TableHeaderCell>
                <asp:TableCell ID="cellProductName" runat="server"></asp:TableCell>
            </asp:TableRow>

            <asp:TableRow runat="server">
                <asp:TableHeaderCell ID="cellCaptionUnitPrice" runat="server" Text="<%$ Resources:Common, prodUnitPrice_Text %>"></asp:TableHeaderCell>
                <asp:TableCell ID="cellUnitPrice" DataFormatString="{0:c}" runat="server"></asp:TableCell>
            </asp:TableRow>

            <asp:TableRow runat="server">
                <asp:TableHeaderCell ID="cellCaptionProductCategory" runat="server" Text="<%$ Resources:Common, prodCategory_Text %>"></asp:TableHeaderCell>
                <asp:TableCell ID="cellProductCategory" runat="server"></asp:TableCell>
            </asp:TableRow>

            <asp:TableRow runat="server">
                <asp:TableHeaderCell ID="cellCaptionStockUnits" runat="server" Text="<%$ Resources:Common, prodStockUnits_Text %>"></asp:TableHeaderCell>
                <asp:TableCell ID="cellStockUnits" runat="server"></asp:TableCell>
            </asp:TableRow>

            <asp:TableRow runat="server">
                <asp:TableHeaderCell ID="cellCaptionProductDate" runat="server" Text="<%$ Resources:Common, prodDate_Text%>"></asp:TableHeaderCell>
                <asp:TableCell ID="cellProductDate" runat="server"></asp:TableCell>
            </asp:TableRow>

        </asp:Table>
        <div class="field">
            <span class="label">
                <asp:Localize ID="lclQuantity" runat="server" meta:resourcekey="lclQuantity" />
            </span><span
                class="entry">
                <asp:TextBox ID="txtQuantity" runat="server" Columns="16"
                    meta:resourcekey="txtQuantity"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvQuantity" runat="server" ControlToValidate="txtQuantity"
                    Font-Bold="true" ForeColor="Red" Display="Dynamic" Text="<%$ Resources:Common, mandatoryField %>"
                    meta:resourcekey="rfvQuantity"></asp:RequiredFieldValidator>
                <asp:CompareValidator ID="rfvQuantityPositive" runat="server" ValueToCompare="0" ControlToValidate="txtQuantity"
                    Font-Bold="true" ForeColor="Red" Text="<%$ Resources:Common, positiveField %>" Operator="GreaterThan" Type="Integer"></asp:CompareValidator>
                <asp:Label ID="lblQuantityError" runat="server" Font-Bold="true" ForeColor="Red" Style="position: relative"
                    Visible="False" meta:resourcekey="lblQuantityError"></asp:Label></span>
            <span class="label">
                <asp:CheckBox ID="ckToPresent" Text="To Present?" runat="server" />
            </span>
        </div>
        <div class="button">
            <asp:Button ID="btnAddToCart" runat="server" OnClick="BtnAddToCart" meta:resourcekey="btnAddToCart" />
        </div>
</asp:Content>
