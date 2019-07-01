using BusinessLogicLayer;
using CommunicationLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace etEcom.admin
{
    public partial class UpdateProductPopup : System.Web.UI.Page
    {
        int productId = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserId"] != null)
            {
                string userId = Session["UserId"].ToString();
            }
            else
            {
                //If the session value for userid is not set, redirect the user to the loginpage
                //see the ReturnUrl querystring value, it will be the page, that the ASP.NEt
                //infrastructure will redirect to after successful validation of the user

                //See the <Authentication node in web.config
                FormsAuthentication.RedirectToLoginPage();
            }
            productId = Convert.ToInt32(Request.QueryString["productId"]);
            CategoryBLL categoryBLL = new CategoryBLL();
            int categoryId = Convert.ToInt32(Request.QueryString["categoryId"]);
            CategoryCL categorydata = categoryBLL.getCategory(categoryId);
            string[] abc = categorydata.featureCategory.Split(';');
            if (!IsPostBack)
            {
                bindFeatures();
                lblProductFeature1.Text = abc[0];
                lblProductFeature2.Text = abc[1];
                lblProductFeature3.Text = abc[2];
                lblProductFeature4.Text = abc[3];
                int count = abc.Count();

                if (count == 1)
                {
                    txtProductFeature2.Visible = false;
                    txtProductFeature3.Visible = false;
                    txtProductFeature4.Visible = false;
                }
                else if (count == 2)
                {
                    txtProductFeature3.Visible = false;
                    txtProductFeature4.Visible = false;
                }
                else if (count == 3)
                {
                    txtProductFeature4.Visible = false;
                }
            }
        }
        private void bindFeatures()
        {
            ProductBLL productBLL = new ProductBLL();
            ProductCL productCL = productBLL.getProduct(productId);
            string[] abc = productCL.featureDetails.Split(';');
            txtProductFeature1.Text = abc[0];
            txtProductFeature2.Text = abc[1];
            txtProductFeature3.Text = abc[2];
            txtProductFeature4.Text = abc[3];
        }
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            ProductBLL productBLL = new ProductBLL();
            ProductCL productCL = productBLL.getProduct(productId);
            if (txtProductFeature2.Visible == false)
            {
                productCL.featureDetails = txtProductFeature1.Text + ";" + ";" + ";" + ";";
            }
            else if (txtProductFeature3.Visible == false)
            {
                productCL.featureDetails = txtProductFeature1.Text + ";" + txtProductFeature2.Text + ";" + ";" + ";";
            }
            else if (txtProductFeature4.Visible == false)
            {
                productCL.featureDetails = txtProductFeature1.Text + ";" + txtProductFeature2.Text + ";" + txtProductFeature3.Text + ";" + ";";
            }
            else
            {
                productCL.featureDetails = txtProductFeature1.Text + ";" + txtProductFeature2.Text + ";" + txtProductFeature3.Text + ";" + txtProductFeature4.Text + ";";
            }
            productBLL.updateProduct(productCL);
            string s = "window.close();";
            ClientScript.RegisterStartupScript(this.GetType(), "script", s, true);
        }
    }
}