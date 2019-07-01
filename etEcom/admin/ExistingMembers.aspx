<%@ Page Title="" Language="C#" MasterPageFile="~/admin/Sellers.Master" AutoEventWireup="true" CodeBehind="ExistingMembers.aspx.cs" Inherits="etEcom.admin.ExistingMembers" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../Style/Global.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
    <asp:Label ID="lblName" runat="server" Text="Name" Width="166px"></asp:Label>
    <asp:Label ID="lblEmail" runat="server" Text="Email" Width="168px"></asp:Label>
    <asp:Label ID="lblMobNo" runat="server" Text="Mobile Number" Width="166px"></asp:Label>
    <asp:Label ID="lblAddress" runat="server" Text="Address" Width="165px"></asp:Label>
    <asp:Label ID="lblState" runat="server" Text="State" Width="242px"></asp:Label>
    <asp:Label ID="lblCity" runat="server" Text="City" Width="201px"></asp:Label>
    <asp:Label ID="lblGender" runat="server" Text="Gender"></asp:Label>
    <br />
    <asp:TextBox ID="txtName" runat="server" CssClass="txt" Width="150px"></asp:TextBox>&nbsp;
    <asp:TextBox ID="txtEmail" runat="server" CssClass="txt" Width="150px"></asp:TextBox>&nbsp;
    <asp:TextBox ID="txtMobNo" runat="server" CssClass="txt" Width="150px"></asp:TextBox>&nbsp;
    <asp:TextBox ID="txtAddress" runat="server" CssClass="txt" Width="150px"></asp:TextBox>&nbsp;
    <asp:DropDownList ID="ddlState" runat="server" CssClass="ddl" Width="230px" OnSelectedIndexChanged="ddlState_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>&nbsp;
    <asp:DropDownList ID="ddlCity" runat="server" CssClass="ddl" Width="230px"></asp:DropDownList>&nbsp;
    <asp:DropDownList ID="ddlGender" runat="server" CssClass="ddl" Width="150px">
        <asp:ListItem Value="0">Select...</asp:ListItem>
        <asp:ListItem Value="true">Male</asp:ListItem>
        <asp:ListItem Value="false">Female</asp:ListItem>
    </asp:DropDownList>
    <asp:Button ID="btnSearch" runat="server" CssClass="btn" Text="Search" OnClick="btnSearch_Click" />
    <asp:GridView ID="grdExistingMembers" runat="server" Width="100%" Height="100%" HeaderStyle-BackColor="#3F8CD6" AllowPaging="true" RowStyle-CssClass="GvGrid"
        HeaderStyle-ForeColor="White" RowStyle-BackColor="#77AEE1" AlternatingRowStyle-BackColor="White"
        RowStyle-ForeColor="#3A3A3A" AutoGenerateColumns="false" PageSize="10">
        <Columns>
            <asp:BoundField DataField="name" HeaderText="Name" />
            <asp:BoundField DataField="email" HeaderText="Email" />
            <asp:BoundField DataField="gender" HeaderText="Gender" />
            <asp:BoundField DataField="mobNo" HeaderText="Mobile Number" />
            <asp:BoundField DataField="shippingAddress" HeaderText="Shipping Address" />
            <asp:BoundField DataField="billingAddress" HeaderText="Billing Address" />
            <asp:BoundField DataField="permanentAddress" HeaderText="Permanent Address" />
        </Columns>
    </asp:GridView>
</asp:Content>
