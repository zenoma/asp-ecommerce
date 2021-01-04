<%@ Page Title="" Language="C#" MasterPageFile="~/ECommerce.Master" AutoEventWireup="true" CodeBehind="ListCreditCards.aspx.cs" Inherits="Es.Udc.DotNet.PracticaMaD.Web.Pages.User.ListCreditCards" %>
<asp:Content ID="Content" ContentPlaceHolderID="ContentPlaceHolder_BodyContent" runat="server">
        <h1>
            <asp:Localize ID="titlePage" meta:resourcekey="titlePage" runat="server"></asp:Localize>
        </h1>
        <asp:HyperLink ID="lnkAddCreditCard" runat="server" NavigateUrl="~/Pages/User/AddCreditCard.aspx" meta:resourcekey="lnkAddCreditCard" />
        <div class="containerErrors">
            <asp:Label ID="lblNoCreditCards" runat="server" CssClass="errorMessage" meta:resourcekey="lblNoCreditCards"></asp:Label>
        </div>
        <asp:GridView ID="gvCreditCards" runat="server" CssClass="table-allwidth" GridLines="None"
            AutoGenerateColumns="False">
            <Columns>
                <asp:BoundField DataField="type" HeaderText="<%$ Resources:Common, type %>" />
                <asp:BoundField DataField="number" HeaderText="<%$ Resources:Common, number %>" />
                <asp:BoundField DataField="verifyCode" HeaderText="<%$ Resources:Common, verifyCode %>" />
                <asp:BoundField DataField="expDate" HeaderText="<%$ Resources:Common, expDate %>" DataFormatString="{0:d}" />
                <asp:BoundField DataField="isFav" HeaderText="<%$ Resources:Common, isFav %>" />
                <asp:HyperLinkField Text="<%$ Resources:Common, editButton %>" DataNavigateUrlFields="CreditCardId" DataNavigateUrlFormatString="~/Pages/User/EditCreditCard.aspx?CreditCardId={0}" />
                <asp:HyperLinkField Text="<%$ Resources:Common, removeButton %>" DataNavigateUrlFields="CreditCardId" DataNavigateUrlFormatString="~/Pages/User/RemoveCreditCard.aspx?CreditCardId={0}" />
            </Columns>
        </asp:GridView>
</asp:Content>
