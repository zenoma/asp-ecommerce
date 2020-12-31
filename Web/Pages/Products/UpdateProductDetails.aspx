<%@ Page Title="" Language="C#" MasterPageFile="~/ECommerce.Master" AutoEventWireup="true" CodeBehind="UpdateProductDetails.aspx.cs" Inherits="Es.Udc.DotNet.PracticaMaD.Web.Pages.Products.UpdateProductDetails" %>

<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder_BodyContent" runat="server">
    <div id="form">
        <form id="UpdateUserProductForm" method="POST" runat="server">
            <h1>
                <asp:Localize ID="titlePage" meta:resourcekey="titlePage" runat="server"></asp:Localize>
            </h1>
            <div class="field">
                <span class="label">
                    <asp:Localize ID="lclName" runat="server" Text="<%$ Resources:Common, prodName_Text %>" /></span><span class="entry">
                        <asp:TextBox ID="txtName" runat="server" Columns="16"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvName" runat="server"
                            ControlToValidate="txtName" Display="Dynamic" Text="<%$ Resources:Common, mandatoryField %>" /></span>
            </div>
            <%-- Music fields --%>
            <div class="field" id="artist" runat="server">
                <span class="label" id="lblArtist">
                    <asp:Localize ID="lclArtist" runat="server" Text="<%$ Resources:Common, prodArtist_Text %>" /></span><span class="entry">
                        <asp:TextBox ID="txtArtist" runat="server" Columns="16"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvArtist" runat="server"
                            ControlToValidate="txtArtist" Display="Dynamic" Text="<%$ Resources:Common, mandatoryField %>" /></span>
            </div>
            <div class="field" id="album" runat="server">
                <span class="label">
                    <asp:Localize ID="lclAlbum" runat="server" Text="<%$ Resources:Common, prodAlbum_Text %>" /></span><span class="entry">
                        <asp:TextBox ID="txtAlbum" runat="server" Columns="16"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvAlbum" runat="server"
                            ControlToValidate="txtAlbum" Display="Dynamic" Text="<%$ Resources:Common, mandatoryField %>" /></span>
            </div>
            <%-- Movie fields --%>
            <div class="field" id="director" runat="server">
                <span class="label">
                    <asp:Localize ID="lclDirector" runat="server" Text="<%$ Resources:Common, prodDirector_Text %>" /></span><span class="entry">
                        <asp:TextBox ID="txtDirector" runat="server" Columns="16"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvDirector" runat="server"
                            ControlToValidate="txtDirector" Display="Dynamic" Text="<%$ Resources:Common, mandatoryField %>" /></span>
            </div>
            <div class="field" id="premiereDate" runat="server">
                <span class="label">
                    <asp:Localize ID="lclPremiereDate" runat="server" Text="<%$ Resources:Common, prodPremiereDate_Text %>" /></span><span class="entry">
                        <asp:TextBox ID="txtPremiereDate" TextMode="Date" runat="server" Columns="16"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvPremiereDate" runat="server"
                            ControlToValidate="txtPremiereDate" Display="Dynamic" Text="<%$ Resources:Common, mandatoryField %>" /></span>
            </div>
            <%-- Book fields --%>
            <div class="field" id="author" runat="server">
                <span class="label">
                    <asp:Localize ID="lclAuthor" runat="server" Text="<%$ Resources:Common, prodAuthor_Text %>" /></span><span class="entry">
                        <asp:TextBox ID="txtAuthor" runat="server" Columns="16"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvAuthor" runat="server"
                            ControlToValidate="txtAuthor" Display="Dynamic" Text="<%$ Resources:Common, mandatoryField %>" /></span>
            </div>
            <div class="field" id="editionNumber" runat="server">
                <span class="label">
                    <asp:Localize ID="lclEditionNumber" runat="server" Text="<%$ Resources:Common, prodEditionNumber_Text %>" /></span><span class="entry">
                        <asp:TextBox ID="txtEditionNumber" TextMode="Number" runat="server" Columns="16"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvEditionNumber" runat="server"
                            ControlToValidate="txtEditionNumber" Display="Dynamic" Text="<%$ Resources:Common, mandatoryField %>" />
                        <asp:CompareValidator ID="rfvEditionNumberPositive" runat="server" ValueToCompare="0" ControlToValidate="txtEditionNumber"
                            Text="<%$ Resources:Common, positiveField %>" ForeColor="Red" Operator="GreaterThan" Type="Integer"></asp:CompareValidator>
                    </span>
            </div>
            <div class="field" id="isbn" runat="server">
                <span class="label">
                    <asp:Localize ID="lclIsbn" runat="server" Text="<%$ Resources:Common, prodIsbn_Text %>" /></span><span class="entry">
                        <asp:TextBox ID="txtIsbn" runat="server" Columns="16"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvIsbn" runat="server"
                            ControlToValidate="txtIsbn" Display="Dynamic" Text="<%$ Resources:Common, mandatoryField %>" /></span>
            </div>

            <div class="field">
                <span class="label">
                    <asp:Localize ID="lclUnitPrice" runat="server" Text="<%$ Resources:Common, prodUnitPrice_Text %>" /></span><span class="entry">
                        <asp:TextBox ID="txtUnitPrice" runat="server" Columns="16"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvUnitPrice" runat="server"
                            ControlToValidate="txtUnitPrice" Display="Dynamic" CssClass="errorMessage" Text="<%$ Resources:Common, mandatoryField %>" />
                        <asp:RegularExpressionValidator ErrorMessage="Invalid Price" meta:resourcekey="InvalidPriceUpdate"
                            ControlToValidate="txtUnitPrice" ValidationExpression="^(?!0*(\,0+)?$)(\d+|\d*\,\d+)$" Display="Dynamic" runat="server" />


                    </span>
            </div>
            <div class="field">
                <span class="label">
                    <asp:Localize ID="lblCategory" runat="server" meta:resourcekey="lblCategory" />
                </span>
                <span class="entry">
                    <asp:DropDownList ID="drpdCategory" runat="server" AppendDataBoundItems="false"></asp:DropDownList>
                </span>
            </div>
            <div class="field">
                <span class="label">
                    <asp:Localize ID="lclStockUnits" runat="server" Text="<%$ Resources:Common, prodStockUnits_Text %>" /></span><span class="entry">
                        <asp:TextBox ID="txtStockUnits" TextMode="Number" runat="server" Columns="16"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvStockUnits" runat="server"
                            ControlToValidate="txtStockUnits" Display="Dynamic" Text="<%$ Resources:Common, mandatoryField %>" />
                        <asp:CompareValidator ID="rfvQuantityPositive" runat="server" ValueToCompare="0" ControlToValidate="txtStockUnits"
                            Text="<%$ Resources:Common, positiveField %>" ForeColor="Red" Operator="GreaterThan" Type="Integer"></asp:CompareValidator>
                    </span>

            </div>
            <div class="button">
                <asp:Button ID="btnUpdateProduct" runat="server" OnClick="BtnUpdateProductClick" Text="<%$ Resources:Common, btnUpdateProduct_Text %>" />
            </div>
        </form>
    </div>
</asp:Content>
