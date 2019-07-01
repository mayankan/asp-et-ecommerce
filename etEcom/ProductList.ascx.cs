using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace etEcom
{
    public partial class ProductList : System.Web.UI.UserControl
    {
        string productImg;
        string productName;
        string productPrice;
        string url;
        string feature1;
        string feature2;
        string feature3;
        string feature4;
        string feature5;
        string feature6;
        string feature7;
        string feature8;
        public string prodImage
        {
            get { return productImg; }
            set { productImg = value; }
        }
        public string prodName
        {
            get { return productName; }
            set { productName = value; }
        }
        public string prodprice
        {
            get { return productPrice; }
            set { productPrice = value; }
        }
        public string redirectUrl
        {
            get { return url; }
            set { url = value; }
        }
        public string prodFeature1
        {
            get { return feature1; }
            set { feature1 = value; }
        }
        public string prodFeature2
        {
            get { return feature2; }
            set { feature2 = value; }
        }
        public string prodFeature3
        {
            get { return feature3; }
            set { feature3 = value; }
        }
        public string prodFeature4
        {
            get { return feature4; }
            set { feature4 = value; }
        }
        public string prodFeature5
        {
            get { return feature5; }
            set { feature5 = value; }
        }
        public string prodFeature6
        {
            get { return feature6; }
            set { feature6 = value; }
        }
        public string prodFeature7
        {
            get { return feature7; }
            set { feature7 = value; }
        }
        public string prodFeature8
        {
            get { return feature8; }
            set { feature8 = value; }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            productImage.ImageUrl = productImg;
            lblProductName.Text = productName;
            lblProductPrice.Text = productPrice;
            lblFeature1.Text = prodFeature1;
            lblFeature2.Text = prodFeature2;
            lblFeature3.Text = prodFeature3;
            lblFeature4.Text = prodFeature4;
            lblFeature5.Text = prodFeature5;
            lblFeature6.Text = prodFeature6;
            lblFeature7.Text = prodFeature7;
            lblFeature8.Text = prodFeature8;
        }

        protected void productImage_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect(redirectUrl);
        }
    }
}