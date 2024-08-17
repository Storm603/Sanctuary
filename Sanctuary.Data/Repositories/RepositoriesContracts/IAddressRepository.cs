using Sanctuary.Data.Models.LocationTables;
using Sanctuary.Services.Data.Services.API.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sanctuary.Data.Repositories.RepositoriesContracts
{
    public interface IAddressRepository<TAddress> : IBaseRepository<TAddress> where TAddress : Address
    {
        string? GetDBTownAndCountryThroughPostalCode(string postalCode);
        Task<List<DetailedAddressDTO>> GetAddressDetailsFilteredByZip(string postalCode);
        Task<List<ZipCoordinatesDTO>> GetUniqueClinicsPostalCodesStartingWith(string postalCode);
        Task<List<DetailedAddressDTO>> GetFormattedAddressListByZip(string postalCode);
    }
}
