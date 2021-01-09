<%@ Page Title="" Language="C#" MasterPageFile="~/ECommerce.Master" AutoEventWireup="true" CodeBehind="EditComment.aspx.cs" Inherits="Es.Udc.DotNet.PracticaMaD.Web.Pages.Comments.EditComment" %>

<asp:Content ID="Content5" ContentPlaceHolderID="ContentPlaceHolder_BodyContent" runat="server">
    <div id="form">
        <h1>
            <asp:Localize ID="titlePage" meta:resourcekey="titlePage" runat="server"></asp:Localize>
        </h1>
        <div class="field">
            <span class="label">
                <asp:Localize ID="lclBody" runat="server" meta:resourcekey="lclBody" />
            </span>
            <span class="entry">
                <asp:TextBox ID="txtBody" runat="server" Columns="16" meta:resourcekey="txtBodyResource"
                    Rows="4" TextMode="MultiLine"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvBody" runat="server" ControlToValidate="txtBody"
                    Font-Bold="true" ForeColor="Red" Display="Dynamic" Text="<%$ Resources:Common, mandatoryField %>"
                    meta:resourcekey="rfvBody"></asp:RequiredFieldValidator>

            </span>
        </div>
        <div class="field">
            <span class="label">
                <asp:Localize ID="lclTags" runat="server" meta:resourcekey="lclTags" />
            </span>
            <span class="entry">
                <asp:ListBox ID="lbTags" SelectionMode="multiple" runat="server"></asp:ListBox>
            </span>
        </div>
        <div class="field">
            <span class="label">
                <asp:Localize ID="lclNewTags" runat="server" meta:resourcekey="lclNewTags" />
            </span>
            <span class="entry">
                <asp:TextBox ID="txtNewTags" runat="server" Columns="16"
                    meta:resourcekey="txtNewTagsResource"></asp:TextBox>
            </span>
        </div>
        <div class="button">
            <asp:Button ID="btnEdit" runat="server" OnClick="BtnEditClick" meta:resourcekey="btnEdit" />
        </div>
    </div>
</asp:Content>
