using Microsoft.EntityFrameworkCore;
using Sanctuary.Data.Models.LocationTables;
using Sanctuary.Data.Repositories.RepositoriesContracts;
using Sanctuary.Services.Data.Services.API.DTO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace Sanctuary.Data.Repositories
{
    public class AddressRepository<TAddress> : BaseRepository<TAddress>, IAddressRepository<TAddress> where TAddress : Address
    {
        public AddressRepository(ApplicationDbContext context) : base(context) { }

        public string? GetDBTownAndCountryThroughPostalCode(string postalCode)
        {
            return null;
            //return base.DbSet.Where(x => x.PostalCode == postalCode).Select(x => new
            //{
            //    result = $"{x.PostalCode}, {x.Town}, {x.Country}"
            //}).FirstOrDefault()!.ToString()!;
        }

        public async Task<List<ZipCoordinatesDTO>> GetUniqueClinicsPostalCodesStartingWith(string postalCode)
        {
            return await DbSet.Where(x =>
                    x.PostalCodeInfo != null && x.ClinicId != null &&
                    x.PostalCodeInfo.PostalCode.StartsWith(postalCode))
                .GroupBy(x => x.PostalCodeInfo!.PostalCode)
            .Select(x => new ZipCoordinatesDTO()
            {
                PostalCode = x.Key,
                lat = x.Select(x => x.PostalCodeInfo!.lat).FirstOrDefault(),
                lon = x.Select(x => x.PostalCodeInfo!.lng).FirstOrDefault(),
            }).ToListAsync();
        }


        public async Task<List<DetailedAddressDTO>> GetAddressDetailsFilteredByZip(string postalCode)
        {
            return await DbSet.Where(x => x.PostalCodeInfo!.PostalCode.StartsWith(postalCode) && x.ClinicId != null)
                .Select(x => new DetailedAddressDTO()
                {
                    Country = x.Country!,
                    Town = x.Town!,
                    StreetName = x.StreetName!,
                    lat = (float)x.lat!,
                    lon = (float)x.lon!,
                }).ToListAsync();
        }

        public async Task<List<DetailedAddressDTO>> GetFormattedAddressListByZip(string postalCode)
        {
            return await DbSet.Where(x => x.PostalCodeInfo!.PostalCode.StartsWith(postalCode) && x.ClinicId != null)
                .OrderBy(x => x.PostalCodeInfo!.PostalCode)
                .Select(x => new DetailedAddressDTO()
                {
                    ClinicName = x.Clinic!.ClinicName,
                    StreetName = x.StreetName!,
                    District = x.District,
                    Town = x.Town!,
                    Zip = x.PostalCodeInfo!.PostalCode,
                    Country = x.Country!,
                    lat = (float) x.lat!,
                    lon = (float) x.lon!,
                }).ToListAsync();
        }
    }
}
