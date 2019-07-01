<%@ Page Title="" Language="C#" MasterPageFile="~/admin/Sellers.Master" AutoEventWireup="true" CodeBehind="CompletedOrders.aspx.cs" Inherits="etEcom.admin.CompletedOrders" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="//code.jquery.com/ui/1.11.2/jquery-ui.js"></script>
    <link href="../Style/GlobalV3.css" rel="stylesheet" />
    <link rel="stylesheet" href="//code.jquery.com/ui/1.11.2/themes/smoothness/jquery-ui.css" />
    <script>
        $(function () {
            $(document.getElementById('<%= txtDatePickerCreated.ClientID %>')).datepicker();
            $(document.getElementById('<%= txtDatePickerModified.ClientID %>')).datepicker();
        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <br />
    <asp:Label ID="lblMember" runat="server" Text="Member Name" Width="166px"></asp:Label>
    <asp:Label ID="lblAddress" runat="server" Text="Address" Width="165px"></asp:Label>
    <asp:Label ID="lblProductName" runat="server" Text="Product Name" Width="166px"></asp:Label>
    <asp:Label ID="lblState" runat="server" Text="State" Width="242px"></asp:Label>
    <asp:Label ID="lblCity" runat="server" Text="City" Width="165px"></asp:Label>
    <asp:Label ID="lblDateCreated" runat="server" Text="Date Created" Width="105px"></asp:Label>
    <asp:Label ID="lblDateModified" runat="server" Text="Date Modified"></asp:Label>
    <br />
    <asp:TextBox ID="txtMember" runat="server" CssClass="txt" Width="150px"></asp:TextBox>&nbsp;
    <asp:TextBox ID="txtAddress" runat="server" CssClass="txt" Width="150px"></asp:TextBox>&nbsp;
    <asp:TextBox ID="txtProductName" runat="server" CssClass="txt" Width="150px"></asp:TextBox>&nbsp;
    <asp:DropDownList ID="ddlState" runat="server" CssClass="ddl" Width="213px" OnSelectedIndexChanged="ddlState_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>&nbsp;
    <asp:DropDownList ID="ddlCity" runat="server" CssClass="ddl" Width="219px"></asp:DropDownList>&nbsp;
    <asp:TextBox ID="txtDatePickerCreated" runat="server" Width="100px" onclick="DatePicker(this)"></asp:TextBox>&nbsp;
    <asp:TextBox ID="txtDatePickerModified" runat="server" Width="100px" onclick="DatePicker(this)"></asp:TextBox>&nbsp;
    <br />
    <asp:Button ID="btnSearch" runat="server" CssClass="btn" Text="Search" OnClick="btnSearch_Click" />
    <asp:GridView ID="grdCompletedOrders" runat="server" Width="100%" Height="100%" HeaderStyle-BackColor="#3F8CD6" AllowPaging="true" RowStyle-CssClass="GvGrid"
        HeaderStyle-ForeColor="White" RowStyle-BackColor="#77AEE1" AlternatingRowStyle-BackColor="White"
        RowStyle-ForeColor="#3A3A3A" AutoGenerateColumns="false" PageSize="10" OnRowCommand="grdCompletedOrders_RowCommand">
        <Columns>
            <asp:BoundField DataField="memberName" HeaderText="Member Name" />
            <asp:BoundField DataField="address" HeaderText="Address" />
            <asp:BoundField DataField="productName" HeaderText="Product Name" />
            <asp:BoundField DataField="productQty" HeaderText="Product Quantity" />
            <asp:BoundField DataField="orderStatus" HeaderText="Status" />
            <asp:BoundField DataField="dateCreated" HeaderText="Date Created" />
            <asp:BoundField DataField="dateModified" HeaderText="Date Modified" />
            <asp:BoundField DataField="shippingDescription" HeaderText="Shipping Description" />
            <asp:TemplateField HeaderText="Update">
                    <ItemTemplate>
                        <%-- <asp:LinkButton runat="server" CommandName="edit">Edit</asp:LinkButton>--%>
                        <asp:Button runat="server" Text="" CommandName="Update" CommandArgument='<%#Eval("id") %>' CssClass="btn" Height="25px" HeaderStyle-Width="15%" />
                    </ItemTemplate>
                </asp:TemplateField>
        </Columns>
    </asp:GridView>
</asp:Content>
