﻿<%@ Page Title="" Language="C#" MasterPageFile="~/ECommerce.Master" AutoEventWireup="true" CodeBehind="ShowProductDetails.aspx.cs" Inherits="Es.Udc.DotNet.PracticaMaD.Web.Pages.Products.ShowProductDetails" %>

<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder_BodyContent" runat="server">
    <form id="form1" runat="server">
        <asp:Table ID="tbProductDetails" runat="server">
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
                <asp:TableHeaderCell ID="cellCaptionProductDate" runat="server" Text="<%$ Resources:Common, prodDate_Text %>"></asp:TableHeaderCell>
                <asp:TableCell ID="cellProductDate" runat="server"></asp:TableCell>
            </asp:TableRow>
        </asp:Table>
        <asp:Button ID="btnUpdateProduct" runat="server" Text="<%$ Resources:Common, btnUpdateProduct_Text %>" OnClick="btnUpdateProduct_Click" Height="22px" Width="103px" />
    </form>
</asp:Content>
