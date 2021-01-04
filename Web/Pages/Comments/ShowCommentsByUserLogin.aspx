<%@ Page Title="" Language="C#" MasterPageFile="~/ECommerce.Master" AutoEventWireup="true" CodeBehind="ShowCommentsByUserLogin.aspx.cs" Inherits="Es.Udc.DotNet.PracticaMaD.Web.Pages.Comments.ShowCommentsByUserLogin" %>
<asp:Content ID="Content5" ContentPlaceHolderID="ContentPlaceHolder_BodyContent" runat="server">
        <h1>
            <asp:Localize ID="titlePage" meta:resourcekey="titlePage" runat="server"></asp:Localize>
        </h1>
        <div class="containerErrors">
            <asp:Label ID="lblNoComments" runat="server" CssClass="errorMessage" meta:resourcekey="lblNoComments"></asp:Label>
        </div>
        <asp:GridView ID="gvComments" runat="server" CssClass="table-allwidth" GridLines="None"
            AutoGenerateColumns="False">
            <Columns>
                <asp:BoundField DataField="productName" HeaderText="<%$ Resources:Common, prodName_Text %>" />
                <asp:BoundField DataField="commentDate" HeaderText="<%$ Resources:Common, commentDate %>" />
                <asp:BoundField DataField="body" HeaderText="<%$ Resources:Common, body %>" />
                <asp:HyperLinkField Text="<%$ Resources:Common, editButton %>" DataNavigateUrlFields="CommentId" DataNavigateUrlFormatString="~/Pages/Comments/EditComment.aspx?CommentId={0}" />
                <asp:HyperLinkField Text="<%$ Resources:Common, removeButton %>" DataNavigateUrlFields="CommentId" DataNavigateUrlFormatString="~/Pages/Comments/RemoveComment.aspx?CommentId={0}" />
            </Columns>
        </asp:GridView>
        <div class="previousNextLinks">
            <span class="previousLink"><%--Text="<%$ Resources:Common, Previous %>"--%>
                <asp:HyperLink ID="lnkPrevious" runat="server" Text="<%$ Resources:Common, Previous %>"
                    Visible="False"></asp:HyperLink>
            </span><span class="nextLink"><%--Text="<%$ Resources:Common, Next %>"--%>
                <asp:HyperLink ID="lnkNext" runat="server" Visible="False" Text="<%$ Resources:Common, Next %>"></asp:HyperLink>
            </span>
        </div>
</asp:Content>
