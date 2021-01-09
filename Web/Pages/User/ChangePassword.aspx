<%@ Page Title="" Language="C#" MasterPageFile="~/ECommerce.Master" AutoEventWireup="true" CodeBehind="ChangePassword.aspx.cs" Inherits="Es.Udc.DotNet.PracticaMaD.Web.Pages.User.ChangePassword" %>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder_BodyContent" runat="server">
    <div id="form">
            <h1>
                <asp:Localize ID="titlePage" meta:resourcekey="titlePage" runat="server"></asp:Localize>
            </h1>
            <div class="field">
                <span class="label">
                    <asp:Localize ID="lclOldPassword" runat="server" meta:resourcekey="lclOldPassword" /></span><span
                        class="entry">
                        <asp:TextBox ID="txtOldPassword" TextMode="Password" runat="server" Columns="16">
                        </asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvOldPassword" runat="server" ControlToValidate="txtOldPassword"
                            Font-Bold="true" ForeColor="Red" Display="Dynamic" Text="<%$ Resources:Common, mandatoryField %>"/>
                        <asp:Label ID="lblOldPasswordError" runat="server" ForeColor="Red" Visible="False"
                            meta:resourcekey="lblOldPasswordError">
                        </asp:Label>
                    </span>
            </div>
            <div class="field">
                <span class="label">
                    <asp:Localize ID="lclNewPassword" runat="server" meta:resourcekey="lclNewPassword" /></span><span
                        class="entry">
                        <asp:TextBox TextMode="Password" ID="txtNewPassword" runat="server" Columns="16">
                        </asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvNewPassword" runat="server" ControlToValidate="txtNewPassword"
                            Font-Bold="true" ForeColor="Red" Display="Dynamic" Text="<%$ Resources:Common, mandatoryField %>"/>
                        <asp:CompareValidator ID="cvCreateNewPassword" runat="server" ControlToCompare="txtOldPassword"
                            ControlToValidate="txtNewPassword" Operator="NotEqual" meta:resourcekey="cvCreateNewPassword"></asp:CompareValidator>
                    </span>
            </div>
            <div class="field">
                <span class="label">
                    <asp:Localize ID="lclRetypePassword" runat="server" meta:resourcekey="lclRetypePassword" /></span><span
                        class="entry">
                        <asp:TextBox TextMode="Password" ID="txtRetypePassword" runat="server"
                            Columns="16"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvRetypePassword" runat="server" ControlToValidate="txtRetypePassword"
                            Font-Bold="true" ForeColor="Red" Display="Dynamic" Text="<%$ Resources:Common, mandatoryField %>"/>
                        <asp:CompareValidator ID="cvPasswordCheck" runat="server" ControlToCompare="txtNewPassword"
                            ControlToValidate="txtRetypePassword" meta:resourcekey="cvPasswordCheck"></asp:CompareValidator>
                    </span>
            </div>
            <div class="button">
                <asp:Button ID="btnChangePassword" runat="server" OnClick="BtnChangePasswordClick"
                    meta:resourcekey="btnChangePassword" />
            </div>
    </div>
</asp:Content>
