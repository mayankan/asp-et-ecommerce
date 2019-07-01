using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EcommerceCart
{
    public partial class AddToCart : System.Web.UI.UserControl
    {
        int productId;
        public int ProductId 
        { 
            get { return productId; }
            set { productId = value; }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["ProductId"]!=null)
            {
                string productId = Session["ProductId"].ToString(); 
            }
        }

        protected void Unnamed1_Click(object sender, EventArgs e)
        {
            Session["ProductId"] = productId;
        }
    }
}