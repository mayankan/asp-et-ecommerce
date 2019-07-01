using BusinessLogicLayer;
using CommunicationLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Collections.ObjectModel;
using System.Web.UI.WebControls;
using System.Data;
using System.Web.Security;

namespace etEcom.admin
{
    public partial class BrandManagement : System.Web.UI.Page
    {
        BrandBLL brandBLL = new BrandBLL();
        private void ShowNoResultFound(Collection<BrandCL> source, GridView gv)
        {
            // source.Rows.Add(source.NewRow()); // create a new blank row to the DataTable

            source.Add(new BrandCL()
            {
                id = 0,
                name = "",
                isDeleted = false,
                dateCreated = DateTime.Now,
                dateModified = DateTime.Now,
                promotions = 0,
                brandRating = 0
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
                bindGrid();
            }
           
        }
        private void bindGrid()
        {
            Collection<BrandCL> brands = brandBLL.getAllBrands();
            if (brands.Count() > 0)
            {
                GvBrand.DataSource = brands;
                GvBrand.DataBind();
            }
            else
            {
                DataTable dt = new DataTable();
                ShowNoResultFound(brands, GvBrand);
            }
        }
        protected void GvBrand_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int brandId = Convert.ToInt32(e.CommandArgument);
            Response.Redirect("UpdateProduct.aspx?Id=" + brandId + "&spec=brand");
        }
        protected void btnBSearch_Click(object sender, EventArgs e)
        {
            Collection<BrandCL> grd = brandBLL.getAllBrands();
            var xyz = grd.Where(x => x.id >= 0);
            if (txtName.Text == string.Empty && txtPromotions.Text == string.Empty && ddlBrandRating.Text == 0.ToString())
            {
                if (grd.Count > 0)
                {
                    GvBrand.DataSource = grd;
                    GvBrand.DataBind();
                }
                else
                {
                    DataTable dt = new DataTable();
                    ShowNoResultFound(grd, GvBrand);
                }
            }
            else
            {
                if (txtName.Text != string.Empty)
                {
                    xyz = from x in xyz where x.name.ToLower().Contains(txtName.Text.ToLower()) select x;
                }
                if (txtPromotions.Text != string.Empty)
                {
                    xyz = from x in xyz where x.promotions == Convert.ToDecimal(txtPromotions.Text) select x;
                }
                if (ddlBrandRating.Text != 0.ToString())
                {
                    xyz = from x in xyz where x.brandRating == Convert.ToInt32(ddlBrandRating.Text) select x;
                }
                Collection<BrandCL> xyzUpdate = new Collection<BrandCL>();
                foreach (var item in xyz)
                {
                    xyzUpdate.Add(new BrandCL()
                        {
                            id = item.id,
                            dateModified = item.dateModified,
                            dateCreated = item.dateCreated,
                            brandRating = item.brandRating,
                            isDeleted = item.isDeleted,
                            name = item.name,
                            promotions = item.promotions
                        });
                }
                if(xyzUpdate.Count() > 0)
                {
                    GvBrand.DataSource = xyzUpdate;
                    GvBrand.DataBind();
                }
                else
                {
                    DataTable dt = new DataTable();
                    ShowNoResultFound(xyzUpdate, GvBrand);
                }
            }
        }
        protected void btnNewBrand_Click(object sender, EventArgs e)
        {
            Response.Redirect("CreateProduct.aspx");
        }
    }
}