using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace etEcom.admin
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            if (ValidateUser(txtUsername.Text, txtPassword.Text))
            {
                //Call FormsAuthentication.RedirectFromLoginPage, which would set a cookie for validation
                //and depending on the ReturnUrl value in the URL redirect user back to that page(here default.aspx)
                Session["UserId"] = txtUsername.Text;
                FormsAuthentication.RedirectFromLoginPage(txtUsername.Text, true);
            }
        }

        private bool ValidateUser(string userName, string password)
        {
            //ideally this would be validating against a datastore like a database or something else
            //for demo purpose we have done some hard code validation
            //so it will erturn true is username and password = demo
            return (userName == "admin" && password == "anandbookcorner");
        }
    }
}