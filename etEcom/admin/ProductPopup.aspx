<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ProductPopup.aspx.cs" Inherits="etEcom.admin.ProductPopup" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Product Feature Items</title>
    <link href="../Style/GlobalV2.css" rel="stylesheet" />
</head>
<body>
    <form runat="server">
        <div style="height:100%;width:100%">
    <div style="height:100%;width:50%; float:left;">
    
        <asp:Label ID="lblProductFeature1" runat="server" Text=""></asp:Label>
        <br />
        <br />
        <br />
        <asp:Label ID="lblProductFeature2" runat="server" Text=""></asp:Label>
        <br />
        <br />
        <br />
        <asp:Label ID="lblProductFeature3" runat="server" Text=""></asp:Label>
        <br />
        <br />
        <br />
        <asp:Label ID="lblProductFeature4" runat="server" Text=""></asp:Label>
    </div>
    <div style="height:100%;width:50%;float:right;">
        <asp:TextBox ID="txtProductFeature1" runat="server" CssClass="txt"></asp:TextBox>
        <br />
        <br />
        <br />
        <asp:TextBox ID="txtProductFeature2" runat="server" CssClass="txt"></asp:TextBox>
        <br />
        <br />
        <br />
        <asp:TextBox ID="txtProductFeature3" runat="server" CssClass="txt"></asp:TextBox>
        <br />
        <br />
        <br />
        <asp:TextBox ID="txtProductFeature4" runat="server" CssClass="txt"></asp:TextBox>
        <br />
        <br />
        <asp:Button ID="btnSubmit" runat="server" CssClass="button" Text="Submit" Width="300px" OnClick="btnSubmit_Click" />
    </div>
            </div>
        </form>
</body>
</html>
