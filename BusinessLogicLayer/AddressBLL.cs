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
    public class AddressBLL
    {
        //DB Context
        etEcomEntities dbcontext = new etEcomEntities();
        //Instantiates the DataBase model from edmx file in this Solution.
        #region DROPDOWNLISTS
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
        #endregion DROPDOWNLISTS
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
        /// Fetchs the Status CL class By provided statusId.
        /// </summary>
        /// <param name="statusId">StatusId to fetch Status CL class.</param>
        /// <returns>Status CL containing data fetched by StatusId.</returns>
        public StatusCL getStatusById(int statusId)
        {
            Status statusQuery = (from x in dbcontext.Status where x.Id == statusId select x).FirstOrDefault();
            StatusCL statusCL = new StatusCL()
            {
                id = statusQuery.Id,
                name = statusQuery.Name
            };
            return statusCL;
        }
    }
}
