using BusinessLogicLayer;
using CommunicationLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace etEcom
{
    public partial class Checkout : System.Web.UI.Page
    {
        int cartId;
        protected void Page_Load(object sender, EventArgs e)
        {
            if(Session["CartId"]==null)
            {
                Response.Redirect("Product.aspx");
            }
        }
    }
}