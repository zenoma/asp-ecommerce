<%@ Page Title="" Language="C#" MasterPageFile="~/ECommerce.Master" AutoEventWireup="true" CodeBehind="ShowProducts.aspx.cs" Inherits="Es.Udc.DotNet.PracticaMaD.Web.Pages.Products.ShowProducts" %>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder_MenuLinks" runat="server">
    <asp:HyperLink ID="lnkHome" runat="server"
        Text="Home" NavigateUrl="~/Pages/MainPage.aspx" />
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder_BodyContent" runat="server">
    <form id="form1" runat="server">
        <asp:GridView ID="gvProducts" runat="server" AutoGenerateColumns="False" Width="505px" >
            <Columns>
                <asp:HyperLinkField DataTextField="name" HeaderText="Name" DataNavigateUrlFields="productId" DataNavigateUrlFormatString="./ShowProductDetails.aspx?productID={0}" />
                <asp:BoundField DataField="category" HeaderText="Category" />
                <asp:BoundField DataField="productDate" HeaderText="Registration Date" DataFormatString="{0:dd/MM/yyyy}" />
                <asp:BoundField DataField="unitPrice" HeaderText="Price" DataFormatString="{0:C}" />                
                <asp:HyperLinkField Text="<%$ Resources:Common, addLink %>" DataNavigateUrlFields="productId" DataNavigateUrlFormatString="~/Pages/Cart/AddToCart.aspx?productID={0}"  />
            </Columns>
        </asp:GridView>
    </form>
    <br />
    <!-- "Previous" and "Next" links. -->
    <div class="previousNextLinks">
        <span class="previousLink"> <%--Text="<%$ Resources:Common, Previous %>"--%>
            <asp:HyperLink ID="lnkPrevious" runat="server"
                Visible="False">Previous</asp:HyperLink>
        </span><span class="nextLink"> <%--Text="<%$ Resources:Common, Next %>"--%>
            <asp:HyperLink ID="lnkNext"  runat="server" Visible="False">Next</asp:HyperLink>
        </span>
    </div>
    <br />
    <br />
</asp:Content>
