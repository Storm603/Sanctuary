using Sanctuary.Services.Data.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sanctuary.Services.Contracts
{
    public interface IGeocodingApi
    {
        public Task<Location> GetLatitudeAndLongitudeByName(string countryAndTown);
    }
}
    