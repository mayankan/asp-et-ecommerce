using BusinessLogicLayer;
using CommunicationLayer;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace etEcom.admin
{
    public partial class UpdateProduct : System.Web.UI.Page
    {
        string featureDetails;
        string imageUl;
        int id = 0;
        string spec;
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
            CategoryBLL categoryBLL = new CategoryBLL();
            BrandBLL brandBLL = new BrandBLL();

            spec = Request.QueryString["spec"];
            id = Convert.ToInt32(Request.QueryString["id"]);
            switch (spec)
            {
                case "prod":
                    disableCategory();
                    disableBrand();
                    bindProducts(id);
                    break;
                case "brand":
                    disableProduct();
                    disableCategory();
                    bindBrands(id);
                    break;
                case "cat":
                    disableProduct();
                    disableBrand();
                    bindCategories(id);
                    break;
                // default:                    
            };
            if (!IsPostBack)
            {
                Collection<CategoryCL> categoriesInProduct = categoryBLL.viewCategory();
                //Initialises the Categories from the DataBase.
                lstPCategoryName.DataSource = from x in categoriesInProduct select x;
                lstPCategoryName.DataTextField = "name";
                lstPCategoryName.DataValueField = "id";
                //Adds the Names of Categories in the DropDown List.
                lstPCategoryName.DataBind();
                //Binds the data in the DropDown List.
                Collection<BrandCL> brandsInProduct = brandBLL.viewBrand();
                //Initialises the Brands from the DataBase.
                lstPBrandName.DataSource = from x in brandsInProduct select x;
                lstPBrandName.DataTextField = "name";
                lstPBrandName.DataValueField = "id";
                //Adds the Names of Brands in the DropDown List.
                lstPBrandName.DataBind();
                //Binds the data in the DropDown List.
                lstCParentCategory.DataSource = from x in categoriesInProduct select x;
                lstCParentCategory.DataTextField = "name";
                lstCParentCategory.DataValueField = "id";
                //Adds the Names of Categories in the DropDown List.
                lstCParentCategory.DataBind();
                
            }
        }
        #region Disable Input Types
        private void disableProduct()
        {
            txtProductName.Enabled = false;
            txtProductPrice.Enabled = false;
            txtPStockQty.Enabled = false;
            txtWeight.Enabled = false;
            ddlWeight.Enabled = false;
            txtKeywords.Enabled = false;
            ddlDispatchTime.Enabled = false;
            ddlCODApplicable.Enabled = false;
            txtPCategoryName.Enabled = false;
            txtPBrandName.Enabled = false;
            lstPBrandName.Enabled = false;
            lstPCategoryName.Enabled = false;
            btnProduct.Enabled = false;
            txtShippingCharge.Enabled = false;
        }
        private void disableCategory()
        {
            txtCategoryName.Enabled = false;
            txtCDesc.Enabled = false;
            lstCParentCategory.Enabled = false;
            ddlFeatureCategoryItems.Enabled = false;
            btnCategory.Enabled = false;
        }
        private void disableBrand()
        {
            txtBName.Enabled = false;
            txtBDiscount.Enabled = false;
            ddlBRating.Enabled = false;
            btnBrand.Enabled = false;
        }
        #endregion
        #region Bind Input Types with Data from database.
        private void bindProducts(int productId)
        {
            ProductBLL prodBLL = new ProductBLL();
            ProductCL prodCL = prodBLL.getProduct(productId);
            txtProductName.Text = prodCL.name;
            txtProductPrice.Text = prodCL.price.ToString();
            lstPBrandName.SelectedValue = prodCL.brandId.ToString();
            lstPCategoryName.SelectedValue = prodCL.categoryId.ToString();
            txtPStockQty.Text = prodCL.stockQuantity.ToString();
            txtShippingCharge.Text = prodCL.shippingCharge.ToString();
            txtWeight.Text = prodCL.weight.ToString();
            ddlCODApplicable.Text = prodCL.codApplicable.ToString();
            txtKeywords.Text = prodCL.keywordsMeta;
            ddlDispatchTime.Text= prodCL.dispatchTime.ToString();
            txtDesc.Text = prodCL.description;
            txtWarranty.Text = prodCL.warranty;
            checkHot.Checked = prodCL.isHot;
            string image = prodCL.imageUrl;
            imageUl = image;
            featureDetails = prodCL.featureDetails;
        }
        private void bindBrands(int brandId)
        {
            BrandCL brandCL = new BrandCL();
            BrandBLL brandBLL = new BrandBLL();
            brandCL = brandBLL.getBrands(brandId);
            txtBName.Text = brandCL.name;
            ddlBRating.Text = brandCL.brandRating.ToString();
            txtBDiscount.Text = brandCL.promotions.ToString();
        }
        private void bindCategories(int categoryID)
        {
            CategoryBLL catBLL = new CategoryBLL();
            CategoryCL catCL = catBLL.getCategory(categoryID);
            txtCategoryName.Text = catCL.name;
            txtCDesc.Text = catCL.description;
            lstCParentCategory.SelectedValue = catCL.parentCategoryId.ToString();
            ddlFeatureCategoryItems.Text = catCL.featureCategory;
        }
        #endregion
        #region Button Click Update
        protected void btnCategory_Click(object sender, EventArgs e)
        {
            CategoryCL catCL = new CategoryCL();
            CategoryBLL catBLL = new CategoryBLL();
            catCL.id = id;
            catCL.name = txtCategoryName.Text;
            catCL.parentCategoryId = Convert.ToInt32(lstCParentCategory.SelectedValue);
            if (txtCDesc.Text == null)
            {
                catCL.description = string.Empty;
            }
            else
            {
                catCL.description = txtCDesc.Text;
            }
            if (txtFeatureCategoryItem2.Text == null)
            {
                catCL.featureCategory = txtFeatureCategoryItem1.Text;
            }
            else if (txtFeatureCategoryItem3.Text == null)
            {
                catCL.featureCategory = txtFeatureCategoryItem1.Text + ';' + txtFeatureCategoryItem2.Text;
            }
            else if (txtFeatureCategoryItem4.Text == null)
            {
                catCL.featureCategory = txtFeatureCategoryItem1.Text + ';' + txtFeatureCategoryItem2.Text + ';' + txtFeatureCategoryItem3.Text;
            }
            else
            {
                catCL.featureCategory = txtFeatureCategoryItem1.Text + ';' + txtFeatureCategoryItem2.Text + ';' + txtFeatureCategoryItem3.Text + ';' + txtFeatureCategoryItem4.Text;
            }

            catCL.description = txtCDesc.Text;
            catCL.parentCategoryId = Convert.ToInt32(lstCParentCategory.SelectedValue);
            catCL.dateCreated = DateTime.Now;
            catCL.dateModified = DateTime.Now;
            catCL.isDeleted = false;
            catBLL.updateCategory(catCL);
            lblSuccessfulCategory.Text = "Category Updated Successfully";
        }
        protected void btnBrand_Click(object sender, EventArgs e)
        {
            BrandCL brandCL = new BrandCL();
            BrandBLL brandBLL = new BrandBLL();
            brandCL.id = id;
            brandCL.name = txtBName.Text;
            brandCL.dateCreated = DateTime.Now;
            brandCL.dateModified = DateTime.Now;
            brandCL.brandRating = Convert.ToInt32(ddlBRating.Text);
            brandCL.isDeleted = false;
            brandCL.promotions = Convert.ToDecimal(txtBDiscount.Text);
            brandBLL.updateBrand(brandCL);
            lblSuccessfulBrand.Text = "Brand Updated Successfully";
        }
        protected void btnProduct_Click(object sender, EventArgs e)
        {
            ProductCL prodCL = new ProductCL();
            ProductBLL prodBLL = new ProductBLL();
            prodCL.Id = id;
            prodCL.name = txtProductName.Text;
            prodCL.price = Convert.ToDecimal(txtProductPrice.Text);
            //prodCL.weight = Convert.ToDecimal(txtWeight.Text);
            if (flImage.HasFile)
            {
                flImage.SaveAs(Server.MapPath("~/") + "Images/" + Path.GetFileName(flImage.FileName));
                prodCL.imageUrl = "Images/" + Path.GetFileName(flImage.FileName);
            }
            else
            {
                prodCL.imageUrl = imageUl;
            }
            prodCL.shippingCharge = Convert.ToDecimal(txtShippingCharge.Text);
            prodCL.keywordsMeta = txtKeywords.Text;
            prodCL.stockQuantity = Convert.ToInt32(txtPStockQty.Text);
            prodCL.codApplicable = (ddlCODApplicable.Text == "Yes") ? true : false;
            prodCL.dispatchTime = Convert.ToInt32(ddlDispatchTime.Text);
            if (ddlWeight.Text == "gms.")
            {
                prodCL.weight = Convert.ToDecimal(txtWeight.Text);
            }
            else
            {
                prodCL.weight = Convert.ToDecimal(txtWeight.Text) * 1000;
            }
            prodCL.dateCreated = DateTime.Now;
            prodCL.dateModified = DateTime.Now;
            prodCL.isDeleted = false;
            prodCL.isHot = false;
            prodCL.categoryId = Convert.ToInt32(lstPCategoryName.SelectedValue);
            prodCL.warranty = txtWarranty.Text;
            prodCL.description = txtDesc.Text;
            prodCL.featureDetails = featureDetails;
            prodCL.brandId = Convert.ToInt32(lstPBrandName.SelectedValue);
            ProductCL productCL = prodBLL.updateProduct(prodCL);
            lblSuccessfulProduct.Text = "Product Updated Successfully";
            string url = "UpdateProductPopup.aspx?categoryId=" + productCL.categoryId + "&productId=" + productCL.Id;
            string y = url;
            OpenNewWindows(y);
        }
        public void OpenNewWindows(string url)
        {
            string s = "window.open('" + url + "', 'popup_window', 'width=700,height=500,left=700,top=100,resizable=yes');";
            ClientScript.RegisterStartupScript(this.GetType(), "script", s, true);
            //ClientScript.RegisterStartupScript(this.GetType(), "new Window", String.Format("<script>window.open('http://www.google.com.hk/','_blank');</script>"));
            //(url,windowName,'height=200,width=150')
            // We need the resizable=yes because otherwise Netscape fails to size the window properly... 
            //window.open(FileURL, "Detail", "width=420,height=480,resizable=yes");
            //ClientScript.RegisterStartupScript(this.GetType(), "new Window", String.Format("<script> window.open('"+url+", 'List', 'toolbar=no, location=no,status=yes,menubar=no,scrollbars=yes,resizable=yes, width=900,height=500,left=430,top=100'); return false;</script>"));
        }
        #endregion
        #region Delete methods to be called.(Meenakshi)
        protected void btnDelProd_Click(object sender, EventArgs e)
        {
            ProductBLL productBLL = new ProductBLL();
            ProductCL productCL = new ProductCL();
            productCL.Id = id;
            productBLL.deleteProduct(productCL);
            Response.Redirect("ProductManagement.aspx");
        }

        protected void btnDelBrand_Click(object sender, EventArgs e)
        {
            BrandCL brandCL = new BrandCL();
            BrandBLL brandBLL = new BrandBLL();
            brandCL.id = id;
            brandBLL.deleteBrand(brandCL);
            Response.Redirect("ProductManagement.aspx");
        }

        protected void btnDeleteCat_Click(object sender, EventArgs e)
        {
            CategoryCL catCL = new CategoryCL();
            CategoryBLL catBLL = new CategoryBLL();
            catCL.id = id;
            catBLL.deleteCategory(catCL);
            Response.Redirect("ProductManagement.aspx");
        }
        #endregion
    }
}