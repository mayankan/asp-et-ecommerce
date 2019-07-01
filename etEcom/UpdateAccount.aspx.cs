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
    public partial class UpdateAccount : System.Web.UI.Page
    {
        int memberId = 0;
        MemberCL memberCL = new MemberCL();
        MemberBLL memberBLL = new MemberBLL(); 
        AddressCL addressCL = new AddressCL();
        AddressBLL addressBLL = new AddressBLL();
        AddressLocationCL addLocationCL = new AddressLocationCL();
        AddressTypeCL addTypeCL = new AddressTypeCL();
        MemberAddressCL memAddCL = new MemberAddressCL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                bindState();
                int id = Convert.ToInt32(Request.QueryString["memberId"]);
                memberId = id;
            }
        }

        protected void btnUpdateAccnt_Click(object sender, EventArgs e)
        {
            bool chkpass = memberBLL.chkPassword(new MemberCL
            {
                password=memberCL.password
            });
            if(chkpass)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('password do not match !!')", true);
            }
            else
            { 
            addressCL.addressLine1 = txtHouseNo.Text;
            addressCL.addressLine2 = txtMobileNo.Text;
            addressCL.addressLine3 = txtLandmark.Text;
            addressCL.addressTypeId = Convert.ToInt32(ddlAddType.SelectedValue);
            addressCL.cityId = Convert.ToInt32(ddlCity.SelectedValue);
            AddressCL address =memberBLL.updateAddress(addressCL);
            memberCL.name = txtName.Text;
            memberCL.dateModified = DateTime.Now;
            memberCL.isGuest = false;
            memberCL.gender = rbtnMale.Checked ? true : false;            
            memberCL.password = txtNewPwd.Text;
            memberCL.id = memberId;
            memberCL.addressId=address.id;          
            MemberCL newMemberCL = memberBLL.updateMember(memberCL);
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('successfully updated.  !!')", true);
            }
        }
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