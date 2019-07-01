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
    public partial class CompletedOrders : System.Web.UI.Page
    {
        CartBLL cartBLL = new CartBLL();
        AddressBLL addressBLL = new AddressBLL();
        OrderBLL orderBLL = new OrderBLL();
        MemberBLL memberBLL = new MemberBLL();
        private void ShowNoResultFound(Collection<OrderGridCL> source, GridView gv)
        {
            // source.Rows.Add(source.NewRow()); // create a new blank row to the DataTable

            source.Add(new OrderGridCL()
            {
                id = 0,
                address = "",
                addressLine1 = "",
                addressLine2 = "",
                addressLine3 = "",
                addressType = "",
                cityId = 0,
                country = "",
                dateCreated = DateTime.Now,
                dateModified = DateTime.Now,
                isDeleted = false,
                memberName = "",
                orderStatus = "",
                productName = "",
                productQty = "",
                shippingCharge = "",
                shippingDescription = "",
                stateId = 0,
                taxAmt = "",
                totalAmt = "",
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
                ddlState.DataSource = addressBLL.getAllState().OrderBy(x => x.name);
                ddlState.DataValueField = "id";
                ddlState.DataTextField = "name";
                ddlState.DataBind();
                Collection<OrderCL> activeOrders = orderBLL.getCompletedOrders();
                Collection<OrderGridCL> activeOrderDetails = ConvertOrderToGrid(activeOrders);
                if (activeOrderDetails.Count() > 0)
                {
                    grdCompletedOrders.DataSource = activeOrderDetails;
                    grdCompletedOrders.DataBind();
                }
                else
                {
                    DataTable dt = new DataTable();
                    ShowNoResultFound(activeOrderDetails, grdCompletedOrders);
                }
            }
        }
        private Collection<OrderGridCL> ConvertOrderToGrid(Collection<OrderCL> activeOrders)
        {
            Collection<OrderGridCL> activeOrderDetails = new Collection<OrderGridCL>();
            foreach (OrderCL item in activeOrders)
            {
                activeOrderDetails.Add(new OrderGridCL
                {
                    addressLine1 = addressBLL.getAddressById(item.addressId).addressLine1,
                    addressLine2 = addressBLL.getAddressById(item.addressId).addressLine2,
                    addressLine3 = addressBLL.getAddressById(item.addressId).addressLine3,
                    address = addressBLL.getAddressById(item.addressId).addressLine1 + "," + addressBLL.getAddressById(item.addressId).addressLine2 + "," + addressBLL.getAddressById(item.addressId).addressLine3 + "," + addressBLL.getCityById(addressBLL.getAddressById(item.addressId).cityId).cityName + "," + addressBLL.getCityById(addressBLL.getAddressById(item.addressId).cityId).stateName + "," + addressBLL.getCityById(addressBLL.getAddressById(item.addressId).cityId).countryName + ",",
                    addressType = "memberBLL.getAddressById(item.addressId).",
                    cityId = addressBLL.getAddressById(item.addressId).cityId,
                    country = addressBLL.getCityById(addressBLL.getAddressById(item.addressId).cityId).countryName,
                    dateCreated = item.dateCreated,
                    dateModified = item.dateModified,
                    id = item.id,
                    isDeleted = item.isDeleted,
                    memberName = cartBLL.getMemberbyCartId(item.cartId).name,
                    orderStatus = addressBLL.getStatusById(item.statusId).name,
                    productName = cartBLL.getProductbyCartId(item.cartId).name,
                    productQty = cartBLL.getCartProductByCartId(item.cartId).quantity.ToString(),
                    shippingCharge = item.shippingCharge,
                    shippingDescription = item.description,
                    stateId = addressBLL.getCityById(addressBLL.getAddressById(item.addressId).cityId).stateId,
                    taxAmt = item.taxAmount,
                    totalAmt = item.totalAmount,
                });
            }
            return activeOrderDetails;
        }
        private Collection<OrderGridCL> ConvertOrderToGrid(IEnumerable<OrderGridCL> activeOrders)
        {
            Collection<OrderGridCL> activeOrderDetails = new Collection<OrderGridCL>();
            foreach (OrderGridCL item in activeOrderDetails)
            {
                activeOrderDetails.Add(new OrderGridCL
                {
                    address = item.address,
                    addressLine1 = item.addressLine1,
                    addressLine2 = item.addressLine2,
                    addressLine3 = item.addressLine3,
                    addressType = item.addressType,
                    cityId = item.cityId,
                    country = item.country,
                    dateCreated = item.dateCreated,
                    dateModified = item.dateModified,
                    id = item.id,
                    isDeleted = item.isDeleted,
                    memberName = item.memberName,
                    orderStatus = item.orderStatus,
                    productName = item.productName,
                    productQty = item.productQty,
                    shippingCharge = item.shippingCharge,
                    shippingDescription = item.shippingDescription,
                    stateId = item.stateId,
                    taxAmt = item.taxAmt,
                    totalAmt = item.totalAmt,
                });
            }
            return activeOrderDetails;
        }
        protected void ddlState_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddlCity.DataSource = addressBLL.getCityByStateId(Convert.ToInt32(ddlState.SelectedValue));
            ddlCity.DataValueField = "id";
            ddlCity.DataTextField = "name";
            ddlCity.DataBind();
        }
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            Collection<OrderGridCL> grdview = ConvertOrderToGrid(orderBLL.getCompletedOrders());
            var grdviewInstance = grdview.Where(x => x.id >= 0);
            if (txtMember.Text == string.Empty && txtProductName.Text == string.Empty && txtAddress.Text == string.Empty && ddlState.SelectedValue == 0.ToString() && txtDatePickerCreated.Text == string.Empty && txtDatePickerModified.Text == string.Empty)
            {
                if(grdview.Count()>0)
                {
                    grdCompletedOrders.DataSource = grdview;
                    grdCompletedOrders.DataBind();
                }
                else
                {
                    DataTable dt = new DataTable();
                    ShowNoResultFound(grdview, grdCompletedOrders);
                }
            }
            else
            {
                if (txtMember.Text != string.Empty)
                {
                    grdviewInstance = from x in grdviewInstance where x.memberName.ToLower().Contains(txtMember.Text.ToLower()) select x;
                }
                if (txtProductName.Text != string.Empty)
                {
                    grdviewInstance = from x in grdviewInstance where x.productName.ToLower().Contains(txtProductName.Text.ToLower()) select x;
                }
                if (txtAddress.Text != string.Empty)
                {
                    grdviewInstance = from x in grdviewInstance where x.address.ToLower().Contains(txtAddress.Text.ToLower()) select x;
                }
                if (ddlCity.Text != string.Empty)
                {
                    grdviewInstance = from x in grdviewInstance where x.cityId == Convert.ToInt32(ddlCity.SelectedValue) select x;
                }
                if (ddlState.SelectedValue != 0.ToString())
                {
                    grdviewInstance = from x in grdviewInstance where x.stateId == Convert.ToInt32(ddlState.SelectedValue) select x;
                }
                if (txtDatePickerCreated.Text != string.Empty)
                {
                    grdviewInstance = from x in grdviewInstance where x.dateCreated.Date == Convert.ToDateTime(txtDatePickerCreated.Text) select x;
                }
                if (txtDatePickerModified.Text != string.Empty)
                {
                    grdviewInstance = from x in grdviewInstance where x.dateModified.Date == Convert.ToDateTime(txtDatePickerModified.Text) select x;
                }
                if (grdviewInstance.Count() > 0)
                {
                    grdCompletedOrders.DataSource = ConvertOrderToGrid(grdviewInstance);
                    grdCompletedOrders.DataBind();
                }
                else
                {
                    DataTable dt = new DataTable();
                    ShowNoResultFound(ConvertOrderToGrid(grdviewInstance), grdCompletedOrders);
                }
            }
        }

        protected void grdCompletedOrders_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int orderId = Convert.ToInt32(e.CommandArgument);
            Response.Redirect("UpdateOrder.aspx?id=" + orderId);
        }
    }
}