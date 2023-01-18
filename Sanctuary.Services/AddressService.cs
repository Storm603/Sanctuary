using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Sanctuary.Services.Contracts;
using Sanctuary.Services.Data.DTO;
using Sanctuary.Web.Data;
using System.Text.Json;

namespace Sanctuary.Services
{
    public class AddressService : IAddressService
    {
        public ApplicationDbContext context { get; set; }
        public AddressService(ApplicationDbContext context)
        {
            this.context = context;
        }

        public List<string?> RetrieveTownsWithCountriesWhereClinicsAreEstablished()
        {
            return context.MtClinicAddresses.Include(x => x.Address).Select(x => x.Address.Town)
                .Distinct().ToList();

            
            /// returns country and towns(distincted)
            //return context.MtClinicAddresses.Include(x => x.Address).Select(x => string.Join(" ", new
            //{
            //    x.Address.Country,
            //    x.Address.Town,
            //})).Distinct().ToList();
        }

        //retrieves latitude and longitude for clinics from address table
        public string RetrieveClinicLatitudeAndLongitude()
        {
            Location[] geoData = context.Clinics.Include(x => x.Address).Select(x => new Location()
            {
                lat = x.Address.Address.lat.Value,
                lng = x.Address.Address.lon.Value
            }).ToArray();

            var jsonInfo = JsonSerializer.Serialize(geoData);

            return jsonInfo;
        }
    }
}
