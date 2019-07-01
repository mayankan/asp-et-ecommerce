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
    public partial class Contact : System.Web.UI.Page
    {
        AddressBLL addressBLL = new AddressBLL();
        AddressCL addressCL = new AddressCL();
        ContactBLL contactBLL = new ContactBLL();
        ContactCL contactCL = new ContactCL();
        protected void Page_Load(object sender, EventArgs e)
        {
            //http://www.aspsnippets.com/Articles/How-to-send-email-with-attachment-in-ASPNet.aspx
            if (!IsPostBack) 
            {  
                bindState();
            } 
          
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {           
            contactCL.emailId = txtUserEmail.Text;
            contactCL.name = txtname.Text;
            contactCL.query = txtMsg.Text;
            contactCL.mobNo = txtCountryCode.Text + txtMobNo.Text;
            contactCL.cityId = Convert.ToInt32(ddlCity.Text);
            contactCL.dateAdded = DateTime.Now;
           ContactCL contact= contactBLL.createContact(contactCL);
           //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('successfully submitted.  !!')", true);
           lblTextMsg.Text = "Thankyou  for contacting us. We will get back to you soon!!!!";
           //ClearText(this);
        }
        //public void ClearText(Control c)
        //{
        //    foreach (Control item in c.Controls)
        //    {
        //        if (item.GetType() == typeof(TextBox))
        //        {
        //            ((TextBox)(item)).Text = string.Empty;
        //        }
        //    }
        //}
        private void bindState()
        {
            ddlState.DataSource = addressBLL.getAllState();
            ddlState.DataTextField = "name";
            ddlState.DataValueField = "id";
            ddlState.DataBind();
        }
        protected void ddlState_SelectedIndexChanged(object sender, EventArgs e)
        {
            int stateId = Convert.ToInt32(ddlState.SelectedValue);
            ddlCity.DataSource = addressBLL.getCityByStateId(stateId);
            ddlCity.DataTextField = "name";
            ddlCity.DataValueField = "id";
            ddlCity.DataBind();
        }
    }
}