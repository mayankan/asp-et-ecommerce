<%@ Page Title="" Language="C#" MasterPageFile="~/admin/Sellers.Master" AutoEventWireup="true" CodeBehind="CategoryManagement.aspx.cs" Inherits="etEcom.admin.CatagoryManagement" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <%-- <link href="../Style/Global.css" rel="stylesheet" />--%>
    <link href="../Style/GlobalV3.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
    <asp:Label ID="lblName" runat="server" CssClass="translabel" Text="Name" Width="166px"></asp:Label>
    <asp:Label ID="lblDesc" runat="server" CssClass="translabel" Text="Description" Width="150px"></asp:Label>
    <asp:Label ID="lblParentCat" runat="server" CssClass="translabel" Text="Parent Category" Width="150px"></asp:Label>
    <asp:Label ID="lblFeature1" runat="server" CssClass="translabel" Text="1st Feature" Width="150px"></asp:Label>
    <asp:Label ID="lblFeature2" runat="server" CssClass="translabel" Text="2nd Feature" Width="150px"></asp:Label>
    <asp:Label ID="lblFeature3" runat="server" CssClass="translabel" Text="3rd Feature" Width="150px"></asp:Label>
    <asp:Label ID="lblFeature4" runat="server" CssClass="translabel" Text="4th Feature" Width="150px"></asp:Label>
    <br />
    <asp:TextBox ID="txtName" runat="server" CssClass="txt" Width="151px"></asp:TextBox>&nbsp;
      <asp:TextBox ID="txtDesc" runat="server" CssClass="txt" Width="150px"></asp:TextBox>&nbsp;
      <asp:TextBox ID="txtParentCategory" runat="server" CssClass="txt" Width="150px"></asp:TextBox>&nbsp;
      <asp:TextBox ID="txtFeature1" runat="server" CssClass="txt" Width="150px"></asp:TextBox>&nbsp;
      <asp:TextBox ID="txtFeature2" runat="server" CssClass="txt" Width="150px"></asp:TextBox>&nbsp;
      <asp:TextBox ID="txtFeature3" runat="server" CssClass="txt" Width="150px"></asp:TextBox>&nbsp;    
      <asp:TextBox ID="txtFeature4" runat="server" CssClass="txt" Width="150px"></asp:TextBox>&nbsp;
      <br />
    <asp:Button ID="btnCatSearch" runat="server" CssClass="btn" Text="Search" OnClick="btnCatSearch_Click" />
    <br />

    <div class="rounded_corners" style="width: 100%">
        <asp:GridView ID="GvCategory" runat="server" Width="100%" HeaderStyle-BackColor="#3F8CD6" AllowPaging="true" RowStyle-CssClass="GvGrid"
            HeaderStyle-ForeColor="White" RowStyle-BackColor="#77AEE1" AlternatingRowStyle-BackColor="White"
            RowStyle-ForeColor="#3A3A3A" AutoGenerateColumns="false" PageSize="10" OnRowCommand="GvCategory_RowCommand">
            <Columns>
                <asp:BoundField DataField="categoryName" HeaderText="Category Name" />
                <asp:BoundField DataField="description" HeaderText=" Category Description" />
                <asp:BoundField DataField="parentCategory" HeaderText="Parent Category" />
                <asp:BoundField DataField="feature1" HeaderText="1st Feature of this Category" />
                <asp:BoundField DataField="feature2" HeaderText="2nd Feature of this Category" />
                <asp:BoundField DataField="feature3" HeaderText="3rd Feature of this Category" />
                <asp:BoundField DataField="feature4" HeaderText="4th Feature of this Category" />
                <%--<asp:ButtonField DataTextField="select" HeaderText="Edit"/>--%>
                <asp:TemplateField HeaderText="Select">
                    <ItemTemplate>
                        <%-- <asp:LinkButton runat="server" CommandName="edit">Edit</asp:LinkButton>--%>
                        <asp:Button runat="server" Text="" Font-Size="Small" CommandName="Select" CommandArgument='<%#Eval("id") %>' CssClass="btn" Height="25px" HeaderStyle-Width="15%" />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>

    </div>

    <asp:Button runat="server" Text="Add New Category" ID="btnNewCat" CssClass="btn" Width="300px" OnClick="btnNewCat_Click" />
</asp:Content>
