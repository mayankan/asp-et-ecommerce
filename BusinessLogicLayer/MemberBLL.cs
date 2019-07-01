using CommunicationLayer;
using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace BusinessLogicLayer
{
    public class MemberBLL
    {
        etEcomEntities dbcontext = new etEcomEntities();
        /// <summary>
        /// Creates a new address entity for each member in  the database
        /// </summary>
        /// <param name="addCL">Address Details of new member to be added in the Database.</param>
        /// <returns>Returns the class containing the created address. </returns>
        public AddressCL createAddress(AddressCL addCL)
        {
            Address address = dbcontext.Addresses.Add(new Address
                {
                    AddressLine1 = addCL.addressLine1,
                    AddressLine2 = addCL.addressLine2,
                    AddressLine3 = addCL.addressLine2,
                    AddressTypeId = addCL.addressTypeId,
                    CityId = addCL.cityId,
                    Id = 0,
                });
            dbcontext.SaveChanges();
            AddressCL addressCl = new AddressCL()
            {
                id = address.Id,
                cityId = address.CityId,
                addressTypeId = address.AddressTypeId,
                addressLine1 = address.AddressLine1,
                addressLine2 = address.AddressLine2,
                addressLine3 = address.AddressLine3
            };
            return addressCl;
        }
        /// <summary>
        /// Creates a new Member entity in Database.
        /// </summary>
        /// <param name="memberCL">General Details of new member to be added in the Database.</param>        
        /// <returns>Class of Member which contains created data.</returns>
        /// 
        public MemberCL createMember(MemberCL memberCL)
        {
            Member memBer = dbcontext.Members.Add(new Member
            {
                DateCreated = DateTime.Now,
                DateModified = DateTime.Now,
                Id = memberCL.id,
                AddressId = memberCL.addressId,
                Email = memberCL.email,
                Gender = memberCL.gender,
                IsDeleted = memberCL.isDeleted,
                IsGuest = memberCL.isGuest,
                MobileNumber = memberCL.mobNo,
                Name = memberCL.name,
                Password = memberCL.password,
            });
            dbcontext.SaveChanges();
            MemberCL memberCLchanged = new MemberCL()
            {
                id = memBer.Id,
                addressId = memBer.AddressId,
                email = memBer.Email,
                gender = memBer.Gender,
                isDeleted = memBer.IsDeleted,
                isGuest = memBer.IsGuest,
                mobNo = memBer.MobileNumber,
                name = memBer.Name,
                password = memBer.Password
            };
            return memberCLchanged;
        }
        /// <summary>
        /// Checks the user login authentication.
        /// </summary>
        /// <param name="memberCL">Username are entered by the user</param>
        /// <returns>Returns a member class instance checking whether username exists and are correct.</returns>
        public bool chkUserName(string username)
        {
            IEnumerable<Member> chkUName = (from x in dbcontext.Members where x.Email == username select x);
            bool returnvalue = false;
            if (chkUName != null)
            {
                foreach (Member item in chkUName)
                {
                    if (username ==item.Email)
                    {
                        returnvalue = true;
                    }
                }

                //if (chkUName.Email  memberCL.email)
                //{
                //    returnvalue = true;
                //}
            }
            return returnvalue;
        }
        /// <summary>
        /// Checks if the Password is correct or not.
        /// </summary>
        /// <param name="memberCL">Pasword entered By the User.</param>
        /// <returns>Returns a member class instance checking whether password is correct or not. </returns>
        public bool chkPassword(MemberCL memberCL)
        {
            Member query = (from x in dbcontext.Members where x.Id == memberCL.id && x.IsDeleted == false select x).FirstOrDefault();
            if (query.Password == memberCL.password)
            {
                return false;
            }
            else
                return true;
        }
        /// <summary>
        /// Updates the Entity of Member in the Database.
        /// </summary>
        /// <param name="memberCL">Member Entity to be changed.</param>
        /// <param name="addressCL">Address Entitiy to be changed.</param>
        /// <param name="addressTypeCL">AddressType Entitiy to be changed.</param>
        /// <returns>Updated Member Entity.</returns>
        public MemberCL updateMember(MemberCL memberCL)
        {
            Member query = (from type in dbcontext.Members where type.Id == memberCL.id && type.IsDeleted == false && type.Password!=memberCL.password select type).FirstOrDefault();
            Member newMember = query;
            newMember.AddressId = memberCL.addressId;
            newMember.Email = memberCL.email;
            newMember.Gender = memberCL.gender;
            newMember.IsDeleted = memberCL.isDeleted;
            newMember.IsGuest = memberCL.isGuest;
            newMember.MobileNumber = memberCL.mobNo;
            newMember.Name = memberCL.name;
            newMember.Password = memberCL.password;
            dbcontext.SaveChanges();
            MemberCL updateddata = new MemberCL()
            {
                email = newMember.Email,
                gender = newMember.Gender,
                id = newMember.Id,
                isDeleted = newMember.IsDeleted,
                isGuest = newMember.IsGuest,
                mobNo = newMember.MobileNumber,
                name = newMember.Name,
                password = newMember.Password,
                addressId=newMember.AddressId,
                dateModified=DateTime.Now
            };
            return updateddata;
        }
        /// <summary>
        /// Update the Member's address in the Database.
        /// </summary>
        /// <param name="addCL">Address entity to be changed.</param>
        /// <returns>Returns Updated Address entity.</returns>
        public AddressCL updateAddress(AddressCL addCL) 
        {
            Address address = (from type in dbcontext.Addresses where type.Id == addCL.id select type).FirstOrDefault();
            Address newAddress = address;
            newAddress.AddressLine1 = addCL.addressLine1;
            newAddress.AddressLine2 = addCL.addressLine2;
            newAddress.AddressLine3 = addCL.addressLine3;
            newAddress.AddressTypeId = addCL.addressTypeId;
            newAddress.CityId = addCL.cityId;
            dbcontext.SaveChanges();
            AddressCL updatedAddress = new AddressCL() 
            {
                addressLine1=newAddress.AddressLine1,
                addressLine2=newAddress.AddressLine2,
                addressLine3=newAddress.AddressLine3,
                addressTypeId=newAddress.AddressTypeId,
                cityId=newAddress.CityId
            };
            return updatedAddress;
        }
        /// <summary>
        /// Deletes the Member User Id with reference to Member Primary Key Id.
        /// </summary>
        /// <param name="memberCL">Member Id</param>
        /// <returns>Deleted Member Communication Layer Class.</returns>
        public MemberCL deleteMember(MemberCL memberCL)
        {
            Member query = (from x in dbcontext.Members where x.Id == memberCL.id select x).FirstOrDefault();
            query.IsDeleted = true;
            dbcontext.SaveChanges();
            memberCL.addressId = query.AddressId;
            memberCL.email = query.Email;
            memberCL.gender = query.Gender;
            memberCL.isDeleted = query.IsDeleted;
            memberCL.isGuest = query.IsGuest;
            memberCL.mobNo = query.MobileNumber;
            memberCL.name = query.Name;
            memberCL.password = query.Password;
            return memberCL;
        }
        /// <summary>
        /// Checks the login authentication of the user.
        /// </summary>
        /// <param name="memberCL">Username and Password inputed by the user.</param>
        /// <returns>Boolean value whether user is authenticated or not.</returns>
        public bool login(MemberCL memberCL)
        {
            IQueryable<Member> check = from type in dbcontext.Members where type.Email == memberCL.email && type.Password == memberCL.password select type;
            //where type.Email.Contains(memberCL.email) 
            bool flag = false;
            foreach (Member item in check)
            {
                if (item.Email == memberCL.email)
                    if (item.Password == memberCL.password)
                        flag = true;
            };

            return flag;
        }
        /// <summary>
        /// Get All Members in the Member Table from the Database.
        /// </summary>
        /// <returns>All Members Data in Communication Layer Collection available in Database.</returns>
        public Collection<MemberCL> getMember()
        {
            Collection<MemberCL> memberCL = new Collection<MemberCL>();
            IQueryable<Member> query = from x in dbcontext.Members where x.IsGuest == false && x.IsDeleted == false select x;
            foreach (Member item in query)
            {
                memberCL.Add(new MemberCL
                    {
                        addressId = item.AddressId,
                        email = item.Email,
                        gender = item.Gender,
                        id = item.Id,
                        isDeleted = item.IsDeleted,
                        isGuest = item.IsGuest,
                        mobNo = item.MobileNumber,
                        name = item.Name,
                        password = item.Password,
                    });
            }
            return memberCL;
        }
        /// <summary>
        /// Get All Guests in the Member Table from the Database.
        /// </summary>
        /// <returns>All Guest Data in Communication Layer Collection available in Database.</returns>
        public Collection<MemberCL> getGuest()
        {
            Collection<MemberCL> memberCL = new Collection<MemberCL>();
            IQueryable<Member> query = from x in dbcontext.Members where x.IsGuest == true && x.IsDeleted == false select x;
            foreach (Member item in query)
            {
                memberCL.Add(new MemberCL
                {
                    addressId = item.AddressId,
                    email = item.Email,
                    gender = item.Gender,
                    id = item.Id,
                    isDeleted = item.IsDeleted,
                    isGuest = item.IsGuest,
                    mobNo = item.MobileNumber,
                    name = item.Name,
                    password = item.Password,
                });
            }
            return memberCL;
        }
        /// <summary>
        /// Gets the Address Entity in the Database by addressId.
        /// </summary>
        /// <param name="addressId">AddressId for Address Entry to be fetched</param>
        /// <returns>Address Communication Layer Class queried by the input.</returns>
        public AddressCL getAddressById(int addressId)
        {
            Address query = (from x in dbcontext.Addresses where x.Id == addressId select x).FirstOrDefault();
            AddressCL addressCL = new AddressCL()
            {
                addressLine1 = query.AddressLine1,
                addressLine2 = query.AddressLine2,
                addressLine3 = query.AddressLine3,
                addressTypeId = query.AddressTypeId,
                cityId = query.CityId,
                id = query.Id
            };
            return addressCL;
        }
        /// <summary>
        /// Gets the State Entity in Communication Layer Class By City.
        /// </summary>
        /// <param name="cityId">City Id entered by user.</param>
        /// <returns>State Communication Layer Class entered by the user.</returns>
        public StateCL getStateByCityId(int cityId)
        {
            int stateId = (from x in dbcontext.Cities where x.Id == cityId select x.StateId).FirstOrDefault();
            State stateQuery = (from x in dbcontext.States where x.Id == stateId select x).FirstOrDefault();
            StateCL stateCL = new StateCL()
            {
                id = stateQuery.Id,
                countryId = stateQuery.CountryId,
                name = stateQuery.Name
            };
            return stateCL;
        }
        /// <summary>
        /// Gets all the Cities in the Database in a Collection Communication Layer.
        /// </summary>
        /// <returns>Collection of City Communication Layer Class.</returns>
        public Collection<CityCL> getCityByStateId(int stateId)
        {
            IQueryable<City> allCity = from x in dbcontext.Cities where x.StateId == stateId select x;
            Collection<CityCL> allCityData = new Collection<CityCL>();
            foreach (City item in allCity)
            {
                allCityData.Add(new CityCL
                    {
                        id = item.Id,
                        name = item.Name,
                        stateId = item.StateId
                    });
            }
            return allCityData;
        }
        /// <summary>
        /// Gets all the States in the Database in a Collection Communication Layer.
        /// </summary>
        /// <returns>Collection of State Communication Layer Class.</returns>
        public Collection<StateCL> getAllState()
        {
            IQueryable<State> getAll = from x in dbcontext.States select x;
            Collection<StateCL> getAllStateData = new Collection<StateCL>();
            foreach (State item in getAll)
            {
                getAllStateData.Add(new StateCL
                    {
                        id = item.Id,
                        name = item.Name,
                        countryId = item.CountryId
                    });
            }
            return getAllStateData;
        }
        /// <summary>
        /// Gets City, State & Country by Inputting City id.
        /// </summary>
        /// <param name="cityId">City Id for fetching All Location.</param>
        /// <returns>Address containing city, state & Country with Id.</returns>
        public AddressLocationCL getCityById(int cityId)
        {
            City query = (from x in dbcontext.Cities where x.Id == cityId select x).FirstOrDefault();
            AddressLocationCL cityCL = new AddressLocationCL()
            {
                id = query.Id,
                stateId = query.StateId,
                countryId = query.State.CountryId,
                cityName = query.Name,
                stateName = query.State.Name,
                countryName = query.State.Country.Name
            };
            return cityCL;
        }
        /// <summary>
        /// Gets the Member by username.
        /// </summary>
        /// <param name="userName">User name for fetching meber From dtabase.</param>
        /// <returns>Instance of member Class with Username.</returns>
        public MemberCL getMemberByUserName(string userName) 
        {
           Member username = (from x in dbcontext.Members where x.Email == userName && x.IsDeleted==false select x).FirstOrDefault();
           MemberCL memberCL = new MemberCL() 
           {
               name=username.Name,
               email=username.Email,
               addressId=username.AddressId,
               gender=username.Gender,
               mobNo=username.MobileNumber,
               isDeleted=username.IsDeleted,
               isGuest=username.IsGuest,
               password=username.Password,
               id=username.Id
           };
           return memberCL;
        }
        /// <summary>
        /// Get the Member by Member Id.
        /// </summary>
        /// <param name="memberId">Fetching Members by member Id.</param>
        /// <returns>Member class Instance from member ID.</returns>
        public MemberCL getMemberById(int memberId)
        {
            Member query = (from x in dbcontext.Members where x.Id == memberId select x).FirstOrDefault();
            MemberCL memberCL = new MemberCL()
            {
                addressId = query.AddressId,
                dateCreated = query.DateCreated,
                dateModified = query.DateModified,
                email = query.Email,
                gender = query.Gender,
                id = query.Id,
                isDeleted = query.IsDeleted,
                isGuest = query.IsGuest,
                mobNo = query.MobileNumber,
                name = query.Name,
                password = query.Password,
            };
            return memberCL;
        }
    }
}
