<%@ Page Title="" Language="C#" MasterPageFile="~/admin/Sellers.Master" AutoEventWireup="true" CodeBehind="UpdateOrder.aspx.cs" Inherits="etEcom.admin.UpdateOrder" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="height: 26px;width:100%">
        <asp:Label runat="server" ID="lblMember" Text="Member Details" Width="400px"></asp:Label>
        <asp:Label runat="server" ID="lblCart" Text="Cart Details" Width="400px"></asp:Label>
        <asp:Label runat="server" ID="lblPayment" Text="Payment Method" Width="219px"></asp:Label>
        <asp:Label runat="server" ID="lblShipping" Text="Shipping Update" Width="200px"></asp:Label><br />
    </div><br />
    <div style="height: 540px; width:100%">
        <asp:Label runat="server" ID="lblMemberDetails" Width="347px" Height="336px" style="float:left; border:1px solid black" ></asp:Label>
        <asp:GridView ID="grdUpdateOrders" runat="server" CssClass="GvGrid" Width="400px" Height="336px" HeaderStyle-BackColor="#3F8CD6" AllowPaging="true" RowStyle-CssClass="GvGrid"
        HeaderStyle-ForeColor="White" RowStyle-BackColor="#77AEE1" AlternatingRowStyle-BackColor="White"
        RowStyle-ForeColor="#3A3A3A" AutoGenerateColumns="false" PageSize="10" style="float:left; border:1px solid black">
        <Columns>
            <asp:BoundField DataField="productName" HeaderText="Product Name" />
            <asp:BoundField DataField="productDispatchTime" HeaderText="Dispatch Time" />
            <asp:BoundField DataField="productPrice" HeaderText="Product Price" />
            <asp:BoundField DataField="productId" Visible="false" />
            <asp:BoundField DataField="productQty" HeaderText="Product Quantity" />
            <asp:BoundField DataField="productShippingCharge" HeaderText="Shipping Charge" />
        </Columns>
    </asp:GridView>
        <asp:Label runat="server" ID="lblPaymentDetails" Width="200px" Height="336px" style="float:left; border:1px solid black"></asp:Label>
        <div style="height:336px; width:218px; float:left; border:1px solid black">
        <asp:DropDownList runat="server" ID="ddlShippingStatus" Width="200px"> 
            <asp:ListItem Value="0">Active</asp:ListItem>
            <asp:ListItem Value="1">Pending</asp:ListItem>
            <asp:ListItem Value="2">Complete</asp:ListItem>
        </asp:DropDownList><br /><br /><br />
        <asp:TextBox runat="server" TextMode="MultiLine" ID="txtShippingDescription" Width="200px" Height="239px"></asp:TextBox><br />
        </div>
        <asp:Button runat="server" ID="btnUpdate" CssClass="btn" Text="Update Shipping Details" OnClick="btnUpdate_Click" />
    </div>
</asp:Content>