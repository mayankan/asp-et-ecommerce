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
    public partial class CreateProduct : System.Web.UI.Page
    {
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
            //Instantiates the Category BusinessLogic Layer Class.
            BrandBLL brandBLL = new BrandBLL();
            //Instantiates the Brand BusinessLogic Layer Class.
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
                //Binds the data in the DropDown List. 
        }
        //Initialises Page Load.
        protected void btnCategory_Click(object sender, EventArgs e)
        {
            CategoryCL categoryCL = new CategoryCL();
            //Instantiates the Category Communication Layer Class.
            CategoryBLL categoryBLL = new CategoryBLL();
            //Instantiates the Category BusinessLogic Layer Class.
        
            categoryCL.dateCreated = DateTime.Now;
            categoryCL.dateModified = DateTime.Now;
            if (txtCDesc.Text==null)
            {
                categoryCL.description = string.Empty;
            }
            else
            {
                categoryCL.description = txtCDesc.Text;
            }
            if(txtFeatureCategoryItem2.Text==null)
            {
                categoryCL.featureCategory = txtFeatureCategoryItem1.Text;
            }
            else if(txtFeatureCategoryItem3.Text==null)
            {
                categoryCL.featureCategory = txtFeatureCategoryItem1.Text + ";" + txtFeatureCategoryItem2.Text;
            }
            else if(txtFeatureCategoryItem4.Text==null)
            {
                categoryCL.featureCategory = txtFeatureCategoryItem1.Text + ";" + txtFeatureCategoryItem2.Text + ";" + txtFeatureCategoryItem3.Text;
            }
            else
            {
                categoryCL.featureCategory = txtFeatureCategoryItem1.Text + ";" + txtFeatureCategoryItem2.Text + ";" + txtFeatureCategoryItem3.Text + ";" + txtFeatureCategoryItem4.Text + ";";
            }
            categoryCL.isDeleted = false;
            categoryCL.name = txtCategoryName.Text;
            categoryCL.parentCategoryId = Convert.ToInt32(lstCParentCategory.SelectedValue);
            //Adds the data entered from the Inputs to the Communication Layer Class instance.
            categoryBLL.createCategory(categoryCL);
            //This method sends the data of the Communication Layer class instance to the Database.
            lblSuccessfulCategory.Text = "Category Created Successfully.";
        }
        //Initialises when the Create Category Button is clicked.
        protected void btnBrand_Click(object sender, EventArgs e)
        {
            BrandCL brandCL = new BrandCL();
            //Instantiates the Brand Communication Layer Class.
            BrandBLL brandBLL = new BrandBLL();
            //Instantiates the Brand BusinessLogic Layer Class.
            brandCL.brandRating= Convert.ToInt32(ddlBRating.SelectedValue);
            brandCL.name=txtBName.Text;
            brandCL.promotions = Convert.ToDecimal(txtBDiscount.Text);
            brandCL.dateCreated = DateTime.Now;
            brandCL.dateModified = DateTime.Now;
            brandCL.isDeleted = false;
            //Adds the data entered from the Inputs to the Communication Layer Class instance.
            brandBLL.createBrand(brandCL);
            //This method sends the data of the Communication Layer class instance to the Database.
            lblSuccessfulBrand.Text = "Brand Created Successfully.";
        }
        //Initialises when the Create Brand Button is clicked.
        protected void btnProduct_Click(object sender, EventArgs e)
        {
            ProductBLL productBLL = new ProductBLL();
            //Instantiates the Product BusinessLogic Layer Class.
            ProductCL productCL = new ProductCL();
            //Instantiates the Product Communication Layer Class.
            if (flImage.HasFile)
            {
                flImage.SaveAs(Server.MapPath("~/") + "Images/" + Path.GetFileName(flImage.FileName));
                productCL.imageUrl = "Images/" + Path.GetFileName(flImage.FileName);
            }
            else
            {
                productCL.imageUrl = "";
            }
            productCL.brandId = Convert.ToInt32(lstPBrandName.SelectedValue);
            productCL.categoryId = Convert.ToInt32(lstPCategoryName.SelectedValue);
            productCL.codApplicable = (ddlCODApplicable.SelectedValue == "Yes") ? true : false;
            productCL.dateCreated = productCL.dateModified = DateTime.Now;
            productCL.dispatchTime = Convert.ToInt32(ddlDispatchTime.SelectedValue);
            productCL.featureDetails = ";;;;";
            productCL.isDeleted = false;
            productCL.shippingCharge = Convert.ToDecimal(txtShippingCharge.Text);
            productCL.keywordsMeta = txtKeywords.Text;
            productCL.name = txtProductName.Text;
            productCL.price = Convert.ToDecimal(txtProductPrice.Text);
            productCL.stockQuantity = Convert.ToInt32(txtPStockQty.Text);
            if(ddlWeight.SelectedValue=="gms.")
            {
                productCL.weight = Convert.ToDecimal(txtWeight.Text);
            }
            else
            {
                productCL.weight = Convert.ToDecimal(txtWeight.Text)*1000;
            }
            productCL.description = txtDesc.Text;
            productCL.warranty = txtWarranty.Text;
            productCL.isHot = checkHot.Checked;
            //Adds the data entered from the Inputs to the Communication Layer Class instance.
            ProductCL pCL = productBLL.createProduct(productCL);
            lblSuccessfulProduct.Text = "Product Created Successfully.";
            //This method sends the data of the Communication Layer class instance to the Database.
            string url = "ProductPopup.aspx?categoryId=" + productCL.categoryId + "&productId=" + pCL.Id;
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
    }
}