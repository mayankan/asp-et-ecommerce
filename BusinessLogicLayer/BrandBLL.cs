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
    public class BrandBLL
    {
        //DB context
        etEcomEntities dbcontext = new etEcomEntities();
        //Instantiates the DataBase model from edmx file in this Solution.
        /// <summary>
        /// This method query's for Brands Data in DataBase and add that to a Collection which is returned.
        /// </summary>
        /// <returns>Collection of Brands in Database.</returns>
        public Collection<BrandCL> viewBrand()
        {
            IQueryable<Brand> view = from x in dbcontext.Brands where x.IsDeleted==false select x;
            //Initialises the Brands details already in the database by querying.
            Collection<BrandCL> brandCL = new Collection<BrandCL>();
            //Instantiating a new Collection of Brands Communication Layer Class.
            foreach (Brand item in view) 
            {
                brandCL.Add(new BrandCL
                    {
                        id=item.Id,
                        brandCode=item.BrandCode,
                        brandRating=Convert.ToInt32(item.BrandRating),
                        name=item.Name,
                        promotions=item.Promotions,
                        isDeleted=item.IsDeleted,
                        dateCreated=item.DateCreated,
                        dateModified=item.DateModified,
                        imageURL=item.ImageURL,
                    });
            }
            //Adding the queried data from query variable to Collection of Brand Communication Layer Class.
            //string [] abc = brandCL.FirstOrDefault().name.Split() //Spliting a single data with a special character in between by split method.
            return brandCL;
            //Returning the Collection of Brand Communication Layer Class.
        }
        /// <summary>
        /// This method creates a Brand in the Database.
        /// </summary>
        /// <param name="brandCL">Details of Brand to be created in database.</param>
        /// <returns>Class of Brand created in this method.</returns>
        public BrandCL createBrand(BrandCL brandCL)
        {
            Brand brand = dbcontext.Brands.Add(new Brand
                {
                    Id = 0,
                    Name = brandCL.name,
                    BrandCode="",
                    BrandRating = brandCL.brandRating,
                    Promotions = brandCL.promotions,
                    DateCreated = brandCL.dateCreated,
                    DateModified = brandCL.dateModified,
                    IsDeleted = brandCL.isDeleted,
                    ImageURL=brandCL.imageURL,
                });
            //Adding the data recieved in parameters to DB and to a temporary DataAccess Layer Class.
            dbcontext.SaveChanges();
            string productCode = "";
            if (brand.Id.ToString().Length == 1)
            {
                productCode = "000" + brand.Id;
            }
            if (brand.Id.ToString().Length == 2)
            {
                productCode = "00" + brand.Id;
            }
            if (brand.Id.ToString().Length == 3)
            {
                productCode = "0" + brand.Id;
            }
            if (brand.Id.ToString().Length == 4)
            {
                productCode = brand.Id.ToString();
            }
            brand.BrandCode = brand.Name.Substring(0, 3) + productCode;
            dbcontext.SaveChanges();
            //Updating the Database.
            BrandCL brandCl = new BrandCL()
            {
                id = brand.Id,
                brandRating = brand.Id,
                name = brand.Name,
                promotions = brand.Promotions,
                dateCreated = brand.DateCreated,
                dateModified = brand.DateModified,
                isDeleted = brand.IsDeleted,
                brandCode=brand.BrandCode,
                imageURL=brand.ImageURL
            };
            //Adding the temporary DataAccess Layer Class data to Communication Layer class.
            return brandCl;
            //Returning the Communication Layer Class with Created Brand data on it.
        }
        /// <summary>
        /// The method updates a Brand in the Database.
        /// </summary>
        /// <param name="productCL">Details of Brand to be updated in the database.</param>
        /// <returns>Updated Brand Communication Layer Class.</returns>
        public BrandCL updateBrand(BrandCL brandCL)
        {
            Brand brand = (from x in dbcontext.Brands where x.Id == brandCL.id select x).FirstOrDefault();
            //Initialises the query of fetching the Brand from the Data Base.
            brand.IsDeleted = brandCL.isDeleted;
            brand.DateCreated = brandCL.dateCreated;
            brand.DateModified = brandCL.dateModified;
            brand.Name = brandCL.name;
            brand.Promotions = brandCL.promotions;
            brand.BrandRating = brandCL.brandRating;
            brand.ImageURL = brandCL.imageURL;
            //Updating the instance of DataBase to a Inputed Communication Layer class instance by the user.
            dbcontext.SaveChanges();
            //Updating the Database.
            brandCL.dateCreated = brand.DateCreated;
            brandCL.brandCode = brand.BrandCode;
            brandCL.imageURL = brand.ImageURL;
            brandCL.dateModified = brand.DateModified;
            brandCL.promotions = brand.Promotions;
            brandCL.brandRating = Convert.ToInt32(brand.BrandRating);
            brandCL.isDeleted = brand.IsDeleted;
            brandCL.name = brand.Name;
            brandCL.id = brand.Id;
            //Updating the Communication Layer class instance by the user data by the instance of DataBase.
            return brandCL;
            //Returning the Communication Layer Class with Updated Brand data on it.
        }
        /// <summary>
        /// The method deletes a Brand in the Database.
        /// </summary>
        /// <param name="brandCL">Details of Brand to be deleted in the database.</param>
        /// <returns>Deleted Brand Communication Layer </returns>
        public BrandCL deleteBrand(BrandCL brandCL)
        {
            Brand brand = (from x in dbcontext.Brands where x.Id == brandCL.id select x).FirstOrDefault();
            //Initialises the query of fetching the Brand from the Data Base.
            brand.IsDeleted = true;
            //Updating the instance of DataBase to a Inputed Communication Layer class instance by the user.
            dbcontext.SaveChanges();
            //Updating the Database.
            brandCL.isDeleted = brand.IsDeleted;
            //Updating the Communication Layer class instance by the user data by the instance of DataBase.
            return brandCL;
            //Returning the Communication Layer Class with Deleted Brand data on it.
        }
        /// <summary>
        /// This method fetchs the values from Brand table By ID
        /// </summary>
        /// <param name="brandID"></param>
        /// <returns></returns>
        public BrandCL getBrands(int brandID)
        {
            Brand brandDB = (from brandInfo in dbcontext.Brands where brandInfo.Id == brandID && brandInfo.IsDeleted == false select brandInfo).FirstOrDefault();
            BrandCL brandget = new BrandCL()
            {
                id = brandDB.Id,
                name = brandDB.Name,
                promotions = brandDB.Promotions,
                brandRating = Convert.ToInt32(brandDB.BrandRating),
                dateCreated = brandDB.DateCreated,
                dateModified = brandDB.DateModified,
                isDeleted = brandDB.IsDeleted,
                brandCode=brandDB.BrandCode,
                imageURL=brandDB.ImageURL,
            };
            return brandget;
        }
        /// <summary>
        /// This method fetches all the data from the Brand Table
        /// </summary>
        /// <returns></returns>
        public Collection<BrandCL> getAllBrands()
        {
            //Instantiate a new collection for the Brands Communication Layer Class
            Collection<BrandCL> brands = new Collection<BrandCL>();
            IEnumerable<Brand> brandsDB = from brandsInfo in dbcontext.Brands where brandsInfo.IsDeleted == false select brandsInfo;
            foreach (Brand item in brandsDB)
            {
                brands.Add(new BrandCL()
                {
                    id = item.Id,
                    name = item.Name,
                    promotions = item.Promotions,
                    brandRating = Convert.ToInt32(item.BrandRating),
                    dateCreated = item.DateCreated,
                    dateModified = item.DateModified,
                    isDeleted = item.IsDeleted,
                    imageURL=item.ImageURL,
                    brandCode=item.BrandCode,
                });

            }
            return brands;
            //returns Collection From communication Layer Class
        }
    }
}
