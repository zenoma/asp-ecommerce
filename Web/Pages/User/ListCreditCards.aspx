<%@ Page Title="" Language="C#" MasterPageFile="~/ECommerce.Master" AutoEventWireup="true" CodeBehind="ListCreditCards.aspx.cs" Inherits="Es.Udc.DotNet.PracticaMaD.Web.Pages.User.ListCreditCards" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder_MenuExplanation" runat="server">
    -
    <asp:Localize ID="lclMenuExplanation" runat="server" meta:resourcekey="lclMenuExplanation" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder_MenuLinks" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder_BodyContent" runat="server">
    <asp:HyperLink ID="lnkAddCreditCard" runat="server" NavigateUrl="~/Pages/User/AddCreditCard.aspx" meta:resourcekey="lnkAddCreditCard" />
    <form runat="server">
        <p>
            <asp:Label ID="lblNoCreditCards" meta:resourcekey="lblNoCreditCards" runat="server"></asp:Label>
        </p>
        <asp:GridView ID="gvCreditCards" runat="server" CssClass="creditCards" GridLines="None"
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
    </form>
</asp:Content>
