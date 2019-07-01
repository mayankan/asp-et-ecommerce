using BusinessLogicLayer;
using CommunicationLayer;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace etEcom.admin
{
    public partial class UpdateOrder : System.Web.UI.Page
    {
        CartBLL cartBLL = new CartBLL();
        AddressBLL addressBLL = new AddressBLL();
        int id = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            int orderId = Convert.ToInt32(Request.QueryString["id"]);
            id = orderId;
            if(!IsPostBack)
            {
                OrderBLL orderBLL = new OrderBLL();
                OrderCL orderCL = orderBLL.getOrderById(orderId);
                UpdateOrderGridCL ordergridCL = ConvertOrderToGrid(orderCL);
                string memberIsGuest = ordergridCL.memberIsGuest ? "Is Guest" : "Member"; ;
                string memberGender = ordergridCL.memberGender ? "Is Male" : "Is Female";
                string dateJoining = ordergridCL.memberJoinDate.Date.ToString("d");
                string dateModified = ordergridCL.memberModifiedDate.Date.ToString("d");
                lblMemberDetails.Text = ordergridCL.memberName + " , " + memberIsGuest + " , " + memberGender + " , " + ordergridCL.memberMobNo + Environment.NewLine + ordergridCL.memberAddress + "<br />" + "Member Joining Date" + " - " + dateJoining + "<br />" + "Member Update Date" + " - " + dateModified;
                lblPaymentDetails.Text = "";
                ddlShippingStatus.SelectedValue = orderBLL.getOrderById(orderId).statusId.ToString();
                txtShippingDescription.Text = orderBLL.getOrderById(orderId).description;
                string[] productName = ordergridCL.productName.Split(';');
                string[] productDispatchTime = ordergridCL.productDispatchTime.Split(';');
                string[] productQty = ordergridCL.productQty.Split(';');
                string[] productPrice = ordergridCL.productPrice.Split(';');
                string[] productShippingCharge = ordergridCL.productShippingCharge.Split(';');
                string[] productId = ordergridCL.productId.Split(';');
                int productCount = ordergridCL.productCount;
                Collection<UpdateProductGridCL> productUpdateInGrid = new Collection<UpdateProductGridCL>();
                for (int i = 0; i < productCount; i++)
                {
                    productUpdateInGrid.Add(new UpdateProductGridCL
                    {
                        productDispatchTime = productName[i],
                        productId = productId[i],
                        productName = productName[i],
                        productPrice = productPrice[i],
                        productQty = productQty[i],
                        productShippingCharge = productShippingCharge[i],
                    });
                }
                grdUpdateOrders.DataSource = productUpdateInGrid;
                grdUpdateOrders.DataBind();
            }

        }
        private UpdateOrderGridCL ConvertOrderToGrid(OrderCL activeOrders)
        {
            Collection<ProductCL> products = cartBLL.getProductCollectionByCartId(activeOrders.cartId);
            Collection<CartProductCL> cartProducts = cartBLL.getCartProductCollectionByCartId(activeOrders.cartId);
            string addressType = "";
            int addressTypeId = addressBLL.getAddressById(activeOrders.addressId).addressTypeId;
            if (addressTypeId == 0)
            {
                addressType = "Shipping Address";
            }
            if (addressTypeId == 1)
            {
                addressType = "Billing Address";
            }
            if (addressTypeId == 2)
            {
                addressType = "Permanent Address";
            }
            StringBuilder productQty = new StringBuilder();
            StringBuilder productId = new StringBuilder();
            StringBuilder productName = new StringBuilder();
            StringBuilder productDispatchTime = new StringBuilder();
            StringBuilder productPrice = new StringBuilder();
            StringBuilder productShippingCharge = new StringBuilder();
            foreach (ProductCL item in products) // Loop through all strings
            {

                productName.Append(item.name).Append(";"); // Append string to StringBuilder
                productDispatchTime.Append(item.dispatchTime).Append(";");
                productId.Append(item.Id).Append(";");
                productPrice.Append(item.price).Append(";");
                productShippingCharge.Append(item.shippingCharge).Append(";");
            }
            foreach (CartProductCL item in cartProducts)
            {
                productQty.Append(item.quantity).Append(";");
            }
            UpdateOrderGridCL updateOrderDetails = new UpdateOrderGridCL()
            {
                id = activeOrders.id,
                memberName = cartBLL.getMemberbyCartId(activeOrders.cartId).name,
                memberAddress = addressBLL.getAddressById(activeOrders.addressId).addressLine1 + "," + addressBLL.getAddressById(activeOrders.addressId).addressLine2 + "," + addressBLL.getAddressById(activeOrders.addressId).addressLine3 + "," + addressBLL.getCityById(addressBLL.getAddressById(activeOrders.addressId).cityId).cityName + "," + addressBLL.getCityById(addressBLL.getAddressById(activeOrders.addressId).cityId).stateName + "," + addressBLL.getCityById(addressBLL.getAddressById(activeOrders.addressId).cityId).countryName,
                memberAddressType = addressType,
                memberCityId = addressBLL.getAddressById(activeOrders.addressId).cityId,
                memberCountryName = addressBLL.getCityById(addressBLL.getAddressById(activeOrders.addressId).cityId).countryName,
                memberGender = cartBLL.getMemberbyCartId(activeOrders.cartId).gender,
                memberIsGuest = cartBLL.getMemberbyCartId(activeOrders.cartId).isGuest,
                memberModifiedDate = cartBLL.getMemberbyCartId(activeOrders.cartId).dateModified,
                memberJoinDate = cartBLL.getMemberbyCartId(activeOrders.cartId).dateCreated,
                memberMobNo = cartBLL.getMemberbyCartId(activeOrders.cartId).mobNo,
                memberStateId = addressBLL.getCityById(addressBLL.getAddressById(activeOrders.addressId).cityId).stateId,
                orderShippingDescription = activeOrders.description,
                orderStatusId = activeOrders.statusId,
                orderTaxAmt = activeOrders.taxAmount,
                orderTotalAmt = activeOrders.totalAmount,
                orderTotalShippingCharge = activeOrders.shippingCharge,
                productName = productName.ToString(),
                productDispatchTime = productDispatchTime.ToString(),
                productId = productId.ToString(),
                productPrice = productPrice.ToString(),
                productShippingCharge = productShippingCharge.ToString(),
                productQty = productQty.ToString(),
                productCount = cartProducts.Count(),
            };
            return updateOrderDetails;
        }
        //private OrderGridCL ConvertOrderToGrid(OrderCL activeOrders)
        //{
        //    string addressType = "";
        //    int addressTypeId = addressBLL.getAddressById(activeOrders.addressId).addressTypeId;
        //    if(addressTypeId==0)
        //    {
        //        addressType = "Shipping Address";
        //    }
        //    if(addressTypeId==1)
        //    {
        //        addressType = "Billing Address";
        //    }
        //    if(addressTypeId==2)
        //    {
        //        addressType = "Permanent Address";
        //    }
        //    OrderGridCL activeOrderDetails = new OrderGridCL()
        //        {
        //            addressLine1 = addressBLL.getAddressById(activeOrders.addressId).addressLine1,
        //            addressLine2 = addressBLL.getAddressById(activeOrders.addressId).addressLine2,
        //            addressLine3 = addressBLL.getAddressById(activeOrders.addressId).addressLine3,
        //            address = addressBLL.getAddressById(activeOrders.addressId).addressLine1 + "," + addressBLL.getAddressById(activeOrders.addressId).addressLine2 + "," + addressBLL.getAddressById(activeOrders.addressId).addressLine3 + "," + addressBLL.getCityById(addressBLL.getAddressById(activeOrders.addressId).cityId).cityName + "," + addressBLL.getCityById(addressBLL.getAddressById(activeOrders.addressId).cityId).stateName + "," + addressBLL.getCityById(addressBLL.getAddressById(activeOrders.addressId).cityId).countryName + ",",
        //            addressType = addressType,
        //            cityId = addressBLL.getAddressById(activeOrders.addressId).cityId,
        //            country = addressBLL.getCityById(addressBLL.getAddressById(activeOrders.addressId).cityId).countryName,
        //            dateCreated = activeOrders.dateCreated,
        //            dateModified = activeOrders.dateModified,
        //            id = activeOrders.id,
        //            isDeleted = activeOrders.isDeleted,
        //            memberName = cartBLL.getMemberbyCartId(activeOrders.cartId).name,
        //            orderStatus = addressBLL.getStatusById(activeOrders.statusId).name,
        //            productName = cartBLL.getProductbyCartId(activeOrders.cartId).name,
        //            productQty = cartBLL.getCartProductByCartId(activeOrders.cartId).quantity.ToString(),
        //            shippingCharge = activeOrders.shippingCharge,
        //            shippingDescription = activeOrders.description,
        //            stateId = addressBLL.getCityById(addressBLL.getAddressById(activeOrders.addressId).cityId).stateId,
        //            taxAmt = activeOrders.taxAmount,
        //            totalAmt = activeOrders.totalAmount,
        //        };
        //    return activeOrderDetails;
        //}
        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            OrderCL orderCL = new OrderCL();
            orderCL.id = id;
            orderCL.description = txtShippingDescription.Text;
            orderCL.statusId = Convert.ToInt32(ddlShippingStatus.SelectedValue);
            OrderBLL orderBLL = new OrderBLL();
            OrderCL newOrderCL = orderBLL.updateShippingDetails(orderCL);
            txtShippingDescription.Text = newOrderCL.description;
            ddlShippingStatus.SelectedValue = newOrderCL.statusId.ToString();
        }
        private class UpdateOrderGridCL
        {
            public int id { get; set; }
            public bool memberIsGuest{get;set;}
            public string memberName { get; set; }
            public string memberAddressType { get; set; }
            public string memberAddress { get; set; }
            public string memberMobNo { get; set; }
            public bool memberGender { get; set; }
            public DateTime memberJoinDate { get; set; }
            public DateTime memberModifiedDate { get; set; }
            public int memberCityId { get; set; }
            public int memberStateId { get; set; }
            public string memberCountryName { get; set; }
            public int productCount { get; set; }
            public string productId{get;set;}
            public string productName { get; set; }
            public string productQty { get; set; }
            public string productShippingCharge { get; set; }
            public string productDispatchTime { get; set; }
            public string productPrice { get; set; }
            public string orderSubTotalAmt { get; set; }
            public string orderTaxAmt { get; set; }
            public string orderTotalShippingCharge { get; set; }
            public string orderTotalAmt { get; set; }
            public int orderStatusId { get; set; }
            public string orderShippingDescription { get; set; }
        }
        private class UpdateProductGridCL
        {
            public string productId{get;set;}
            public string productName { get; set; }
            public string productQty { get; set; }
            public string productShippingCharge { get; set; }
            public string productDispatchTime { get; set; }
            public string productPrice { get; set; }
        }
    }
}