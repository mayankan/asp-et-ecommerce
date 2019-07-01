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
    public partial class HotProduct : System.Web.UI.Page
    {
        ProductBLL productBLL = new ProductBLL();
        ProductCL productCL = new ProductCL();
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
            }

        }
        public class newProductCL
        {
            public int id { get; set; }
            public string productName { get; set; }
            public string imageUrl { get; set; }
            public string feature1 { get; set; }
            public string feature2 { get; set; }
            public string feature3 { get; set; }
            public string feature4 { get; set; }
            public string stockQuantity { get; set; }
            public DateTime dateModified { get; set; }
            public DateTime dateCreated { get; set; }
            public bool isDeleted { get; set; }
            public string productPrice { get; set; }
            public string dispatchTime { get; set; }
            public string shippingCharge { get; set; }
            public string description { get; set; }
            public string warranty { get; set; }
            public string isHot { get; set; }
            public string keywords { get; set; }
            public string weight { get; set; }
            public string codApplicable { get; set; }
        }
        public Collection<newProductCL> ConvertProductToGrid(Collection<ProductCL> productCL)
        {
            Collection<newProductCL> newProductCl = new Collection<newProductCL>();
            foreach (ProductCL item in productCL)
            {
                string[] abc = item.featureDetails.Split(';');
                newProductCl.Add(new newProductCL
                {
                    id = item.Id,
                    productName = item.name,
                    productPrice = item.price.ToString(),
                    feature1 = abc[0],
                    feature2 = abc[1],
                    feature3 = abc[2],
                    feature4 = abc[3],
                    stockQuantity = item.stockQuantity.ToString(),
                    dateCreated = item.dateCreated,
                    dateModified = item.dateModified,
                    isDeleted = item.isDeleted,
                    description = item.description,
                    imageUrl = "../" + item.imageUrl,
                    warranty = item.warranty,
                    weight = item.weight.ToString(),
                    keywords = item.keywordsMeta,
                    codApplicable = (item.codApplicable) ? "Yes" : "No",
                    isHot = (item.isHot) ? "Yes" : "No",
                    dispatchTime = item.dispatchTime.ToString(),
                    shippingCharge = item.shippingCharge.ToString(),
                });
            }
            return newProductCl;
        }
        private void ShowNoResultFound(Collection<newProductCL> source, GridView gv)
        {
            // source.Rows.Add(source.NewRow()); // create a new blank row to the DataTable

            source.Add(new newProductCL()
            {
                dateCreated = DateTime.Now,
                dateModified = DateTime.Now,
                isDeleted = false,
                stockQuantity = "300",
                productPrice = 20000.ToString(),
                productName = "abc",
                feature1 = "2",
                feature2 = "0",
                feature3 = "12",
                feature4 = "30",
                imageUrl = "",
                description = ""
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
            Collection<ProductCL> grd = productBLL.getAllProducts();
            Collection<newProductCL> newProdgrd = ConvertProductToGrid(grd);
            var xyz = newProdgrd.Where(x => x.id >= 0);
            if (txtFeature1.Text == string.Empty && txtStkQty.Text == string.Empty && txtPrice.Text == string.Empty && txtName.Text == string.Empty && txtFeature2.Text == string.Empty && txtFeature3.Text == string.Empty && txtFeature4.Text == string.Empty && txtWeight.Text == string.Empty && txtKeywords.Text == string.Empty && ddlCodApplicable.SelectedValue == "0" && txtDispatchTime.Text == string.Empty && txtWarranty.Text == string.Empty && txtShippingCharge.Text == string.Empty)
            {
                if (newProdgrd.Count > 0)
                {
                    GvProductMangmt.DataSource = newProdgrd;
                    GvProductMangmt.DataBind();
                }
                else
                {
                    DataTable dt = new DataTable();
                    ShowNoResultFound(newProdgrd, GvProductMangmt);
                }
            }
            else
            {
                if (txtName.Text != string.Empty)
                {
                    xyz = xyz.Where(x => x.productName.ToLower().Contains(txtName.Text.ToLower()));
                }
                if (txtPrice.Text != string.Empty)
                {
                    xyz = from x in xyz where x.productPrice.Contains(txtPrice.Text) select x;
                }
                if (txtStkQty.Text != string.Empty)
                {
                    xyz = from x in xyz where x.stockQuantity.Contains(txtStkQty.Text) select x;
                }
                if (txtFeature1.Text != string.Empty)
                {
                    xyz = from x in xyz where x.feature1.ToLower().Contains(txtFeature1.Text.ToLower()) select x;
                }
                if (txtFeature2.Text != string.Empty)
                {
                    xyz = from x in xyz where x.feature2.ToLower().Contains(txtFeature2.Text.ToLower()) select x;
                }
                if (txtFeature3.Text != string.Empty)
                {
                    xyz = from x in xyz where x.feature3.ToLower().Contains(txtFeature3.Text.ToLower()) select x;
                }
                if (txtFeature4.Text != string.Empty)
                {
                    xyz = from x in xyz where x.feature4.ToLower().Contains(txtFeature4.Text.ToLower()) select x;
                }
                if (txtKeywords.Text != string.Empty)
                {
                    xyz = from x in xyz where x.keywords.ToLower().Contains(txtKeywords.Text.ToLower()) select x;
                }
                if (txtWeight.Text != string.Empty)
                {
                    xyz = from x in xyz where x.weight.Contains(txtWeight.Text) select x;
                }
                if (ddlCodApplicable.SelectedValue != "0")
                {
                    xyz = from x in xyz where x.codApplicable == ddlCodApplicable.Text select x;
                }
                if (txtDispatchTime.Text != string.Empty)
                {
                    xyz = from x in xyz where x.dispatchTime == txtDispatchTime.Text select x;
                }
                if (txtShippingCharge.Text != string.Empty)
                {
                    xyz = from x in xyz where x.shippingCharge.Contains(txtShippingCharge.Text) select x;
                }
                if (txtWarranty.Text != string.Empty)
                {
                    xyz = from x in xyz where x.warranty.Contains(txtWarranty.Text) select x;
                }
                Collection<newProductCL> xyzUpdate = new Collection<newProductCL>();
                foreach (newProductCL item in xyz)
                {
                    xyzUpdate.Add(new newProductCL
                    {
                        codApplicable = item.codApplicable,
                        dateCreated = item.dateCreated,
                        dateModified = item.dateModified,
                        description = item.description,
                        dispatchTime = item.dispatchTime,
                        feature1 = item.feature1,
                        feature2 = item.feature2,
                        feature3 = item.feature3,
                        feature4 = item.feature4,
                        id = item.id,
                        imageUrl = item.imageUrl,
                        isDeleted = item.isDeleted,
                        isHot = item.isHot,
                        keywords = item.keywords,
                        productName = item.productName,
                        productPrice = item.productPrice,
                        shippingCharge = item.shippingCharge,
                        stockQuantity = item.stockQuantity,
                        warranty = item.warranty,
                        weight = item.weight,
                    });
                }
                if (xyzUpdate.Count() > 0)
                {
                    GvProductMangmt.DataSource = xyzUpdate;
                    GvProductMangmt.DataBind();
                }
                else
                {
                    DataTable dt = new DataTable();
                    ShowNoResultFound(xyzUpdate, GvProductMangmt);
                }
            }

        }
        private void bindGrid()
        {
            Collection<ProductCL> products = productBLL.getAllProducts();
            Collection<newProductCL> prod = ConvertProductToGrid(products);
            if (prod.Count() > 0)
            {
                GvProductMangmt.DataSource = prod;
                GvProductMangmt.DataBind();
            }
            else
            {
                DataTable dt = new DataTable();
                ShowNoResultFound(prod, GvProductMangmt);
            }
        }
        protected void GvProductMangmt_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int productId = Convert.ToInt32(e.CommandArgument);
            Response.Redirect("UpdateProduct.aspx?Id=" + productId + "&spec=prod");
        }
        protected void btnNewProd_Click(object sender, EventArgs e)
        {
            Response.Redirect("CreateProduct.aspx");
        }
    }
}