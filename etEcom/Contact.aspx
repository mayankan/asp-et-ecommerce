<%@ Page Title="" Language="C#" MasterPageFile="~/Buyers.Master" AutoEventWireup="true" CodeBehind="Contact.aspx.cs" Inherits="etEcom.Contact" EnableEventValidation="false" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="Style/GlobalV3.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <!-- content -->
   
    <style>
        #myDiv {
            width: 500px;
            height: 800px;            
            margin: 0px auto 0px auto;
            padding: 0px 0px 0px 0px;
        }
    </style> 
<div class="container">
<div>
<div class="contact">				
					<div class="contact_info">
						<h2>get in touch</h2>
			    	 		<div class="map">
					   			<%--<iframe width="100%" height="250" frameborder="0" scrolling="no" marginheight="0" marginwidth="0" src="https://maps.google.co.in/maps?f=q&amp;source=s_q&amp;hl=en&amp;geocode=&amp;q=Lighthouse+Point,+FL,+United+States&amp;aq=4&amp;oq=light&amp;sll=26.275636,-80.087265&amp;sspn=0.04941,0.104628&amp;ie=UTF8&amp;hq=&amp;hnear=Lighthouse+Point,+Broward,+Florida,+United+States&amp;t=m&amp;z=14&amp;ll=26.275636,-80.087265&amp;output=embed"></iframe><br><small><a href="https://maps.google.co.in/maps?f=q&amp;source=embed&amp;hl=en&amp;geocode=&amp;q=Lighthouse+Point,+FL,+United+States&amp;aq=4&amp;oq=light&amp;sll=26.275636,-80.087265&amp;sspn=0.04941,0.104628&amp;ie=UTF8&amp;hq=&amp;hnear=Lighthouse+Point,+Broward,+Florida,+United+States&amp;t=m&amp;z=14&amp;ll=26.275636,-80.087265" style="color:#777777;text-align:left;font-size:13px;">View Larger Map</a></small>--%>
					   		</div>
      				</div>
				  <div id="myDiv">
			 	  	 	<h2>Contact Us</h2>
			 	 	    <br /><br />
					    	<div>
                                <span><asp:Label runat="server" ID="lblName" Text="Name"></asp:Label></span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
						    	<span><asp:TextBox runat="server" ID="txtname" Width="300px" CssClass="txt"/></span>
                                <asp:RequiredFieldValidator runat="server" ID="rfvName" ControlToValidate="txtname" ErrorMessage="*" Font-Bold="true" ForeColor="Red" ValidationGroup="SubmitQuery"></asp:RequiredFieldValidator>
						    </div><br /><br />
						    <div>
						    	<span><asp:Label runat="server" ID="lblEmail">E-mail</asp:Label></span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
						    	<span><asp:TextBox runat="server" ID="txtUserEmail" Width="300px" CssClass="txt"/></span>
                                 <asp:RequiredFieldValidator runat="server" ID="rfvEmail" ControlToValidate="txtUserEmail" ErrorMessage="*" Font-Size="Large" Font-Bold="true" ForeColor="Red" ValidationGroup="SubmitQuery"></asp:RequiredFieldValidator>
						    </div><br /><br />
						    <div>
						     	<span><asp:Label runat="server" ID="lblMobNo">Mobile</asp:Label></span>&nbsp;&nbsp;&nbsp;&nbsp;
						    	<span><asp:TextBox runat="server" ID="txtCountryCode" Width="50px" MaxLength="2" CssClass="txt"/></span>&nbsp;&nbsp;
                                <span><asp:TextBox runat="server" ID="txtMobNo" Width="230px" MaxLength="10" CssClass="txt"/></span>
                                 <asp:RequiredFieldValidator runat="server" ID="rfvMobNo" ControlToValidate="txtMobNo" ErrorMessage="*" Font-Bold="true" ForeColor="Red" ValidationGroup="SubmitQuery"></asp:RequiredFieldValidator>                               

						    </div><br /><br />
                              <div>
                                  <span><asp:Label runat="server" ID="lblState">State</asp:Label></span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                  <span>                                     
                                      <asp:DropDownList runat="server" ID="ddlState" CssClass="dropDownLists" Width="145px" AutoPostBack="true" OnSelectedIndexChanged="ddlState_SelectedIndexChanged"></asp:DropDownList>&nbsp;&nbsp;
                                      <asp:DropDownList runat="server" ID="ddlCity" CssClass="dropDownLists" Width="145px"></asp:DropDownList>
                                      
                                  </span><br /><br />
                              </div>
						    <div>
						    	<span><asp:Label runat="server" ID="lblSubject">Subject</asp:Label></span>&nbsp;&nbsp;&nbsp;
						    	<span><asp:TextBox runat="server" ID="txtMsg" TextMode="MultiLine" Width="300px"/></span>
                                 <asp:RequiredFieldValidator runat="server" ID="rfvMsg" ControlToValidate="txtMsg" ErrorMessage="*" Font-Bold="true" ForeColor="Red" ValidationGroup="SubmitQuery"></asp:RequiredFieldValidator>
						    </div><br />
						   <div>
						   		<span><asp:Button runat="server" ID="btnSubmit" Text="Submit us" ValidationGroup="SubmitQuery" OnClick="btnSubmit_Click" Width="150px" CssClass="button"/></span>
                                <asp:ValidationSummary ID="valContactDet" runat="server" ShowMessageBox="false" ShowSummary="false" EnableClientScript="false"  />
                               <br />
						  </div>
                              <div>
                                  <asp:Label runat="server" ID="lblTextMsg" ForeColor="Blue"></asp:Label>
                              </div>
					    </>
				    </div>	
			  </div>
</div>
</div>

</asp:Content>
