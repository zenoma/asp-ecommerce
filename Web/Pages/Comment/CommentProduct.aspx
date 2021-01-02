<%@ Page Title="" Language="C#" MasterPageFile="~/ECommerce.Master" AutoEventWireup="true" CodeBehind="CommentProduct.aspx.cs" Inherits="Es.Udc.DotNet.PracticaMaD.Web.Pages.Comment.CommentProduct" %>

<asp:Content ID="Content5" ContentPlaceHolderID="ContentPlaceHolder_BodyContent" runat="server">
    <form id="CreateOrderForm" method="POST" runat="server">
        <h1>
            <asp:Localize ID="titlePage" meta:resourcekey="titlePage" runat="server"></asp:Localize>
        </h1>
        <div class="containerErrors">
            <asp:Label ID="lblIdentifierError" runat="server" CssClass="errorMessage" meta:resourcekey="lblIdentifierError" />
        </div>
        <div class="field">
            <span class="label">
                <asp:Localize ID="lclBodyComment" runat="server" meta:resourcekey="lclComment" /></span><span class="entry">
                    <asp:TextBox ID="txtBodyComment" TextMode="MultiLine" Rows="5" runat="server" Columns="16" Width="352px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvComment" runat="server"
                        ControlToValidate="txtComment" Display="Dynamic" Text="<%$ Resources:Common, mandatoryField %>" /></span>
        </div>
        <div class="button">
            <asp:Button ID="btnCreateOrder" runat="server" OnClick="btnCreateComment_Click" meta:resourcekey="btnCreateComment" />
        </div>
    </form>
</asp:Content>
