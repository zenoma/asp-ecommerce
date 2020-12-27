<%@ Page Title="" Language="C#" MasterPageFile="~/ECommerce.Master" AutoEventWireup="true" CodeBehind="CreateOrder.aspx.cs" Inherits="Es.Udc.DotNet.PracticaMaD.Web.Pages.Order.CreateOrder" %>

<asp:Content ID="Content5" ContentPlaceHolderID="ContentPlaceHolder_BodyContent" runat="server">
    <asp:Label ID="lblIdentifierError" runat="server" CssClass="errorMessage" meta:resourcekey="lblIdentifierError" />
    <form id="CreateOrderForm" method="POST" runat="server">
        <div class="field">
            <span class="label">
                <asp:Localize ID="lclName" runat="server" meta:resourcekey="lclName" /></span><span class="entry">
                    <asp:TextBox ID="txtName" runat="server" Width="100" Columns="16"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvName" runat="server"
                        ControlToValidate="txtName" Display="Dynamic" Text="<%$ Resources:Common, mandatoryField %>" /></span>
        </div>
        <div class="field">
            <span class="label">
                <asp:Localize ID="lclPostalAddress" runat="server" meta:resourcekey="lclPostalAddress" /></span><span class="entry">
                    <asp:TextBox ID="txtPostalAddress" runat="server" Width="100" Columns="16"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvPostalAddress" runat="server"
                        ControlToValidate="txtPostalAddress" Display="Dynamic" Text="<%$ Resources:Common, mandatoryField %>" /></span>
        </div>
        <div class="field">
            <span class="label">
                <asp:Localize ID="lclCreditCard" runat="server" meta:resourcekey="lclCreditCard" /></span><span class="entry">
                    <asp:DropDownList ID="comboCreditCard" runat="server" Width="100px">
                    </asp:DropDownList></span>
        </div>
        <div class="button">
            <asp:Button ID="btnCreateOrder" runat="server" OnClick="BtnCreateOrder" meta:resourcekey="btnCreateOrder" />
        </div>
    </form>
</asp:Content>
