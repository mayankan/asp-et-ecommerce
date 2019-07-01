using BusinessLogicLayer;
using CommunicationLayer;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace etEcom.admin
{
    public partial class ExistingMembers : System.Web.UI.Page
    {
        private void ShowNoResultFound(Collection<MemberAddressCL> source, GridView gv)
        {
            // source.Rows.Add(source.NewRow()); // create a new blank row to the DataTable

            source.Add(new MemberAddressCL()
            {
                id = 0,
                name = "",
                billingAddress = "",
                email = "",
                gender="",
                isDelete="",
                isGuest="",
                mobNo="",
                password="",
                permanentAddress="",
                shippingAddress="",
            });
            // Bind the DataTable which contain a blank row to the GridView
            gv.DataSource = source;
            gv.DataBind();
            //Get the total number of columns in the GridView to know what the Column Span should be
            // GridViewRow row = new GridViewRow();

            int columnsCount = gv.Columns.Count;
            gv.Rows[0].Cells.Clear();// clear all the cells in the row
            gv.Rows[0].Cells.Add(new TableCell()); //add a new blank cell
            gv.Rows[0].Cells[0].ColumnSpan = columnsCount; //set the column span to the new added cell

            //You can set the styles here
            gv.Rows[0].Cells[0].HorizontalAlign = HorizontalAlign.Center;
            gv.Rows[0].Cells[0].ForeColor = System.Drawing.Color.Red;
            gv.Rows[0].Cells[0].Font.Bold = true;
            //set No Results found to the new added cell
            gv.Rows[0].Cells[0].Text = "NO RESULT FOUND!";
        }
        MemberBLL memberBLL = new MemberBLL();
        AddressBLL addressBLL = new AddressBLL();
        private Collection<MemberAddressCL> fetchMembers(Collection<MemberCL> members)
        {
            Collection<MemberAddressCL> memberWithAddress = new Collection<MemberAddressCL>();
            foreach (MemberCL item in members)
            {
                AddressCL addressCL = addressBLL.getAddressById(item.addressId);
                AddressLocationCL cityCL = addressBLL.getCityById(addressCL.cityId);
                if (addressCL.addressTypeId == 0)
                {
                    memberWithAddress.Add(new MemberAddressCL
                    {
                        id = item.id,
                        name = item.name,
                        password = item.password,
                        mobNo = item.mobNo,
                        isGuest = item.isGuest.ToString(),
                        isDelete = item.isDeleted.ToString(),
                        email = item.email,
                        gender = item.gender ? "Male" : "Female",
                        shippingAddress = addressCL.addressLine1 + ", " + addressCL.addressLine2 + ", " + addressCL.addressLine3 + ", " + cityCL.cityName + ", " + cityCL.stateName + ", " + cityCL.countryName,
                    });
                }
                else if (addressCL.addressTypeId == 1)
                {
                    memberWithAddress.Add(new MemberAddressCL
                    {
                        id = item.id,
                        name = item.name,
                        password = item.password,
                        mobNo = item.mobNo,
                        isGuest = item.isGuest.ToString(),
                        isDelete = item.isDeleted.ToString(),
                        email = item.email,
                        gender = item.gender ? "Male" : "Female",
                        billingAddress = addressCL.addressLine1 + ", " + addressCL.addressLine2 + ", " + addressCL.addressLine3 + ", " + cityCL.cityName + ", " + cityCL.stateName + ", " + cityCL.countryName,
                    });
                }
                else if (addressCL.addressTypeId == 2)
                {
                    memberWithAddress.Add(new MemberAddressCL
                    {
                        id = item.id,
                        name = item.name,
                        password = item.password,
                        mobNo = item.mobNo,
                        isGuest = item.isGuest.ToString(),
                        isDelete = item.isDeleted.ToString(),
                        email = item.email,
                        gender = item.gender ? "Male" : "Female",
                        permanentAddress = addressCL.addressLine1 + ", " + addressCL.addressLine2 + ", " + addressCL.addressLine3 + ", " + cityCL.cityName + ", " + cityCL.stateName + ", " + cityCL.countryName,
                    });

                }

            }
            return memberWithAddress;
        }
        private Collection<MemberAddressCL> fetchMembersFromQuery(IEnumerable<MemberCL> members)
        {
            Collection<MemberAddressCL> memberWithAddress = new Collection<MemberAddressCL>();
            foreach (MemberCL item in members)
            {
                AddressCL addressCL = addressBLL.getAddressById(item.addressId);
                AddressLocationCL cityCL = addressBLL.getCityById(addressCL.cityId);
                if (addressCL.addressTypeId == 0)
                {
                    memberWithAddress.Add(new MemberAddressCL
                    {
                        id = item.id,
                        name = item.name,
                        password = item.password,
                        mobNo = item.mobNo,
                        isGuest = item.isGuest.ToString(),
                        isDelete = item.isDeleted.ToString(),
                        email = item.email,
                        gender = item.gender ? "Male" : "Female",
                        shippingAddress = addressCL.addressLine1 + ", " + addressCL.addressLine2 + ", " + addressCL.addressLine3 + ", " + cityCL.cityName + ", " + cityCL.stateName + ", " + cityCL.countryName,
                    });
                }
                else if (addressCL.addressTypeId == 1)
                {
                    memberWithAddress.Add(new MemberAddressCL
                    {
                        id = item.id,
                        name = item.name,
                        password = item.password,
                        mobNo = item.mobNo,
                        isGuest = item.isGuest.ToString(),
                        isDelete = item.isDeleted.ToString(),
                        email = item.email,
                        gender = item.gender ? "Male" : "Female",
                        billingAddress = addressCL.addressLine1 + ", " + addressCL.addressLine2 + ", " + addressCL.addressLine3 + ", " + cityCL.cityName + ", " + cityCL.stateName + ", " + cityCL.countryName,
                    });
                }
                else if (addressCL.addressTypeId == 2)
                {
                    memberWithAddress.Add(new MemberAddressCL
                    {
                        id = item.id,
                        name = item.name,
                        password = item.password,
                        mobNo = item.mobNo,
                        isGuest = item.isGuest.ToString(),
                        isDelete = item.isDeleted.ToString(),
                        email = item.email,
                        gender = item.gender ? "Male" : "Female",
                        permanentAddress = addressCL.addressLine1 + ", " + addressCL.addressLine2 + ", " + addressCL.addressLine3 + ", " + cityCL.cityName + ", " + cityCL.stateName + ", " + cityCL.countryName,
                    });

                }

            }
            return memberWithAddress;
        }
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
            MemberCL memberCL = new MemberCL();
            if (!IsPostBack)
            {
                Collection<MemberCL> members = memberBLL.getMember();
                Collection<MemberAddressCL> memberWithAddress = fetchMembers(members);
                if (memberWithAddress.Count() > 0)
                {
                    grdExistingMembers.DataSource = memberWithAddress;
                    grdExistingMembers.DataBind();
                }
                else
                {
                    DataTable dt = new DataTable();
                    ShowNoResultFound(memberWithAddress, grdExistingMembers);
                }
                ddlState.DataSource = addressBLL.getAllState().OrderBy(x => x.name);
                ddlState.DataValueField = "id";
                ddlState.DataTextField = "name";
                ddlState.DataBind();
            }
        }
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            Collection<MemberCL> grd = memberBLL.getMember();
            Collection<MemberAddressCL> grdUpdate = fetchMembers(grd);
            var xyz = grd.Where(x => x.id >= 0);
            if (txtName.Text == string.Empty && txtMobNo.Text == string.Empty && txtEmail.Text == string.Empty && txtAddress.Text == string.Empty && ddlGender.SelectedValue == "0" && ddlCity.SelectedValue == "0" && ddlState.SelectedValue == "0")
            {
                if (grd.Count() > 0)
                {
                    grdExistingMembers.DataSource = grdUpdate;
                    grdExistingMembers.DataBind();
                }
                else
                {
                    DataTable dt = new DataTable();
                    ShowNoResultFound(grdUpdate, grdExistingMembers);
                };
            }
            else
            {
                if (txtName.Text != string.Empty)
                {
                    xyz = grd.Where(x => x.name.ToLower().Contains(txtName.Text.ToLower()));
                }
                if (txtEmail.Text != string.Empty)
                {
                    xyz = from x in xyz where x.email.ToLower() == txtEmail.Text.ToLower() select x;
                }
                if (txtMobNo.Text != string.Empty)
                {
                    xyz = from x in xyz where x.mobNo.Contains(txtMobNo.Text) select x;
                }
                if (txtAddress.Text != string.Empty)
                {
                    xyz = from x in xyz where addressBLL.getAddressById(x.addressId).addressLine1.Contains(txtAddress.Text) || addressBLL.getAddressById(x.addressId).addressLine2.Contains(txtAddress.Text) || addressBLL.getAddressById(x.addressId).addressLine3.Contains(txtAddress.Text) || addressBLL.getCityById(addressBLL.getAddressById(x.addressId).cityId).cityName.Contains(txtAddress.Text) || addressBLL.getCityById(addressBLL.getAddressById(x.addressId).cityId).stateName.Contains(txtAddress.Text) || addressBLL.getCityById(addressBLL.getAddressById(x.addressId).cityId).countryName.Contains(txtAddress.Text) select x;
                }
                if (ddlState.SelectedValue != "0")
                {
                    xyz = from x in xyz where addressBLL.getCityById(addressBLL.getAddressById(x.addressId).cityId).stateId == Convert.ToInt32(ddlState.SelectedValue) select x;
                    if (ddlCity.SelectedValue != "0")
                    {
                        xyz = from x in xyz where addressBLL.getAddressById(x.addressId).cityId == Convert.ToInt32(ddlCity.SelectedValue) select x;
                    }
                }
                if (ddlGender.SelectedValue != "0")
                {
                    xyz = from x in xyz where x.gender == Convert.ToBoolean(ddlGender.SelectedValue) select x;
                }

                Collection<MemberAddressCL> xyzUpdate = fetchMembersFromQuery(xyz);
                if (xyz.Count() > 0)
                {
                    grdExistingMembers.DataSource = xyzUpdate;
                    grdExistingMembers.DataBind();
                }
                else
                {
                    DataTable dt = new DataTable();
                    ShowNoResultFound(xyzUpdate, grdExistingMembers);
                }
            }
        }
        protected void ddlState_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddlCity.DataSource = addressBLL.getCityByStateId(Convert.ToInt32(ddlState.SelectedValue));
            ddlCity.DataValueField = "id";
            ddlCity.DataTextField = "name";
            ddlCity.DataBind();
        }
    }
}