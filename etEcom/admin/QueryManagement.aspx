<%@ Page Title="" Language="C#" MasterPageFile="~/admin/Sellers.Master" AutoEventWireup="true" CodeBehind="QueryManagement.aspx.cs" Inherits="etEcom.admin.QueryManagement" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../Style/GlobalV3.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
    <asp:Label ID="lblName" runat="server" CssClass="translabel" Text="Name" Width="166px"></asp:Label>
    <asp:Label ID="lblEmail" runat="server" CssClass="translabel" Text="EmailId" Width="160px"></asp:Label>
    <asp:Label ID="lblMobNo" runat="server" CssClass="translabel" Text="Mobile Number" Width="152px"></asp:Label>
    <asp:Label ID="lblState" runat="server" CssClass="translabel" Text="State" Width="230px"></asp:Label>
    <asp:Label ID="lblCity" runat="server" CssClass="translabel" Text="City" Width="230px"></asp:Label>
    <br />
    <asp:TextBox ID="txtName" runat="server" CssClass="txt" Width="150px"></asp:TextBox>&nbsp;
    <asp:TextBox ID="txtEmail" runat="server" CssClass="txt" Width="150px"></asp:TextBox>&nbsp;
    <asp:TextBox ID="txtMobNo" runat="server" CssClass="txt" Width="150px"></asp:TextBox>&nbsp;
    <asp:DropDownList ID="ddlState" runat="server" CssClass="ddl" Width="230px" AutoPostBack="true" OnSelectedIndexChanged="ddlState_SelectedIndexChanged"></asp:DropDownList>&nbsp;
    <asp:DropDownList ID="ddlCity" runat="server" CssClass="ddl" Width="230px"></asp:DropDownList>&nbsp;
    <br />
    <asp:Button ID="btnBSearch" runat="server" Text="Search" CssClass="btn" OnClick="btnBSearch_Click"></asp:Button>
    <div class="roundCorners" style="width: 100%;">
        <asp:GridView ID="grdQueryMgmt" runat="server" HeaderStyle-BackColor="#3F8CD6" RowStyle-CssClass="GvGrid"
            HeaderStyle-ForeColor="White" RowStyle-BackColor="#77AEE1" AlternatingRowStyle-BackColor="White" AllowPaging="true"
            RowStyle-ForeColor="#3A3A3A" AutoGenerateColumns="false" Width="100%">
          <%--  <AlternatingRowStyle BackColor="White" />--%>
            <Columns>
                <asp:BoundField DataField="name" HeaderText="Name" />
                <asp:BoundField DataField="emailId" HeaderText="Email Id" />
                <asp:BoundField DataField="mobNo" HeaderText="Mobile Number" />
                <asp:BoundField DataField="query" HeaderText="Query" />
                <asp:BoundField DataField="cityName" HeaderText="City Name" />
                <asp:BoundField DataField="stateName" HeaderText="State Name" />
            </Columns>
        </asp:GridView>
    </div>
</asp:Content>
