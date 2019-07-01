using BusinessLogicLayer;
using CommunicationLayer;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Web.Security;

namespace etEcom.admin
{
    public partial class QueryManagement : System.Web.UI.Page
    {
        ContactCL contactCL = new ContactCL();
        ContactBLL contactBLL = new ContactBLL();
        AddressBLL addressBLL = new AddressBLL();
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
            if (!IsPostBack)
            {
                bindGrid();
                bindState();
            }
        }
        private void ShowNoResultFound(Collection<QueryManagementCL> source, GridView gv)
        {
            // source.Rows.Add(source.NewRow()); // create a new blank row to the DataTable

            source.Add(new QueryManagementCL()
            {
                dateAdded = DateTime.Now,
                name = "",
                cityId = 1,
                mobNo = "",
                emailId = "",
                query = "",
                stateId = 1,
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
        private void bindGrid()
        {
            Collection<ContactCL> contact = contactBLL.getAllContacts();
            Collection<QueryManagementCL> contacts = ConvertOrderToGrid(contact);
            if (contacts.Count() > 0)
            {
                grdQueryMgmt.DataSource = contacts;
                grdQueryMgmt.DataBind();
            }
            else
            {
                DataTable dt = new DataTable();
                ShowNoResultFound(contacts, grdQueryMgmt);
            }
        }
        protected void btnBSearch_Click(object sender, EventArgs e)
        {
            Collection<ContactCL> grd = contactBLL.getAllContacts();
            Collection<QueryManagementCL> grdUpdate = ConvertOrderToGrid(grd);
            var xyz = grdUpdate.Where(x => x.id >= 0);
            if (txtEmail.Text == string.Empty && txtMobNo.Text == string.Empty && txtName.Text == string.Empty && ddlState.SelectedValue == "0" && ddlCity.Text == string.Empty)
            {
                if (grd.Count() > 0)
                {
                    grdQueryMgmt.DataSource = grdUpdate;
                    grdQueryMgmt.DataBind();
                }
                else
                {
                    DataTable dt = new DataTable();
                    ShowNoResultFound(grdUpdate, grdQueryMgmt);
                }
            }
            else
            {
                if (txtName.Text != string.Empty)
                {
                    xyz = from x in xyz where x.name.ToLower().Contains(txtName.Text.ToLower()) select x;
                }
                if (txtMobNo.Text != string.Empty)
                {
                    xyz = from x in xyz where x.mobNo.Contains(txtMobNo.Text) select x;
                }
                if (txtEmail.Text != string.Empty)
                {
                    xyz = from x in xyz where x.emailId.ToLower() == txtEmail.Text.ToLower() select x;
                }
                if(ddlState.SelectedValue!="0")
                {
                    xyz = from x in xyz where x.stateId == Convert.ToInt32(ddlState.SelectedValue) select x;
                }
                if (ddlCity.Text != string.Empty)
                {
                    xyz = from x in xyz where x.cityId == Convert.ToInt32(ddlCity.SelectedValue) select x;
                }

                Collection<QueryManagementCL> xyzUpdate = new Collection<QueryManagementCL>();
                foreach (var item in grdUpdate)
                {
                    xyzUpdate.Add(new QueryManagementCL()
                    {
                        id = item.id,
                        name = item.name,
                        emailId = item.emailId,
                        mobNo = item.mobNo,
                        cityId = item.cityId,
                        dateAdded = item.dateAdded,
                        query = item.query,
                        stateId=item.stateId,
                        cityName=item.cityName,
                        stateName=item.stateName,
                    });
                }
                if (xyz.Count() > 0)
                {
                    grdQueryMgmt.DataSource = xyzUpdate;
                    grdQueryMgmt.DataBind();
                }
                else
                {
                    DataTable dt = new DataTable();
                    ShowNoResultFound(xyzUpdate, grdQueryMgmt);
                }
            }
        }
        private Collection<QueryManagementCL> ConvertOrderToGrid(Collection<ContactCL> queries)
        {
            Collection<QueryManagementCL> updatedqueries = new Collection<QueryManagementCL>();
            foreach (ContactCL item in queries)
            {
                updatedqueries.Add(new QueryManagementCL
                    {
                        cityId = item.cityId,
                        dateAdded = item.dateAdded,
                        emailId = item.emailId,
                        id = item.id,
                        mobNo = item.mobNo,
                        name = item.name,
                        query = item.query,
                        stateId = addressBLL.getCityById(item.cityId).stateId,
                        cityName = addressBLL.getCityById(item.cityId).cityName,
                        stateName=addressBLL.getCityById(item.cityId).stateName,
                    });
            }
            return updatedqueries;
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
        private class QueryManagementCL
        {
            public int id { get; set; }
            public int stateId { get; set; }
            public string name { get; set; }
            public string emailId { get; set; }
            public string mobNo { get; set; }
            public int cityId { get; set; }
            public string query { get; set; }
            public DateTime dateAdded { get; set; }
            public string stateName { get; set; }
            public string cityName { get; set; }
        }
    }
}