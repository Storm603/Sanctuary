using Sanctuary.Services.API.APIContracts;
using Sanctuary.Services.Contracts;
using Sanctuary.Data.Control.ControlContracts;
using Sanctuary.Data.Models.LocationTables;
using Sanctuary.Data.Repositories.RepositoriesContracts;
using Sanctuary.Services.Data.Services.API.DTO;
using Sanctuary.Common;
using System.Text.RegularExpressions;
using Sanctuary.Data;

namespace Sanctuary.Services
{
    public class AddressService : IAddressService
    {
        //private readonly ITransactionalManagementUoW<IAddressRepository<Address>, Address> _unitOfWork;
        private readonly IAPIGoogleGeocodingService _coordRetriever;

        //public AddressService(ITransactionalManagementUoW<IAddressRepository<Address>, Address> unitOfWork, IAPIGoogleGeocodingService coordRetriver)
        //{
        //    this._unitOfWork = unitOfWork;
        //    this._coordRetriever = coordRetriver;
        //}

        private IAddressRepository<Address> Repository;

        public AddressService(IAddressRepository<Address> Repository, IAPIGoogleGeocodingService _coordRetriever)
        {
            this.Repository = Repository;
            this._coordRetriever = _coordRetriever;
        }

        //[UrlSanitization]
        public async Task<List<ZipCoordinatesDTO>?> GetClinicPostalCodesFromSearchBar(string postalCode)
        {
            if (string.IsNullOrWhiteSpace(postalCode) || !Regex.IsMatch(postalCode, RegexConstants.RegexNumbersOnly))
            {
                return null;
            }
            return await Repository.GetUniqueClinicsPostalCodesStartingWith(postalCode);
        }

        //[UrlSanitization]
        public async Task<List<DetailedAddressDTO>?> GetDetailedAddressInZipRange(string postalCode)
        {
            if (string.IsNullOrWhiteSpace(postalCode) || !Regex.IsMatch(postalCode, RegexConstants.RegexNumbersOnly))
            {
                return null;
            }
            return await Repository.GetAddressDetailsFilteredByZip(postalCode);
        }

        public async Task<List<DetailedAddressDTO>?> GetDetailedAddressByZip(string postalCode)
        {
            if (string.IsNullOrWhiteSpace(postalCode) || !Regex.IsMatch(postalCode, RegexConstants.RegexNumbersOnly))
            {
                return null;
            }

            return await Repository.GetFormattedAddressListByZip(postalCode);
        }

        public async Task<CoordinatesDTO?> GetZIPCoordinatesThroughPostalCodeAsync(string postalCode)
        {
            // Gets all parameters(ZIP, Town, Country) through which Google Geocoding API can retrieve specific ZIP code coordinates so the Map on the UI can be centered accordingly on the ZIP area
            string? locationInfo = Repository.GetDBTownAndCountryThroughPostalCode(postalCode);

            // No postal code returns default value
            if (string.IsNullOrEmpty(locationInfo))
            {
                return null;
            }


            // Google Geocoding API call
            return await _coordRetriever.GetGAPILatitudeAndLongitudeByZipTownCountry(locationInfo);
        }
    }
}
