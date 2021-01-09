<%@ Page Title="" Language="C#" MasterPageFile="~/ECommerce.Master" AutoEventWireup="true" CodeBehind="Authentication.aspx.cs" Inherits="Es.Udc.DotNet.PracticaMaD.Web.Pages.User.Login" %>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder_BodyContent" runat="server">
    <div id="form">
        <asp:HyperLink ID="lnkRegister" runat="server" NavigateUrl="~/Pages/User/Register.aspx" meta:resourcekey="lnkRegister" />
            <h1>
                <asp:Localize ID="titlePage" meta:resourcekey="titlePage" runat="server"></asp:Localize>
            </h1>
            <div class="field">
                <span class="label">
                    <asp:Localize ID="lclLogin" runat="server" meta:resourcekey="lclLogin" /></span><span
                        class="entry">
                        <asp:TextBox ID="txtLogin" runat="server" Columns="16"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvLogin" runat="server"
                            ControlToValidate="txtLogin" Font-Bold="true" ForeColor="Red" Display="Dynamic" Text="<%$ Resources:Common, mandatoryField %>"/>
                        <asp:Label ID="lblLoginError" runat="server" ForeColor="Red" Style="position: relative"
                            Visible="False" meta:resourcekey="lblLoginError">                        
                        </asp:Label>
                    </span>
            </div>
            <div class="field">
                <span class="label">
                    <asp:Localize ID="lclPassword" runat="server" meta:resourcekey="lclPassword" /></span><span
                        class="entry">
                        <asp:TextBox TextMode="Password" ID="txtPassword" runat="server" Columns="16"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvPassword" runat="server"
                            ControlToValidate="txtPassword" Font-Bold="true" ForeColor="Red" Display="Dynamic" Text="<%$ Resources:Common, mandatoryField %>"/>
                        <asp:Label ID="lblPasswordError" runat="server" ForeColor="Red" Style="position: relative"
                            Visible="False" meta:resourcekey="lblPasswordError">       
                        </asp:Label>
                    </span>
            </div>
            <div class="checkbox">
                <asp:CheckBox ID="checkRememberPassword" runat="server" TextAlign="Right" meta:resourcekey="checkRememberPassword" />
            </div>
            <div class="button">
                <asp:Button ID="btnLogin" runat="server" OnClick="BtnLoginClick" meta:resourcekey="btnLogin" />
            </div>
    </div>
</asp:Content>
