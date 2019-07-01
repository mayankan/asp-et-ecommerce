using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UserControl
{
    public partial class AutoSearchControl : System.Web.UI.UserControl
    {
        //Collection<Name> l_names;
        int lenth;
        //public Collection<Name> names { get { return l_names; } set { l_names = value; } }
        public int textBoxLenth { get { return lenth; } set { lenth = value; } }

        protected void Page_Load(object sender, EventArgs e)
        {
            txtSearch.Width = textBoxLenth;
            //gvNames.DataSource = names;
            gvNames.DataBind();
        }

        protected void txtSearch_TextChanged(object sender, EventArgs e)
        {
            gvNames.Visible = true;
        }


       //[System.Web.Services.WebMethod]
       // public void GetData()
       // {
       //     gvNames.Visible = true;
       //     gvNames.DataSource = names.Where(ex => ex.FName.Contains(txtSearch.Text.Trim()));
       //     gvNames.DataBind();
       // }
    }
}