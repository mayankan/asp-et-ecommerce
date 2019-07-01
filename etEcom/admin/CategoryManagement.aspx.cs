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
    public partial class CatagoryManagement : System.Web.UI.Page
    {
        CategoryCL categoryCL = new CategoryCL();
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
                bindGrid();
            }

        }
        private void bindGrid()
        {
            Collection<CategoryCL> categories = categoryBLL.getAllCategories();
            Collection<newCategoryCL> category = getCatName(categories);
            if (category.Count() > 0)
            {
                GvCategory.DataSource = category;
                GvCategory.DataBind();
            }
            else
            {
                DataTable dt = new DataTable();

                ShowNoResultFound(category, GvCategory);
            }
        }
        private Collection<newCategoryCL> getCatName(Collection<CategoryCL> categories)
        {
            Collection<newCategoryCL> nameFrmPCategoryId = new Collection<newCategoryCL>();

            foreach (CategoryCL item in categories)
            {
                string[] abc = item.featureCategory.Split(';');
                nameFrmPCategoryId.Add(new newCategoryCL   
                {
                    id = item.id,
                    categoryName = item.name,
                    parentCategory = categoryBLL.getCategory(item.parentCategoryId).name,
                    feature1 = abc[0],
                    feature2 = abc[1],
                    feature3 = abc[2],
                    feature4 = abc[3],
                    description = item.description,
                    dateCreated = item.dateCreated,
                    dateModified = item.dateModified,
                    isDeleted = item.isDeleted
                });
            } return nameFrmPCategoryId;
        }
        private void ShowNoResultFound(Collection<newCategoryCL> source, GridView gv)
        {
            // source.Rows.Add(source.NewRow()); // create a new blank row to the DataTable

            source.Add(new newCategoryCL()
            {
                id = 0,
                description = "pqr",
                categoryName = "",
                feature1 = "",
                feature2 = "",
                feature3 = "",
                feature4 = "",
                parentCategory = "",
                isDeleted = false,
                dateCreated = DateTime.Now,
                dateModified = DateTime.Now
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
        protected void btnNewCat_Click(object sender, EventArgs e)
        {
            Response.Redirect("CreateProduct.aspx");
        }
        protected void btnCatSearch_Click(object sender, EventArgs e)
        {
            Collection<CategoryCL> grd = categoryBLL.getAllCategories();
            Collection<newCategoryCL> newGrd = getCatName(grd);
            var xyz = newGrd.Where(x => x.id >= 0);
            if (txtDesc.Text == string.Empty && txtFeature1.Text == string.Empty && txtFeature2.Text == string.Empty && txtFeature3.Text == string.Empty && txtFeature4.Text == string.Empty && txtName.Text == string.Empty && txtParentCategory.Text == string.Empty)
            {
                if (newGrd.Count > 0)
                {
                    GvCategory.DataSource = newGrd;
                    GvCategory.DataBind();
                }
                else
                {
                    DataTable dt = new DataTable();
                    ShowNoResultFound(newGrd, GvCategory);
                }

            }
            else
            {
                if (txtName.Text != string.Empty)
                {
                    xyz = xyz.Where(x => x.categoryName.ToLower().Contains(txtName.Text.ToLower()));
                }
                if (txtParentCategory.Text != string.Empty)
                {
                    xyz = from x in xyz where x.parentCategory == txtParentCategory.Text select x;
                }
                if (txtFeature1.Text != string.Empty)
                {
                    xyz = from x in xyz where x.feature1.ToLower() == txtFeature1.Text.ToLower() select x;
                }
                if (txtFeature2.Text != string.Empty)
                {
                    xyz = from x in xyz where x.feature2.ToLower() == txtFeature2.Text.ToLower() select x;
                }
                if (txtFeature3.Text != string.Empty)
                {
                    xyz = from x in xyz where x.feature3.ToLower() == txtFeature3.Text.ToLower() select x;
                }
                if (txtFeature4.Text != string.Empty)
                {
                    xyz = from x in xyz where x.feature4.ToLower() == txtFeature4.Text.ToLower() select x;
                }
                if (txtDesc.Text != string.Empty)
                {
                    xyz = from x in xyz where x.description.ToLower().Contains(txtDesc.Text.ToLower()) select x;
                }
                Collection<newCategoryCL> xyzUpdate = new Collection<newCategoryCL>();
                foreach (var item in xyz)
                {
                    xyzUpdate.Add(new newCategoryCL()
                    {
                        id = item.id,
                        dateModified = item.dateModified,
                        dateCreated = item.dateCreated,
                        isDeleted = item.isDeleted,
                        categoryName = item.categoryName,
                        description = item.description,
                        feature1 = item.feature1,
                        feature2 = item.feature2,
                        feature3 = item.feature3,
                        feature4 = item.feature4,
                        parentCategory = item.parentCategory
                    });
                }
                if (xyzUpdate.Count() > 0)
                {
                    GvCategory.DataSource = xyzUpdate;
                    GvCategory.DataBind();
                }
                else
                {
                    DataTable dt = new DataTable();
                    ShowNoResultFound(xyzUpdate, GvCategory);
                }
            }

        }
        protected void GvCategory_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int catId = Convert.ToInt32(e.CommandArgument);
            Response.Redirect("UpdateProduct.aspx?Id=" + catId + "&spec=cat");
        }
        public class newCategoryCL
        {
            public int id { get; set; }
            public string categoryName { get; set; }
            public string parentCategory { get; set; }
            public string feature1 { get; set; }
            public string feature2 { get; set; }
            public string feature3 { get; set; }
            public string feature4 { get; set; }
            public DateTime dateModified { get; set; }
            public DateTime dateCreated { get; set; }
            public bool isDeleted { get; set; }
            public string description { get; set; }
        }
    }
}