<%@ Page Title="" Language="C#" MasterPageFile="~/admin/Sellers.Master" AutoEventWireup="true" CodeBehind="test.aspx.cs" Inherits="etEcom.test" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="//code.jquery.com/ui/1.11.2/themes/smoothness/jquery-ui.css" />
    <script src="//code.jquery.com/jquery-1.10.2.js"></script>
    <link href="Style/GlobalV3.css" rel="stylesheet" />
    <script src="//code.jquery.com/ui/1.11.2/jquery-ui.js"></script>
    <script>
        $(function () {
            $(document.getElementById('<%= txtDatePicker.ClientID %>')).datepicker();
        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
    <br />
    <asp:GridView ID="GridView1" runat="server"></asp:GridView>
    <br />
    <br />
    <br />
    &nbsp;
    <asp:Button ID="Button1" runat="server" Text="BUTTON" class="button" />
    <br />
    <br />
    <br />
    &nbsp;<asp:DropDownList ID="DropDownList1" runat="server" class="dropDownLists">
        <asp:ListItem>one</asp:ListItem>
        <asp:ListItem>two</asp:ListItem>
        <asp:ListItem>three</asp:ListItem>
        <asp:ListItem>four</asp:ListItem>
        <asp:ListItem>five</asp:ListItem>
        <asp:ListItem>six</asp:ListItem>
        <asp:ListItem>seventh</asp:ListItem>
    </asp:DropDownList>
    <br />
    <br />
    &nbsp;<div class="check">
        <asp:CheckBox ID="CheckBox1" runat="server" CssClass="checkbox-css" />
    </div>
    <br />
    <br />
    <div class="check">
        <asp:CheckBox ID="cbActive" runat="server" />
        <asp:Label ID="Label3" AssociatedControlID="cbActive" runat="server"
            Text=""></asp:Label>
    </div>
    <br />
    <br />
    <br />
    &nbsp;
    <asp:RadioButton ID="RadioButton1" runat="server" class="radio" />
    <br />
    <br />
    <br />
    <asp:Label ID="Label1" runat="server" Text="Label" class="simpleLabel"></asp:Label>
    <%--<asp:Label ID="Label2" runat="server" Text="Label" class="label"></asp:Label>--%>
    <asp:Label ID="Label4" runat="server" Text="Label" class="translabel"></asp:Label>
    <br />
    <br />
    <br />
    <div class="sky-form">
        <div class="sky_form1">
            <ul>
                <li>
                    <label class="radio left">
                        <asp:RadioButton ID="rdbutton" runat="server" GroupName="hello" /><i></i>Male</label></li>
                <li>
                    <label class="radio">
                        <asp:RadioButton ID="rdButton2" runat="server" GroupName="hello" /><i></i>Female</label></li>
            </ul>
        </div>
    </div>
    <br />
    <br />
    <br />
    <br />
    <div class="sky-form">
        <div class="sky_form1">
            <ul>
                <li>
                    <label class="checkbox">
                        <asp:CheckBox ID="checkbox" runat="server" /><i></i>Male</label></li>
                <li>
                    <label class="checkbox">
                        <asp:CheckBox ID="checkbox2" runat="server" /><i></i>Female</label></li>
            </ul>
        </div>
    </div>
    <br />
    <asp:TextBox ID="txtDatePicker" runat="server"></asp:TextBox>
    <br />
    <table class="table">
        
        <tr><td></td><td></td><td></td></tr>
    </table>
    <asp:Table runat="server" ID="ttblProducts" CssClass="table"></asp:Table>
</asp:Content>
