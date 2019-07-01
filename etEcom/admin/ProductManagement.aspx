<%@ Page Title="" Language="C#" MasterPageFile="~/admin/Sellers.Master" AutoEventWireup="true" CodeBehind="ProductManagement.aspx.cs" Inherits="etEcom.admin.ProductManagement" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <%--  <link href="../Style/Global.css" rel="stylesheet" />--%>
    <%-- <link href="../Style/GlobalV2.css" rel="stylesheet" />--%>
    <link href="../Style/GlobalV3.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
    <asp:Label ID="lblName" runat="server" CssClass="translabel" Text="Name" Width="166px"></asp:Label>
    <asp:Label ID="lblPrice" runat="server" CssClass="translabel" Text="Price" Width="160px"></asp:Label>
    <asp:Label ID="lblStkQty" runat="server" CssClass="translabel" Text="Stock Quantity" Width="161px"></asp:Label>
    <asp:Label ID="lblFeature1" runat="server" CssClass="translabel" Text="1st Feature" Width="150px"></asp:Label>
    <asp:Label ID="lblFeature2" runat="server" CssClass="translabel" Text="2nd Feature" Width="150px"></asp:Label>
    <asp:Label ID="lblFeature3" runat="server" CssClass="translabel" Text="3rd Feature" Width="150px"></asp:Label>
    <asp:Label ID="lblFeature4" runat="server" CssClass="translabel" Text="4th Feature" Width="150px"></asp:Label>
    <asp:Label ID="lblWeight" runat="server" CssClass="translabel" Text="Weight" Width="152px"></asp:Label>
    <br />
    <asp:TextBox ID="txtName" runat="server" CssClass="txt" Width="150px"></asp:TextBox>
    <asp:TextBox ID="txtPrice" runat="server" CssClass="txt" Width="150px"></asp:TextBox>&nbsp;
    <asp:TextBox ID="txtStkQty" runat="server" CssClass="txt" Width="150px"></asp:TextBox>&nbsp;
    <asp:TextBox ID="txtFeature1" runat="server" CssClass="txt" Width="150px"></asp:TextBox>&nbsp;
    <asp:TextBox ID="txtFeature2" runat="server" CssClass="txt" Width="150px"></asp:TextBox>&nbsp;
    <asp:TextBox ID="txtFeature3" runat="server" CssClass="txt" Width="150px"></asp:TextBox>&nbsp;
    <asp:TextBox ID="txtFeature4" runat="server" CssClass="txt" Width="150px"></asp:TextBox>&nbsp;
    <asp:TextBox ID="txtWeight" runat="server" CssClass="txt" Width="150px"></asp:TextBox>&nbsp;
    <br />
    <br />
    <asp:Label ID="lblKeywords" runat="server" CssClass="translabel" Text="Keywords Meta" Width="154px"></asp:Label>
    <asp:Label ID="lblCodApplicable" runat="server" CssClass="translabel" Text="COD Applicable" Width="158px"></asp:Label>
    <asp:Label ID="lblDispatchTime" runat="server" CssClass="translabel" Text="Dispatch Time" Width="166px"></asp:Label>
    <asp:Label ID="lblShippingCharge" runat="server" CssClass="translabel" Text="Shipping Charge" Width="168px"></asp:Label>
    <asp:Label ID="lblWarranty" runat="server" CssClass="translabel" Text="Warranty"></asp:Label>
    <br />
    <asp:TextBox ID="txtKeywords" runat="server" CssClass="txt" Width="150px"></asp:TextBox>&nbsp;
    <asp:DropDownList ID="ddlCodApplicable" runat="server" CssClass="ddl" Width="150px">
        <asp:ListItem Value="0">Select...</asp:ListItem>
        <asp:ListItem Value="Yes">Yes</asp:ListItem>
        <asp:ListItem Value="No">No</asp:ListItem>
    </asp:DropDownList>&nbsp;
    <asp:TextBox ID="txtDispatchTime" runat="server" CssClass="txt" Width="150px"></asp:TextBox>&nbsp;
    <asp:TextBox ID="txtShippingCharge" runat="server" CssClass="txt" Width="150px"></asp:TextBox>&nbsp;
    <asp:TextBox ID="txtWarranty" runat="server" CssClass="txt" Width="150px"></asp:TextBox>&nbsp;
    <br />
    <asp:Button ID="btnSearch" runat="server" CssClass="btn" Text="Search" OnClick="btnSearch_Click" />    
    <br />
    <div class="rounded_corners" style="width: 100%">

        <asp:GridView ID="GvProductMangmt" runat="server" Width="100%" HeaderStyle-BackColor="#3F8CD6" RowStyle-CssClass="GvGrid"
            HeaderStyle-ForeColor="White" RowStyle-BackColor="#77AEE1" AlternatingRowStyle-BackColor="White" AllowPaging="true"
            RowStyle-ForeColor="#3A3A3A" AutoGenerateColumns="False" OnRowCommand="GvProductMangmt_RowCommand">
            <AlternatingRowStyle BackColor="White"></AlternatingRowStyle>
            <Columns>

                <asp:BoundField DataField="productName" HeaderText="Name" />
                <asp:ImageField HeaderText="Image" DataImageUrlField="imageUrl" ControlStyle-Height="20px" ControlStyle-Width="20px" />
                <asp:BoundField DataField="productPrice" HeaderText="Price" />
                <asp:BoundField DataField="stockQuantity" HeaderText="Stock Quantity" />
                <asp:BoundField DataField="feature1" HeaderText="1st Feature" />
                <asp:BoundField DataField="dateCreated" HeaderText="Date Created" Visible="false" />
                <asp:BoundField DataField="dateModified" HeaderText="Date Modified" Visible="false" />
                <asp:BoundField DataField="feature2" HeaderText="2nd Feature" />
                <%-- <asp:BoundField DataField="isShippingFree" HeaderText="Shipping Charge Applicable" HeaderStyle-Width="15%" />--%>
                <asp:BoundField DataField="feature3" HeaderText="3rd Feature" />
                <asp:BoundField DataField="feature4" HeaderText="4th Feature" />
                <asp:BoundField DataField="isHot" HeaderText="Is Hot" />
                <asp:BoundField DataField="codApplicable" HeaderText="Cod Applicable" />
                <asp:BoundField DataField="dispatchTime" HeaderText="Dispatch Time" />
                <asp:BoundField DataField="shippingCharge" HeaderText="Shipping Charge" />
                <%--<asp:BoundField DataField="shippingCharge" HeaderText="Shipping Charge" />--%>
                <asp:BoundField DataField="warranty" HeaderText="Warranty" />
                <%--   <asp:BoundField DataField="isDeleted" HeaderText="IsDeleted" Visible="false" />--%>
                <%--<asp:ButtonField DataTextField="select" HeaderText="Edit"/>--%>
                <asp:TemplateField HeaderText="Select">
                    <ItemTemplate>
                        <%-- <asp:LinkButton runat="server" CommandName="edit">Edit</asp:LinkButton>--%>
                        <asp:Button runat="server" Text="" CommandName="Select" CommandArgument='<%#Eval("id") %>' CssClass="btn" Height="25px" HeaderStyle-Width="10%" />
                    </ItemTemplate>
                </asp:TemplateField>

            </Columns>

            <HeaderStyle BackColor="#3F8CD6" ForeColor="White"></HeaderStyle>

            <RowStyle BackColor="#77AEE1" CssClass="GvGrid" ForeColor="#3A3A3A"></RowStyle>
        </asp:GridView>
    </div>
    <asp:Button runat="server" Text="Add New Product" ID="btnNewProd" CssClass="btn" Width="300px" OnClick="btnNewProd_Click" />
</asp:Content>
