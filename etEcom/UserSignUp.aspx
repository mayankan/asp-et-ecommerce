<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserSignUp.aspx.cs" Inherits="etEcom.UserSignUp" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script>
        function showPanel(txt) {
            document.getElementById('<%= pnlForgotPwd.ClientID %>').style.visibility = "visible";
        }
    </script>
    <link href="Content/style.css" rel="stylesheet" />
    <link href="Content/megamenu.css" rel="stylesheet" />
    <link href="Content/fwslider.css" rel="stylesheet" />
    <link href="Style/GlobalV3.css" rel="stylesheet" />
    <script src="Scripts/jquery-ui.min.js"></script>
    <script src="Scripts/jquery.etalage.min.js"></script>
    <script src="Scripts/bootstrap.js"></script>
    <script src="Scripts/fwslider.js"></script>
    <script src="Scripts/jquery-1.11.1.min.js"></script>
    <script src="Scripts/menu_jquery.js"></script>
    <script src="Scripts/modernizr-2.6.2.js"></script>
    <script>$(document).ready(function () { $(".megamenu").megamenu(); });</script>
    <script src="Scripts/megamenu.js"></script>
</head>
<body>
    <form runat="server">
        <div class="container">
            <div class="registration_left">
                <h2>Existing User</h2>
                <%--<a href="#"><div class="reg_fb"><img src="images/facebook.png" alt=""><i>sign in using Facebook</i><div class="clear"></div></div></a>--%>
                <div class="registration_form">
                    <div>
                        <asp:TextBox runat="server" ID="txtUserName" placeholder="Username" Width="300px" TabIndex="1" CssClass="txt"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvUserName" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="txtUserName" ValidationGroup="SignIN"></asp:RequiredFieldValidator>
                    </div>
                    <div>
                        <asp:TextBox runat="server" ID="txtPwd" placeholder="Password" TextMode="Password" Width="300px" TabIndex="2" CssClass="txt"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvPWD" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="txtPwd" ValidationGroup="SignIN"></asp:RequiredFieldValidator>
                    </div>
                    <div style="float:left">
                        <asp:Label runat="server" Style="cursor: pointer" TabIndex="5" Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Size="Small" Font-Strikeout="False" Font-Underline="True" ForeColor="#000099">Forgot Your Password</asp:Label>
                    </div>
                    <div style="float:left">
                        <asp:Label ID="lblLoginResult" runat="server" Font-Bold="True" ForeColor="Red"></asp:Label>
                    </div>
                    <div>
                        <asp:Button ID="btnSignIn" runat="server" Text="Sign In" OnClick="btnSignIn_Click" ValidationGroup="SignIN" TabIndex="3" CssClass="button" />
                        <asp:ValidationSummary ID="valSummarySignIN" runat="server" ShowMessageBox="false" ShowSummary="false" EnableClientScript="true" />
                    </div>
                </div>
            </div>
            <div class="registration_left" style="margin-left:1em">
                <h2>New User? <span>Create an Account </span></h2>
                <div class="registration_form">
                    <div>
                        <label>
                            <asp:TextBox ID="txtName" runat="server" placeholder="Name" Width="300px" TabIndex="10" CssClass="txt"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvName" runat="server" ErrorMessage="*" ControlToValidate="txtName" Font-Bold="True" Font-Overline="False" Font-Size="Medium" Font-Underline="False" ForeColor="Red" ValidationGroup="SignUp"></asp:RequiredFieldValidator>
                        </label>
                    </div>
                    <fieldset>
                        <legend>Address</legend>
                        <div>
                            <label>
                                <asp:TextBox ID="txtHouseNo" runat="server" placeholder="House Number" TextMode="SingleLine" Width="300px" TabIndex="12" CssClass="txt"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rfvHouseNo" runat="server" ErrorMessage="*" ControlToValidate="txtHouseNo" Font-Bold="True" Font-Overline="False" Font-Size="Medium" Font-Underline="False" ForeColor="Red" ValidationGroup="SignUp"></asp:RequiredFieldValidator>
                            </label>
                        </div>
                        <div>
                            <label>
                                <asp:TextBox ID="txtStrtNo" runat="server" placeholder="Street Number" TextMode="SingleLine" Width="300px" TabIndex="13" CssClass="txt"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rfvStrtNo" runat="server" ErrorMessage="*" ControlToValidate="txtStrtNo" Font-Bold="True" Font-Overline="False" Font-Size="Medium" Font-Underline="False" ForeColor="Red" ValidationGroup="SignUp"></asp:RequiredFieldValidator>
                            </label>
                        </div>
                        <div>
                            <label>
                                <asp:TextBox ID="txtLandmark" runat="server" placeholder="Landmark" TextMode="SingleLine" Width="300px" TabIndex="15" CssClass="txt"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rfvLandmark" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="txtLandmark" ValidationGroup="SignUp"></asp:RequiredFieldValidator>
                            </label>
                        </div>
                        <div>
                            <asp:DropDownList runat="server" ID="ddlCountry" Width="100px" CssClass="dropDownLists" TabIndex="17">
                                <asp:ListItem Value="-1">Select...</asp:ListItem>
                                <asp:ListItem Value="0">India</asp:ListItem>
                                <asp:ListItem Value="1">Pakistan</asp:ListItem>
                                <asp:ListItem Value="2"></asp:ListItem>
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator runat="server" ID="rfvCountry" ErrorMessage="*" ForeColor="Red" ControlToValidate="ddlCountry" ValidationGroup="SignUp"></asp:RequiredFieldValidator>


                            <asp:DropDownList runat="server" ID="ddlState" Width="100px" CssClass="dropDownLists" TabIndex="18" AutoPostBack="true" OnSelectedIndexChanged="ddlState_SelectedIndexChanged">
                                <asp:ListItem>Select...</asp:ListItem>
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="rfvState" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="ddlState" ValidationGroup="SignUp"></asp:RequiredFieldValidator>

                            <asp:DropDownList runat="server" ID="ddlCity" CssClass="dropDownLists" Width="100px" TabIndex="19">
                                <asp:ListItem>Select...</asp:ListItem>
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="rfvCity" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="ddlCity" ValidationGroup="SignUp"></asp:RequiredFieldValidator>
                            <label>
                                <asp:DropDownList runat="server" ID="ddlAddType" CssClass="dropDownLists" Width="100px" TabIndex="20">
                                    <asp:ListItem Value="-1">Select...</asp:ListItem>
                                    <asp:ListItem Value="0">Shipping</asp:ListItem>
                                    <asp:ListItem Value="1">Billing</asp:ListItem>
                                    <asp:ListItem Value="2">Permanent</asp:ListItem>
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="rfvAddType" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="ddlAddType" ValidationGroup="SignUp"></asp:RequiredFieldValidator>
                            </label>
                        </div>
                    </fieldset>
                    <div>
                        <div class="sky-form">
                            <div class="sky_form1">
                                <ul>
                                    <li>
                                        <label class="radio">
                                            <asp:RadioButton runat="server" ID="rbtnMale" GroupName="gender" Checked="true" TabIndex="22" /><i></i>Male</label>
                                    </li>
                                    <li>
                                        <label class="radio">
                                            <asp:RadioButton runat="server" ID="rbtnFemale" GroupName="gender" TabIndex="23" /><i></i>Female</label>
                                    </li>
                                    <div class="clearfix"></div>
                                </ul>
                            </div>
                        </div>
                    </div>
                    <br />
                    <fieldset>
                        <legend>Login Details</legend>
                    <div>
                        <label>
                            <asp:TextBox ID="txtEmail" runat="server" placeholder="Email" TextMode="Email" Width="300px" TabIndex="25" CssClass="txt"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvEmail" runat="server" ErrorMessage="*" ControlToValidate="txtEmail" Font-Bold="True" Font-Overline="False" Font-Size="Medium" Font-Underline="False" ForeColor="Red" ValidationGroup="SignUp"></asp:RequiredFieldValidator>
                        </label>
                    </div>
                    <div>
                        <label>
                            <asp:TextBox ID="txtPassword" runat="server" placeholder="Password" TextMode="Password" Width="300px" TabIndex="26" CssClass="txt"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvPassword" runat="server" ErrorMessage="*" ControlToValidate="txtPassword" Font-Bold="true" Font-Overline="false" Font-Size="Medium" ForeColor="Red" Font-Underline="false" ValidationGroup="SignUp"></asp:RequiredFieldValidator>
                        </label>
                    </div>
                    <div>
                        <label>
                            <asp:TextBox ID="txtCnfrmPwd" runat="server" placeholder="Retype Password" TextMode="Password" Width="300px" TabIndex="27" CssClass="txt"></asp:TextBox>

                            <asp:RequiredFieldValidator ID="rfvCnfrmPwd" runat="server" ErrorMessage="*" ControlToValidate="txtCnfrmPwd" Font-Bold="True" Font-Overline="False" Font-Size="Medium" Font-Underline="False" ForeColor="Red" ValidationGroup="SignUp"></asp:RequiredFieldValidator>
                            <asp:CompareValidator ID="cvPwd" runat="server" ErrorMessage="Passwords do not match" ForeColor="Red" ControlToValidate="txtPassword" ControlToCompare="txtCnfrmPwd" Operator="Equal" ValidationGroup="SignUp"></asp:CompareValidator>
                        </label>
                    </div>

                    <div>
                        <label>
                            <asp:TextBox ID="txtMobNo" runat="server" placeholder="Mobile Number" Width="300px" TabIndex="29" CssClass="txt"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvMobNo" runat="server" ErrorMessage="*" ControlToValidate="txtMobNo" Font-Bold="True" Font-Overline="False" Font-Size="Medium" Font-Underline="False" ForeColor="Red" ValidationGroup="SignUp"></asp:RequiredFieldValidator>
                        </label>
                    </div>
                        </fieldset>
                    <div>
                        <asp:ValidationSummary ID="valSummarySignUp" runat="server" ShowMessageBox="false" ShowSummary="false" EnableClientScript="true" />
                        <asp:Button ID="btnRegister" runat="server" Text="Create An Account" OnClick="btnRegister_Click" ValidationGroup="SignUp" TabIndex="33" CssClass="button" />
                    </div>
                    <div>
                        <asp:Panel runat="server" ID="pnlForgotPwd" Style="visibility: hidden">
                            This Username is already registered. Create your account using another email id or
                                 <asp:LinkButton runat="server" ID="lbtnRegainAccnt" OnClick="lbtnRegainAccnt_Click">Regain Account</asp:LinkButton>&nbsp;
                                 regain your Account for this email id.                               
                                <asp:LinkButton runat="server" ID="lbtnUpdateAccnt" OnClick="lbtnUpdateAccnt_Click">
                                    Update Account
                                </asp:LinkButton>
                        </asp:Panel>
                    </div>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
