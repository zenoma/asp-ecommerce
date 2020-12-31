<%@ Page Title="" Language="C#" MasterPageFile="~/ECommerce.Master" AutoEventWireup="true" CodeBehind="UpdateUserDetails.aspx.cs" Inherits="Es.Udc.DotNet.PracticaMaD.Web.Pages.User.UpdateUserDetails" %>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder_BodyContent" runat="server">
    <div id="form">
        <form id="UpdateUserProfileForm" method="POST" runat="server">
            <h1>
                <asp:Localize ID="titlePage" meta:resourcekey="titlePage" runat="server"></asp:Localize>
            </h1>
            <asp:HyperLink ID="lnkChangePassword" runat="server" 
                NavigateUrl="~/Pages/User/ChangePassword.aspx"
                meta:resourcekey="lnkChangePassword"/>
            <div class="field">
                <span class="label"><asp:Localize ID="lclName" runat="server" meta:resourcekey="lclName" /></span><span class="entry">
                    <asp:TextBox ID="txtName" runat="server" Columns="16"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvName" runat="server"
                        ControlToValidate="txtName" Display="Dynamic" Text="<%$ Resources:Common, mandatoryField %>"/></span>
            </div>
            <div class="field">
                <span class="label"><asp:Localize ID="lclSurnames" runat="server" meta:resourcekey="lclSurnames" /></span><span class="entry">
                    <asp:TextBox ID="txtSurnames" runat="server" Columns="16"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvSurnames" runat="server"
                        ControlToValidate="txtSurnames" Display="Dynamic" Text="<%$ Resources:Common, mandatoryField %>"/></span>
            </div>
            <div class="field">
                <span class="label"><asp:Localize ID="lclEmail" runat="server" meta:resourcekey="lclEmail" /></span><span class="entry">
                    <asp:TextBox ID="txtEmail" runat="server" Columns="16"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvEmail" runat="server"
                        ControlToValidate="txtEmail" Display="Dynamic" Text="<%$ Resources:Common, mandatoryField %>"/>
                    <asp:RegularExpressionValidator ID="revEmail" runat="server"
                        ControlToValidate="txtEmail" Display="Dynamic" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" meta:resourcekey="revEmail"></asp:RegularExpressionValidator></span>
            </div>
            <div class="field">
                <span class="label"><asp:Localize ID="lclPostalAddress" runat="server" meta:resourcekey="lclPostalAddress" /></span><span class="entry">
                    <asp:TextBox ID="txtPostalAddress" runat="server" Columns="16"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvPostalAddress" runat="server"
                        ControlToValidate="txtPostalAddress" Display="Dynamic" Text="<%$ Resources:Common, mandatoryField %>"/></span>
            </div>
            <div class="field">
                <span class="label"><asp:Localize ID="lclLanguage" runat="server" meta:resourcekey="lclLanguage" /></span><span class="entry">
                    <asp:DropDownList ID="comboLanguage" runat="server" AutoPostBack="True" 
                    onselectedindexchanged="ComboLanguageSelectedIndexChanged">
                    </asp:DropDownList></span>
            </div>
            <div class="field">
                <span class="label"><asp:Localize ID="lclCountry" runat="server" meta:resourcekey="lclCountry" /></span><span class="entry">
                    <asp:DropDownList ID="comboCountry" runat="server">
                    </asp:DropDownList></span>
            </div>
            <div class="button">
                <asp:Button ID="btnUpdate" runat="server" OnClick="BtnUpdateClick" meta:resourcekey="btnUpdate"/>
            </div>
        </form>
    </div>
</asp:Content>
