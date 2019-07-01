<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UpdateAccount.aspx.cs" Inherits="etEcom.UpdateAccount" %>

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
            <h2>Update Your Account</h2>
        </div>
        <div class="container">
            <div class="registration_form">
<fieldset>
                <legend>Address Details</legend>
                <div>
                    <label>
                    <asp:TextBox runat="server" ID="txtHouseNo"  placeholder="House Number" Width="300px" TabIndex="1"></asp:TextBox>
                    <asp:RequiredFieldValidator runat="server" ID="rfvHNo" ErrorMessage="*"  ControlToValidate="txtHouseNo" Font-Bold="True" Font-Overline="False" Font-Size="Medium" Font-Underline="False" ForeColor="Red"></asp:RequiredFieldValidator>
                        </label>
                </div>
                 <div>
                     <label>
                    <asp:TextBox runat="server" ID="txtStreetNo" placeholder="Street Number" Width="300px" TabIndex="1"></asp:TextBox>
                    <asp:RequiredFieldValidator runat="server" ID="rfvStreetNo" ErrorMessage="*"  ControlToValidate="txtStreetNo" Font-Bold="True" Font-Overline="False" Font-Size="Medium" Font-Underline="False" ForeColor="Red"></asp:RequiredFieldValidator>
                         </label>
                </div>
                 <div>
                     <label>
                    <asp:TextBox runat="server" ID="txtLandmark" placeholder="Landmark" Width="300px" TabIndex="1"></asp:TextBox>
                    <asp:RequiredFieldValidator runat="server" ID="rfvLandmark" ErrorMessage="*"  ControlToValidate="txtLandmark" Font-Bold="True" Font-Overline="False" Font-Size="Medium" Font-Underline="False" ForeColor="Red"></asp:RequiredFieldValidator>
                         </label>
                </div>
                   <div>
                            <asp:DropDownList runat="server" ID="ddlCountry" Width="100px" CssClass="ddl" TabIndex="1">
                                <asp:ListItem Value="-1">Select...</asp:ListItem>
                                <asp:ListItem Value="0">India</asp:ListItem>
                                <asp:ListItem Value="1">Pakistan</asp:ListItem>
                                <asp:ListItem Value="1"></asp:ListItem>
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator runat="server" ID="rfvCountry" ErrorMessage="*" ForeColor="Red" ControlToValidate="ddlCountry" ValidationGroup="SignUp"></asp:RequiredFieldValidator>
                            &nbsp;                      
                 <label>
                     <asp:DropDownList runat="server" ID="ddlState" Width="100px" CssClass="ddl" TabIndex="1" AutoPostBack="true" OnSelectedIndexChanged="ddlState_SelectedIndexChanged" >
                         <asp:ListItem>Select...</asp:ListItem>
                     </asp:DropDownList>
                     <asp:RequiredFieldValidator ID="rfvState" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="ddlState" ValidationGroup="SignUp"></asp:RequiredFieldValidator>
                 </label>

                            &nbsp;   
                 <label>
                     <asp:DropDownList runat="server" ID="ddlCity" CssClass="ddl" Width="100px" TabIndex="1">
                         <asp:ListItem>Select...</asp:ListItem>
                     </asp:DropDownList></label><br />
                            <asp:RequiredFieldValidator ID="rfvCity" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="ddlCity" ValidationGroup="SignUp"></asp:RequiredFieldValidator>
                       
                            <label>
                                <asp:DropDownList runat="server" ID="ddlAddType" CssClass="ddl" Width="100px" TabIndex="1">
                                    <asp:ListItem Value="-1">Select...</asp:ListItem>
                                    <asp:ListItem Value="0">Shipping</asp:ListItem>
                                    <asp:ListItem Value="1">Billing</asp:ListItem>
                                    <asp:ListItem Value="2">Permanent</asp:ListItem>
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="rfvAddType" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="ddlAddType" ValidationGroup="SignUp"></asp:RequiredFieldValidator>
                            </label>
                        </div>               

              
           </fieldset>
            <fieldset>
                <legend> Personal Details</legend>
                <div>
                    <label>
                    <asp:TextBox ID="txtName" runat="server" placeholder="Name" Width="300px" TabIndex="1"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvName" runat="server" ErrorMessage="*" ControlToValidate="txtName" Font-Bold="True" Font-Overline="False" Font-Size="Medium" Font-Underline="False" ForeColor="Red"></asp:RequiredFieldValidator>
                    </label>
                </div>
                <div>
                    <label>
                        <asp:TextBox runat="server" ID="txtMobileNo" palceholder="Mobile Number" Width="300px" TabIndex="1"></asp:TextBox>
                        <asp:RequiredFieldValidator runat="server" ID="rfvMobNo" ErrorMessage="*" ControlToValidate="txtName" Font-Bold="True" Font-Overline="False" Font-Size="Medium" Font-Underline="False" ForeColor="Red"></asp:RequiredFieldValidator>
                    </label>
                </div>  
              
                 <div class="sky-form">
                        <div class="sky_form1">
                            <ul>
                                <label class="radio left">
                                    <asp:RadioButton runat="server" ID="rbtnMale" GroupName="gender" Checked="true" /><i></i>Male</label>
                                <label class="radio">
                                    <asp:RadioButton runat="server" ID="rbtnFemale" GroupName="gender" /><i></i>Female</label>
                                <div class="clearfix"></div>
                            </ul>
                        </div>
                    </div>
                    <br />
                <div>
                    <label>
                    <asp:TextBox runat="server" ID="txtOldPwd" Width="300px" placeholder="Old password" TextMode="Password" TabIndex="1"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvOldPwd" runat="server" ErrorMessage="*" ControlToValidate="txtOldPwd" Font-Bold="True" Font-Overline="False" Font-Size="Medium" Font-Underline="False" ForeColor="Red"></asp:RequiredFieldValidator>
                    </label>
                </div>
                <div>
                    <label>
                    <asp:TextBox runat="server" ID="txtNewPwd" Width="300px" placeholder="New password" TextMode="Password" TabIndex="1"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvnewPwd" runat="server" ErrorMessage="*"  ControlToValidate="txtNewPwd" Font-Bold="True" Font-Overline="False" Font-Size="Medium" Font-Underline="False" ForeColor="Red"></asp:RequiredFieldValidator>
                        </label>
                </div>           
              <asp:Button runat="server" ID="btnUpdateAccnt" Text="Update" CssClass="btn" OnClick="btnUpdateAccnt_Click" />
                 </fieldset>
        </div>
            </div>
    </form>
</body>
</html>
