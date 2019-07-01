<%@ Page Title="" Language="C#" MasterPageFile="~/admin/Sellers.Master" AutoEventWireup="true" CodeBehind="AddedInCart.aspx.cs" Inherits="etEcom.admin.AddedInCart" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="//code.jquery.com/ui/1.11.2/jquery-ui.js"></script>
    <link href="../Style/GlobalV3.css" rel="stylesheet" />
    <link rel="stylesheet" href="//code.jquery.com/ui/1.11.2/themes/smoothness/jquery-ui.css" />
    <script>
        $(function () {
            $(document.getElementById('<%= txtDatePickerAdded.ClientID %>')).datepicker();
            $(document.getElementById('<%= txtDatePickerModified.ClientID %>')).datepicker();
        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
    <asp:Label ID="lblMemberDetails" runat="server" Text="Member Details" Width="140px"></asp:Label>
    <asp:Label ID="lblProductDetails" runat="server" Text="Product Details" Width="162px"></asp:Label>
    <asp:Label ID="lblDateAdded" runat="server" Text="Date Added" Width="100px"></asp:Label>
    <asp:Label ID="lblDateModified" runat="server" Text="Date Modified"></asp:Label>
    <br />
    <asp:TextBox ID="txtMemberDetails" runat="server" CssClass="txt" Width="150px"></asp:TextBox>&nbsp;
    <asp:TextBox ID="txtProductDetails" runat="server" CssClass="txt" Width="150px"></asp:TextBox>&nbsp;
    <asp:TextBox ID="txtDatePickerAdded" runat="server" Width="100px" onclick="DatePicker(this)"></asp:TextBox>&nbsp;
    <asp:TextBox ID="txtDatePickerModified" runat="server" Width="100px" onclick="DatePicker(this)"></asp:TextBox>&nbsp;
    <br />
    <asp:Button ID="btnSearch" runat="server" CssClass="btn" Text="Search" OnClick="btnSearch_Click" />
    <asp:GridView ID="grdAddedInCart" runat="server" Width="100%" Height="100%" HeaderStyle-BackColor="#3F8CD6" AllowPaging="true" RowStyle-CssClass="GvGrid"
        HeaderStyle-ForeColor="White" RowStyle-BackColor="#77AEE1" AlternatingRowStyle-BackColor="White"
        RowStyle-ForeColor="#3A3A3A" AutoGenerateColumns="false" PageSize="10" OnRowCommand="grdAddedInCart_RowCommand">
        <Columns>
            <asp:BoundField DataField="memberDetails" HeaderText="Member Details" />
            <asp:BoundField DataField="productDetails" HeaderText="Product Details" />
            <asp:BoundField DataField="shippingCharge" HeaderText="Shipping Charge" />
            <asp:BoundField DataField="cartTotalPrice" HeaderText="Cart Total" />
            <asp:BoundField DataField="dateAdded" HeaderText="Cart Added" />
            <asp:BoundField DataField="dateModified" HeaderText="Cart Modified" />
        </Columns>
    </asp:GridView>
</asp:Content>
