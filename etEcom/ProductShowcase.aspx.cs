using BusinessLogicLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections.ObjectModel;
using CommunicationLayer;
using System.Web.UI.HtmlControls;

namespace etEcom
{
    public partial class ProductShowcase : System.Web.UI.Page
    {
        ProductBLL productBLL = new ProductBLL();
      
        protected void Page_Load(object sender, EventArgs e)
        {
            bindProducts();
        }
        private void bindProducts()
        {
            Collection<ProductCL> product = productBLL.getAllProducts();
            Collection<newProductCL> products = getProdFeatures(product);
            TableCell tc = new TableCell();
            TableRow tr = new TableRow();
            //HtmlGenericControl div = new HtmlGenericControl("div");
            //div.Style.Add("padding-left", "5px");
            //div.Style.Add("padding-right", "5px");
            int noOfCell = 0;
            foreach (newProductCL item in products)
            {
                ProductList uc = (ProductList)Page.LoadControl("ProductList.ascx");
                uc.prodImage = item.imageUrl;
                uc.prodName = item.productName;
                uc.prodprice = item.productPrice;
                uc.prodFeature1 = item.feature1;
                uc.prodFeature2 = item.feature2;
                uc.prodFeature3 = item.feature3;
                uc.prodFeature4 = item.feature4;
                uc.redirectUrl = "ProductDetail?Id=" + item.id;
                tc = new TableCell();
                tc.Controls.Add(uc);
                tr.Controls.Add(tc);
                noOfCell++;
                if (noOfCell % 4 == 0)
                {
                    tr = new TableRow();
                    tblProducts.Rows.Add(tr);
                }
                else
                {
                    tblProducts.Rows.Add(tr);   
                }

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
        private Collection<newProductCL> getProdFeatures(Collection<ProductCL> products)
        {
            Collection<newProductCL> featuresFromProdId = new Collection<newProductCL>();
            foreach (ProductCL item in products)
            {
                string[] abc = item.featureDetails.Split(';');
                featuresFromProdId.Add(new newProductCL()
                {
                    id=item.Id,
                    productName=item.name,
                    productPrice=item.price.ToString(),
                    feature1=abc[0],
                    feature2=abc[1],
                    feature3=abc[2],
                    feature4=abc[3],
                    imageUrl=item.imageUrl
                });
            }
            return featuresFromProdId;
        }
    }
}