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
    public partial class UserSignUp : System.Web.UI.Page
    {

        MemberBLL memberBLL = new MemberBLL();
        MemberCL memberCL = new MemberCL();
        AddressCL addressCL = new AddressCL();
        AddressBLL addressBLL = new AddressBLL();
        AddressLocationCL addLocationCL = new AddressLocationCL();
        AddressTypeCL addTypeCL = new AddressTypeCL();
        MemberAddressCL memAddCL = new MemberAddressCL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if(Session["MemberId"]!=null)
            {
                int memberId = Convert.ToInt32(Session["MemberId"]);
            }
            if (!IsPostBack)
            {
                bindState();
            }
        }
        protected void btnRegister_Click(object sender, EventArgs e)
        {

            bool checkUsrname = memberBLL.chkUserName(txtEmail.Text.ToLower());

            if (checkUsrname)
            {
                pnlForgotPwd.Visible = true;
                //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Email Address Already Exists.')", true);
            }
            else
            {
                addressCL.addressLine1 = txtHouseNo.Text;
                addressCL.addressLine2 = txtStrtNo.Text;
                addressCL.addressLine3 = txtLandmark.Text;
                addressCL.addressTypeId = Convert.ToInt32(ddlAddType.SelectedValue);
                addressCL.cityId = Convert.ToInt32(ddlCity.SelectedValue);
                AddressCL address = memberBLL.createAddress(addressCL);

                memberCL.name = txtName.Text;
                memberCL.mobNo = txtMobNo.Text;
                memberCL.password = txtPassword.Text;
                memberCL.email = txtEmail.Text.ToLower();
                memberCL.addressId = address.id;
                memberCL.isGuest = false;
                memberCL.gender = rbtnMale.Checked ? true : false;
                MemberCL memberCl = memberBLL.createMember(memberCL);
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Successfully Registered. Check Email for activation.')", true);
            }

        }
        private void bindState()
        {
            ddlState.DataSource = addressBLL.getAllState();
            ddlState.DataTextField = "name";
            ddlState.DataValueField = "id";
            ddlState.DataBind();
        }
        protected void btnSignIn_Click(object sender, EventArgs e)
        {
            MemberBLL memeberBLL = new MemberBLL();
            bool checkLogin = memberBLL.login(new MemberCL()
            {
                password = txtPwd.Text,
                email = txtUserName.Text.ToLower()
            });
            if (checkLogin)
            {
                Session["MemberId"] = memberBLL.getMemberByUserName(txtUserName.Text.ToLower()).id;
                Response.Redirect("Home.aspx");
            }
            else
            {
                lblLoginResult.Text = "Username or Password do not match.";

            }
        }
        protected void ddlState_SelectedIndexChanged(object sender, EventArgs e)
        {
            int stateId = Convert.ToInt32(ddlState.SelectedValue);

            ddlCity.DataSource = addressBLL.getCityByStateId(stateId);
            ddlCity.DataTextField = "name";
            ddlCity.DataValueField = "id";
            ddlCity.DataBind();
        }
        protected void lbtnUpdateAccnt_Click(object sender, EventArgs e)
        {
            Response.Redirect("UpdateAccount.aspx?memberId=" + memberCL.id);
        }
        protected void lbtnRegainAccnt_Click(object sender, EventArgs e)
        {
            Response.Redirect("");
        }
    }
}