﻿<%@ Page Title="" Language="C#" MasterPageFile="~/ECommerce.Master" AutoEventWireup="true" CodeBehind="ShowProductDetails.aspx.cs" Inherits="Es.Udc.DotNet.PracticaMaD.Web.Pages.Products.ShowProductDetails" %>

<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder_BodyContent" runat="server">
        <h1>
            <asp:Localize ID="titlePage" meta:resourcekey="titlePage" runat="server"></asp:Localize>
        </h1>
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
                <asp:TableHeaderCell ID="cellCaptionProductDate" runat="server" Text="<%$ Resources:Common, prodDate_Text %>"></asp:TableHeaderCell>
                <asp:TableCell ID="cellProductDate" runat="server"></asp:TableCell>
            </asp:TableRow>
        </asp:Table>
        <asp:Label ID="test" runat="server"></asp:Label>
        
        <asp:Button ID="btnShowComments" Visible="false" runat="server" Text="<%$ Resources:Common, btnShowComments_Text %>" OnClick="btnShowComments_Click" />
        <asp:Button ID="btnCommentProduct" runat="server" Text="<%$ Resources:Common, btnCommentProduct_Text %>" OnClick="btnCommentProduct_Click" />
        <asp:Button ID="btnUpdateProduct" Visible="false" runat="server" Text="<%$ Resources:Common, btnUpdateProduct_Text %>" OnClick="btnUpdateProduct_Click" />
</asp:Content>
