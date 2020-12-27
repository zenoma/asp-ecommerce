<%@ Page Title="" Language="C#" MasterPageFile="~/ECommerce.Master" AutoEventWireup="true" CodeBehind="AddToCart.aspx.cs" Inherits="Es.Udc.DotNet.PracticaMaD.Web.Pages.Cart.AddToCart" %>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder_BodyContent" runat="server">
    <asp:Label ID="lblIdentifierError" runat="server" CssClass="errorMessage" meta:resourcekey="lblIdentifierError" />
        <form id="RegisterForm" method="post" runat="server">
            <div class="field">
                <span class="label">
                    <asp:Localize ID="lclQuantity" runat="server" meta:resourcekey="lclQuantity" />
                </span><span
                    class="entry">
                    <asp:TextBox ID="txtQuantity" runat="server" Width="100px" Columns="16"
                        meta:resourcekey="txtQuantity"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvQuantity" runat="server" ControlToValidate="txtQuantity"
                        Display="Dynamic" Text="<%$ Resources:Common, mandatoryField %>"
                        meta:resourcekey="rfvQuantity"></asp:RequiredFieldValidator>
                    <asp:Label ID="lblQuantityError" runat="server" ForeColor="Red" Style="position: relative"
                        Visible="False" meta:resourcekey="lblQuantityError"></asp:Label></span>
                <span class="label">
                    <asp:CheckBox ID="ckToPresent" Text="To Present?" runat="server" />
                </span>
            </div>
            <div class="button">
                <asp:Button ID="btnAddToCart" runat="server" OnClick="BtnAddToCart" meta:resourcekey="btnAddToCart" />
            </div>
        </form>
</asp:Content>
