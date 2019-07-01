<%@ Page Title="" Language="C#" MasterPageFile="~/Buyers.Master" AutoEventWireup="true" CodeBehind="Cart.aspx.cs" Inherits="etEcom.Cart" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="Style/GlobalV3.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   <%--  <div style="height: 26px;width:100%;margin-left:100px;">
   <asp:Label runat="server" ID="lblProduct" Text="Product" Width="600px"></asp:Label>
       <asp:Label runat="server" ID="lblPrice" Text="Price" Width="100px"></asp:Label>
         <asp:Label runat="server" ID="lblDeliveryDet" Text="Delivery Details" Width="200px"></asp:Label>
         <asp:Label runat="server" ID="lblTotal" Text="Subtotal" Width="300px"></asp:Label>
    </div><br />
    <div style="height: 540px; width:100%;margin-left:100px">       
        <asp:Image runat="server" ID="imgProduct" Width="300" />
        <asp:Label runat="server" ID="lblProductName" Width="200px"></asp:Label>
        <asp:Label runat="server" ID="lblProductPrice" Width="200px"></asp:Label>
        <asp:Label runat="server" ID="lbl" Width="200px"></asp:Label>
       <asp:Label runat="server" ID="lblSubtotal" Width="400px"></asp:Label>
     <div style="height:336px; width:218px; float:left; border:1px solid black">       
         
        </div>
        <br />
        <asp:Button runat="server" ID="btnUpdate" CssClass="btn" Text="Place Order" />
    </div>--%>
    <div style="margin-left:10%;">
        <asp:GridView runat="server" ID="grdCart">
            <Columns>
                <asp:BoundField DataField="productImg" HeaderText="Product" />
                <asp:BoundField DataField="productPrice" HeaderText="Price" />
                <asp:BoundField DataField="deliveryDetails" HeaderText="Delivery Details" />
                <asp:BoundField DataField="subtotal" HeaderText="Subtotal" />
            </Columns>
            
        </asp:GridView><br />
        <asp:Button runat="server" ID="btnPlaceOrder" CssClass="btn" Text="Place Order" />

    </div>
</asp:Content>
