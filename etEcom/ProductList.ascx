<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ProductList.ascx.cs" Inherits="etEcom.ProductList" %>
<link href="Content/style.css" rel="stylesheet" />
<link href="Content/bootstrap.css" rel="stylesheet" />
<link href="Content/megamenu.css" rel="stylesheet" />
<link href="Content/fwslider.css" rel="stylesheet" />
<link href="Style/GlobalV3.css" rel="stylesheet" />
<link href="Content/etalage.css" rel="stylesheet" />
<script src="Scripts/jquery-ui.min.js"></script>
<script src="Scripts/jquery.etalage.min.js"></script>
<script src="Scripts/bootstrap.js"></script>
<script src="Scripts/fwslider.js"></script>
<script src="Scripts/jquery-1.11.1.min.js"></script>
<script src="Scripts/menu_jquery.js"></script>
<script src="Scripts/modernizr-2.6.2.js"></script>
<script>$(document).ready(function () { $(".megamenu").megamenu(); });</script>
<script src="Scripts/megamenu.js"></script>
<style>
    /*.menu:hover {
    background-color: #00405d;
    border: 3px solid #ffcc33;
    font-family: "Algerian";
    <!--,Castellar,Cooper Black,Arial Black,Impact,Cursive,Times New Roman; -->
}*/
    /* .menu {
    background-color: whitesmoke;
    border-color:navajowhite;
    color: darkgray;
    padding: 0px;
    font-family: "Forte"; 
   Brush Script MT,Curlz MT,Chiller,Monospace,Baskerville Old Face; -->
}*/
    .img {
        width: 150px;
        height: 200px;
        margin-left: 50px;
        margin-right: 20px;
        cursor:pointer;
    }
    .labels {
        margin-left: 20px;
        margin-right:20px;
        text-align: right;
    }
</style>
<link href='http://fonts.googleapis.com/css?family=Open+Sans' rel='stylesheet' type='text/css' />
<!-- grids_of_4 -->
    <div class="grid1_of_4 menu" style="width: 260px;">
                    <asp:ImageButton runat="server" ID="productImage" CssClass="img" OnClientClick="productImage_Click" OnClick="productImage_Click" />
        <div>
            <h4>
            <asp:Label runat="server" ID="lblProductName" CssClass="labels"></asp:Label></h4>
            <asp:Label runat="server" ID="lblProductPrice" CssClass="labels"></asp:Label><br />
            <h4><asp:Label runat="server" ID="lblFeatures" CssClass="labels" Text="Features:"></asp:Label></h4>            
            <asp:Label runat="server" ID="lblFeature1" CssClass="labels"></asp:Label><br />
            <asp:Label runat="server" ID="lblFeature2" CssClass="labels"></asp:Label><br />
            <asp:Label runat="server" ID="lblFeature3" CssClass="labels"></asp:Label><br />
            <asp:Label runat="server" ID="lblFeature4" CssClass="labels"></asp:Label><br />
            <asp:Label runat="server" ID="lblFeature5" CssClass="labels"></asp:Label><br />
            <asp:Label runat="server" ID="lblFeature6" CssClass="labels"></asp:Label><br />
            <asp:Label runat="server" ID="lblFeature7" CssClass="labels"></asp:Label><br />
            <asp:Label runat="server" ID="lblFeature8" CssClass="labels"></asp:Label><br />
        </div>
    </div>
<!-- end grids_of_4 -->
