<%@ Page Title="" Language="C#" MasterPageFile="~/admin/Sellers.Master" AutoEventWireup="true" CodeBehind="CreateProduct.aspx.cs" Inherits="etEcom.admin.CreateProduct" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../Style/GlobalV2.css" rel="stylesheet" />
    <%--    <link href="../Style/Global.css" rel="stylesheet" /> --%>
    <link href="../Style/GlobalV3.css" rel="stylesheet" />
    <script>
        function openpopup(FileURL) {

        }
        function txtParentCategoryTextChanged(txtParentCategory) {
            var l = document.getElementById('<%= lstCParentCategory.ClientID %>');
            var txt = txtParentCategory;
            if (txt.value == "") {
                $(l.options).show();
            }
            else {
                for (var i = 0; i < l.options.length; i++) {
                    if (l.options[i].innerHTML.toLowerCase().match(txt.value.toLowerCase())) {
                        $(l.options[i]).show();
                    }
                    else {
                        $(l.options[i]).hide();
                    }
                }
            }
        }
        function txtParentCategory() {
            document.getElementById("<%=lstCParentCategory.ClientID%>").style.visibility = "visible";
        }
        function txtCategoryName() {
            document.getElementById("<%=lstPCategoryName.ClientID%>").style.visibility = "visible";
        }
        function txtBrandName() {
            document.getElementById("<%=lstPBrandName.ClientID%>").style.visibility = "visible";
        }
        function ddlCFeatureItemsChange(ddlCategoryItems) {
            if (ddlCategoryItems.value == 1) {
                document.getElementById("addInput1").style.display = "block";
                document.getElementById("addInput2").style.display = "none";
                document.getElementById("addInput3").style.display = "none";
                document.getElementById("addInput4").style.display = "none";
            }
            if (ddlCategoryItems.value == 2) {
                document.getElementById("addInput1").style.display = "block";
                document.getElementById("addInput2").style.display = "block";
                document.getElementById("addInput3").style.display = "none";
                document.getElementById("addInput4").style.display = "none";
            }
            if (ddlCategoryItems.value == 3) {
                document.getElementById("addInput1").style.display = "block";
                document.getElementById("addInput2").style.display = "block";
                document.getElementById("addInput3").style.display = "block";
                document.getElementById("addInput4").style.display = "none";
            }
            if (ddlCategoryItems.value == 4) {
                document.getElementById("addInput1").style.display = "block";
                document.getElementById("addInput2").style.display = "block";
                document.getElementById("addInput3").style.display = "block";
                document.getElementById("addInput4").style.display = "block";
            }
            <%--document.getElementById("<%=ddlFeatureCategoryItems.ClientID%>")--%>
        }
        function txtCategoryNameTextChanged(txtCategoryName) {
            var l = document.getElementById('<%= lstPCategoryName.ClientID %>');
            var txt = txtCategoryName;
            if (txt.value == "") {
                $(l.options).show();
            }
            else {
                for (var i = 0; i < l.options.length; i++) {
                    if (l.options[i].innerHTML.toLowerCase().match(txt.value.toLowerCase())) {
                        $(l.options[i]).show();
                    }
                    else {
                        $(l.options[i]).hide();
                    }
                }
            }
        }
        function txtBrandNameTextChanged(txtBrandName) {
            var l = document.getElementById('<%= lstPBrandName.ClientID %>');
            var txt = txtBrandName;
            if (txt.value == "") {
                $(l.options).show();
            }
            else {
                for (var i = 0; i < l.options.length; i++) {
                    if (l.options[i].innerHTML.toLowerCase().match(txt.value.toLowerCase())) {
                        $(l.options[i]).show();
                    }
                    else {
                        $(l.options[i]).hide();
                    }
                }
            }
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="height: 100%; width: 100%; float: left;">
        <div style="height: 100%; width: 30%; float: left; border: 1px solid black;" id="createCategoryDiv">
            <h2>Create a Category</h2>
            <p>Fields marked * are mandatory.</p>
        </div>
        <div style="height: 100%; width: 30%; float: left; border: 1px solid black;" id="createBrandDiv">
            <h2>Create a Brand</h2>
            <p>Fields marked * are mandatory.</p>
        </div>
        <div style="height: 100%; width: 40%; float: left; border: 1px solid black;" id="createProductDiv">
            <h2>Create a Product</h2>
            <p>Fields marked * are mandatory.</p>
        </div>
        <div style="height: 100%; width: 30%; float: left; border: 1px solid black;" id="categoryDiv">
            <div style="height: 100%; width: 40%; float: left;" id="categoryDiv1">
                <br />
                <asp:Label ID="lblCategoryName" runat="server" Text="Category Name" CssClass="translabel"></asp:Label>(*)
            <br />
                <br />
                <asp:Label ID="lblCDesc" runat="server" Text="Category Description" CssClass="translabel"></asp:Label>
                <br />
                <br />
                <asp:Label ID="lblCParentCategory" runat="server" Text="Parent Category" CssClass="translabel"></asp:Label>(*)
            <br />
                <br />
                <br />
                <br />
                <br />
                <br />
                <asp:Label ID="lblFeatureCategory1" runat="server" Text="No. of Category Feature Items" CssClass="translabel"></asp:Label>(*)
            <br />
                <br />
                <br />
                <asp:ValidationSummary ID="valSummaryCategory" runat="server" ShowSummary="false" ShowMessageBox="false" EnableClientScript="true" />
                <asp:Label ID="lblSuccessfulCategory" runat="server" Text=""></asp:Label>
            </div>
            <div style="height: 100%; width: 60%; float: left;" id="categoryDiv2">
                <br />
                <asp:TextBox ID="txtCategoryName" runat="server" CssClass="txt" onclick="openpopup('ProductPopup.aspx')"></asp:TextBox>&nbsp;
            <asp:RequiredFieldValidator ID="validateCategory" runat="server" ErrorMessage="*" ControlToValidate="txtCategoryName" Font-Bold="True" Font-Overline="False" Font-Size="Medium" Font-Underline="False" ForeColor="Red" ValidationGroup="Category"></asp:RequiredFieldValidator>
                <br />
                <br />
                <asp:TextBox ID="txtCDesc" runat="server" CssClass="txt"></asp:TextBox>&nbsp;
            <br />
                <br />
                <asp:TextBox ID="txtCParentCategory" runat="server" CssClass="dropDownLists" AutoPostBack="true" onclick="txtParentCategory()" oninput="txtParentCategoryTextChanged(this)"></asp:TextBox>
                <asp:ListBox ID="lstCParentCategory" runat="server" CssClass="txt" Style="visibility: hidden;"></asp:ListBox>&nbsp;
            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="*" ControlToValidate="lstCParentCategory" Font-Bold="True" Font-Overline="False" Font-Size="Medium" Font-Underline="False" ForeColor="Red" ValidationGroup="Category"></asp:RequiredFieldValidator>
                <br />
                <br />
                <asp:DropDownList ID="ddlFeatureCategoryItems" runat="server" CssClass="dropDownLists" onchange="ddlCFeatureItemsChange(this)">
                    <asp:ListItem>1</asp:ListItem>
                    <asp:ListItem>2</asp:ListItem>
                    <asp:ListItem>3</asp:ListItem>
                    <asp:ListItem>4</asp:ListItem>
                </asp:DropDownList>items
            <div id="addInput1" style="display: block;">
                <br />
                <br />
                <asp:TextBox ID="txtFeatureCategoryItem1" runat="server" CssClass="txt"></asp:TextBox>&nbsp;
                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="*" ControlToValidate="txtFeatureCategoryItem1" Font-Bold="True" Font-Overline="False" Font-Size="Medium" Font-Underline="False" ForeColor="Red" ValidationGroup="Category"></asp:RequiredFieldValidator>
            </div>
                <div id="addInput2" style="display: none;">
                    <br />
                    <br />
                    <asp:TextBox ID="txtFeatureCategoryItem2" runat="server" CssClass="txt"></asp:TextBox>
                </div>
                <div id="addInput3" style="display: none;">
                    <br />
                    <br />
                    <asp:TextBox ID="txtFeatureCategoryItem3" runat="server" CssClass="txt"></asp:TextBox>
                </div>
                <div id="addInput4" style="display: none;">
                    <br />
                    <br />
                    <asp:TextBox ID="txtFeatureCategoryItem4" runat="server" CssClass="txt"></asp:TextBox>
                </div>
                <br />
                <asp:Button ID="btnCategory" runat="server" Text="Create Category" CssClass="button" OnClick="btnCategory_Click" ValidationGroup="Category" />
            </div>
        </div>
        <div style="height: 100%; width: 30%; float: left; border: 1px solid black;" id="brandDiv">
            <div style="height: 100%; width: 40%; float: left;" id="brandDiv1">
                <br />
                <asp:Label ID="lblBName" runat="server" Text="Brand Name" CssClass="translabel"></asp:Label>(*)
            <br />
                <br />
                <asp:Label ID="lblBDiscount" runat="server" Text="Promotional Discount" CssClass="translabel"></asp:Label>
                <br />
                <br />
                <asp:Label ID="lblBRating" runat="server" Text="Brand Rating" CssClass="translabel"></asp:Label>(*)
            <br />
                <br />
                <br />
                <br />
                <br />
                <asp:ValidationSummary ID="valSummaryBrand" runat="server" ShowSummary="false" ShowMessageBox="false" EnableClientScript="true" ValidationGroup="Brand" />
                <asp:Label ID="lblSuccessfulBrand" runat="server" Text=""></asp:Label>
                <br />
            </div>
            <div style="height: 100%; width: 60%; float: left;" id="brandDiv2">
                <br />
                &nbsp;&nbsp;
            <asp:TextBox ID="txtBName" runat="server" CssClass="txt"></asp:TextBox>
                &nbsp;<asp:RequiredFieldValidator ID="validateBrandName" runat="server" ErrorMessage="*" ControlToValidate="txtBName" Font-Bold="True" Font-Overline="False" Font-Size="Medium" Font-Underline="False" ForeColor="Red" ValidationGroup="Brand"></asp:RequiredFieldValidator>
                <br />
                <br />
                &nbsp;&nbsp;
            <asp:TextBox ID="txtBDiscount" runat="server" CssClass="txt"></asp:TextBox>%
            <br />
                <br />
                <br />
                &nbsp;&nbsp;
            <asp:DropDownList ID="ddlBRating" runat="server" CssClass="dropDownLists">
                <asp:ListItem>1</asp:ListItem>
                <asp:ListItem>2</asp:ListItem>
                <asp:ListItem>3</asp:ListItem>
                <asp:ListItem>4</asp:ListItem>
                <asp:ListItem>5</asp:ListItem>
            </asp:DropDownList>/5 Stars&nbsp;
            <br />
                <br />
                <br />
                <asp:Button ID="btnBrand" runat="server" Text="Create Brand" CssClass="button" OnClick="btnBrand_Click" ValidationGroup="Brand" />
            </div>
        </div>
        <div style="height: 100%; width: 40%; float: left; border: 1px solid black;" id="productDiv">
            <div style="height: 100%; width: 40%; float: left;" id="productDiv1">
                <br />
                <asp:Label ID="lblPCategoryName" runat="server" Text="Category Name" CssClass="translabel"></asp:Label>(*)
            <br />
                <br />
                <br />
                <br />
                <br />
                <br />
                <br />
                <asp:Label ID="lblPBrandName" runat="server" Text="Brand Name" CssClass="translabel"></asp:Label>
                <br />
                <br />
                <br />
                <br />
                <br />
                <br />
                <asp:Label ID="lblProductName" runat="server" Text="Product Name" CssClass="translabel"></asp:Label>(*)
            <br />
                <br />
                <asp:Label ID="lblProductPrice" runat="server" Text="Product Price" CssClass="translabel"></asp:Label>(*)
            <br />
                <br />
                <asp:Label ID="lblPStockQty" runat="server" Text="Stock Quantity" CssClass="translabel"></asp:Label>(*)
            <br />
                <br />
                <asp:Label ID="lblWeight" runat="server" Text="Product Weight" CssClass="translabel"></asp:Label>(*)
                <br />
                <br />
                <asp:Label ID="lblShippingCharge" runat="server" Text="Shipping Charge" CssClass="translabel"></asp:Label>(*)
            <br />
                <br />
                <asp:Label ID="lblKeywords" runat="server" Text="Keywords/ Metadata" CssClass="translabel"></asp:Label>(*)
            <br />
                <br />
                <br />
                <br />
                <asp:Label ID="lblDispatchTime" runat="server" Text="Dispatch Time" CssClass="translabel"></asp:Label>(*)
            <br />
                <br />
                <asp:Label ID="lblCODApplicable" runat="server" Text="COD Applicable" CssClass="translabel"></asp:Label>(*)
                <br />
                <br />
                <br />
                <asp:Label ID="lblImageURL" runat="server" Text="Image URL" CssClass="translabel"></asp:Label>(*)
            <br />
                <br />
                <asp:Label ID="lblDescription" runat="server" Text="Description" CssClass="translabel"></asp:Label>(*)
            <br />
                <br />
                <br />
                <asp:Label ID="lblWarranty" runat="server" Text="Warranty" CssClass="translabel"></asp:Label>(*)
            <br />
                <br />
                <br />
                <br />
                <div class="sky-form" style="float:right">
                    <div class="sky_form1">
                        <ul>
                            <li>
                                <label class="checkbox">
                                    <asp:CheckBox ID="checkHot" runat="server" /><i></i>Is Hot</label></li>
                        </ul>
                    </div>
                </div>
                <br />
                <div id="addProductFeatureNames"></div>
                <asp:ValidationSummary ID="valSummaryProduct" runat="server" ShowSummary="false" ShowMessageBox="false" EnableClientScript="true" ValidationGroup="Product" />
                <asp:Label ID="lblSuccessfulProduct" runat="server"></asp:Label>
                <br />
                <br />
            </div>
            <div style="height: 100%; width: 60%; float: left;" id="productDiv2">
                <br />
                <asp:TextBox ID="txtPCategoryName" runat="server" CssClass="dropDownLists" onclick="txtCategoryName()" oninput="txtCategoryNameTextChanged(this)"></asp:TextBox>
                <asp:ListBox ID="lstPCategoryName" runat="server" CssClass="txt" Style="visibility: hidden"></asp:ListBox>
                &nbsp;<asp:RequiredFieldValidator ID="validateCategoryName" runat="server" ControlToValidate="lstPCategoryName" ErrorMessage="*" Font-Size="Medium" ForeColor="Red" ValidationGroup="Product"></asp:RequiredFieldValidator>
                <br />
                <br />
                <asp:TextBox ID="txtPBrandName" runat="server" CssClass="dropDownLists" onclick="txtBrandName()" oninput="txtBrandNameTextChanged(this)"></asp:TextBox>
                <asp:ListBox ID="lstPBrandName" runat="server" CssClass="txt" Style="visibility: hidden;"></asp:ListBox>
                &nbsp;<asp:RequiredFieldValidator ID="valBrandName" runat="server" ControlToValidate="lstPBrandName" ErrorMessage="*" Font-Size="Medium" ForeColor="Red" ValidationGroup="Product"></asp:RequiredFieldValidator>
                <br />
                <br />
                <br />
                <asp:TextBox ID="txtProductName" runat="server" CssClass="txt"></asp:TextBox>
                &nbsp;<asp:RequiredFieldValidator ID="valProductName" runat="server" ControlToValidate="txtProductName" ErrorMessage="*" Font-Size="Medium" ForeColor="Red" ValidationGroup="Product"></asp:RequiredFieldValidator>
                <br />
                <br />
                <asp:TextBox ID="txtProductPrice" runat="server" CssClass="txt"></asp:TextBox>Rs.
            <asp:RequiredFieldValidator ID="valProductPrice" runat="server" ControlToValidate="txtProductPrice" ErrorMessage="*" Font-Size="Medium" ForeColor="Red" ValidationGroup="Product"></asp:RequiredFieldValidator>
                <br />
                <br />
                <asp:TextBox ID="txtPStockQty" runat="server" CssClass="txt"></asp:TextBox>pcs.
            <asp:RequiredFieldValidator ID="valStockQty" runat="server" ControlToValidate="txtPStockQty" ErrorMessage="*" Font-Size="Medium" ForeColor="Red" ValidationGroup="Product"></asp:RequiredFieldValidator>
                <br />
                <br />
                <asp:TextBox ID="txtWeight" runat="server" CssClass="txt"></asp:TextBox>
                <asp:DropDownList runat="server" ID="ddlWeight" Height="100%" Width="22%">
                    <asp:ListItem>gms.</asp:ListItem>
                    <asp:ListItem>kgs.</asp:ListItem>
                </asp:DropDownList>
                &nbsp;<asp:RequiredFieldValidator ID="valWeight" runat="server" ControlToValidate="txtWeight" ErrorMessage="*" Font-Size="Medium" ForeColor="Red" ValidationGroup="Product"></asp:RequiredFieldValidator>
                <br />
                <br />
                <asp:TextBox ID="txtShippingCharge" runat="server" CssClass="txt"></asp:TextBox>Rs.
            &nbsp;<asp:RequiredFieldValidator ID="valShippingApplicable" runat="server" ControlToValidate="txtShippingCharge" ErrorMessage="*" Font-Size="Medium" ForeColor="Red" ValidationGroup="Product"></asp:RequiredFieldValidator>
                <br />
                <br />
                <asp:TextBox TextMode="MultiLine" Width="80%" Height="20%" ID="txtKeywords" runat="server" CssClass="txt"></asp:TextBox>
                &nbsp;<asp:RequiredFieldValidator ID="valKeywords" runat="server" ControlToValidate="txtKeywords" ErrorMessage="*" Font-Size="Medium" ForeColor="Red" ValidationGroup="Product"></asp:RequiredFieldValidator>
                <br />
                <br />
                <asp:DropDownList ID="ddlDispatchTime" runat="server" CssClass="dropDownLists">
                    <asp:ListItem>1</asp:ListItem>
                    <asp:ListItem>2</asp:ListItem>
                    <asp:ListItem>3</asp:ListItem>
                    <asp:ListItem>4</asp:ListItem>
                    <asp:ListItem>5</asp:ListItem>
                </asp:DropDownList>
                days
            <asp:RequiredFieldValidator ID="valDispatchTime" runat="server" ControlToValidate="ddlDispatchTime" ErrorMessage="*" Font-Size="Medium" ForeColor="Red" ValidationGroup="Product"></asp:RequiredFieldValidator>
                <br />
                <br />
                <asp:DropDownList ID="ddlCODApplicable" runat="server" CssClass="dropDownLists">
                    <asp:ListItem>Yes</asp:ListItem>
                    <asp:ListItem>No</asp:ListItem>
                </asp:DropDownList>
                &nbsp;<asp:RequiredFieldValidator ID="valCODApplicable" runat="server" ControlToValidate="ddlCODApplicable" ErrorMessage="*" Font-Size="Medium" ForeColor="Red" ValidationGroup="Product"></asp:RequiredFieldValidator>
                <br />
                <br />
                <br />
                <asp:FileUpload ID="flImage" runat="server" />
                <br />
                <br />
                <asp:TextBox runat="server" ID="txtDesc" CssClass="txt" TextMode="MultiLine"></asp:TextBox>
                <br />
                <br />
                <asp:TextBox runat="server" ID="txtWarranty" CssClass="txt"></asp:TextBox>
                <br />
                <br />
                <br />
                <br />
                <br />
                <div id="addProductFeatureTexts"></div>
                <asp:Button ID="btnProduct" runat="server" OnClick="btnProduct_Click" Text="Create Product" CssClass="button" Width="227px" ValidationGroup="Product" />
                <%----%>
            </div>
        </div>
    </div>
</asp:Content>
