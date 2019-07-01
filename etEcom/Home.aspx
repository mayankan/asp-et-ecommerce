<%@ Page Title="" Language="C#" MasterPageFile="~/Buyers.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="etEcom.Home" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="Scripts/masonry.pkgd.min.js"></script>
    <link href="Scripts/reference.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="goquickly-bar" data-tracking-id="nmenu_quicklinks">
        <ul class="goquickly-list">
            <li class="subheading">Go quickly to</li>
            <li class=""><a href="/mobiles?otracker=hp_nmenu_quicklinks_Mobile" data-tracking-id="Mobile">Mobile</a></li>
            <li class=""><a href="/headphones?otracker=hp_nmenu_quicklinks_Headphones" data-tracking-id="Headphones">Headphones</a></li>
            <li class=""><a href="/computers/laptops?otracker=hp_nmenu_quicklinks_Laptop" data-tracking-id="Laptop">Laptop</a></li>
            <li class=""><a href="/televisions?otracker=hp_nmenu_quicklinks_TV" data-tracking-id="TV">TV</a></li>
            <li class=""><a href="/tablets?otracker=hp_nmenu_quicklinks_Tablet" data-tracking-id="Tablet">Tablet</a></li>
            <li class=""><a href="/computers/storage/pen-drives/pr?sid=6bo,jdy,uar&amp;otracker=hp_nmenu_quicklinks_Pendrives" data-tracking-id="Pendrives">Pendrives</a></li>
            <li class=""><a href="/home-kitchen/home-appliances/fans/pr?sid=j9e,abm,lbz&amp;otracker=hp_nmenu_quicklinks_Fans" data-tracking-id="Fans">Fans</a></li>
            <li class=""><a href="/computers/audio-players/home-audio/speakers/pr?sid=6bo,ord,rlj,8sb&amp;otracker=hp_nmenu_quicklinks_Speakers" data-tracking-id="Speakers">Speakers</a></li>
            <li class=""><a href="/watches/men?otracker=hp_nmenu_quicklinks_Watches" data-tracking-id="Watches">Watches</a></li>
            <li class=""><a href="/home-decor/lights-lamps/led-cfl-bulbs/pr?sid=1m7,sat,nmw&amp;otracker=hp_nmenu_quicklinks_LED%20%26%20CFLs" data-tracking-id="LED &amp; CFLs">LED &amp; CFLs</a></li>
            <li class=""><a href="/jewellery?otracker=hp_nmenu_quicklinks_Jewellery" data-tracking-id="Jewellery">Jewellery</a></li>
            <li class=""><a href="/beauty-and-personal-care/fragrances/perfumes/pr?p%5B%5D=sort%3Dpopularity&amp;sid=t06%2Cr3o%2Caa1&amp;otracker=hp_nmenu_quicklinks_Perfumes" data-tracking-id="Perfumes">Perfumes</a></li>
            <li class="last"><a href="/buy-gift-voucher?otracker=hp_nmenu_quicklinks_Gift%20Voucher" data-tracking-id="Gift Voucher">Gift Voucher</a></li>
        </ul>
    </div>
    <!-- content -->
    <div class="container">
        <div class="women_main">
            <!-- start sidebar -->
            <div class="col-md-3">
                <div class="w_sidebar">
                    <div class="w_nav1">
                        <h4>All</h4>
                        <ul>
                            <li><a href="women.html">women</a></li>
                            <li><a href="#">new arrivals</a></li>
                            <li><a href="#">trends</a></li>
                            <li><a href="#">boys</a></li>
                            <li><a href="#">girls</a></li>
                            <li><a href="#">sale</a></li>
                        </ul>
                    </div>
                    <h3>filter by</h3>
                    <section class="sky-form">
                        <h4>catogories</h4>
                        <div class="row1 scroll-pane">
                            <div class="col col-4">
                                <label class="checkbox">
                                    <input type="checkbox" name="checkbox" checked=""><i></i>kurtas</label>
                            </div>
                            <div class="col col-4">
                                <label class="checkbox">
                                    <input type="checkbox" name="checkbox"><i></i>kutis</label>
                                <label class="checkbox">
                                    <input type="checkbox" name="checkbox"><i></i>churidar kurta</label>
                                <label class="checkbox">
                                    <input type="checkbox" name="checkbox"><i></i>salwar</label>
                                <label class="checkbox">
                                    <input type="checkbox" name="checkbox"><i></i>printed sari</label>
                                <label class="checkbox">
                                    <input type="checkbox" name="checkbox"><i></i>shree</label>
                                <label class="checkbox">
                                    <input type="checkbox" name="checkbox"><i></i>Anouk</label>
                                <label class="checkbox">
                                    <input type="checkbox" name="checkbox"><i></i>biba</label>
                                <label class="checkbox">
                                    <input type="checkbox" name="checkbox"><i></i>fashion sari</label>
                                <label class="checkbox">
                                    <input type="checkbox" name="checkbox"><i></i>fashion sari</label>
                                <label class="checkbox">
                                    <input type="checkbox" name="checkbox"><i></i>fashion sari</label>
                                <label class="checkbox">
                                    <input type="checkbox" name="checkbox"><i></i>fashion sari</label>
                                <label class="checkbox">
                                    <input type="checkbox" name="checkbox"><i></i>fashion sari</label>
                                <label class="checkbox">
                                    <input type="checkbox" name="checkbox"><i></i>fashion sari</label>
                                <label class="checkbox">
                                    <input type="checkbox" name="checkbox"><i></i>fashion sari</label>
                                <label class="checkbox">
                                    <input type="checkbox" name="checkbox"><i></i>fashion sari</label>
                            </div>
                        </div>
                    </section>
                    <section class="sky-form">
                        <h4>brand</h4>
                        <div class="row1 scroll-pane">
                            <div class="col col-4">
                                <label class="checkbox">
                                    <input type="checkbox" name="checkbox" checked=""><i></i>shree</label>
                                <label class="checkbox">
                                    <input type="checkbox" name="checkbox"><i></i>Anouk</label>
                                <label class="checkbox">
                                    <input type="checkbox" name="checkbox"><i></i>biba</label>
                            </div>
                            <div class="col col-4">
                                <label class="checkbox">
                                    <input type="checkbox" name="checkbox"><i></i>vishud</label>
                                <label class="checkbox">
                                    <input type="checkbox" name="checkbox"><i></i>amari</label>
                                <label class="checkbox">
                                    <input type="checkbox" name="checkbox"><i></i>shree</label>
                                <label class="checkbox">
                                    <input type="checkbox" name="checkbox"><i></i>Anouk</label>
                                <label class="checkbox">
                                    <input type="checkbox" name="checkbox"><i></i>biba</label>
                                <label class="checkbox">
                                    <input type="checkbox" name="checkbox"><i></i>shree</label>
                                <label class="checkbox">
                                    <input type="checkbox" name="checkbox"><i></i>Anouk</label>
                                <label class="checkbox">
                                    <input type="checkbox" name="checkbox"><i></i>biba</label>
                                <label class="checkbox">
                                    <input type="checkbox" name="checkbox"><i></i>shree</label>
                                <label class="checkbox">
                                    <input type="checkbox" name="checkbox"><i></i>Anouk</label>
                                <label class="checkbox">
                                    <input type="checkbox" name="checkbox"><i></i>biba</label>
                            </div>
                        </div>
                    </section>
                    <section class="sky-form">
                        <h4>colour</h4>
                        <ul class="w_nav2">
                            <li><a class="color1" href="#"></a></li>
                            <li><a class="color2" href="#"></a></li>
                            <li><a class="color3" href="#"></a></li>
                            <li><a class="color4" href="#"></a></li>
                            <li><a class="color5" href="#"></a></li>
                            <li><a class="color6" href="#"></a></li>
                            <li><a class="color7" href="#"></a></li>
                            <li><a class="color8" href="#"></a></li>
                            <li><a class="color9" href="#"></a></li>
                            <li><a class="color10" href="#"></a></li>
                            <li><a class="color12" href="#"></a></li>
                            <li><a class="color13" href="#"></a></li>
                            <li><a class="color14" href="#"></a></li>
                            <li><a class="color15" href="#"></a></li>
                            <li><a class="color5" href="#"></a></li>
                            <li><a class="color6" href="#"></a></li>
                            <li><a class="color7" href="#"></a></li>
                            <li><a class="color8" href="#"></a></li>
                            <li><a class="color9" href="#"></a></li>
                            <li><a class="color10" href="#"></a></li>
                        </ul>
                    </section>
                    <section class="sky-form">
                        <h4>discount</h4>
                        <div class="row1 scroll-pane">
                            <div class="col col-4">
                                <label class="radio">
                                    <input type="radio" name="radio" checked=""><i></i>60 % and above</label>
                                <label class="radio">
                                    <input type="radio" name="radio"><i></i>50 % and above</label>
                                <label class="radio">
                                    <input type="radio" name="radio"><i></i>40 % and above</label>
                            </div>
                            <div class="col col-4">
                                <label class="radio">
                                    <input type="radio" name="radio"><i></i>30 % and above</label>
                                <label class="radio">
                                    <input type="radio" name="radio"><i></i>20 % and above</label>
                                <label class="radio">
                                    <input type="radio" name="radio"><i></i>10 % and above</label>
                            </div>
                        </div>
                    </section>
                </div>
            </div>
            <!-- start content -->
            <div class="col-md-9 w_content">
                <div class="women">
                    <a href="#">
                        <h4>Enthecwear - <span>4449 itemms</span> </h4>
                    </a>
                    <ul class="w_nav">
                        <li>Sort : </li>
                        <li><a class="active" href="#">popular</a></li>
                        |
		     			<li><a href="#">new </a></li>
                        |
		     			<li><a href="#">discount</a></li>
                        |
		     			<li><a href="#">price: Low High </a></li>
                        <div class="clear"></div>
                    </ul>
                    <div class="clearfix"></div>
                </div>
                <!-- grids_of_4 -->
                <div class="grids_of_4">
                    <div class="grid1_of_4">
                        <div class="content_box">
                            <a href="details.html">
                                <div class="view view-fifth">
                                    <img src="images/w1.jpg" class="img-responsive" alt="" />
                                    <div class="mask">
                                        <div class="info">Quick View</div>
                                    </div>
                            </a>
                        </div>
                        <h4><a href="details.html">Duis autem</a></h4>
                        <p>It is a long established fact that a reader</p>
                        Rs. 499
                    </div>
                </div>
                <div class="grid1_of_4">
                    <div class="content_box">
                        <a href="details.html">
                            <div class="view view-fifth">
                                <img src="images/w2.jpg" class="img-responsive" alt="" />
                                <div class="mask">
                                    <div class="info">Quick View</div>
                                </div>
                        </a>
                    </div>
                    <h4><a href="details.html">Duis autem</a></h4>
                    <p>It is a long established fact that a reader</p>
                    Rs. 499
                </div>
            </div>
            <div class="grid1_of_4">
                <div class="content_box">
                    <a href="details.html">
                        <div class="view view-fifth">
                            <img src="images/w3.jpg" class="img-responsive" alt="" />
                            <div class="mask">
                                <div class="info">Quick View</div>
                            </div>
                    </a>
                </div>
                <h4><a href="details.html">Duis autem</a></h4>
                <p>It is a long established fact that a reader</p>
                Rs. 499
            </div>
        </div>
        <div class="grid1_of_4">
            <div class="content_box">
                <a href="details.html">
                    <div class="view view-fifth">
                        <img src="images/w4.jpg" class="img-responsive" alt="" />
                        <div class="mask">
                            <div class="info">Quick View</div>
                        </div>
                </a>
            </div>
            <h4><a href="details.html">Duis autem</a></h4>
            <p>It is a long established fact that a reader</p>
            Rs. 499
        </div>
    </div>
    <div class="clearfix"></div>


    <div class="grids_of_4">
        <div class="grid1_of_4">
            <div class="content_box">
                <a href="details.html">
                    <div class="view view-fifth">
                        <img src="images/w5.jpg" class="img-responsive" alt="" />
                        <div class="mask">
                            <div class="info">Quick View</div>
                        </div>
                </a>
            </div>
            <h4><a href="details.html">Duis autem</a></h4>
            <p>It is a long established fact that a reader</p>
            Rs. 499
        </div>
    </div>
    <div class="grid1_of_4">
        <div class="content_box">
            <a href="details.html">
                <div class="view view-fifth">
                    <img src="images/w6.jpg" class="img-responsive" alt="" />
                    <div class="mask">
                        <div class="info">Quick View</div>
                    </div>
            </a>
        </div>
        <h4><a href="details.html">Duis autem</a></h4>
        <p>It is a long established fact that a reader</p>
        Rs. 499
    </div>
    </div>
			<div class="grid1_of_4">
                <div class="content_box">
                    <a href="details.html">
                        <div class="view view-fifth">
                            <img src="images/w7.jpg" class="img-responsive" alt="" />
                            <div class="mask">
                                <div class="info">Quick View</div>
                            </div>
                    </a>
                </div>
                <h4><a href="details.html">Duis autem</a></h4>
                <p>It is a long established fact that a reader</p>
                Rs. 499
            </div>
    </div>
			<div class="grid1_of_4">
                <div class="content_box">
                    <a href="details.html">
                        <div class="view view-fifth">
                            <img src="images/w8.jpg" class="img-responsive" alt="" />
                            <div class="mask">
                                <div class="info">Quick View</div>
                            </div>
                    </a>
                </div>
                <h4><a href="details.html">Duis autem</a></h4>
                <p>It is a long established fact that a reader</p>
                Rs. 499
            </div>
    </div>
			<div class="clearfix"></div>
    </div>
		
		
		<div class="grids_of_4">
            <div class="grid1_of_4">
                <div class="content_box">
                    <a href="details.html">
                        <div class="view view-fifth">
                            <img src="images/w9.jpg" class="img-responsive" alt="" />
                            <div class="mask">
                                <div class="info">Quick View</div>
                            </div>
                    </a>
                </div>
                <h4><a href="details.html">Duis autem</a></h4>
                <p>It is a long established fact that a reader</p>
                Rs. 499
            </div>
        </div>
    <div class="grid1_of_4">
        <div class="content_box">
            <a href="details.html">
                <div class="view view-fifth">
                    <img src="images/w10.jpg" class="img-responsive" alt="" />
                    <div class="mask">
                        <div class="info">Quick View</div>
                    </div>
            </a>
        </div>
        <h4><a href="details.html">Duis autem</a></h4>
        <p>It is a long established fact that a reader</p>
        Rs. 499
    </div>
    </div>
			<div class="grid1_of_4">
                <div class="content_box">
                    <a href="details.html">
                        <div class="view view-fifth">
                            <img src="images/w11.jpg" class="img-responsive" alt="" />
                            <div class="mask">
                                <div class="info">Quick View</div>
                            </div>
                    </a>
                </div>
                <h4><a href="details.html">Duis autem</a></h4>
                <p>It is a long established fact that a reader</p>
                Rs. 499
            </div>
    </div>
			<div class="grid1_of_4">
                <div class="content_box">
                    <a href="details.html">
                        <div class="view view-fifth">
                            <img src="images/w12.jpg" class="img-responsive" alt="" />
                            <div class="mask">
                                <div class="info">Quick View</div>
                            </div>
                    </a>
                </div>
                <h4><a href="details.html">Duis autem</a></h4>
                <p>It is a long established fact that a reader</p>
                Rs. 499
            </div>
    </div>
			<div class="clearfix"></div>
    </div>
		<!-- end grids_of_4 -->


    </div>
	<div class="clearfix"></div>

    <!-- end content -->
    </div>
</div>

    </div>

</asp:Content>
