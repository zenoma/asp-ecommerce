<%@ Page Title="" Language="C#" MasterPageFile="~/ECommerce.Master" AutoEventWireup="true" CodeBehind="EditCreditCard.aspx.cs" Inherits="Es.Udc.DotNet.PracticaMaD.Web.Pages.User.EditCreditCard" %>
<asp:Content ID="Content" ContentPlaceHolderID="ContentPlaceHolder_BodyContent" runat="server">
    <div id="form">
            <h1>
                <asp:Localize ID="titlePage" meta:resourcekey="titlePage" runat="server"></asp:Localize>
            </h1>
            <div class="field">
                <span class="label">
                    <asp:Localize ID="lclType" runat="server" meta:resourcekey="lclType" />
                </span><span
                        class="entry">
                        <asp:TextBox ID="txtType" runat="server" Columns="16"
                            meta:resourcekey="txtTypeResource"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvType" runat="server" ControlToValidate="txtType"
                            Display="Dynamic" Text="<%$ Resources:Common, mandatoryField %>"
                            meta:resourcekey="rfvType"></asp:RequiredFieldValidator>
                        <asp:Label ID="lblTypeError" runat="server" ForeColor="Red" Style="position: relative"
                            Visible="False" meta:resourcekey="lblTypeError"></asp:Label></span>
            </div>
            <div class="field">
                <span class="label">
                    <asp:Localize ID="lclNumber" runat="server" meta:resourcekey="lclNumber" /></span><span
                        class="entry">
                        <asp:TextBox TextMode="Number" ID="txtNumber" runat="server" Columns="16" 
                            meta:resourcekey="txtNumberResource"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvNumber" runat="server" ControlToValidate="txtNumber"
                            Display="Dynamic" Text="<%$ Resources:Common, mandatoryField %>"
                            meta:resourcekey="rfvNumber"></asp:RequiredFieldValidator></span>
            </div>
            <div class="field">
                <span class="label">
                    <asp:Localize ID="lclVerifyCode" runat="server" meta:resourcekey="lclVerifyCode" /></span><span
                        class="entry">
                        <asp:TextBox TextMode="Number" ID="txtVerifyCode" runat="server"
                            Columns="16" meta:resourcekey="txtVerifyCodeResource"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvVerifyCode" runat="server" ControlToValidate="txtVerifyCode"
                            Display="Dynamic" Text="<%$ Resources:Common, mandatoryField %>"
                            meta:resourcekey="rfvVerifyCode"></asp:RequiredFieldValidator></span>
            </div>
            <div class="field">
                <span class="label">
                    <asp:Localize ID="lclExpDate" runat="server" meta:resourcekey="lclExpDate" /></span><span
                        class="entry">
                        <asp:TextBox TextMode="Date" ID="txtExpDate" runat="server"
                            Columns="16" meta:resourcekey="txtExpDateResource"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvExpDate" runat="server" ControlToValidate="txtExpDate"
                            Display="Dynamic" Text="<%$ Resources:Common, mandatoryField %>"
                            meta:resourcekey="rfvExpDate"></asp:RequiredFieldValidator></span>
            </div>
            <div class="checkbox">
                <asp:CheckBox ID="checkIsFav" runat="server" TextAlign="Right" meta:resourcekey="checkIsFav" />
            </div>
            <div class="button">
                <asp:Button ID="btnEdit" runat="server" OnClick="BtnEditClick" meta:resourcekey="btnEdit" />
            </div>
    </div>
</asp:Content>
