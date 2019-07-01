using BusinessLogicLayer;
using CommunicationLayer;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace etEcom
{
    public partial class ProductDetail : System.Web.UI.Page
    {
        //ProductCL products = new ProductCL();
        ProductBLL productBLL = new ProductBLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            int productId = Convert.ToInt32(Request.QueryString["Id"]);
            ProductCL product = productBLL.getAllProducts().Where(ex => ex.Id == productId).FirstOrDefault();
            Collection<newProductCL> products = getProdFeatures(product);
            foreach (newProductCL item in products)
            {
                ProductDet uc = (ProductDet)Page.LoadControl("ProductDet.ascx");
                uc.productPrice = item.productPrice;
                uc.productName = item.productName;
                uc.config1 = item.feature1;
                uc.config2 = item.feature2;
                uc.config3 = item.feature3;
                uc.config4 = item.feature4;
                uc.productImageURl = item.imageUrl;
                uc.ButtonClick += product_Click;
            }

        }
        protected void product_Click(object sender, EventArgs e)
        {
            Response.Redirect("Cart.aspx?id=");
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
            public string productPrice { get; set; }
            public string stockQuantity { get; set; }
            public DateTime dateModified { get; set; }
            public DateTime dateCreated { get; set; }
            public bool isDeleted { get; set; }
            public string dispatchTime { get; set; }
            public string shippingCharge { get; set; }
            public string description { get; set; }
            public string warranty { get; set; }
            public string isHot { get; set; }
            public string keywords { get; set; }
            public string weight { get; set; }
            public string codApplicable { get; set; }
        }
        private Collection<newProductCL> getProdFeatures(ProductCL products)
        {
            Collection<newProductCL> featuresFromProdId = new Collection<newProductCL>();

            string[] abc = products.featureDetails.Split(';');
            featuresFromProdId.Add(new newProductCL()
            {
                id = products.Id,
                productName = products.name,
                productPrice = products.price.ToString(),
                feature1 = abc[0],
                feature2 = abc[1],
                feature3 = abc[2],
                feature4 = abc[3],
                imageUrl = products.imageUrl
            });

            return featuresFromProdId;
        }
    }
}