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
    public partial class AddedInCart : System.Web.UI.Page
    {
        OrderBLL orderBLL = new OrderBLL();
        CartBLL cartBLL = new CartBLL();
        AddressBLL addressBLL = new AddressBLL();
        MemberBLL memberBLL = new MemberBLL();
        ProductBLL productBLL = new ProductBLL();
        CategoryBLL categoryBLL = new CategoryBLL();
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
                Collection<CartProductCL> activeCarts = cartBLL.getProductsAddedInCart();//To be pending of added in cart.cartBLL.getAddedInCart()
                Collection<AddedInCartCL> activeCartDetails = ConvertCartToGrid(activeCarts);
                if (activeCartDetails.Count() > 0)
                {
                    grdAddedInCart.DataSource = activeCartDetails;
                    grdAddedInCart.DataBind();
                }
                else
                {
                    DataTable dt = new DataTable();
                    ShowNoResultFound(activeCartDetails, grdAddedInCart);
                }
            }
        }
        private Collection<AddedInCartCL> ConvertCartToGrid(Collection<CartProductCL> cartProductCL)
        {
            Collection<AddedInCartCL> addedInCart = new Collection<AddedInCartCL>();
            foreach (CartProductCL item in cartProductCL)
	        {
                MemberCL fetchDetailsFromMember = memberBLL.getMemberById(cartBLL.getCartbyId(item.cartId).memberId);
                addedInCart.Add(new AddedInCartCL
                    {
                        id=orderBLL.getOrderByCartId(item.cartId).id,
                        cartId = item.id,
                        dateAdded = cartBLL.getCartbyId(item.cartId).dateAdded,
                        dateModified = cartBLL.getCartbyId(item.cartId).dateModified,
                        isDeleted = cartBLL.getCartbyId(item.cartId).isDeleted,
                        shippingCharge = cartBLL.getCartbyId(item.cartId).shippingCost,
                        memberDetails = fetchDetailsFromMember.name + " , " + fetchDetailsFromMember.email,
                        productDetails = productBLL.getProduct(item.productId).name + " -> " + categoryBLL.getCategory(productBLL.getProduct(item.productId).categoryId).name,
                        cartTotalPrice = (Convert.ToInt32(productBLL.getProduct(item.productId).price) * item.quantity).ToString(),
                    });
	        }
            return addedInCart;
        }
        private Collection<AddedInCartCL> ConvertCartToGrid(IEnumerable<AddedInCartCL> cartProductCL)
        {
            Collection<AddedInCartCL> addedInCart = new Collection<AddedInCartCL>();
            foreach (AddedInCartCL item in cartProductCL)
            {
                addedInCart.Add(new AddedInCartCL
                {
                    cartTotalPrice=item.cartTotalPrice,
                    dateAdded=item.dateAdded,
                    dateModified=item.dateModified,
                    id=item.id,
                    isDeleted=item.isDeleted,
                    memberDetails=item.memberDetails,
                    productDetails=item.productDetails,
                    shippingCharge=item.shippingCharge
                });
            }
            return addedInCart;
        }
        private class AddedInCartCL
        {
            public int id { get; set; }
            public int cartId { get; set; }
            public string memberDetails { get; set; }
            public string productDetails { get; set; }
            public string shippingCharge { get; set; }
            public string cartTotalPrice { get; set; }
            public DateTime dateAdded { get; set; }
            public DateTime dateModified { get; set; }
            public bool isDeleted { get; set; }
        }
        private void ShowNoResultFound(Collection<AddedInCartCL> source, GridView gv)
        {
            // source.Rows.Add(source.NewRow()); // create a new blank row to the DataTable

            source.Add(new AddedInCartCL()
            {
                id = 0,
                dateAdded=DateTime.Now,
                dateModified=DateTime.Now,
                isDeleted=false,
                memberDetails="",
                productDetails="",
                shippingCharge="",
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
        protected void btnSearch_Click(object sender, EventArgs e)
        {
           Collection<AddedInCartCL> grdview = ConvertCartToGrid(cartBLL.getProductsAddedInCart());
            var grdviewInstance = grdview.Where(x => x.id >= 0);
            if (txtMemberDetails.Text == string.Empty && txtProductDetails.Text == string.Empty && txtDatePickerAdded.Text == string.Empty && txtDatePickerModified.Text == string.Empty)
            {
                if(grdview.Count()>0)
                {
                    grdAddedInCart.DataSource = grdview;
                    grdAddedInCart.DataBind();
                }
                else
                {
                    DataTable dt = new DataTable();
                    ShowNoResultFound(grdview, grdAddedInCart);                    
                }
            }
            else
            {
                if (txtMemberDetails.Text != string.Empty)
                {
                    grdviewInstance = from x in grdviewInstance where x.memberDetails.ToLower().Contains(txtMemberDetails.Text.ToLower()) select x;
                }
                if (txtProductDetails.Text != string.Empty)
                {
                    grdviewInstance = from x in grdviewInstance where x.productDetails.ToLower().Contains(txtProductDetails.Text.ToLower()) select x;
                }
                if (txtDatePickerAdded.Text != string.Empty)
                {
                    grdviewInstance = from x in grdviewInstance where x.dateAdded.Date == Convert.ToDateTime(txtDatePickerAdded.Text).Date select x;
                }
                if (txtDatePickerModified.Text != string.Empty)
                {
                    grdviewInstance = from x in grdviewInstance where x.dateModified.Date == Convert.ToDateTime(txtDatePickerModified.Text).Date select x;
                }
                if (grdviewInstance.Count() > 0)
                {
                    grdAddedInCart.DataSource = ConvertCartToGrid(grdviewInstance);
                    grdAddedInCart.DataBind();
                }
                else
                {
                    DataTable dt = new DataTable();
                    ShowNoResultFound(ConvertCartToGrid(grdviewInstance), grdAddedInCart);
                }
            }
        }
        protected void grdAddedInCart_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int orderId = Convert.ToInt32(e.CommandArgument);
            Response.Redirect("UpdateOrder.aspx?id=" + orderId);
        }
    }
}