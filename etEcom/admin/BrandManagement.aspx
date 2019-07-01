<%@ Page Title="" Language="C#" MasterPageFile="~/admin/Sellers.Master" AutoEventWireup="true" CodeBehind="BrandManagement.aspx.cs" Inherits="etEcom.admin.BrandManagement" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <link href="../Style/GlobalV3.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
    <asp:Label ID="lblName" runat="server" CssClass="translabel" Text="Name" Width="166px"></asp:Label>
    <asp:Label ID="lblPromotions" runat="server" CssClass="translabel" Text="Promotions" Width="180px"></asp:Label>
    <asp:Label ID="lblBRating" runat="server" CssClass="translabel" Text="Brand Rating" Width="166px"></asp:Label>
    <br />
    <asp:TextBox ID="txtName" runat="server" CssClass="txt" Width="150px"></asp:TextBox>&nbsp;
    <asp:TextBox ID="txtPromotions" runat="server" CssClass="txt" Width="150px"></asp:TextBox>%&nbsp;
    <asp:DropDownList ID="ddlBrandRating" runat="server" CssClass="dropDownLists" Width="230px">
        <asp:ListItem Value="0">Select...</asp:ListItem>
        <asp:ListItem>1</asp:ListItem>
        <asp:ListItem>2</asp:ListItem>
        <asp:ListItem>3</asp:ListItem>
        <asp:ListItem>4</asp:ListItem>
        <asp:ListItem>5</asp:ListItem>
    </asp:DropDownList>/5 Stars&nbsp;<br />
    <asp:Button ID="btnBSearch" runat="server" Text="Search" CssClass="btn" OnClick="btnBSearch_Click"></asp:Button>

    <div class="rounded_corners" style="width: 100%">
        <asp:GridView ID="GvBrand" runat="server" Width="100%" HeaderStyle-BackColor="#3F8CD6" AllowPaging="true" RowStyle-CssClass="GvGrid"
            HeaderStyle-ForeColor="White" RowStyle-BackColor="#77AEE1" AlternatingRowStyle-BackColor="White"
            RowStyle-ForeColor="#3A3A3A" AutoGenerateColumns="False" OnRowCommand="GvBrand_RowCommand">
            <AlternatingRowStyle BackColor="White"></AlternatingRowStyle>
            <Columns>
                <asp:BoundField DataField="name" HeaderText="Name" />
                <asp:BoundField DataField="promotions" HeaderText="Promotional Discount(%)" />
                <asp:BoundField DataField="brandRating" HeaderText="Brand Rating(/5 Stars)" />

                <%--<asp:ButtonField DataTextField="select" HeaderText="Edit"/>--%>
                <asp:TemplateField HeaderText="Select">
                    <ItemTemplate>
                        <%-- <asp:LinkButton runat="server" CommandName="edit">Edit</asp:LinkButton>--%>
                        <asp:Button runat="server" Text="" CommandName="Select" CommandArgument='<%#Eval("id") %>' CssClass="btn" Height="25px" HeaderStyle-Width="15%" />
                    </ItemTemplate>
                </asp:TemplateField>

            </Columns>

            <HeaderStyle BackColor="#3F8CD6" ForeColor="White"></HeaderStyle>

            <RowStyle BackColor="#77AEE1" CssClass="GvGrid" ForeColor="#3A3A3A"></RowStyle>
        </asp:GridView>
    </div>
    <br />
    <div>
 <asp:Button runat="server" ID="btnNewBrand" CssClass="btn" Text="Add New Brand" Width="300px" OnClick="btnNewBrand_Click" />
        </div>
</asp:Content>
