using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace etEcom
{
    public partial class ProductDet : System.Web.UI.UserControl
    {
         string pName;
        string cnfg1;
        string cnfg2;
        string cnfg3;
        string cnfg4;
        string imgURL;
        string price;
        public string productName
        {
            get { return pName; }
            set { pName = value; }
        }

        public string config1
        {
            get { return cnfg1; }
            set { cnfg1 = value; }
        }
        public string config2
        {
            get { return cnfg2; }
            set { cnfg2 = value; }
        }
        public string config3
        {
            get { return cnfg3; }
            set { cnfg3 = value; }
        }
        public string config4
        {
            get { return cnfg4; }
            set { cnfg4 = value; }
        }
        public string productImageURl
        {
            get { return imgURL; }
            set { imgURL = value; }
        }
        public string productPrice
        {
            get { return price; }
            set { price = value; }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            lblConfig1.Text = config1;
            lblConfig2.Text = config2;
            lblConfig3.Text = config3;
            lblConfig4.Text = config4;
            lblName.Text = pName;
            lblPrice.Text = price;
            imgMain.ImageUrl = productImageURl;            
        }
        public event EventHandler ButtonClick;
      
        //protected void btnCart_Click(object sender, EventArgs e)
        //{
        //    ButtonClick(sender, e);
        //}

        protected void btnCart_Click1(object sender, EventArgs e)
        {
            ButtonClick(sender, e);
        }

        protected void btnBuy_Click(object sender, EventArgs e)
        {

        }
    }
      
    
}