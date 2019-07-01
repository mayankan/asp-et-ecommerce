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
    public class CategoryBLL
    {
        //DB Context
        etEcomEntities dbcontext = new etEcomEntities();
        //Instantiates the DataBase model from edmx file in this Solution.
        /// <summary>
        /// This method query's for Categories Data in DataBase and add that to a Collection which is returned.
        /// </summary>
        /// <returns>Collection of Categories in Database.</returns>
        public Collection<CategoryCL> viewCategory()
        {
            IQueryable<Category> view = from x in dbcontext.Categories select x;
            //Initialises the Categories details already in the database by querying.
            Collection<CategoryCL> categoryCL = new Collection<CategoryCL>();
            //Instantiating a new Collection of Categories Communication Layer Class.
            foreach (Category item in view)
            {
                categoryCL.Add(new CategoryCL
                    {
                        dateCreated = item.DateCreated,
                        dateModified = item.DateModified,
                        description = item.Description,
                        featureCategory = item.FeatureName,
                        id = item.Id,
                        isDeleted = item.IsDeleted,
                        name = item.Name,
                        parentCategoryId = item.ParentCategoryId,
                        categoryCode=item.CategoryCode,
                    });
            }
            //Adding the queried data from query variable to Collection of Categories Communication Layer Class.
            return categoryCL;
            //Returning the Collection of Categories Communication Layer Class.
        }
        /// <summary>
        /// This method creates a Category in the Database.
        /// </summary>
        /// <param name="categoryCL">Details of Category to be created in database.</param>
        /// <returns>Class of Category created in this method.</returns>
        public CategoryCL createCategory(CategoryCL categoryCL)
        {
            Category category = dbcontext.Categories.Add(new Category
                {
                    DateCreated = DateTime.Now,
                    DateModified = DateTime.Now,
                    Description = categoryCL.description,
                    FeatureName = categoryCL.featureCategory,
                    Name = categoryCL.name,
                    ParentCategoryId = categoryCL.parentCategoryId,
                    Id = 0,
                    IsDeleted = categoryCL.isDeleted,
                    CategoryCode="",
                });
            //Adding the data recieved in parameters to DB and to a temporary DataAccess Layer Class.
            dbcontext.SaveChanges();
            string productCode = "";
            if (category.Id.ToString().Length == 1)
            {
                productCode = "000" + category.Id;
            }
            if (category.Id.ToString().Length == 2)
            {
                productCode = "00" + category.Id;
            }
            if (category.Id.ToString().Length == 3)
            {
                productCode = "0" + category.Id;
            }
            if (category.Id.ToString().Length == 4)
            {
                productCode = category.Id.ToString();
            }
            category.CategoryCode = category.Name.Substring(0, 3) + productCode;
            dbcontext.SaveChanges();
            //Updating the Database.
            CategoryCL categoryCl = new CategoryCL()
            {
                dateCreated = category.DateCreated,
                dateModified = category.DateModified,
                description = category.Description,
                featureCategory = category.FeatureName,
                id = category.Id,
                isDeleted = category.IsDeleted,
                name = category.Name,
                categoryCode=category.CategoryCode,
                parentCategoryId = category.ParentCategoryId,
            };
            //Adding the temporary DataAccess Layer Class data to Communication Layer class.
            return categoryCl;
            //Returning the Communication Layer Class with Created Category data on it.
        }
        /// <summary>
        /// The method updates a Category in the Database.
        /// </summary>
        /// <param name="categoryCL">Details of Category to be updated in the database.</param>
        /// <returns>Updated Category Communication Layer Class.</returns>
        public CategoryCL updateCategory(CategoryCL categoryCL)
        {
            Category cat = (from x in dbcontext.Categories where x.Id == categoryCL.id select x).FirstOrDefault();
            //Initialises the query of fetching the Category from the Data Base.
            cat.IsDeleted = categoryCL.isDeleted;
            cat.DateCreated = categoryCL.dateCreated;
            cat.DateModified = categoryCL.dateModified;
            cat.Description = categoryCL.description;
            cat.FeatureName = categoryCL.featureCategory;
            cat.Name = categoryCL.name;
            cat.ParentCategoryId = categoryCL.parentCategoryId;
            //Updating the instance of DataBase to a Inputed Communication Layer class instance by the user.
            dbcontext.SaveChanges();
            //Updating the Database.
            categoryCL.dateCreated = cat.DateCreated;
            categoryCL.dateModified = cat.DateModified;
            categoryCL.description = cat.Description;
            categoryCL.featureCategory = cat.FeatureName;
            categoryCL.isDeleted = cat.IsDeleted;
            categoryCL.name = cat.Name;
            categoryCL.parentCategoryId = cat.ParentCategoryId;
            categoryCL.categoryCode = cat.CategoryCode;
            //Updating the Communication Layer class instance by the user data by the instance of DataBase.
            return categoryCL;
            //Returning the Communication Layer Class with Updated Category data on it.
        }
        /// <summary>
        /// The method deletes a Category in the Database.
        /// </summary>
        /// <param name="categoryCL">Details of Category to be deleted in the database.</param>
        /// <returns>Deleted Category Communication Layer </returns>
        public CategoryCL deleteCategory(CategoryCL categoryCL)
        {
            Category cat = (from x in dbcontext.Categories where x.Id == categoryCL.id select x).FirstOrDefault();
            //Initialises the query of fetching the Category from the Data Base.
            cat.IsDeleted = true;
            //Updating the instance of DataBase to a Inputed Communication Layer class instance by the user.
            dbcontext.SaveChanges();
            //Updating the Database.
            categoryCL.dateCreated = cat.DateCreated;
            categoryCL.dateModified = cat.DateModified;
            categoryCL.description = cat.Description;
            categoryCL.featureCategory = cat.FeatureName;
            categoryCL.isDeleted = cat.IsDeleted;
            categoryCL.name = cat.Name;
            categoryCL.categoryCode = cat.CategoryCode;
            categoryCL.parentCategoryId = cat.ParentCategoryId;
            //Updating the Communication Layer class instance by the user data by the instance of DataBase.
            return categoryCL;
            //Returning the Communication Layer Class with Deleted Category data on it.
        }
        /// <summary>
        /// Fetching Data From Category table by Id from database
        /// </summary>
        /// <param name="brandID"></param>
        /// <returns></returns>
        public CategoryCL getCategory(int categoryId)
        {
            Category categoryDB = (from categoryInfo in dbcontext.Categories where categoryInfo.Id == categoryId && categoryInfo.IsDeleted == false select categoryInfo).FirstOrDefault();
            CategoryCL categoryget = new CategoryCL()
            {
                id = categoryDB.Id,
                categoryCode=categoryDB.CategoryCode,
                name = categoryDB.Name,
                description = categoryDB.Description,
                parentCategoryId = categoryDB.ParentCategoryId,
                featureCategory = categoryDB.FeatureName,
                dateCreated = categoryDB.DateCreated,
                dateModified = categoryDB.DateModified,
                isDeleted = categoryDB.IsDeleted
            };
            return categoryget;
            //Returns a Communication Layer Class which is fetching data from Categories table.
        }
        /// <summary>
        /// this method fetches all the data from the Category table
        /// </summary>
        /// <returns></returns>
        public Collection<CategoryCL> getAllCategories()
        {
            //Instantiating a new Collection for the Categories Communication Layer
            Collection<CategoryCL> categories = new Collection<CategoryCL>();
            IQueryable<Category> categoriesDB = (from categoriesInfo in dbcontext.Categories where categoriesInfo.IsDeleted == false select categoriesInfo).OrderBy(x=>x.Id).Skip(1);
            foreach (Category item in categoriesDB)
            {
                categories.Add(new CategoryCL()
                {
                    id = item.Id,
                    categoryCode=item.CategoryCode,
                    name = item.Name,
                    description = item.Description,
                    parentCategoryId = item.ParentCategoryId,
                    featureCategory = item.FeatureName,
                    dateCreated = item.DateCreated,
                    dateModified = item.DateModified,
                    isDeleted = item.IsDeleted
                });
            }
            return categories;
            //returns Collection from the Categories communication layer class
        }
    }
}