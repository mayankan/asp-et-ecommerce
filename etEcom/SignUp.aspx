<%@ Page Title="" Language="C#" MasterPageFile="~/Buyers.Master" AutoEventWireup="true" CodeBehind="SignUp.aspx.cs" Inherits="etEcom.SignUp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   <div class="container">
<div class="main">
	<!-- start registration -->
	<div class="registration">
		<div class="registration_left">
		<h2>new user? <span> create an account </span></h2>
		<%--<a href="#"><div class="reg_fb"><img src="images/facebook.png" alt=""><i>register using Facebook</i><div class="clearfix"></div></div></a>--%>
		<!-- [if IE] 
		    < link rel='stylesheet' type='text/css' href='ie.css'/>  
		 [endif] -->  
		  
		<!-- [if lt IE 7]>  
		    < link rel='stylesheet' type='text/css' href='ie6.css'/>  
		<! [endif] -->  
		<script>
		    (function () {

		        // Create input element for testing
		        var inputs = document.createElement('input');

		        // Create the supports object
		        var supports = {};

		        supports.autofocus = 'autofocus' in inputs;
		        supports.required = 'required' in inputs;
		        supports.placeholder = 'placeholder' in inputs;

		        // Fallback for autofocus attribute
		        if (!supports.autofocus) {

		        }

		        // Fallback for required attribute
		        if (!supports.required) {

		        }

		        // Fallback for placeholder attribute
		        if (!supports.placeholder) {

		        }

		        // Change text inside send button on submit
		        var send = document.getElementById('register-submit');
		        if (send) {
		            send.onclick = function () {
		                this.innerHTML = '...Sending';
		            }
		        }

		    })();
		</script>
		 <div class="registration_form">
		 <!-- Form -->
			<form id="registration_form" action="contact.php" method="post">
				<div>
					<label>
						<%--<input placeholder="first name:" type="text" tabindex="1" required autofocus>--%>
                        <asp:TextBox ID="txtName" runat="server" placeholder="Name" TabIndex="1"></asp:TextBox>
					</label>
				</div>
				<div>
					<label>
						<asp:TextBox ID="txtEmail" runat="server" placeholder="Email" TabIndex="1"></asp:TextBox>                       
					</label>				
				</div>
				<div>
					<label>
					<asp:TextBox ID="txtMobNo" runat="server" placeholder="MoBile Number" TabIndex="1"></asp:TextBox>
 					</label>
				</div>
				<div class="sky-form">
					<div class="sky_form1">
						<ul>
							<li><label class="radio left"><asp:RadioButton runat="server" ID="btnMale" /><i></i>Male</label></li>
							<li><label class="radio"><asp:RadioButton runat="server" ID="btnFemale" /><i></i>Female</label></li>
							<div class="clearfix"></div>
						</ul>
					</div>
				</div>
				<div>
					<label>
					<asp:TextBox ID="txtPassword" runat="server" placeholder="Password" TabIndex="1"></asp:TextBox>
					</label>
				</div>						
				<div>
					<label>
						<asp:TextBox ID="txtCnfrmPwd" runat="server" placeholder="Confirm Password" TabIndex="1"></asp:TextBox>
					</label>
				</div>	
				<div>
					
                    <asp:Button ID="btnRegister" runat="server" Text="Create An Account" />
				</div>
				<div class="sky-form">
					<%--<label class="checkbox"><input type="checkbox" name="checkbox" ><i></i>i agree to shoppe.com &nbsp;<a class="terms" href="#"> terms of service</a> </label>--%>
				</div>
			</form>
			<!-- /Form -->
		</div>
	</div>
	<div class="registration_left">
		<h2>existing user</h2>
		<%--<a href="#"><div class="reg_fb"><img src="images/facebook.png" alt=""><i>sign in using Facebook</i><div class="clear"></div></div></a>--%>
		 <div class="registration_form">
		 <!-- Form -->
		<form id="registration_form" action="contact.php" method="post">
				<div>
					<label>
						<asp:TextBox runat="server" ID="TxtUserName" TabIndex="1"></asp:TextBox>
 					</label>
				</div>
				<div>
					<label>
						<asp:TextBox runat="server" ID="txtPwd" TabIndex="4"></asp:TextBox>
					</label>
				</div>						
				<div>
					<asp:Button ID="btnSignIn" runat="server" Text="Sign In" />
                        				</div>
				<div class="forget">
					<a href="#">forgot your password</a>
				</div>
			</form>
			<!-- /Form -->
			</div>
	</div>
	<div class="clearfix"></div>
	</div>
	<!-- end registration -->
</div>
</div>
    <div>
                   <label> </label>
    </div>
</asp:Content>
