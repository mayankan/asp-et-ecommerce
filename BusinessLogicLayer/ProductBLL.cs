using CommunicationLayer;
using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer
{
    public class ProductBLL
    {
        //DB Context
        etEcomEntities dbcontext = new etEcomEntities();
        //Instantiates the DataBase model from edmx file in this Solution.
        /// <summary>
        /// This method creates a Product in the Database.
        /// </summary>
        /// <param name="productCL">>Details of Product to be created in database.</param>
        /// <returns>Class of Product created in this method.</returns>
        public ProductCL createProduct(ProductCL productCL)
        {
            
            Product product = dbcontext.Products.Add(new Product
                {
                    BrandId = productCL.brandId,
                    CategoryId = productCL.categoryId,
                    CODApplicable = productCL.codApplicable,
                    DateCreated = DateTime.Now,
                    DateModified = DateTime.Now,
                    DispatchTime = productCL.dispatchTime,
                    FeatureDetails = productCL.featureDetails,
                    Keywords_Meta = productCL.keywordsMeta,
                    Name = productCL.name,
                    Price = productCL.price,
                    StockQuantity = productCL.stockQuantity,
                    Weight = Convert.ToDecimal(productCL.weight),
                    IsDeleted = false,
                    ShippingCharge = productCL.shippingCharge, 
                    ImageURL=productCL.imageUrl,
                    Warranty=productCL.warranty,
                    Description=productCL.description,
                    IsHot=productCL.isHot,
                    ProductCode="",
                });
            //Adding the data recieved in parameters to DB and to a temporary DataAccess Layer Class.
            dbcontext.SaveChanges();
            string productCode = "";
            if (product.Id.ToString().Length == 1)
            {
                productCode = "000" + product.Id;
            }
            if (product.Id.ToString().Length == 2)
            {
                productCode = "00" + product.Id;
            }
            if (product.Id.ToString().Length == 3)
            {
                productCode = "0" + product.Id;
            }
            if (product.Id.ToString().Length == 4)
            {
                productCode = product.Id.ToString();
            }
            product.ProductCode = product.Name.Substring(0, 3) + productCode;
            dbcontext.SaveChanges();
            //Updating the Database.
            ProductCL productCl = new ProductCL()
            {
                Id = product.Id,
                brandId = product.BrandId,
                categoryId = product.CategoryId,
                codApplicable = product.CODApplicable,
                dateCreated = product.DateCreated,
                dateModified = product.DateModified,
                dispatchTime = product.DispatchTime,
                featureDetails = product.FeatureDetails,
                isDeleted = product.IsDeleted,
                keywordsMeta = product.Keywords_Meta,
                name = product.Name,
                price = product.Price,
                stockQuantity = Convert.ToInt32(product.StockQuantity),//Typecasts to int.
                weight = product.Weight,//Typecasts the variable of any type to string.
                shippingCharge = product.ShippingCharge,
                description=product.Description,
                warranty=product.Warranty,
                imageUrl=product.ImageURL,
                isHot=product.IsHot,
                productCode=product.ProductCode,
            };
            //Adding the temporary DataAccess Layer Class data to Communication Layer class.
            return productCl;
            //Returning the Communication Layer Class with Created Product data on it.
        }
        /// <summary>
        /// The method updates a Product in the Database.
        /// </summary>
        /// <param name="productCL">Details of Product to be updated in the database.</param>
        /// <returns>Updated Product Communication Layer Class.</returns>
        public ProductCL updateProduct(ProductCL productCL)
        {
            Product prod = (from x in dbcontext.Products where x.Id == productCL.Id select x).FirstOrDefault();
            //Initialises the query of fetching the Product from the Data Base.
            prod.IsDeleted = productCL.isDeleted;
            prod.DateCreated = productCL.dateCreated;
            prod.DateModified = productCL.dateModified;
            prod.Name = productCL.name;
            prod.Keywords_Meta = productCL.keywordsMeta;
            prod.Price = productCL.price;
            prod.ShippingCharge = productCL.shippingCharge;
            prod.StockQuantity = productCL.stockQuantity;
            prod.Weight = Convert.ToDecimal(productCL.weight);
            prod.BrandId = productCL.brandId;
            prod.CategoryId = productCL.categoryId;
            prod.CODApplicable = productCL.codApplicable;
            prod.DispatchTime = productCL.dispatchTime;
            prod.FeatureDetails = productCL.featureDetails;
            prod.IsHot = productCL.isHot;
            prod.Description = productCL.description;
            prod.ImageURL = productCL.imageUrl;
            prod.Warranty = productCL.warranty;
            //Updating the instance of DataBase to a Inputed Communication Layer class instance by the user.
            dbcontext.SaveChanges();
            //Updating the Database.
            productCL.dateCreated = prod.DateCreated;
            productCL.dateModified = prod.DateModified;
            productCL.isDeleted = prod.IsDeleted;
            productCL.name = prod.Name;
            productCL.keywordsMeta = prod.Keywords_Meta;
            productCL.price = prod.Price;
            productCL.shippingCharge = prod.ShippingCharge;
            productCL.stockQuantity = Convert.ToInt32(prod.StockQuantity);
            productCL.weight = prod.Weight;
            productCL.brandId = prod.BrandId;
            productCL.categoryId = prod.CategoryId;
            productCL.codApplicable = prod.CODApplicable;
            productCL.dispatchTime = prod.DispatchTime;
            productCL.featureDetails = prod.FeatureDetails;
            productCL.warranty = prod.Warranty;
            productCL.isHot = prod.IsHot;
            productCL.imageUrl = prod.ImageURL;
            productCL.description = prod.Description;
            productCL.productCode = prod.ProductCode;
            //Updating the Communication Layer class instance by the user data by the instance of DataBase.
            return productCL;
            //Returning the Communication Layer Class with Updated Product data on it.
        }
        /// <summary>
        /// The method deletes a Product in the Database.
        /// </summary>
        /// <param name="brandCL">Details of Product to be deleted in the database.</param>
        /// <returns>Deleted Product Communication Layer </returns>
        public ProductCL deleteProduct(ProductCL productCL)
        {
            Product prod = (from x in dbcontext.Products where x.Id == productCL.Id select x).FirstOrDefault();
            //Initialises the query of fetching the Product from the Data Base.
            prod.IsDeleted = true;
            //Updating the instance of DataBase to a Inputed Communication Layer class instance by the user.
            dbcontext.SaveChanges();
            //Updating the Database.
            productCL.isDeleted = prod.IsDeleted;
            //Updating the Communication Layer class instance by the user data by the instance of DataBase.
            return productCL;
            //Returning the Communication Layer Class with Deleted Product data on it.
        }
       /// <summary>
       /// Fetches the data from the product table by Id.
       /// </summary>
       /// <param name="productId"></param>
       /// <returns></returns>        
        public ProductCL getProduct(int productId)
        {
            Product productDB = (from productInfo in dbcontext.Products where productInfo.Id == productId && productInfo.IsDeleted == false select productInfo).FirstOrDefault();
            ProductCL productget = new ProductCL()
            {
                Id = productDB.Id,
                categoryId = productDB.CategoryId,
                brandId = productDB.BrandId,
                name = productDB.Name,
                featureDetails = productDB.FeatureDetails,
                price = productDB.Price,
                stockQuantity = Convert.ToInt32(productDB.StockQuantity),
                dateCreated = productDB.DateCreated,
                dateModified = productDB.DateModified,
                isDeleted = productDB.IsDeleted,
                dispatchTime = productDB.DispatchTime,
                codApplicable = productDB.CODApplicable,
                shippingCharge = productDB.ShippingCharge,
                keywordsMeta = productDB.Keywords_Meta,
                weight = productDB.Weight,
                description = productDB.Description,
                warranty = productDB.Warranty,
                imageUrl = productDB.ImageURL,
                isHot = productDB.IsHot,
                productCode=productDB.ProductCode,
            };
            return productget;
        }
        /// <summary>
        /// This method fetches all the data from the Products Table
        /// </summary>
        /// <returns></returns>
        public Collection<ProductCL> getAllProducts()
        {
            //Initialising a new collection for the Products rtable
            Collection<ProductCL> products = new Collection<ProductCL>();
            IEnumerable<Product> productsDB = from productsInfo in dbcontext.Products where productsInfo.IsDeleted == false select productsInfo;
            //Foreach loop iterates for every single row data.
            //foreach (Product item in productsDB)
            //{
            //    products.Add(new ProductCL()
            //    {
            //        Id = item.Id,
            //        brandId = item.BrandId,
            //        categoryId = item.CategoryId,
            //        name = item.Name,
            //        featureDetails = item.FeatureDetails,
            //        price = item.Price,
            //        stockQuantity = Convert.ToInt32(item.StockQuantity),
            //        dateCreated = item.DateCreated,
            //        dateModified = item.DateModified,
            //        isDeleted = item.IsDeleted,
            //        dispatchTime = item.DispatchTime,
            //        codApplicable = item.CODApplicable,
            //        shippingCharge = item.ShippingCharge,
            //        keywordsMeta = item.Keywords_Meta,
            //        weight = item.Weight,
            //        description=item.Description,
            //        imageUrl=item.ImageURL,
            //        warranty=item.Warranty,
            //        isHot=item.IsHot,
            //        productCode=item.ProductCode,
            //    });
            //}
            //Returning a collection from the Communication Layer Class.
            return products;

        }
        /// <summary>
        /// This method fetches all the hot products from the Products Table
        /// </summary>
        /// <returns></returns>
        public Collection<ProductCL> getAllHotProducts()
        {
            //Initialising a new collection for the Products rtable
            Collection<ProductCL> products = new Collection<ProductCL>();
            IEnumerable<Product> productsDB = from productsInfo in dbcontext.Products where productsInfo.IsDeleted == false && productsInfo.IsHot == true select productsInfo;
            //Foreach loop iterates for every single row data.
            foreach (Product item in productsDB)
            {
                products.Add(new ProductCL()
                {
                    Id = item.Id,
                    brandId = item.BrandId,
                    categoryId = item.CategoryId,
                    name = item.Name,
                    featureDetails = item.FeatureDetails,
                    price = item.Price,
                    stockQuantity = Convert.ToInt32(item.StockQuantity),
                    dateCreated = item.DateCreated,
                    dateModified = item.DateModified,
                    isDeleted = item.IsDeleted,
                    dispatchTime = item.DispatchTime,
                    codApplicable = item.CODApplicable,
                    shippingCharge = item.ShippingCharge,
                    keywordsMeta = item.Keywords_Meta,
                    weight = item.Weight,
                    description = item.Description,
                    imageUrl = item.ImageURL,
                    warranty = item.Warranty,
                    isHot = item.IsHot,
                    productCode=item.ProductCode,
                });
            }
            //Returning a collection from the Communication Layer Class.
            return products;

        }
    }
}
