<%@ Page Title="" Language="C#" MasterPageFile="~/ECommerce.Master" AutoEventWireup="true" CodeBehind="FindProducts.aspx.cs" Inherits="Es.Udc.DotNet.PracticaMaD.Web.Pages.Products.FindProducts" meta:resourcekey="PageResource1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder_MenuWelcome" runat="server">
    -
    <asp:Localize ID="lclMenuExplanation" runat="server" meta:resourcekey="lclMenuExplanation" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder_MenuExplanation" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder_MenuLinks" runat="server">
    <asp:HyperLink ID="lnkHome" runat="server"
        Text="Home" NavigateUrl="~/Pages/MainPage.aspx" />
</asp:Content>
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
                    <%-- <asp:RequiredFieldValidator ID="rfvKeywords" runat="server" ControlToValidate="txtKeywords"
                        Display="Dynamic" Text="<%$ Resources:Common, mandatoryField %>"
                        meta:resourcekey="rfvKeywords"></asp:RequiredFieldValidator>--%>
                    <asp:Label ID="lblKeywordsError" runat="server" ForeColor="Red" Style="position: relative"
                        Visible="False" meta:resourcekey="lblKeywordsError"></asp:Label></span>
            </div>
            <div class="button">
                <asp:Button ID="btnFind" runat="server" OnClick="BtnFindClick" meta:resourcekey="btnFind" />
            </div>
        </form>
    </div>
</asp:Content>
