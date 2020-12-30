<%@ Page Title="" Language="C#" MasterPageFile="~/ECommerce.Master" AutoEventWireup="true" CodeBehind="FindProducts.aspx.cs" Inherits="Es.Udc.DotNet.PracticaMaD.Web.Pages.Products.FindProducts" meta:resourcekey="PageResource1" %>

<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder_BodyContent" runat="server">
    <div id="form" style="height: 64px">
        <form id="FindForm" method="post" runat="server">
            <div class="field">
                <span class="label">
                    <asp:Localize ID="lclKeywords" runat="server" meta:resourcekey="lclKeywords" />
                </span><span
                    class="entry">
                    <asp:TextBox ID="txtKeywords" runat="server" Width="100px" Columns="16"
                        meta:resourcekey="txtKeywords"></asp:TextBox>
                    <asp:Label ID="lblKeywordsError" runat="server" ForeColor="Red" Style="position: relative"
                        Visible="False" meta:resourcekey="lblKeywordsError"></asp:Label>
                    <asp:DropDownList ID="drpdCategory" runat="server" AppendDataBoundItems="true">
                        <asp:ListItem meta:resourcekey="None" Value="0">None</asp:ListItem>
                    </asp:DropDownList></span>
            </div>
            <div class="button">
                <asp:Button ID="btnFind" runat="server" OnClick="BtnFindClick" meta:resourcekey="btnFind" />
            </div>
        </form>
    </div>
</asp:Content>
