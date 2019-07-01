<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ForgotPassword.aspx.cs" Inherits="etEcom.ForgotPassword" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="Content/style.css" rel="stylesheet" />
    <link href="Content/bootstrap.css" rel="stylesheet" />
    <link href="Content/megamenu.css" rel="stylesheet" />
    <link href="Content/fwslider.css" rel="stylesheet" />
    <link href="Style/Global.css" rel="stylesheet" />
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
    <link href='http://fonts.googleapis.com/css?family=Open+Sans' rel='stylesheet' type='text/css' />
    <script type="application/x-javascript"> addEventListener("load", function() { setTimeout(hideURLbar, 0); }, false); function hideURLbar(){ window.scrollTo(0,1); } </script>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h2>Forgot Password</h2>
        </div>
        <div class="container">
            <div class="registration_form">
                <div>
                    <label>
                        <asp:TextBox runat="server" ID="txtUserName" placeholder="Enter Your Existing email id" Width="300px"></asp:TextBox>
                    </label>
                    <br />
                    <br />
                    <br />
                    <label><asp:Label runat="server" ID="lblAlert"></asp:Label></label>
                </div>
                <div>
                    <label>
                        <asp:Button runat="server" ID="btnOk" Text="OK" OnClick="btnOk_Click" />
                    </label>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
