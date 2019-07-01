using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunicationLayer;
using System.Collections.ObjectModel;

namespace BusinessLogicLayer
{
    public class ContactBLL
    {
        //DB Context
        etEcomEntities dbContext = new etEcomEntities();
        //Instantiates the DataBase model from edmx file in this Solution.
        /// <summary>
        /// Creates a new Contact provided ContactCL class in the input.
        /// </summary>
        /// <param name="contactCL">ContactCL item provided to be added in the DB.</param>
        /// <returns>ContactCL class with updated id & data that has been created.</returns>
        public ContactCL createContact(ContactCL contactCL)
        {
            Contact contact = dbContext.Contacts.Add(new Contact
            {   
                DateAdded=contactCL.dateAdded,
                CityId=contactCL.cityId,
                EmailId=contactCL.emailId,
                Id=contactCL.id,
                MobileNumber=contactCL.mobNo,
                Name=contactCL.name,
                Query=contactCL.query                
            });
            dbContext.SaveChanges();
            ContactCL newContactCL = new ContactCL()
            {
                cityId= contact.CityId,
                emailId = contact.EmailId,
                id = contact.Id,
                mobNo = contact.MobileNumber,
                name = contact.Name,
                query = contact.Query,
                dateAdded=contact.DateAdded
            };
            return newContactCL;
        }
        /// <summary>
        /// Fetchs the Contact CL class by provided Id in the method.
        /// </summary>
        /// <param name="contactId">contactId for fetching the data.</param>
        /// <returns>ContactCL class having data fetched by contactId.</returns>
        public ContactCL getContactById(int contactId)
        {
            Contact contacts = (from contactInfo in dbContext.Contacts where contactInfo.Id == contactId select contactInfo).FirstOrDefault();
            ContactCL getContact = new ContactCL() 
            {
                id=contacts.Id,
                emailId=contacts.EmailId,
                mobNo=contacts.MobileNumber,
                query=contacts.Query,
                name=contacts.Name,
                dateAdded=contacts.DateAdded,
                cityId=contacts.CityId
            };
            return getContact;
        }
        /// <summary>
        /// Fetchs all the Query data in the contact table.
        /// </summary>
        /// <returns>Collection of ContactCL class containing the query data.</returns>
        public Collection<ContactCL> getAllContacts()
        {
            Collection<ContactCL> contacts = new Collection<ContactCL>();
            IEnumerable<Contact> contactDB = from queries in dbContext.Contacts select queries;
            foreach (Contact item in contactDB)
            {
                contacts.Add(new ContactCL() 
                {
                    id=item.Id,
                    name=item.Name,
                    cityId=item.CityId,
                    query=item.Query,
                    mobNo=item.MobileNumber,
                    emailId=item.EmailId,
                    dateAdded=item.DateAdded                    
                });
            }
            return contacts;
        }
    }
}
