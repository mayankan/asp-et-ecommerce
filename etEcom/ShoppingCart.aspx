<%@ Page Title="" Language="C#" MasterPageFile="~/Buyers.Master" AutoEventWireup="true" CodeBehind="ShoppingCart.aspx.cs" Inherits="etEcom.ShoppingCart" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <!-- content -->
<div class="container">
<div class="main">
	<div class="shoping_bag">
		<h4><img src="images/bag1.png">my shopping bag / <span> 11 item</span></h4>
		<ul class="s_art">
			<li><img src="images/art1.png"></li>
			<li><span> 11 item</span></li>
		</ul>
		<div class="clearfix"></div>
	</div>
	<div class="shoping_bag1">
		<div class="shoping_left">
			<div class="shoping1_of_1">
				<img src="images/w3.jpg"  class="img-responsive" alt="" />
			</div>
			<div class="shoping1_of_2">
				<h4><a href="#">shakumbhari women black kurtas</a> </h4>
				<span>size <b>xl</b>&nbsp;&nbsp; qty <b>1</b> | code :1175</span>
				<ul class="s_icons">
					<li><a href="#"><img src="images/s_icon1.png" alt=""></a></li>
					<li><a href="#"><img src="images/s_icon2.png" alt=""></a></li>
					<li><a href="#"><img src="images/s_icon3.png" alt=""></a></li>
				</ul>
			</div>
			<div class="clearfix"></div>
		</div>
		<div class="shoping_right">
			<p>35% off &nbsp;<span> Rs. 1,899</span></p>
		</div>
		<div class="clearfix"></div>
	</div>
	<div class="shoping_bag1">
		<div class="shoping_left">
			<h2><a href="#"><img src="images/gift.jpg">gift wrap </a> <span> for rs. 25</span></h2>
		</div>
		<div class="shoping_right">
			<p>sub total &nbsp;<span> Rs. 1,899</span></p>
			<p>vat collected &nbsp;<span> Rs. 91</span></p>
			<p>delivery &nbsp;<a href="#">free</a>&nbsp;<span> Rs. 0</span></p>
		</div>
		<div class="clearfix"></div>
	</div>
	<div class="shoping_bag1">
		<div class="shoping_left">
			<h2><a href="#"><img src="images/login.jpg">login </a> <span> to apply coupons</span></h2>
		</div>
		<div class="shoping_right">
			<p>coupon discount &nbsp;<span class="color"> Rs. 0</span></p>
		</div>
		<div class="clearfix"></div>
	</div>
	<div class="shoping_bag2">
		<div class="shoping_left">
			<a class="btn1" href="details.html">place order</a>
		</div>
		<div class="shoping_right">
			<p class="tot">total &nbsp;<span class="color"> Rs. 2,109</span></p>
		</div>
		<div class="clearfix"></div>
	</div>
</div>
</div>

</asp:Content>
